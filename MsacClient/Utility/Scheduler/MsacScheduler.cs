using MsacClient.Entities;
using MsacClient.Exceptions;
using MsacClient.Utility.Upload;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MsacClient.Utility.Scheduler
{
    /// <summary>
    /// Class that will automatically handle sending LOTs and ID3s in the background from a list of requests.
    /// </summary>
    public class MsacScheduler : IDisposable
    {
        public delegate void MsacSendErrorEventArgs(IMsacScheduledImage image, string message, Exception ex);

        public MsacScheduler(IMsacConnection connection, MsacUploadManager uploader)
        {
            //Set
            this.connection = connection;
            this.uploader = uploader;

            //Start worker thread
            worker = new Thread(Worker);
            worker.IsBackground = true;
            worker.Name = "Threaded MSAC Worker";
        }

        private readonly IMsacConnection connection;
        private readonly MsacUploadManager uploader;
        private readonly object mutex = new object();
        private readonly List<SchedulerList> lists = new List<SchedulerList>();
        private PsdSendBuilder lastSentPsd;

        /* START ACCESSED BY WORKER ONLY - NO MUTEX NEEDED */

        private DateTime latestPsdSendTime;
        private List<ActiveLot> activeLots = new List<ActiveLot>();

        /* END ACCESSED BY WORKER ONLY - NO MUTEX NEEDED */

        /// <summary>
        /// The text to prepend to the filename on the sync send command to the MSAC.
        /// </summary>
        public string FilenamePrefix { get; set; } = "";

        /// <summary>
        /// The amount of time to wait before an image starts until the MSAC is notified of it.
        /// </summary>
        public TimeSpan ImagePreNotify { get; set; } = TimeSpan.FromMinutes(5);

        /// <summary>
        /// The amount of time to reuse a lot after it has been sent.
        /// </summary>
        public TimeSpan ImageLifespan { get; set; } = TimeSpan.FromMinutes(5);

        /// <summary>
        /// The amount of time to wait to retry an image.
        /// </summary>
        public TimeSpan ErrorDelay { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// The minimum amount of time that an image timing can change before an update is sent to the MSAC.
        /// </summary>
        public TimeSpan ImageFloatingJitter { get; set; } = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Event raised when there was an error sending/updating an image.
        /// </summary>
        public event MsacSendErrorEventArgs MsacSendError;

        /// <summary>
        /// Gets all items across all lists.
        /// </summary>
        private MsacScheduledRequestFromList[] Items
        {
            get
            {
                lock (mutex)
                {
                    //Total the number of items across all lists
                    int total = 0;
                    foreach (var l in lists)
                        total += l.Items.Length;

                    //Build new array
                    MsacScheduledRequestFromList[] items = new MsacScheduledRequestFromList[total];
                    int i = 0;
                    foreach (var l in lists)
                    {
                        foreach (var itm in l.Items)
                            items[i++] = new MsacScheduledRequestFromList
                            {
                                req = itm,
                                list = l
                            };
                    }

                    //Sanity check
                    if (i != total)
                        throw new Exception("Items modified while compiling list.");

                    return items;
                }
            }
        }

        /// <summary>
        /// Creates a new event list used for managing events.
        /// </summary>
        /// <param name="exporterAddress"></param>
        /// <param name="audioChannel"></param>
        /// <returns></returns>
        public IMsacSchedulerList CreateList(string exporterAddress, string audioChannel = "HD1")
        {
            //Create
            SchedulerList list = new SchedulerList(this, exporterAddress, audioChannel);

            //Add to lists
            lock (mutex)
                lists.Add(list);

            return list;
        }

        private bool started;
        private Thread worker;
        private volatile bool stopping;
        private AutoResetEvent signal = new AutoResetEvent(false);
        private DateTime? nextTick;
        private Mutex nextTickMutex = new Mutex();

        /// <summary>
        /// Starts the worker thread.
        /// </summary>
        public void Start()
        {
            //Make sure not already started
            if (started)
                throw new Exception("Threaded command worker is already started.");

            //Start
            started = true;
            worker.Start();
        }

        /// <summary>
        /// Stops the worker
        /// </summary>
        public void Dispose()
        {
            if (started)
            {
                //Send shutdown command
                stopping = true;
                RequestTick();

                //Wait for worker to exit
                worker.Join();
            }
        }

        private void RequestTick()
        {
            //Just request a specifying a minimum value
            RequestTickAt(DateTime.MinValue);
        }

        private void RequestTickAt(DateTime time)
        {
            //Update the next tick time to be the latest value
            nextTickMutex.WaitOne();

            //Calculate minimum time, or if the time isn't set use this
            bool timeUpdated = nextTick == null || (nextTick != null && nextTick.Value > time);
            if (timeUpdated)
                nextTick = time;

            //Release mutex
            nextTickMutex.ReleaseMutex();

            //Set signal if changed and NOT on the worker thread
            if (timeUpdated && (worker == null || Thread.CurrentThread.ManagedThreadId != worker.ManagedThreadId))
                signal.Set();
        }

        private void Worker()
        {
            while (!stopping)
            {
                //Save current time for calculations
                DateTime now = DateTime.Now;

                //Lock mutex to prevent the time from being updated
                nextTickMutex.WaitOne();

                //If a next tick is in the past, tick the graph now. Otherwise, wait for the next item
                if (nextTick != null && nextTick.Value <= now)
                {
                    //Clear it as to not loop infiniately...nodes should put in their requests for a next tick
                    lock (nextTickMutex)
                        nextTick = null;

                    //Release lock on the tick timer now
                    nextTickMutex.ReleaseMutex();

                    //Tick
                    ProcessTick(now).Wait();

                    //Go back to the start of the loop
                    continue;
                }

                //Determine the time until the next event. Use a reasonable default in case we get stuck for whatever reason
                TimeSpan timeout = TimeSpan.FromMinutes(1);
                if (nextTick != null) // If not null, it'll always be in the future
                    timeout = nextTick.Value - now;

                //Release lock on the tick timer now
                nextTickMutex.ReleaseMutex();

                //Convert timeout to milliseconds
                int timeoutMs = (int)timeout.TotalMilliseconds;
                if (timeoutMs <= 0)
                    continue; // Shouldn't ever happen, but in case it does go back and reprocess

                //Wait for a signal
                signal.WaitOne(timeoutMs);
            }
        }

        /// <summary>
        /// Gets the next scheduled tick. Thread safe.
        /// </summary>
        public DateTime? NextTick
        {
            get
            {
                //Lock mutex to prevent the time from being updated
                nextTickMutex.WaitOne();

                //Save
                DateTime? nextTick = this.nextTick;

                //Release lock on the tick timer now
                nextTickMutex.ReleaseMutex();

                return nextTick;
            }
        }

        /// <summary>
        /// Processes a tick and clears the next tick beforehand. Should only be used for debugging.
        /// </summary>
        /// <param name="now"></param>
        public void DebugProcessTick(DateTime now)
        {
            //Clear last tick
            nextTickMutex.WaitOne();
            lock (nextTickMutex)
                nextTick = null;
            nextTickMutex.ReleaseMutex();

            //Process
            ProcessTick(now).Wait();
        }
        
        /// <summary>
        /// Find active lots matching the PSD, ordered by the nearest to the start time.
        /// </summary>
        /// <param name="psd"></param>
        /// <returns></returns>
        private ActiveLot[] FindMatchingLots(MsacScheduledRequest psd)
        {
            var result = activeLots.Where(x => x.Filename == psd.image.Filename && !x.Lot.Cancelled && TimesOverlap(x.Start, x.End, psd.start, psd.end))
                        .OrderBy(x => x.Start.AbsDifference(psd.start)) // find nearest to start
                        .ToArray();
            return result;
        }

        /// <summary>
        /// Processes a tick. Assumes that the next tick has been cleared.
        /// </summary>
        /// <param name="now"></param>
        private async Task ProcessTick(DateTime now)
        {
            //Process PSD work
            MsacScheduledRequest[] psds = await ProcessTickPsd(now);

            //Remove expired lots
            foreach (var lot in activeLots.Where(x => x.End < now).ToArray())
                activeLots.Remove(lot);

            //Find all PSDs and generate/update LOTs
            //Get PSD list sorted by time (already done) then sorted by the referenced filename. This is to aid with easier combining of items.
            var psdsScan = psds.Where(x => x.start >= now && x.image != null).OrderBy(x => x.image.Filename).ToArray();
            List<ActiveLot> usedLots = new List<ActiveLot>();
            int psdScanIndex = 0;
            while (psdScanIndex < psdsScan.Length)
            {
                //Save first and last using this
                MsacScheduledRequest first = psdsScan[psdScanIndex];
                List<MsacScheduledRequest> matchingPsds = new List<MsacScheduledRequest>(); //PSDs with matching images
                while (psdScanIndex < psdsScan.Length && psdsScan[psdScanIndex].image.Filename == first.image.Filename)
                    matchingPsds.Add(psdsScan[psdScanIndex++]);

                //Use these to get the start/duration time of this LOT
                DateTime end = matchingPsds.LastOrDefault().end;

                //Loop through each matching PSD list but only ones within pre-schedule range
                foreach (var psd in matchingPsds.Where(x => x.start - ImagePreNotify <= now))
                {
                    //Get start
                    DateTime start = psd.start;

                    //Check if this overlaps with any existing LOTs with matching filenames
                    TimeSpan duration = end - start;
                    var matchingLots = FindMatchingLots(psd);

                    //If no lots were found, schedule a new one
                    if (matchingLots.Length == 0)
                    {
                        //Snap to the duration of the last lot within ImageTimespan
                        //TODO...

                        //Notify MSAC
                        ActiveLot newLot = await ScheduleNewLotAsync(psd.image, start, duration, now);
                        activeLots.Add(newLot);
                        usedLots.Add(newLot);
                    } else
                    {
                        //Get the lot
                        ActiveLot lot = matchingLots[0];

                        //Only if the LOT hasn't already started sending, adjust timing
                        if (lot.Start > now.AddSeconds(10) && lot.Start != start)
                        {
                            //If the LOT start time is after start, relocate it
                            if (lot.Start > start)
                                await lot.Lot.ModifyStartAsync(start);

                            //If the LOT start time is before start and it hasn't been touched yet, relocate it
                            if (lot.Start < start && !usedLots.Contains(lot))
                                await lot.Lot.ModifyStartAsync(start);
                        }

                        //Use this lot
                        if (!usedLots.Contains(lot))
                            usedLots.Add(lot);
                    }
                }
            }

            //Cancel and remove any lots that were not referenced
            foreach (var unusedLot in activeLots.Where(x => x.Start > latestPsdSendTime && !x.Lot.Cancelled && !usedLots.Contains(x)).ToArray())
            {
                //Attempt to cancel
                try
                {
                    await unusedLot.Lot.CancelSendAsync();
                } catch (Exception ex)
                {
                    //Send error event but otherwise assume it was cancelled.
                    MsacSendError?.Invoke(unusedLot.Image, "Failed to cancel send; Will not retry.", ex);
                }

                //Remove
                activeLots.Remove(unusedLot);
            }

            //Schedule next wakeup to the first PSD's LOT that needs to be sent - May or may not be redundant
            var nextWakeupLot = psds.Where(x => x.start - ImagePreNotify > now && x.image != null);
            if (nextWakeupLot.Count() > 0)
                RequestTickAt(nextWakeupLot.FirstOrDefault().start - ImagePreNotify);
        }

        /// <summary>
        /// Sends the lot to the MSAC and returns it.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="start"></param>
        /// <param name="duration"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        private async Task<ActiveLot> ScheduleNewLotAsync(IMsacScheduledImage image, DateTime start, TimeSpan duration, DateTime now)
        {
            //Upload to the MSAC
            await uploader.UploadImageAsync(image, now);

            //Begin send
            ISyncSendLot lot = await connection.PreSendSyncLotAsync(
                start,
                FilenamePrefix + image.Filename,
                duration,
                null,
                now.AddYears(1),
                image.DataService
            );

            //Wrap
            return new ActiveLot(this, image, lot);
        }

        /// <summary>
        /// Checks if times overlap each other.
        /// </summary>
        /// <param name="aStart"></param>
        /// <param name="aEnd"></param>
        /// <param name="bStart"></param>
        /// <param name="bEnd"></param>
        /// <returns></returns>
        private static bool TimesOverlap(DateTime aStart, DateTime aEnd, DateTime bStart, DateTime bEnd)
        {
            return (aStart <= bEnd) && (bStart <= aEnd);
        }

        /// <summary>
        /// Does PSD ticking.
        /// </summary>
        /// <param name="now"></param>
        private async Task<MsacScheduledRequest[]> ProcessTickPsd(DateTime now)
        {
            //Find the latest ID3 item that hasn't been sent
            MsacScheduledRequestFromList? sendItem = null;
            MsacScheduledRequestFromList? nextItem = null;
            MsacScheduledRequestFromList[] items;
            lock (mutex)
            {
                //Collect all items
                items = Items.OrderBy(x => x.req.start).ToArray();

                //Find all relevant items
                foreach (var item in items)
                {
                    //Get items that:
                    // * Are after the last PSD was sent
                    // * Are started
                    // * Are not expired
                    // * Do NOT match the latest one
                    if (item.req.start > latestPsdSendTime && item.req.start <= now && (sendItem == null || item.req.start > sendItem.Value.req.start) && !item.req.psd.Equals(lastSentPsd))
                        sendItem = item;
                }

                //Update last PSD to prevent resending the same one
                if (sendItem != null)
                    lastSentPsd = sendItem.Value.req.psd;

                //Find the next PSD update (after this one, if one was found)
                DateTime compareTime = now;
                if (sendItem != null)
                    compareTime = sendItem.Value.req.start;
                var nextQuery = items.Where(x => x.req.start > compareTime);
                if (nextQuery.Count() > 0)
                    nextItem = nextQuery.FirstOrDefault();
            }

            //Send PSD
            if (sendItem != null)
            {
                //Branch on if this has an image or not
                PsdSendBuilder psd = sendItem.Value.req.psd.Clone();

                //If it has an image, apply it
                bool appliedImage = false;
                if (sendItem.Value.req.image != null)
                {
                    //Clone the PSD
                    psd = psd.Clone();

                    //Find image
                    ActiveLot lot = FindMatchingLots(sendItem.Value.req).FirstOrDefault();
                    if (lot != null)
                    {
                        //Set image
                        psd.XhdrTriggerImage(lot.Lot);
                        psd.XhdrSetMime(MsacConnection.MIME_SYNC);
                        appliedImage = true;
                    } else
                    {
                        //TODO: Raise alarm here!
                    }
                }

                //If didn't apply image, clear
                if (!appliedImage)
                {
                    psd.XhdrBlankScreen();
                    psd.XhdrSetMime(MsacConnection.MIME_ASYNC);
                }

                //Send
                await connection.SendPSDAsync(psd, sendItem.Value.list.ExporterAddress, sendItem.Value.list.AudioChannel);

                //Update time
                latestPsdSendTime = sendItem.Value.req.start;
            }

            //If the next PSD is known, request that tick time
            if (nextItem != null)
                RequestTickAt(nextItem.Value.req.start);

            return items.Select(x => x.req).ToArray();
        }

        /// <summary>
        /// Contains the list of cued items, given to the user.
        /// </summary>
        class SchedulerList : IMsacSchedulerList
        {
            public SchedulerList(MsacScheduler scheduler, string exporterAddress, string audioChannel)
            {
                this.scheduler = scheduler;
                this.exporterAddress = exporterAddress;
                this.audioChannel = audioChannel;
            }

            private readonly MsacScheduler scheduler;
            private readonly string exporterAddress;
            private readonly string audioChannel;
            private MsacScheduledRequest[] items = new MsacScheduledRequest[0]; // Protected by scheduler mutex

            /// <summary>
            /// The exporter address given at creation.
            /// </summary>
            public string ExporterAddress => exporterAddress;

            /// <summary>
            /// The audio channel given at creation.
            /// </summary>
            public string AudioChannel => audioChannel;

            /// <summary>
            /// Assumes in scheduler mutex.
            /// </summary>
            public MsacScheduledRequest[] Items => items;

            public void UpdateItems(IEnumerable<MsacScheduledRequest> requests)
            {
                //TODO: Look for overlapping items

                //Enter mutex
                lock (scheduler.mutex)
                {
                    //Set
                    this.items = requests.ToArray();

                    //Request tick
                    scheduler.RequestTick();
                }
            }

            public void Dispose()
            {
                //Remove this from the list of items in the scheduler
                lock (scheduler.mutex)
                    scheduler.lists.Remove(this);
            }
        }

        struct MsacScheduledRequestFromList
        {
            public MsacScheduledRequest req;
            public SchedulerList list;
        }

        /// <summary>
        /// Lot that has been sent to the server.
        /// </summary>
        class ActiveLot
        {
            public ActiveLot(MsacScheduler scheduler, IMsacScheduledImage image, ISyncSendLot lot)
            {
                this.scheduler = scheduler;
                this.image = image;
                this.lot = lot;
            }

            private readonly MsacScheduler scheduler;
            private readonly IMsacScheduledImage image;
            private readonly ISyncSendLot lot;

            /// <summary>
            /// The send start time of this LOT.
            /// </summary>
            public DateTime Start => lot.Start;

            /// <summary>
            /// The send duration of this LOT.
            /// </summary>
            public TimeSpan Duration => lot.Duration;

            /// <summary>
            /// The end send time of this LOT.
            /// </summary>
            public DateTime End => Start + Duration;

            /// <summary>
            /// Associated LOT.
            /// </summary>
            public ISyncSendLot Lot => lot;

            /// <summary>
            /// Associated image.
            /// </summary>
            public IMsacScheduledImage Image => image;

            /// <summary>
            /// The image filename to check for matches.
            /// </summary>
            public string Filename => image.Filename;
        }
    }
}

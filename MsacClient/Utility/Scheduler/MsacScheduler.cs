using MsacClient.Entities;
using MsacClient.Exceptions;
using MsacClient.Utility.Upload;
using System;
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
        private readonly List<ScheduledLot> lots = new List<ScheduledLot>();
        private PsdSendBuilder lastSentPsd;
        private DateTime latestPsdSendTime; // Only to be accessed by worker, not locked by mutex

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
        private ScheduledItem[] Items
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
                    ScheduledItem[] items = new ScheduledItem[total];
                    int i = 0;
                    foreach (var l in lists)
                    {
                        l.Items.CopyTo(items, i);
                        i += l.Items.Length;
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
                    ProcessTick(now);

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
            ProcessTick(now);
        }

        /// <summary>
        /// Processes a tick. Assumes that the next tick has been cleared.
        /// </summary>
        /// <param name="now"></param>
        public void ProcessTick(DateTime now)
        {
            //Find the latest ID3 item that hasn't been sent
            ScheduledItem? sendItem = null;
            ScheduledItem? nextItem = null;
            lock (mutex)
            {
                //Find all relevant items
                foreach (var item in Items)
                {
                    //Get items that:
                    // * Are after the last PSD was sent
                    // * Are started
                    // * Are not expired
                    // * Do NOT match the latest one
                    if (item.time > latestPsdSendTime && item.time <= now && (sendItem == null || item.time > sendItem.Value.time) && !item.psd.Equals(lastSentPsd))
                        sendItem = item;
                }

                //Update last PSD to prevent resending the same one
                if (sendItem != null)
                    lastSentPsd = sendItem.Value.psd;

                //Find the next PSD update (after this one, if one was found)
                DateTime compareTime = now;
                if (sendItem != null)
                    compareTime = sendItem.Value.time;
                var nextQuery = Items.Where(x => x.time > compareTime).OrderBy(x => x.time);
                if (nextQuery.Count() > 0)
                    nextItem = nextQuery.FirstOrDefault();
            }

            //Send PSD
            if (sendItem != null)
            {
                sendItem.Value.SendPsdAsync(connection).Wait();
                latestPsdSendTime = sendItem.Value.time;
            }

            //If the next PSD is known, request that tick time
            if (nextItem != null)
                RequestTickAt(nextItem.Value.time);

            //Capture lot list
            ScheduledLot[] lots;
            lock (mutex)
                lots = this.lots.ToArray();

            //Tick all lots
            foreach (var l in lots)
                l.TickAsync(now).Wait();

            //Remove expired lots
            lock (mutex)
            {
                foreach (var l in lots)
                {
                    if (l.IsExpired(now))
                        this.lots.Remove(l);
                }
            }
        }

        /// <summary>
        /// Cancels all lots no longer in use.
        /// </summary>
        private void SyncLots()
        {
            lock (mutex)
            {
                //Create lists
                List<ScheduledLot> unusedLots = new List<ScheduledLot>(lots);

                //Remove
                foreach (var i in Items)
                {
                    if (i.lot != null)
                        unusedLots.Remove(i.lot);
                }

                //Cancel remaining lots
                foreach (var l in unusedLots)
                    l.Cancel();
            }
        }

        /// <summary>
        /// Gets or creates a lot that will be valid at a specified time.
        /// </summary>
        /// <returns></returns>
        private ScheduledLot GetLot(DateTime start, TimeSpan duration, IMsacScheduledImage image)
        {
            lock (mutex)
            {
                //Search for matching lots
                ScheduledLot lot = lots.Where(x => x.EstimatedExpiration >= (start+duration) && x.Image.Filename == image.Filename).FirstOrDefault();
                if (lot != null)
                    return lot;

                //Create a new lot
                lot = new ScheduledLot(this, image, start, duration);
                lots.Add(lot);

                return lot;
            }
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
            private ScheduledItem[] items = new ScheduledItem[0]; // Protected by scheduler mutex

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
            public ScheduledItem[] Items => items;

            public void UpdateItems(IEnumerable<MsacScheduledRequest> requests)
            {
                lock (scheduler.mutex)
                {
                    //Convert all requests to scheduled events
                    items = requests.Select((MsacScheduledRequest evt) =>
                    {
                        //Calculate duration
                        TimeSpan duration = evt.end - evt.start;

                        //If an image is specified, get or create a lot
                        ScheduledLot lot = null;
                        if (evt.image != null)
                            lot = scheduler.GetLot(evt.start, duration, evt.image);

                        //Adjust start/duration to fill both old timing as well as current timing
                        if (lot != null)
                        {
                            //Get the old end time
                            DateTime end = lot.Start + lot.Duration;

                            //If this is before we end, update
                            if (end < evt.end)
                                end = evt.end;

                            //Calculate new start
                            DateTime start = lot.Start;
                            if (evt.start < start)
                                start = evt.start;

                            //Apply
                            lot.Duration = end - start;
                            lot.Start = start;
                        }

                        //Wrap into an item
                        return new ScheduledItem(this, evt.start, evt.psd, lot);
                    }).ToArray();

                    //Sync lots
                    scheduler.SyncLots();

                    //Find the earliest event and request a tick then
                    DateTime earliest = DateTime.MaxValue;
                    foreach (var e in items)
                    {
                        if (e.time < earliest)
                            earliest = e.time;
                    }

                    //Request tick
                    if (earliest != DateTime.MaxValue)
                        scheduler.RequestTickAt(earliest);
                }
            }

            public void Dispose()
            {
                //Remove this from the list of items in the scheduler
                lock (scheduler.mutex)
                    scheduler.lists.Remove(this);
            }
        }

        struct ScheduledItem
        {
            public ScheduledItem(SchedulerList list, DateTime time, PsdSendBuilder psd, ScheduledLot lot)
            {
                this.list = list;
                this.time = time;
                this.psd = psd;
                this.lot = lot;
            }

            public readonly SchedulerList list;
            public readonly DateTime time;
            public readonly PsdSendBuilder psd;
            public readonly ScheduledLot lot;

            /// <summary>
            /// Sends the PSD to the MSAC
            /// </summary>
            /// <returns></returns>
            public Task SendPsdAsync(IMsacConnection conn)
            {
                //Clone the PSD
                PsdSendBuilder psd = this.psd.Clone();

                //Set image
                if (lot != null && lot.TryGetLot(out ISyncSendLot msacLot))
                {
                    psd.XhdrTriggerImage(msacLot);
                    psd.XhdrSetMime(MsacConnection.MIME_SYNC);
                } else
                {
                    psd.XhdrBlankScreen();
                    psd.XhdrSetMime(MsacConnection.MIME_ASYNC);
                }

                //Send
                return conn.SendPSDAsync(psd, list.ExporterAddress, list.AudioChannel);
            }
        }

        /// <summary>
        /// Represents an image that is pending.
        /// </summary>
        class ScheduledLot
        {
            public ScheduledLot(MsacScheduler scheduler, IMsacScheduledImage image, DateTime start, TimeSpan duration)
            {
                this.scheduler = scheduler;
                this.image = image;
                this.start = start;
                this.duration = duration;
            }

            private readonly MsacScheduler scheduler;
            private readonly IMsacScheduledImage image;
            private readonly object mutex = new object();
            private bool cancelled; // Permanent flag set when it's time to cancel
            private bool serverCancelled; // The state of cancellation on the server side
            private DateTime serverStart; // The state of start on the server side
            private DateTime start;
            private TimeSpan duration;
            private ScheduledLotStatus status = ScheduledLotStatus.PENDING;
            private ISyncSendLot lot; // Only valid if status == SENT
            private DateTime expires; // Set when status is anything but PENDING

            /// <summary>
            /// Gets the image this belongs to.
            /// </summary>
            public IMsacScheduledImage Image => image;

            /// <summary>
            /// Gets the time when this client will send the notification to the MSAC to send.
            /// </summary>
            public DateTime PreNotifyTime => Start - scheduler.ImagePreNotify;

            /// <summary>
            /// Gets the estimated expiration time, regardless of state.
            /// </summary>
            public DateTime EstimatedExpiration
            {
                get
                {
                    lock (mutex)
                    {
                        if (status == ScheduledLotStatus.PENDING)
                            return start + scheduler.ImageLifespan.Max(duration); // Truly an estimate
                        else
                            return expires; // Not an estimate
                    }
                }
            }

            /// <summary>
            /// Gets the start of the event.
            /// </summary>
            public DateTime Start
            {
                get
                {
                    lock (mutex)
                        return start;
                }
                set
                {
                    bool notify;
                    lock (mutex)
                    {
                        notify = value != start;
                        start = value;
                    }
                    if (notify)
                        scheduler.RequestTick();
                }
            }

            /// <summary>
            /// Gets the duration of the event.
            /// </summary>
            public TimeSpan Duration
            {
                get
                {
                    lock (mutex)
                        return duration;
                }
                set
                {
                    lock (mutex)
                        duration = value;
                }
            }

            /// <summary>
            /// The status of this lot.
            /// </summary>
            public ScheduledLotStatus Status
            {
                get
                {
                    lock (mutex)
                        return status;
                }
                private set
                {
                    lock (mutex)
                        status = value;
                }
            }

            /// <summary>
            /// Gets if this lot is one of:
            /// * Sent and ImageLifespan has expired
            /// * Errored and RetryTime has expired
            /// * This has been cancelled both locally and server-side
            /// </summary>
            public bool IsExpired(DateTime now)
            {
                lock (mutex)
                {
                    if (status != ScheduledLotStatus.PENDING)
                        return now > expires;
                    return cancelled && serverCancelled;
                }
            }

            /// <summary>
            /// Cancels the send of this lot.
            /// </summary>
            public void Cancel()
            {
                bool notify;
                lock (mutex)
                {
                    notify = !cancelled;
                    cancelled = true;
                }
                if (notify)
                    scheduler.RequestTick();
            }

            /// <summary>
            /// Gets the lot if it is available
            /// </summary>
            /// <param name="lot"></param>
            /// <returns></returns>
            public bool TryGetLot(out ISyncSendLot lot)
            {
                lock (mutex)
                {
                    lot = this.lot;
                    return lot != null;
                }
            }

            /// <summary>
            /// Ticks on the worker thread.
            /// </summary>
            /// <returns></returns>
            public async Task TickAsync(DateTime now)
            {
                //Capture state in mutex
                bool cancelled;
                bool serverCancelled;
                DateTime serverStart;
                DateTime start;
                ScheduledLotStatus status;
                ISyncSendLot lot;
                lock (mutex)
                {
                    cancelled = this.cancelled;
                    serverCancelled = this.serverCancelled;
                    serverStart = this.serverStart;
                    start = this.start;
                    status = this.status;
                    lot = this.lot;
                }

                //Send cancel signal to MSAC if requested and sent
                if (cancelled && !serverCancelled)
                {
                    //Attempt to send signal
                    if (lot != null)
                    {
                        try
                        {
                            await lot.CancelSendAsync();
                            serverCancelled = true;
                        }
                        catch (MsacBadStatusException ex)
                        {
                            //Assume that the MSAC just doesn't know of this lot and don't attempt to cancel again
                            scheduler.MsacSendError?.Invoke(image, "MSAC responded with failure after cancelling image; Will not retry.", ex);
                            serverCancelled = true;
                        }
                        catch (Exception ex)
                        {
                            //Assume that there was a network error and try again shortly
                            scheduler.MsacSendError?.Invoke(image, "Error sending image cancellation; Will retry...", ex);
                            serverCancelled = false;
                        }
                    } else
                    {
                        //Server never even knew
                        serverCancelled = true;
                    }

                    //Update state
                    lock (mutex)
                        this.serverCancelled = serverCancelled;
                }

                //Send timing update signal to MSAC if requested and sent
                if (start.AbsDifference(serverStart) > scheduler.ImageFloatingJitter && lot != null)
                {
                    //Attempt to send signal
                    try
                    {
                        await lot.ModifyStartAsync(start);
                        serverStart = start;
                    }
                    catch (MsacBadStatusException ex)
                    {
                        //Assume that the MSAC just doesn't know of this lot and don't attempt to cancel again
                        scheduler.MsacSendError?.Invoke(image, "MSAC responded with failure after sending image timing update; Will not retry.", ex);
                        serverStart = start;
                    }
                    catch (Exception ex)
                    {
                        //Assume that there was a network error and try again shortly
                        scheduler.MsacSendError?.Invoke(image, "Error sending image timing update; Will retry...", ex);
                    }

                    //Update state
                    lock (mutex)
                        this.serverStart = serverStart;
                }

                //Start send notify if it's within range and has not yet been sent
                if (!cancelled && status == ScheduledLotStatus.PENDING && start + scheduler.ImagePreNotify >= now)
                {
                    //Perform send, this will update state from PENDING
                    await PrepareAsync(now);
                } else if (status == ScheduledLotStatus.PENDING)
                {
                    //Set wakeup when we can send this
                    scheduler.RequestTickAt(PreNotifyTime);
                }
            }

            /// <summary>
            /// Notifies the MSAC of the image. This is performed ahead of time, typically ~5 mins.
            /// This should only be called on the worker and is expected to handle any errors itself.
            /// </summary>
            /// <returns></returns>
            private async Task PrepareAsync(DateTime now)
            {
                //Check state
                if (status != ScheduledLotStatus.PENDING)
                    throw new Exception("Invalid state to send image.");

                //Get data
                DateTime start;
                TimeSpan duration;
                lock (mutex)
                {
                    start = this.start;
                    duration = this.duration;
                }

                //Catch upload problems
                ISyncSendLot lot = null;
                string errorText = "Failed to load image.";
                Exception errorException = null;
                try
                {
                    //Upload to the MSAC
                    await scheduler.uploader.UploadImageAsync(image, now);

                    //Begin send
                    errorText = "Failed to send command to MSAC.";
                    lot = await scheduler.connection.PreSendSyncLotAsync(
                        start,
                        scheduler.FilenamePrefix + image.Filename,
                        duration,
                        null,
                        now.AddYears(1),
                        image.DataService
                    );
                }
                catch (Exception ex)
                {
                    //Set error
                    errorException = ex;
                }

                //Update state
                bool success = lot != null && errorException == null;
                lock (mutex)
                {
                    //Update status and expiry based on if an error occured
                    if (success)
                    {
                        serverStart = start;
                        expires = start + scheduler.ImageLifespan.Max(duration);
                        status = ScheduledLotStatus.SENT;
                    } else
                    {
                        expires = start + scheduler.ErrorDelay;
                        status = ScheduledLotStatus.ERROR;
                    }

                    //Set lot
                    this.lot = lot;
                }

                //Send error event if there was one
                if (success)
                    scheduler.MsacSendError?.Invoke(image, errorText, errorException);
            }
        }

        enum ScheduledLotStatus
        {
            /// <summary>
            /// The lot is still waiting to be sent to the JMSAC.
            /// </summary>
            PENDING,

            /// <summary>
            /// The JMSAC has the lot. Lot ID is valid.
            /// </summary>
            SENT,

            /// <summary>
            /// Failed to send the lot.
            /// </summary>
            ERROR
        }
    }
}

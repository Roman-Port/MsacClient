using MsacClient.Entities;
using MsacClient.Simulator.Core.Output;
using MsacClient.Simulator.Core.Settings;
using MsacClient.Utility.Scheduler;
using MsacClient.Utility.Upload;
using MsacClient.XmlData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Core
{
    /// <summary>
    /// Class that will simulate the MSAC scheduler
    /// </summary>
    public class SimulationRunner
    {
        public SimulationRunner(MsacSimTest settings)
        {
            //Set
            this.settings = settings;
            simTime = settings.Epoch;

            //Create simulated connection and upload manager
            conn = new SimulatedConnection(this);
            upload = new MsacUploadManager(conn);

            //Create and configure scheduler
            sched = new MsacScheduler(conn, upload)
            {
                FilenamePrefix = "",
                ErrorDelay = settings.SchedulerSettings.ErrorDelay,
                ImageFloatingJitter = settings.SchedulerSettings.ImageFloatingJitter,
                ImageLifespan = settings.SchedulerSettings.ImageLifespan,
                ImagePreNotify = settings.SchedulerSettings.ImagePreNotify
            };
            list = sched.CreateList("dummy");

            //Create output
            output = new SimOutput
            {
                Settings = settings
            };
        }

        private readonly MsacSimTest settings;
        private readonly SimulatedConnection conn;
        private readonly MsacUploadManager upload;
        private readonly MsacScheduler sched;
        private readonly IMsacSchedulerList list;
        private readonly SimOutput output;

        private DateTime simTime;
        private MsacSimEventList lastTimelineEvent;

        /// <summary>
        /// The simulated time. Advanced each call to Process()
        /// </summary>
        public DateTime SimulatedTime => simTime;

        /// <summary>
        /// The output results.
        /// </summary>
        public SimOutput Result => output;

        /// <summary>
        /// Processes a tick. Returns true if completed with the simulation, otherwise false.
        /// </summary>
        /// <returns></returns>
        public bool Process()
        {
            //Find the next timeline event after the simulated time
            MsacSimEventList nextTimelineEvent = settings.Timeline.OrderBy(x => x.Time).Where(x => SettingTimeToSimTime(x.Time) >= simTime).FirstOrDefault();
            DateTime nextTimelineEventTime = DateTime.MaxValue;
            if (nextTimelineEvent != null)
                nextTimelineEventTime = SettingTimeToSimTime(nextTimelineEvent.Time);

            //Determine the next time to execute
            DateTime next = simTime.AddMinutes(1); // Start with the +1 minute failsafe built into the scheduler worker
            if (sched.NextTick.HasValue && sched.NextTick.Value < next) // If the next scheduled tick is closer than the default, apply
                next = sched.NextTick.Value;
            if (nextTimelineEvent != null && nextTimelineEvent != lastTimelineEvent && nextTimelineEventTime > simTime && nextTimelineEventTime < next) // If the next event is closer than the default but still in the future, apply
                next = nextTimelineEventTime;

            //Constrain to not go back in time
            if (next < simTime)
                next = simTime;

            //Check if time to exit
            if (nextTimelineEvent == null && (!sched.NextTick.HasValue || sched.NextTick.Value < simTime))
                return true;

            //Update state
            simTime = next;
            output.LastTick = simTime;
            output.Ticks.Add(simTime);

            //If this matches the next timeline event, execute it
            if (nextTimelineEvent != null && simTime >= nextTimelineEventTime) // Should never be greater than it, but use as a failsafe
            {
                lastTimelineEvent = nextTimelineEvent;
                list.UpdateItems(ConvertListToRequests(nextTimelineEvent));
            }

            //Process a tick
            sched.DebugProcessTick(simTime);

            return false;
        }

        /// <summary>
        /// Converts from the timespan in settings to a simulated date/time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private DateTime SettingTimeToSimTime(TimeSpan time)
        {
            return settings.Epoch.Add(time);
        }

        /// <summary>
        /// Converts from a settings event list to a group of requests to pass to the simulator.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private MsacScheduledRequest[] ConvertListToRequests(MsacSimEventList list)
        {
            return list.Events.Select(x =>
            {
                return new MsacScheduledRequest
                {
                    start = SettingTimeToSimTime(x.Start),
                    end = SettingTimeToSimTime(x.End),
                    psd = new PsdSendBuilder()
                        .SetTitle(x.Comment),
                    image = x.ImageFilename == null ? null : new SimulatedImage(x.ImageFilename)
                };
            }).ToArray();
        }

        /// <summary>
        /// Creates an artificial wait if specified. If no wait is requested, returns a completed task.
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        private static Task CreateDelayedResult(TimeSpan delay)
        {
            if (delay > TimeSpan.Zero)
                return Task.Delay((int)delay.TotalMilliseconds);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Creates an artificial wait if specified. If no wait is requested, returns a completed task.
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        private static async Task<T> CreateDelayedResult<T>(TimeSpan delay, T result)
        {
            if (delay > TimeSpan.Zero)
                await Task.Delay((int)delay.TotalMilliseconds);
            return result;
        }

        class SimulatedConnection : IMsacConnection
        {
            public SimulatedConnection(SimulationRunner ctx)
            {
                this.ctx = ctx;
            }

            private readonly SimulationRunner ctx;
            private int nextLotId = 1;

            public Task FileCopyDirectAsync(string filename, byte[] buffer, int index, int count)
            {
                //Add event
                ctx.output.Uploads.Add(new SimOutputUpload
                {
                    Time = ctx.simTime,
                    Filename = filename
                });

                //Delay
                return CreateDelayedResult(ctx.settings.TimingSettings.UploadDelay);
            }

            public Task<ISyncSendLot> PreSendSyncLotAsync(DateTime startTime, string fileName, TimeSpan duration, int? requestedLotId, DateTime expiry, string dataService = "AAHD1", SyncSendTriggerType triggerType = SyncSendTriggerType.Passive, bool cancelPrior = false)
            {
                //Get lot ID
                int lotId;
                if (requestedLotId.HasValue)
                    lotId = requestedLotId.Value;
                else
                    lotId = nextLotId++;

                //Create output item for lot
                SimOutputLot output = new SimOutputLot
                {
                    LotId = lotId,
                    Filename = fileName,
                    CreatedAt = ctx.simTime,
                    LastTimeUpdate = ctx.simTime,
                    InitialStartTime = startTime,
                    FinalStartTime = startTime,
                    Duration = duration,
                    Expiry = expiry
                };
                ctx.output.Lots.Add(output);

                //Create simulated lot
                SimulatedSyncLot result = new SimulatedSyncLot(ctx, output, startTime, duration);

                //Delay
                return CreateDelayedResult<ISyncSendLot>(ctx.settings.TimingSettings.StartSyncSendDelay, result);
            }

            public Task<StatusInfo> RequestStatusAsync(string dataServiceName = "SLHD1")
            {
                throw new NotSupportedException();
            }

            public Task<IAsyncSendLot> SendAsyncLotAsync(string fileName, int? lotId, string dataService = "SLHD1")
            {
                throw new NotSupportedException();
            }

            public Task SendPSDAsync(PsdSendBuilder psd, string exportAddress, string audioChannel = "HD1")
            {
                return SendPSDAsync(psd.Psd, exportAddress, audioChannel);
            }

            public Task SendPSDAsync(PsdFields psd, string exportAddress, string audioChannel = "HD1")
            {
                //Try to get lot ID
                int? lotId = null;
                if (psd.Xhdr != null && psd.Xhdr.LotId != null)
                    lotId = int.Parse(psd.Xhdr.LotId);

                //Add event
                ctx.output.Psds.Add(new SimOutputPsd
                {
                    Time = ctx.simTime,
                    Text = psd.Core.Title,
                    LotId = lotId
                });

                //Delay
                return CreateDelayedResult(ctx.settings.TimingSettings.SendPsdDelay);
            }
        }

        class SimulatedSyncLot : ISyncSendLot
        {
            public SimulatedSyncLot(SimulationRunner ctx, SimOutputLot output, DateTime start, TimeSpan duration)
            {
                this.ctx = ctx;
                this.output = output;
                this.start = start;
                this.duration = duration;
            }

            private readonly SimulationRunner ctx;
            private readonly SimOutputLot output;
            private DateTime start;
            private TimeSpan duration;

            public string State => throw new NotSupportedException();

            public string Tag => throw new NotSupportedException();

            public int LotId => output.LotId;

            public DateTime Start => start;

            public TimeSpan Duration => duration;

            public bool Cancelled => output.Cancelled;

            public Task ModifyStartAsync(DateTime start)
            {
                //Check if cancelled
                if (Cancelled)
                    throw new Exception("Attempted to modify start of event that was cancelled.");

                //Check if this has already started sending
                if (ctx.simTime >= output.FinalStartTime)
                    throw new Exception("Attempted to modify start of event already being sent.");

                //Check if it's being changed
                if (start == this.start)
                    throw new Exception("Attempted to change start time to the already set value.");

                //Add event
                output.Events.Add(new SimOutputLotEvent
                {
                    Time = ctx.simTime,
                    EventType = SimOutputLotEventType.MODIFY_START,
                    Parameter = start
                });

                //Set
                output.FinalStartTime = start;
                this.start = start;
                output.LastTimeUpdate = ctx.simTime;

                //Delay
                return CreateDelayedResult(ctx.settings.TimingSettings.EditSyncSendDelay);
            }

            public Task RefreshStateAsync()
            {
                throw new NotSupportedException();
            }

            public Task CancelSendAsync(bool cancelPrior = false)
            {
                //Check if already cancelled
                if (Cancelled)
                    throw new Exception("Cancelling already cancelled event.");

                //If after it would've sent, throw error
                if (ctx.simTime >= output.FinalStartTime)
                    throw new Exception("Attempted to cancel image already being sent.");

                //Add event
                output.Events.Add(new SimOutputLotEvent
                {
                    Time = ctx.simTime,
                    EventType = SimOutputLotEventType.CANCEL
                });

                //Set
                if (ctx.simTime < output.FinalStartTime)
                {
                    output.FinalStartTime = ctx.simTime;
                    output.Cancelled = true;
                }

                //Delay
                return CreateDelayedResult(ctx.settings.TimingSettings.CancelSyncSendDelay);
            }
        }

        class SimulatedImage : IMsacScheduledImage
        {
            public SimulatedImage(string filename)
            {
                this.filename = filename;
            }

            private readonly string filename;

            public string Filename => filename;

            public string DataService => "dummy";

            public Stream Open()
            {
                byte[] data = Encoding.UTF8.GetBytes(filename);
                return new MemoryStream(data);
            }
        }
    }
}

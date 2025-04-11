using MsacClient.Entities;
using MsacClient.Tests.Testing;
using MsacClient.XmlData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Tests
{
    /// <summary>
    /// A dummy connection that can be used for testing.
    /// </summary>
    class TestingConnection : IMsacConnection
    {
        public TestingConnection(SimulatedState state)
        {
            this.state = state;
            eventsDirectFileCopy = new TestingEventList<DirectFileCopyEvent>(state);
            eventsPreSendSyncLot = new TestingEventList<PreSendSyncLotEvent>(state);
            eventsSendAsyncLot = new TestingEventList<SendAsyncLotEvent>(state);
            eventsSendPsd = new TestingEventList<SendPsdEvent>(state);
        }

        private readonly SimulatedState state;
        private readonly TestingEventList<DirectFileCopyEvent> eventsDirectFileCopy;
        private readonly TestingEventList<PreSendSyncLotEvent> eventsPreSendSyncLot;
        private readonly TestingEventList<SendAsyncLotEvent> eventsSendAsyncLot;
        private readonly TestingEventList<SendPsdEvent> eventsSendPsd;

        private int nextLotId = 1;

        public TestingEventList<DirectFileCopyEvent> EventsDirectFileCopy => eventsDirectFileCopy;
        public TestingEventList<PreSendSyncLotEvent> EventsPreSendSyncLot => eventsPreSendSyncLot;
        public TestingEventList<SendAsyncLotEvent> EventsSendAsyncLot => eventsSendAsyncLot;
        public TestingEventList<SendPsdEvent> EventsSendPsd => eventsSendPsd;
        public SimulatedState State => state;

        public Task FileCopyDirectAsync(string filename, byte[] buffer, int index, int count)
        {
            eventsDirectFileCopy.AddEvent(new DirectFileCopyEvent
            {
                buffer = buffer,
                count = count,
                filename = filename,
                index = index
            });
            return Task.CompletedTask;
        }

        public Task<ISyncSendLot> PreSendSyncLotAsync(DateTime startTime, string fileName, TimeSpan duration, int? lotId, DateTime expiry, string dataService = "AAHD1", SyncSendTriggerType triggerType = SyncSendTriggerType.Passive, bool cancelPrior = false)
        {
            //Get lot ID
            int returnedLotId;
            if (lotId == null)
                returnedLotId = nextLotId++;
            else
                returnedLotId = lotId.Value;

            //Create result
            TestingSyncSendLot returnValue = new TestingSyncSendLot(state, returnedLotId);

            //Add to list
            eventsPreSendSyncLot.AddEvent(new PreSendSyncLotEvent
            {
                fileName = fileName,
                lotId = lotId,
                dataService = dataService,
                expiry = expiry,
                cancelPrior = cancelPrior,
                duration = duration,
                startTime = startTime,
                triggerType = triggerType,
                returnValue = returnValue
            });

            return Task.FromResult((ISyncSendLot)returnValue);
        }

        public Task<StatusInfo> RequestStatusAsync(string dataServiceName = "SLHD1")
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncSendLot> SendAsyncLotAsync(string fileName, int? lotId, string dataService = "SLHD1")
        {
            //Get lot ID
            int returnedLotId;
            if (lotId == null)
                returnedLotId = nextLotId++;
            else
                returnedLotId = lotId.Value;

            //Create result
            TestingAsyncSendLot returnValue = new TestingAsyncSendLot(state, returnedLotId);

            //Add to list
            eventsSendAsyncLot.AddEvent(new SendAsyncLotEvent
            {
                fileName = fileName,
                lotId = lotId,
                dataService = dataService,
                returnValue = returnValue
            });

            return Task.FromResult((IAsyncSendLot)returnValue);
        }

        public Task SendPSDAsync(PsdSendBuilder psd, string exportAddress, string audioChannel = "HD1")
        {
            return SendPSDAsync(psd.Psd, exportAddress, audioChannel);
        }

        public Task SendPSDAsync(PsdFields psd, string exportAddress, string audioChannel = "HD1")
        {
            eventsSendPsd.AddEvent(new SendPsdEvent
            {
                psd = psd,
                exportAddress = exportAddress,
                audioChannel = audioChannel
            });
            return Task.CompletedTask;
        }
    }
}

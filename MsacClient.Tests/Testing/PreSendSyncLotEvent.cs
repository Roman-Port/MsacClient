using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Testing
{
    public struct PreSendSyncLotEvent
    {
        public DateTime startTime;
        public string fileName;
        public TimeSpan duration;
        public int? lotId;
        public DateTime expiry;
        public string dataService;
        public SyncSendTriggerType triggerType;
        public bool cancelPrior;

        public TestingSyncSendLot returnValue;
    }
}

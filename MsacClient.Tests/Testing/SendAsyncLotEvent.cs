using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Testing
{
    public struct SendAsyncLotEvent
    {
        public string fileName;
        public int? lotId;
        public string dataService;

        public TestingAsyncSendLot returnValue;
    }
}

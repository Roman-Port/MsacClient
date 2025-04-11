using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Tests.Testing
{
    public class TestingAsyncSendLot : IAsyncSendLot
    {
        public TestingAsyncSendLot(SimulatedState state, int lotId)
        {
            this.lotId = lotId;
            eventsCancel = new TestingEventList<CancelEvent>(state);
        }

        private readonly int lotId;
        private readonly TestingEventList<CancelEvent> eventsCancel;

        public TestingEventList<CancelEvent> EventsCancel => eventsCancel;

        public string State => throw new NotImplementedException();

        public string Tag => throw new NotImplementedException();

        public int LotId => lotId;

        public Task CancelSendAsync(bool cancelPrior = false)
        {
            eventsCancel.AddEvent(new CancelEvent
            {
                cancelPrior = cancelPrior
            });
            return Task.CompletedTask;
        }

        public Task RefreshStateAsync()
        {
            return Task.CompletedTask;
        }
    }
}

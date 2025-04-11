using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Tests.Testing
{
    public class TestingSyncSendLot : TestingAsyncSendLot, ISyncSendLot
    {
        public TestingSyncSendLot(SimulatedState state, int lotId) : base(state, lotId)
        {
            eventsModifyStart = new TestingEventList<ModifyStartEvent>(state);
        }

        private readonly TestingEventList<ModifyStartEvent> eventsModifyStart;

        public TestingEventList<ModifyStartEvent> EventsModifyStart => eventsModifyStart;

        public Task ModifyStartAsync(DateTime start)
        {
            eventsModifyStart.AddEvent(new ModifyStartEvent
            {
                start = start
            });
            return Task.CompletedTask;
        }
    }
}

using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Tests.Testing
{
    public class TestingSyncSendLot : TestingAsyncSendLot, ISyncSendLot
    {
        public TestingSyncSendLot(SimulatedState state, int lotId, DateTime start, TimeSpan duration) : base(state, lotId)
        {
            eventsModifyStart = new TestingEventList<ModifyStartEvent>(state);
            this.start = start;
            this.duration = duration;
        }

        private readonly TestingEventList<ModifyStartEvent> eventsModifyStart;
        private DateTime start;
        private TimeSpan duration;

        public TestingEventList<ModifyStartEvent> EventsModifyStart => eventsModifyStart;

        public DateTime Start => start;

        public TimeSpan Duration => duration;

        public Task ModifyStartAsync(DateTime start)
        {
            eventsModifyStart.AddEvent(new ModifyStartEvent
            {
                start = start
            });
            this.start = start;
            return Task.CompletedTask;
        }
    }
}

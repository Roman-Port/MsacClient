using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsacClient.Tests.Testing
{
    public class TestingEventList<T>
    {
        public TestingEventList(SimulatedState state)
        {
            this.state = state;
        }

        private readonly SimulatedState state;
        private readonly List<TestingEvent<T>> events = new List<TestingEvent<T>>();
        private int nextIndex;

        public List<TestingEvent<T>> Events => events;
        public int Count => events.Count;
        public TestingEvent<T> FirstEvent => events.FirstOrDefault();
        public TestingEvent<T> LastEvent => events.LastOrDefault();

        public void AddEvent(T info)
        {
            events.Add(new TestingEvent<T>(nextIndex++, DateTime.Now, state.SimulatedTime, state.SimulatedStateObject, info, state.GetNewTransactionNumber()));
        }
    }
}

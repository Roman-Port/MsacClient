using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests.Testing
{
    public class TestingEvent<T>
    {
        public TestingEvent(int index, DateTime realTime, DateTime simulatedTime, object simulatedState, T evt, int transactionNumber)
        {
            this.index = index;
            this.realTime = realTime;
            this.simulatedTime = simulatedTime;
            this.simulatedState = simulatedState;
            this.evt = evt;
            this.transactionNumber = transactionNumber;
        }

        private readonly int index;
        private readonly DateTime realTime;
        private readonly DateTime simulatedTime;
        private readonly object simulatedState;
        private readonly T evt;
        private readonly int transactionNumber;

        public int Index => index;
        public DateTime RealTime => realTime;
        public DateTime SimulatedTime => simulatedTime;
        public object SimulatedState => simulatedState;
        public T Event => evt;
        public int TransactionNumber => transactionNumber;
    }
}

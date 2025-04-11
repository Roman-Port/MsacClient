using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests
{
    public class SimulatedState
    {
        private int nextTransactionNumber;

        public DateTime SimulatedTime { get; set; }
        public object SimulatedStateObject { get; set; }

        public int GetNewTransactionNumber()
        {
            return nextTransactionNumber++;
        }
    }
}

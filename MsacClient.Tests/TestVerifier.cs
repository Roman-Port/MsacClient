using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsacClient.Simulator.Core;
using MsacClient.Simulator.Core.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests
{
    class TestVerifier : SimulationVerifier
    {
        public TestVerifier(SimOutput result) : base(result)
        {
        }

        protected override void Fault(string message)
        {
            Assert.Fail(message);
        }
    }
}

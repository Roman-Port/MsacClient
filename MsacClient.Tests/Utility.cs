using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsacClient.Simulator.Core;
using MsacClient.Simulator.Core.Output;
using MsacClient.Simulator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Tests
{
    static class Utility
    {
        public static TimeSpan Time(double hours, double mins, double secs)
        {
            return TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(mins) + TimeSpan.FromSeconds(secs);
        }

        public static SimOutput RunSimulation(MsacSimTest settings)
        {
            SimulationRunner sim = new SimulationRunner(settings);
            int tick = 0;
            while (!sim.Process())
                Assert.IsTrue(tick++ < 9999);
            new TestVerifier(sim.Result).Verify();
            return sim.Result;
        }
    }
}

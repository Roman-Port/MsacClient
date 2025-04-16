using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Core.Settings
{
    /// <summary>
    /// Represents a test to perform.
    /// </summary>
    public class MsacSimTest
    {
        /// <summary>
        /// Settings for the scheduler.
        /// </summary>
        public MsacSimSchedulerSettings SchedulerSettings { get; set; } = new MsacSimSchedulerSettings();

        /// <summary>
        /// Settings for simulated timing.
        /// </summary>
        public MsacSimTimingSettings TimingSettings { get; set; } = new MsacSimTimingSettings();

        /// <summary>
        /// The label of this test.
        /// </summary>
        public string Label { get; set; } = "New Test";

        /// <summary>
        /// The simulated start time of the event.
        /// </summary>
        public DateTime Epoch { get; set; } = new DateTime(2025, 1, 1);

        /// <summary>
        /// The timeline of events.
        /// </summary>
        public List<MsacSimEventList> Timeline { get; set; } = new List<MsacSimEventList>();
    }
}

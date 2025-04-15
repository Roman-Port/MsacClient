using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Simulator.Settings
{
    /// <summary>
    /// A simulated MsacScheduledRequest
    /// </summary>
    public class MsacSimEvent
    {
        /// <summary>
        /// Start time of this event relative to the epoch.
        /// </summary>
        public TimeSpan Start { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// End time of this event relative to the epoch.
        /// </summary>
        public TimeSpan End { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Comment sent to the simulated PSD.
        /// </summary>
        public string Comment { get; set; } = "New Event";

        /// <summary>
        /// The optional simulated image filename.
        /// </summary>
        public string ImageFilename { get; set; } = null;
    }
}

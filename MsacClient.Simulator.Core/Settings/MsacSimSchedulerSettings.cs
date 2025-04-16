using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Core.Settings
{
    /// <summary>
    /// Scheduler settings
    /// </summary>
    public class MsacSimSchedulerSettings
    {
        /// <summary>
        /// The amount of time to wait before an image starts until the MSAC is notified of it.
        /// </summary>
        public TimeSpan ImagePreNotify { get; set; } = TimeSpan.FromMinutes(5);

        /// <summary>
        /// The amount of time to reuse a lot after it has been sent.
        /// </summary>
        public TimeSpan ImageLifespan { get; set; } = TimeSpan.FromMinutes(5);

        /// <summary>
        /// The amount of time to wait to retry an image.
        /// </summary>
        public TimeSpan ErrorDelay { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// The minimum amount of time that an image timing can change before an update is sent to the MSAC.
        /// </summary>
        public TimeSpan ImageFloatingJitter { get; set; } = TimeSpan.FromSeconds(1);
    }
}

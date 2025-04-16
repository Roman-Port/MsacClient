using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Core.Settings
{
    /// <summary>
    /// Simulated timings for the emulated MSAC connection
    /// </summary>
    public class MsacSimTimingSettings
    {
        /// <summary>
        /// Time to delay for uploading an image to the JMSAC.
        /// </summary>
        public TimeSpan UploadDelay { get; set; }

        /// <summary>
        /// Time to delay for sending PSD to the MSAC.
        /// </summary>
        public TimeSpan SendPsdDelay { get; set; }

        /// <summary>
        /// Time to delay for starting a sync send.
        /// </summary>
        public TimeSpan StartSyncSendDelay { get; set; }

        /// <summary>
        /// Time to delay for changing start time on a sync send.
        /// </summary>
        public TimeSpan EditSyncSendDelay { get; set; }

        /// <summary>
        /// Time to delay for cancelling an existing sync send.
        /// </summary>
        public TimeSpan CancelSyncSendDelay { get; set; }
    }
}

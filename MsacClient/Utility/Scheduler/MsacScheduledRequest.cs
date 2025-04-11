using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Utility.Scheduler
{
    /// <summary>
    /// A requested event to add to the event queue.
    /// </summary>
    public struct MsacScheduledRequest
    {
        /// <summary>
        /// Start time of this event.
        /// </summary>
        public DateTime start;

        /// <summary>
        /// End time of this event.
        /// </summary>
        public DateTime end;

        /// <summary>
        /// The PSD to send. Do not specify an image, it will be automatically attached.
        /// </summary>
        public PsdSendBuilder psd;

        /// <summary>
        /// The image to attach. Optional.
        /// </summary>
        public IMsacScheduledImage image;
    }
}

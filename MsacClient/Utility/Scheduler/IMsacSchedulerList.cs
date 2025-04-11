using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Utility.Scheduler
{
    /// <summary>
    /// An independent list of events tied to a scheduler.
    /// </summary>
    public interface IMsacSchedulerList : IDisposable
    {
        /// <summary>
        /// The exporter address given at creation.
        /// </summary>
        string ExporterAddress { get; }

        /// <summary>
        /// The audio channel given at creation.
        /// </summary>
        string AudioChannel { get; }

        /// <summary>
        /// Updates items in the list.
        /// </summary>
        /// <param name="requests"></param>
        void UpdateItems(IEnumerable<MsacScheduledRequest> requests);
    }
}

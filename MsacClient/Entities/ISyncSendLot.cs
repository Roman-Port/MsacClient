using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Entities
{
    /// <summary>
    /// A sync sending file.
    /// </summary>
    public interface ISyncSendLot : IAsyncSendLot
    {
        /// <summary>
        /// Gets the set start send time.
        /// </summary>
        DateTime Start { get; }

        /// <summary>
        /// Gets the duration of the send.
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// Sends a request to modify the scheduled start time of this event.
        /// </summary>
        /// <param name="start">The new start time.</param>
        /// <returns></returns>
        Task ModifyStartAsync(DateTime start);
    }
}

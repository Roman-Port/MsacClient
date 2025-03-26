using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Entities
{
    /// <summary>
    /// A sync sending file.
    /// </summary>
    public interface ISyncSendLot : ILot
    {
        /// <summary>
        /// The state returned by the server. Call RefreshStateAsync() to update.
        /// Pending, Active
        /// </summary>
        string State { get; }

        /// <summary>
        /// The ID from the server.
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Requests a state update from the server.
        /// </summary>
        /// <returns></returns>
        Task RefreshStateAsync();

        /// <summary>
        /// Sends a request to modify the scheduled start time of this event.
        /// </summary>
        /// <param name="start">The new start time.</param>
        /// <returns></returns>
        Task ModifyStartAsync(DateTime start);

        /// <summary>
        /// Sends a request to cancel the sending of this file, optionally cancelling the last LOT in the process of being sent.
        /// </summary>
        /// <param name="cancelPrior">If true, cancels the last LOT in the process of being sent.</param>
        /// <returns></returns>
        Task CancelSendAsync(bool cancelPrior = false);
    }
}

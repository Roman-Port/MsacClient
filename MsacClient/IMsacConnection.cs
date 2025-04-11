using MsacClient.Entities;
using MsacClient.XmlData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient
{
    public interface IMsacConnection
    {
        /// <summary>
        /// Requests basic status from the MSAC.
        /// </summary>
        /// <returns></returns>
        Task<StatusInfo> RequestStatusAsync(string dataServiceName = "SLHD1");

        /// <summary>
        /// Sends a PSD update.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task SendPSDAsync(PsdSendBuilder psd, string exportAddress, string audioChannel = "HD1");

        /// <summary>
        /// Sends a PSD update.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task SendPSDAsync(PsdFields psd, string exportAddress, string audioChannel = "HD1");

        /// <summary>
        /// Directly uploads a file to the server.
        /// </summary>
        /// <param name="filename">The destination filename.</param>
        /// <param name="buffer">Buffer to read from.</param>
        /// <param name="index">Index within the buffer to read from.</param>
        /// <param name="count">Number of bytes in the buffer.</param>
        /// <returns></returns>
        Task FileCopyDirectAsync(string filename, byte[] buffer, int index, int count);

        /// <summary>
        /// Sends a sync lot. Use this for sending images tied to audio like album art.
        /// </summary>
        /// <param name="startTime">The estimated time this image will be displayed.</param>
        /// <param name="fileName">The filename on the exporter to use.</param>
        /// <param name="duration">The duration of the item.</param>
        /// <param name="lotId">The requested lot ID. Optional.</param>
        /// <param name="expiry">The expiration of this lot.</param>
        /// <param name="dataService">The data service to send this on.</param>
        /// <param name="triggerType">The type of trigger to use.</param>
        /// <param name="cancelPrior">If true, cancels other items being sent.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ISyncSendLot> PreSendSyncLotAsync(DateTime startTime, string fileName, TimeSpan duration, int? lotId, DateTime expiry, string dataService = "AAHD1", SyncSendTriggerType triggerType = SyncSendTriggerType.Passive, bool cancelPrior = false);

        /// <summary>
        /// Sends an async lot. Use this for sending background images like station logos.
        /// This will continue to be sent until it's cancelled or another async send begins on the same data service.
        /// </summary>
        /// <param name="fileName">The filename on the exporter to use.</param>
        /// <param name="lotId">The requested lot ID. Optional.</param>
        /// <param name="dataService">The data service to send this on.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<IAsyncSendLot> SendAsyncLotAsync(string fileName, int? lotId, string dataService = "SLHD1");
    }
}

using MsacClient.XmlData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient
{
    /// <summary>
    /// A single transaction between the server and client.
    /// </summary>
    public interface IMsacTransportTransaction : IDisposable
    {
        /// <summary>
        /// Sends bytes to the server.
        /// </summary>
        /// <returns></returns>
        Task SendAsync(byte[] data, int index, int length);

        /// <summary>
        /// Reads into this buffer until the connection is shut down or it is full.
        /// </summary>
        /// <returns></returns>
        Task<int> ReadToEndAsync(byte[] buffer, int index, int length);
    }
}

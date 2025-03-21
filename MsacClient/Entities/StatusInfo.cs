using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Entities
{
    public class StatusInfo
    {
        /// <summary>
        /// Reported operating system of the MSAC server.
        /// </summary>
        public string MsacOS { get; set; }

        /// <summary>
        /// Reported version of the MSAC server.
        /// </summary>
        public string MsacVersion { get; set; }

        /// <summary>
        /// The reported lot ID.
        /// </summary>
        public string LotId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Entities
{
    /// <summary>
    /// Info for sending PSD.
    /// </summary>
    public class PsdSendInfo
    {
        /// <summary>
        /// Required. EVEN FOR HD2, YOU LIKELY WANT TO LEAVE THIS AS-IS. Refer to ExporterAddress
        /// </summary>
        public string AudioChannel { get; set; } = "HD1";

        /// <summary>
        /// The exporter that the MSAC will send the PSD info to. This is likely the same address, followed by a colon, and one of these ports:
        /// HD1: 11000
        /// HD2+: 10010 + (HD - 2) -> IE HD2 would be 10010, HD3 10011
        /// </summary>
        public string ExporterAddress { get; set; }

        /// <summary>
        /// Required, but may be blank. The title to set.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Required, but may be blank. The artist to set.
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Required, but may be blank. The album to set.
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Required, but may be blank. The genre to set.
        /// </summary>
        public string Genre { get; set; }
    }
}

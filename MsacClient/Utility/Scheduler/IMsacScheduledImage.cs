using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MsacClient.Utility.Scheduler
{
    /// <summary>
    /// User-implemented wrapper for an image. Must implement Equals as well.
    /// </summary>
    public interface IMsacScheduledImage
    {
        /// <summary>
        /// The unique filename for this image.
        /// </summary>
        string Filename { get; }

        /// <summary>
        /// The data service channel to send this on the MSAC. AAHD1 for HD1
        /// </summary>
        string DataService { get; }

        /// <summary>
        /// Open the file for reading to transmit.
        /// </summary>
        /// <returns></returns>
        Stream Open();
    }
}

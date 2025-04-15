using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Simulator.Output
{
    /// <summary>
    /// File direct send.
    /// </summary>
    public class SimOutputUpload
    {
        /// <summary>
        /// Time of the upload.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Virtual filename.
        /// </summary>
        public string Filename { get; set; }
    }
}

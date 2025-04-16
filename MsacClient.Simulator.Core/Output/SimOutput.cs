using MsacClient.Simulator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Core.Output
{
    /// <summary>
    /// The results of a simulation.
    /// </summary>
    public class SimOutput
    {
        /// <summary>
        /// The parameters for the test.
        /// </summary>
        public MsacSimTest Settings { get; set; }

        /// <summary>
        /// Time of the last tick.
        /// </summary>
        public DateTime LastTick { get; set; }

        /// <summary>
        /// Lots created in this simulation.
        /// </summary>
        public List<SimOutputLot> Lots { get; set; } = new List<SimOutputLot>();

        /// <summary>
        /// ID3 outputs
        /// </summary>
        public List<SimOutputPsd> Psds { get; set; } = new List<SimOutputPsd>();

        /// <summary>
        /// List of file uploads.
        /// </summary>
        public List<SimOutputUpload> Uploads { get; set; } = new List<SimOutputUpload>();
    }
}

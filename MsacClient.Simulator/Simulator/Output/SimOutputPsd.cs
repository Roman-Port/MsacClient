using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Simulator.Output
{
    /// <summary>
    /// PSD output event.
    /// </summary>
    public class SimOutputPsd
    {
        /// <summary>
        /// Simulated time.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// PSD text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Lot ID, if specified.
        /// </summary>
        public int? LotId { get; set; }
    }
}

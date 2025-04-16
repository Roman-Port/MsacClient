using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Core.Output
{
    /// <summary>
    /// An output lot.
    /// </summary>
    public class SimOutputLot
    {
        /// <summary>
        /// Virtual lot ID.
        /// </summary>
        public int LotId { get; set; }

        /// <summary>
        /// Virtual filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The time this was created at.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The initial time that the start was set to.
        /// </summary>
        public DateTime InitialStartTime { get; set; }

        /// <summary>
        /// The time this was finally sent at, or cancelled at
        /// </summary>
        public DateTime FinalStartTime { get; set; }

        /// <summary>
        /// The duration of the event.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The expiry given to the MSAC.
        /// </summary>
        public DateTime Expiry { get; set; }

        /// <summary>
        /// True if this was finally cancelled.
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// Events related to this lot.
        /// </summary>
        public List<SimOutputLotEvent> Events { get; set; } = new List<SimOutputLotEvent>();
    }
}

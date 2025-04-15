using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Simulator.Output
{
    /// <summary>
    /// Events that happened to a lot throughout it's life.
    /// </summary>
    public class SimOutputLotEvent
    {
        /// <summary>
        /// Time that the event happened at.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The type of event.
        /// </summary>
        public SimOutputLotEventType EventType { get; set; }

        /// <summary>
        /// For start changes, this is the new start time.
        /// </summary>
        public DateTime Parameter { get; set; }
    }
}

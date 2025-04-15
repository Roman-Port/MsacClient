using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator.Simulator.Settings
{
    /// <summary>
    /// Represents a list of events at a specified time.
    /// </summary>
    public class MsacSimEventList
    {
        /// <summary>
        /// User-defined comment for this item.
        /// </summary>
        public string Comment { get; set; } = null;

        /// <summary>
        /// Offset from epoch to apply this event.
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Events at this time.
        /// </summary>
        public List<MsacSimEvent> Events { get; set; } = new List<MsacSimEvent>();
    }
}

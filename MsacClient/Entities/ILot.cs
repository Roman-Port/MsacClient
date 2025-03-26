using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Entities
{
    /// <summary>
    /// A lot that is being sent.
    /// </summary>
    public interface ILot
    {
        /// <summary>
        /// The physical lot ID.
        /// </summary>
        int LotId { get; }
    }
}

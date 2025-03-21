using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient.Exceptions
{
    /// <summary>
    /// Indicates that the MSAC returned a bad return string.
    /// </summary>
    public class MsacBadStatusException : Exception
    {
        public MsacBadStatusException(string returnString) : base($"The MSAC returned a bad return string: \"{returnString}\".")
        {
            this.returnString = returnString;
        }

        private readonly string returnString;

        /// <summary>
        /// The return string the MSAC specified.
        /// </summary>
        public string ReturnString => returnString;
    }
}

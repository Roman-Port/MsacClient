using System;
using System.Collections.Generic;
using System.Text;

namespace MsacClient
{
    static class Utils
    {
        /// <summary>
        /// This comes directly from the TX_TN_4289 document and expresses the IDs that map to their offset, in hours, from UTC.
        /// </summary>
        private static readonly KeyValuePair<string, TimeSpan>[] TIMEZONE_IDS = new KeyValuePair<string, TimeSpan>[]
        {
            new KeyValuePair<string, TimeSpan>("GMT", TimeSpan.FromHours(0)),
            new KeyValuePair<string, TimeSpan>("UTC", TimeSpan.FromHours(0)),
            new KeyValuePair<string, TimeSpan>("AST", TimeSpan.FromHours(-4)),
            new KeyValuePair<string, TimeSpan>("EST", TimeSpan.FromHours(-5)),
            new KeyValuePair<string, TimeSpan>("EDT", TimeSpan.FromHours(-4)),
            new KeyValuePair<string, TimeSpan>("CST", TimeSpan.FromHours(-6)),
            new KeyValuePair<string, TimeSpan>("CDT", TimeSpan.FromHours(-5)),
            new KeyValuePair<string, TimeSpan>("MST", TimeSpan.FromHours(-7)),
            new KeyValuePair<string, TimeSpan>("MDT", TimeSpan.FromHours(-6)),
            new KeyValuePair<string, TimeSpan>("PST", TimeSpan.FromHours(-8)),
            new KeyValuePair<string, TimeSpan>("PDT", TimeSpan.FromHours(-7)),
            new KeyValuePair<string, TimeSpan>("AKST", TimeSpan.FromHours(-9)),
            new KeyValuePair<string, TimeSpan>("AKDT", TimeSpan.FromHours(-8)),
            new KeyValuePair<string, TimeSpan>("HST", TimeSpan.FromHours(-10)),
            new KeyValuePair<string, TimeSpan>("HAST", TimeSpan.FromHours(-10)),
            new KeyValuePair<string, TimeSpan>("HADT", TimeSpan.FromHours(-9)),
            new KeyValuePair<string, TimeSpan>("SST", TimeSpan.FromHours(-11)),
            new KeyValuePair<string, TimeSpan>("SDT", TimeSpan.FromHours(-10)),
        };

        /// <summary>
        /// Converts from a C# DateTime to the DateTime string that the MSAC expects.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateTimeToMsacString(DateTime dt)
        {
            //Convert to UTC
            if (dt.Kind != DateTimeKind.Utc)
                dt = dt.ToLocalTime();

            return dt.ToString("ddd MMM dd HH:mm:ss 'GMT' yyyy");
        }

        /// <summary>
        /// Gets the absolute difference between the two date times
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static TimeSpan AbsDifference(this DateTime a, DateTime b)
        {
            return new TimeSpan(Math.Abs((a - b).Ticks));
        }

        /// <summary>
        /// Gets the larger of two TimeSpans
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static TimeSpan Max(this TimeSpan a, TimeSpan b)
        {
            if (a > b)
                return a;
            return b;
        }
    }
}

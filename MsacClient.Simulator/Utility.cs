using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsacClient.Simulator
{
    static class Utility
    {
        public static TimeSpan Time(double hours, double mins, double secs)
        {
            return TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(mins) + TimeSpan.FromSeconds(secs);
        }
    }
}

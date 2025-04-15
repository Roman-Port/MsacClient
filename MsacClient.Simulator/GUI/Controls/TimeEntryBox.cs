using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Simulator.GUI.Controls
{
    public class TimeEntryBox : MaskedTextBox
    {
        public TimeEntryBox()
        {
            Mask = "00:00:00:00 sec";
            TextMaskFormat = MaskFormat.IncludePrompt;
            Text = "00000000";
        }

        /// <summary>
        /// Gets or sets the value in time.
        /// </summary>
        public TimeSpan ValueTime
        {
            get
            {
                if (TryGetTimeValue(out TimeSpan value))
                    return value;
                throw new Exception("Incomplete time.");
            } set
            {
                Text = ConvertDigit(value.Days) +
                    ConvertDigit(value.Hours) +
                    ConvertDigit(value.Minutes) +
                    ConvertDigit(value.Seconds);
            }
        }

        /// <summary>
        /// Returns a two digit value for converting time back into this string.
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        private string ConvertDigit(int digit)
        {
            string text = digit.ToString();
            if (text.Length == 1)
                text = "0" + text;
            if (text.Length > 2 || text.Length == 0)
                throw new Exception("Invalid time.");
            return text;
        }

        public bool TryGetTimeValue(out TimeSpan value)
        {
            //Clear
            value = TimeSpan.Zero;

            //Get and check length
            string text = Text;
            if (text.Length != 8)
                return false;

            //Parse out every two digits
            int[] components = new int[4]; //days, hours, min, sec
            for (int i = 0; i < 4; i++)
            {
                if (int.TryParse(text.Substring(i * 2, 2), out int decoded))
                    components[i] = decoded;
                else
                    return false;
            }

            //Convert
            value = TimeSpan.FromSeconds(components[3]);
            value += TimeSpan.FromMinutes(components[2]);
            value += TimeSpan.FromHours(components[1]);
            value += TimeSpan.FromDays(components[0]);
            return true;
        }
    }
}

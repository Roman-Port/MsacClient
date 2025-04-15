using MsacClient.Simulator.Simulator.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Simulator.GUI.Forms
{
    public partial class TestEventListEditor : Form
    {
        public TestEventListEditor(MsacSimEventList info)
        {
            this.info = info;
            InitializeComponent();
        }

        private readonly MsacSimEventList info;

        private const string TIME_HELP_STRING = "\r\n\r\nFormat times as dd:hh:mm:ss after the epoch.";

        private void TestEventListEditor_Load(object sender, EventArgs e)
        {
            //Initialize data in table
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var evt in info.Events.OrderBy(x => x.Start))
            {
                DataGridViewRow r = (DataGridViewRow)timelineGrid.Rows[0].Clone();
                r.Cells[0].Value = evt.Comment;
                r.Cells[1].Value = TimeToString(evt.Start);
                r.Cells[2].Value = TimeToString(evt.End - evt.Start);
                r.Cells[3].Value = evt.ImageFilename == null ? "" : evt.ImageFilename;
                rows.Add(r);
            }
            timelineGrid.Rows.AddRange(rows.ToArray());

            //Set other info
            fieldComment.Text = info.Comment;
            fieldTime.ValueTime = info.Time;
        }

        /// <summary>
        /// Parses timeline.
        /// </summary>
        /// <returns></returns>
        private bool TryParseTable(out List<MsacSimEvent> events)
        {
            events = new List<MsacSimEvent>();
            foreach (var _r in timelineGrid.Rows)
            {
                //Gather data from columns
                DataGridViewRow r = (DataGridViewRow)_r;
                if (r.IsNewRow)
                    continue;
                string comment = r.Cells[0].Value as string;
                string startRaw = r.Cells[1].Value as string;
                string lengthRaw = r.Cells[2].Value as string;
                string image = r.Cells[3].Value as string;

                //Interpret empty image as null
                if (image != null && image.Length == 0)
                    image = null;

                //Parse times
                TimeSpan start;
                if (!TryParseTime(startRaw, out start))
                {
                    MessageBox.Show($"Invalid start time in row {r.Index + 1}" + TIME_HELP_STRING, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                TimeSpan length;
                if (!TryParseTime(lengthRaw, out length))
                {
                    MessageBox.Show($"Invalid length time in row {r.Index + 1}" + TIME_HELP_STRING, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //Wrap
                events.Add(new MsacSimEvent
                {
                    Comment = comment,
                    Start = start,
                    End = start + length,
                    ImageFilename = image
                });
            }
            return true;
        }

        private bool TryParseTime(string text, out TimeSpan time)
        {
            //Clear
            time = TimeSpan.Zero;
            if (text == null)
                return true;

            //Split into components
            string[] components = text.Split(':');
            if (components.Length > 4)
                return false;

            //Parse backwards
            double[] parsed = new double[4]; // sec, min, hour, day
            int parsedIndex = 0;
            for (int i = components.Length - 1; i >= 0; i--)
            {
                if (double.TryParse(components[i], out double result))
                    parsed[parsedIndex++] = result;
                else
                    return false;
            }

            //Commit
            time = TimeSpan.FromSeconds(parsed[0]);
            time += TimeSpan.FromMinutes(parsed[1]);
            time += TimeSpan.FromHours(parsed[2]);
            time += TimeSpan.FromDays(parsed[3]);
            return true;
        }

        private string TimeToString(TimeSpan time)
        {
            return $"{ConvertDigit(time.Days)}:{ConvertDigit(time.Hours)}:{ConvertDigit(time.Minutes)}:{ConvertDigit(time.Seconds)}";
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Attempt to decode grid
            if (!TryParseTable(out List<MsacSimEvent> list))
                return;

            //Attempt to decode time
            TimeSpan time;
            if (!fieldTime.TryGetTimeValue(out time))
            {
                MessageBox.Show("The entered trigger time is invalid.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Save settings
            info.Comment = fieldComment.Text;
            info.Time = time;
            info.Events = list;

            //Set and exit
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

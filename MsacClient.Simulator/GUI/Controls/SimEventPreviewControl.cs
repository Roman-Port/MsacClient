using MsacClient.Simulator.Simulator.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Simulator.GUI.Controls
{
    /// <summary>
    /// Control that just renders rectangles where events are
    /// </summary>
    public class SimEventPreviewControl : BaseTimeControl
    {
        private MsacSimEvent[] events = new MsacSimEvent[0];
        private Color fillColor;

        /// <summary>
        /// Color to fill boxes with
        /// </summary>
        public Color FillColor
        {
            get => fillColor;
            set
            {
                fillColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Simulated events to display.
        /// </summary>
        public MsacSimEvent[] SimEvents
        {
            get => events;
            set
            {
                events = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            //Erase background
            pe.Graphics.Clear(BackColor);

            //Draw each event's background first
            Brush fillBrush = new SolidBrush(FillColor);
            foreach (var e in events)
                pe.Graphics.FillRectangle(fillBrush, GetEventRect(e));

            //Draw each event's border now
            Pen borderPen = new Pen(ForeColor);
            foreach (var e in events)
                pe.Graphics.DrawRectangle(borderPen, GetEventRect(e));
        }

        private Rectangle GetEventRect(MsacSimEvent e)
        {
            //Get times as pixels
            int start = TimeToPixel(e.Start);
            int end = TimeToPixel(e.End);

            //Check for bad values
            if (end < start)
                end = start;

            return new Rectangle(start, 0, end - start, Height - 1);
        }
    }
}

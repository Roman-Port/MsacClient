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
    /// Time control that renders gridlines
    /// </summary>
    public class GridlineTimeControl : BaseTimeControl
    {
        private const int TIME_MARGIN = 5;
        private const double TARGET_PIXELS_PER_GRIDLINE = 170;
        private const double MIN_GRIDLINE_MAJOR_INCREMENT = 15;
        private const double MAX_GRIDLINE_MAJOR_INCREMENT = 3000;

        public GridlineTimeControl()
        {
            //Create pens
            gridlinePen = new Pen(Color.LightGray, 1);
            gridlinePen.DashPattern = new float[] { 5, 5 };
        }

        private readonly Pen gridlinePen;
        private DateTime epoch;
        private TimeSpan minTime = TimeSpan.Zero; // Minimum time where data is drawn
        private TimeSpan maxTime = TimeSpan.Zero; // Maximum time where data is drawn

        /// <summary>
        /// Time added to values to produce the time.
        /// </summary>
        public DateTime Epoch
        {
            get => epoch;
            set
            {
                epoch = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Minimum time rendered.
        /// </summary>
        public TimeSpan MinTime
        {
            get => minTime;
            set
            {
                minTime = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Maximum time rendered.
        /// </summary>
        public TimeSpan MaxTime
        {
            get => maxTime;
            set
            {
                maxTime = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Paints vertical gridlines showing time scale.
        /// </summary>
        /// <param name="gfx"></param>
        protected void PaintTimeGridlines(Graphics gfx)
        {
            //Calculate the target number of shown gridlines from the density requested
            double targetPixelsPerGridline = TARGET_PIXELS_PER_GRIDLINE;
            double targetShownGridlines = (GraphWidth + (targetPixelsPerGridline - 1)) / targetPixelsPerGridline;

            //Start from the smallest increment and increase until we reach the target number of gridlines
            double incrementSeconds = MIN_GRIDLINE_MAJOR_INCREMENT;
            while (DisplayedTime.TotalSeconds / incrementSeconds > targetShownGridlines && incrementSeconds <= MAX_GRIDLINE_MAJOR_INCREMENT)
                incrementSeconds *= 2;

            //Render major gridlines
            PaintSingleTimeGridlines(gfx, TimeSpan.FromSeconds(incrementSeconds), gridlinePen);
        }

        private void PaintSingleTimeGridlines(Graphics gfx, TimeSpan tick, Pen pen)
        {
            //Get start time on the tick boundry
            TimeSpan time = new TimeSpan(Start.Ticks - (Start.Ticks % tick.Ticks));

            //Determine width between each tick in pixels
            int tickPixels = TimeToPixel(tick + tick) - TimeToPixel(tick);
            int height = ClientRectangle.Height;

            //Render
            while (time <= End)
            {
                //Draw
                if (time >= minTime && time <= maxTime)
                {
                    //Draw grid line
                    int pos = TimeToPixel(time);
                    gfx.DrawLine(pen, pos, 0, pos, ClientSize.Height);

                    //Draw time as text
                    string text = (epoch + time).ToLongTimeString();
                    RectangleF rect = new RectangleF(pos + TIME_MARGIN, 0, tickPixels - TIME_MARGIN - TIME_MARGIN, height - TIME_MARGIN);
                    gfx.DrawString(text, SystemFonts.DefaultFont, Brushes.Gray, rect, new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Far
                    });
                }

                //Increment
                time += tick;
            }
        }
    }
}

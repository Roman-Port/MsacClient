using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Simulator.GUI.Controls
{
    /// <summary>
    /// Basic control for rending time based events
    /// </summary>
    public class BaseTimeControl : Control
    {
        public BaseTimeControl()
        {
            DoubleBuffered = true;
        }

        private Padding graphMargins;
        private TimeSpan start = TimeSpan.Zero; // Left side of the graph
        private TimeSpan end = TimeSpan.FromSeconds(90); // Right side of the graph

        public bool UserScrollable { get; set; } = false;

        /// <summary>
        /// Margins of the graph in pixels.
        /// </summary>
        public Padding GraphMargins
        {
            get => graphMargins;
            set
            {
                graphMargins = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Start time.
        /// </summary>
        public TimeSpan Start
        {
            get => start;
            set
            {
                start = value;
                Invalidate();
            }
        }

        /// <summary>
        /// End time.
        /// </summary>
        public TimeSpan End
        {
            get => end;
            set
            {
                end = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Width of the graph in pixels.
        /// </summary>
        public int GraphWidth => ClientSize.Width - graphMargins.Horizontal - 1;

        /// <summary>
        /// Total displayed time.
        /// </summary>
        public TimeSpan DisplayedTime => end - start;

        /// <summary>
        /// Converts a timestamp to a pixel location across the X axis.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        protected int TimeToPixel(TimeSpan time)
        {
            if (DisplayedTime.TotalSeconds == 0)
                return 0;
            return graphMargins.Left + (int)(((time.TotalSeconds - start.TotalSeconds) / DisplayedTime.TotalSeconds) * GraphWidth);
        }

        /// <summary>
        /// Converts a pixel location across the X axis to a timestamp. Inverse of TimeToPixel.
        /// </summary>
        /// <param name="pixel"></param>
        /// <returns></returns>
        protected TimeSpan PixelToTime(int pixel)
        {
            if (GraphWidth == 0)
                return TimeSpan.Zero;
            return TimeSpan.FromSeconds(start.TotalSeconds + (((double)(pixel - graphMargins.Left) / GraphWidth) * DisplayedTime.TotalSeconds));
        }

        private bool scrolling;
        private int lastMouseX;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            scrolling = true;
            lastMouseX = e.X;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (scrolling)
            {
                //Get delta
                int delta = lastMouseX - e.X;
                lastMouseX = e.X;

                //Slide
                TimeSpan move = PixelToTime(delta) - PixelToTime(0);
                Start += move;
                End += move;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            scrolling = false;
        }
    }
}

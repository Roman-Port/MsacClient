using MsacClient.Simulator.Simulator.Output;
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
    /// Graph to render results.
    /// </summary>
    public class SimResultsGraphControl : GridlineTimeControl
    {
        public SimResultsGraphControl()
        {
            UserScrollable = true;
        }

        private SimOutput data;
        private List<RenderTimeline> timelines = new List<RenderTimeline>();
        private List<RenderId3> id3s = new List<RenderId3>();

        private Color colorMarkerCreated = Color.DarkSlateBlue;
        private Color colorMarkerStartSend = Color.Blue;
        private Color colorMarkerFinishSend = Color.DarkGreen;
        private Color colorMarkerCancel = Color.Red;

        private const int TEXT_PADDING = 5;
        private const int TIMELINE_HEIGHT = 30;
        private const int TIMELINE_SPACING = 10;

        /// <summary>
        /// Data to be displayed
        /// </summary>
        public SimOutput Data
        {
            get => data;
            set
            {
                data = value;
                RenderData();
            }
        }

        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            //Clear
            pe.Graphics.Clear(BackColor);

            //Render status text
            if (Text.Length > 0)
            {
                pe.Graphics.DrawString(Text, DefaultFont, Brushes.Black, new Rectangle(0, 0, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            //Render ID3s
            foreach (var i in id3s)
            {
                //Cull
                if (i.End < Start || i.Start > End)
                    continue;

                //Get start and end pixel -- extend to end of screen if this is the last one
                int startX = TimeToPixel(i.Start);
                int endX = TimeToPixel(i.End == MaxTime ? End : i.End);

                //Draw text
                Rectangle textRect = new Rectangle(startX + TEXT_PADDING, 0, endX - startX - TEXT_PADDING - TEXT_PADDING, Height - 31);
                if (textRect.Width > 0)
                {
                    pe.Graphics.DrawString(i.Text, Font, Brushes.Black, textRect, new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Far
                    });
                }

                //Draw line
                pe.Graphics.DrawLine(Pens.Black, startX, 0, startX, Height - 1);
                pe.Graphics.DrawLine(Pens.Black, endX, 0, endX, Height - 1);
            }

            //Render gridlines
            PaintTimeGridlines(pe.Graphics);

            //Render timelines
            foreach (var t in timelines)
            {
                //Cull
                if (t.End < Start || t.Start > End)
                    continue;

                //Get start and end pixel
                int startX = TimeToPixel(t.Start);
                int endX = TimeToPixel(t.End);

                //Get heights
                int y = (t.YIndex * TIMELINE_HEIGHT) + ((t.YIndex + 1) * TIMELINE_SPACING);
                int yHalf = y + (TIMELINE_HEIGHT / 2);

                //Render text
                Rectangle textRect = new Rectangle(startX + TEXT_PADDING, y, endX - startX - TEXT_PADDING - TEXT_PADDING, TIMELINE_HEIGHT / 2);
                pe.Graphics.DrawString(t.Text, DefaultFont, Brushes.Black, textRect, new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });

                //Draw line
                pe.Graphics.DrawLine(Pens.Black, startX, yHalf, endX, yHalf);

                //Draw markers
                foreach (var m in t.Checkpoints)
                {
                    //Get X
                    int x = TimeToPixel(m.Time);

                    //Draw line
                    pe.Graphics.DrawLine(new Pen(m.Color), x, y, x, y + TIMELINE_HEIGHT);

                    //Render text
                    textRect = new Rectangle(x + TEXT_PADDING, yHalf, endX - x - TEXT_PADDING, TIMELINE_HEIGHT / 2);
                    pe.Graphics.DrawString(m.Text, DefaultFont, new SolidBrush(m.Color), textRect, new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    });
                }
            }
        }

        /// <summary>
        /// Processes new data
        /// </summary>
        private void RenderData()
        {
            //Clear
            timelines.Clear();
            id3s.Clear();

            //Proceed if set
            if (data != null)
            {
                //Set render region
                Start = TimeSpan.Zero;
                End = data.LastTick - data.Settings.Epoch;
                MinTime = Start;
                MaxTime = End;

                //Add all ID3s
                RenderId3 last = null;
                foreach (var psd in data.Psds.OrderBy(x => x.Time))
                {
                    //Terminate last
                    if (last != null)
                        last.End = psd.Time - data.Settings.Epoch;

                    //Create new
                    last = new RenderId3
                    {
                        Start = psd.Time - data.Settings.Epoch,
                        End = End,
                        LotId = psd.LotId,
                        Text = psd.Text
                    };
                    id3s.Add(last);
                }

                //Add all lots
                int index = 0;
                foreach (var l in data.Lots)
                {
                    //Find last time it was referenced
                    TimeSpan lastTime = (l.InitialStartTime + l.Duration) - data.Settings.Epoch;
                    foreach (var id3 in id3s)
                    {
                        if (id3.LotId == l.LotId && id3.End > lastTime)
                            lastTime = id3.End;
                    }

                    //Create
                    RenderTimeline tl = new RenderTimeline
                    {
                        YIndex = index++,
                        Text = $"Lot {l.LotId} - {l.Filename}",
                        Start = l.CreatedAt - data.Settings.Epoch,
                        End = lastTime
                    };
                    timelines.Add(tl);

                    //Put marker at start
                    tl.Checkpoints.Add(new RenderCheckpoint
                    {
                        Time = l.CreatedAt - data.Settings.Epoch,
                        Color = colorMarkerCreated,
                        Text = "Notified MSAC"
                    });

                    //Find the final send time (if it was moved)
                    DateTime sendTime = l.InitialStartTime;
                    bool cancelled = false;
                    foreach (var e in l.Events)
                    {
                        if (e.Time < sendTime)
                        {
                            switch (e.EventType)
                            {
                                case SimOutputLotEventType.MODIFY_START:
                                    sendTime = e.Parameter;
                                    break;
                                case SimOutputLotEventType.CANCEL:
                                    cancelled = true;
                                    sendTime = e.Time;
                                    break;
                            }
                        }
                    }

                    //Set state
                    tl.StartedSend = sendTime - data.Settings.Epoch;
                    tl.Cancelled = cancelled;

                    //Put marker at end
                    tl.Checkpoints.Add(new RenderCheckpoint
                    {
                        Time = sendTime - data.Settings.Epoch,
                        Color = cancelled ? colorMarkerCancel : colorMarkerStartSend,
                        Text = cancelled ? "Cancelled" : "Start Send"
                    });

                    //Put marker at end of send period
                    if (!cancelled)
                    {
                        tl.Checkpoints.Add(new RenderCheckpoint
                        {
                            Time = sendTime + l.Duration - data.Settings.Epoch,
                            Color = colorMarkerFinishSend,
                            Text = "Send Finish"
                        });
                    }
                }
            }

            //Invalidate
            Invalidate();
        }

        class RenderId3
        {
            public TimeSpan Start { get; set; }
            public TimeSpan End { get; set; }
            public string Text { get; set; }
            public int? LotId { get; set; }
        }

        class RenderTimeline
        {
            public int YIndex { get; set; }
            public string Text { get; set; }
            public TimeSpan Start { get; set; }
            public TimeSpan End { get; set; }
            public TimeSpan StartedSend { get; set; }
            public bool Cancelled { get; set; }
            public List<RenderCheckpoint> Checkpoints { get; set; } = new List<RenderCheckpoint>();
        }

        class RenderCheckpoint
        {
            public TimeSpan Time { get; set; }
            public Color Color { get; set; }
            public string Text { get; set; }
        }
    }
}

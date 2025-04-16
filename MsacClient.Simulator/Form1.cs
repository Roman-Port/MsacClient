using MsacClient.Simulator.GUI;
using MsacClient.Simulator.Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MsacSimTest settings = new MsacSimTest
            {
                Label = "Test",
                /*Timeline = new List<MsacSimEventList>()
                {
                    new MsacSimEventList
                    {
                        Time = Utility.Time(0, 0, 0),
                        Events = new List<MsacSimEvent>()
                        {
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 10, 0),
                                Length = Utility.Time(0, 2, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            },
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 12, 0),
                                Length = Utility.Time(0, 1, 0),
                                Comment = "b",
                                ImageFilename = "img2"
                            }
                        }
                    },
                    new MsacSimEventList
                    {
                        Time = Utility.Time(0, 8, 0),
                        Events = new List<MsacSimEvent>()
                        {
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 10, 0),
                                Length = Utility.Time(0, 2, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            },
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 12, 0),
                                Length = Utility.Time(0, 1, 0),
                                Comment = "b",
                                ImageFilename = "img2"
                            },
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 13, 0),
                                Length = Utility.Time(0, 1, 0),
                                Comment = "c",
                                ImageFilename = "img1"
                            }
                        }
                    }
                }*/
                Timeline = new List<MsacSimEventList>()
                {
                    new MsacSimEventList
                    {
                        Time = Utility.Time(0, 0, 0),
                        Events = new List<MsacSimEvent>()
                        {
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 10, 0),
                                Length = Utility.Time(0, 5, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            }
                        }
                    },
                    new MsacSimEventList
                    {
                        Time = Utility.Time(0, 9, 30),
                        Events = new List<MsacSimEvent>()
                        {
                            new MsacSimEvent
                            {
                                Start = Utility.Time(0, 10, 1),
                                Length = Utility.Time(0, 5, 0),
                                Comment = "a",
                                ImageFilename = "img1"
                            }
                        }
                    }
                }
            };
            new TestEditorForm(settings).ShowDialog();
        }
    }
}

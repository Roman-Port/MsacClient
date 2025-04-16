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
                Timeline = new List<MsacSimEventList>()
                {
                    new MsacSimEventList
                    {
                        Time = TimeSpan.FromSeconds(0),
                        Events = new List<MsacSimEvent>
                        {
                            new MsacSimEvent
                            {
                                Start = TimeSpan.FromMinutes(10.2),
                                End = TimeSpan.FromMinutes(12.3),
                                Comment = "Test 1",
                                ImageFilename = "img1"
                            },
                            new MsacSimEvent
                            {
                                Start = TimeSpan.FromMinutes(12.3),
                                End = TimeSpan.FromMinutes(14.6),
                                Comment = "Test 2",
                                ImageFilename = "img2"
                            },
                            new MsacSimEvent
                            {
                                Start = TimeSpan.FromMinutes(50),
                                End = TimeSpan.FromMinutes(51),
                                Comment = "Test 3",
                                ImageFilename = "img3"
                            }
                        }
                    }
                }
            };
            new TestEditorForm(settings).ShowDialog();
        }
    }
}

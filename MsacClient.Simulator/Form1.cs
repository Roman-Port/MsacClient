using MsacClient.Simulator.GUI;
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
                                Start = TimeSpan.FromMinutes(10),
                                End = TimeSpan.FromMinutes(12),
                                Comment = "Test 1",
                                ImageFilename = "img1"
                            },
                            new MsacSimEvent
                            {
                                Start = TimeSpan.FromMinutes(14),
                                End = TimeSpan.FromMinutes(16),
                                Comment = "Test 2",
                                ImageFilename = "img2"
                            }
                        }
                    }
                }
            };
            new TestEditorForm(settings).ShowDialog();
        }
    }
}

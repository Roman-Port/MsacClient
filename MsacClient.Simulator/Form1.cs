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
using MsacClient.Simulator.Core;
using MsacClient.Simulator.Properties;
using MsacClient.Simulator.GUI.Forms;

namespace MsacClient.Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MsacSimTest test = new MsacSimTest();

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show file selector
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Text Files (*.txt)|*.txt";
            if (fd.ShowDialog() != DialogResult.OK)
                return;

            //Import
            test = new MsacSimTest
            {
                Label = "Imported Test",
                Timeline = RealWorldTestImporter.ImportFromFile(fd.FileName)
            };
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SimulatorRunnerForm(test).ShowDialog();
        }
    }
}

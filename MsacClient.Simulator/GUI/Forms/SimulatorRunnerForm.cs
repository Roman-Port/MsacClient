using MsacClient.Simulator.Simulator;
using MsacClient.Simulator.Simulator.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Simulator.GUI.Forms
{
    public partial class SimulatorRunnerForm : Form
    {
        public SimulatorRunnerForm(MsacSimTest settings)
        {
            this.settings = settings;
            run = new SimulationRunner(settings);
            InitializeComponent();
        }

        private readonly MsacSimTest settings;
        private readonly SimulationRunner run;
        private Thread worker;

        private void SimulatorRunnerForm_Load(object sender, EventArgs e)
        {
            //Set up simulator
            worker = new Thread(Worker);
            worker.IsBackground = true;
            worker.Start();
        }

        private void Worker()
        {
            int tickNum = 1;
            do
            {
                Invoke((MethodInvoker)delegate
                {
                    graph.Text = $"Simulating...(tick {tickNum++} at {run.SimulatedTime.ToShortDateString()} {run.SimulatedTime.ToLongTimeString()})";
                });
            } while (!run.Process());
            Invoke((MethodInvoker)delegate
            {
                graph.Text = "";
                graph.Data = run.Result;
            });
        }
    }
}

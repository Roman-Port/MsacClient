using MsacClient.Simulator.Core;
using MsacClient.Simulator.Core.Output;
using MsacClient.Simulator.Core.Settings;
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
                SimulationAvailable(run.Result);
            });
        }

        private void SimulationAvailable(SimOutput result)
        {
            //Set graph
            graph.Text = "";
            graph.Data = result;

            //Verify
            try
            {
                //Run
                Verifier ver = new Verifier(result);
                ver.Verify();

                //Check if errors
                if (ver.FirstError == null)
                {
                    //OK
                    passFailLabel.Text = "PASS";
                    passFailLabel.BackColor = Color.Lime;
                } else
                {
                    //FAIL
                    passFailLabel.Text = "FAIL: " + ver.FirstError;
                    passFailLabel.BackColor = Color.Red;
                }
            } catch (Exception ex)
            {
                //Set
                passFailLabel.Text = "EXCEPTION: " + ex.Message;
                passFailLabel.BackColor = Color.Red;
            }
        }

        class Verifier : SimulationVerifier
        {
            public Verifier(SimOutput result) : base(result)
            {
            }

            public string FirstError { get; set; } = null;

            protected override void Fault(string message)
            {
                if (FirstError == null)
                    FirstError = message;
            }
        }
    }
}

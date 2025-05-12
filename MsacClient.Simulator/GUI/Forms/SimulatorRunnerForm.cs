using MsacClient.Simulator.Core;
using MsacClient.Simulator.Core.Output;
using MsacClient.Simulator.Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private Verifier ver;
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
            //Tick graph
            int tickNum = 1;
            Stopwatch lastGuiUpdate = new Stopwatch();
            lastGuiUpdate.Start();
            do
            {
                //Set text if it hasn't recently
                if (tickNum == 1 || lastGuiUpdate.ElapsedMilliseconds > 1000 / 30)
                {
                    SetGraphTextFromWorker($"Simulating...(tick {tickNum} at {run.SimulatedTime.ToShortDateString()} {run.SimulatedTime.ToLongTimeString()})");
                    lastGuiUpdate.Restart();
                }

                //Increment state
                tickNum++;
            } while (!run.Process());

            //Set and start verifying
            Invoke((MethodInvoker)delegate
            {
                graph.Text = $"Verifying...";
                graph.Data = run.Result;
            });

            //Verify
            try
            {
                //Run
                ver = new Verifier(run.Result);
                ver.Verify();

                //Check if errors
                if (ver.FirstError == null)
                {
                    //OK
                    SetPassFailLabelFromWorker("PASS", Color.Lime);
                }
                else
                {
                    //FAIL
                    SetPassFailLabelFromWorker("FAIL: " + ver.FirstError, Color.Red);
                }
            }
            catch (Exception ex)
            {
                //Set
                SetPassFailLabelFromWorker("EXCEPTION: " + ex.Message, Color.Red);
            }
            SetGraphTextFromWorker("");

            //Enable toolstrip items
            Invoke((MethodInvoker)delegate
            {
                pSDListToolStripMenuItem.Enabled = true;
            });
        }

        private void SetGraphTextFromWorker(string text)
        {
            Invoke((MethodInvoker)delegate
            {
                graph.Text = text;
            });
        }

        private void SetPassFailLabelFromWorker(string text, Color color)
        {
            Invoke((MethodInvoker)delegate
            {
                passFailLabel.Text = text;
                passFailLabel.BackColor = color;
            });
        }

        class Verifier : SimulationVerifier
        {
            public Verifier(SimOutput result) : base(result)
            {
            }

            public string FirstError { get; set; } = null;
            public List<string> Warnings { get; set; } = new List<string>();

            protected override void Fault(string message)
            {
                if (FirstError == null)
                    FirstError = message;
            }

            protected override void Warn(string message)
            {
                Warnings.Add(message);
            }
        }

        private void pSDListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SimPsdsView(ver.ExpectedPsds.ToArray(), run.Result.Psds.ToArray(), run.Result.Settings.Epoch).Show();
        }
    }
}

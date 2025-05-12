using MsacClient.Simulator.Core.Output;
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

namespace MsacClient.Simulator.GUI.Forms
{
    public partial class SimPsdsView : Form
    {
        public SimPsdsView(MsacSimEvent[] inputData, SimOutputPsd[] outputData, DateTime epoch)
        {
            this.inputData = inputData;
            this.outputData = outputData;
            this.epoch = epoch;
            InitializeComponent();
        }

        private readonly MsacSimEvent[] inputData;
        private readonly SimOutputPsd[] outputData;
        private readonly DateTime epoch;

        private void SimPsdsView_Load(object sender, EventArgs e)
        {
            DataAdapter[] adapters = new DataAdapter[outputData.Length];
            for (int i = 0; i < adapters.Length; i++)
                adapters[i] = new DataAdapter(inputData, outputData, i, epoch);
            mainTable.DataSource = adapters;
        }

        class DataAdapter
        {
            public DataAdapter(MsacSimEvent[] inputData, SimOutputPsd[] outputData, int index, DateTime epoch)
            {
                this.inputData = inputData;
                this.outputData = outputData;
                this.index = index;
                this.epoch = epoch;
            }

            private readonly MsacSimEvent[] inputData;
            private readonly SimOutputPsd[] outputData;
            private readonly int index;
            private readonly DateTime epoch;

            private MsacSimEvent DataIn => inputData[index];
            private SimOutputPsd DataOut => outputData[index];

            public int Index => index;
            public string StartTimeIn => DataIn.Start.TotalSeconds.ToString();
            public string DurationIn => (DataIn.End - DataIn.Start).TotalSeconds.ToString();
            public string StartTimeOut => (DataOut.Time - epoch).TotalSeconds.ToString();
            public string DurationOut => (index + 1 == outputData.Length) ? "(last)" : (outputData[index+1].Time - DataOut.Time).TotalSeconds.ToString();
            public string Text => DataOut.Text;
            public string LotId => DataOut.LotId == null ? "(none)" : DataOut.LotId.Value.ToString();
        }
    }
}

using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Console.Forms
{
    public partial class LotForm : Form
    {
        public LotForm(IAsyncSendLot lot)
        {
            this.lot = lot;
            InitializeComponent();
        }

        private readonly IAsyncSendLot lot;

        private void SyncLotForm_Load(object sender, EventArgs e)
        {
            Text += " #" + lot.LotId;
            boxLotId.Text = lot.LotId.ToString();
            boxUniqueId.Text = lot.Tag;
            boxStatus.Text = lot.State;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            lot.RefreshStateAsync().ContinueWith(t =>
            {
                Invoke((MethodInvoker)delegate
                {
                    btnRefresh.Enabled = true;
                    if (t.IsFaulted)
                        MessageBox.Show("Error: " + t.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boxStatus.Text = lot.State;
                });
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            lot.CancelSendAsync().ContinueWith(t =>
            {
                Invoke((MethodInvoker)delegate
                {
                    if (t.IsFaulted)
                        MessageBox.Show("Error: " + t.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boxStatus.Text = lot.State;
                });
            });
        }
    }
}

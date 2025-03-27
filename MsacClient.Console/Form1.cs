using MsacClient.Console.Forms;
using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Console
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MsacTransport transport;
        private MsacConnection conn;

        private ConnectionStatus status;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Set status
            UpdateStatus(ConnectionStatus.CONNECTING, "Connecting...");

            //Create transport and connection
            transport = new MsacTransport(new IPEndPoint(IPAddress.Parse(connectHost.Text), (int)connectPort.Value));
            conn = new MsacConnection(transport);

            //Set flag
            UpdateStatus(ConnectionStatus.CONNECTED, "Ready.");
        }

        private void btnSendPSD_Click(object sender, EventArgs e)
        {
            //Automatiicaly determine the exporter address
            string exporterAddress = boxPsdPgm.Text;
            string baseExporterAddr = connectHost.Text + ":";
            if (exporterAddress == "HD1")
                exporterAddress = baseExporterAddr + "11000";
            else if (exporterAddress.StartsWith("HD") && int.TryParse(exporterAddress.Substring(2), out int subNum) && subNum > 1)
                exporterAddress = baseExporterAddr + (10010 + (subNum - 2)).ToString();

            //Start PSD build
            PsdSendBuilder builder = new PsdSendBuilder();
            builder.SetTitle(boxTitle.Text);
            builder.SetArtist(boxArtist.Text);
            builder.SetAlbum(boxAlbum.Text);
            builder.SetGenre(boxGenre.Text);

            //Do XHDR build
            string xhdrAction = boxXhdrAction.Text;
            switch (xhdrAction)
            {
                case "":
                case "<none>":
                    break;
                case "<flush memory>":
                    builder.XhdrFlushMemory();
                    break;
                case "<blank screen>":
                    builder.XhdrBlankScreen();
                    break;
                default: // parse lot ID
                    if (!int.TryParse(xhdrAction, out int lot))
                    {
                        MessageBox.Show("Unable to parse lot ID: " + xhdrAction, "Bad Lot ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    builder.XhdrTriggerImage(lot);
                    break;
            }

            //Set MIME
            string mime = boxXhdrMime.Text;
            if (mime.Contains('<')) // Trim off bracket where comments start
                mime = mime.Substring(0, mime.IndexOf('<'));
            mime = mime.Trim(); // Trim whitespace
            if (mime.Length > 0)
            {
                if (!mime.ToLower().StartsWith("0x") || mime.Contains(' '))
                {
                    MessageBox.Show("Mime must be a hexidecimal value.", "Bad MIME", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                builder.XhdrSetMime(mime);
            }

            //Send
            UpdateStatus(ConnectionStatus.PROCESSING_COMMAND, "Setting PSD...");
            conn.SendPSDAsync(builder, exporterAddress).ContinueWith((Task t) =>
            {
                if (t.IsFaulted)
                    UpdateStatus(ConnectionStatus.CONNECTED, "Failed: " + t.Exception.Message);
                else
                    UpdateStatus(ConnectionStatus.CONNECTED, "PSD set.");
            });
        }

        private void UpdateStatus(ConnectionStatus status, string statusText, Action extra = null)
        {
            Invoke((MethodInvoker)delegate
            {
                //Update label
                statusLabel.Text = statusText;

                //Update GUI
                bool connWaitng = status == ConnectionStatus.DISCONNECTED;
                bool ready = status == ConnectionStatus.CONNECTED;
                btnConnect.Enabled = connWaitng;
                connectHost.Enabled = connWaitng;
                connectPort.Enabled = connWaitng;

                btnSendPSD.Enabled = ready;
                boxTitle.Enabled = ready;
                boxArtist.Enabled = ready;
                boxAlbum.Enabled = ready;
                boxGenre.Enabled = ready;
                boxPsdPgm.Enabled = ready;
                boxXhdrAction.Enabled = ready;
                boxXhdrMime.Enabled = ready;
                boxDirectUploadName.Enabled = ready;
                btnDirectFileUpload.Enabled = ready;
                boxSyncActive.Enabled = ready;
                boxSyncCancelPrior.Enabled = ready;
                boxSyncDataService.Enabled = ready;
                boxSyncDuration.Enabled = ready;
                boxSyncExpiry.Enabled = ready;
                boxSyncFilename.Enabled = ready;
                boxSyncLotId.Enabled = ready;
                boxSyncTime.Enabled = ready;
                btnSyncSetTime.Enabled = ready;
                btnSyncSend.Enabled = ready;
                boxAsyncDataService.Enabled = ready;
                boxAsyncFileName.Enabled = ready;
                boxAsyncLotId.Enabled = ready;
                btnAsyncSend.Enabled = ready;

                //Fire extra
                if (extra != null)
                    extra();
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateStatus(ConnectionStatus.DISCONNECTED, "Ready for connection.");
            boxSyncTime.Value = DateTime.Now;
            boxSyncExpiry.Value = DateTime.Now.AddYears(10);
        }

        private void btnDirectFileUpload_Click(object sender, EventArgs e)
        {
            //Check that the filename is valid
            if (boxDirectUploadName.Text.Length == 0)
            {
                MessageBox.Show("The filename must not be blank.", "Filename Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Show file picker
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "*.*|*.*";
            if (fd.ShowDialog() != DialogResult.OK)
                return;

            //Read file data
            byte[] data = File.ReadAllBytes(fd.FileName);

            //Send
            conn.FileCopyDirectAsync(boxDirectUploadName.Text, data, 0, data.Length).ContinueWith((Task t) =>
            {
                if (t.IsFaulted)
                    UpdateStatus(ConnectionStatus.CONNECTED, "Failed: " + t.Exception.Message);
                else
                    UpdateStatus(ConnectionStatus.CONNECTED, "File uploaded OK.");
            });
        }

        private void btnSyncSend_Click(object sender, EventArgs e)
        {
            //Parse lot ID
            int? lotId = null;
            if (boxSyncLotId.Text.Length > 0)
            {
                if (int.TryParse(boxSyncLotId.Text, out int _lot))
                {
                    lotId = _lot;
                } else
                {
                    MessageBox.Show("Lot ID is invalid. Specify a number or leave blank", "Invalid Lot ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Send
            conn.PreSendSyncLotAsync(boxSyncTime.Value, boxSyncFilename.Text, TimeSpan.FromSeconds((int)boxSyncDuration.Value), lotId, boxSyncExpiry.Value, boxSyncDataService.Text, boxSyncActive.Checked ? SyncSendTriggerType.Active : SyncSendTriggerType.Passive, boxSyncCancelPrior.Checked).ContinueWith((Task<ISyncSendLot> t) =>
            {
                if (t.IsFaulted)
                    UpdateStatus(ConnectionStatus.CONNECTED, "Failed: " + t.Exception.Message);
                else
                    UpdateStatus(ConnectionStatus.CONNECTED, "OK.", () =>
                    {
                        ISyncSendLot lot = t.GetAwaiter().GetResult();
                        boxXhdrAction.Items.Add(lot.LotId);
                        new LotForm(lot).Show();
                    });
            });
        }

        private void btnSyncSetTime_Click(object sender, EventArgs e)
        {
            boxSyncTime.Value = DateTime.Now.AddSeconds(30);
        }

        private void btnAsyncSend_Click(object sender, EventArgs e)
        {
            //Parse lot ID
            int? lotId = null;
            if (boxAsyncLotId.Text.Length > 0)
            {
                if (int.TryParse(boxAsyncLotId.Text, out int _lot))
                {
                    lotId = _lot;
                }
                else
                {
                    MessageBox.Show("Lot ID is invalid. Specify a number or leave blank", "Invalid Lot ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Send
            conn.SendAsyncLotAsync(boxAsyncFileName.Text, lotId, boxAsyncDataService.Text).ContinueWith((Task<IAsyncSendLot> t) =>
            {
                if (t.IsFaulted)
                    UpdateStatus(ConnectionStatus.CONNECTED, "Failed: " + t.Exception.Message);
                else
                    UpdateStatus(ConnectionStatus.CONNECTED, "OK.", () =>
                    {
                        IAsyncSendLot lot = t.GetAwaiter().GetResult();
                        new LotForm(lot).Show();
                    });
            });
        }
    }
}

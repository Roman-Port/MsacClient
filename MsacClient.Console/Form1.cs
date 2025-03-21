using MsacClient.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            //Send
            UpdateStatus(ConnectionStatus.PROCESSING_COMMAND, "Setting PSD...");
            PsdSendInfo info = new PsdSendInfo
            {
                ExporterAddress = exporterAddress,
                Title = boxTitle.Text,
                Artist = boxArtist.Text,
                Album = boxAlbum.Text,
                Genre = boxGenre.Text
            };
            conn.SendPSDAsync(info).ContinueWith((Task t) =>
            {
                if (t.IsFaulted)
                    UpdateStatus(ConnectionStatus.CONNECTED, "Failed: " + t.Exception.Message);
                else
                    UpdateStatus(ConnectionStatus.CONNECTED, "PSD set.");
            });
        }

        private void UpdateStatus(ConnectionStatus status, string statusText)
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
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateStatus(ConnectionStatus.DISCONNECTED, "Ready for connection.");
        }
    }
}

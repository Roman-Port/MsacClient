namespace MsacClient.Console
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.connectHost = new System.Windows.Forms.TextBox();
            this.connectPort = new System.Windows.Forms.NumericUpDown();
            this.btnSendPSD = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.boxTitle = new System.Windows.Forms.TextBox();
            this.boxArtist = new System.Windows.Forms.TextBox();
            this.boxAlbum = new System.Windows.Forms.TextBox();
            this.boxGenre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.corePanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.boxPsdPgm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.connectPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.corePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(476, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // connectHost
            // 
            this.connectHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectHost.Location = new System.Drawing.Point(12, 12);
            this.connectHost.Name = "connectHost";
            this.connectHost.Size = new System.Drawing.Size(372, 20);
            this.connectHost.TabIndex = 1;
            this.connectHost.Text = "192.168.103.12";
            // 
            // connectPort
            // 
            this.connectPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectPort.Location = new System.Drawing.Point(390, 12);
            this.connectPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.connectPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.connectPort.Name = "connectPort";
            this.connectPort.Size = new System.Drawing.Size(80, 20);
            this.connectPort.TabIndex = 2;
            this.connectPort.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // btnSendPSD
            // 
            this.btnSendPSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendPSD.Location = new System.Drawing.Point(455, 94);
            this.btnSendPSD.Name = "btnSendPSD";
            this.btnSendPSD.Size = new System.Drawing.Size(75, 23);
            this.btnSendPSD.TabIndex = 3;
            this.btnSendPSD.Text = "Send";
            this.btnSendPSD.UseVisualStyleBackColor = true;
            this.btnSendPSD.Click += new System.EventHandler(this.btnSendPSD_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(563, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(29, 17);
            this.statusLabel.Text = "Idle.";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 139);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PSD Send";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSendPSD, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.boxTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.boxArtist, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.boxAlbum, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.boxGenre, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.boxPsdPgm, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(533, 120);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // boxTitle
            // 
            this.boxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxTitle.Location = new System.Drawing.Point(3, 16);
            this.boxTitle.Name = "boxTitle";
            this.boxTitle.Size = new System.Drawing.Size(260, 20);
            this.boxTitle.TabIndex = 1;
            this.boxTitle.Text = "KRVX-FM";
            // 
            // boxArtist
            // 
            this.boxArtist.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxArtist.Location = new System.Drawing.Point(269, 16);
            this.boxArtist.Name = "boxArtist";
            this.boxArtist.Size = new System.Drawing.Size(261, 20);
            this.boxArtist.TabIndex = 2;
            this.boxArtist.Text = "103.1 The Raven";
            // 
            // boxAlbum
            // 
            this.boxAlbum.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxAlbum.Location = new System.Drawing.Point(3, 55);
            this.boxAlbum.Name = "boxAlbum";
            this.boxAlbum.Size = new System.Drawing.Size(260, 20);
            this.boxAlbum.TabIndex = 3;
            // 
            // boxGenre
            // 
            this.boxGenre.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxGenre.Location = new System.Drawing.Point(269, 55);
            this.boxGenre.Name = "boxGenre";
            this.boxGenre.Size = new System.Drawing.Size(261, 20);
            this.boxGenre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Artist";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Album";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Genre";
            // 
            // corePanel
            // 
            this.corePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.corePanel.Controls.Add(this.groupBox1);
            this.corePanel.Location = new System.Drawing.Point(12, 38);
            this.corePanel.Name = "corePanel";
            this.corePanel.Size = new System.Drawing.Size(539, 387);
            this.corePanel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Program (or exporter address)";
            // 
            // boxPsdPgm
            // 
            this.boxPsdPgm.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxPsdPgm.FormattingEnabled = true;
            this.boxPsdPgm.Items.AddRange(new object[] {
            "HD1",
            "HD2",
            "HD3",
            "HD4",
            "HD5",
            "HD6",
            "HD7",
            "HD8"});
            this.boxPsdPgm.Location = new System.Drawing.Point(3, 94);
            this.boxPsdPgm.Name = "boxPsdPgm";
            this.boxPsdPgm.Size = new System.Drawing.Size(260, 21);
            this.boxPsdPgm.TabIndex = 10;
            this.boxPsdPgm.Text = "HD1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 450);
            this.Controls.Add(this.corePanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.connectPort);
            this.Controls.Add(this.connectHost);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.connectPort)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.corePanel.ResumeLayout(false);
            this.corePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox connectHost;
        private System.Windows.Forms.NumericUpDown connectPort;
        private System.Windows.Forms.Button btnSendPSD;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxTitle;
        private System.Windows.Forms.TextBox boxArtist;
        private System.Windows.Forms.TextBox boxAlbum;
        private System.Windows.Forms.TextBox boxGenre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel corePanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox boxPsdPgm;
    }
}


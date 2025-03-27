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
            this.label5 = new System.Windows.Forms.Label();
            this.boxPsdPgm = new System.Windows.Forms.ComboBox();
            this.corePanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDirectFileUpload = new System.Windows.Forms.Button();
            this.boxDirectUploadName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.boxXhdrAction = new System.Windows.Forms.ComboBox();
            this.boxXhdrMime = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSyncSend = new System.Windows.Forms.Button();
            this.boxSyncDuration = new System.Windows.Forms.NumericUpDown();
            this.boxSyncTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.boxSyncLotId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.boxSyncExpiry = new System.Windows.Forms.DateTimePicker();
            this.boxSyncFilename = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.boxSyncDataService = new System.Windows.Forms.TextBox();
            this.boxSyncActive = new System.Windows.Forms.CheckBox();
            this.boxSyncCancelPrior = new System.Windows.Forms.CheckBox();
            this.btnSyncSetTime = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.boxAsyncLotId = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.boxAsyncFileName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.boxAsyncDataService = new System.Windows.Forms.TextBox();
            this.btnAsyncSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.connectPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.corePanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxSyncDuration)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(473, 11);
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
            this.connectHost.Size = new System.Drawing.Size(369, 20);
            this.connectHost.TabIndex = 1;
            this.connectHost.Text = "192.168.103.12";
            // 
            // connectPort
            // 
            this.connectPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectPort.Location = new System.Drawing.Point(387, 12);
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
            this.btnSendPSD.Location = new System.Drawing.Point(435, 134);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(560, 22);
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
            this.groupBox1.Size = new System.Drawing.Size(519, 179);
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
            this.tableLayoutPanel1.Controls.Add(this.btnSendPSD, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.boxTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.boxArtist, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.boxAlbum, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.boxGenre, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.boxPsdPgm, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.boxXhdrAction, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.boxXhdrMime, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 160);
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
            this.boxTitle.Size = new System.Drawing.Size(250, 20);
            this.boxTitle.TabIndex = 1;
            this.boxTitle.Text = "KRVX-FM";
            // 
            // boxArtist
            // 
            this.boxArtist.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxArtist.Location = new System.Drawing.Point(259, 16);
            this.boxArtist.Name = "boxArtist";
            this.boxArtist.Size = new System.Drawing.Size(251, 20);
            this.boxArtist.TabIndex = 2;
            this.boxArtist.Text = "103.1 The Raven";
            // 
            // boxAlbum
            // 
            this.boxAlbum.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxAlbum.Location = new System.Drawing.Point(3, 55);
            this.boxAlbum.Name = "boxAlbum";
            this.boxAlbum.Size = new System.Drawing.Size(250, 20);
            this.boxAlbum.TabIndex = 3;
            // 
            // boxGenre
            // 
            this.boxGenre.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxGenre.Location = new System.Drawing.Point(259, 55);
            this.boxGenre.Name = "boxGenre";
            this.boxGenre.Size = new System.Drawing.Size(251, 20);
            this.boxGenre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 0);
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
            this.label4.Location = new System.Drawing.Point(259, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Genre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 118);
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
            this.boxPsdPgm.Location = new System.Drawing.Point(3, 134);
            this.boxPsdPgm.Name = "boxPsdPgm";
            this.boxPsdPgm.Size = new System.Drawing.Size(250, 21);
            this.boxPsdPgm.TabIndex = 10;
            this.boxPsdPgm.Text = "HD1";
            // 
            // corePanel
            // 
            this.corePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.corePanel.AutoScroll = true;
            this.corePanel.Controls.Add(this.groupBox4);
            this.corePanel.Controls.Add(this.groupBox3);
            this.corePanel.Controls.Add(this.groupBox2);
            this.corePanel.Controls.Add(this.groupBox1);
            this.corePanel.Location = new System.Drawing.Point(12, 38);
            this.corePanel.Name = "corePanel";
            this.corePanel.Size = new System.Drawing.Size(536, 492);
            this.corePanel.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 87);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Direct File Upload";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDirectFileUpload, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.boxDirectUploadName, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(513, 68);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Filename";
            // 
            // btnDirectFileUpload
            // 
            this.btnDirectFileUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectFileUpload.Location = new System.Drawing.Point(435, 42);
            this.btnDirectFileUpload.Name = "btnDirectFileUpload";
            this.btnDirectFileUpload.Size = new System.Drawing.Size(75, 23);
            this.btnDirectFileUpload.TabIndex = 3;
            this.btnDirectFileUpload.Text = "Upload...";
            this.btnDirectFileUpload.UseVisualStyleBackColor = true;
            this.btnDirectFileUpload.Click += new System.EventHandler(this.btnDirectFileUpload_Click);
            // 
            // boxDirectUploadName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.boxDirectUploadName, 2);
            this.boxDirectUploadName.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxDirectUploadName.Location = new System.Drawing.Point(3, 16);
            this.boxDirectUploadName.Name = "boxDirectUploadName";
            this.boxDirectUploadName.Size = new System.Drawing.Size(507, 20);
            this.boxDirectUploadName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Xhdr Trigger/Action";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Xhdr MIME type";
            // 
            // boxXhdrAction
            // 
            this.boxXhdrAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxXhdrAction.FormattingEnabled = true;
            this.boxXhdrAction.Items.AddRange(new object[] {
            "<none>",
            "<blank screen>",
            "<flush memory>"});
            this.boxXhdrAction.Location = new System.Drawing.Point(3, 94);
            this.boxXhdrAction.Name = "boxXhdrAction";
            this.boxXhdrAction.Size = new System.Drawing.Size(250, 21);
            this.boxXhdrAction.TabIndex = 14;
            this.boxXhdrAction.Text = "<none>";
            // 
            // boxXhdrMime
            // 
            this.boxXhdrMime.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxXhdrMime.FormattingEnabled = true;
            this.boxXhdrMime.Items.AddRange(new object[] {
            "<none>",
            "0xBE4B7536 <sync, album art>",
            "0xD9C72536 <async, station logo>"});
            this.boxXhdrMime.Location = new System.Drawing.Point(259, 94);
            this.boxXhdrMime.Name = "boxXhdrMime";
            this.boxXhdrMime.Size = new System.Drawing.Size(251, 21);
            this.boxXhdrMime.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(519, 142);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sync Send";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.boxSyncExpiry, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.boxSyncTime, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.boxSyncDuration, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label11, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.boxSyncLotId, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label13, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.boxSyncFilename, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.boxSyncDataService, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.boxSyncActive, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.boxSyncCancelPrior, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnSyncSend, 3, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnSyncSetTime, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(513, 123);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Start Time";
            // 
            // btnSyncSend
            // 
            this.btnSyncSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncSend.Location = new System.Drawing.Point(435, 97);
            this.btnSyncSend.Name = "btnSyncSend";
            this.btnSyncSend.Size = new System.Drawing.Size(75, 23);
            this.btnSyncSend.TabIndex = 3;
            this.btnSyncSend.Text = "Send";
            this.btnSyncSend.UseVisualStyleBackColor = true;
            this.btnSyncSend.Click += new System.EventHandler(this.btnSyncSend_Click);
            // 
            // boxSyncDuration
            // 
            this.boxSyncDuration.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxSyncDuration.Location = new System.Drawing.Point(259, 16);
            this.boxSyncDuration.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.boxSyncDuration.Name = "boxSyncDuration";
            this.boxSyncDuration.Size = new System.Drawing.Size(122, 20);
            this.boxSyncDuration.TabIndex = 4;
            // 
            // boxSyncTime
            // 
            this.boxSyncTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxSyncTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.boxSyncTime.Location = new System.Drawing.Point(3, 16);
            this.boxSyncTime.Name = "boxSyncTime";
            this.boxSyncTime.Size = new System.Drawing.Size(122, 20);
            this.boxSyncTime.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Duration (sec)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(387, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Lot ID";
            // 
            // boxSyncLotId
            // 
            this.boxSyncLotId.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxSyncLotId.Location = new System.Drawing.Point(387, 16);
            this.boxSyncLotId.Name = "boxSyncLotId";
            this.boxSyncLotId.Size = new System.Drawing.Size(123, 20);
            this.boxSyncLotId.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Expiry";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(259, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "File Name";
            // 
            // boxSyncExpiry
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.boxSyncExpiry, 2);
            this.boxSyncExpiry.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxSyncExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.boxSyncExpiry.Location = new System.Drawing.Point(3, 58);
            this.boxSyncExpiry.Name = "boxSyncExpiry";
            this.boxSyncExpiry.Size = new System.Drawing.Size(250, 20);
            this.boxSyncExpiry.TabIndex = 11;
            // 
            // boxSyncFilename
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.boxSyncFilename, 2);
            this.boxSyncFilename.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxSyncFilename.Location = new System.Drawing.Point(259, 58);
            this.boxSyncFilename.Name = "boxSyncFilename";
            this.boxSyncFilename.Size = new System.Drawing.Size(251, 20);
            this.boxSyncFilename.TabIndex = 12;
            this.boxSyncFilename.Text = "..\\data\\remote\\2382b6b19d75f26a04871b95e863ebce.jpg";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Data Service";
            // 
            // boxSyncDataService
            // 
            this.boxSyncDataService.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxSyncDataService.Location = new System.Drawing.Point(3, 97);
            this.boxSyncDataService.Name = "boxSyncDataService";
            this.boxSyncDataService.Size = new System.Drawing.Size(122, 20);
            this.boxSyncDataService.TabIndex = 14;
            this.boxSyncDataService.Text = "AAHD1";
            // 
            // boxSyncActive
            // 
            this.boxSyncActive.AutoSize = true;
            this.boxSyncActive.Dock = System.Windows.Forms.DockStyle.Left;
            this.boxSyncActive.Location = new System.Drawing.Point(131, 97);
            this.boxSyncActive.Name = "boxSyncActive";
            this.boxSyncActive.Size = new System.Drawing.Size(56, 23);
            this.boxSyncActive.TabIndex = 15;
            this.boxSyncActive.Text = "Active";
            this.boxSyncActive.UseVisualStyleBackColor = true;
            // 
            // boxSyncCancelPrior
            // 
            this.boxSyncCancelPrior.AutoSize = true;
            this.boxSyncCancelPrior.Dock = System.Windows.Forms.DockStyle.Left;
            this.boxSyncCancelPrior.Location = new System.Drawing.Point(259, 97);
            this.boxSyncCancelPrior.Name = "boxSyncCancelPrior";
            this.boxSyncCancelPrior.Size = new System.Drawing.Size(83, 23);
            this.boxSyncCancelPrior.TabIndex = 16;
            this.boxSyncCancelPrior.Text = "Cancel Prior";
            this.boxSyncCancelPrior.UseVisualStyleBackColor = true;
            // 
            // btnSyncSetTime
            // 
            this.btnSyncSetTime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSyncSetTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSyncSetTime.Location = new System.Drawing.Point(131, 16);
            this.btnSyncSetTime.Name = "btnSyncSetTime";
            this.btnSyncSetTime.Size = new System.Drawing.Size(122, 23);
            this.btnSyncSetTime.TabIndex = 17;
            this.btnSyncSetTime.Text = "Now + 30s";
            this.btnSyncSetTime.UseVisualStyleBackColor = true;
            this.btnSyncSetTime.Click += new System.EventHandler(this.btnSyncSetTime_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 408);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(519, 100);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Async Send";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.boxAsyncLotId, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label19, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.boxAsyncFileName, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.boxAsyncDataService, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label20, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label17, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnAsyncSend, 3, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(513, 81);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(131, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Lot ID";
            // 
            // boxAsyncLotId
            // 
            this.boxAsyncLotId.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxAsyncLotId.Location = new System.Drawing.Point(131, 55);
            this.boxAsyncLotId.Name = "boxAsyncLotId";
            this.boxAsyncLotId.Size = new System.Drawing.Size(122, 20);
            this.boxAsyncLotId.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "File Name";
            // 
            // boxAsyncFileName
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.boxAsyncFileName, 4);
            this.boxAsyncFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxAsyncFileName.Location = new System.Drawing.Point(3, 16);
            this.boxAsyncFileName.Name = "boxAsyncFileName";
            this.boxAsyncFileName.Size = new System.Drawing.Size(507, 20);
            this.boxAsyncFileName.TabIndex = 12;
            this.boxAsyncFileName.Text = "..\\data\\remote\\SLKRVXFM010101HD1.jpg";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "Data Service";
            // 
            // boxAsyncDataService
            // 
            this.boxAsyncDataService.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxAsyncDataService.Location = new System.Drawing.Point(3, 55);
            this.boxAsyncDataService.Name = "boxAsyncDataService";
            this.boxAsyncDataService.Size = new System.Drawing.Size(122, 20);
            this.boxAsyncDataService.TabIndex = 14;
            this.boxAsyncDataService.Text = "SLHD1";
            // 
            // btnAsyncSend
            // 
            this.btnAsyncSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsyncSend.Location = new System.Drawing.Point(435, 55);
            this.btnAsyncSend.Name = "btnAsyncSend";
            this.btnAsyncSend.Size = new System.Drawing.Size(75, 23);
            this.btnAsyncSend.TabIndex = 3;
            this.btnAsyncSend.Text = "Send";
            this.btnAsyncSend.UseVisualStyleBackColor = true;
            this.btnAsyncSend.Click += new System.EventHandler(this.btnAsyncSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 555);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxSyncDuration)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDirectFileUpload;
        private System.Windows.Forms.TextBox boxDirectUploadName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox boxXhdrAction;
        private System.Windows.Forms.ComboBox boxXhdrMime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSyncSend;
        private System.Windows.Forms.NumericUpDown boxSyncDuration;
        private System.Windows.Forms.DateTimePicker boxSyncTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox boxSyncLotId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker boxSyncExpiry;
        private System.Windows.Forms.TextBox boxSyncFilename;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox boxSyncDataService;
        private System.Windows.Forms.CheckBox boxSyncActive;
        private System.Windows.Forms.CheckBox boxSyncCancelPrior;
        private System.Windows.Forms.Button btnSyncSetTime;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox boxAsyncLotId;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox boxAsyncFileName;
        private System.Windows.Forms.TextBox boxAsyncDataService;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnAsyncSend;
    }
}


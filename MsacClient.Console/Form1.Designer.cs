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
            ((System.ComponentModel.ISupportInitialize)(this.connectPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.corePanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.btnSendPSD.Location = new System.Drawing.Point(452, 134);
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
            this.groupBox1.Size = new System.Drawing.Size(536, 179);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 160);
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
            this.boxTitle.Size = new System.Drawing.Size(259, 20);
            this.boxTitle.TabIndex = 1;
            this.boxTitle.Text = "KRVX-FM";
            // 
            // boxArtist
            // 
            this.boxArtist.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxArtist.Location = new System.Drawing.Point(268, 16);
            this.boxArtist.Name = "boxArtist";
            this.boxArtist.Size = new System.Drawing.Size(259, 20);
            this.boxArtist.TabIndex = 2;
            this.boxArtist.Text = "103.1 The Raven";
            // 
            // boxAlbum
            // 
            this.boxAlbum.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxAlbum.Location = new System.Drawing.Point(3, 55);
            this.boxAlbum.Name = "boxAlbum";
            this.boxAlbum.Size = new System.Drawing.Size(259, 20);
            this.boxAlbum.TabIndex = 3;
            // 
            // boxGenre
            // 
            this.boxGenre.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxGenre.Location = new System.Drawing.Point(268, 55);
            this.boxGenre.Name = "boxGenre";
            this.boxGenre.Size = new System.Drawing.Size(259, 20);
            this.boxGenre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 0);
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
            this.label4.Location = new System.Drawing.Point(268, 39);
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
            this.boxPsdPgm.Size = new System.Drawing.Size(259, 21);
            this.boxPsdPgm.TabIndex = 10;
            this.boxPsdPgm.Text = "HD1";
            // 
            // corePanel
            // 
            this.corePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox2.Size = new System.Drawing.Size(536, 87);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(530, 68);
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
            this.btnDirectFileUpload.Location = new System.Drawing.Point(452, 42);
            this.btnDirectFileUpload.Name = "btnDirectFileUpload";
            this.btnDirectFileUpload.Size = new System.Drawing.Size(75, 23);
            this.btnDirectFileUpload.TabIndex = 3;
            this.btnDirectFileUpload.Text = "Upload...";
            this.btnDirectFileUpload.UseVisualStyleBackColor = true;
            this.btnDirectFileUpload.Click += new System.EventHandler(this.btnDirectFileUpload_Click);
            // 
            // boxDirectUploadName
            // 
            this.boxDirectUploadName.Dock = System.Windows.Forms.DockStyle.Top;
            this.boxDirectUploadName.Location = new System.Drawing.Point(3, 16);
            this.boxDirectUploadName.Name = "boxDirectUploadName";
            this.boxDirectUploadName.Size = new System.Drawing.Size(259, 20);
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
            this.label8.Location = new System.Drawing.Point(268, 78);
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
            this.boxXhdrAction.Size = new System.Drawing.Size(259, 21);
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
            this.boxXhdrMime.Location = new System.Drawing.Point(268, 94);
            this.boxXhdrMime.Name = "boxXhdrMime";
            this.boxXhdrMime.Size = new System.Drawing.Size(259, 21);
            this.boxXhdrMime.TabIndex = 15;
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
    }
}


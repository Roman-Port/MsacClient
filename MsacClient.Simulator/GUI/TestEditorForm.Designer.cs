namespace MsacClient.Simulator.GUI
{
    partial class TestEditorForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.fieldFloatingJitter = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fieldErrorDelay = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fieldImageLifespan = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldLabel = new System.Windows.Forms.TextBox();
            this.fieldImagePreNotify = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.fieldEpoch = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timelinePanel = new System.Windows.Forms.Panel();
            this.btnAddTimelineEvent = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldFloatingJitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldErrorDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldImageLifespan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldImagePreNotify)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Core Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.fieldFloatingJitter, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.fieldErrorDelay, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.fieldImageLifespan, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fieldLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.fieldImagePreNotify, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fieldEpoch, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 162);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(6, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 26);
            this.label10.TabIndex = 14;
            this.label10.Text = "Epoch";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(6, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 26);
            this.label9.TabIndex = 13;
            this.label9.Text = "Floating Jitter";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fieldFloatingJitter
            // 
            this.fieldFloatingJitter.DecimalPlaces = 2;
            this.fieldFloatingJitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldFloatingJitter.Location = new System.Drawing.Point(97, 136);
            this.fieldFloatingJitter.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.fieldFloatingJitter.Name = "fieldFloatingJitter";
            this.fieldFloatingJitter.Size = new System.Drawing.Size(102, 20);
            this.fieldFloatingJitter.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(205, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 26);
            this.label8.TabIndex = 11;
            this.label8.Text = "sec";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(6, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 26);
            this.label7.TabIndex = 10;
            this.label7.Text = "Error Delay";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fieldErrorDelay
            // 
            this.fieldErrorDelay.DecimalPlaces = 2;
            this.fieldErrorDelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldErrorDelay.Location = new System.Drawing.Point(97, 110);
            this.fieldErrorDelay.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.fieldErrorDelay.Name = "fieldErrorDelay";
            this.fieldErrorDelay.Size = new System.Drawing.Size(102, 20);
            this.fieldErrorDelay.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(205, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "min";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(205, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "min";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fieldImageLifespan
            // 
            this.fieldImageLifespan.DecimalPlaces = 2;
            this.fieldImageLifespan.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldImageLifespan.Location = new System.Drawing.Point(97, 84);
            this.fieldImageLifespan.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.fieldImageLifespan.Name = "fieldImageLifespan";
            this.fieldImageLifespan.Size = new System.Drawing.Size(102, 20);
            this.fieldImageLifespan.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Image Lifespan";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image Pre-Notify";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fieldLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.fieldLabel, 2);
            this.fieldLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldLabel.Location = new System.Drawing.Point(97, 6);
            this.fieldLabel.Name = "fieldLabel";
            this.fieldLabel.Size = new System.Drawing.Size(132, 20);
            this.fieldLabel.TabIndex = 1;
            // 
            // fieldImagePreNotify
            // 
            this.fieldImagePreNotify.DecimalPlaces = 2;
            this.fieldImagePreNotify.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldImagePreNotify.Location = new System.Drawing.Point(97, 58);
            this.fieldImagePreNotify.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.fieldImagePreNotify.Name = "fieldImagePreNotify";
            this.fieldImagePreNotify.Size = new System.Drawing.Size(102, 20);
            this.fieldImagePreNotify.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(205, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "min";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fieldEpoch
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.fieldEpoch, 2);
            this.fieldEpoch.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldEpoch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fieldEpoch.Location = new System.Drawing.Point(97, 32);
            this.fieldEpoch.Name = "fieldEpoch";
            this.fieldEpoch.Size = new System.Drawing.Size(132, 20);
            this.fieldEpoch.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddTimelineEvent);
            this.groupBox2.Controls.Add(this.timelinePanel);
            this.groupBox2.Location = new System.Drawing.Point(259, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 368);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timeline";
            // 
            // timelinePanel
            // 
            this.timelinePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timelinePanel.AutoScroll = true;
            this.timelinePanel.Location = new System.Drawing.Point(6, 19);
            this.timelinePanel.Name = "timelinePanel";
            this.timelinePanel.Size = new System.Drawing.Size(517, 314);
            this.timelinePanel.TabIndex = 0;
            // 
            // btnAddTimelineEvent
            // 
            this.btnAddTimelineEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTimelineEvent.Location = new System.Drawing.Point(448, 339);
            this.btnAddTimelineEvent.Name = "btnAddTimelineEvent";
            this.btnAddTimelineEvent.Size = new System.Drawing.Size(75, 23);
            this.btnAddTimelineEvent.TabIndex = 1;
            this.btnAddTimelineEvent.Text = "Add...";
            this.btnAddTimelineEvent.UseVisualStyleBackColor = true;
            this.btnAddTimelineEvent.Click += new System.EventHandler(this.btnAddTimelineEvent_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 426);
            this.panel1.TabIndex = 2;
            // 
            // btnSimulate
            // 
            this.btnSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulate.Location = new System.Drawing.Point(713, 419);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(75, 23);
            this.btnSimulate.TabIndex = 3;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // TestEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Name = "TestEditorForm";
            this.Text = "TestEditorForm";
            this.Load += new System.EventHandler(this.TestEditorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldFloatingJitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldErrorDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldImageLifespan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldImagePreNotify)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fieldLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown fieldImagePreNotify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown fieldImageLifespan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown fieldErrorDelay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown fieldFloatingJitter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker fieldEpoch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddTimelineEvent;
        private System.Windows.Forms.Panel timelinePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSimulate;
    }
}
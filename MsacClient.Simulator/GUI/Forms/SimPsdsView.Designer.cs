namespace MsacClient.Simulator.GUI.Forms
{
    partial class SimPsdsView
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
            this.mainTable = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainTable)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.AllowUserToAddRows = false;
            this.mainTable.AllowUserToDeleteRows = false;
            this.mainTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.timeIn,
            this.durationIn,
            this.time,
            this.duration,
            this.text,
            this.lotId});
            this.mainTable.Location = new System.Drawing.Point(12, 12);
            this.mainTable.Name = "mainTable";
            this.mainTable.ReadOnly = true;
            this.mainTable.RowHeadersVisible = false;
            this.mainTable.Size = new System.Drawing.Size(776, 426);
            this.mainTable.TabIndex = 0;
            // 
            // index
            // 
            this.index.DataPropertyName = "Index";
            this.index.HeaderText = "#";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            this.index.Width = 30;
            // 
            // timeIn
            // 
            this.timeIn.DataPropertyName = "StartTimeIn";
            this.timeIn.HeaderText = "Time (in)";
            this.timeIn.Name = "timeIn";
            this.timeIn.ReadOnly = true;
            // 
            // durationIn
            // 
            this.durationIn.DataPropertyName = "DurationIn";
            this.durationIn.HeaderText = "Duration (in)";
            this.durationIn.Name = "durationIn";
            this.durationIn.ReadOnly = true;
            // 
            // time
            // 
            this.time.DataPropertyName = "StartTimeOut";
            this.time.HeaderText = "Time (sim)";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // duration
            // 
            this.duration.DataPropertyName = "DurationOut";
            this.duration.HeaderText = "Duration (sim)";
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            // 
            // text
            // 
            this.text.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.text.DataPropertyName = "Text";
            this.text.HeaderText = "Text";
            this.text.Name = "text";
            this.text.ReadOnly = true;
            // 
            // lotId
            // 
            this.lotId.DataPropertyName = "LotId";
            this.lotId.HeaderText = "Lot ID";
            this.lotId.Name = "lotId";
            this.lotId.ReadOnly = true;
            // 
            // SimPsdsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTable);
            this.Name = "SimPsdsView";
            this.Text = "SimPsdsView";
            this.Load += new System.EventHandler(this.SimPsdsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView mainTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn text;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotId;
    }
}
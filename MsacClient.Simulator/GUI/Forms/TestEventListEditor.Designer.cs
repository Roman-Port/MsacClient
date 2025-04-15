namespace MsacClient.Simulator.GUI.Forms
{
    partial class TestEventListEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.fieldComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timelineGrid = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.columnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnImageFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldTime = new MsacClient.Simulator.GUI.Controls.TimeEntryBox();
            ((System.ComponentModel.ISupportInitialize)(this.timelineGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comment";
            // 
            // fieldComment
            // 
            this.fieldComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldComment.Location = new System.Drawing.Point(12, 29);
            this.fieldComment.Name = "fieldComment";
            this.fieldComment.Size = new System.Drawing.Size(395, 20);
            this.fieldComment.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time";
            // 
            // timelineGrid
            // 
            this.timelineGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timelineGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnComment,
            this.columnStart,
            this.columnLength,
            this.columnImageFile});
            this.timelineGrid.Location = new System.Drawing.Point(12, 55);
            this.timelineGrid.Name = "timelineGrid";
            this.timelineGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.timelineGrid.Size = new System.Drawing.Size(528, 354);
            this.timelineGrid.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(465, 415);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // columnComment
            // 
            this.columnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnComment.HeaderText = "Comment";
            this.columnComment.Name = "columnComment";
            // 
            // columnStart
            // 
            this.columnStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnStart.HeaderText = "Start Time";
            this.columnStart.Name = "columnStart";
            // 
            // columnLength
            // 
            this.columnLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnLength.HeaderText = "Length";
            this.columnLength.Name = "columnLength";
            // 
            // columnImageFile
            // 
            this.columnImageFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnImageFile.HeaderText = "Virtual Filename";
            this.columnImageFile.Name = "columnImageFile";
            // 
            // fieldTime
            // 
            this.fieldTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldTime.Location = new System.Drawing.Point(413, 29);
            this.fieldTime.Mask = "00:00:00:00 sec";
            this.fieldTime.Name = "fieldTime";
            this.fieldTime.Size = new System.Drawing.Size(127, 20);
            this.fieldTime.TabIndex = 3;
            this.fieldTime.Text = "00000000";
            this.fieldTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.fieldTime.ValueTime = System.TimeSpan.Parse("00:00:00");
            // 
            // TestEventListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 450);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.timelineGrid);
            this.Controls.Add(this.fieldTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fieldComment);
            this.Controls.Add(this.label1);
            this.Name = "TestEventListEditor";
            this.Text = "Edit Event List";
            this.Load += new System.EventHandler(this.TestEventListEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timelineGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fieldComment;
        private System.Windows.Forms.Label label2;
        private Controls.TimeEntryBox fieldTime;
        private System.Windows.Forms.DataGridView timelineGrid;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnImageFile;
    }
}
namespace MsacClient.Simulator.GUI.Controls
{
    partial class TestEditorTimelineEvent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fieldComment = new System.Windows.Forms.Label();
            this.fieldInfo = new System.Windows.Forms.Label();
            this.timeline = new MsacClient.Simulator.GUI.Controls.SimEventPreviewControl();
            this.SuspendLayout();
            // 
            // fieldComment
            // 
            this.fieldComment.Location = new System.Drawing.Point(3, 0);
            this.fieldComment.Name = "fieldComment";
            this.fieldComment.Size = new System.Drawing.Size(371, 20);
            this.fieldComment.TabIndex = 0;
            this.fieldComment.Text = "label1";
            this.fieldComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fieldInfo
            // 
            this.fieldInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldInfo.Location = new System.Drawing.Point(380, 0);
            this.fieldInfo.Name = "fieldInfo";
            this.fieldInfo.Size = new System.Drawing.Size(193, 20);
            this.fieldInfo.TabIndex = 3;
            this.fieldInfo.Text = "label1";
            this.fieldInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeline
            // 
            this.timeline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeline.BackColor = System.Drawing.SystemColors.ControlLight;
            this.timeline.Enabled = false;
            this.timeline.FillColor = System.Drawing.Color.Red;
            this.timeline.Start = System.TimeSpan.Parse("00:00:00");
            this.timeline.GraphMargins = new System.Windows.Forms.Padding(0);
            this.timeline.End = System.TimeSpan.Parse("00:01:30");
            this.timeline.Location = new System.Drawing.Point(0, 23);
            this.timeline.Name = "timeline";
            this.timeline.SimEvents = new MsacClient.Simulator.Simulator.Settings.MsacSimEvent[0];
            this.timeline.Size = new System.Drawing.Size(573, 28);
            this.timeline.TabIndex = 2;
            this.timeline.Text = "simEventPreviewControl1";
            // 
            // TestEditorTimelineEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fieldInfo);
            this.Controls.Add(this.timeline);
            this.Controls.Add(this.fieldComment);
            this.Name = "TestEditorTimelineEvent";
            this.Size = new System.Drawing.Size(573, 51);
            this.ResumeLayout(false);

        }

        #endregion
        private SimEventPreviewControl timeline;
        public System.Windows.Forms.Label fieldComment;
        public System.Windows.Forms.Label fieldInfo;
    }
}

namespace MsacClient.Simulator.GUI.Forms
{
    partial class SimulatorRunnerForm
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
            this.graph = new MsacClient.Simulator.GUI.Controls.SimResultsGraphControl();
            this.passFailLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSDListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph.Data = null;
            this.graph.End = System.TimeSpan.Parse("00:01:30");
            this.graph.Epoch = new System.DateTime(((long)(0)));
            this.graph.GraphMargins = new System.Windows.Forms.Padding(0);
            this.graph.Location = new System.Drawing.Point(12, 61);
            this.graph.MaxTime = System.TimeSpan.Parse("00:00:00");
            this.graph.MinTime = System.TimeSpan.Parse("00:00:00");
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(776, 377);
            this.graph.Start = System.TimeSpan.Parse("00:00:00");
            this.graph.TabIndex = 0;
            this.graph.Text = "Preparing...";
            this.graph.UserScrollable = true;
            // 
            // passFailLabel
            // 
            this.passFailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passFailLabel.BackColor = System.Drawing.Color.Yellow;
            this.passFailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passFailLabel.Location = new System.Drawing.Point(12, 24);
            this.passFailLabel.Name = "passFailLabel";
            this.passFailLabel.Size = new System.Drawing.Size(776, 34);
            this.passFailLabel.TabIndex = 1;
            this.passFailLabel.Text = "PROCESSING";
            this.passFailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pSDListToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // pSDListToolStripMenuItem
            // 
            this.pSDListToolStripMenuItem.Enabled = false;
            this.pSDListToolStripMenuItem.Name = "pSDListToolStripMenuItem";
            this.pSDListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pSDListToolStripMenuItem.Text = "PSD List";
            this.pSDListToolStripMenuItem.Click += new System.EventHandler(this.pSDListToolStripMenuItem_Click);
            // 
            // SimulatorRunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.passFailLabel);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SimulatorRunnerForm";
            this.Text = "SimulatorRunnerForm";
            this.Load += new System.EventHandler(this.SimulatorRunnerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.SimResultsGraphControl graph;
        private System.Windows.Forms.Label passFailLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSDListToolStripMenuItem;
    }
}
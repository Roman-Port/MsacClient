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
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.Data = null;
            this.graph.End = System.TimeSpan.Parse("00:01:30");
            this.graph.Epoch = new System.DateTime(((long)(0)));
            this.graph.GraphMargins = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.graph.Location = new System.Drawing.Point(12, 12);
            this.graph.MaxTime = System.TimeSpan.Parse("00:00:00");
            this.graph.MinTime = System.TimeSpan.Parse("00:00:00");
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(776, 426);
            this.graph.Start = System.TimeSpan.Parse("00:00:00");
            this.graph.TabIndex = 0;
            this.graph.Text = "Preparing...";
            // 
            // SimulatorRunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.graph);
            this.Name = "SimulatorRunnerForm";
            this.Text = "SimulatorRunnerForm";
            this.Load += new System.EventHandler(this.SimulatorRunnerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SimResultsGraphControl graph;
    }
}
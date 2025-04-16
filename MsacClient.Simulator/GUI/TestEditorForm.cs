using MsacClient.Simulator.GUI.Controls;
using MsacClient.Simulator.GUI.Forms;
using MsacClient.Simulator.Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Simulator.GUI
{
    public partial class TestEditorForm : Form
    {
        public TestEditorForm(MsacSimTest info)
        {
            this.info = info;
            InitializeComponent();
        }

        private readonly MsacSimTest info;

        private void RefreshTimeline()
        {
            //Enumerate events to find the last one
            TimeSpan last = TimeSpan.Zero;
            foreach (var t in info.Timeline)
            {
                foreach (var e in t.Events)
                {
                    if (e.End > last)
                        last = e.End;
                }
            }

            //Clear and refresh list
            timelinePanel.SuspendLayout();
            timelinePanel.Controls.Clear();
            foreach (var t in info.Timeline.OrderByDescending(x => x.Time))
            {
                TestEditorTimelineEvent ctrl = new TestEditorTimelineEvent
                {
                    CommentText = t.Comment,
                    InfoText = t.Time.ToString(),
                    Dock = DockStyle.Top,
                    Cursor = Cursors.Hand
                };
                ctrl.Timeline.End = last;
                ctrl.Timeline.SimEvents = t.Events.ToArray();
                ctrl.Tag = t;
                ctrl.Click += TimelineItemClick;
                ctrl.fieldComment.Click += TimelineItemClick;
                ctrl.fieldComment.Tag = t;
                ctrl.fieldInfo.Click += TimelineItemClick;
                ctrl.fieldInfo.Tag = t;
                timelinePanel.Controls.Add(ctrl);
            }
            timelinePanel.ResumeLayout();
        }

        private void TimelineItemClick(object sender, EventArgs e)
        {
            //Get info
            Control control = (Control)sender;
            MsacSimEventList item = (MsacSimEventList)control.Tag;

            //Show editor
            if (new TestEventListEditor(item).ShowDialog() != DialogResult.OK)
                return;

            //Refresh
            RefreshTimeline();
        }

        private void TestEditorForm_Load(object sender, EventArgs e)
        {
            //Initialize timeline list
            RefreshTimeline();
        }

        private void btnAddTimelineEvent_Click(object sender, EventArgs e)
        {
            //Show new dialog
            MsacSimEventList tl = new MsacSimEventList();
            if (new TestEventListEditor(tl).ShowDialog() != DialogResult.OK)
                return;

            //Add and refresh
            info.Timeline.Add(tl);
            RefreshTimeline();
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            new SimulatorRunnerForm(info).ShowDialog();
        }
    }
}

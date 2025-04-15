using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsacClient.Simulator.GUI.Controls
{
    public partial class TestEditorTimelineEvent : UserControl
    {
        public TestEditorTimelineEvent()
        {
            InitializeComponent();
        }

        public string CommentText
        {
            get => fieldComment.Text;
            set => fieldComment.Text = value;
        }

        public string InfoText
        {
            get => fieldInfo.Text;
            set => fieldInfo.Text = value;
        }

        public SimEventPreviewControl Timeline => timeline;
    }
}

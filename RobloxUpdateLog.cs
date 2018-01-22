using System;
using System.Windows.Forms;

namespace RobloxVersionMonitor
{
    public partial class RobloxUpdateLog : Form
    {
        public RobloxUpdateLog(string logs)
        {
            InitializeComponent();
            log.Text = logs;
        }

        private void dismiss_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

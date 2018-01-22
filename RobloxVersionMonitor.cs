using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobloxVersionMonitor
{
    public partial class RobloxVersionMonitor : Form
    {
        private Dictionary<string,List<RobloxDeployLog>> previousLogs = null;
        private Dictionary<string,List<RobloxDeployLog>> currentLogs = null;
        private static string[] branches = new string[] { "roblox", "gametest1.robloxlabs", "gametest2.robloxlabs" };

        public RobloxVersionMonitor()
        {
            InitializeComponent();
        }

        private void updateStatusPage(TabPage page)
        {
            string branch = page.ToolTipText;
            List<RobloxDeployLog> deployLogs = currentLogs[branch];
            Label statusLbl = (Label)page.Controls[branch + "_Status"];

            string newText = "Version Deploy Info:\n\n";
            foreach (RobloxDeployType deployType in Enum.GetValues(typeof(RobloxDeployType)))
            {
                RobloxDeployLog latest = deployLogs.Where(log => log.DeployType == deployType).Last();
                string[] lines = new string[]
                {
                    " Latest " + deployType.ToString() + ":",
                    "    Version: " + latest.VersionInfo,
                    "    GUID:    " + latest.VersionGuid,
                    "    Updated: " + latest.DeployTime
                };
                newText += string.Join("\n", lines) + "\n\n";
            }

            statusLbl.Text = newText;
        }

        private void updateHistoryPage(TabPage page)
        {
            string branch = page.ToolTipText;
            List<RobloxDeployLog> deployLogs = currentLogs[branch];
            TreeView tree = (TreeView)page.Controls[branch + "_Tree"];

            foreach (RobloxDeployType deployType in Enum.GetValues(typeof(RobloxDeployType)))
            {
                RobloxDeployLog[] deployTypedLogs = deployLogs
                    .Where(log => log.DeployType == deployType)
                    .Reverse()
                    .ToArray();

                string type = deployType.ToString();
                TreeNode root = tree.Nodes[type];
                if (root == null)
                    root = tree.Nodes.Add(type, type);

                foreach (RobloxDeployLog deployLog in deployTypedLogs)
                {
                    RobloxVersionInfo info = deployLog.VersionInfo;
                    string name = deployLog.DeployTime.ToString("MM/dd/yyyy hh:mm:ss tt");
                    TreeNode logNode = root.Nodes[name];
                    if (logNode == null)
                    {
                        logNode = root.Nodes.Add(name, name);
                        logNode.Nodes.Add("Deploy Log:   " + deployLog.SourceLog);

                        TreeNode versionNode = 
                        logNode.Nodes.Add("Version Info: " + info.ToString());

                        if (info.Available)
                        {
                            versionNode.Nodes.Add("Generation: " + info.Generation);
                            versionNode.Nodes.Add("Version:    " + info.Version);
                            versionNode.Nodes.Add("Patch:      " + info.Patch);
                            versionNode.Nodes.Add("Commit:     " + info.Commit);
                        }

                        logNode.Nodes.Add("GUID:         " + deployLog.VersionGuid);
                        logNode.Nodes.Add("Deploy Time:  " + name);
                        
                    }
                }
            }
        }

        private async void updateLogs(object sender = null, EventArgs e = null)
        {
            Text = "(Refreshing)";
            UseWaitCursor = true;

            previousLogs = currentLogs;
            currentLogs = new Dictionary<string, List<RobloxDeployLog>>();

            List<string> newLogs = new List<string>();

            foreach (string branch in branches)
            {
                currentLogs[branch] = await RobloxDeployLog.CollectDeployLogs(branch);
                if (previousLogs != null && previousLogs[branch].GetHashCode() != currentLogs[branch].GetHashCode())
                {
                    currentLogs[branch]
                        .Where(log => !previousLogs[branch].Contains(log))
                        .Select(log => log.SourceLog)
                        .ToList()
                        .ForEach(log => { newLogs.Add("[" + branch + "] " + log); });
                }
            }

            if (newLogs.Count > 0)
            {
                updateNotifier.Tag = string.Join("\n", newLogs.ToArray());
                updateNotifier.ShowBalloonTip(10000);
            }

            foreach (TabPage page in statusTabControl.TabPages)
                updateStatusPage(page);

            foreach (TabPage page in historyTabControl.TabPages)
                updateHistoryPage(page);

            UseWaitCursor = false;
            Text = "Roblox Version Monitor";
        }

        private void RobloxVersionMonitor_Load(object sender, EventArgs e)
        {
            Font baseFont = new Font("Consolas", 8.25f, FontStyle.Regular);

            foreach (TabPage page in statusTabControl.TabPages)
            {
                string branch = page.ToolTipText;
                Label label = new Label();
                label.Name = branch + "_Status";
                label.Text = "Loading Status...";
                label.AutoSize = true;
                label.Font = baseFont;
                page.Controls.Add(label);
                page.AutoScroll = true;
            }

            foreach (TabPage page in historyTabControl.TabPages)
            {
                string branch = page.ToolTipText;
                TreeView tree = new TreeView();
                tree.Name = branch + "_Tree";
                tree.Dock = DockStyle.Fill;
                tree.Font = baseFont;
                page.Controls.Add(tree);
                page.AutoScroll = true;
            }

            // Uncomment this to debug notifications.
            //currentLogs = new Dictionary<string, List<RobloxDeployLog>>();
            //foreach (string branch in branches)
            //    currentLogs[branch] = new List<RobloxDeployLog>();

            Timer timer = new Timer { Interval = 30000 };
            timer.Tick += new EventHandler(updateLogs);
            timer.Start();

            updateLogs();
        }

        private void updateNotifier_BalloonTipClicked(object sender, EventArgs e)
        {
            string logs = updateNotifier.Tag.ToString();
            RobloxUpdateLog updateLog = new RobloxUpdateLog(logs);
            updateLog.Show();
            updateLog.BringToFront();
        }
    }
}

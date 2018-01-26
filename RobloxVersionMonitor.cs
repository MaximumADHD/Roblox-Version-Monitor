using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;

namespace RobloxVersionMonitor
{
    public struct RobloxDeployLogBranch
    {
        public List<RobloxDeployLog> Logs;
        public string Name;
        public string Source;
        public bool Dirty;
        public bool Initialized;
        public TabPage StatusPage;
        public Label StatusLabel;
        public TabPage HistoryPage;
        public TreeView HistoryTree;
    }

    public partial class RobloxVersionMonitor : Form
    {
        private Dictionary<string, RobloxDeployLogBranch> currentLogs;
        private static string[] branches = new string[] { "roblox", "gametest1.robloxlabs", "gametest2.robloxlabs" };

        public RobloxVersionMonitor()
        {
            InitializeComponent();
        }

        private void UpdateStatusPage(RobloxDeployLogBranch deployBranch)
        {
            string branch = deployBranch.Name;
            List<RobloxDeployLog> deployLogs = deployBranch.Logs;
            TabPage page = deployBranch.StatusPage;

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

        private void UpdateHistoryPage(RobloxDeployLogBranch deployBranch)
        {
            string branch = deployBranch.Name;
            List<RobloxDeployLog> deployLogs = deployBranch.Logs;
            TabPage page = deployBranch.HistoryPage;
            TreeView tree = (TreeView)page.Controls[branch + "_Tree"];

            foreach (RobloxDeployType deployType in Enum.GetValues(typeof(RobloxDeployType)))
            {
                List<RobloxDeployLog> deployTypedLogs = deployLogs
                    .Where(log => log.DeployType == deployType)
                    .ToList();

                deployTypedLogs.Sort();

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
                        logNode = root.Nodes.Insert(0, name, name);

                        TreeNode versionNode =
                        logNode.Nodes.Add("Version Info: " + info.ToString());

                        if (info.Available)
                        {
                            versionNode.Nodes.Add("Generation: " + info.Generation);
                            versionNode.Nodes.Add("Version:    " + info.Version);
                            versionNode.Nodes.Add("Patch:      " + info.Patch);
                            versionNode.Nodes.Add("Commit:     " + info.Commit);
                        }

                        logNode.Nodes.Add("Deploy Log:   " + deployLog.SourceLog);
                        logNode.Nodes.Add("GUID:         " + deployLog.VersionGuid);
                        logNode.Nodes.Add("Deploy Time:  " + name);
                    }
                }
            }
        }

        private async void UpdateLogs(object sender = null, EventArgs e = null)
        {
            Text = "(Refreshing)";
            UseWaitCursor = true;
            await Task.Delay(500);

            List<string> newLogs = new List<string>();
            RegistryKey savedLogs = Program.OpenSubKey("LogHistory");

            foreach (string branchName in branches)
            {
                RobloxDeployLogBranch branch = currentLogs[branchName];
                List<string> newBranchLogs = await RobloxDeployLog.UpdateDeployLogs(branch);
                if (newBranchLogs.Count > 0)
                {
                    string prefix = "[" + branch.Name + "] ";
                    newBranchLogs.ForEach(log => { newLogs.Add(prefix + log); });

                    branch.Source = string.Join("\n", newBranchLogs.ToArray());
                    savedLogs.SetValue(branch.Name, branch.Source);
                }

                if (branch.Dirty)
                {
                    UpdateStatusPage(branch);
                    UpdateHistoryPage(branch);
                    branch.Dirty = false;
                }
            }

            if (newLogs.Count > 0)
            {
                updateNotifier.Tag = string.Join("\n", newLogs.ToArray());
                updateNotifier.ShowBalloonTip(10000);
            }

            Text = "Roblox Version Monitor";
            UseWaitCursor = false;
        }

        private void RobloxVersionMonitor_Load(object sender, EventArgs e)
        {
            RegistryKey savedLogs = Program.OpenSubKey("LogHistory");
            Font baseFont = new Font("Consolas", 8.25f, FontStyle.Regular);
            currentLogs = new Dictionary<string, RobloxDeployLogBranch>();

            foreach (string branch in branches)
            {
                RobloxDeployLogBranch logBranch = new RobloxDeployLogBranch
                {
                    Name = branch,
                    Source = (string)savedLogs.GetValue(branch, ""),
                    Logs = new List<RobloxDeployLog>(),
                    Dirty = true,
                    StatusPage = new TabPage
                    {
                        Name = branch,
                        Text = branch,
                        AutoScroll = true,
                        Parent = statusTabControl,
                    },
                    StatusLabel = new Label
                    {
                        Name = branch + "_Status",
                        Text = "Loading Status...",
                        AutoSize = true,
                        Font = baseFont,
                    },
                    HistoryPage = new TabPage
                    {
                        Name = branch,
                        Text = branch,
                        AutoScroll = true,
                        Parent = historyTabControl,
                    },
                    HistoryTree = new TreeView
                    {
                        Name = branch + "_Tree",
                        Dock = DockStyle.Fill,
                        Font = baseFont,
                    },
                };

                logBranch.StatusPage.Controls.Add(logBranch.StatusLabel);
                logBranch.HistoryPage.Controls.Add(logBranch.HistoryTree);
                currentLogs[branch] = logBranch;
            }

            Timer timer = new Timer { Interval = 30000 };
            timer.Tick += new EventHandler(UpdateLogs);
            UpdateLogs();

            timer.Start();
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobloxVersionMonitor
{
    public enum RobloxDeployType
    {
        Client_Windows,
        Client_Mac,
        Studio_Windows,
        Studio_Mac,
        Server
    }

    public struct RobloxVersionInfo
    {
        public bool Available;

        public int Generation;
        public int Version;
        public int Patch;
        public int Commit;

        public override string ToString()
        {
            if (Available)
                return string.Join(", ", Generation, Version, Patch, Commit);
            else
                return "N/A";
        }
    }

    public struct RobloxDeployLog : IComparable
    {
        public static string MatchPattern = "New ([A-z]+) (version-[a-f\\d]+) at (\\d+/\\d+/\\d+ \\d+:\\d+:\\d+ [A,P]M)(, file vers?ion: (\\d+), (\\d+), (\\d+), (\\d+))?";

        public string SourceLog;
        public RobloxDeployType DeployType;
        public DateTime DeployTime;
        public string VersionGuid;
        public RobloxVersionInfo VersionInfo;

        public override string ToString()
        {
            string result = DeployTime.ToString("[MM/dd/yyyy hh:mm:ss tt] ") + DeployType.ToString().PadRight(25);
            if (VersionInfo.Available)
                result += VersionInfo.ToString();
            else
                result += VersionGuid;

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(RobloxDeployLog))
            {
                RobloxDeployLog log = (RobloxDeployLog)obj;
                return (VersionGuid == log.VersionGuid);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int CompareTo(object other)
        {
            if (other.GetType() == typeof(RobloxDeployLog))
            {
                RobloxDeployLog otherLog = (RobloxDeployLog)other;
                return DeployTime.CompareTo(otherLog.DeployTime);
            }
            return 0;
        }

        public static void AddDeployLogs(RobloxDeployLogBranch branch, List<string> deployLogs)
        {
            foreach (string log in deployLogs)
            {
                Match match = Regex.Match(log, MatchPattern);
                string[] data = match.Groups.Cast<Group>()  // Cast the groups into an IEnumerable<Group>.
                    .Select(group => group.Value)           // Select the values of the groups
                    .Where(value => value.Length != 0)      // where the values aren't empty strings
                    .ToArray();                             // and cast the values into a string array.

                RobloxDeployLog deployLog = new RobloxDeployLog();
                string deployType = data[1];

                if (Enum.TryParse(deployType, out deployLog.DeployType))
                {
                    deployLog.SourceLog = data[0];
                    deployLog.VersionGuid = data[2];
                    deployLog.DeployTime = DateTime.Parse(data[3], CultureInfo.InvariantCulture);

                    if (data.Length > 4)
                    {
                        RobloxVersionInfo versionInfo = new RobloxVersionInfo { Available = true };
                        int.TryParse(data[5], out versionInfo.Generation);
                        int.TryParse(data[6], out versionInfo.Version);
                        int.TryParse(data[7], out versionInfo.Patch);
                        int.TryParse(data[8], out versionInfo.Commit);

                        deployLog.VersionInfo = versionInfo;
                    }

                    branch.Logs.Add(deployLog);
                }
            }
        }

        public static async Task<List<string>> UpdateDeployLogs(RobloxDeployLogBranch branch)
        {
            string setupUrl = "http://setup." + branch.Name + ".com/";

            // There are two deploy log sources that we have to collect from.
            string deployHistory;
            using (WebClient http = new WebClient())
            {
                string winDeployHistory = await http.DownloadStringTaskAsync(setupUrl + "DeployHistory.txt");
                winDeployHistory = winDeployHistory
                    .Replace("WindowsPlayer", "Client")
                    .Replace("Client", "Client_Windows")
                    .Replace("Studio", "Studio_Windows");

                string macDeployHistory = await http.DownloadStringTaskAsync(setupUrl + "mac/DeployHistory.txt");
                macDeployHistory = macDeployHistory
                    .Replace("Client", "Client_Mac")
                    .Replace("Studio", "Studio_Mac");

                deployHistory = (winDeployHistory + '\n' + macDeployHistory)
                    .Replace("RccService", "Server");
            }

            // Collect strings that match the pattern in the deployHistory.
            MatchCollection matches = Regex.Matches(deployHistory, MatchPattern);

            // Compute the difference between these logs so we only generate the RobloxDeployLogs we need.
            List<string> oldLogs = branch.Source.Split('\n').ToList();
            List<string> newLogs = matches.Cast<Match>().Select(match => match.Value).ToList();
            List<string> diffLogs = newLogs.Where(log => !oldLogs.Contains(log)).ToList();

            if (!branch.Initialized)
            {
                AddDeployLogs(branch, oldLogs);
                branch.Initialized = true;
            }

            // Collect and return the newly collected logs.
            if (diffLogs.Count > 0)
            {
                AddDeployLogs(branch, diffLogs);
                branch.Logs.Sort();
                branch.Dirty = true;
            }

            return diffLogs;
        }
    }
}

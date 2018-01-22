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
            return ToString() == obj.ToString() && obj.GetType() == typeof(RobloxDeployLog);
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

        public static async Task<List<RobloxDeployLog>> CollectDeployLog(string deployHistoryUrl, string platform)
        {
            string deployHistory;
            using (WebClient http = new WebClient())
                deployHistory = await http.DownloadStringTaskAsync(deployHistoryUrl);

            MatchCollection matches = Regex.Matches(deployHistory, MatchPattern);
            List<RobloxDeployLog> deployLogs = new List<RobloxDeployLog>();

            foreach (Match match in matches)
            {
                string[] data = match.Groups.Cast<Group>()  // Cast the groups into an IEnumerable<Group>.
                    .Select(group => group.Value)           // Select the values of the groups
                    .Where(value => value.Length != 0)      // where the values aren't empty strings
                    .ToArray();                             // and cast the values into a string array.

                RobloxDeployLog deployLog = new RobloxDeployLog();
                string deployType = data[1];
                if (deployType == "WindowsPlayer")
                    deployType = "Client";

                if (deployType.ToLower() == "rccservice")
                    deployType = "Server";
                else
                    deployType += '_' + platform;

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

                    deployLogs.Add(deployLog);
                }
            }

            return deployLogs;
        }

        public static async Task<List<RobloxDeployLog>> CollectDeployLogs(string branch)
        {
            string setupUrl = "http://setup." + branch + ".com/";

            // There are two deploy log sources that we have to collect from.
            List<RobloxDeployLog> winDeployLogs = await CollectDeployLog(setupUrl + "DeployHistory.txt", "Windows");
            List<RobloxDeployLog> macDeployLogs = await CollectDeployLog(setupUrl + "mac/DeployHistory.txt", "Mac");

            // Merge them together and sort by date.
            List<RobloxDeployLog> deployLogs = winDeployLogs.Concat(macDeployLogs).ToList();
            deployLogs.Sort();

            return deployLogs;
        }
    }
}

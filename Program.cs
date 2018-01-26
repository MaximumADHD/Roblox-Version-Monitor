using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RobloxVersionMonitor
{
    static class Program
    {
        static RegistryKey CoreReg;

        public static RegistryKey OpenSubKey(RegistryKey key, params string[] path)
        {
            RegistryKey at = key;
            foreach (string part in path)
                at = at.CreateSubKey(part);
            return at;
        }

        public static RegistryKey OpenSubKey(params string[] path)
        {
            return OpenSubKey(CoreReg, path);
        }

        [STAThread]

        static void Main()
        {
            CoreReg = OpenSubKey(Registry.CurrentUser, "Software", "Roblox Version Monitor");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RobloxVersionMonitor());
        }
    }
}

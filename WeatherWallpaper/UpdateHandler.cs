using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace WeatherWallpaper
{
    class UpdateHandler
    {
        /// <summary>
        /// Shows dialog requesting user to update if one is available.
        /// </summary>
        /// <param name="latestVersion"></param>
        /// <returns>isUpToDate</returns>
        public static bool CheckForUpdates(bool ignoreBuildVersion = true)
        {
            // get latest version
            string latestVersion = GetLatestVersion();
            if (latestVersion == "")
                return false;

            // Get local version
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string localVersion = fvi.FileVersion;

            string[] latest = latestVersion.Split('.');
            string[] local = localVersion.Split('.');

            // Compare
            int versionDepth = 4;
            if (ignoreBuildVersion)
                versionDepth = 3;

            bool isUpToDate = true;
            for (int i = 0; i < versionDepth; i++)
            {
                if (isUpToDate)
                {
                    int latestInt = int.Parse(latest[i]);
                    int localInt = int.Parse(local[i]);
                    if (latestInt > localInt)
                    {
                        isUpToDate = false;
                        break;
                    }
                }
            }

            if (!isUpToDate)
            {
                DialogResult r = MessageBox.Show("Would you like to update Weather Wallpaper from v" + localVersion + " to v" + latestVersion + " now?",
                    "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                    Process.Start("Updater.exe");
            }

            return isUpToDate;
        }

        private static string GetLatestVersion()
        {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load("https://raw.githubusercontent.com/RStijn/Weather-Wallpaper/master/Installer/Product.wxs");
                return doc["Wix"]["Product"].Attributes["Version"].InnerText;
            }
            catch
            {
                MessageBox.Show("Could not contact the server to determine the latest version. Check manually or try again later.",
                    "Failed to contact server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}

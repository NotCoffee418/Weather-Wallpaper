using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace WeatherWallpaper
{
    class UpdateHandler
    {
        /// <summary>
        /// Shows dialog requesting user to update if one is available.
        /// </summary>
        /// <param name="latestVersion"></param>
        /// <returns>isUpToDate</returns>
        public static bool CheckForUpdates()
        {
            // todo: get latest version
            string latestVersion = "9.9.9.9";

            // Get local version
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string localVersion = fvi.FileVersion;

            string[] latest = latestVersion.Split('.');
            string[] local = localVersion.Split('.');

            // Compare
            bool isUpToDate = true;
            for (int i = 0; i < 4; i++)
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
                DialogResult r = MessageBox.Show("Would you like to automatically update Weather Wallpaper from v" + localVersion + " to v" + latestVersion + " now?",
                    "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                    Process.Start("Updater.exe");
            }

            return isUpToDate;
        }
    }
}

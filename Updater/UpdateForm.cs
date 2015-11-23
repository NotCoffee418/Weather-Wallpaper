using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;
using Microsoft.Win32;

namespace Updater
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            startDownload();
        }

        string InstallerPath = "";

        private void startDownload()
        {
            // Closing main application
            statusLabel.Text = "Preparing to update";
            CloseOtherRunning();
            InstallerPath = Path.GetTempFileName() + ".msi";
            statusLabel.Text = "Downloading latest version...";
            progressBar1.Style = ProgressBarStyle.Blocks;

            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(
                    new Uri("https://github.com/RStijn/Weather-Wallpaper/blob/master/WeatherWallpaper-installer.msi?raw=true"), 
                    InstallerPath);
            });
            thread.Start();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                int iPercentage = int.Parse(Math.Truncate(percentage).ToString());
                statusLabel.Text = "Downloaded " + iPercentage + "% (" + e.BytesReceived + " of " + e.TotalBytesToReceive + ")";
                progressBar1.Value = iPercentage;
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // install updates
            this.BeginInvoke((MethodInvoker)delegate {
                // Start installer & wait for exit
                statusLabel.Text = "Installing update...";
                progressBar1.Value = 0;
                progressBar1.Style = ProgressBarStyle.Marquee;
                ProcessStartInfo procStart = new ProcessStartInfo("msiexec.exe");
                procStart.Arguments = "/i \""+ InstallerPath + "\" /qr";
                Process p = Process.Start(procStart);
                p.WaitForExit();

                // run installed application & close updater
                statusLabel.Text = "Installation complete!";
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 100;

                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Stijn Raeymaekers\\Weather Wallpaper");
                string installedExe = key.GetValue("installDirectory") + "WeatherWallpaper.exe";
                Process.Start(installedExe);

                Thread.Sleep(1500);
                Environment.Exit(0);
            });
        }
        
        private static void CloseOtherRunning()
        {
            var processes = from proc in Process.GetProcessesByName("WeatherWallpaper")
                            where proc.Id != Process.GetCurrentProcess().Id
                            select proc;
            foreach (var p in processes)
                p.Kill();
        }
    }
}

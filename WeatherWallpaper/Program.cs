using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace WeatherWallpaper
{
    static class Program
    {
        // forms
        public static SettingsForm settingsForm;
        public static PreviewForm previewForm;

        // global vars
        public static string UserDir = GetUserDir();

        private static string GetUserDir()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Stijn Raeymaekers\Weather Wallpaper\";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Start(args);
            }
            catch (Exception e)
            {
                // log error
                using (StreamWriter sw = File.AppendText(Program.UserDir + "error.log"))
                {
                    sw.WriteLine("---\n");
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(e.Message);
                }

                // restart minimized
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "\\WeatherWallpaper.exe";
                startInfo.Arguments = "windowed";
                Process.Start(startInfo);
            }
        }

        private static void Start(string[] args)
        {
            // Close any running process of Weather Wallpaper
            CloseOtherRunning();

            // Start Wallpaper
            Wallpaper wall = new Wallpaper();

            // Prepare for first use
            HandleFirstRun(wall);
            
            // Start application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Background-start some forms
            previewForm = new PreviewForm();

            // Handle args
            bool minimized = false;
            foreach (string arg in args)
            {
                if (arg == "minimized")
                    minimized = true;
            }

            Application.Run(settingsForm = new SettingsForm(wall, minimized));
        }

        private static void CloseOtherRunning()
        {
            var processes = from proc in Process.GetProcessesByName("WeatherWallpaper")
                where proc.Id != Process.GetCurrentProcess().Id select proc;
            foreach (var p in processes)
                p.Kill();
        }

        private static void HandleFirstRun(Wallpaper wall)
        {
            if (!File.Exists(Program.UserDir + "CustomWallpapers\\static.jpg"))// Save original to use as static wallpaper
                wall.SaveOriginalWallpaper();

            if (Properties.Settings.Default.FirstRun)
            {
                // Start with windows
                RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                add.SetValue("Weather Wallpaper", "\"" + Application.ExecutablePath + "\"");

                // Set as saved
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();    
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace WeatherWallpaper
{
    public class Wallpaper
    {
        public Wallpaper()
        {
            StartHandler();
        }

        private System.Timers.Timer timer = new System.Timers.Timer();
        private int realInterval = 60000;            // 1 minute
        private int shortInterval = 1000;            // 1 second
        private string lastWeather = String.Empty;

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public bool Ready = false;

        /// <summary>
        /// Starts setting the correct wallpaper for the current weather
        /// </summary>
        public void StartHandler()
        {
            timer.Interval = shortInterval; // Initial interval, modified to realInterval after that
            timer.Elapsed += SetWallpaper;
            timer.Start();
        }

        internal void SetWallpaper(object sender, ElapsedEventArgs e)
        {
            // Start only when ready
            if (!Ready)
            {
                timer.Interval = shortInterval; // retry sooner when busy
                return;
            }
            else timer.Interval = realInterval;
            Ready = false;
            SetStatusLoading(finished: false);

            // Modify interval after first trigger
            if (timer.Interval == shortInterval)
                timer.Interval = realInterval;

            // Reset timer when manually called
            if (e == null)
            {
                timer.Stop();
                timer.Start();
            }

            // Get Current Weather
            string currentWeather = Weather.GetCurrentWeather();
            lastWeather = currentWeather;

            // Update weather label
            Program.settingsForm.currentWeatherLabel.Invoke((MethodInvoker)
                delegate { Program.settingsForm.currentWeatherLabel.Text = currentWeather; });

            // Set new wallpaper
            Set(GetWallpaper(currentWeather));
            Ready = true;
            SetStatusLoading(finished:true);
        }

        private void SetStatusLoading(bool finished = false)
        {
            Program.settingsForm.currentWeatherLabel.Invoke((MethodInvoker)
                delegate {
                    if (finished)
                    {
                        Program.settingsForm.loadingStatusLabel.Text = "Done";
                        Program.settingsForm.loadingStatusBar.Style = ProgressBarStyle.Blocks;
                    }
                    else
                    {
                        Program.settingsForm.loadingStatusLabel.Text = "Loading...";
                        Program.settingsForm.loadingStatusBar.Style = ProgressBarStyle.Marquee;
                    }
                });
        }

        internal static Image GetWallpaperImage(string weather, bool thumbnail = false, bool preview = false)
        {
            string path = GetWallpaper(weather, thumbnail);
            Stream s = new System.Net.WebClient().OpenRead(path);
            Image img = Image.FromStream(s);
            s.Close();
            
            // Modify for multiscreen
            if (!preview && !thumbnail && weather != "Static")
                img = Multiscreen.ModifyImage(img);

            return img;
        }

        /// <summary>
        /// Returns the correct wallpaper for the weather/license
        /// </summary>
        /// <param name="weather"></param>
        /// <returns>wallpaper</returns>
        internal static string GetWallpaper(string weather, bool thumbnail = false)
        {
            weather = CorrectWeatherName(weather);
            string path = Program.UserDir + "CustomWallpapers\\";

            if (thumbnail && File.Exists(path + weather + "_thumbnail.jpg"))
                return path + weather + "_thumbnail.jpg";
            else if (File.Exists(path + weather + ".jpg"))
                return path+ weather + ".jpg";
            else return GetDefaultWallpaper(weather, thumbnail, nameCorrected:true);
            
        }


        /// <summary>
        /// Returns path to default wallpaper for the weather
        /// </summary>
        /// <param name="weather">weather</param>
        /// <param name="thumbnail">requesting thumbnail?</param>
        /// <param name="nameCorrected">is CorrectWeatherName() called on weather yet?</param>
        /// <returns></returns>
        private static string GetDefaultWallpaper(string weather, bool thumbnail = false, bool nameCorrected = false)
        {
            if (!nameCorrected)
                weather = CorrectWeatherName(weather);

            Image img = GetDefaultWallpaperImage(weather, thumbnail);
            string tempPath = Program.UserDir + "wallpaper.jpg";
            
            if (thumbnail)
            {
                if (!Directory.Exists(Program.UserDir + "DefaultThumbnails"))
                    Directory.CreateDirectory(Program.UserDir + "DefaultThumbnails");
                tempPath = Program.UserDir + "DefaultThumbnails\\" + weather + ".jpg";
            }

            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            return tempPath;
        }

        private static Image GetDefaultWallpaperImage(string weather, bool thumbnail = false, bool preview = false)
        {
            string resource = weather.Replace("-", "_").Replace(" ", "_"); // everything is _ in resources

            if (thumbnail)
                resource += "_thumbnail";

            Image img = (Image)Properties.Resources.ResourceManager.GetObject(resource);
            if (img == null)
                img = Properties.Resources.Unknown;

            if (!thumbnail && !preview)
                img = Multiscreen.ModifyImage(img);


            return img;
        }


        /// <summary>
        /// Returns the filename for the approperiate weather
        /// </summary>
        /// <param name="weather"></param>
        /// <returns></returns>
        private static string CorrectWeatherName(string weather)
        {
            if (weather == "Light Rain" || weather == "Rain Showers")
                weather = "Rain";
            else if (weather == "Mostly Cloudy")
                weather = "Cloudy";
            else if (weather == "Partly Sunny")
                weather = "Partly Cloudy";
            else if (weather == "Mostly Clear")
                weather = "Clear";
            else if (weather == "Mostly Sunny")
                weather = "Sunny";
            else if (weather == "Light Snow")
                weather = "Snow";
            return weather;
        }

        
        public void Set(string path)
        {
            // ensure full path is set
            if (!path.Contains(':'))
                path = AppDomain.CurrentDomain.BaseDirectory + path;

            // Write to registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue(@"WallpaperStyle", 0.ToString()); // allow multiscreen
            key.SetValue(@"TileWallpaper", 1.ToString()); // tile
            
            // Update wallpaper
            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        /// <summary>
        /// Let user set a new wallpaper for the specified weather
        /// </summary>
        /// <param name="weather"></param>
        /// <returns>true if wallpaper has changed</returns>
        internal bool ChangeCustomWallpaper(string weather, string path = "")
        {
            // Let user select picture
            DialogResult result = DialogResult.None;
            if (path == "")
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All Images|*.jpeg;*.png;*.jpg;*.gif;*.bmp";
                result = dialog.ShowDialog(); // Show the dialog.
                path = dialog.FileName;
            }
            else
            {
                string ext = Path.GetExtension(path).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".bmp" || ext == ".png")
                    result = DialogResult.OK;
            }

            // Change wallpaper
            if (result == DialogResult.OK)
            {
                // Save wallpaper to CustomWallpapers
                Stream s = new System.Net.WebClient().OpenRead(path);
                Image img = Image.FromStream(s);
                string tempPath = Program.UserDir + "CustomWallpapers\\" + weather + ".jpg";

                if (!Directory.Exists(Program.UserDir + "CustomWallpapers"))
                    Directory.CreateDirectory(Program.UserDir + "CustomWallpapers");
                img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return true;
            }
            else return false;
        }

        internal void SaveOriginalWallpaper()
        {
            string newPath = Program.UserDir + "CustomWallpapers\\static.jpg";
            if (File.Exists(newPath))
                return; // First run only
            else if (!Directory.Exists(Program.UserDir + "CustomWallpapers"))
                Directory.CreateDirectory(Program.UserDir + "CustomWallpapers");

            // Get path
            string originalPath = "";
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
            {
                originalPath = (string)registryKey.GetValue("Wallpaper");
            }

            // Copy image
            Image img = Properties.Resources.Unknown;
            if (File.Exists(originalPath))
                img = Image.FromFile(originalPath);
            img.Save(newPath);
        }

        internal void Preview(string weather)
        {
            Image img = GetWallpaperImage(weather, preview: true);
            Program.previewForm.LoadNew(img);
        }

        /// <summary>
        /// Lets the wallpaper update after shortInteval from now
        /// </summary>
        internal void QuickUpdate()
        {
            timer.Stop();
            timer.Interval = shortInterval;
            timer.Start();
        }
    }
}

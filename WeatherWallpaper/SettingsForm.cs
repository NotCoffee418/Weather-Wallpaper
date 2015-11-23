using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace WeatherWallpaper
{
    public partial class SettingsForm : Form
    {
        Wallpaper wall = null;
        
        public SettingsForm(Wallpaper _wall, bool minimized)
        {
            InitializeComponent();
            wall = _wall;

            if (minimized)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }

            // Enable dragdrop on pictureboxes
            ((Control)pictureBox_Sunny).AllowDrop = true;
            ((Control)pictureBox_PartlyCloudy).AllowDrop = true;
            ((Control)pictureBox_Cloudy).AllowDrop = true;
            ((Control)pictureBox_Clear).AllowDrop = true;
            ((Control)pictureBox_Rain).AllowDrop = true;
            ((Control)pictureBox_Thunderstorm).AllowDrop = true;
            ((Control)pictureBox_Snow).AllowDrop = true;
            ((Control)pictureBox_Static).AllowDrop = true;

            // Prepare multiscreen
            var screens = Multiscreen.GetScreenInfo();
            foreach (KeyValuePair<string, bool> screen in screens)
                screenListBox.Items.Add(screen.Key, screen.Value);

            // set context menu
            ContextMenu iconMenu = new ContextMenu();
            MenuItem openItem = new MenuItem("Open");
            openItem.Click += IconMenuOpen;
            iconMenu.MenuItems.Add(openItem);
            MenuItem exitItem = new MenuItem("Exit");
            exitItem.Click += IconMenuExit;
            iconMenu.MenuItems.Add(exitItem);
            notifyIcon.ContextMenu = iconMenu;
        }

        #region Location Handlers

        /// <summary>
        /// Lists location names based on user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findLocationButton_Click(object sender, EventArgs e)
        {
            locationComboBox.Items.Clear();

            string[] locations = Weather.FindLocations(locationComboBox.Text);
            foreach (string loc in locations)
                locationComboBox.Items.Add(loc);
            locationComboBox.DroppedDown = true;

            if (locationComboBox.Items.Count > 0)
                locationComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Saves new location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Location = locationComboBox.Items[locationComboBox.SelectedIndex].ToString();
            Properties.Settings.Default.Save();

            wall.QuickUpdate();
        }
        #endregion


        #region Form Handlers
        private void Form1_Shown(object sender, EventArgs e)
        {
            // Set user location
            locationComboBox.Text = Weather.GetUserLocation();

            // load active wallpapers
            LoadSettingWallpapers();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void IconMenuOpen(object sender, EventArgs e)
        {
            Show();
            BringToFront();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }
        private void IconMenuExit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            notifyIcon.ShowBalloonTip(10000);
        }
        #endregion

        internal void ReloadThumbnails()
        {
            pictureBox_Sunny.Image = Wallpaper.GetWallpaperImage("Sunny", thumbnail: true);
            pictureBox_PartlyCloudy.Image = Wallpaper.GetWallpaperImage("Partly Cloudy", thumbnail: true);
            pictureBox_Cloudy.Image = Wallpaper.GetWallpaperImage("Cloudy", thumbnail: true);
            pictureBox_Clear.Image = Wallpaper.GetWallpaperImage("Clear", thumbnail: true);
            pictureBox_Rain.Image = Wallpaper.GetWallpaperImage("Rain", thumbnail: true);
            pictureBox_Thunderstorm.Image = Wallpaper.GetWallpaperImage("T-Storms", thumbnail: true);
            pictureBox_Snow.Image = Wallpaper.GetWallpaperImage("Snow", thumbnail: true);
            pictureBox_Static.Image = Wallpaper.GetWallpaperImage("Static", thumbnail: true);
            wall.QuickUpdate();
        }

        #region Change Buttons
        private void changeButton_Sunny_Click(object sender, EventArgs e)
        {
            if (wall.ChangeCustomWallpaper("Sunny"))
                ReloadThumbnails();
        }

        private void changeButton_PartlyCloudy_Click(object sender, EventArgs e)
        {
            if (wall.ChangeCustomWallpaper("Partly Cloudy"))
                ReloadThumbnails();
        }

        private void changeButton_Cloudy_Click(object sender, EventArgs e)
        {
            if (wall.ChangeCustomWallpaper("Cloudy"))
                ReloadThumbnails();
        }

        private void changeButton_Clear_Click(object sender, EventArgs e)
        {
            if (wall.ChangeCustomWallpaper("Clear"))
                ReloadThumbnails();
        }

        private void changeButton_Rain_Click(object sender, EventArgs e)
        {
            if (wall.ChangeCustomWallpaper("Rain"))
                ReloadThumbnails();
        }

        private void changeButton_Thunderstorm_Click(object sender, EventArgs e)
        {
            if (wall.ChangeCustomWallpaper("T-Storms"))
                ReloadThumbnails();
        }

        private void changeButton_Snow_Click(object sender, EventArgs e)
        {
            if (wall.ChangeCustomWallpaper("Snow"))
                ReloadThumbnails();
        }

        private void changeButton_Static_Click(object sender, EventArgs e)
        {
            if (wall.ChangeCustomWallpaper("Static"))
                ReloadThumbnails();
        }
        #endregion

        #region Picturebox Drag & drop handlers

        private void PictureBoxDragEnter(ref DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
            {
                String[] strGetFormats = e.Data.GetFormats();
                e.Effect = DragDropEffects.None;
            }
        }
        private void PictureBoxDragDrop(string weather, ref DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (wall.ChangeCustomWallpaper(weather, files[0]))
            {
                ReloadThumbnails();
                wall.QuickUpdate();
            }
        }

        private void pictureBox_Sunny_DragEnter(object sender, DragEventArgs e)
        {
            PictureBoxDragEnter(ref e);
        }

        private void pictureBox_PartlyCloudy_DragEnter(object sender, DragEventArgs e)
        {
            PictureBoxDragEnter(ref e);
        }

        private void pictureBox_Cloudy_DragEnter(object sender, DragEventArgs e)
        {
            PictureBoxDragEnter(ref e);
        }

        private void pictureBox_Clear_DragEnter(object sender, DragEventArgs e)
        {
            PictureBoxDragEnter(ref e);
        }

        private void pictureBox_Rain_DragEnter(object sender, DragEventArgs e)
        {
            PictureBoxDragEnter(ref e);
        }

        private void pictureBox_Thunderstorm_DragEnter(object sender, DragEventArgs e)
        {
            PictureBoxDragEnter(ref e);
        }

        private void pictureBox_Snow_DragEnter(object sender, DragEventArgs e)
        {
            PictureBoxDragEnter(ref e);
        }

        private void pictureBox_Static_DragEnter(object sender, DragEventArgs e)
        {
            PictureBoxDragEnter(ref e);
        }

        private void pictureBox_Sunny_DragDrop(object sender, DragEventArgs e)
        {
            PictureBoxDragDrop("Sunny", ref e);
        }

        private void pictureBox_PartlyCloudy_DragDrop(object sender, DragEventArgs e)
        {
            PictureBoxDragDrop("Partly Cloudy", ref e);
        }

        private void pictureBox_Cloudy_DragDrop(object sender, DragEventArgs e)
        {
            PictureBoxDragDrop("Cloudy", ref e);
        }

        private void pictureBox_Clear_DragDrop(object sender, DragEventArgs e)
        {
            PictureBoxDragDrop("Clear", ref e);
        }

        private void pictureBox_Rain_DragDrop(object sender, DragEventArgs e)
        {
            PictureBoxDragDrop("Rain", ref e);
        }

        private void pictureBox_Thunderstorm_DragDrop(object sender, DragEventArgs e)
        {
            PictureBoxDragDrop("T-Storms", ref e);
        }

        private void pictureBox_Snow_DragDrop(object sender, DragEventArgs e)
        {
            PictureBoxDragDrop("Snow", ref e);
        }

        private void pictureBox_Static_DragDrop(object sender, DragEventArgs e)
        {
            PictureBoxDragDrop("Static", ref e);
        }
        #endregion

        #region Wallpaper Previews
        private void pictureBox_Sunny_Click(object sender, EventArgs e)
        {
            wall.Preview("Sunny");
        }

        private void pictureBox_PartlyCloudy_Click(object sender, EventArgs e)
        {
            wall.Preview("Partly Cloudy");
        }

        private void pictureBox_Cloudy_Click(object sender, EventArgs e)
        {
            wall.Preview("Cloudy");
        }

        private void pictureBox_Clear_Click(object sender, EventArgs e)
        {
            wall.Preview("Clear");
        }

        private void pictureBox_Rain_Click(object sender, EventArgs e)
        {
            wall.Preview("Rain");
        }

        private void pictureBox_Thunderstorm_Click(object sender, EventArgs e)
        {
            wall.Preview("T-Storms");
        }

        private void pictureBox_Snow_Click(object sender, EventArgs e)
        {
            wall.Preview("Snow");
        }

        private void pictureBox_Static_Click(object sender, EventArgs e)
        {
            wall.Preview("Static");
        }
        #endregion


        /// <summary>
        /// Only call from different thread
        /// </summary>
        private void LoadSettingWallpapers()
        {
            ReloadThumbnails();
            wall.Ready = true;
        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UpdateHandler.CheckForUpdates())
                MessageBox.Show("You are currently using the latest version of Weather Wallpaper.", "Up to date",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void screenListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> checkedItems = new List<string>();
            foreach (var item in screenListBox.CheckedItems)
                checkedItems.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
                checkedItems.Add(screenListBox.Items[e.Index].ToString());
            else // remove it again
                checkedItems.Remove(screenListBox.Items[e.Index].ToString());

            if (checkedItems.Count > 0)
                Multiscreen.Enabled = true;
            else
                Multiscreen.Enabled = false;

            Properties.Settings.Default.StaticScreens = string.Join(",", checkedItems);
            Properties.Settings.Default.Save();
        }

        private void screenListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wall.QuickUpdate();
        }
    }
}

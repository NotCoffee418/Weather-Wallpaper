using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Drawing;

namespace WeatherWallpaper
{
    class Multiscreen
    {
        public static bool Enabled = false; // Used by Wallpaper to set tiled on/off
        private static List<Display> displays = new List<Display>();

        /// <summary>
        /// Saves screen info when program starts
        /// </summary>
        /// <returns>screen CheckedListbox Items</returns>
        internal static List<KeyValuePair<string, bool>> GetScreenInfo()
        {
            // Gets static screens
            string[] staticScreens = Properties.Settings.Default.StaticScreens.Split(',');

            // Get offset for startX&Y < 0
            int offsetX = 0, offsetY = 0;
            foreach (var screen in Screen.AllScreens)
            {
                if (screen.Bounds.X < offsetX)
                    offsetX = screen.Bounds.X;
                if (screen.Bounds.Y < offsetY)
                    offsetY = screen.Bounds.Y;
            }
            offsetX = Math.Abs(offsetX);
            offsetY = Math.Abs(offsetY);

            // Create displays
            List<KeyValuePair<string, bool>> list = new List<KeyValuePair<string, bool>>();
            foreach (var screen in Screen.AllScreens)
            {
                Display display = new Display();
                display.Name = screen.DeviceName.Replace(@"\\.\", "");
                display.Width = screen.Bounds.Width;
                display.Height = screen.Bounds.Height;
                display.StartX = screen.Bounds.X + offsetX;
                display.StartY = screen.Bounds.Y + offsetY;
                
                bool isChecked = false;
                if (staticScreens.Contains(display.Name))
                    isChecked = true;

                display.Static = isChecked;
                displays.Add(display);

                KeyValuePair<string, bool> kvp = new KeyValuePair<string, bool>(display.Name, isChecked);
                list.Add(kvp);
            }

            return list;
        }

        // Modifies image for multiscreen if a static wallpaper is assigned
        internal static Image ModifyImage(Image img)
        {
            if (!Enabled || displays.Count <= 1) // No static screen assigned
                return img;

            // Calculate total width & height
            int totalWidth = 0, totalHeight = 0;
            foreach (Display display in displays)
            {
                if (display.StartX + display.Width > totalWidth)
                    totalWidth = display.StartX + display.Width;
                if (display.StartY + display.Height > totalHeight)
                    totalHeight = display.StartY + display.Height;
            }

            // Draw wallpaper
            Bitmap result = new Bitmap(totalWidth, totalHeight);
            foreach (Display display in displays)
            {
                // Resize or get static image
                Image displayImg = null;
                if (display.Image == null)
                {
                    if (display.Static)
                    {
                        displayImg = ResizeImageAndRatio(
                            Wallpaper.GetWallpaperImage("Static"), 
                            display.Width, display.Height);
                        display.Image = displayImg;
                    }
                    else displayImg = ResizeImageAndRatio(img, display.Width, display.Height);
                }
                else displayImg = display.Image;

                // Add to wallpaper
                Bitmap displayBmp = new Bitmap(displayImg);
                for (int x = 0; x < display.Width; x++)
                {
                    for (int y = 0; y < display.Height; y++)
                    {
                        result.SetPixel(x + display.StartX, 
                            y + display.StartY,
                            displayBmp.GetPixel(x, y));
                    }
                }
            }
            return (Image)result;
        }

        public static Image ResizeImageAndRatio(Image initImage, int newWidth, int newHeight)
        {
            int templateWidth = newWidth;
            int templateHeight = newHeight;
            double templateRate = double.Parse(templateWidth.ToString()) / templateHeight;
            double initRate = double.Parse(initImage.Width.ToString()) / initImage.Height;
            if (templateRate == initRate)
            {
                Image templateImage = new Bitmap(templateWidth, templateHeight);
                Graphics templateG = Graphics.FromImage(templateImage);
                templateG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                templateG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                templateG.Clear(Color.White);
                templateG.DrawImage(initImage, new Rectangle(0, 0, templateWidth, templateHeight), new Rectangle(0, 0, initImage.Width, initImage.Height), GraphicsUnit.Pixel);
                return templateImage;
            }
            else
            {
                Image pickedImage = null;
                Graphics pickedG = null;
                Rectangle fromR = new Rectangle(0, 0, 0, 0);
                Rectangle toR = new Rectangle(0, 0, 0, 0);
                if (templateRate > initRate)
                {

                    pickedImage = new Bitmap(initImage.Width, int.Parse(Math.Floor(initImage.Width / templateRate).ToString()));
                    pickedG = Graphics.FromImage(pickedImage);

                    fromR.X = 0;
                    fromR.Y = int.Parse(Math.Floor((initImage.Height - initImage.Width / templateRate) / 2).ToString());
                    fromR.Width = initImage.Width;
                    fromR.Height = int.Parse(Math.Floor(initImage.Width / templateRate).ToString());

                    toR.X = 0;
                    toR.Y = 0;
                    toR.Width = initImage.Width;
                    toR.Height = int.Parse(Math.Floor(initImage.Width / templateRate).ToString());
                }

                else
                {
                    pickedImage = new Bitmap(int.Parse(Math.Floor(initImage.Height * templateRate).ToString()), initImage.Height);
                    pickedG = Graphics.FromImage(pickedImage);

                    fromR.X = int.Parse(Math.Floor((initImage.Width - initImage.Height * templateRate) / 2).ToString());
                    fromR.Y = 0;
                    fromR.Width = int.Parse(Math.Floor(initImage.Height * templateRate).ToString());
                    fromR.Height = initImage.Height;

                    toR.X = 0;
                    toR.Y = 0;
                    toR.Width = int.Parse(Math.Floor(initImage.Height * templateRate).ToString());
                    toR.Height = initImage.Height;
                }

                pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                pickedG.DrawImage(initImage, toR, fromR, GraphicsUnit.Pixel);

                Image templateImage = new Bitmap(templateWidth, templateHeight);
                Graphics templateG = Graphics.FromImage(templateImage);
                templateG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                templateG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                templateG.Clear(Color.White);
                templateG.DrawImage(pickedImage, new Rectangle(0, 0, templateWidth, templateHeight), new Rectangle(0, 0, pickedImage.Width, pickedImage.Height), GraphicsUnit.Pixel);

                templateG.Dispose();
                pickedG.Dispose();
                pickedImage.Dispose();
                return templateImage;
            }
        }
    }

    class Display
    {
        public string Name = "";
        public int Width = 0;
        public int Height = 0;
        public int StartX = 0;
        public int StartY = 0;
        public bool Static = false;
        public Image Image = null;
    }
}

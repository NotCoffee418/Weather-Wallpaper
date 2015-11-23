using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;

namespace WeatherWallpaper
{
    class Weather
    {
        /// <summary>
        /// Returns the current weather at user location as a string such as "Sunny"
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentWeather()
        {
            // Load xml
            try
            {
                string xmlString = GetWeatherXml();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString);
                return xml["weatherdata"]["weather"]["current"].Attributes["skytext"].Value;
            }
            catch
            {
                return "error";
            }
        }

        public static string GetUserLocation()
        {
            string loc = Properties.Settings.Default.Location;
            if (loc == String.Empty)
            {
                loc = GetLocationFromIP();
                Properties.Settings.Default.Location = loc;
                Properties.Settings.Default.Save();
            }
            return loc;
        }

        /// <summary>
        /// List locations based on user search input location
        /// </summary>
        /// <param name="input">location</param>
        /// <returns></returns>
        public static string[] FindLocations(string input)
        {
            // Load xml
            try
            {
                string xmlString = GetWeatherXml(input);
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString);

                // Get Location Names
                int count = xml["weatherdata"].ChildNodes.Count;
                int i = 0;
                string[] result = new string[count];
                foreach (XmlElement weather in xml["weatherdata"])
                {
                    result[i] = weather.Attributes["weatherlocationname"].Value;
                    i++;
                }

                return result;
            }
            catch
            {
                return new string[0];
            }
        }

        private static string GetWeatherXml(string location = "")
        {
            if (location == "")
                location = GetUserLocation();
            string degreeType = Properties.Settings.Default.DegreeType;

            string url = "http://weather.service.msn.com/data.aspx?weasearchstr=" + location +
                "&culture=en-US&weadegreetype=" + degreeType + "&src=outlook";

            WebClient client = new WebClient();
            return client.DownloadString(url);
        }

        /// <summary>
        /// Returns location based on user's IP address
        /// </summary>
        /// <returns></returns>
        private static string GetLocationFromIP()
        {
            WebClient client = new WebClient();
            string xmlString = client.DownloadString("http://ip-api.com/xml");
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            return xml["query"]["city"].InnerText + ", " + xml["query"]["country"].InnerText;
        }
    }
}

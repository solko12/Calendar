using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Logic
{
    /// <summary>
    /// Class parse downloaded weatherInfo 5 days per 3 h to average for 5 days
    /// </summary>
    public static class WeatherParser
    {
        /// <summary>
        /// Method parse json string consist weather for 5 days per 3 h to average weather for 5 days daily
        /// </summary>
        /// <param name="json">Input JSON formated string</param>
        /// <returns>Parsed Json formated string</returns>
        public static String parseWeather(string json)
        {
            //Helper var for single day weather
            String singleParsedWeather = "";
            //List of daily forecast
            List<String> weathers = new List<string>();
            //Flag indicates new day
            bool flag = false;
            //Var storage last day
            string lastDay = "";
            //Helping vars for high and low temperature
            decimal currentHighTemp = -999;
            decimal currentLowTemp = 999;
            //Helping vars for high and low wind speed
            decimal currentHighSpeed = 0;
            decimal currentLowSpeed = 999;
            //Helping var for compute average pressure
            decimal sumPressure = 0;
            int pressureCount = 0;
            //Weather JObject stores input json OBJ
            JObject weather = JObject.Parse(json);
            //We are looking at single forecast from api
            foreach (JObject singleWeather in weather.SelectToken("list"))
            {
                //String stores prepared current day nb from date in format "YYYY-MM-DD HH-MM-SS"
                string currentDay = singleWeather.SelectToken("dt_txt").ToString().Split(" ")[0].Split("-")[2];
                //When new day comes
                if (flag == false)
                {
                    lastDay = currentDay;
                    flag = true;
                    singleParsedWeather = "{\"Day\":\"" + singleWeather.SelectToken("dt_txt").ToString().Split(" ")[0] + "\",";
                    sumPressure = 0;
                    pressureCount = 0;
                    currentHighTemp = (decimal)singleWeather.SelectToken("main").SelectToken("temp_max");
                    currentLowTemp = (decimal)singleWeather.SelectToken("main").SelectToken("temp_min");
                    currentHighSpeed = (decimal)singleWeather.SelectToken("wind").SelectToken("speed");
                    currentLowSpeed = currentHighSpeed;
                }
                if (lastDay.Equals(currentDay))
                {
                    lastDay = currentDay;
                    if (currentHighTemp < (decimal)singleWeather.SelectToken("main").SelectToken("temp_max"))
                    {
                        currentHighTemp = (decimal)singleWeather.SelectToken("main").SelectToken("temp_max");
                    }
                    if (currentLowTemp > (decimal)singleWeather.SelectToken("main").SelectToken("temp_min"))
                    {
                        currentLowTemp = (decimal)singleWeather.SelectToken("main").SelectToken("temp_min");
                    }
                    if (currentHighSpeed < (decimal)singleWeather.SelectToken("wind").SelectToken("speed"))
                    {
                        currentHighSpeed = (decimal)singleWeather.SelectToken("wind").SelectToken("speed");
                    }
                    if (currentLowSpeed > (decimal)singleWeather.SelectToken("wind").SelectToken("speed"))
                    {
                        currentLowSpeed = (decimal)singleWeather.SelectToken("wind").SelectToken("speed");
                    }
                    sumPressure += (decimal)singleWeather.SelectToken("main").SelectToken("pressure");
                    pressureCount++;
                }
                else
                {
                    singleParsedWeather += "\"Temperature\":{";
                    //ToString(CultureInfo.InvariantCulture) give us a change from "," to "." decimal separator
                    singleParsedWeather += "\"TempMax\":" + currentHighTemp.ToString(CultureInfo.InvariantCulture) + ",";
                    singleParsedWeather += "\"TempMin\":" + currentLowTemp.ToString(CultureInfo.InvariantCulture) + "},";
                    singleParsedWeather += "\"AvPressure\":" + Math.Round(sumPressure / pressureCount, 2).ToString(CultureInfo.InvariantCulture) + ",";
                    singleParsedWeather += "\"Wind\":" + "{" + "\"Direction\":\"" + getMeTheWindDirectionLetter((decimal)singleWeather.SelectToken("wind").SelectToken("deg")) + "\",";
                    singleParsedWeather += "\"SpeedMin\":" + (currentLowSpeed).ToString(CultureInfo.InvariantCulture) + ",";
                    singleParsedWeather += "\"SpeedMax\":" + (currentHighSpeed).ToString(CultureInfo.InvariantCulture) + "}";
                    singleParsedWeather += "}";
                    weathers.Add(singleParsedWeather);
                    flag = false;
                }
            }
            return "{\"City\":\""+ weather.SelectToken("city").SelectToken("name") + "\",\"Weather\":[" + string.Join(",", weathers) + "]}";
        }

        private static string getMeTheWindDirectionLetter(decimal degree)
        {
            if ((degree <= 20 && degree >= 0) || (degree <= 360 && degree > 340))
            {
                return "N";
            }
            else if ((degree <= 70 && degree > 20))
            {
                return "NE";
            }
            else if ((degree <= 110 && degree > 70))
            {
                return "E";
            }
            else if ((degree <= 160 && degree > 110))
            {
                return "SE";
            }
            else if ((degree <= 200 && degree > 160))
            {
                return "S";
            }
            else if ((degree <= 250 && degree > 200))
            {
                return "SW";
            }
            else if ((degree <= 290 && degree > 250))
            {
                return "W";
            }
            else if (((degree <= 340 && degree > 290)))
            {
                return "NW";
            }
            else
            {
                return "ERROR";
            }
        }


    }
}

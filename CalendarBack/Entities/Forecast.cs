using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CalendarBack.Entities
{
    /// <summary>
    /// Class contains main json's object structure
    /// </summary>
    public class Main
    {
        /// <summary>
        /// Temperature
        /// </summary>
        public double temp { get; set; } = 0;
        /// <summary>
        /// Feels like temperature
        /// </summary>
        public double feels_like { get; set; } = 0;
        /// <summary>
        /// Minimal temperature
        /// </summary>
        public double temp_min { get; set; } = 0;
        /// <summary>
        /// Maximal temperature
        /// </summary>
        public double temp_max { get; set; } = 0;
        /// <summary>
        /// Air pressure
        /// </summary>
        public int pressure { get; set; } = 0;
        /// <summary>
        /// Sea level
        /// </summary>
        public int sea_level { get; set; } = 0;
        /// <summary>
        /// Location ground level
        /// </summary>
        public int grnd_level { get; set; } = 0;
        /// <summary>
        /// Humidity in percents
        /// </summary>
        public int humidity { get; set; } = 0;
        /// <summary>
        /// Temperature in kelwins
        /// </summary>
        public double temp_kf { get; set; } = 0;
    }
    /// <summary>
    /// Class contains weather json's object structure
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Id of weather type
        /// </summary>
        public int id { get; set; } = 0;
        /// <summary>
        /// Main description of weather
        /// </summary>
        public string main { get; set; } = "x";
        /// <summary>
        /// Description in specified language
        /// </summary>
        public string description { get; set; } = "x";
        /// <summary>
        /// Weather icon
        /// </summary>
        public string icon { get; set; } = "x";
    }
    /// <summary>
    /// Class contains clouds json's object structure
    /// </summary>
    public class Clouds
    {
        /// <summary>
        /// Cloudless in percents
        /// </summary>
        public int all { get; set; } = 0;
    }
    /// <summary>
    /// Class contains wind json's object structure
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// Wind speed
        /// </summary>
        public double speed { get; set; } = 0;
        /// <summary>
        /// Angle of wind where 0 is North
        /// </summary>
        public int deg { get; set; } = 0;
    }
    /// <summary>
    /// Class contains sys json's object structure
    /// </summary>
    public class Sys
    {
        /// <summary>
        /// 
        /// </summary>
        public string pod { get; set; } = "x";

    }
    /// <summary>
    /// Class contains rain json's object structure
    /// </summary>
    public class Rain
    {
        /// <summary>
        /// Expected rain in next 3h
        /// </summary>
        public double __invalid_name__3h { get; set; } = 0;
    }
    /// <summary>
    /// Class contains list json's object structure
    /// </summary>
    public class List
    {
        /// <summary>
        /// It's status block
        /// </summary>
        public int dt { get; set; } = 0;
        /// <summary>
        /// Main object
        /// </summary>
        public Main main { get; set; } = new Main();
        /// <summary>
        /// List of Weather objects
        /// </summary>
        public List<Weather> weather { get; set; } = new List<Weather>();
        /// <summary>
        /// Clouds object
        /// </summary>
        public Clouds clouds { get; set; } = new Clouds();
        /// <summary>
        /// Wind object
        /// </summary>
        public Wind wind { get; set; } = new Wind();
        /// <summary>
        /// Sys object
        /// </summary>
        public Sys sys { get; set; } = new Sys();
        /// <summary>
        /// Description
        /// </summary>
        public string dt_txt { get; set; } = "x";
        /// <summary>
        /// Rain object
        /// </summary>
        public Rain rain { get; set; } = new Rain();
    }
    /// <summary>
    /// Class contains coord json's object structure
    /// </summary>
    public class Coord
    {
        /// <summary>
        /// Lattitude
        /// </summary>
        public double lat { get; set; } = 0;
        /// <summary>
        /// Lontitude
        /// </summary>
        public double lon { get; set; } = 0;
    }
    /// <summary>
    /// Class contains city json's object structure
    /// </summary>
    public class City
    {
        /// <summary>
        /// City id
        /// </summary>
        public int id { get; set; } = 0;
        /// <summary>
        /// City name
        /// </summary>
        public string name { get; set; } = "x";
        /// <summary>
        /// Coord object
        /// </summary>
        public Coord coord { get; set; } = new Coord();
        /// <summary>
        /// Country code
        /// </summary>
        public string country { get; set; } = "x";
        /// <summary>
        /// City population
        /// </summary>
        public int population { get; set; } = 0;
        /// <summary>
        /// Time zone
        /// </summary>
        public int timezone { get; set; } = 0;
        /// <summary>
        /// Sunrise time
        /// </summary>
        public int sunrise { get; set; } = 0;
        /// <summary>
        /// Sunset time
        /// </summary>
        public int sunset { get; set; } = 0;
    }
    /// <summary>
    /// Class contains forecast json's object structure
    /// </summary>
    public class Forecast
    {
        /// <summary>
        /// System variable
        /// </summary>
        public string cod { get; set; } = "x";
        /// <summary>
        /// System variable
        /// </summary>
        public int message { get; set; } = 0;
        /// <summary>
        /// System variable
        /// </summary>
        public int cnt { get; set; } = 0;
        /// <summary>
        /// List of list objects
        /// </summary>
        public List<List> list { get; set; } = new List<List>();
        /// <summary>
        /// City object
        /// </summary>
        public City city { get; set; } = new City();
    }
}

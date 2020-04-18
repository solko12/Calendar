using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Forecast.cs contains entity pattern for api's forecast
/// </summary>
namespace CalendarBack.Entities
{
    public class Main
    {
        public double temp { get; set; } = 0;
        public double feels_like { get; set; } = 0;
        public double temp_min { get; set; } = 0;
        public double temp_max { get; set; } = 0;
        public int pressure { get; set; } = 0;
        public int sea_level { get; set; } = 0;
        public int grnd_level { get; set; } = 0;
        public int humidity { get; set; } = 0;
        public double temp_kf { get; set; } = 0;
    }

    public class Weather
    {
        public int id { get; set; } = 0;
        public string main { get; set; } = "x";
        public string description { get; set; } = "x";
        public string icon { get; set; } = "x";
    }

    public class Clouds
    {
        public int all { get; set; } = 0;
    }

    public class Wind
    {
        public double speed { get; set; } = 0;
        public int deg { get; set; } = 0;
    }

    public class Sys
    {
        public string pod { get; set; } = "x";

    }

    public class Rain
    {
        public double __invalid_name__3h { get; set; } = 0;
    }

    public class List
    {
        public int dt { get; set; } = 0;
        public Main main { get; set; } = new Main();
        public List<Weather> weather { get; set; } = new List<Weather>();
        public Clouds clouds { get; set; } = new Clouds();
        public Wind wind { get; set; } = new Wind();
        public Sys sys { get; set; } = new Sys();
        public string dt_txt { get; set; } = "x";
        public Rain rain { get; set; } = new Rain();
    }

    public class Coord
    {
        public double lat { get; set; } = 0;
        public double lon { get; set; } = 0;
    }

    public class City
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = "x";
        public Coord coord { get; set; } = new Coord();
        public string country { get; set; } = "x";
        public int population { get; set; } = 0;
        public int timezone { get; set; } = 0;
        public int sunrise { get; set; } = 0;
        public int sunset { get; set; } = 0;
    }

    public class Forecast
    {
        public string cod { get; set; } = "x";
        public int message { get; set; } = 0;
        public int cnt { get; set; } = 0;
        public List<List> list { get; set; } = new List<List>();
        public City city { get; set; } = new City();
    }
}

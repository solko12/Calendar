using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{

    public class weather
    {
        public int id { get; set;}
        public string mainName { get; set; }
        public string description { get; set; }
        public string iconCode { get; set; }
    }
    public class coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }
    public class mainParams 
    {
        public double temp { get; set; }
        public double tempFeel { get; set; }
        public double tempMin { get; set; }
        public double tempHigh { get; set; }
        public int pressure { get; set; }
        public double humidity { get; set; }
        public double seaLevel { get; set; }
        public double groundLevel { get; set; }
    }
    public class wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    public class sys {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    public class rain
    {
        public double rain1h { get; set; }
        public double rain3h { get; set; }
    }
    public class snow
    {
        public double snow1h { get; set; }
        public double snow3h { get; set; }
    }

    public class Weather
    {
        public coord position { get; set; }
        public IList<weather> weathers { get; set; }
        public string _base { get; set; }
        public string temperatureC { get; set; }
        public mainParams mainParams { get; set; }
        public double visibility { get; set; }
        public double cloudness { get; set; }
        public int dt { get; set; }
        public sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public rain rain { get; set; }
        public snow snow { get; set; }
    }
}

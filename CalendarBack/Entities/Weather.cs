using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{
    public class Weather
    {
        public Dictionary<String, double> coord { get; set; }
        public IList<Dictionary<String,String>> weather { get; set; }
        public string @base { get; set; }
        public string temperature { get; set; }
        public Dictionary<String, double> main { get; set; }
        public double visibility { get; set; }
        public double cloudness { get; set; }
        public int dt { get; set; }
        public Dictionary<String, String> sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public Dictionary<String,String> rain { get; set; }
        public Dictionary<String,String> snow { get; set; }
    }
}

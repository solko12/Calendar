using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{
    public class wind
    {
        public string direction { get; set; }
        public double power { get; set; }
    }
    public class weather
    {
        public string day { get; set; }
        public double temperature { get; set; }
        public wind wind { get; set; }
        public double cloudness { get; set; }
        public int icon { get; set; }
    }
    public class WeatherSendingFromEndpoint
    {
        IList<weather> weathers { get; set; }
    }
}

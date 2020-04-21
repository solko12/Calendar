using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{

    public class SysC
    {
        public string country { get; set; }
    }

    public class SingleCity
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public SysC sys { get; set; }
    }

    public class CitiesList
    {
        public string message { get; set; }
        public string cod { get; set; }
        public int count { get; set; }
        public List<SingleCity> list { get; set; }
    }
}

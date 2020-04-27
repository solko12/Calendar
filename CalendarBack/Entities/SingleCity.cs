using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{
    public class SingleCity
    {
        public int id { get; set; }
        public String name { get; set; }
        public String state { get; set; }
        public String country { get; set; }
        public Coord coord { get; set; }
    }
}

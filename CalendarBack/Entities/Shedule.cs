using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{
    public class Shedule
    {
        public DateTime date { get; set; }
        public List<Task> tasksList { get; set; }
    }
}

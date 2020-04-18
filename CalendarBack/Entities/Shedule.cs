using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{
    public class TasksList
    {
        public string content { get; set; }
        public string time { get; set; }
    }

    public class Shedule
    {
        public DateTime date { get; set; }
        public List<TasksList> tasksList { get; set; }
    }
}

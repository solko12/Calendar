using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{
    /// <summary>
    /// Describes task json object
    /// </summary>
    public class Task
    {
        /// <summary>
        /// It's name of task
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// Time of the task
        /// </summary>
        public string time { get; set; }
    }
}

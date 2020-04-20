using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{
    /// <summary>
    /// Describes Shedule json object
    /// </summary>
    public class Shedule
    {
        /// <summary>
        /// Date of shedule
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// List of tasks objects
        /// </summary>
        public List<Task> tasksList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Database.Entities
{
    /// <summary>
    /// Shedule entity
    /// </summary>
    public class Shedule
    {
        /// <summary>
        /// Id of the shedule
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Date is date for which data is storage
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// TaskList is list of task for that day
        /// </summary>
        public List<Task> TasksList { get; set; } = new List<Task>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Database.Entities
{
    /// <summary>
    /// Task Entity
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Id of single task
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Content storages string value describe of task
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Time storages time when task have been planed
        /// </summary>
        public string Time { get; set; }

        public int SheduleId { get; set; }
    }
}

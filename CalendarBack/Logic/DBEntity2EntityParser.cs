using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Logic
{    
    /// <summary>
     /// Class for parse DBModel Enities to Entities
     /// </summary>
    public class DBEntity2EntityParser
    {
        /// <summary>
        /// Method parse shedule entity
        /// </summary>
        /// <param name="dbShedule">Shedule in dbentity model</param>
        /// <returns></returns>
        public static Entities.Shedule parseShedule(Database.Entities.Shedule dbShedule)
        {
            Entities.Shedule eShedule = new Entities.Shedule() { date = dbShedule.Date };
            List<Entities.Task> eTasks = new List<Entities.Task>();
            foreach (Database.Entities.Task task in dbShedule.TasksList)
            {
                eTasks.Add(new Entities.Task() { content = task.Content, time = task.Time });
            }
            eShedule.tasksList = eTasks;
            return eShedule;
        }

        public static Entities.Task parseTask(Database.Entities.Task dbTask) {
            return new Entities.Task() { content = dbTask.Content, time = dbTask.Time };
        }
    }
}

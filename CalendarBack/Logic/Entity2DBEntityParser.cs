using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Logic
{
    /// <summary>
    /// Class for parse Entities to DBModel Enities
    /// </summary>
    public class Entity2DBEntityParser
    {
        /// <summary>
        /// Method parse shedule entity
        /// </summary>
        /// <param name="eShedule">Shedule in dotnet entity model</param>
        /// <returns></returns>
        public static Database.Entities.Shedule parseShedule(Entities.Shedule eShedule) {
            Database.Entities.Shedule dbShedule = new Database.Entities.Shedule() { Date=eShedule.date};
            List<Database.Entities.Task> dbTasks = new List<Database.Entities.Task>();
            foreach (Entities.Task task in eShedule.tasksList) {
                dbTasks.Add(new Database.Entities.Task() { Content = task.content, Time = task.time });
            }
            dbShedule.TasksList = dbTasks;
            return dbShedule;
        }
        public static Database.Entities.Task parseTask(Entities.Task eTask) {
            return new Database.Entities.Task() { Content = eTask.content, Time = eTask.time };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CalendarBack.Database;
using CalendarBack.Database.Entities;
using CalendarBack.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CalendarBack.Controllers
{
    /// <summary>
    /// Controller for flow of tasks between client and database
    /// </summary>
    [Route("tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        CalendarContext context = new CalendarContext() {DbCatalog = "Do_celow_testowych"};
        /// <summary>
        /// Endpoint for adding record in tasks table in database
        /// <param name="shedule">Param for specified shedule for day</param>
        /// </summary>
        [HttpPut("{date}")]
        public void AddRecord([FromBody] Entities.Shedule shedule, String date)
        {
            context.Database.EnsureCreated();
            var dbShedule = context.Shedules.Where(s => s.Date == shedule.date).ToList();

            if (dbShedule.Count == 0) {
                context.Shedules.Add(Logic.Entity2DBEntityParser.parseShedule(shedule));
            }
            else
            {
                var tasksToRemove = context.Tasks.Where(s => s.SheduleId == dbShedule[0].Id).ToList();
                context.Tasks.RemoveRange(tasksToRemove);
                List<Entities.Task> eTasks = shedule.tasksList;
                List<Database.Entities.Task> tasksList = new List<Task>();
                foreach (Entities.Task task in eTasks) { 
                    tasksList.Add(Entity2DBEntityParser.parseTask(task));
                }
                dbShedule[0].TasksList = tasksList;
                context.Shedules.Update(dbShedule[0]);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// Endpoint returns daily tasks
        /// </summary>
        /// <param name="date">Param for specified date</param>
        /// <returns>Json formated shedule object</returns>
        [HttpGet("{date}")]
        public String GetTasksForDay(String date)
        {
            context.Database.EnsureCreated();
            List<Database.Entities.Shedule> dbShedules = context.Shedules.Where(s => s.Date == DateTime.Parse(date)).ToList();
            List<Entities.Task> eTasks = new List<Entities.Task>();

            if (dbShedules.Count == 0)
            {
                return JsonConvert.SerializeObject(eTasks);
            }
            else
            {
                List<Database.Entities.Task> dbTasks = context.Tasks.Where(s => s.SheduleId == dbShedules[0].Id).ToList();
                if (dbTasks.Count == 0)
                {
                    return JsonConvert.SerializeObject(eTasks);
                }
                else
                {
                    foreach (Database.Entities.Task dbTask in dbTasks)
                    {
                        eTasks.Add(DBEntity2EntityParser.parseTask(dbTask));
                    }
                    return JsonConvert.SerializeObject(eTasks);
                }
            }

        }

        /// <summary>
        /// Enpoint returns list of days which contains tasks
        /// </summary>
        /// <returns>Parsed json list includes days with tasks</returns>
        [HttpGet]
        public String GetDaysWithTasks() {
            context.Database.EnsureCreated();
            List<Database.Entities.Shedule> dbShedules = context.Shedules.Where(s => s.TasksList.Count != 0).ToList();
            List<DateTime> daysWithTasks = new List<DateTime>();
            foreach (Database.Entities.Shedule shedule in dbShedules) {
                daysWithTasks.Add(shedule.Date);
            }
            return JsonConvert.SerializeObject(daysWithTasks);
        }
    }
}

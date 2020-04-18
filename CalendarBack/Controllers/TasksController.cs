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
        public void AddRecord([FromBody] Entities.Shedule shedule)
        {
            context.Database.EnsureCreated();
            var dbShedule = context.Shedules.Where(s => s.Date == shedule.date);

            if (dbShedule.Count() == 0) {
                context.Shedules.Add(Logic.Entity2DBEntityParser.parseShedule(shedule));
            }
            context.SaveChanges();
            Console.WriteLine(context.Shedules.Where(s=>s.Date == shedule.date).ToList()[0].TasksList[0].Content);
        }
        /// <summary>
        /// Endpoint returns daily tasks
        /// </summary>
        /// <param name="date">Param for specified date</param>
        /// <returns>Json formated shedule object</returns>
        [HttpGet("{date}")]
        public String GetSheduleForDay(String date)
        {
            context.Database.EnsureCreated();
            List<Database.Entities.Shedule> dbShedules = context.Shedules.Where(s => s.Date == DateTime.Parse(date)).ToList();
            if (dbShedules.Count() == 0)
            {
                return JsonConvert.SerializeObject(new Entities.Shedule());
            }
            else
            {
                return JsonConvert.SerializeObject(DBEntity2EntityParser.parseShedule(dbShedules[0]));
            }
        }
    }
}

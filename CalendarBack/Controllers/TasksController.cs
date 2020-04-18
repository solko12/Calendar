using System;
using System.Collections.Generic;
using System.Linq;
using CalendarBack.Database;
using CalendarBack.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalendarBack.Controllers
{
    /// <summary>
    /// Controller for flow of tasks between client and database
    /// </summary>
    [Route("tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        CalendarContext context = new CalendarContext();
        /// <summary>
        /// Endpoint for adding record in tasks table in database
        /// </summary>
        [HttpPut("{date}")]
        public void AddRecord([FromBody] object json)
        {
            //context.Database.EnsureCreated();
            Task task = new Task();
            task.Content = "";
            task.Time = "";
            //context.Shedules.Find()
            Shedule shedule = new Shedule();
            Console.WriteLine(json);
            
        }


    }
}

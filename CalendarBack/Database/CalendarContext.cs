using CalendarBack.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Database
{
    /// <summary>
    /// This class is contector between database and CalendarBack
    /// </summary>
    public class CalendarContext:DbContext
    {
        /// <summary>
        /// DbCatalog is database name
        /// </summary>
        public String DbCatalog { get; set; } = "CalendarData";
        /// <summary>
        /// DbSet collection for storage shedules
        /// </summary>
        public DbSet<Shedule> Shedules { get; set; }
        /// <summary>
        /// DbSet collection for storage tasks
        /// </summary>
        public DbSet<Entities.Task> Tasks { get; set; }
        /// <summary>
        /// Overrided method for init configuration
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder object</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = "+ DbCatalog);
        }
    }
}

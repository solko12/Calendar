using CalendarBack.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace CalendarBack.Tests
{
    /// <summary>
    /// Tests for Database unit
    /// </summary>
    public class DatabaseTest
    {

        private CalendarContext context = new CalendarContext() { DbCatalog="Tests"};
        

        [Fact]
        void creatingAndDeletingDatabase() {
            Assert.True(context.Database.EnsureCreated());
            Assert.True(context.Database.EnsureDeleted());
        }

        [Fact]
        void addingAndDeletingNewRecord() {
            context.Database.EnsureCreated();
            var task = new Database.Entities.Task() {Content = " ", Time = "13:00" };
            Assert.Equal(0, context.Tasks.Count());
            context.Tasks.Add(task);
            context.SaveChanges();
            Assert.Equal(1, context.Tasks.Count());
            context.Tasks.Remove(task);
            context.SaveChanges();
            Assert.Equal(0, context.Tasks.Count());
            context.Database.EnsureDeleted();
        }

    }
}

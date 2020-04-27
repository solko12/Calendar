using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CalendarBack.Tests
{
    /// <summary>
    /// Tests for DBEntity2EntityParse
    /// </summary>
    public class DBEntity2EntityParserTest
    {
        [Theory]
        [MemberData(nameof(TaskData))]
        private void parseTask(Database.Entities.Task task, Entities.Task expectedParsedTask)
        {
            Assert.Equal(expectedParsedTask.content, Logic.DBEntity2EntityParser.parseTask(task).content);
            Assert.Equal(expectedParsedTask.time, Logic.DBEntity2EntityParser.parseTask(task).time);
        }
        [Theory]
        [MemberData(nameof(SheduleData))]
        private void parseShedule(Database.Entities.Shedule shedule, Entities.Shedule expectedParsedShedule) {
            Assert.Equal(expectedParsedShedule.date, Logic.DBEntity2EntityParser.parseShedule(shedule).date);
            for(int i = 0; i < 2; i++)
            {
                Assert.Equal(expectedParsedShedule.tasksList[i].content, Logic.DBEntity2EntityParser.parseShedule(shedule).tasksList[i].content);
                Assert.Equal(expectedParsedShedule.tasksList[i].time, Logic.DBEntity2EntityParser.parseShedule(shedule).tasksList[i].time);
            }
        }
        /// <summary>
        /// Test data for task
        /// </summary>
        public static IEnumerable<object[]> TaskData =>
        new List<object[]>
        {
            new object[] { new Database.Entities.Task() { Content="Konie",Time="21:00"}, new Entities.Task() { content="Konie",time="21:00"} },
            new object[] { new Database.Entities.Task() { Content="Nie wiem",Time="00:00"}, new Entities.Task() { content="Nie wiem",time="00:00"} },
            new object[] { new Database.Entities.Task() { Content="Wyindywidualizowac indywidualiste",Time="21:30"}, new Entities.Task() { content= "Wyindywidualizowac indywidualiste", time= "21:30" } },
        };
        /// <summary>
        /// Test data for Shedule
        /// </summary>
        public static IEnumerable<object[]> SheduleData => new List<object[]>
        {
            new object[] {
                new Database.Entities.Shedule() { Date = new DateTime(1998, 3, 15), TasksList = new List<Database.Entities.Task>() { new Database.Entities.Task() { Content = "Konie", Time = "21:00" }, new Database.Entities.Task() { Content = "Nie wiem", Time = "00:00" } } },
                new Entities.Shedule() { date = new DateTime(1998, 3, 15), tasksList = new List<Entities.Task>() { new Entities.Task() { content = "Konie", time = "21:00" }, new Entities.Task() { content = "Nie wiem", time = "00:00" } } }
            },
            new object[] {
                new Database.Entities.Shedule() { Date = new DateTime(2013, 12, 16), TasksList = new List<Database.Entities.Task>() { new Database.Entities.Task() { Content = "Konie", Time = "21:00" }, new Database.Entities.Task() { Content = "Nie wiem", Time = "00:00" } } },
                new Entities.Shedule() { date = new DateTime(2013, 12, 16), tasksList = new List<Entities.Task>() { new Entities.Task() { content = "Konie", time = "21:00" }, new Entities.Task() { content = "Nie wiem", time = "00:00" } } }
            },
        };
    }
}

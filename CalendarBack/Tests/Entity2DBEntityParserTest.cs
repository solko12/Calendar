using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CalendarBack.Tests
{
    public class Entity2DBEntityParserTest
    {
        [Theory]
        [MemberData(nameof(TaskData))]
        private void parseTask(Entities.Task task, Database.Entities.Task expectedParsedTask)
        {
            Assert.Equal(expectedParsedTask.Content, Logic.Entity2DBEntityParser.parseTask(task).Content);
            Assert.Equal(expectedParsedTask.Time, Logic.Entity2DBEntityParser.parseTask(task).Time);
        }
        [Theory]
        [MemberData(nameof(SheduleData))]
        private void parseShedule(Entities.Shedule shedule, Database.Entities.Shedule expectedParsedShedule)
        {
            Assert.Equal(expectedParsedShedule.Date, Logic.Entity2DBEntityParser.parseShedule(shedule).Date);
            for (int i = 0; i < 2; i++)
            {
                Assert.Equal(expectedParsedShedule.TasksList[i].Content, Logic.Entity2DBEntityParser.parseShedule(shedule).TasksList[i].Content);
                Assert.Equal(expectedParsedShedule.TasksList[i].Time, Logic.Entity2DBEntityParser.parseShedule(shedule).TasksList[i].Time);
            }
        }
        /// <summary>
        /// Test data for task
        /// </summary>
        public static IEnumerable<object[]> TaskData =>
        new List<object[]>
        {
            new object[] { new Entities.Task() { content="Konie",time="21:00"}, new Database.Entities.Task() { Content="Konie",Time="21:00"} },
            new object[] { new Entities.Task() { content="Nie wiem",time="00:00"}, new Database.Entities.Task() { Content="Nie wiem",Time="00:00"} },
            new object[] { new Entities.Task() { content="Wyindywidualizowac indywidualiste",time="21:30"}, new Database.Entities.Task() { Content= "Wyindywidualizowac indywidualiste", Time= "21:30" } },
        };
        /// <summary>
        /// Test data for Shedule
        /// </summary>
        public static IEnumerable<object[]> SheduleData => new List<object[]>
        {
            new object[] {
                new Entities.Shedule() { date = new DateTime(1998, 3, 15), tasksList = new List<Entities.Task>() { new Entities.Task() { content = "Konie", time = "21:00" }, new Entities.Task() { content = "Nie wiem", time = "00:00" } } },
                new Database.Entities.Shedule() { Date = new DateTime(1998, 3, 15), TasksList = new List<Database.Entities.Task>() { new Database.Entities.Task() { Content = "Konie", Time = "21:00" }, new Database.Entities.Task() { Content = "Nie wiem", Time = "00:00" } } }
            },
            new object[] {
                new Entities.Shedule() { date = new DateTime(2013, 12, 16), tasksList = new List<Entities.Task>() { new Entities.Task() { content = "Konie", time = "21:00" }, new Entities.Task() { content = "Nie wiem", time = "00:00" } } },
                new Database.Entities.Shedule() { Date = new DateTime(2013, 12, 16), TasksList = new List<Database.Entities.Task>() { new Database.Entities.Task() { Content = "Konie", Time = "21:00" }, new Database.Entities.Task() { Content = "Nie wiem", Time = "00:00" } } }
            },
        };
    }
}

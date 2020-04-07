using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalendarApp.CalendarAppTests
{
    public class DayPageTests
    {
        
        [Theory]
        [InlineData(true,"02:00","02:00","Cały dzień")]
        [InlineData(true,"02:00","05:00","Cały dzień")]
        [InlineData(false,"02:00","02:00","02:00")]
        [InlineData(false,"02:00","05:00","02:00-05:00")]
        public void ValidatingTaskTimeAssignment(bool allDay,string begin, string end, string result)
        {
            string actual = DayPageLogic.TaskTimeAssignment(allDay, begin, end);
            Assert.Equal(result, actual);
        }
    }
}

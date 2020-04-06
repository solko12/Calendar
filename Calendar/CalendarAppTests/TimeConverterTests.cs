using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace CalendarApp.CalendarAppTests
{
    public class TimeConverterTests
    {
        [Theory]
        [InlineData(120,"02:00")]
        [InlineData(0,"00:00")]
        public void ConvertingMinutes(int value, string expected)
        {
            TimeConverter timeConverter = new TimeConverter();
            string actual = timeConverter.ConvertLogic(value);
            Assert.Equal(expected, actual);
        }
    }
}

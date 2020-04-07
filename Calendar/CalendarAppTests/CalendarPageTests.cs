using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace CalendarApp.CalendarAppTests
{
    /// <summary>
    /// This class consist of unit tests for CalendarPageLogic.cs
    /// </summary>
    public class CalendarPageTests
    {
        /// <summary>
        /// This method check if the method DayOfWeekNumeration works correctly. It checks the index of sunday and monday.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(2020,4,5,7)]
        [InlineData(2020,4,6,1)]
        public void DoesItReturnsOneSevenNumerationDayOfTheWeek(int year, int month, int day, int expected)
        {
            DateTime date = new DateTime(year, month, day);
            int actual=CalendarPageLogic.DayOfWeekNumeration(date);
            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// This method checks if SetBeginOfTheMonth method works correctly
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        [Theory]
        [InlineData(2020,4,7)]
        public void TestingSetDayToBeginOfTheMonth(int year,int month, int day)
        {
            DateTime date = new DateTime(year,month,day);
            date = CalendarPageLogic.SetDayToBeginingOfTheMonth(date);
            Assert.Equal(1, date.Day);
        }
    }
}

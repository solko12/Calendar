using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp
{
    /// <summary>
    /// A class with helpful methods for CalendarPage.xaml.cs
    /// </summary>
    class CalendarPageLogic
    {
        /// <summary>
        /// This method change numeration of the sunday from dafault 0 to 7
        /// </summary>
        /// <param name="day"></param>
        /// <returns>Day number of the week</returns>
        public static int DayOfWeekNumeration(DateTime day)
        {
            return ((int)day.DayOfWeek == 0) ? 7 : (int)day.DayOfWeek;
        }
        /// <summary>
        /// This method set date to the first day of the current month
        /// </summary>
        /// <param name="day"></param>
        /// <returns>Date with first day of the month</returns>
        public static DateTime SetDayToBeginingOfTheMonth(DateTime day)
        {
            return day.AddDays((-1 * (int)day.Day) + 1);
        }
    }
}

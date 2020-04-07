using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp
{
    class DayPageLogic
    {
        public static string TaskTimeAssignment(bool isChecked, string begin, string end)
        {
            if (isChecked)
            {
                return "Cały dzień";
            }
            // checking if the time of begining of the task equals the time of finishing the task
            else if (begin == end)
            {
                //if true, only one value is assigned to task time
                return begin;
            }
            else
            {
                return begin + "-" + end;
            }
        }
    }
}

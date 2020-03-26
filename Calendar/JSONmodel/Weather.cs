using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.JSONmodel
{
    class Weather
    {
        public string Day { get; set; }
        public Temperature Temperature { get; set; }
        public double AvPressure { get; set; }
        public Wind Wind { get; set; }
    }
}

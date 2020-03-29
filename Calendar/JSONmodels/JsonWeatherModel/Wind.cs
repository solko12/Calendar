using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.JSONmodels.JsonWeatherModel
{
    class Wind
    {
        public string Direction { get; set; }
        public double SpeedMin { get; set; }
        public double SpeedMax { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.JSONmodels.JsonWeatherModel
{
    class RootObject
    {
        public string City { get; set; }
        public List<Weather> Weather { get; set; }
    }
}

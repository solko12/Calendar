using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.JSONmodel
{
    class RootObject
    {
        public string City { get; set; }
        public List<Weather> Weather { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.JSONmodels.JsonWeatherModel
{
    class Weather
    {
        public string Day { get; set; }
        public Temperature Temperature { get; set; }
        public double AvPressure { get; set; }
        public Wind Wind { get; set; }
        public WeatherInfo WeatherInfo { get; set; }
    }
}

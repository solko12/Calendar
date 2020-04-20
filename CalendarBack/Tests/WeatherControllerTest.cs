using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Data;
using CalendarBack.Logic;
using CalendarBack.Entities;

namespace CalendarBack.Tests
{
    /// <summary>
    /// Tests for wheaterControler
    /// </summary>
    public class WeatherControllerTest
    {
        [Fact]
        private void deserialiseJson() {
            Assert.Equal("{\"City\":\"x\",\"Weather\":[]}", WeatherParser.parseWeather(new Forecast()));
        }
    }
}

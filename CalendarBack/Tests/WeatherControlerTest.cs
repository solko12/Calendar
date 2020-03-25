using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Data;

namespace CalendarBack.Tests
{
    public class WeatherControlerTest
    {
        [Fact]
        void deserialiseJson() {
            string json = "{\"cod\":\"200\",\"message\":0,\"cnt\":1,\"list\":[{\"dt\":1585148400,\"main\":{\"temp\":5.83,\"feels_like\":-0.71,\"temp_min\":4.81,\"temp_max\":5.83,\"pressure\":1034,\"sea_level\":1034,\"grnd_level\":1014,\"humidity\":57,\"temp_kf\":1.02},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"bezchmurnie\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":6.11,\"deg\":101},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2020 - 03 - 25 15:00:00\"}],\"city\":{\"id\":760778,\"name\":\"Radom\",\"coord\":{\"lat\":51.4025,\"lon\":21.1471},\"country\":\"PL\",\"population\":226794,\"timezone\":3600,\"sunrise\":1585110360,\"sunset\":1585155386}}";
            DataSet data = JsonConvert.DeserializeObject<DataSet>(json);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using CalendarApp.JSONmodels.JsonWeatherModel;
using CalendarApp.JSONmodels.JsonSheduleModel;
using System.Collections.ObjectModel;


namespace CalendarApp.API
{
    class AppsCommunication
    {
        public List<Weather> GetWeather()
        {
            WebClient client = new WebClient();
            String rawJSON = client.DownloadString("https://localhost:5001/weather");
            RootObject weatherData = JsonConvert.DeserializeObject<RootObject>(rawJSON);
            List<Weather> weathers = weatherData.Weather;
            return weathers;

        }
        public string SendTasks(DateTime d,ObservableCollection<Task> t )
        {
            Shedule shedule = new Shedule();
            shedule.date = d;
            shedule.tasksList = t;
            string strResultJson = JsonConvert.SerializeObject(shedule);
            return strResultJson;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using CalendarApp.JSONmodels.JsonWeatherModel;
using CalendarApp.JSONmodels.JsonSheduleModel;
using System.Collections.ObjectModel;
using System.IO;

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
        
        public string JsoningTasks(DateTime d,ObservableCollection<Task> t )
        {
            Shedule shedule = new Shedule();
            shedule.date = d;
            shedule.tasksList = t;
            string strResultJson = JsonConvert.SerializeObject(shedule);
            return strResultJson;
        }
        public Shedule DeJsonigTasks(string taskJson)
        {
            Shedule shedule = JsonConvert.DeserializeObject<Shedule>(taskJson);
            return shedule;
        }
        public string GetTasks(DateTime date)
        {
            string strDate = date.ToShortDateString();
            string url = "https://localhost:5001/tasks/" + strDate;
            string responseString = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if(response.StatusCode!=HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code:" + response.StatusCode.ToString());
                }
                using(Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream!=null)
                    {
                        using(StreamReader reader = new StreamReader(responseStream))
                        {
                            responseString = reader.ReadToEnd();
                            reader.Close();
                        }
                    }
                }
            } //end of using response
            return responseString;
        }
        public void PutTasks(string postedData,DateTime date)
        {
            string strDate = date.ToShortDateString();
            string url = "https://localhost:5001/tasks/" + strDate ; 
            WebRequest request = WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json";
            using(var streamWriter= new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postedData);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using(var streamReader = new StreamReader(request.GetRequestStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }

        }
    }
}

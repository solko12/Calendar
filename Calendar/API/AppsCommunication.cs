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
    /// <summary>
    /// Class that allows to comunicate with server
    /// </summary>
    class AppsCommunication
    {
        /// <summary>
        /// This method download weather data as json and deserialize it into RootObject
        /// </summary>
        /// <returns> List of Weather objects</returns>
        public List<Weather> GetWeather()
        {
            WebClient client = new WebClient();
            String rawJSON = client.DownloadString("https://localhost:5001/weather");
            RootObject weatherData = JsonConvert.DeserializeObject<RootObject>(rawJSON);
            List<Weather> weathers = weatherData.Weather;
            return weathers;

        }
        /// <summary>
        /// this method creates json from Shedule object
        /// </summary>
        /// <param name="d">day on which the tasks are scheduled</param>
        /// <param name="t">List of tasks</param>
        /// <returns> json created from Shedule object </returns>
        public string JsoningTasks(DateTime d,ObservableCollection<Task> t )
        {
            Shedule shedule = new Shedule();
            shedule.date = d;
            shedule.tasksList = t;
            string strResultJson = JsonConvert.SerializeObject(shedule);
            return strResultJson;
        }
        /// <summary>
        /// This method converts json to Shedule object
        /// </summary>
        /// <param name="taskJson"></param>
        /// <returns> Shedule object as a result of deserialization json</returns>
        public ObservableCollection<Task> DeJsonigTasks(string taskJson)
        {
            ObservableCollection<Task> shedule = JsonConvert.DeserializeObject<ObservableCollection<Task>>(taskJson);
            return shedule;
        }
        /// <summary>
        /// This method makes GET request to the server to get tasks planed for given day
        /// </summary>
        /// <param name="date">given day</param>
        /// <returns> Response of the server as string </returns>
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
        /// <summary>
        /// This method makes PUT request to the server to update informations about tasks
        /// </summary>
        /// <param name="postedData"> Tasks</param>
        /// <param name="date">Day on which the tasks are sheduled</param>
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
                /*using(var streamReader = new StreamReader(request.GetRequestStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                */
                
            }

        }
    }
}

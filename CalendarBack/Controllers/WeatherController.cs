using System;
using System.Collections.Generic;
using System.Data;
using CalendarBack.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using unirest_net.http;

namespace CalendarBack.Controllers
{

    ///<summary>
    /// Class controls downloading weather info from api and make endpoints which sending wanted data
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        /// <summary>
        /// Variable weather store data about current weather
        /// </summary>
        static string location = "Zwoleń";
        Weather weather = JsonConvert.DeserializeObject<Weather>(Unirest.get("http://api.openweathermap.org/data/2.5/weather?q="+ location +"&APPID=2a0aa79c92d95fff84d4a19951ba6eaf").asJson<string>().Body.ToString());

        /// <summary>
        /// Endpoint for current location
        /// </summary>
        /// <returns></returns>
        [HttpGet("location")]
        public IEnumerable<string> Get()
        {
            return new string[] { weather.name };
        }

        [HttpGet("/")]
        public string GetWeather() {

            return "";
        }

        // GET: api/Weather/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return id.ToString();
        }
        
        // GET: weather/reload
        [HttpGet("reload")]
        public Weather reload() {
            return weather = JsonConvert.DeserializeObject<Weather>(Unirest.get("http://api.openweathermap.org/data/2.5/weather?q=" + location + "&APPID=2a0aa79c92d95fff84d4a19951ba6eaf").asJson<string>().Body.ToString());
        }
        /*
        [HttpGet("TEST")]
        public string test() {
            DataSet data = JsonConvert.DeserializeObject<DataSet>(Unirest.get("http://api.openweathermap.org/data/2.5/weather?q=" + location + "&APPID=2a0aa79c92d95fff84d4a19951ba6eaf").asJson<string>().Body.ToString());
            
            return data.Tables["cod"].Rows[0].ToString();
        }*/
    }
}

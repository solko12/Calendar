using System;
using System.Collections.Generic;
using System.Data;
using CalendarBack.Entities;
using CalendarBack.Logic;
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
        //Weather weather = JsonConvert.DeserializeObject<Weather>(Unirest.get("http://api.openweathermap.org/data/2.5/weather?q="+ location + "&APPID=2a0aa79c92d95fff84d4a19951ba6eaf&units=metric&lang=pl").asJson<string>().Body.ToString());
        String forecast = Unirest.get("http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&APPID=2a0aa79c92d95fff84d4a19951ba6eaf&units=metric&lang=pl").asJson<string>().Body.ToString();

        [HttpGet("")]
        public String GetWeather() {
            return WeatherParser.parseWeather(forecast);
        }

        // GET: api/Weather/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return id.ToString();
        }
        
        // GET: weather/reload
        [HttpGet("reload")]
        public string reload() {
            //weather = JsonConvert.DeserializeObject<Weather>(Unirest.get("http://api.openweathermap.org/data/2.5/weather?q=" + location + "&APPID=2a0aa79c92d95fff84d4a19951ba6eaf").asJson<string>().Body.ToString());
            forecast = Unirest.get("http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&APPID=2a0aa79c92d95fff84d4a19951ba6eaf&units=metric&lang=pl").asJson<string>().Body.ToString();

            return "DONE";
        }
        /*
        [HttpGet("TEST")]
        public string test() {
            DataSet data = JsonConvert.DeserializeObject<DataSet>(Unirest.get("http://api.openweathermap.org/data/2.5/weather?q=" + location + "&APPID=2a0aa79c92d95fff84d4a19951ba6eaf").asJson<string>().Body.ToString());
            
            return data.Tables["cod"].Rows[0].ToString();
        }*/
    }
}

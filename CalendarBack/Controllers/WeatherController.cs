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
        /// List of avaliable cities starts there because of server flexibility at endpoint request
        /// </summary>
        private static List<Entities.SingleCity> cities = Logic.ListOfCitiesLoader.getCities();
        private static String ApiKey = "2a0aa79c92d95fff84d4a19951ba6eaf";
        /// <summary>
        /// Variable weather store data about current weather
        /// </summary>
        private static string location = "Zwoleń";
        private static Forecast forecast = JsonConvert.DeserializeObject<Forecast>(Unirest.get("http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&APPID=" + ApiKey + "&units=metric&lang=pl").asJson<string>().Body.ToString());

        /// <summary>
        /// Endpoint for forecast in default location
        /// </summary>
        /// <returns>String in json format</returns>
        [HttpGet("")]
        public String GetWeatherByDefaultLocation()
        {
            return WeatherParser.parseWeather(forecast);
        }
        /// <summary>
        /// Endpoint for forecast in specified zipCode
        /// </summary>
        /// <param name="zipCode">Zip Code specified for region</param>
        /// <param name="countryCode">Country code from zipCode where it comes from</param>
        /// <returns>Forecast String in json format</returns>
        [HttpGet("{zipCode}/{countryCode}")]
        public String GetWeatherByPostCode(string zipCode, string countryCode) {
            forecast = JsonConvert.DeserializeObject<Forecast>(Unirest.get("http://api.openweathermap.org/data/2.5/forecast?zip=" + zipCode + "," + countryCode + "&APPID="+ApiKey+"&units=metric&lang=pl").asJson<string>().Body.ToString());
            return WeatherParser.parseWeather(forecast);
        }
        /// <summary>
        /// Endpoint for forecast in specified city
        /// </summary>
        /// <param name="city">Specified name of city</param>
        /// <returns>Forecast String in json format</returns>
        [HttpGet("{city}", Name = "Get")]
        public string GetForecastByCityName(string city)
        {
            location = city;
            forecast = JsonConvert.DeserializeObject<Forecast>(Unirest.get("http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&APPID="+ApiKey+"&units=metric&lang=pl").asJson<string>().Body.ToString());
            return WeatherParser.parseWeather(forecast);
        }
        /// <summary>
        /// Endpoint for forecast in specified city by id
        /// </summary>
        /// <param name="id">Id of the city</param>
        /// <returns>Forecast String in json format</returns>
        [HttpGet("byId/{id}")]
        public String GetForecastByCityId(int id) {
            forecast = JsonConvert.DeserializeObject<Forecast>(Unirest.get("http://api.openweathermap.org/data/2.5/forecast?id=" + id + "&APPID="+ApiKey+"&units=metric&lang=pl").asJson<string>().Body.ToString());
            return WeatherParser.parseWeather(forecast);
        }
        /// <summary>
        /// Endpoint for reloading forecast to actual location. Actual location means specified forecast for specified region when endpoint for forecast from specified vity was used
        /// otherwise will be used defaul one
        /// </summary>
        /// <returns>Done when operation was succesfuly done</returns>
        // GET: weather/reload
        [HttpGet("reload")]
        public string GetReload()
        {

            forecast = JsonConvert.DeserializeObject<Forecast>(Unirest.get("http://api.openweathermap.org/data/2.5/forecast?q=" + location + "&APPID="+ApiKey+"&units=metric&lang=pl").asJson<string>().Body.ToString());
            return "DONE";
        }
        /// <summary>
        /// Endpoint returns list of avaliable cities
        /// </summary>
        /// <returns>Cities in list</returns>
        [HttpGet("cities")]
        public List<SingleCity> GetCities() {
            return cities;
        }
        /// <summary>
        /// Method for testing purposes
        /// </summary>
        /// <returns></returns>
        [HttpGet("TEST")]
        public string test() {
            Forecast forecast1 = new Forecast();
            return WeatherParser.parseWeather(forecast1);
        }
    }
}
using System.Collections.Generic;
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
        
        Weather weather = JsonConvert.DeserializeObject<Weather>(Unirest.get("http://api.openweathermap.org/data/2.5/weather?q=Zwoleń&APPID=2a0aa79c92d95fff84d4a19951ba6eaf").asJson<string>().Body.ToString());

        
        [HttpGet("location")]
        public IEnumerable<string> Get()
        {
            return new string[] { weather.name };
        }

        // GET: api/Weather/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return id.ToString();
        }


    }
}

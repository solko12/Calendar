using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unirest_net.http;
using Newtonsoft.Json;

namespace CalendarBack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        
        HttpResponse<string> response = Unirest.get("http://api.openweathermap.org/data/2.5/forecast?id=524901&APPID=2a0aa79c92d95fff84d4a19951ba6eaf")
.asJson<string>();
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { response.Body.ToString() };
        }

        // GET: api/Weather/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return id.ToString();
        }
    }
}

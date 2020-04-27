using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Logic
{
    /// <summary>
    /// Class loads cities list and parse it;
    /// </summary>
    public static class ListOfCitiesLoader
    {
        /// <summary>
        /// Location for json list of cities data
        /// </summary>
        public static String dataLocation { get; set; } = "city.list.json";
        /// <summary>
        /// Method loads and parse citiesList entity
        /// </summary>
        /// <returns></returns>
        public static List<Entities.SingleCity> getCities() {
            String jsonStrList="";
            try
            {
                jsonStrList = File.ReadAllText(dataLocation);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("XD");
            return JsonConvert.DeserializeObject<List<Entities.SingleCity>>(jsonStrList);
        }  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarBack.Entities
{
    /// <summary>
    /// Single City Entity
    /// </summary>
    public class SingleCity
    {
        /// <summary>
        /// City id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// City state
        /// </summary>
        public String state { get; set; }
        /// <summary>
        /// Country of City
        /// </summary>
        public String country { get; set; }
        /// <summary>
        /// City coordinates
        /// </summary>
        public Coord coord { get; set; }
    }
}

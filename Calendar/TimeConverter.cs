using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CalendarApp
{   
    class TimeConverter : IValueConverter
    {
        /// <summary>
        /// This method converts minutes to hours
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns> Time as a string </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timeString = string.Empty;

            int minutes = System.Convert.ToInt32((double)value);

            TimeSpan ts = new TimeSpan(0, minutes, 0);

            timeString = ts.ToString(@"hh\:mm");

            return timeString;
        }
        /// <summary>
        /// Not implemented method 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns> Throws exception </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

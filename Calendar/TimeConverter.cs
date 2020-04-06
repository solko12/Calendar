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
        /// This method converts value of the object to minutes
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns> Object </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timeString = string.Empty;

            int minutes = System.Convert.ToInt32((double)value);

            return this.ConvertLogic(minutes);
        }
        /// <summary>
        /// This method converts minutes to time format
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns>Time as string</returns>
        public string ConvertLogic(int minutes)
        {
            string timeString = string.Empty;

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

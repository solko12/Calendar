using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CalendarApp
{
    class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timeString = string.Empty;

            int seconds = System.Convert.ToInt32((double)value);

            TimeSpan ts = new TimeSpan(0, seconds, 0);

            timeString = ts.ToString(@"hh\:mm");

            return timeString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

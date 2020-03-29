using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using CalendarApp.JSONmodels.JsonWeatherModel;

namespace CalendarApp
{
    /// <summary>
    /// Logika interakcji dla klasy WeatherPage.xaml
    /// </summary>
    public partial class WeatherPage : Page
    {
        public DateTime date = DateTime.Now; 
        public ObservableCollection<string> listOfCities = new ObservableCollection<string>();
        public WeatherPage()
        {
            InitializeComponent();
            PrintDays();
            PrintTemp(GetWeather());
            PrintPressure(GetWeather());
            PrintWind(GetWeather());
            PrintIcon(GetWeather());
            PrintDescription(GetWeather());
            CityBox.ItemsSource = listOfCities;
        }
        private void PrintDays()
        {
            DateTime day = new DateTime(date.Year, date.Month, date.Day);
            Style style = this.FindResource("DateLabelStyle") as Style;
            for (int i=0;i<5;i++)
            {
                var label = new Label();
                label.Content = day.ToShortDateString();
                label.SetValue(Grid.ColumnProperty, i);
                label.Style = style;
                DaysGrid.Children.Add(label);
                day=day.AddDays(1);
            }
        }
        private List<Weather> GetWeather()
        {
            WebClient client = new WebClient();
            String rawJSON = client.DownloadString("https://localhost:5001/weather");
            RootObject weatherData = JsonConvert.DeserializeObject<RootObject>(rawJSON);
            List<Weather> weathers = weatherData.Weather;
            return weathers;
           
        }
        private void PrintTemp(List<Weather> weathers)
        {
            Style style = this.FindResource("TempLabelStyle") as Style;
            int i = 0;
            foreach (Weather w in weathers)
            {
                var label = new Label();
                double maxTemp = Math.Round(w.Temperature.TempMax);
                double minTemp = Math.Round(w.Temperature.TempMin);
                label.Content = string.Format("{0}°C", maxTemp) + " / " + string.Format("{0}°C", minTemp); 
                label.SetValue(Grid.ColumnProperty, i);
                label.SetValue(Grid.RowProperty, 3);
                label.Style = style;
                DaysGrid.Children.Add(label);
                i++;
            }
        }
        private void PrintPressure(List<Weather> weathers)
        {
            Style style = this.FindResource("TempLabelStyle") as Style;
            int i = 0;
            foreach (Weather w in weathers)
            {
                var label = new Label();
                double pressure = Math.Round(w.AvPressure);
                label.Content = pressure + "hPa";
                label.SetValue(Grid.ColumnProperty, i);
                label.SetValue(Grid.RowProperty, 5);
                label.Style = style;
                DaysGrid.Children.Add(label);
                i++;
            }
        }
        private void PrintWind(List<Weather> weathers)
        {
            Style style = this.FindResource("TempLabelStyle") as Style;
            int i = 0;
            foreach (Weather w in weathers)
            {
                var label = new Label();
                string direction = w.Wind.Direction;
                double wind = Math.Round((w.Wind.SpeedMax+w.Wind.SpeedMin)/2);        
                label.Content = direction + " " + wind +" km/h";
                label.SetValue(Grid.ColumnProperty, i);
                label.SetValue(Grid.RowProperty, 4);
                label.Style = style;
                DaysGrid.Children.Add(label);
                i++;
            }
        }
        private void PrintIcon(List<Weather> weathers)
        {
            int i = 0;
            foreach (Weather w in weathers)
            {
                Image img = new Image();
                string icon = w.WeatherInfo.icon;
                string source = "http://openweathermap.org/img/wn/" + icon + "@2x.png";
                Uri resourceUri = new Uri(source, UriKind.RelativeOrAbsolute);
                img.Source = new BitmapImage(resourceUri);
                img.SetValue(Grid.ColumnProperty, i);
                img.SetValue(Grid.RowProperty, 1);
                
                DaysGrid.Children.Add(img);
                i++;
            }
        }
        private void PrintDescription(List<Weather> weathers)
        {
            Style style = this.FindResource("TempLabelStyle") as Style;
            int i = 0;
            foreach (Weather w in weathers)
            {
                var label = new Label();
                string description = w.WeatherInfo.Description;
                label.Content = description;
                label.SetValue(Grid.ColumnProperty, i);
                label.SetValue(Grid.RowProperty, 2);
                label.Style = style;
                DaysGrid.Children.Add(label);
                i++;
            }
        }

    }
}

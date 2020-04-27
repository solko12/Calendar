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
using CalendarApp.API;
using CalendarBack.Entities;

namespace CalendarApp
{
    /// <summary>
    /// This is a weather page class that enables program to show 5 days weather forecast
    /// </summary>
    public partial class WeatherPage : Page
    {
        /// <summary>
        /// Actual date
        /// </summary>
        public DateTime date = DateTime.Now; 
        /// <summary>
        /// List of cities with weather forecast
        /// </summary>
        public ObservableCollection<SingleCity> listOfCities { get; set; }
        public SingleCity selectedCity { get; set; }
        string cityName = "Kielce";
        /// <summary>
        /// API that enables communication with server
        /// </summary>
        private AppsCommunication api= new AppsCommunication();
        /// <summary>
        /// Constructor that initalizes weather page
        /// </summary>
        public WeatherPage()
        {
            listOfCities = new ObservableCollection<SingleCity>(); 
            InitializeComponent();
            DataContext = this;
            listOfCities = api.GetCities();
            Refresh();
            
           
        }
        /// <summary>
        /// This method prints dates of 5 days from today
        /// </summary>
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
        /// <summary>
        /// Method which prints maximum and minimum temperature 
        /// </summary>
        /// <param name="weathers"></param>
        private void PrintTemp(List<JSONmodels.JsonWeatherModel.Weather> weathers)
        {
            Style style = this.FindResource("TempLabelStyle") as Style;
            int i = 0;
            foreach (JSONmodels.JsonWeatherModel.Weather w in weathers)
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
        /// <summary>
        /// A method that prints the average pressure 
        /// </summary>
        /// <param name="weathers"></param>
        private void PrintPressure(List<JSONmodels.JsonWeatherModel.Weather> weathers)
        {
            
            Style style = this.FindResource("TempLabelStyle") as Style;
            int i = 0;
            foreach (JSONmodels.JsonWeatherModel.Weather w in weathers)
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
        /// <summary>
        /// A method that prints the average wind speed 
        /// </summary>
        /// <param name="weathers"></param>
        private void PrintWind(List<JSONmodels.JsonWeatherModel.Weather> weathers)
        {
            Style style = this.FindResource("TempLabelStyle") as Style;
            int i = 0;
            foreach (JSONmodels.JsonWeatherModel.Weather w in weathers)
            {
                var label = new Label();
                string direction = w.Wind.Direction;
                double wind = Math.Round((w.Wind.SpeedMax+w.Wind.SpeedMin)/2);        
                label.Content = direction + " " + wind +" m/s";
                label.SetValue(Grid.ColumnProperty, i);
                label.SetValue(Grid.RowProperty, 4);
                label.Style = style;
                DaysGrid.Children.Add(label);
                i++;
            }
        }
        /// <summary>
        /// the method displays icons symbolizing the given weather
        /// </summary>
        /// <param name="weathers"></param>
        private void PrintIcon(List<JSONmodels.JsonWeatherModel.Weather> weathers)
        {
            int i = 0;
            foreach (JSONmodels.JsonWeatherModel.Weather w in weathers)
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
        /// <summary>
        /// This method prints description about weather for given day
        /// </summary>
        /// <param name="weathers"></param>
        private void PrintDescription(List<JSONmodels.JsonWeatherModel.Weather> weathers)
        {
            
            Style style = this.FindResource("TempLabelStyle") as Style;
            int i = 0;
            foreach (JSONmodels.JsonWeatherModel.Weather w in weathers)
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
        private void Refresh()
        {
            DaysGrid.Children.Clear();
            PrintDays();
            PrintTemp(api.GetWeather(cityName));
            PrintPressure(api.GetWeather(cityName));
            PrintWind(api.GetWeather(cityName));
            PrintIcon(api.GetWeather(cityName));
            PrintDescription(api.GetWeather(cityName));
            
        }

        private void CityBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedCity == null) return;
            cityName = selectedCity.name;
            Refresh();
        }
    }
}

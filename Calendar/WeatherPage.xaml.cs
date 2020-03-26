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

namespace CalendarApp
{
    /// <summary>
    /// Logika interakcji dla klasy WeatherPage.xaml
    /// </summary>
    public partial class WeatherPage : Page
    {
        public DateTime date = DateTime.Now; 
        public ObservableCollection<string> list = new ObservableCollection<string>();
        public WeatherPage()
        {
            InitializeComponent();
            PrintDays();
            list.Add("cipka");
            list.Add("Hugo");
            list.Add("boss");
            CityBox.ItemsSource = list;
        }
        private void PrintDays()
        {
            DateTime day = new DateTime(date.Year, date.Month, date.Day);
            Style style = this.FindResource("LabelStyle") as Style;
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
    }
}

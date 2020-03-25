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

namespace CalendarApp
{
    public partial class CalendarPage : Page
    {
        public DateTime selectedDate = DateTime.Now;

        public CalendarPage()
        {
            this.DataContext = this;
            InitializeComponent();
            RefreshCalendarGrid();
        }

        private void RefreshCalendarGrid()
        {
            currDateText.Text = selectedDate.ToString("MMMM") + " " + selectedDate.Year;
            GridCalendar.Children.Clear();

            int daysInMonth = System.DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);

            int row = 0;
         
            DateTime day = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);
            
            day = day.AddDays((-1 * (int)day.Day) +1);

            for (int i = 1; i <= daysInMonth; i++)
            {

                var button = new Button();
                if (day.Date.Equals(DateTime.Now.Date))
                {
                    button.Background = Brushes.DeepSkyBlue;
                }
                else
                {
                    button.Background = Brushes.Lime;
                }
                button.Content = day.Day + "";
                button.SetValue(Grid.RowProperty, row);
                int dayOfWeeek = ((int)day.DayOfWeek == 0) ? 7 : (int)day.DayOfWeek;
                button.SetValue(Grid.ColumnProperty, dayOfWeeek-1);
                button.Click += Button_Click;
                GridCalendar.Children.Add(button);
                if (dayOfWeeek == 7) row++;
                day = day.AddDays(1);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            
            DayPage nextPage = new DayPage(new DateTime(selectedDate.Year, selectedDate.Month, int.Parse(button.Content.ToString())));
            this.NavigationService.Navigate(nextPage);
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = selectedDate.AddMonths(-1);
            RefreshCalendarGrid();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = selectedDate.AddMonths(1);
            RefreshCalendarGrid();
        }
    }
}

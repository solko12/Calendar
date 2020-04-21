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
using CalendarApp.API;

namespace CalendarApp
{
    public partial class CalendarPage : Page
    {
        /// <summary>
        /// Selected date
        /// </summary>
        public DateTime selectedDate = DateTime.Now;

        public List<DateTime> daysWithTasks { get; set; }
        private AppsCommunication api = new AppsCommunication();

        /// <summary>
        /// Constructor that initialize calendar page
        /// </summary>
        public CalendarPage()
        {
            this.DataContext = this;
            InitializeComponent();
            daysWithTasks = api.GetDaysWithTasks();
            RefreshCalendarGrid();
            
        }
        /// <summary>
        /// This method prints days on the calendar page.
        /// </summary>
        private void RefreshCalendarGrid() // to rozbic i napisac testy
        {
            
            // Current date text block
            currDateText.Text = selectedDate.ToString("MMMM") + " " + selectedDate.Year;
            // Clearing grid
            GridCalendar.Children.Clear();

            int daysInMonth = System.DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);

            int row = 0;
         
            DateTime day = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);

            day = CalendarPageLogic.SetDayToBeginingOfTheMonth(day); 

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
                if(daysWithTasks.Contains(day))
                {
                    button.Content = "*    " + day.Day + "    *";
                }
                else
                {
                    button.Content = day.Day + "";
                }
                
                button.SetValue(Grid.RowProperty, row);
                int dayOfWeeek = CalendarPageLogic.DayOfWeekNumeration(day);
                button.SetValue(Grid.ColumnProperty, dayOfWeeek-1);
                button.Click += Button_Click;
                GridCalendar.Children.Add(button);
                if (dayOfWeeek == 7) row++;
                day = day.AddDays(1);
            }
        }
        /// <summary>
        /// The method supports clicking the button that represents given day. As a result of clicking button day page is displayed.
        /// </summary>
        /// <param name="sender"> Default parameter </param>
        /// <param name="e"> Default parameter </param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            
            DayPage nextPage = new DayPage(new DateTime(selectedDate.Year, selectedDate.Month, int.Parse(button.Content.ToString())));
            this.NavigationService.Navigate(nextPage);
        }
        /// <summary>
        /// The method supports clicking the button that changes the month to the previous one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = selectedDate.AddMonths(-1);
            RefreshCalendarGrid();
        }
        /// <summary>
        /// The method supports clicking the button that changes the month to the next one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = selectedDate.AddMonths(1);
            RefreshCalendarGrid();
        }
        /// <summary>
        /// The method supports clicking the weather button that leads us to weather page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Weather_Click(object sender, RoutedEventArgs e)
        {
            WeatherPage nextPage = new WeatherPage();
            this.NavigationService.Navigate(nextPage);
        }
    }
}

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
    /// <summary>
    /// Logika interakcji dla klasy CalendarPage.xaml
    /// </summary>
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
            currDateText.Text = selectedDate.Month + " " + selectedDate.Year;
            GridCalendar.Children.Clear();

            int daysInMonth = System.DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);

            //selectedDate = selectedDate.AddDays(-dayOfMonth + 1);

            //int dayOfWeeek = ((int)selectedDate.DayOfWeek == 0) ? 7 : (int)selectedDate.DayOfWeek;

            int row = 0;
            

            DateTime day = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);
            
            day = day.AddDays((-1 * (int)day.Day) +1);
            //int column = day.DayOfWeek -1 ;

            for (int i = 1; i <= daysInMonth; i++)
            {

                //if (column == 7)
                //{
                //    column = 0;
                //    row++;
                //}

                var button = new Button();
                if (day.Date.Equals(DateTime.Now.Date))
                {
                    button.Background = Brushes.Aqua;
                }
                button.Content = day.Day + "";
                button.SetValue(Grid.RowProperty, row);
                int dayOfWeeek = ((int)day.DayOfWeek == 0) ? 7 : (int)day.DayOfWeek;
                button.SetValue(Grid.ColumnProperty, dayOfWeeek-1);
                button.Click += Button_Click;
                GridCalendar.Children.Add(button);
                if (dayOfWeeek == 7) row++;
                day = day.AddDays(1);
                //column++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            //MessageBox.Show(button.Content.ToString());
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

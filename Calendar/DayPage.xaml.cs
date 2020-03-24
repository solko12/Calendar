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
    /// Logika interakcji dla klasy DayPage.xaml
    /// </summary>
    public partial class DayPage : Page
    {
        private DateTime _date;
        public DayPage(DateTime date)
        {
            InitializeComponent();
            _date = date;
            newQuest.Text = date.ToShortDateString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

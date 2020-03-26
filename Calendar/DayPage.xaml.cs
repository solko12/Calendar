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
    /// Logika interakcji dla klasy DayPage.xaml
    /// </summary>
    public partial class DayPage : Page
    {
        private DateTime _date;
        private ObservableCollection<string> list = new ObservableCollection<string>();
        public DayPage(DateTime date)
        {
            InitializeComponent();
            _date = date;
            Notes.ItemsSource = list;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            list.Add(newQuest.Text);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            list.Remove(Notes.SelectedItem.ToString());
        }
    }
}

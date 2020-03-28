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
        public ObservableCollection<Task> list { get; set; } //public bo bindowanie
        public Task selectedTask { get; set; } //public bo bindowanie

        public DayPage(DateTime date)
        {
            list = new ObservableCollection<Task>();
            InitializeComponent();
            DataContext = this;
            _date = date;
            //Notes.ItemsSource = list;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (newQuest.Text == "")
            {
                MessageBox.Show("Podaj treść wydarzenia");
            }
            else
            {
                Task task = new Task();
                task.content = newQuest.Text;

                if ((bool)AllDay.IsChecked)
                {
                    task.time = "Cały dzień";
                }
                else if(BeginTime.Text == EndTime.Text)
                {
                    task.time = BeginTime.Text;
                }
                else
                {
                    task.time = BeginTime.Text + "-" + EndTime.Text;
                }
                list.Add(task);
                newQuest.Clear();
                AllDay.IsChecked = false;
            }     
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(Notes.SelectedItem!=null)
            {
                list.Remove(selectedTask);
            }
        }
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider.Value > slider2.Value)
            {
                slider2.Value = slider.Value;
            }
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider2.Value < slider.Value)
            {
                slider.Value = slider2.Value;
            }
        }


    }
}

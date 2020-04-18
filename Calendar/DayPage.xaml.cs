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
using CalendarApp.API;
using CalendarApp.JSONmodels.JsonSheduleModel;

namespace CalendarApp
{
    /// <summary>
    /// The class is responsible for service and displaying Day's tasks
    /// </summary>
    public partial class DayPage : Page
    {
        // date of the page 
        private DateTime _date;
        /// <summary>
        /// List of the tasks binded to xaml control
        /// </summary>
        public ObservableCollection<Task> list { get; set; }
        /// <summary>
        /// selected Task on the list necessary to removing elements from the list
        /// </summary>
        public Task selectedTask { get; set; }
        /// <summary>
        /// facility enabling communication
        /// </summary>
        private AppsCommunication api = new AppsCommunication();
        /// <summary>
        /// Actual shedule
        /// </summary>
        public Shedule shedule;
        
        /// <summary>
        /// Constructor that initialize day page
        /// </summary>
        /// <param name="date"> Date of the clicked day</param>
        public DayPage(DateTime date)
        {
            list = new ObservableCollection<Task>();
            InitializeComponent();
            DataContext = this;
            _date = date;
            string jsonData=api.GetTasks(_date);
            shedule = api.DeJsonigTasks(jsonData);
            list = shedule.tasksList;
        }

        /// <summary>
        /// Function invokes after clicking AddButton. It adds task to the list of tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // if textbox is empty we will get warning
            if (newQuest.Text == "")
            {
                MessageBox.Show("Podaj treść wydarzenia");
            }
            else
            {
                Task task = new Task();
                // Text from newQuest TextBox is assigned to task content
                task.content = newQuest.Text;
                bool check = (bool)AllDay.IsChecked;
                task.time=DayPageLogic.TaskTimeAssignment(check, BeginTime.Text, EndTime.Text);
                list.Add(task);
                // clears TextBox 
                newQuest.Clear();
                // clears CheckBox
                AllDay.IsChecked = false;
            }
            string jsonData = api.JsoningTasks(_date, list);
            api.PutTasks(jsonData,_date);
        }
        
        /// <summary>
        /// This method removes selected task from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // checking if the list is not empty
            if(Notes.SelectedItem!=null)
            {
                list.Remove(selectedTask);
            }
        }
        /// <summary>
        /// This method guards if slider value isn't bigger than slider2 value and aligns them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider.Value > slider2.Value)
            {
                slider2.Value = slider.Value;
            }
        }
        /// <summary>
        /// This method guards if slider2 value isn't smalle than slider value and aligns them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider2.Value < slider.Value)
            {
                slider.Value = slider2.Value;
            }
        }


    }
}

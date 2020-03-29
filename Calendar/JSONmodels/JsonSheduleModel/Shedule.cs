using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CalendarApp.JSONmodels.JsonSheduleModel
{
    class Shedule
    {
        public DateTime date { get; set; }
        public ObservableCollection<Task> tasksList { get; set; }
    }
}

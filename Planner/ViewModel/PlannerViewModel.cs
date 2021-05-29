using Planner.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Planner.ViewModel
{
    class PlannerViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public PlannerViewModel()
        {
            SelectedDate = DateTime.Now;
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value; OnPropertyChanged("SelectedDate");
                Label = SelectedDate.ToString();
            }
        }
        
        private string _label;
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value; OnPropertyChanged("Label");
            }
        }
    }
}

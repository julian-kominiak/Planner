using Planner.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Planner.ViewModel
{
    class PlannerViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public PlannerViewModel()
        {
            SelectedDate = DateTime.Now;
        }

        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                Console.WriteLine("lol");
                _selectedDate = value; OnPropertyChanged("SelectedDate");
            }
        }
    }
}

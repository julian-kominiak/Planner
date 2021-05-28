using Planner.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Planner.ViewModel
{
    class PlannerViewModel : ViewModelBase
    {
        public PlannerViewModel()
        {

        }

        private DateTime _calendarSelectedDate;
        public DateTime CalendarSelectedDate
        {
            get => _calendarSelectedDate;
            set
            {
                Console.WriteLine("elo");
                SetProperty(ref _calendarSelectedDate, value);
            }
        }
    }
}

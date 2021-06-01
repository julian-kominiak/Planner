using Planner.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Planner = new PlannerViewModel();
        }
        
        private static PlannerViewModel _planner;
        public static PlannerViewModel Planner
        {
            get => _planner;
            private set
            {
                _planner = value;
            }

        }
    }
}

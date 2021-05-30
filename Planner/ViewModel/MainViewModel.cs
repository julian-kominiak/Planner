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
        
        private readonly PlannerViewModel _planner;
        public PlannerViewModel Planner
        {
            get => _planner;
            private init => SetProperty(ref _planner, value);
        }
    }
}

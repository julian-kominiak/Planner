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
        
        private PlannerViewModel _planner;
        public PlannerViewModel Planner
        {
            get => _planner;
            set => SetProperty(ref _planner, value);
        }
    }
}

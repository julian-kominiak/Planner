using Planner.ViewModel.BaseClass;

namespace Planner.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Planner = new PlannerViewModel();
        }

        public static PlannerViewModel Planner { get; private set; }
    }
}
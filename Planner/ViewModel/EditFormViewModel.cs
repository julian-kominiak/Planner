using System;
using Planner.ViewModel.BaseClass;

namespace Planner.ViewModel
{
    public class EditFormViewModel: ViewModelBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private DateTime _date;

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        private Enum _priority;

        public Enum Priority
        {
            get => _priority;
            set => SetProperty(ref _priority, value);
        }
        
        private void PerformSaveEventAction(){
            throw new NotImplementedException();
        }
    }
}
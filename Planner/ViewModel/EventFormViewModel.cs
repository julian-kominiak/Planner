using System;
using Planner.Model;
using Planner.Data;
using Planner.ViewModel.BaseClass;

namespace Planner.ViewModel
{
    public class EditFormViewModel: ViewModelBase
    {
        public EditFormViewModel()
        {
            Event sampleEvent = new Event ("Sample Event Title", "sample event description", DateTime.Now.AddDays(-1).Date, Model.Priority.High);
            Title = sampleEvent.Title;
            Description = sampleEvent.Description;
            Date = sampleEvent.Date;
            Priority = sampleEvent.Priority;
        }
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
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
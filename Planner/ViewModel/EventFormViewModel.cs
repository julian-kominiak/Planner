using System;
using Planner.Model;
using Planner.Data;
using Planner.View;
using Planner.ViewModel.BaseClass;

namespace Planner.ViewModel
{
    public class EventFormViewModel: ViewModelBase
    {
        public EventFormViewModel()
        {
            WindowTitle = "Add event";
        }

        public EventFormViewModel(Event @event)
        {
            WindowTitle = "Edit event";
            Title = @event.Title;
            Description = @event.Description;
            Date = @event.Date;
        }

        private string _windowTitle;

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                SetProperty(ref _windowTitle, value);
            }
        }
        
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                SetProperty(ref _date, value);
            }
        }

        private Enum _priority;

        public Enum Priority
        {
            get { return _priority; }
            set
            {
                SetProperty(ref _priority, value);
            }
        }

        private void PerformSaveEventAction(){
            throw new NotImplementedException();
        }
    }
}
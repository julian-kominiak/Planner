using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;
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
            Date = MainViewModel.Planner.SelectedDate;
        }

        public EventFormViewModel(Event @event)
        {
            WindowTitle = "Edit event";
            Title = @event.Title;
            Description = @event.Description;
            Date = @event.Date;
            SelectedPriority = @event.Priority;
            OldEvent = @event;
        }
        
        private Event _oldEvent;

        public Event OldEvent
        {
            get { return _oldEvent; }
            set
            {
                SetProperty(ref _oldEvent, value);
            }
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

        public IEnumerable<Priority> PriorityEnumValues
        {
            get
            {
                return Enum.GetValues(typeof(Priority))
                    .Cast<Priority>();
            }
        }

        private Priority _selectedPriority;
        public Priority SelectedPriority
        {
            get { return _selectedPriority; }
            set { 
                _selectedPriority = value;
                OnPropertyChanged("SelectedPriority");
            }
        }
        
        private ICommand _saveEvent;

        public ICommand SaveEvent
        {
            get
            {
                return _saveEvent ??= new RelayCommand(
                    arg=>PerformSaveEventAction(), arg=>(Title is not null));
            }
        }

        private void PerformSaveEventAction()
        {
            Event NewEvent = new Event(Title, Description, Date.Date, SelectedPriority);
            if (OldEvent is not null)
            {
                PerformEditEventAction(NewEvent);
                return;
            }
            EventsDTO.addEvent(NewEvent);
            MainViewModel.Planner.updateListBox();
            MainViewModel.Planner.AddView.Close();
            
        }

        private void PerformEditEventAction(Event @NewEvent)
        {
            EventsDTO.editEvent(OldEvent, NewEvent);
            MainViewModel.Planner.updateListBox();
            MainViewModel.Planner.EditView.Close();
        }
        

    }
}
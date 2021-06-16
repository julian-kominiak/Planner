using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Planner.Data;
using Planner.Model;
using Planner.ViewModel.BaseClass;

namespace Planner.ViewModel
{
    public class EventFormViewModel : ViewModelBase
    {
        private DateTime _date;

        private string _description;

        private Event _oldEvent;

        private ICommand _saveEvent;

        private Priority _selectedPriority;

        private string _title;

        public EventFormViewModel()
        {
            Date = MainViewModel.Planner.SelectedDate;
        }

        public EventFormViewModel(Event @event)
        {
            Title = @event.Title;
            Description = @event.Description;
            Date = @event.Date;
            SelectedPriority = @event.Priority;
            OldEvent = @event;
        }

        public Event OldEvent
        {
            get => _oldEvent;
            set => SetProperty(ref _oldEvent, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public IEnumerable<Priority> PriorityEnumValues =>
            Enum.GetValues(typeof(Priority))
                .Cast<Priority>();

        public Priority SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveEvent
        {
            get
            {
                return _saveEvent ??= new RelayCommand(
                    arg => PerformSaveEventAction(), arg => Title is not null);
            }
        }

        private void PerformSaveEventAction()
        {
            var NewEvent = new Event(Title, Description, Date.Date, SelectedPriority);
            if (OldEvent is not null)
            {
                PerformEditEventAction(NewEvent);
                return;
            }

            EventsDTO.addEvent(NewEvent, MainViewModel.Planner.CurrentUser);
            MainViewModel.Planner.updateListBox();
            MainViewModel.Planner.AddView.Close();
        }

        private void PerformEditEventAction(Event NewEvent)
        {
            EventsDTO.editEvent(OldEvent, NewEvent, MainViewModel.Planner.CurrentUser);
            MainViewModel.Planner.updateListBox();
            MainViewModel.Planner.EditView.Close();
        }
    }
}
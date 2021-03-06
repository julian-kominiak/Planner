using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Planner.Data;
using Planner.Model;
using Planner.View;
using Planner.ViewModel.BaseClass;

namespace Planner.ViewModel
{
    internal class PlannerViewModel : ViewModelBase
    {
        private ICommand _addEvent;

        private EventFormView _addView;

        private ICommand _changeUser;

        private string _currentUser;

        private ICommand _deleteEvent;

        private ICommand _editEvent;

        private EventFormView _editView;

        private List<Event> _itemsSource;

        private string _label;

        private LoginView _loginView;

        private DateTime _selectedDate;

        private Event _selectedItem;

        private string _tooltip;

        public PlannerViewModel()
        {
            SelectedDate = DateTime.Now;
            CurrentUser = "";
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                SetProperty(ref _selectedDate, value);
                Label = formatLabel(SelectedDate);
                updateListBox();
                Mouse.Capture(null);
            }
        }

        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public string CurrentUser
        {
            get => _currentUser;
            set
            {
                SetProperty(ref _currentUser, value);
                updateListBox();
            }
        }

        public List<Event> ItemsSource
        {
            get => _itemsSource;
            set => SetProperty(ref _itemsSource, value);
        }

        public Event SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public string Tooltip
        {
            get => _tooltip;
            set => SetProperty(ref _tooltip, value);
        }

        public ICommand ChangeUser
        {
            get
            {
                return _changeUser ??= new RelayCommand
                    (arg => OpenLoginView(), arg => true);
            }
        }

        public LoginView LoginView
        {
            get => _loginView;
            set => SetProperty(ref _loginView, value);
        }

        public ICommand AddEvent
        {
            get
            {
                return _addEvent ??= new RelayCommand
                    (arg => OpenAddEventForm(), arg => true);
            }
        }

        public EventFormView AddView
        {
            get => _addView;
            set => SetProperty(ref _addView, value);
        }

        public ICommand EditEvent
        {
            get
            {
                return _editEvent ??= new RelayCommand(
                    arg => OpenEditEventForm(), arg => SelectedItem != null);
            }
        }

        public EventFormView EditView
        {
            get => _editView;
            set => SetProperty(ref _editView, value);
        }

        public ICommand DeleteEvent
        {
            get
            {
                return _deleteEvent ??= new RelayCommand
                    (arg => PerformDeleteEventAction(), arg => SelectedItem != null);
            }
        }

        public void OpenLoginView()
        {
            LoginView = new LoginView();
            LoginView.ShowDialog();
            LoginView.Focus();
        }

        public void updateListBox()
        {
            ItemsSource = EventsDTO.getEventsForDate(SelectedDate.Date, CurrentUser).OrderByDescending(o => o.Priority)
                .ToList();
        }

        private static string formatLabel(DateTime dateTime)
        {
            return "Events for " + dateTime.ToString("dd/MM/yyyy");
        }

        private void OpenAddEventForm()
        {
            AddView = new EventFormView();
            AddView.ShowDialog();
            AddView.Focus();
        }

        private void OpenEditEventForm()
        {
            EditView = new EventFormView(SelectedItem);
            EditView.ShowDialog();
        }

        private void PerformDeleteEventAction()
        {
            EventsDTO.deleteEvent(SelectedItem, CurrentUser);
            ItemsSource = EventsDTO.getEventsForDate(SelectedDate.Date, CurrentUser);
        }
    }
}
using Planner.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Planner.Data;
using Planner.Model;
using Planner.View;

namespace Planner.ViewModel
{
    class PlannerViewModel : ViewModelBase
    {
        public PlannerViewModel()
        {
            SelectedDate = DateTime.Now;
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                SetProperty(ref _selectedDate, value);
                Label = formatLabel(SelectedDate);
                updateListBox();
                Mouse.Capture(null);
            }
        }

        public void updateListBox()
        {
            ItemsSource = EventsDTO.getEventsForDate(SelectedDate.Date);
        }
        
        private static string formatLabel(DateTime dateTime)
        {
            return "Events for " + dateTime.ToString("MM/dd/yyyy");;
        }
        
        private string _label;
        public string Label
        {
            get { return _label; }
            set
            {
                SetProperty(ref _label, value);
            }
        }

        private List<Event> _itemsSource;

        public List<Event> ItemsSource
        {
            get { return _itemsSource; }
            set
            {
                SetProperty(ref _itemsSource, value);
            }
        }

        private Event _selectedItem;
        public Event SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        private string _tooltip;

        public string Tooltip
        {
            get { return _tooltip; }
            set
            {
                SetProperty(ref _tooltip, value);
            }
        }

        private ICommand _addEvent;
        public ICommand AddEvent
        {
            get
            {
                return _addEvent ??= new RelayCommand
                    (arg => OpenAddEventForm(), arg => true);
            }
        }

        private EventFormView _addView;

        public EventFormView AddView
        {
            get { return _addView; }
            set
            {
                SetProperty(ref _addView, value);
            }
        }

        private void OpenAddEventForm()
        {
            AddView = new EventFormView();
            AddView.ShowDialog();
            AddView.Focus();
        }

        private ICommand _editEvent;

        public ICommand EditEvent
        {
            get
            {
                return _editEvent ??= new RelayCommand(
                    arg=>OpenEditEventForm(), arg=> SelectedItem != null);
            }
        }
        
        private EventFormView _editView;

        public EventFormView EditView
        {
            get { return _editView; }
            set
            {
                SetProperty(ref _editView, value);
            }
        }

        private void OpenEditEventForm()
        {
            
            
            EditView = new EventFormView(SelectedItem);
            EditView.ShowDialog();
        }

        private ICommand _deleteEvent;
        public ICommand DeleteEvent
        {
            get
            {
                return _deleteEvent ??= new RelayCommand
                    (arg => PerformDeleteEventAction(), arg => SelectedItem != null);
            }
        }

        private void PerformDeleteEventAction()
        {
            EventsDTO.deleteEvent(SelectedItem);
            ItemsSource = EventsDTO.getEventsForDate(SelectedDate.Date);
        }
    }
}

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

namespace Planner.ViewModel
{
    class PlannerViewModel : ViewModelBase
    {
        public PlannerViewModel()
        {
            initializeData();
        }

        private void initializeData()
        {
            Event sampleEvent = new Event
                ("Sample Event Title", "sample event description", DateTime.Now.Date, Priority.High);
            Event sampleEvent2 = new Event
                ("Sample Event Title2", "sample event description", DateTime.Now.Date, Priority.High);
            Event yesterdayEvent = new Event
                ("Yesterday Event", "yesterday event description", DateTime.Now.AddDays(-1).Date, Priority.High);
            EventsDTO.addEvent(sampleEvent);
            EventsDTO.addEvent(sampleEvent2);
            EventsDTO.addEvent(yesterdayEvent);
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
                ItemsSource = EventsDTO.getEventsForDate(SelectedDate.Date);
            }
        }
        
        private static string formatLabel(DateTime dateTime)
        {
            return "Events for " + dateTime.ToString("dd/MM/yyyy");;
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

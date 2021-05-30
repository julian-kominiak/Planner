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
using Planner.Data;
using Planner.Model;

namespace Planner.ViewModel
{
    class PlannerViewModel : ViewModelBase
    {
        public PlannerViewModel()
        {
            SelectedDate = DateTime.Now;
            initializeData();
        }

        private void initializeData()
        {
            Event sampleEvent = new Event
                ("Sample Event Tit", "sample event description", DateTime.Now, Priority.High);
            EventsDTO.addEvent(sampleEvent);
            ItemsSource = EventsDTO.getAllEvents();
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                SetProperty(ref _selectedDate, value);
                Label = formatLabel(SelectedDate);
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
    }
}

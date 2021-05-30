using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Planner.Model;

namespace Planner.Data
{
    public static class EventsDTO
    {
        private static List<Event> _events = new List<Event>();
        
        public static void addEvent(Event @event)
        {
            _events.Add(@event);
        }

        public static List<Event> getAllEvents()
        {
            return _events;
        }

        public static List<Event> getEventsForDate(DateTime dateTime)
        {
            return _events.FindAll(x => x.Date.Equals(dateTime));
        }

        public static void deleteEvent(Event @event)
        {
            _events.RemoveAll(x => x.Equals(@event));
        }
    }
}
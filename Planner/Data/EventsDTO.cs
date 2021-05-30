using System.Collections.Generic;
using Planner.Model;

namespace Planner.Data
{
    public static class EventsDTO
    {
        private static List<Event> _events = new List<Event>();

        public static List<Event> getAllEvents()
        {
            return _events;
        }
        
        public static void addEvent(Event @event)
        {
            _events.Add(@event);
        }
    }
}
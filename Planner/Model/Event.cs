using System;

namespace Planner.Model
{
    public class Event
    {
        private string Title { get; set; }
        private string Description { get; set; }
        private DateTime Date { get; set; }
        private Priority Priority { get; set; }

        public Event(string title, string description, DateTime date, Priority priority)
        {
            Title = title;
            Description = description;
            Date = date;
            Priority = priority;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
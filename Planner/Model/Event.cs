using System;

namespace Planner.Model
{
    public class Event
    {
        public Event(string title, string description, DateTime date, Priority priority)
        {
            Title = title;
            Description = description;
            Date = date;
            Priority = priority;
        }

        public string Title { get; }

        public string Description { get; }
        public DateTime Date { get; }
        public Priority Priority { get; }

        private bool Equals(Event other)
        {
            return Title == other.Title && Description == other.Description && Date.Equals(other.Date) &&
                   Priority == other.Priority;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Event) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description, Date, (int) Priority);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
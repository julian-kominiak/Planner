using System;

namespace Planner.Model
{
    public class Event
    {
        private string Title { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        private Priority Priority { get; set; }

        public Event(string title, string description, DateTime date, Priority priority)
        {
            Title = title;
            Description = description;
            Date = date;
            Priority = priority;
        }

        protected bool Equals(Event other)
        {
            return Title == other.Title && Description == other.Description && Date.Equals(other.Date) && Priority == other.Priority;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Event) obj);
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
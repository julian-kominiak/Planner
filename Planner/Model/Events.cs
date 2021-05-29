using System;

namespace Planner.Model
{
    public class Events
    {
        private string Name { get; set; }
        private string Description { get; set; }
        private DateTime Date { get; set; }
        private Enum Priority { get; set; }
    }
}
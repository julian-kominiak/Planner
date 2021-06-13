using System;
using System.Collections.Generic;
using MySqlConnector;
using Planner.Model;

namespace Planner.Data
{
    public static class EventsDTO
    {
        private static readonly List<Event> _events = new();

        private static readonly MySqlConnectionStringBuilder connStrBuilder = new()
        {
            UserID = "sql11418815",
            Password = "ExK1zwX5gp",
            Server = "sql11.freemysqlhosting.net",
            Database = "sql11418815",
            Port = 3306
        };

        private static readonly MySqlConnection connection = new(connStrBuilder.ToString());

        public static void addEvent(Event @event)
        {
            var query = "INSERT INTO events (title, description, date, priority, user_id) VALUES " +
                        "('" + @event.Title + "', " +
                        "'" + @event.Description + "', " +
                        "'" + @event.Date.Date.ToString("yyyy-MM-dd") + "', " +
                        "'" + @event.Priority + "', " +
                        "1);";
            var command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static List<Event> getEventsForDate(DateTime dateTime)
        {
            var eventsForDate = new List<Event>();

            var query = "SELECT title, description, date, priority FROM events WHERE date = "
                        + "'" + dateTime.Date.ToString("yyyy-MM-dd") + "'";

            var command = new MySqlCommand(query, connection);
            connection.Open();
            var dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
                while (dataReader.Read())
                    eventsForDate.Add(new Event(dataReader["title"].ToString(),
                        dataReader["description"].ToString(),
                        (DateTime) dataReader["date"],
                        Enum.Parse<Priority>(dataReader["priority"].ToString()!)));
            connection.Close();

            return eventsForDate;
        }

        public static void deleteEvent(Event @event)
        {
            _events.RemoveAll(x => x.Equals(@event));
        }

        public static void editEvent(Event OldEvent, Event NewEvent)
        {
            _events.Remove(OldEvent);
            _events.Add(NewEvent);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows;
using MySqlConnector;
using Planner.Model;

namespace Planner.Data
{
    public static class EventsDTO
    {
        public static void addEvent(Event @event)
        {
            var query = "INSERT INTO events (title, description, date, priority, user_id) VALUES " +
                        "('" + @event.Title + "', " +
                        "'" + @event.Description + "', " +
                        "'" + @event.Date.Date.ToString("yyyy-MM-dd") + "', " +
                        "'" + @event.Priority + "', " +
                        "2);";
            MessageBox.Show(query);
            var command = new MySqlCommand(query, DatabaseConnector.connection);
            DatabaseConnector.connection.Open();
            command.ExecuteNonQuery();
            DatabaseConnector.connection.Close();
        }

        public static List<Event> getEventsForDate(DateTime dateTime)
        {
            var eventsForDate = new List<Event>();

            var query = "SELECT title, description, date, priority FROM events WHERE date = "
                        + "'" + dateTime.Date.ToString("yyyy-MM-dd") + "'";

            var command = new MySqlCommand(query, DatabaseConnector.connection);
            DatabaseConnector.connection.Open();
            var dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
                while (dataReader.Read())
                    eventsForDate.Add(new Event(dataReader["title"].ToString(),
                        dataReader["description"].ToString(),
                        (DateTime) dataReader["date"],
                        Enum.Parse<Priority>(dataReader["priority"].ToString()!)));
            DatabaseConnector.connection.Close();

            return eventsForDate;
        }

        public static void deleteEvent(Event @event)
        {
            var query = "DELETE FROM events WHERE " + 
                        "title = '" + @event.Title + "' AND " +
                        "description = '" + @event.Description + "' AND " +
                        "date = '" + @event.Date.Date.ToString("yyyy-MM-dd") + "' AND " +
                        "priority = '" + @event.Priority + "'";
            var command = new MySqlCommand(query, DatabaseConnector.connection);
            DatabaseConnector.connection.Open();
            command.ExecuteNonQuery();
            DatabaseConnector.connection.Close();
        }

        public static void editEvent(Event @OldEvent, Event @NewEvent)
        {
            var query = "UPDATE events " + 
                        "SET title = '" + @NewEvent.Title + "', " +
                        "description = '" + @NewEvent.Description + "', " +
                        "date = '" + @NewEvent.Date.Date.ToString("yyyy-MM-dd") + "', " +
                        "priority = '" + @NewEvent.Priority + "' " +
                        "WHERE " +
                        "title = '" + @OldEvent.Title + "' AND " +
                        "description = '" + @OldEvent.Description + "' AND " +
                        "date = '" + @OldEvent.Date.Date.ToString("yyyy-MM-dd") + "' AND " +
                        "priority = '" + @OldEvent.Priority + "'";
            var command = new MySqlCommand(query, DatabaseConnector.connection);
            DatabaseConnector.connection.Open();
            command.ExecuteNonQuery();
            DatabaseConnector.connection.Close();
        }
    }
}
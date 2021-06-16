using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows;
using MySqlConnector;
using Planner.Model;

namespace Planner.Data
{
    public static class EventsDTO
    {
        public static void addEvent(Event @event, string user)
        {
            var procedure = "CreateEventForUser";
            var command = new MySqlCommand(procedure, DatabaseConnector.ConnectionString);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("getTitle", @event.Title);
            command.Parameters.AddWithValue("getDescription", @event.Description);
            command.Parameters.AddWithValue("getDate", @event.Date);
            command.Parameters.AddWithValue("getPriority", @event.Priority.ToString());
            command.Parameters.AddWithValue("getLogin", user);
            DatabaseConnector.ConnectionString.Open();
            command.ExecuteNonQuery();
            DatabaseConnector.ConnectionString.Close();
        }

        public static List<Event> getEventsForDate(DateTime dateTime, string user)
        {
            var eventsForDate = new List<Event>();

            var procedure = "GetEventsByDateForUser";

            var command = new MySqlCommand(procedure, DatabaseConnector.ConnectionString);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("getLogin", user);
            command.Parameters.AddWithValue("getDate", dateTime.Date);
            
            DatabaseConnector.ConnectionString.Open();
            
            MySqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

             foreach (DataRow row in dataTable.Rows)
             {
                 eventsForDate.Add(new Event(
                     row["title"].ToString(),
                     row["description"].ToString(),
                     (DateTime)row["date"],
                     Enum.Parse<Priority>(row["priority"].ToString()!)));
             }

            DatabaseConnector.ConnectionString.Close();

            return eventsForDate;
        }

        public static void deleteEvent(Event @event, string user)
        {
            var procedure = "DeleteEventForUser";
            var command = new MySqlCommand(procedure, DatabaseConnector.ConnectionString);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("getTitle", @event.Title);
            command.Parameters.AddWithValue("getDescription", @event.Description);
            command.Parameters.AddWithValue("getDate", @event.Date);
            command.Parameters.AddWithValue("getPriority", @event.Priority.ToString());
            command.Parameters.AddWithValue("getLogin", user);
            
            DatabaseConnector.ConnectionString.Open();
            command.ExecuteNonQuery();
            DatabaseConnector.ConnectionString.Close();
        }

        public static void editEvent(Event @OldEvent, Event @NewEvent, string user)
        {
            var procedure = "EditEventForUser";
            var command = new MySqlCommand(procedure, DatabaseConnector.ConnectionString);
            command.CommandType = CommandType.StoredProcedure;
            // Old event params
            command.Parameters.AddWithValue("oldTitle", @OldEvent.Title);
            command.Parameters.AddWithValue("oldDescription", @OldEvent.Description);
            command.Parameters.AddWithValue("oldDate", @OldEvent.Date);
            command.Parameters.AddWithValue("oldPriority", @OldEvent.Priority.ToString());
            // New event params
            command.Parameters.AddWithValue("newTitle", @NewEvent.Title);
            command.Parameters.AddWithValue("newDescription", @NewEvent.Description);
            command.Parameters.AddWithValue("newDate", @NewEvent.Date);
            command.Parameters.AddWithValue("newPriority", @NewEvent.Priority.ToString());
            // Login
            command.Parameters.AddWithValue("getLogin", user);
            
            
            DatabaseConnector.ConnectionString.Open();
            command.ExecuteNonQuery();
            DatabaseConnector.ConnectionString.Close();
        }
    }
}
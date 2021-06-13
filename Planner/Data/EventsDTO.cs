using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;
using Planner.Model;

namespace Planner.Data
{
    public static class EventsDTO
    {
        private static List<Event> _events = new List<Event>();
        
        private static readonly MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder
        {
            UserID = "sql11418815",
            Password = "ExK1zwX5gp",
            Server = "sql11.freemysqlhosting.net",
            Database = "sql11418815",
            Port = 3306
        };
        private static readonly MySqlConnection connection = new MySqlConnection(connStrBuilder.ToString());

        // private static string ALL_COUNTRY_QUERY = "SELECT * FROM country";
        

        // public List<Country> GetAllCountries()
        // {
        //     List<Country> countries = new List<Country>();
        //     //connection powiązane będzie z bazą danych tylko w zakresie sekcji unsing i obiekt zostanie automatycznie usunięty poza tym zakresem
        //     using (connection = new MySqlConnection(connStrBuilder.ToString()))
        //     {
        //         MySqlCommand command = new MySqlCommand(ALL_COUNTRY_QUERY, connection);
        //         connection.Open();
        //         var dataReader=command.ExecuteReader();
        //         if (dataReader.HasRows)
        //         {
        //             while (dataReader.Read())
        //             {
        //                 countries.Add(new Country(dataReader["code"].ToString(),dataReader["name"].ToString(),(int)dataReader["population"]));
        //             }
        //         }
        //         else 
        //         {
        //             Console.WriteLine("Brak wyników zapytania");
        //         }
        //         connection.Close();
        //
        //     }
        //
        //
        //     return countries;//.ToArray();
        //          
        // }

        public static string test()
        {
            MySqlCommand command = new MySqlCommand("show tables", connection);
            connection.Open();
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                return dataReader[0].ToString();
            }

            return null;
        }
        
        
        public static void addEvent(Event @event)
        {
            _events.Add(@event);
        }
        

        public static List<Event> getEventsForDate(DateTime dateTime)
        {
            List<Event> eventsForDate = new List<Event>();
            string query = "SELECT title, description, date, priority FROM events WHERE date = '2021-06-13'";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            var dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    MessageBox.Show(dataReader["priority"].ToString());
                    eventsForDate.Add(new Event(dataReader["title"].ToString(),
                        dataReader["description"].ToString(),
                        (DateTime)dataReader["date"],
                        Enum.Parse<Priority>(dataReader["priority"].ToString()!)));
                }
            }
            return eventsForDate;
        }

        public static void deleteEvent(Event @event)
        {
            _events.RemoveAll(x => x.Equals(@event));
        }

        public static void editEvent(Event @OldEvent, Event @NewEvent)
        {
            _events.Remove(OldEvent);
            _events.Add(@NewEvent);
        }
    }
}
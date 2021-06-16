using System.Data;
using MySqlConnector;
using Planner.Model;

namespace Planner.Data
{
    public static class UsersDTO
    {
        public static bool checkIfUserExists(User user)
        {
            User existingUser = null;

            const string procedure = "GetUsersByLogin";
            var command = new MySqlCommand(procedure, DatabaseConnector.ConnectionString)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("getLogin", user.Login);
            DatabaseConnector.ConnectionString.Open();

            var dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
                while (dataReader.Read())
                    existingUser = new User(dataReader["login"].ToString(), dataReader["password"].ToString());

            DatabaseConnector.ConnectionString.Close();

            return existingUser != null && existingUser.Equals(user);
        }

        public static void CreateUser(User user)
        {
            const string procedure = "CreateUser";
            var command = new MySqlCommand(procedure, DatabaseConnector.ConnectionString)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("getLogin", user.Login);
            command.Parameters.AddWithValue("getPassword", user.Password);
            DatabaseConnector.ConnectionString.Open();
            command.ExecuteNonQuery();
            DatabaseConnector.ConnectionString.Close();
        }
    }
}
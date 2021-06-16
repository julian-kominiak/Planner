﻿using System.Windows;
using MySqlConnector;
using Planner.Model;

namespace Planner.Data
{
    public static class UsersDTO
    {
        public static bool checkIfUserExists(User @user)
        {
            User existingUser = null;
            var query = "CALL GetUsersByLogin('" +
                        @user.Login + "')";
            var command = new MySqlCommand(query, DatabaseConnector.ConnectionString);
            
            DatabaseConnector.ConnectionString.Open();
            var dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
                while (dataReader.Read())
                    existingUser = new User(dataReader["login"].ToString(), dataReader["password"].ToString());
            DatabaseConnector.ConnectionString.Close();
            
            return existingUser != null && existingUser.Equals(@user);
        }

        public static void CreateUser(User @user)
        {
            var query = "CALL CreateUser('" +
                        @user.Login + "', '" +
                        @user.Password + "')";
            var command = new MySqlCommand(query, DatabaseConnector.ConnectionString);
            DatabaseConnector.ConnectionString.Open();
            command.ExecuteNonQuery();
            DatabaseConnector.ConnectionString.Close();
        }
    }
}
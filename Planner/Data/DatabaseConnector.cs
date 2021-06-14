using MySqlConnector;

namespace Planner.Data
{
    public static class DatabaseConnector
    {
        private static readonly MySqlConnectionStringBuilder connStrBuilder = new()
        {
            UserID = "sql11418815",
            Password = "ExK1zwX5gp",
            Server = "sql11.freemysqlhosting.net",
            Database = "sql11418815",
            Port = 3306
        };
        public static readonly MySqlConnection connection = new(connStrBuilder.ToString());
    }
}
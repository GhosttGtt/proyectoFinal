using MySql.Data.MySqlClient;
using System.Configuration;

namespace POS.Database
{
    public static class DatabaseHelper
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            return new MySqlConnection(connectionString);
        }
    }
}
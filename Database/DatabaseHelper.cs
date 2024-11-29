using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
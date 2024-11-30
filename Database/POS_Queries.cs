using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Database
{
    internal class POS_Queries
    {
        public class LoginService
        {
            public static bool ValidateLogin(string username, string password)
            {
                string query = @" 
            SELECT EmployeeID FROM Employees WHERE Username = @username AND PasswordHash = SHA2(@password, 256);";

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        var result = command.ExecuteScalar();

                        return result != null;
                    }
                }
            }
        }
    }
}

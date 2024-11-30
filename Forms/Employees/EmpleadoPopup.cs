using MySql.Data.MySqlClient;
using POS.Database;
using POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.Employees
{
    public partial class EmpleadoPopup : Form
    {
        private int? EmployeeID;
        public EmpleadoPopup(int? customerId = null)
        {
            InitializeComponent();

            EmployeeID = customerId;
            if (EmployeeID.HasValue)
            {
                LoadEmpleado();
            }
        }
        private void LoadEmpleado()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT FirstName, LastName, Position, Username FROM Employees WHERE EmployeeID = @EmployeeID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        txtNombre.Text = reader["FirstName"].ToString();
                        txtApellido.Text = reader["LastName"].ToString();
                        txtPosition.Text = reader["Position"].ToString();
                        txtUsername.Text = reader["Username"].ToString();
                        
                    }
                }
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query;

                if (EmployeeID.HasValue)
                {
                    query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Position = @Position, Username = @Username WHERE EmployeeID = @EmployeeID";
                }
                else
                {
                    query = "INSERT INTO Employees (FirstName, LastName, Position, Username) VALUES ( @FirstName, @LastName, @Position, @Username)";
                }

                MySqlCommand command = new MySqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@FirstName", txtNombre.Text);
                command.Parameters.AddWithValue("@LastName", txtApellido.Text);
                command.Parameters.AddWithValue("@Position", txtPosition.Text);
                command.Parameters.AddWithValue("@Username", txtUsername.Text);
                
            
                if (EmployeeID.HasValue)
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                }

                command.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void EmpleadoPopup_Load(object sender, EventArgs e)
        {

        }
    }
}

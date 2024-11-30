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

namespace POS.Forms.Client
{
    public partial class ClientePopup : Form
    {
        private int? CustomerID;
        public ClientePopup(int? customerId = null)
        {
            InitializeComponent();
            CustomerID = customerId;
            if (CustomerID.HasValue)
            {
                LoadCliente();
            }
        }
        private void LoadCliente()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT NIT, FirstName, LastName, Address, Phone FROM Customers WHERE CustomerID = @CustomerID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNIT.Text = reader["NIT"].ToString();
                        txtNombre.Text = reader["FirstName"].ToString();
                        txtApellido.Text = reader["LastName"].ToString();
                        txtDireccion.Text = reader["Address"].ToString();
                        txtTelefono.Text = reader["Phone"].ToString();
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

                if (CustomerID.HasValue)
                {
                    query = "UPDATE Customers SET NIT = @NIT, FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone WHERE CustomerID = @CustomerID";
                }
                else
                {
                    query = "INSERT INTO Customers (NIT, FirstName, LastName, Address, Phone) VALUES (@NIT, @FirstName, @LastName, @Address, @Phone)";
                }

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NIT", txtNIT.Text);
                command.Parameters.AddWithValue("@FirstName", txtNombre.Text);
                command.Parameters.AddWithValue("@LastName", txtApellido.Text);
                command.Parameters.AddWithValue("@Address", txtDireccion.Text);
                command.Parameters.AddWithValue("@Phone", txtTelefono.Text);

                if (CustomerID.HasValue)
                {
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                }

                command.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ClientePopup_Load(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNIT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

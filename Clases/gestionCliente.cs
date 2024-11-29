using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace POS.Clases
{
    internal class gestionCliente
    {
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                ConnectDB connectDB = new ConnectDB();
                MySqlConnection connection = connectDB.connectON();

               
                string query = "SELECT NIT, FirstName, LastName, Address, Phone FROM u775758814_POS.Customers";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        NIT = reader["NIT"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Address = reader["Address"].ToString(),
                        Phone = reader["Phone"].ToString()
                    };
                    clientes.Add(cliente); 
                }

                connectDB.connectOFF(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener clientes: {ex.Message}");
            }

            return clientes; 
        }

        public void AgregarCliente(Cliente cliente)
        {
            try
            {
                ConnectDB connectDB = new ConnectDB();
                MySqlConnection connection = connectDB.connectON();

        
                string query = "INSERT INTO u775758814_POS.Customers (NIT, FirstName, LastName, Address, Phone) " +
                               "VALUES (@NIT, @FirstName, @LastName, @Address, @Phone)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NIT", cliente.NIT);
                command.Parameters.AddWithValue("@FirstName", cliente.FirstName);
                command.Parameters.AddWithValue("@LastName", cliente.LastName);
                command.Parameters.AddWithValue("@Address", cliente.Address);
                command.Parameters.AddWithValue("@Phone", cliente.Phone);

                command.ExecuteNonQuery();  

                connectDB.connectOFF(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cliente: {ex.Message}");
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            try
            {
                ConnectDB connectDB = new ConnectDB();
                MySqlConnection connection = connectDB.connectON();

          
                string query = "UPDATE u775758814_POS.Customers SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone " +
                               "WHERE NIT = @NIT";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NIT", cliente.NIT);
                command.Parameters.AddWithValue("@FirstName", cliente.FirstName);
                command.Parameters.AddWithValue("@LastName", cliente.LastName);
                command.Parameters.AddWithValue("@Address", cliente.Address);
                command.Parameters.AddWithValue("@Phone", cliente.Phone);

                command.ExecuteNonQuery();  

                connectDB.connectOFF(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}");
            }
        }

        public void EliminarCliente(string nit)
        {
            try
            {
                ConnectDB connectDB = new ConnectDB();
                MySqlConnection connection = connectDB.connectON();

                
                string query = "DELETE FROM u775758814_POS.Customers WHERE NIT = @NIT";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NIT", nit);

                command.ExecuteNonQuery();  

                connectDB.connectOFF();  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace POS.Clases
{
    internal class Products
    {
        public void mostrarProductos(DataGridView tablaProductos)
        {
            try
            {
                ConnectDB connect = new ConnectDB();

                string query = "SELECT ProductID AS ID, Code AS Código, Name AS Nombre, Description AS Descripción, Price AS Precio, Image FROM Products";

                tablaProductos.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connect.connectON());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaProductos.DataSource = dt;
                connect.connectOFF();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}");
            }
        }
    }
}
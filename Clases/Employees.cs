using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Clases
{
    internal class Employees
    {
        public void mostrarEmpleados(DataGridView tablaEmpleados) {
            try {
                ConnectDB connect = new ConnectDB();

                String query = "SELECT FirstName AS Nombre, LastName AS Apellido, Position AS Puesto FROM Employees";

                tablaEmpleados.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query,connect.connectON());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaEmpleados.DataSource = dt;
                connect.connectOFF();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos {ex}"); 
            }
        }
    }
}

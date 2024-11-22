
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Clases
{
    internal class ConnectDB
    {
        MySqlConnection connect = new MySqlConnection();

        static string server = "149.100.151.204";
        static string database = "u775758814_POS";
        static string user = "u775758814_USPG";
        static string pass = "UPU[DL!FI#m5";
        static string port = "3306";

        string connectdb = "server=" + server + ";" + "port=" + port + ";" + "user id=" + user + ";" + "password=" + pass + ";" + "Database=" + database + ";";

        public MySqlConnection connectON()
        {
            try
            {
                connect.ConnectionString = connectdb;
                connect.Open();
                MessageBox.Show("Conexion exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en conectarse a ${ex}");
            }
            return connect;
        }

        public void connectOFF()
        {
            connect.Close();
        }
    }


}

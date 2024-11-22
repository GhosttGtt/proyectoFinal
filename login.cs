using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS.Clases;

namespace POS
{
    public partial class login : Form
    {
        private ConnectDB dbConnection = new ConnectDB();
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (ValidateCredentials(username, password))
            {
                menu menuForm = new menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateCredentials(string username, string password)
        {
            bool isValid = false;
            MySqlConnection connection = dbConnection.connectON();

            try
            {
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); 

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                isValid = count > 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar credenciales: {ex.Message}");
            }

            return isValid;
        }
    
}
}

using System;
using System.Security.Cryptography;
using System.Text;
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
            string pass = textBox2.Text;
            string password = ComputeSha256Hash(pass);
     


            if (ValidateCredentials(username, password))
            {
                menu menuForm = new menu();
                //menu.Show();
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
                string query = "SELECT COUNT(*) FROM Employees WHERE Username = @username AND PasswordHash = @password";
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

}

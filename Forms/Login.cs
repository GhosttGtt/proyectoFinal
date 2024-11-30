using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using POS.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using static POS.Database.POS_Queries;

namespace POS.Forms.LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {
           
        }

       

        private void textUser_Enter(object sender, EventArgs e)
        {
            if (textUser.Text == "Usuario")
            {
                textUser.Text = "";
                textUser.ForeColor = Color.Black;
            }
        }
        private void textUser_Leave(object sender, EventArgs e)
        {
            if (textUser.Text == "")
            {
                textUser.Text = "Usuario";
                textUser.ForeColor = Color.Silver;
            }
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (textPassword.Text == "Password")
            {
                textPassword.Text = "";
                textPassword.ForeColor = Color.Black;
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (textPassword.Text == "")
            {
                textPassword.Text = "Password";
                textPassword.ForeColor = Color.Silver;
            }
        }

        private void textPassword_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUser.Text.Trim();
            string password = textPassword.Text.Trim();
            if (LoginService.ValidateLogin(username, password))
            {
               MessageBox.Show("¡Bienvenido!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
               this.Hide();
               FormHome mainForm = new FormHome(); 
               mainForm.Show();
             }
             else
             {
                MessageBox.Show($"Usuario o contraseña incorrectas:");
            }

        }




        Point mousedownpoint = Point.Empty;
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousedownpoint = new Point(e.X, e.Y);
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {

            if (mousedownpoint.IsEmpty)
                return;
            LoginForm f = sender as LoginForm;
            f.Location = new Point(f.Location.X + (e.X - mousedownpoint.X), f.Location.Y + (e.Y - mousedownpoint.Y));

        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            mousedownpoint = Point.Empty;
        }

        private void panelDrag_MouseDown(object sender, MouseEventArgs e)
        {
            LoginForm_MouseDown(this, e);
        }

        private void panelDrag_MouseUp(object sender, MouseEventArgs e)
        {
            LoginForm_MouseUp(this, e);
        }

        private void panelDrag_MouseMove(object sender, MouseEventArgs e)
        {
            LoginForm_MouseMove(this, e);
        }
    }
}

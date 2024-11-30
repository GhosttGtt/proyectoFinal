using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            msg info = new msg();
           info.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMenu menuForm = new FormMenu(1);
            menuForm.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menuForm = new FormMenu(2);
            menuForm.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menuForm = new FormMenu(3);
            menuForm.Show();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menuForm = new FormMenu(4);
            menuForm.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menuForm = new FormMenu(5);
            menuForm.Show();
        }
    }
}

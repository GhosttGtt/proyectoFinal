using POS.Forms.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class FormMenu : Form
    {
        public FormMenu(int status)
        {
            InitializeComponent();
         ;
            switch (status)
            {
                case 0:
                    Console.WriteLine("Tiene que cerrar");
                    this.Close();
                    break;
                case 1:
                    openFormContent(new FormProducto());
                    break;
                case 2:
                    openFormContent(new FormClientes());
                    break;
                case 3:
                    openFormContent(new FormEmpleados());
                    break;
                case 4:
                    openFormContent(new FormVentas());
                    break;
                case 5:
                    openFormContent(new FormHistorial());
                    break;
                default:
                    openFormContent(new FormProducto());
                    break;
            }
           
        }
        private Form activeForm = null;
        private void openFormContent(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelView.Controls.Add(childForm);
            panelView.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void panelView_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnProducto_Click(object sender, EventArgs e)
        {
            openFormContent(new FormProducto());
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            openFormContent(new FormClientes());
        }
        private void btnFactura_Click(object sender, EventArgs e)
        {
            openFormContent(new FormVentas());
        }
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            openFormContent(new FormEmpleados());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFormContent(new FormHistorial());
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

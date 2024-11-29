using System;
using System.Windows.Forms;
using POS.Clases;

namespace POS
{
    public partial class Form1 : Form
    {
        private gestionCliente gestionCliente = new gestionCliente();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = gestionCliente.ObtenerClientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nit = txtNIT.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;

            if (string.IsNullOrEmpty(nit) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Cliente cliente = new Cliente
            {
                NIT = nit,
                FirstName = nombre,
                LastName = apellido,
                Address = direccion,
                Phone = telefono
            };

            gestionCliente.AgregarCliente(cliente);
            CargarClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nit = txtNIT.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;

            if (string.IsNullOrEmpty(nit) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Cliente cliente = new Cliente
            {
                NIT = nit,
                FirstName = nombre,
                LastName = apellido,
                Address = direccion,
                Phone = telefono
            };

            gestionCliente.ActualizarCliente(cliente);
            CargarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nit = txtNIT.Text;

            if (string.IsNullOrEmpty(nit))
            {
                MessageBox.Show("Por favor, ingrese un NIT para eliminar el cliente.");
                return;
            }

            gestionCliente.EliminarCliente(nit) ;
            CargarClientes();
        }
    }
}
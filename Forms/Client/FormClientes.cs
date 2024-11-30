using MySql.Data.MySqlClient;
using POS.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.Client
{
    public partial class FormClientes : Form
    {
        private DataTable clientesTable;
        public FormClientes()
        {
            InitializeComponent();
            LoadClientes();

            txtBuscar.TextChanged += TxtBuscar_TextChanged;
        }
        private void LoadClientes()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT CustomerID, NIT, FirstName, LastName, Address, Phone FROM Customers";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                clientesTable = new DataTable();
                adapter.Fill(clientesTable);

                dataGridViewClientes.DataSource = clientesTable;

                // Ajustar columnas
                dataGridViewClientes.Columns["CustomerID"].Visible = false; // Ocultar ID
                dataGridViewClientes.Columns["NIT"].HeaderText = "NIT";
                dataGridViewClientes.Columns["FirstName"].HeaderText = "Nombre";
                dataGridViewClientes.Columns["LastName"].HeaderText = "Apellido";
                dataGridViewClientes.Columns["Address"].HeaderText = "Dirección";
                dataGridViewClientes.Columns["Phone"].HeaderText = "Teléfono";
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ClientePopup popup = new ClientePopup();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                LoadClientes();
            }
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtrar datos según el texto ingresado
            string filterText = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(filterText))
            {
                // Filtra por columnas relevantes
                clientesTable.DefaultView.RowFilter = string.Format(
                    "NIT LIKE '%{0}%' OR FirstName LIKE '%{0}%' OR LastName LIKE '%{0}%'",
                    filterText.Replace("'", "''")); // Escapar comillas simples
            }
            else
            {
                // Si no hay texto, muestra todos los datos
                clientesTable.DefaultView.RowFilter = string.Empty;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewClientes.SelectedRows[0];
                int customerId = Convert.ToInt32(row.Cells["CustomerID"].Value);

                ClientePopup popup = new ClientePopup(customerId);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    LoadClientes();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar.");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {

           
                if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewClientes.SelectedRows[0];
                int customerId = Convert.ToInt32(row.Cells["CustomerID"].Value);

                if (MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.ExecuteNonQuery();
                    }
                    LoadClientes();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
                }
            
        

        }
        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            FormMenu menuExit = new FormMenu(0);

            this.Close();
            FormHome menuForm = new FormHome();
            menuForm.Show();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            txtBuscar.Text = "";
        }
    }
}

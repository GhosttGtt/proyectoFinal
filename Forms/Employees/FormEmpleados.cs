using MySql.Data.MySqlClient;
using POS.Database;
using POS.Forms.Client;
using POS.Forms.Employees;
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
    public partial class FormEmpleados : Form
    {
        private DataTable empleadosTable;
        public FormEmpleados()
        {
            InitializeComponent();
            LoadEmpleados();

            txtBuscar.TextChanged += TxtBuscar_TextChanged;
        }

        private void LoadEmpleados()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT EmployeeID, FirstName, LastName, IdentificationNumber, Position, Username FROM Employees";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                empleadosTable = new DataTable();
                adapter.Fill(empleadosTable);

                dataGridViewEmpleados.DataSource = empleadosTable;

                // Ajustar columnas
                dataGridViewEmpleados.Columns["EmployeeID"].Visible = false; // Ocultar ID
                dataGridViewEmpleados.Columns["FirstName"].HeaderText = "Nombre";
                dataGridViewEmpleados.Columns["LastName"].HeaderText = "Apellido";
                dataGridViewEmpleados.Columns["IdentificationNumber"].HeaderText = "Identificación";
                dataGridViewEmpleados.Columns["Position"].HeaderText = "Puesto";
                dataGridViewEmpleados.Columns["Username"].HeaderText = "Usuario";
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EmpleadoPopup popup = new EmpleadoPopup();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                LoadEmpleados();
            }
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtrar datos según el texto ingresado
            string filterText = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(filterText))
            {
                // Filtra por columnas relevantes
                empleadosTable.DefaultView.RowFilter = string.Format(
                    "Username LIKE '%{0}%' OR FirstName LIKE '%{0}%' OR LastName LIKE '%{0}%' OR Position LIKE '%{0}%'",
                    filterText.Replace("'", "''")); // Escapar comillas simples
            }
            else
            {
                // Si no hay texto, muestra todos los datos
                empleadosTable.DefaultView.RowFilter = string.Empty;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewEmpleados.SelectedRows[0];
                int employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);

                if (MessageBox.Show("¿Está seguro de eliminar este Usuario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.ExecuteNonQuery();
                    }
                    LoadEmpleados();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
            }



        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHome menuForm = new FormHome();
            menuForm.Show();
        }

        private void lblTitleForm_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewEmpleados.SelectedRows[0];
                int employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);

                EmpleadoPopup popup = new EmpleadoPopup(employeeId);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    LoadEmpleados();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar.");
            }
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

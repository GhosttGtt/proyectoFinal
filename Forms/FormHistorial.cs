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

namespace POS.Forms
{
    public partial class FormHistorial : Form
    {
        public FormHistorial()
        {
            InitializeComponent();
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            LoadSalesData(); // Cargar todas las ventas al cargar el formulario
        }

        private void LoadSalesData(string filter = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                string query = @"
            SELECT 
                S.SaleID, 
                S.SaleDate, 
                C.FirstName AS 'Nombre Cliente', 
                C.LastName AS ApellidoCliente, 
                E.FirstName AS NombreVendedor, 
                E.LastName AS ApellidoVendedor, 
                S.Total
            FROM Sales S
            LEFT JOIN Customers C ON S.CustomerID = C.CustomerID
            LEFT JOIN Employees E ON S.EmployeeID = E.EmployeeID
            WHERE 
                (@Filter = '' OR C.FirstName LIKE @Filter OR E.FirstName LIKE @Filter OR C.LastName LIKE @Filter OR E.LastName LIKE @Filter)
                AND (@StartDate IS NULL OR S.SaleDate >= @StartDate)
                AND (@EndDate IS NULL OR S.SaleDate <= @EndDate)
            ORDER BY S.SaleDate DESC;";

                MySqlCommand command = new MySqlCommand(query, connection);

         
                command.Parameters.AddWithValue("@Filter", "%" + filter + "%");

           
                if (startDate.HasValue)
                {
                    command.Parameters.AddWithValue("@StartDate", startDate.Value.Date);
                }
                else
                {
                    command.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }

                if (endDate.HasValue)
                {
                    command.Parameters.AddWithValue("@EndDate", endDate.Value.Date);
                }
                else
                {
                    command.Parameters.AddWithValue("@EndDate", DBNull.Value);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable salesTable = new DataTable();
                adapter.Fill(salesTable);

                dataGridViewSales.DataSource = salesTable;
            }
        }

        // Buscar por nombre de cliente o empleado
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            DateTime? startDate = dateTimePickerStart.Checked ? (DateTime?)dateTimePickerStart.Value : null;
            DateTime? endDate = dateTimePickerEnd.Checked ? (DateTime?)dateTimePickerEnd.Value : null;

            LoadSalesData(filter, startDate, endDate); // Cargar los datos filtrados
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHome menuForm = new FormHome();
            menuForm.Show();
        }

        
    }
}

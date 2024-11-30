using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS.Database;

namespace POS.Forms
{
    public partial class FormVentas : Form
    {
        private int? clienteId = null; // Null indica "Consumidor Final"
        private decimal total = 0;
        public FormVentas()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT ProductID, Name, Price, Stock FROM Products WHERE Stock > 0";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridViewProductos.DataSource = table;
            }
        }

        private void BuscarCliente(string criterio)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT CustomerID, CONCAT(FirstName, ' ', LastName) AS Nombre FROM Customers WHERE NIT LIKE @criterio OR FirstName LIKE @criterio";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@criterio", "%" + criterio + "%");

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        clienteId = reader.GetInt32("CustomerID");
                        lblCliente.Text = reader.GetString("Nombre");
                    }
                    else
                    {
                        clienteId = null;
                        lblCliente.Text = "Consumidor Final";
                    }
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente(txtBuscarCliente.Text);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                var row = dataGridViewProductos.SelectedRows[0];
                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                string nombre = row.Cells["Name"].Value.ToString();
                decimal precio = Convert.ToDecimal(row.Cells["Price"].Value);
                int stock = Convert.ToInt32(row.Cells["Stock"].Value);

                if (stock <= 0)
                {
                    MessageBox.Show("Producto sin stock disponible.");
                    return;
                }

                dataGridViewCarrito.Rows.Add(productId, nombre, precio, 1, precio);
                total += precio;
                lblTotal.Text = $"Total: {total:C}";
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar venta
                        string insertSaleQuery = "INSERT INTO Sales (SaleDate, CustomerID, EmployeeID, Total) VALUES (NOW(), @CustomerID, @EmployeeID, @Total)";
                        MySqlCommand saleCommand = new MySqlCommand(insertSaleQuery, connection, transaction);

                        // Si no hay cliente seleccionado, facturar como "Consumidor Final"
                        if (clienteId.HasValue)
                        {
                            saleCommand.Parameters.AddWithValue("@CustomerID", clienteId.Value);
                        }
                        else
                        {
                            saleCommand.Parameters.AddWithValue("@CustomerID", DBNull.Value);
                        }

                        saleCommand.Parameters.AddWithValue("@EmployeeID", 1); // Usuario actual
                        saleCommand.Parameters.AddWithValue("@Total", total);
                        saleCommand.ExecuteNonQuery();

                        int saleId = (int)saleCommand.LastInsertedId;

                        // Insertar detalles de la venta
                        foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
                        {
                            int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);

                            string insertDetailQuery = "INSERT INTO SaleDetails (SaleID, ProductID, Quantity, UnitPrice) VALUES (@SaleID, @ProductID, @Quantity, @UnitPrice)";
                            MySqlCommand detailCommand = new MySqlCommand(insertDetailQuery, connection, transaction);
                            detailCommand.Parameters.AddWithValue("@SaleID", saleId);
                            detailCommand.Parameters.AddWithValue("@ProductID", productId);
                            detailCommand.Parameters.AddWithValue("@Quantity", cantidad);
                            detailCommand.Parameters.AddWithValue("@UnitPrice", precio);
                            detailCommand.ExecuteNonQuery();

                            // Actualizar stock
                            string updateStockQuery = "UPDATE Products SET Stock = Stock - @Quantity WHERE ProductID = @ProductID";
                            MySqlCommand stockCommand = new MySqlCommand(updateStockQuery, connection, transaction);
                            stockCommand.Parameters.AddWithValue("@Quantity", cantidad);
                            stockCommand.Parameters.AddWithValue("@ProductID", productId);
                            stockCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Venta registrada con éxito.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error al facturar: {ex.Message}");
                    }
                }
            }
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
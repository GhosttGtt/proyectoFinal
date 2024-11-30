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
        private DataTable carrito;
        public FormVentas()
        {
            InitializeComponent();            
            LoadClientes();
            LoadProductos();
            InitializeCarrito();
        }
        private void InitializeCarrito()
        {
            carrito = new DataTable();
            carrito.Columns.Add("ProductID", typeof(int));
            carrito.Columns.Add("Name", typeof(string));
            carrito.Columns.Add("Quantity", typeof(int));
            carrito.Columns.Add("UnitPrice", typeof(decimal));
            carrito.Columns.Add("TotalPrice", typeof(decimal));
            dataGridViewCarrito.DataSource = carrito;
        }
        private void LoadClientes()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT CustomerID, CONCAT(FirstName, ' ', LastName) AS FullName FROM Customers";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                comboBoxClientes.DataSource = table;
                comboBoxClientes.DisplayMember = "FullName";
                comboBoxClientes.ValueMember = "CustomerID";
            }
        }



        private void LoadProductos()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT ProductID, ImagePath, Name, Price, Stock FROM Products WHERE Stock > 0";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridViewProductos.DataSource = table;

                if (dataGridViewProductos.Columns["Image"] == null)
                {
                    DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                    imgColumn.Name = "Image";
                    imgColumn.HeaderText = "Imagen";
                    imgColumn.ImageLayout = DataGridViewImageCellLayout.NotSet;
                    dataGridViewProductos.Columns.Add(imgColumn);
                }

                dataGridViewProductos.Columns["ImagePath"].Visible = false;

                string startupPath = Application.StartupPath;
                string startupPath2 = Path.GetDirectoryName(startupPath);
                string basePath = Path.GetDirectoryName(startupPath2) + @"\";

                foreach (DataGridViewRow row in dataGridViewProductos.Rows)
                {

                    if (row.Cells["ImagePath"].Value != DBNull.Value && row.Cells["ImagePath"].Value != null)
                    {
                        string imagePath = row.Cells["ImagePath"].Value.ToString();
                        string fullImagePath = basePath + imagePath;

                        Console.WriteLine(fullImagePath);

                        if (!string.IsNullOrEmpty(fullImagePath) && System.IO.File.Exists(fullImagePath))
                        {
                            try
                            {
                                row.Cells["Image"].Value = Image.FromFile(fullImagePath);
                            }
                            catch (Exception)
                            {
                       
                                row.Cells["Image"].Value = Properties.Resources.DefaultImage;  
                            }
                        }
                        else
                        {
                            
                            row.Cells["Image"].Value = Properties.Resources.DefaultImage; 
                        }
                    }
                    else
                    {
                        
                        row.Cells["Image"].Value = Properties.Resources.DefaultImage; 
                    }
                }
            }
        }








        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            {
                if (dataGridViewProductos.SelectedRows.Count > 0)
                {
                    var row = dataGridViewProductos.SelectedRows[0];
                    int productID = (int)row.Cells["ProductID"].Value;
                    string name = row.Cells["Name"].Value.ToString();
                    decimal price = (decimal)row.Cells["Price"].Value;
                    int quantity = (int)numericUpDownCantidad.Value;

                    if (quantity > 0)
                    {
                        decimal totalPrice = price * quantity;
                        carrito.Rows.Add(productID, name, quantity, price, totalPrice);
                        UpdateTotal();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad debe ser mayor a 0.");
                    }
                }
            }
        }
        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in carrito.Rows)
            {
                total += (decimal)row["TotalPrice"];
            }
            lblTotal.Text = $"Total: {total:C2}";
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            {
                if (comboBoxClientes.SelectedValue == null || carrito.Rows.Count == 0)
                {
                    MessageBox.Show("Seleccione un cliente y agregue productos al carrito.");
                    return;
                }

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            
                            string insertVentaQuery = "INSERT INTO Sales (SaleDate, CustomerID, EmployeeID, Total) VALUES (@SaleDate, @CustomerID, @EmployeeID, @Total)";
                            using (var command = new MySqlCommand(insertVentaQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                                command.Parameters.AddWithValue("@CustomerID", comboBoxClientes.SelectedValue);
                                command.Parameters.AddWithValue("@EmployeeID", 1); // Cambiar por ID del usuario actual
                                command.Parameters.AddWithValue("@Total", carrito.Compute("SUM(TotalPrice)", string.Empty));

                                
                                command.ExecuteNonQuery();

                               
                                var saleID = command.LastInsertedId;
                            
                            foreach (DataRow row in carrito.Rows)
                            {
                                int productID = (int)row["ProductID"];
                                int quantity = (int)row["Quantity"];
                                decimal unitPrice = (decimal)row["UnitPrice"];

                               
                                string insertDetalleQuery = "INSERT INTO SaleDetails (SaleID, ProductID, Quantity, UnitPrice) VALUES (@SaleID, @ProductID, @Quantity, @UnitPrice)";
                                using (var detalleCommand = new MySqlCommand(insertDetalleQuery, connection, transaction))
                                {
                                    detalleCommand.Parameters.AddWithValue("@SaleID", saleID);
                                    detalleCommand.Parameters.AddWithValue("@ProductID", productID);
                                    detalleCommand.Parameters.AddWithValue("@Quantity", quantity);
                                    detalleCommand.Parameters.AddWithValue("@UnitPrice", unitPrice);
                                    detalleCommand.ExecuteNonQuery();
                                }

                           
                                string updateStockQuery = "UPDATE Products SET Stock = Stock - @Quantity WHERE ProductID = @ProductID";
                                using (var stockCommand = new MySqlCommand(updateStockQuery, connection, transaction))
                                {
                                    stockCommand.Parameters.AddWithValue("@Quantity", quantity);
                                    stockCommand.Parameters.AddWithValue("@ProductID", productID);
                                    stockCommand.ExecuteNonQuery();
                                }
                            }

                          
                            transaction.Commit();
                            MessageBox.Show("Venta realizada exitosamente.");
                            carrito.Clear();
                            UpdateTotal();
                            LoadProductos();
                        }
                        }
                        catch (Exception ex)
                        {
                           
                            transaction.Rollback();
                            MessageBox.Show($"Error al realizar la venta: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHome menuForm = new FormHome();
            menuForm.Show();
        }
    }

}

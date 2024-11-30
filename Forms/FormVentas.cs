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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace POS.Forms
{
    
    public partial class FormVentas : Form
    {
        private List<Models.Product> cart = new List<Models.Product>(); // Lista de productos en el carrito.
        private decimal total = 0; // Total acumulado.

        private int? clienteId = null; // Null indica "Consumidor Final"
       
        public FormVentas()
        {
            InitializeComponent();
            this.Load += FormVentas_Load;
        }
        private void FormVentas_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            SearchProducts("");
        }
        
        private void ConfigureDataGridView()
        {
            dataGridViewProducts.Columns.Clear(); // Limpia columnas anteriores, si existen.
            dataGridViewProducts.Columns.Add("ProductID", "ID");
            dataGridViewProducts.Columns.Add("Name", "Nombre");
            dataGridViewProducts.Columns.Add("Price", "Precio");
            dataGridViewProducts.Columns.Add("Stock", "Stock");
            dataGridViewProducts.Columns.Add("ImagePath", "Ruta de Imagen");
        }
        private void SearchProducts(string query)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string sql = "SELECT ProductID, Name, Price, Stock, ImagePath FROM Products WHERE Name LIKE @Query OR ProductID LIKE @Query";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Query", "%" + query + "%"); // Búsqueda parcial.

                MySqlDataReader reader = command.ExecuteReader();
                dataGridViewProducts.Rows.Clear(); // Limpia resultados anteriores.

                while (reader.Read())
                {
                    int productID = reader.GetInt32("ProductID");
                    string name = reader.GetString("Name");
                    decimal price = reader.GetDecimal("Price");
                    int stock = reader.GetInt32("Stock");
                    string imagePath = reader.GetString("ImagePath");

                    // Agrega una fila con los datos recuperados.
                    dataGridViewProducts.Rows.Add(productID, name, price, stock, imagePath);
                }
            }
        }
        private void AddToCart(int productID)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string sql = "SELECT ProductID, Name, Price, Stock, ImagePath FROM Products WHERE ProductID = @ProductID";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ProductID", productID);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int stock = reader.GetInt32("Stock");

                    if (stock > 0)
                    {
                        Product product = new Product
                        {
                            ProductID = reader.GetInt32("ProductID"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetDecimal("Price"),
                            Stock = reader.GetInt32("Stock"),
                            ImagePath = reader.GetString("ImagePath")
                        };

                        cart.Add(product);
                        total += product.Price;

                        UpdateCartView();
                    }
                    else
                    {
                        MessageBox.Show("El producto está agotado.");
                    }
                }
            }
        }
        private void UpdateCartView()
        {
            dataGridViewCart.Rows.Clear();

            foreach (var product in cart)
            {
                Image image = null;
                if (File.Exists(product.ImagePath))
                {
                    image = Image.FromFile(product.ImagePath);
                }

                dataGridViewCart.Rows.Add(product.ProductID, product.Name, product.Price, image);
            }

            lblTotal.Text = "Total: Q" + total.ToString("0.00");
        }

        private void PerformSale(string nit)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Insertar la venta
                string insertSaleQuery = "INSERT INTO Sales (CustomerNIT, SaleDate, Total) VALUES (@CustomerNIT, @SaleDate, @Total)";
                MySqlCommand command = new MySqlCommand(insertSaleQuery, connection);
                command.Parameters.AddWithValue("@CustomerNIT", nit);
                command.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                command.Parameters.AddWithValue("@Total", total);

                command.ExecuteNonQuery();
                int saleID = (int)command.LastInsertedId;

                // Insertar los detalles de la venta
                foreach (var product in cart)
                {
                    string insertSaleDetailQuery = "INSERT INTO SaleDetails (SaleID, ProductID, Quantity, UnitPrice) VALUES (@SaleID, @ProductID, @Quantity, @UnitPrice)";
                    MySqlCommand detailCommand = new MySqlCommand(insertSaleDetailQuery, connection);
                    detailCommand.Parameters.AddWithValue("@SaleID", saleID);
                    detailCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                    detailCommand.Parameters.AddWithValue("@Quantity", 1);
                    detailCommand.Parameters.AddWithValue("@UnitPrice", product.Price);

                    detailCommand.ExecuteNonQuery();

                    // Actualizar el inventario
                    string updateStockQuery = "UPDATE Products SET Stock = Stock - 1 WHERE ProductID = @ProductID";
                    MySqlCommand updateCommand = new MySqlCommand(updateStockQuery, connection);
                    updateCommand.Parameters.AddWithValue("@ProductID", product.ProductID);

                    updateCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Venta realizada exitosamente.");
                ResetForm();
            }
        }

        private void ResetForm()
        {
            cart.Clear();
            total = 0;
            UpdateCartView();
            txtSearchProduct.Clear();
            txtCustomerNIT.Clear();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearchProduct.Text.Trim();
            SearchProducts(query);
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                int productID = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value);
                AddToCart(productID);
            }
            else
            {
                MessageBox.Show("Seleccione un producto para agregar.");
            }
        }

        private void btnPerformSale_Click(object sender, EventArgs e)
        {
            string nit = txtCustomerNIT.Text.Trim();

            if (string.IsNullOrEmpty(nit))
            {
                MessageBox.Show("Ingrese un NIT válido o 'CF' para consumidor final.");
                return;
            }

            PerformSale(nit);
        }



        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
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
            LoadEmployees();
            this.txtSearchProduct = new System.Windows.Forms.TextBox(); this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);

        }
        private void LoadEmployees()
        {
            // Limpiar el ComboBox antes de llenarlo
            cmbEmployees.Items.Clear();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // Obtener la lista de empleados
                string query = "SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS FullName FROM Employees";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                // Llenar el ComboBox con los empleados
                while (reader.Read())
                {
                    cmbEmployees.Items.Add(new KeyValuePair<int, string>(
                        reader.GetInt32("EmployeeID"),
                        reader.GetString("FullName")
                    ));
                }

                // Establecer un valor predeterminado (si es necesario)
                if (cmbEmployees.Items.Count > 0)
                {
                    cmbEmployees.SelectedIndex = 0;
                }
            }
        }
        private void FormVentas_Load(object sender, EventArgs e)
        {
            
            ConfigureCartDataGridView();
            InitializeCartGridView();
            SearchProducts("");

        }
        
        private void InitializeCartGridView()
        {
            dataGridViewProducts.Columns.Clear(); // Limpia columnas anteriores, si existen.
            dataGridViewProducts.Columns.Add("ProductID", "ID");
            dataGridViewProducts.Columns.Add("Name", "Nombre");
            dataGridViewProducts.Columns.Add("Price", "Precio");
            dataGridViewProducts.Columns.Add("Stock", "Stock");
            dataGridViewProducts.Columns.Add("ImagePath", "Ruta de Imagen");
        }
        private void ConfigureCartDataGridView()
        {
            dataGridViewCart.Columns.Clear(); // Limpia columnas anteriores.
            dataGridViewCart.Columns.Add("ProductID", "ID");
            dataGridViewCart.Columns.Add("Name", "Producto");
            dataGridViewCart.Columns.Add("Price", "Precio");
            dataGridViewCart.Columns.Add("Quantity", "Cantidad");
            dataGridViewCart.Columns.Add("Total", "Total");

            // Asegúrate de que no se agreguen filas automáticamente.
            dataGridViewCart.AutoGenerateColumns = false;
        }
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearchProduct.Text.Trim();

            // Si no hay texto en el campo de búsqueda, cargamos todos los productos
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadProducts();
                return;
            }

            // Filtramos productos por ID o nombre
            SearchProducts(searchTerm);
        }
        private void LoadProducts()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    connection.Open();
                    string sql = "SELECT ProductID, Name, Price, Stock, ImagePath FROM Products WHERE Name LIKE @Query OR ProductID LIKE @Query";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignamos el DataTable al DataGridView
                    dataGridViewProducts.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void AddToCart(int productID, int quantity)
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

                    // Verifica que haya suficiente stock
                    if (stock >= quantity)
                    {
                        Models.Product product = new Models.Product
                        {
                            ProductID = reader.GetInt32("ProductID"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetDecimal("Price"),
                            Stock = reader.GetInt32("Stock"),
                            ImagePath = reader.GetString("ImagePath")
                        };

                        // Verifica si el producto ya está en el carrito
                        var existingProduct = cart.FirstOrDefault(item => item.ProductID == product.ProductID);

                        if (existingProduct != null)
                        {
                            // Si el producto ya está en el carrito, actualiza la cantidad
                            existingProduct.Quantity += quantity;
                        }
                        else
                        {
                            // Si el producto no está en el carrito, agrégalo con la cantidad seleccionada
                            product.Quantity = quantity;
                            cart.Add(product);
                        }

                        // Actualiza el total acumulado del carrito
                        total += product.Price * quantity;

                        UpdateCartView();
                    }
                    else
                    {
                        MessageBox.Show("No hay suficiente stock disponible.");
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.");
                }
            }
        }
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado una fila en el DataGridView
            if (dataGridViewCart.SelectedRows.Count > 0)
            {
                // Obtiene el ID del producto de la fila seleccionada
                int productID = Convert.ToInt32(dataGridViewCart.SelectedRows[0].Cells[0].Value);

                // Busca el producto en el carrito
                var productToRemove = cart.FirstOrDefault(p => p.ProductID == productID);

                if (productToRemove != null)
                {
                    // Elimina el producto del carrito
                    cart.Remove(productToRemove);

                    // Actualiza el total del carrito
                    total -= productToRemove.Price * productToRemove.Quantity;

                    // Actualiza la vista del carrito
                    UpdateCartView();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
            }
        }
        private void UpdateCartView()
        {
            dataGridViewCart.Rows.Clear();

            if (cart == null || cart.Count == 0)
            {
                lblTotal.Text = "Total: $0.00";
                return;
            }

            foreach (var item in cart)
            {
                if (item == null) continue;

                dataGridViewCart.Rows.Add(
                    item.ProductID,
                    item.Name ?? "N/A",
                    item.Price.ToString("C"),
                    item.Quantity,
                    (item.Price * item.Quantity).ToString("C")
                );
            }

            decimal total = cart.Sum(item => item?.Price * item?.Quantity ?? 0);
            lblTotal.Text = $"Total: {total:C}";
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

                // Iniciar una transacción
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int customerID;

                    // Verificar si es venta a cliente CF
                    if (nit.ToUpper() == "CF")
                    {
                        
                        string getCFQuery = "SELECT CustomerID FROM Customers WHERE NIT = 'CF'";
                        MySqlCommand getCFCommand = new MySqlCommand(getCFQuery, connection);
                        object cfIDObj = getCFCommand.ExecuteScalar();

                        if (cfIDObj == null)
                        {
                            MessageBox.Show("El cliente CF no está registrado en la base de datos.");
                            return;
                        }

                        customerID = Convert.ToInt32(cfIDObj);
                    }
                    else
                    {
                        // Obtener el CustomerID del cliente basado en el NIT ingresado
                        string getCustomerQuery = "SELECT CustomerID FROM Customers WHERE NIT = @NIT";
                        MySqlCommand getCustomerCommand = new MySqlCommand(getCustomerQuery, connection);
                        getCustomerCommand.Parameters.AddWithValue("@NIT", nit);
                        object customerIDObj = getCustomerCommand.ExecuteScalar();

                        if (customerIDObj == null)
                        {
                            MessageBox.Show("Cliente no encontrado. Por favor, registre al cliente antes de continuar.");
                            return; // Salir si el cliente no existe
                        }

                        customerID = Convert.ToInt32(customerIDObj);
                    }

                    // Obtener el EmployeeID del ComboBox
                    if (cmbEmployees.SelectedItem == null)
                    {
                        MessageBox.Show("Seleccione un empleado.");
                        return;
                    }

                    var selectedEmployee = (KeyValuePair<int, string>)cmbEmployees.SelectedItem;
                    int employeeID = selectedEmployee.Key;

                    // Insertar la venta
                    string insertSaleQuery = "INSERT INTO Sales (CustomerID, SaleDate, Total, EmployeeID) VALUES (@CustomerID, @SaleDate, @Total, @EmployeeID)";
                    MySqlCommand command = new MySqlCommand(insertSaleQuery, connection, transaction);
                    command.Parameters.AddWithValue("@CustomerID", customerID);
                    command.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Total", total);
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    command.ExecuteNonQuery();
                    int saleID = (int)command.LastInsertedId;

                    // Insertar los detalles de la venta
                    foreach (var product in cart)
                    {
                        string insertSaleDetailQuery = "INSERT INTO SaleDetails (SaleID, ProductID, Quantity, UnitPrice) VALUES (@SaleID, @ProductID, @Quantity, @UnitPrice)";
                        MySqlCommand detailCommand = new MySqlCommand(insertSaleDetailQuery, connection, transaction);
                        detailCommand.Parameters.AddWithValue("@SaleID", saleID);
                        detailCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                        detailCommand.Parameters.AddWithValue("@Quantity", product.Quantity); // Usar la cantidad en el carrito
                        detailCommand.Parameters.AddWithValue("@UnitPrice", product.Price);

                        detailCommand.ExecuteNonQuery();

                        // Actualizar el inventario
                        string updateStockQuery = "UPDATE Products SET Stock = Stock - @Quantity WHERE ProductID = @ProductID";
                        MySqlCommand updateCommand = new MySqlCommand(updateStockQuery, connection, transaction);
                        updateCommand.Parameters.AddWithValue("@Quantity", product.Quantity);
                        updateCommand.Parameters.AddWithValue("@ProductID", product.ProductID);

                        updateCommand.ExecuteNonQuery();
                    }

                    // Confirmar la transacción
                    transaction.Commit();

                    MessageBox.Show("Venta realizada exitosamente.");
                    ResetForm();
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, revertir la transacción
                    transaction.Rollback();
                    MessageBox.Show("Error al realizar la venta: " + ex.Message);
                }
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

      

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            
            // Verifica que un producto esté seleccionado en el DataGridView
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                int productID = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value);

                // Verifica si la cantidad ingresada es válida
                if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                {
                    // Llama a la función AddToCart y pasa la cantidad
                    AddToCart(productID, quantity);
                    txtQuantity.Text = "0";
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad válida mayor que 0.");
                }
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHome menuForm = new FormHome();
            menuForm.Show();
        }
    }
}
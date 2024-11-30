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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.IO;
using POS.Forms.Product;

namespace POS.Forms
{
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
            LoadProductos();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            
            FormMenu menuExit = new FormMenu(0);
      
            this.Close();
            FormHome menuForm = new FormHome();
            menuForm.Show();
        }
        
        private void LoadProductos()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT ProductID, Code, Name, Description, Price, Stock, ImagePath FROM Products";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridViewProductos.DataSource = table;
                dataGridViewProductos.Columns["ImagePath"].Visible = false; // Ocultar la columna de ruta
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormPopupProducto popup = new FormPopupProducto();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                LoadProductos();
            }
        }



        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                // Obtener los datos seleccionados
                DataGridViewRow selectedRow = dataGridViewProductos.SelectedRows[0];
                string productId = selectedRow.Cells["ProductID"].Value.ToString();
                string productName = selectedRow.Cells["Name"].Value.ToString();
                string productDescription = selectedRow.Cells["Description"].Value.ToString();
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                int stock = Convert.ToInt32(selectedRow.Cells["Stock"].Value);
                string imagePath = selectedRow.Cells["ImagePath"].Value.ToString();

                // Abrir el popup
                using (ProductEditPopup popup = new ProductEditPopup(productId, productName, productDescription, price, stock, imagePath))
                {
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        // Recargar datos después de la edición
                        LoadProductos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("¿Estas seguro de querer eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            {
                if (dataGridViewProductos.SelectedRows.Count > 0)
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        string query = "DELETE FROM Products WHERE ProductID = @productID";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            var row = dataGridViewProductos.SelectedRows[0];
                            int productID = (int)row.Cells["ProductID"].Value;

                            command.Parameters.AddWithValue("@productID", productID);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Producto eliminado exitosamente.");
                            LoadProductos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un producto.");
                }
            }

            else

            {
                
            }

            
            
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }
    }
}

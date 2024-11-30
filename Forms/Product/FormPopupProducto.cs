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
using MySql.Data.MySqlClient;
using POS.Database;
using System.IO;

namespace POS.Forms.Product
{
    public partial class FormPopupProducto : Form
    {
        private int? productID;
        public FormPopupProducto()
        {
            InitializeComponent();
        }
        public FormPopupProducto(int productID, string code, string name, string description, decimal price, int stock, string imagePath) : this()
        {
            this.productID = productID;
            txtCode.Text = code;
            txtName.Text = name;
            txtDescription.Text = description;
            txtPrice.Text = price.ToString();
            txtStock.Text = stock.ToString();
            if (File.Exists(imagePath))
            {
                pictureBoxProducto.ImageLocation = imagePath;
            }

        }
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Archivos de imagen (*.jpg;*.png)|*.jpg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxProducto.ImageLocation = dialog.FileName;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                string query = productID == null
                    ? @"INSERT INTO Products (Code, Name, Description, Price, Stock, ImagePath) 
                   VALUES (@code, @name, @description, @price, @stock, @imagePath)"
                    : @"UPDATE Products 
                   SET Code = @code, Name = @name, Description = @description, Price = @price, 
                       Stock = @stock, ImagePath = @imagePath
                   WHERE ProductID = @productID";

                using (var command = new MySqlCommand(query, connection))
                {
                    if (productID != null)
                    {
                        command.Parameters.AddWithValue("@productID", productID);
                    }
                    command.Parameters.AddWithValue("@code", txtCode.Text);
                    command.Parameters.AddWithValue("@name", txtName.Text);
                    command.Parameters.AddWithValue("@description", txtDescription.Text);
                    command.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
                    command.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
                    command.Parameters.AddWithValue("@imagePath", pictureBoxProducto.ImageLocation ?? string.Empty);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Producto guardado exitosamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPopupClientes_Load(object sender, EventArgs e)
        {

        }
    }
}

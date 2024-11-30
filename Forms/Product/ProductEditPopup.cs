using MySql.Data.MySqlClient;
using POS.Database;
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
using System.Xml.Linq;

namespace POS.Forms.Product
{

    public partial class ProductEditPopup : Form

    {
        public string ProductId { get; private set; }
        public string productName => txtName.Text;
        public string ProductDescription => txtDescription.Text;
        public decimal Price => numPrice.Value;
        public int Stock => (int)numStock.Value;
        public string ImagePath { get; private set; }

        public ProductEditPopup(string productId, string productName, string productDescription, decimal price, int stock, string imagePath)
        {
            InitializeComponent();
            ProductId = productId;
            txtName.Text = productName;
            txtDescription.Text = productDescription;
            numPrice.Value = price;
            numStock.Value = stock;
            ImagePath = imagePath;

            if (File.Exists(imagePath))
            {
                pictureBoxImage.Image = Image.FromFile(imagePath);
            }
        }
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImagePath = openFileDialog.FileName;
                    pictureBoxImage.Image = Image.FromFile(ImagePath);
                }
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                SaveProduct();
                DialogResult = DialogResult.OK;
               
                Close();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numStock.Value < 0)
            {
                MessageBox.Show("El stock no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }

        private void SaveProduct()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, Stock = @Stock, ImagePath = @ImagePath WHERE ProductID = @ProductID";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@Price", numPrice.Value);
                    command.Parameters.AddWithValue("@Stock", numStock.Value);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    command.Parameters.AddWithValue("@ProductID", ProductId);
                    command.ExecuteNonQuery();
                }
            }
            
        }


        

        private void ProductEditPopup_Load(object sender, EventArgs e)
        {

        }
    }
}

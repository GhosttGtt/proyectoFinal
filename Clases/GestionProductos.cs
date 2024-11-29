using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace POS.Clases
{
    internal class GestionProductos
    {
        public void AgregarProducto(Product producto)
        {
            ConnectDB conexion = new ConnectDB();
            try
            {

                string query = "INSERT INTO u775758814_POS.Products (code, Name, Description, Price, Stock, ImagePath) " +
                               "VALUES (@code, @Name, @Descripcion, @Price, @Stock, @ImagePath)";
                MySqlCommand cmd = new MySqlCommand(query, conexion.connectON());

                cmd.Parameters.AddWithValue("@code", producto.Code);
                cmd.Parameters.AddWithValue("@Name", producto.Name);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Description);
                cmd.Parameters.AddWithValue("@Price", producto.Price);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.Parameters.AddWithValue("@ImagePath", producto.ImagePath); 

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}");
            }
            finally
            {
                conexion.connectOFF();
            }
        }

        public void EditarProducto(Product producto)
        {
            ConnectDB conexion = new ConnectDB();
            try
            {
                string query = "UPDATE u775758814_POS.Products SET Name=@nombre, Description=@descripcion, Price=@precio, " +
                               "Stock=@stock, ImagePath=@imagePath WHERE code=@codigo";
                MySqlCommand cmd = new MySqlCommand(query, conexion.connectON());

                cmd.Parameters.AddWithValue("@codigo", producto.Code);
                cmd.Parameters.AddWithValue("@nombre", producto.Name);
                cmd.Parameters.AddWithValue("@descripcion", producto.Description);
                cmd.Parameters.AddWithValue("@precio", producto.Price);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.Parameters.AddWithValue("@imagePath", producto.ImagePath); 

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}");
            }
            finally
            {
                conexion.connectOFF();
            }
        }

        public void EliminarProducto(string codigo)
        {
            ConnectDB conexion = new ConnectDB();
            try
            {
                string query = "DELETE FROM u775758814_POS.Products WHERE code=@codigo";
                MySqlCommand cmd = new MySqlCommand(query, conexion.connectON());
                cmd.Parameters.AddWithValue("@codigo", codigo);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}");
            }
            finally
            {
                conexion.connectOFF();
            }
        }

        public void MostrarProductosConImagen(DataGridView dgv)
        {
            ConnectDB conexion = new ConnectDB();
            try
            {
                string query = "SELECT productID, code, Name, Description, Price, Stock, ImagePath FROM u775758814_POS.Products";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion.connectON());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgv.DataSource = dt;

                if (!dgv.Columns.Contains("Image"))
                {
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                    {
                        Name = "Image",
                        HeaderText = "Imagen",
                        ImageLayout = DataGridViewImageCellLayout.Zoom
                    };

                    dgv.Columns.Add(imageColumn);
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["ImagePath"].Value != null)
                    {
                        string imagePath = row.Cells["ImagePath"].Value.ToString();
                        if (File.Exists(imagePath)) 
                        {
                            row.Cells["Image"].Value = Image.FromFile(imagePath); 
                        }
                        else
                        {
                            row.Cells["Image"].Value = null; 
                        }
                    }
                }

                if (dgv.Columns.Contains("ImagePath"))
                {
                    dgv.Columns["ImagePath"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}");
            }
            finally
            {
                conexion.connectOFF();
            }
        }

    }
}


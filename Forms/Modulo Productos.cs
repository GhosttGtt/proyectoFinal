using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS.Clases;

namespace POS
{
    public partial class Modulo_Productos : Form
    {
        private GestionProductos gestionProductos;

        public Modulo_Productos()
        {
            InitializeComponent();
            gestionProductos = new GestionProductos();
            this.Load += Modulo_Productos_Load;
        }

        private void Modulo_Productos_Load(object sender, EventArgs e)
        {
            gestionProductos.MostrarProductosConImagen(dgvproductos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigo.Text) ||
                string.IsNullOrWhiteSpace(txtnombre.Text) ||
                string.IsNullOrWhiteSpace(txtdescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtprecio.Text) ||
                string.IsNullOrWhiteSpace(txtstock.Text) ||
                string.IsNullOrWhiteSpace(txtrutaimagen.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos antes de agregar el producto.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            try
            {
                decimal precio = Convert.ToDecimal(txtprecio.Text);
                int stock = Convert.ToInt32(txtstock.Text);

                Product nuevoProducto = new Product
                {
                    Code = txtcodigo.Text,
                    Name = txtnombre.Text,
                    Description = txtdescripcion.Text,
                    Price = precio,
                    Stock = stock,
                    ImagePath = txtrutaimagen.Text
                };

                gestionProductos.AgregarProducto(nuevoProducto);
                gestionProductos.MostrarProductosConImagen(dgvproductos);

                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores válidos para el precio y el stock.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Product productoEditado = new Product
            {
                Code = txtcodigo.Text,
                Name = txtnombre.Text,
                Description = txtdescripcion.Text,
                Price = Convert.ToDecimal(txtprecio.Text),
                Stock = Convert.ToInt32(txtstock.Text),
                ImagePath = txtrutaimagen.Text
            };

            gestionProductos.EditarProducto(productoEditado);
            gestionProductos.MostrarProductosConImagen(dgvproductos);
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigoProducto = txtcodigo.Text;
            gestionProductos.EliminarProducto(codigoProducto);
            gestionProductos.MostrarProductosConImagen(dgvproductos);
            LimpiarCampos();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            gestionProductos.MostrarProductosConImagen(dgvproductos);
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Seleccionar una imagen"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string rutaOriginal = openFileDialog.FileName;

                string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImagenesProductos");

                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                string nombreArchivo = Path.GetFileName(rutaOriginal);
                string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);

                try
                {
                    File.Copy(rutaOriginal, rutaDestino, true); 
                    MessageBox.Show("Imagen guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtrutaimagen.Text = rutaDestino;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    

        public void GuardarProductoConImagen(string nombre, decimal precio, byte[] imagen)
        {
            ConnectDB conexion = new ConnectDB();
            try
            {
                string query = "INSERT INTO u775758814_POS.Products (Name, Description, Price, Stock, ImagePath) VALUES (@nombre, @descripcion, @precio, @stock, @imagen)";
                MySqlCommand cmd = new MySqlCommand(query, conexion.connectON());

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", txtdescripcion.Text); 
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtstock.Text));
                cmd.Parameters.AddWithValue("@imagen", imagen);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto con imagen guardado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}");
            }
            finally
            {
                conexion.connectOFF();
            }
        }

        private void LimpiarCampos()
        {
            txtcodigo.Clear();
            txtnombre.Clear();
            txtdescripcion.Clear();
            txtprecio.Clear();
            txtstock.Clear();
            txtrutaimagen.Clear();
        }

    }
}


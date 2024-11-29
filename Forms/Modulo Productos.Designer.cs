namespace POS
{
    partial class Modulo_Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modulo_Productos));
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.Código = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.Descripción = new System.Windows.Forms.Label();
            this.Precio = new System.Windows.Forms.Label();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.stock = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dgvproductos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.txtrutaimagen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picProducto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(218, 338);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(100, 22);
            this.txtcodigo.TabIndex = 0;
            // 
            // Código
            // 
            this.Código.AutoSize = true;
            this.Código.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Código.Location = new System.Drawing.Point(159, 338);
            this.Código.Name = "Código";
            this.Código.Size = new System.Drawing.Size(54, 16);
            this.Código.TabIndex = 1;
            this.Código.Text = "Código:";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(218, 365);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(245, 22);
            this.txtnombre.TabIndex = 2;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Nombre.Location = new System.Drawing.Point(155, 368);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(59, 16);
            this.Nombre.TabIndex = 3;
            this.Nombre.Text = "Nombre:";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(218, 398);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(336, 22);
            this.txtdescripcion.TabIndex = 4;
            // 
            // Descripción
            // 
            this.Descripción.AutoSize = true;
            this.Descripción.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Descripción.Location = new System.Drawing.Point(130, 401);
            this.Descripción.Name = "Descripción";
            this.Descripción.Size = new System.Drawing.Size(82, 16);
            this.Descripción.TabIndex = 5;
            this.Descripción.Text = "Descripción:";
            // 
            // Precio
            // 
            this.Precio.AutoSize = true;
            this.Precio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Precio.Location = new System.Drawing.Point(161, 436);
            this.Precio.Name = "Precio";
            this.Precio.Size = new System.Drawing.Size(49, 16);
            this.Precio.TabIndex = 6;
            this.Precio.Text = "Precio:";
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(218, 432);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(336, 22);
            this.txtprecio.TabIndex = 7;
            // 
            // txtstock
            // 
            this.txtstock.Location = new System.Drawing.Point(218, 465);
            this.txtstock.Name = "txtstock";
            this.txtstock.Size = new System.Drawing.Size(336, 22);
            this.txtstock.TabIndex = 8;
            // 
            // stock
            // 
            this.stock.AutoSize = true;
            this.stock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.stock.Location = new System.Drawing.Point(167, 470);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(44, 16);
            this.stock.TabIndex = 9;
            this.stock.Text = "Stock:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Black;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(615, 417);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(136, 37);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar Producto";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(615, 331);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(136, 37);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar Producto";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Black;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(615, 374);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(136, 37);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar Producto";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dgvproductos
            // 
            this.dgvproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproductos.Location = new System.Drawing.Point(131, 103);
            this.dgvproductos.Name = "dgvproductos";
            this.dgvproductos.RowHeadersWidth = 51;
            this.dgvproductos.RowTemplate.Height = 24;
            this.dgvproductos.Size = new System.Drawing.Size(658, 222);
            this.dgvproductos.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 35);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mantenimiento De Productos";
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.BackColor = System.Drawing.Color.Black;
            this.btnCargarImagen.ForeColor = System.Drawing.Color.White;
            this.btnCargarImagen.Location = new System.Drawing.Point(615, 468);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(136, 37);
            this.btnCargarImagen.TabIndex = 17;
            this.btnCargarImagen.Text = "Agregar Imagen";
            this.btnCargarImagen.UseVisualStyleBackColor = false;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // txtrutaimagen
            // 
            this.txtrutaimagen.Location = new System.Drawing.Point(218, 501);
            this.txtrutaimagen.Name = "txtrutaimagen";
            this.txtrutaimagen.Size = new System.Drawing.Size(336, 22);
            this.txtrutaimagen.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(166, 505);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ruta:";
            // 
            // picProducto
            // 
            this.picProducto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picProducto.Location = new System.Drawing.Point(812, 470);
            this.picProducto.Name = "picProducto";
            this.picProducto.Size = new System.Drawing.Size(48, 51);
            this.picProducto.TabIndex = 18;
            this.picProducto.TabStop = false;
            // 
            // Modulo_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(940, 539);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtrutaimagen);
            this.Controls.Add(this.picProducto);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvproductos);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.txtstock);
            this.Controls.Add(this.txtprecio);
            this.Controls.Add(this.Precio);
            this.Controls.Add(this.Descripción);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.Código);
            this.Controls.Add(this.txtcodigo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Modulo_Productos";
            this.Text = "Modulo_Productos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label Código;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label Descripción;
        private System.Windows.Forms.Label Precio;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Label stock;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dgvproductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.TextBox txtrutaimagen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picProducto;
    }
}
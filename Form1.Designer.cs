namespace POS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.txtNIT = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNIT = new System.Windows.Forms.Label();
            this.labelNOMBRE = new System.Windows.Forms.Label();
            this.labelAPE = new System.Windows.Forms.Label();
            this.labelDire = new System.Windows.Forms.Label();
            this.labelTEL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(303, 134);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.Size = new System.Drawing.Size(621, 263);
            this.dgvClientes.TabIndex = 0;
            // 
            // txtNIT
            // 
            this.txtNIT.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIT.Location = new System.Drawing.Point(631, 415);
            this.txtNIT.Name = "txtNIT";
            this.txtNIT.Size = new System.Drawing.Size(293, 22);
            this.txtNIT.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(631, 452);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(293, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(631, 492);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(293, 22);
            this.txtApellido.TabIndex = 3;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(631, 531);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(293, 22);
            this.txtDireccion.TabIndex = 4;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(631, 564);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(293, 22);
            this.txtTelefono.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnAgregar.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(303, 429);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(170, 45);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "AGREGAR CLIENTE";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnActualizar.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(303, 481);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(170, 45);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "ACTUALIZAR CLIENTE";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Brown;
            this.btnEliminar.Font = new System.Drawing.Font("Eras Medium ITC", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(303, 534);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(170, 40);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "ELIMINAR CLIENTE";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Eras Bold ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mantenimiento de Clientes";
            // 
            // labelNIT
            // 
            this.labelNIT.AutoSize = true;
            this.labelNIT.BackColor = System.Drawing.Color.Transparent;
            this.labelNIT.Font = new System.Drawing.Font("Eras Medium ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNIT.Location = new System.Drawing.Point(587, 414);
            this.labelNIT.Name = "labelNIT";
            this.labelNIT.Size = new System.Drawing.Size(41, 21);
            this.labelNIT.TabIndex = 12;
            this.labelNIT.Text = "NIT:";
            this.labelNIT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNOMBRE
            // 
            this.labelNOMBRE.AutoSize = true;
            this.labelNOMBRE.BackColor = System.Drawing.Color.Transparent;
            this.labelNOMBRE.Font = new System.Drawing.Font("Eras Medium ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNOMBRE.Location = new System.Drawing.Point(541, 451);
            this.labelNOMBRE.Name = "labelNOMBRE";
            this.labelNOMBRE.Size = new System.Drawing.Size(89, 21);
            this.labelNOMBRE.TabIndex = 13;
            this.labelNOMBRE.Text = "NOMBRE:";
            this.labelNOMBRE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAPE
            // 
            this.labelAPE.AutoSize = true;
            this.labelAPE.BackColor = System.Drawing.Color.Transparent;
            this.labelAPE.Font = new System.Drawing.Font("Eras Medium ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAPE.Location = new System.Drawing.Point(524, 493);
            this.labelAPE.Name = "labelAPE";
            this.labelAPE.Size = new System.Drawing.Size(106, 21);
            this.labelAPE.TabIndex = 14;
            this.labelAPE.Text = "APELLIDOS:";
            this.labelAPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDire
            // 
            this.labelDire.AutoSize = true;
            this.labelDire.BackColor = System.Drawing.Color.Transparent;
            this.labelDire.Font = new System.Drawing.Font("Eras Medium ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDire.Location = new System.Drawing.Point(522, 532);
            this.labelDire.Name = "labelDire";
            this.labelDire.Size = new System.Drawing.Size(106, 21);
            this.labelDire.TabIndex = 15;
            this.labelDire.Text = "DIRECCIÓN:";
            this.labelDire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTEL
            // 
            this.labelTEL.AutoSize = true;
            this.labelTEL.BackColor = System.Drawing.Color.Transparent;
            this.labelTEL.Font = new System.Drawing.Font("Eras Medium ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTEL.Location = new System.Drawing.Point(526, 563);
            this.labelTEL.Name = "labelTEL";
            this.labelTEL.Size = new System.Drawing.Size(106, 21);
            this.labelTEL.TabIndex = 16;
            this.labelTEL.Text = "TELÉFONO:";
            this.labelTEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(964, 597);
            this.Controls.Add(this.labelTEL);
            this.Controls.Add(this.labelDire);
            this.Controls.Add(this.labelAPE);
            this.Controls.Add(this.labelNOMBRE);
            this.Controls.Add(this.labelNIT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.txtNIT);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Mantenimiento Clientes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.TextBox txtNIT;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNIT;
        private System.Windows.Forms.Label labelNOMBRE;
        private System.Windows.Forms.Label labelAPE;
        private System.Windows.Forms.Label labelDire;
        private System.Windows.Forms.Label labelTEL;
    }
}

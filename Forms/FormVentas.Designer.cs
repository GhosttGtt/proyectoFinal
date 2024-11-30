namespace POS.Forms
{
    partial class FormVentas
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
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.txtCustomerNIT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 116);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(272, 366);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(290, 116);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.Size = new System.Drawing.Size(272, 366);
            this.dataGridViewCart.TabIndex = 1;
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(12, 90);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(100, 20);
            this.txtSearchProduct.TabIndex = 2;
            this.txtSearchProduct.Text = "Buscar";
            // 
            // txtCustomerNIT
            // 
            this.txtCustomerNIT.Location = new System.Drawing.Point(118, 90);
            this.txtCustomerNIT.Name = "txtCustomerNIT";
            this.txtCustomerNIT.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerNIT.TabIndex = 3;
            this.txtCustomerNIT.Text = "NIT";
            // 
            // FormVentas
            // 
            this.ClientSize = new System.Drawing.Size(574, 494);
            this.Controls.Add(this.txtCustomerNIT);
            this.Controls.Add(this.txtSearchProduct);
            this.Controls.Add(this.dataGridViewCart);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProductos;
    
        private System.Windows.Forms.DataGridView dataGridViewCarrito;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.TextBox txtCustomerNIT;
    }
}
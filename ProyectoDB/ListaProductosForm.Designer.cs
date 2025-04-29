namespace ProyectoDB
{
    partial class ListaProductosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BackBtn = new System.Windows.Forms.Button();
            this.AgregarBtn = new System.Windows.Forms.Button();
            this.ListaProductos = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Producto_Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_Venta_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock_Venta_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrip_Venta_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminarbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BackBtn.Location = new System.Drawing.Point(56, 29);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(201, 72);
            this.BackBtn.TabIndex = 32;
            this.BackBtn.Text = "Volver";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // AgregarBtn
            // 
            this.AgregarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.AgregarBtn.Location = new System.Drawing.Point(870, 948);
            this.AgregarBtn.Name = "AgregarBtn";
            this.AgregarBtn.Size = new System.Drawing.Size(334, 92);
            this.AgregarBtn.TabIndex = 31;
            this.AgregarBtn.Text = "Agregar";
            this.AgregarBtn.UseVisualStyleBackColor = true;
            this.AgregarBtn.Click += new System.EventHandler(this.AgregarBtn_Click);
            // 
            // ListaProductos
            // 
            this.ListaProductos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.ListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Nombre_Producto_Venta,
            this.Precio_Venta_Producto,
            this.Stock_Venta_Producto,
            this.Descrip_Venta_Producto});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaProductos.DefaultCellStyle = dataGridViewCellStyle14;
            this.ListaProductos.Location = new System.Drawing.Point(162, 152);
            this.ListaProductos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListaProductos.MultiSelect = false;
            this.ListaProductos.Name = "ListaProductos";
            this.ListaProductos.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.ListaProductos.RowHeadersVisible = false;
            this.ListaProductos.RowHeadersWidth = 62;
            this.ListaProductos.RowTemplate.Height = 40;
            this.ListaProductos.RowTemplate.ReadOnly = true;
            this.ListaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaProductos.Size = new System.Drawing.Size(1712, 675);
            this.ListaProductos.TabIndex = 30;
            this.ListaProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaProductos_CellClick);
            this.ListaProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaProductos_CellDoubleClick);
            // 
            // IdProducto
            // 
            this.IdProducto.FillWeight = 253.8071F;
            this.IdProducto.HeaderText = "ID Producto";
            this.IdProducto.MinimumWidth = 8;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Width = 150;
            // 
            // Nombre_Producto_Venta
            // 
            this.Nombre_Producto_Venta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre_Producto_Venta.FillWeight = 61.54822F;
            this.Nombre_Producto_Venta.HeaderText = "Nombre";
            this.Nombre_Producto_Venta.MinimumWidth = 8;
            this.Nombre_Producto_Venta.Name = "Nombre_Producto_Venta";
            this.Nombre_Producto_Venta.ReadOnly = true;
            // 
            // Precio_Venta_Producto
            // 
            this.Precio_Venta_Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Precio_Venta_Producto.FillWeight = 61.54822F;
            this.Precio_Venta_Producto.HeaderText = "Precio";
            this.Precio_Venta_Producto.MinimumWidth = 8;
            this.Precio_Venta_Producto.Name = "Precio_Venta_Producto";
            this.Precio_Venta_Producto.ReadOnly = true;
            // 
            // Stock_Venta_Producto
            // 
            this.Stock_Venta_Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stock_Venta_Producto.FillWeight = 61.54822F;
            this.Stock_Venta_Producto.HeaderText = "Stock";
            this.Stock_Venta_Producto.MinimumWidth = 8;
            this.Stock_Venta_Producto.Name = "Stock_Venta_Producto";
            this.Stock_Venta_Producto.ReadOnly = true;
            // 
            // Descrip_Venta_Producto
            // 
            this.Descrip_Venta_Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descrip_Venta_Producto.FillWeight = 61.54822F;
            this.Descrip_Venta_Producto.HeaderText = "Descripción";
            this.Descrip_Venta_Producto.MinimumWidth = 8;
            this.Descrip_Venta_Producto.Name = "Descrip_Venta_Producto";
            this.Descrip_Venta_Producto.ReadOnly = true;
            // 
            // Eliminarbtn
            // 
            this.Eliminarbtn.AutoSize = true;
            this.Eliminarbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Eliminarbtn.Location = new System.Drawing.Point(56, 948);
            this.Eliminarbtn.Name = "Eliminarbtn";
            this.Eliminarbtn.Size = new System.Drawing.Size(334, 92);
            this.Eliminarbtn.TabIndex = 34;
            this.Eliminarbtn.Text = "Eliminar";
            this.Eliminarbtn.UseVisualStyleBackColor = true;
            this.Eliminarbtn.Click += new System.EventHandler(this.Eliminarbtn_Click);
            // 
            // ListaProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.Eliminarbtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.AgregarBtn);
            this.Controls.Add(this.ListaProductos);
            this.Name = "ListaProductosForm";
            this.Text = "ListaProductosForm";
            ((System.ComponentModel.ISupportInitialize)(this.ListaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button AgregarBtn;
        private System.Windows.Forms.DataGridView ListaProductos;
        private System.Windows.Forms.Button Eliminarbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Producto_Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_Venta_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock_Venta_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip_Venta_Producto;
    }
}
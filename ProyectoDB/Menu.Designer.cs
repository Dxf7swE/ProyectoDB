namespace ProyectoDB
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AlumnosBtn = new System.Windows.Forms.Button();
            this.ProductosBtn = new System.Windows.Forms.Button();
            this.VentasBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 60F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(68, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 145);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 40F);
            this.label2.ForeColor = System.Drawing.Color.Lavender;
            this.label2.Location = new System.Drawing.Point(166, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 98);
            this.label2.TabIndex = 1;
            this.label2.Text = "papelería";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(150, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 79);
            this.label3.TabIndex = 2;
            this.label3.Text = "Menú";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.AlumnosBtn);
            this.panel1.Controls.Add(this.ProductosBtn);
            this.panel1.Controls.Add(this.VentasBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(944, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 676);
            this.panel1.TabIndex = 3;
            // 
            // AlumnosBtn
            // 
            this.AlumnosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlumnosBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.AlumnosBtn.Location = new System.Drawing.Point(61, 504);
            this.AlumnosBtn.Name = "AlumnosBtn";
            this.AlumnosBtn.Size = new System.Drawing.Size(413, 116);
            this.AlumnosBtn.TabIndex = 6;
            this.AlumnosBtn.Text = "Alumnos";
            this.AlumnosBtn.UseVisualStyleBackColor = true;
            this.AlumnosBtn.Click += new System.EventHandler(this.AlumnosBtn_Click);
            // 
            // ProductosBtn
            // 
            this.ProductosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProductosBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.ProductosBtn.Location = new System.Drawing.Point(61, 341);
            this.ProductosBtn.Name = "ProductosBtn";
            this.ProductosBtn.Size = new System.Drawing.Size(413, 116);
            this.ProductosBtn.TabIndex = 4;
            this.ProductosBtn.Text = "Productos";
            this.ProductosBtn.UseVisualStyleBackColor = true;
            this.ProductosBtn.Click += new System.EventHandler(this.ProductosBtn_Click);
            // 
            // VentasBtn
            // 
            this.VentasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VentasBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.VentasBtn.Location = new System.Drawing.Point(61, 166);
            this.VentasBtn.Name = "VentasBtn";
            this.VentasBtn.Size = new System.Drawing.Size(413, 123);
            this.VentasBtn.TabIndex = 5;
            this.VentasBtn.Text = "Ventas";
            this.VentasBtn.UseVisualStyleBackColor = true;
            this.VentasBtn.Click += new System.EventHandler(this.VentasBtn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1566, 920);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ProductosBtn;
        private System.Windows.Forms.Button VentasBtn;
        private System.Windows.Forms.Button AlumnosBtn;
    }
}
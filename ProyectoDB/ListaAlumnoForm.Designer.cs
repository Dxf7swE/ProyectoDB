namespace ProyectoDB
{
    partial class ListaUsuariosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Eliminarbtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.AgregarBtn = new System.Windows.Forms.Button();
            this.ListaAlumnos = new System.Windows.Forms.DataGridView();
            this.NumCtrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ListaAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // Eliminarbtn
            // 
            this.Eliminarbtn.AutoSize = true;
            this.Eliminarbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Eliminarbtn.Location = new System.Drawing.Point(64, 895);
            this.Eliminarbtn.Name = "Eliminarbtn";
            this.Eliminarbtn.Size = new System.Drawing.Size(334, 92);
            this.Eliminarbtn.TabIndex = 41;
            this.Eliminarbtn.Text = "Eliminar";
            this.Eliminarbtn.UseVisualStyleBackColor = true;
            this.Eliminarbtn.Click += new System.EventHandler(this.Eliminarbtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BackBtn.Location = new System.Drawing.Point(44, 12);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(201, 72);
            this.BackBtn.TabIndex = 39;
            this.BackBtn.Text = "Volver";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // AgregarBtn
            // 
            this.AgregarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.AgregarBtn.Location = new System.Drawing.Point(852, 895);
            this.AgregarBtn.Name = "AgregarBtn";
            this.AgregarBtn.Size = new System.Drawing.Size(334, 92);
            this.AgregarBtn.TabIndex = 38;
            this.AgregarBtn.Text = "Agregar";
            this.AgregarBtn.UseVisualStyleBackColor = true;
            this.AgregarBtn.Click += new System.EventHandler(this.AgregarBtn_Click);
            // 
            // ListaAlumnos
            // 
            this.ListaAlumnos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ListaAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumCtrl,
            this.Nombre_Alumno});
            this.ListaAlumnos.Location = new System.Drawing.Point(148, 135);
            this.ListaAlumnos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListaAlumnos.Name = "ListaAlumnos";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaAlumnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.ListaAlumnos.RowHeadersVisible = false;
            this.ListaAlumnos.RowHeadersWidth = 5;
            this.ListaAlumnos.RowTemplate.Height = 40;
            this.ListaAlumnos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaAlumnos.Size = new System.Drawing.Size(1712, 675);
            this.ListaAlumnos.TabIndex = 37;
            this.ListaAlumnos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaAlumnos_CellDoubleClick);
            // 
            // NumCtrl
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCtrl.DefaultCellStyle = dataGridViewCellStyle6;
            this.NumCtrl.HeaderText = "Número Control";
            this.NumCtrl.MinimumWidth = 8;
            this.NumCtrl.Name = "NumCtrl";
            this.NumCtrl.Width = 412;
            // 
            // Nombre_Alumno
            // 
            this.Nombre_Alumno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre_Alumno.DefaultCellStyle = dataGridViewCellStyle7;
            this.Nombre_Alumno.HeaderText = "Nombre";
            this.Nombre_Alumno.MinimumWidth = 8;
            this.Nombre_Alumno.Name = "Nombre_Alumno";
            // 
            // ListaUsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.Eliminarbtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.AgregarBtn);
            this.Controls.Add(this.ListaAlumnos);
            this.Name = "ListaUsuariosForm";
            this.Text = "ListaUsuariosForm";
            this.Click += new System.EventHandler(this.ListaUsuariosForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ListaAlumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Eliminarbtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button AgregarBtn;
        private System.Windows.Forms.DataGridView ListaAlumnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumCtrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Alumno;
    }
}
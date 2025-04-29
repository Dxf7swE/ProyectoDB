namespace ProyectoDB
{
    partial class MetodoPagoForm
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
            this.TransBtn = new System.Windows.Forms.Button();
            this.PuntosBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(360, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1053, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el Método de Pago";
            // 
            // TransBtn
            // 
            this.TransBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TransBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.TransBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TransBtn.Location = new System.Drawing.Point(304, 431);
            this.TransBtn.Name = "TransBtn";
            this.TransBtn.Size = new System.Drawing.Size(315, 101);
            this.TransBtn.TabIndex = 1;
            this.TransBtn.Text = "Transferencia";
            this.TransBtn.UseVisualStyleBackColor = true;
            this.TransBtn.Click += new System.EventHandler(this.TransBtn_Click);
            // 
            // PuntosBtn
            // 
            this.PuntosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PuntosBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.PuntosBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.PuntosBtn.Location = new System.Drawing.Point(793, 431);
            this.PuntosBtn.Name = "PuntosBtn";
            this.PuntosBtn.Size = new System.Drawing.Size(315, 101);
            this.PuntosBtn.TabIndex = 2;
            this.PuntosBtn.Text = "Efectivo";
            this.PuntosBtn.UseVisualStyleBackColor = true;
            this.PuntosBtn.Click += new System.EventHandler(this.PuntosBtn_Click);
            // 
            // MetodoPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1362, 857);
            this.Controls.Add(this.PuntosBtn);
            this.Controls.Add(this.TransBtn);
            this.Controls.Add(this.label1);
            this.Name = "MetodoPagoForm";
            this.Text = "MetodoPagoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TransBtn;
        private System.Windows.Forms.Button PuntosBtn;
    }
}
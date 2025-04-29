namespace ProyectoDB
{
    partial class Efectivo
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCobro = new System.Windows.Forms.TextBox();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.Ptstxt = new System.Windows.Forms.TextBox();
            this.PtsUsartxt = new System.Windows.Forms.TextBox();
            this.BtnPagar = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(548, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cobro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(548, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pago";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(529, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 46);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cambio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(1027, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 46);
            this.label4.TabIndex = 3;
            this.label4.Text = "Saldo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(954, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 46);
            this.label5.TabIndex = 4;
            this.label5.Text = "Puntos a Usar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(486, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(283, 79);
            this.label6.TabIndex = 5;
            this.label6.Text = "Efectivo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(960, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(252, 79);
            this.label7.TabIndex = 6;
            this.label7.Text = "Puntos";
            // 
            // txtCobro
            // 
            this.txtCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCobro.Location = new System.Drawing.Point(416, 243);
            this.txtCobro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCobro.Name = "txtCobro";
            this.txtCobro.ReadOnly = true;
            this.txtCobro.Size = new System.Drawing.Size(397, 64);
            this.txtCobro.TabIndex = 7;
            this.txtCobro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPago
            // 
            this.txtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtPago.Location = new System.Drawing.Point(416, 419);
            this.txtPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(397, 64);
            this.txtPago.TabIndex = 18;
            this.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPago_KeyDown);
            // 
            // txtCambio
            // 
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtCambio.Location = new System.Drawing.Point(416, 601);
            this.txtCambio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(397, 64);
            this.txtCambio.TabIndex = 19;
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Ptstxt
            // 
            this.Ptstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Ptstxt.Location = new System.Drawing.Point(951, 325);
            this.Ptstxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Ptstxt.Name = "Ptstxt";
            this.Ptstxt.ReadOnly = true;
            this.Ptstxt.Size = new System.Drawing.Size(276, 64);
            this.Ptstxt.TabIndex = 20;
            this.Ptstxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PtsUsartxt
            // 
            this.PtsUsartxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.PtsUsartxt.Location = new System.Drawing.Point(951, 533);
            this.PtsUsartxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PtsUsartxt.Name = "PtsUsartxt";
            this.PtsUsartxt.Size = new System.Drawing.Size(276, 64);
            this.PtsUsartxt.TabIndex = 21;
            this.PtsUsartxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PtsUsartxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PtsUsartxt_KeyDown);
            // 
            // BtnPagar
            // 
            this.BtnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPagar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnPagar.Location = new System.Drawing.Point(537, 721);
            this.BtnPagar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnPagar.Name = "BtnPagar";
            this.BtnPagar.Size = new System.Drawing.Size(180, 78);
            this.BtnPagar.TabIndex = 22;
            this.BtnPagar.Text = "Pagar";
            this.BtnPagar.UseVisualStyleBackColor = true;
            this.BtnPagar.Click += new System.EventHandler(this.BtnPagar_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.Cornsilk;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.ForeColor = System.Drawing.Color.Indigo;
            this.BackBtn.Location = new System.Drawing.Point(23, 48);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(156, 62);
            this.BackBtn.TabIndex = 23;
            this.BackBtn.Text = "Volver";
            this.BackBtn.UseVisualStyleBackColor = false;
            // 
            // Efectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1312, 839);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.BtnPagar);
            this.Controls.Add(this.PtsUsartxt);
            this.Controls.Add(this.Ptstxt);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.txtCobro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Efectivo";
            this.Text = "Efectivo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCobro;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.TextBox Ptstxt;
        private System.Windows.Forms.TextBox PtsUsartxt;
        private System.Windows.Forms.Button BtnPagar;
        private System.Windows.Forms.Button BackBtn;
    }
}
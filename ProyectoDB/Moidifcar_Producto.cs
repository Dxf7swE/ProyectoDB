using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProyectoDB
{
    public partial class Moidifcar_Producto: Form
    {
        private readonly DatabaseHelper dbHelper;
        public Producto ProductoActual { get; private set; }
        public Moidifcar_Producto(Producto producto)
        {
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
            InitializeComponent();
            ProductoActual = producto;
            CargarDatosProducto();
        }

        private void CargarDatosProducto()
        {
            txtIDproducto.Text = ProductoActual.IdProducto.ToString();
            txtNombreproducto.Text = ProductoActual.Nombre;
            txtPrecioproducto.Text = ProductoActual.Precio.ToString("0.00");
            txtProductoStock.Text = ProductoActual.Stock.ToString();
            txtDescProducto.Text = ProductoActual.Descripcion;
        }

        private void UpdProductBtn_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                ProductoActual.Nombre = txtNombreproducto.Text;
                ProductoActual.Precio = decimal.Parse(txtPrecioproducto.Text);
                ProductoActual.Stock = int.Parse(txtProductoStock.Text);
                ProductoActual.Descripcion = txtDescProducto.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            // Implementa tu validación aquí
            return true;
        }
    }
}

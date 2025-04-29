using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoDB
{
    public partial class ProductosForm: Form
    {

        private readonly DatabaseHelper dbHelper;
        public ProductosForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
        }
        private void AddProductBtn_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos
            string idProducto = txtIDproducto.Text.Trim();
            string nombre = txtNombreproducto.Text.Trim();
            string descripcion = txtDescProducto.Text.Trim();
            string precioTexto = txtPrecioproducto.Text.Trim();
            string stockTexto = txtProductoStock.Text.Trim();

            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(idProducto) || string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(precioTexto) || string.IsNullOrEmpty(stockTexto))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convertir precio y stock
            if (!decimal.TryParse(precioTexto, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un número válido y no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(stockTexto, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero válido y no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear la consulta SQL para insertar el producto
            string insertQuery = @"
        INSERT INTO Producto (Id_Producto, Nombre, Precio, Stock, Descripcion)
        VALUES (@Id_Producto, @Nombre, @Precio, @Stock, @Descripcion)";

            // Crear los parámetros para la consulta
            SqlParameter[] parameters = {
        new SqlParameter("@Id_Producto", idProducto),
        new SqlParameter("@Nombre", nombre),
        new SqlParameter("@Precio", precio),
        new SqlParameter("@Stock", stock),
        new SqlParameter("@Descripcion", descripcion)
    };

            try
            {
                // Ejecutar la consulta SQL
                dbHelper.ExecuteNonQueryWithParameters(insertQuery, parameters);

                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                // Manejar errores específicos de SQL
                if (ex.Number == 2627) // Error de clave duplicada (Id_Producto ya existe)
                {
                    MessageBox.Show("El ID del producto ya existe. Por favor, ingresa un ID único.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txtIDproducto.Clear();
            txtNombreproducto.Clear();
            txtPrecioproducto.Clear();
            txtProductoStock.Clear();
            txtDescProducto.Clear();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Menú
            ListaProductosForm ListaproductosForm = new ListaProductosForm();

            // Mostrar el formulario Menú
            ListaproductosForm.Show();

            // Ocultar el formulario actual
            this.Hide();

        }
    }
}

    

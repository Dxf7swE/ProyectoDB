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
    
    public partial class ListaProductosForm: Form
    {
        private readonly DatabaseHelper dbHelper;
        public ListaProductosForm()
        {
            
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
            InitializeComponent();
            CargarProductos();

        }
        private void CargarProductos()
        {
            try
            {
                string query = "SELECT Id_Producto, Nombre, Precio, Stock, Descripcion FROM Producto";
                DataTable dtProductos = dbHelper.ExecuteQuery(query);

                // Limpiar el DataGridView antes de cargar nuevos datos
                ListaProductos.Rows.Clear();

                // Llenar el DataGridView con los datos del DataTable
                foreach (DataRow row in dtProductos.Rows)
                {
                    ListaProductos.Rows.Add(
                        row["Id_Producto"],
                        row["Nombre"],
                        row["Precio"],
                        row["Stock"],
                        row["Descripcion"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarProducto(Producto producto)  
        {
            try
            {
                string query = @"UPDATE Producto SET 
                        Nombre = @Nombre, 
                        Precio = @Precio, 
                        Stock = @Stock, 
                        Descripcion = @Descripcion
                        WHERE Id_Producto = @Id_Producto";

                SqlParameter[] parameters = {
            new SqlParameter("@Id_Producto", producto.IdProducto),
            new SqlParameter("@Nombre", producto.Nombre),
            new SqlParameter("@Precio", producto.Precio),
            new SqlParameter("@Stock", producto.Stock),
            new SqlParameter("@Descripcion", producto.Descripcion)
        };

                dbHelper.ExecuteNonQueryWithParameters(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar producto: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AgregarBtn_Click(object sender, EventArgs e)
        {
            ProductosForm AgregarProducto = new ProductosForm();

            AgregarProducto.Show();

            this.Hide();
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();

            // Mostrar el formulario Menú
            menuForm.Show();

            // Ocultar el formulario actual
            this.Hide();
        }

        private void ListaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ListaProductos.Rows[e.RowIndex];
                Producto productoSeleccionado = new Producto
                {
                    IdProducto = row.Cells[0].Value.ToString(),   // Primera columna
                    Nombre = row.Cells[1].Value.ToString(),
                    Precio = Convert.ToDecimal(row.Cells[2].Value),
                    Stock = Convert.ToInt32(row.Cells[3].Value),
                    Descripcion = row.Cells[4].Value?.ToString() ?? ""
                };

                Moidifcar_Producto formModificar = new Moidifcar_Producto(productoSeleccionado);
                if (formModificar.ShowDialog() == DialogResult.OK)
                {
                    ActualizarProducto(productoSeleccionado);
                    CargarProductos(); // Recargar la lista
                }
            }
        }

        private void Eliminarbtn_Click(object sender, EventArgs e)
        {
            if (ListaProductos.SelectedRows.Count > 0) // Asegura que hay una fila seleccionada
            {
                // 🔹 Obtener el ID del producto como INT
                int idProducto = Convert.ToInt32(ListaProductos.SelectedRows[0].Cells[0].Value);

                // 🔹 Confirmar con el usuario
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                         "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // 🔹 Eliminar de la base de datos
                    EliminarProducto(idProducto);

                    // 🔹 Eliminar del DataGridView
                    ListaProductos.Rows.Remove(ListaProductos.SelectedRows[0]);

                    MessageBox.Show("Producto eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
            }
        }
        private void EliminarProducto(int idProducto)
        {
            using (SqlConnection conexion = new SqlConnection("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True"))
            {
                conexion.Open();
                string query = "DELETE FROM Producto WHERE Id_Producto = @Id";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", idProducto);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}

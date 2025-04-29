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

    public partial class ListaUsuariosForm : Form
    {
        private readonly DatabaseHelper dbHelper;
        public ListaUsuariosForm()
        {
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
            InitializeComponent();
            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            try
            {
                string query = "SELECT NumCtrl, Nombre FROM Alumno";
                DataTable dtAlumnos = dbHelper.ExecuteQuery(query);

                // Limpiar el DataGridView antes de cargar nuevos datos
                ListaAlumnos.Rows.Clear();

                // Llenar el DataGridView con los datos del DataTable
                foreach (DataRow row in dtAlumnos.Rows)
                {
                    ListaAlumnos.Rows.Add(
                        row["NumCtrl"],
                        row["Nombre"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarAlumno(Alumno alumno)
        {
            try
            {
                string query = @"UPDATE Alumno SET 
                        Nombre = @Nombre 
                        WHERE NumCtrl = @NumCtrl";

                SqlParameter[] parameters = {
            new SqlParameter("@NumCtrl", alumno.NumCtrl),
            new SqlParameter("@Nombre", alumno.Nombre),

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
            AgregarAlumno agregarAlumno = new AgregarAlumno();

            agregarAlumno.Show();

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

        private void ListaUsuariosForm_Click(object sender, EventArgs e)
        {

        }


        private void ListaAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ListaAlumnos.Rows[e.RowIndex];

                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int numCtrl))
                {
                    Alumno alumnoSeleccionado = new Alumno
                    {
                        NumCtrl = numCtrl,
                        Nombre = row.Cells[1].Value?.ToString() ?? ""
                    };

                    Modificar_Alumno modificarAlumno = new Modificar_Alumno(alumnoSeleccionado);
                    if (modificarAlumno.ShowDialog() == DialogResult.OK)
                    {
                        ActualizarAlumno(alumnoSeleccionado);
                        CargarAlumnos(); // Recargar la lista
                    }
                }
                else
                {
                    MessageBox.Show("Error: El número de control no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Eliminarbtn_Click(object sender, EventArgs e)
        {
            if (ListaAlumnos.SelectedRows.Count > 0) // Asegura que hay una fila seleccionada
            {
                // 🔹 Obtener el ID del producto como INT
                int NumCtrl = Convert.ToInt32(ListaAlumnos.SelectedRows[0].Cells[0].Value);

                // 🔹 Confirmar con el usuario
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este Alumno?",
                                                         "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // 🔹 Eliminar de la base de datos
                    EliminarAlumno(NumCtrl);

                    // 🔹 Eliminar del DataGridView
                    ListaAlumnos.Rows.Remove(ListaAlumnos.SelectedRows[0]);

                    MessageBox.Show("Alumno eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un Alumno para eliminar.");
            }
        }

        private void EliminarAlumno(int NumCtrl)
        {
            using (SqlConnection conexion = new SqlConnection("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True"))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Eliminar registros en VENTAS (primero, por ser clave foránea)
                        string queryVentas = "DELETE FROM Venta WHERE NumCtrl = @NumCtrl";
                        using (SqlCommand comandoVentas = new SqlCommand(queryVentas, conexion, transaccion))
                        {
                            comandoVentas.Parameters.AddWithValue("@NumCtrl", NumCtrl);
                            comandoVentas.ExecuteNonQuery();
                        }

                        // 2. Eliminar registros en PUNTOS
                        string queryPuntos = "DELETE FROM Puntos WHERE NumCtrl = @NumCtrl";
                        using (SqlCommand comandoPuntos = new SqlCommand(queryPuntos, conexion, transaccion))
                        {
                            comandoPuntos.Parameters.AddWithValue("@NumCtrl", NumCtrl);
                            comandoPuntos.ExecuteNonQuery();
                        }

                        // 3. Finalmente, eliminar al alumno
                        string queryAlumno = "DELETE FROM Alumno WHERE NumCtrl = @NumCtrl";
                        using (SqlCommand comandoAlumno = new SqlCommand(queryAlumno, conexion, transaccion))
                        {
                            comandoAlumno.Parameters.AddWithValue("@NumCtrl", NumCtrl);
                            comandoAlumno.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        MessageBox.Show("Alumno eliminado correctamente.", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        MessageBox.Show($"Error al eliminar alumno: {ex.Message}", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



    }
}

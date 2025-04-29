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
    public partial class AgregarAlumno: Form
    {
        private readonly DatabaseHelper dbHelper;
        public AgregarAlumno()
        {
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
            InitializeComponent();
        }

       

        private void AddAlumnoBtn_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos
            string Nombre = txtNombre.Text.Trim();
            string NumCtrl = txtNumControl.Text.Trim();
            

            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(NumCtrl) || string.IsNullOrEmpty(Nombre))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Crear la consulta SQL para insertar el producto
            string insertQuery = @"
        INSERT INTO Alumno (NumCtrl, Nombre)
        VALUES (@NumCtrl, @Nombre)";

            // Crear los parámetros para la consulta
            SqlParameter[] parameters = {
        new SqlParameter("@NumCtrl", NumCtrl),
        new SqlParameter("@Nombre", Nombre),
    };

            try
            {
                // Ejecutar la consulta SQL
                dbHelper.ExecuteNonQueryWithParameters(insertQuery, parameters);

                MessageBox.Show("Alumno agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                // Manejar errores específicos de SQL
                if (ex.Number == 2627) // Error de clave duplicada (Id_Producto ya existe)
                {
                    MessageBox.Show("El Número de control ya existe. Por favor, ingresa un Número de Control.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error al agregar el Alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtNombre.Clear();
            txtNumControl.Clear();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            ListaUsuariosForm listaAlumnosForm = new ListaUsuariosForm();

            listaAlumnosForm.Show();

            this.Hide();
        }
    }
}

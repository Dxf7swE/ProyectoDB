using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDB
{
    public class Alumno
    {
        public int NumCtrl { get; set; }
        public string Nombre { get; set; }
    }
    public partial class Modificar_Alumno: Form
    {
        private readonly DatabaseHelper dbHelper;

        public Alumno AlumnoActual { get; private set; }
        public Modificar_Alumno(Alumno alumno)
        {
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
            InitializeComponent();
            AlumnoActual = alumno;
            CargarDatosAlumno();
        }

        private void CargarDatosAlumno()
        {

            // Cargar los datos en los campos
            txtNumControl.Text = AlumnoActual.NumCtrl.ToString();
            txtNombre.Text = AlumnoActual.Nombre;
        }

        private void UpdAlumnoBtn_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                AlumnoActual.Nombre = txtNombre.Text;

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

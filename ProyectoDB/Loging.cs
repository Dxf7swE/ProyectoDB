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
    public partial class Loging : Form
    {
        public bool LoginExitoso { get; private set; } = false;

        private DatabaseHelper dbHelper;

        public Loging()
        {
            InitializeComponent();

            // Establecer conexión al constructor
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContrasena.Text.Trim();

            string query = "SELECT * FROM Usuario WHERE Nombre = @usuario AND Contraseña = @contraseña";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@contraseña", contraseña)
            };

            DataTable resultado = dbHelper.ExecuteQuery(query, parametros);

            if (resultado.Rows.Count > 0)
            {
                LoginExitoso = true;

                this.Hide(); // Oculta el formulario actual (login)
                var menu = new Menu();
                menu.ShowDialog();
                this.Close(); // Cierra el login cuando se cierre el nuevo
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
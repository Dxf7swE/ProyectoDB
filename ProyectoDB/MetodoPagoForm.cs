using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoDB.Venta;

namespace ProyectoDB
{
    public partial class MetodoPagoForm: Form
    {
        public List<Productos> ProductosVenta { get; set; } = new List<Productos>();
        public int IDVenta { get; set; }
        public int IdCliente { get; set; }
        public float TotalVenta { get; set; }
        public int PuntosGenerados { get; set; } // Nueva propiedad
        public MetodoPagoForm()
        {
            InitializeComponent();
        }

        private void TransBtn_Click(object sender, EventArgs e)
        {
            var transferenciaForm = new TransferenciaForm
            {
                IDVenta = IDVenta,
                IdCliente = IdCliente,
                TotalVenta = TotalVenta,
                ProductosVenta = DatosVenta.ListaProdTicket, // Envía los productos
                PuntosGenerados = PuntosGenerados
            };

            transferenciaForm.Show();
            this.Hide(); // Opcional: Oculta el formulario actual.
        }

        private void PuntosBtn_Click(object sender, EventArgs e)
        {
            var efectivoform = new Efectivo
            {
                IDVenta = IDVenta,
                IdCliente = IdCliente,
                TotalVenta = TotalVenta,
                ProductosVenta = DatosVenta.ListaProdTicket, // Envía los productos
                PuntosGenerados = PuntosGenerados
            };


            // Mostrar el formulario Menú
            efectivoform.Show();
            // Ocultar el formulario actual
            this.Hide();
        }
    }
    }


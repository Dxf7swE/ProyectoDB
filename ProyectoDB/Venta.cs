using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoDB
{
    public partial class Venta : Form
    {
        private readonly DatabaseHelper dbHelper;
        public Venta()
        {
            InitializeComponent();
            ListaProductos.KeyDown += ListaProductos_KeyDown;
            txtBuscarProdVenta.KeyDown += txtBuscarProdVenta_KeyDown;
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
        }

        public static class DatosVenta
        {
            public static List<Productos> ListaProdTicket { get; set; } = new List<Productos>();
        }

        //Agregar Producto
        // Evento que se ejecuta cuando se presiona una tecla en el campo de búsqueda
        private void txtBuscarProdVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                string idProducto = txtBuscarProdVenta.Text.Trim();
                try
                {
                    AgregarProducto(idProducto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void AgregarProducto(string idProducto)
        {
            if (string.IsNullOrWhiteSpace(idProducto))
            {
                return;
            }

            string query = "SELECT Id_Producto, Nombre, Precio, Stock FROM Producto WHERE Id_Producto = @IdProducto";
            SqlParameter[] selectParameters = { new SqlParameter("@IdProducto", idProducto) };

            DataTable dtProducto = dbHelper.ExecuteQueryWithParameters(query, selectParameters);

            if (dtProducto.Rows.Count > 0)
            {
                DataRow row = dtProducto.Rows[0];
                string id = row["Id_Producto"].ToString();
                int stock = Convert.ToInt32(row["Stock"]);
                decimal precio = Convert.ToDecimal(row["Precio"]);
                string nombre = row["Nombre"].ToString();

                if (stock > 0)
                {
                    decimal puntosGenerados = precio / 10;

                    bool productoExiste = false;

                    foreach (DataGridViewRow fila in ListaProductos.Rows)
                    {
                        if (fila.Cells["IdProducto"].Value != null)
                        {
                            string idFila = fila.Cells["IdProducto"].Value.ToString();

                            if (idFila == id)
                            {
                                productoExiste = true;

                                int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                                cantidadActual += 1;
                                fila.Cells["Cantidad"].Value = cantidadActual;

                                // Actualizar el precio total
                                fila.Cells["PrecioTotal"].Value = cantidadActual * precio;

                                break;
                            }
                        }
                    }


                    if (!productoExiste)
                    {
                        int cantidadI = 1;
                        decimal precioTotal = cantidadI * precio;

                        // Agregar nueva fila en el DataGridView
                        ListaProductos.Rows.Add(id, cantidadI, nombre, precio, puntosGenerados, precioTotal);

                        // Agregar nuevo producto a la lista del ticket
                        DatosVenta.ListaProdTicket.Add(new Productos
                        {
                            IdProducto = id,
                            Cantidad = cantidadI,
                            Nombre = nombre,
                            Precio = precio,
                            PrecioTotal = precioTotal
                        });
                    }
                    else
                    {
                        // Si ya existe en el DataGridView, también actualizar la lista del ticket
                        var productoEnTicket = DatosVenta.ListaProdTicket.FirstOrDefault(p => p.IdProducto == id);
                        if (productoEnTicket != null)
                        {
                            productoEnTicket.Cantidad += 1;
                            productoEnTicket.PrecioTotal = productoEnTicket.Cantidad * productoEnTicket.Precio;
                        }
                    }

                    // Actualizar stock
                    SqlParameter[] updateParameters = { new SqlParameter("@IdProducto", idProducto) };
                    string updateQuery = "UPDATE Producto SET Stock = Stock - 1 WHERE Id_Producto = @IdProducto";
                    dbHelper.ExecuteNonQueryWithParameters(updateQuery, updateParameters);

                    ActualizarTotales();
                    txtBuscarProdVenta.Clear();

                }
                else
                {
                    MessageBox.Show("El producto no tiene stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para actualizar los totales de la venta
        private void ActualizarTotales()
        {
            decimal totalPrecio = 0;
            decimal totalPuntos = 0;

            foreach (DataGridViewRow fila in ListaProductos.Rows)
            {
                if (fila.Cells["Precio_Venta_Producto"].Value != null &&
                    fila.Cells["Cantidad"].Value != null &&
                    decimal.TryParse(fila.Cells["Precio_Venta_Producto"].Value.ToString(), out decimal precio) &&
                    int.TryParse(fila.Cells["Cantidad"].Value.ToString(), out int cantidad))
                {
                    totalPrecio += precio * cantidad;
                    totalPuntos += (precio / 10) * cantidad; // Puntos por cantidad
                }
            }

            txtCostoTotal.Text = totalPrecio.ToString("0.00");
            txtPtosGenerados.Text = totalPuntos.ToString("0.00");
        }


        // Eliminar Producto de la lista
        private void ListaProductos_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si se presionó la tecla "Delete" o "Backspace"
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                // Verifica si hay una fila seleccionada
                if (ListaProductos.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = ListaProductos.SelectedRows[0];

                    // Obtiene el ID y la cantidad del producto de la fila seleccionada
                    string idProducto = filaSeleccionada.Cells["IdProducto"].Value.ToString();
                    int cantidad = Convert.ToInt32(filaSeleccionada.Cells["Cantidad"].Value);

                    // Elimina la fila del DataGridView
                    ListaProductos.Rows.RemoveAt(filaSeleccionada.Index);

                    // Reponer el stock en la base de datos, ahora usando la cantidad
                    string updateQuery = "UPDATE Producto SET Stock = Stock + @Cantidad WHERE Id_Producto = @IdProducto";
                    SqlParameter[] parameters =
                    {
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@IdProducto", idProducto)
            };

                    dbHelper.ExecuteNonQueryWithParameters(updateQuery, parameters);

                    // Actualiza los totales después de eliminar el producto
                    ActualizarTotales();
                }
            }
        }

        //PAGAR
        private void PagarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si hay productos en la lista antes de continuar
                if (ListaProductos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay productos en la venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar y convertir el ID del Cliente
                if (!int.TryParse(txtNumCtrlVenta.Text, out int idCliente))
                {
                    MessageBox.Show("ID de cliente inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar y convertir el total de la venta
                if (!float.TryParse(txtCostoTotal.Text, out float totalVenta))
                {
                    MessageBox.Show("Total de venta inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convertir los puntos generados de forma segura
                int puntosGen = ConvertirPuntosGenerados(txtPtosGenerados.Text);

                // Generar un identificador único para la venta (Siempre positivo)
                int idVenta = Math.Abs(Guid.NewGuid().GetHashCode());

                // Preparar los datos de la venta para TransferenciaForm
                var metodoPagoForm = new MetodoPagoForm
                {
                    IDVenta = idVenta,
                    IdCliente = idCliente,          
                    TotalVenta = totalVenta,       
                    ProductosVenta = DatosVenta.ListaProdTicket, 
                    PuntosGenerados = puntosGen   
                };
                this.Close();
                metodoPagoForm.Show(); // Abre la ventana de método de pago
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int ConvertirPuntosGenerados(string puntosGeneradosText)
        {
            try
            {
                if (!float.TryParse(puntosGeneradosText, out float puntosGenerados))
                {
                    MessageBox.Show("El valor de los puntos generados no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                return Convert.ToInt32(Math.Round(puntosGenerados)); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al convertir los puntos generados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();

            // Mostrar el formulario Menú
            menuForm.Show();

            // Ocultar el formulario actual
            this.Hide();
        }
    }
    public class Producto
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }

    public class Productos
    {
        public string IdProducto { get; set; }

        public decimal Cantidad { get; set; } 
        public string Nombre { get; set; }
        public decimal Precio { get; set; }  // Precio unitario
        public decimal PrecioTotal { get; set; }  // Precio unitario

    }


}


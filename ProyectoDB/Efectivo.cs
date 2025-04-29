using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;

namespace ProyectoDB
{
    public partial class Efectivo: Form
    {
        public List<Productos> ProductosVenta { get; set; } = new List<Productos>();
        public int IdCliente { get; set; }
        public float TotalVenta { get; set; }

        public int IDVenta { get; set; }

        public int IDC { get; set; }

        public decimal PuntosGenerados { get; set; } // Nueva propiedad

        private readonly DatabaseHelper dbHelper;
        public Efectivo()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper("Server=JAVID;Database=PAPELERIA;Trusted_Connection=True");
            this.Load += TransferenciaForm_Load; // Suscripción al evento Load
                                                 // Suscribir el evento KeyDown al TextBox PtsUsartxt
            PtsUsartxt.KeyDown += PtsUsartxt_KeyDown;

            // Suscribir el evento KeyDown al TextBox txtPago
            txtPago.KeyDown += txtPago_KeyDown;
        }

        private  void TransferenciaForm_Load(object sender, EventArgs e)
        {
            // Asegúrate de que TotalVenta tenga un valor válido
            txtCobro.Text = TotalVenta > 0 ? TotalVenta.ToString("F2") : "0";

            // Cargar los puntos del cliente si IdCliente es válido
            if (IdCliente > 0)
            {
                CargarPuntosCliente(IdCliente);
            }
            else
            {
                MessageBox.Show("ID del cliente no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool _consultaRealizada = false; // Bandera para evitar doble consulta



        private void CargarPuntosCliente(int idCliente)
        {
            if (_consultaRealizada) return; // Si ya se realizó la consulta, salir

            try
            {
                _consultaRealizada = true; // Marcar que la consulta se está realizando

                // Consulta SQL para obtener los puntos del cliente desde la tabla Puntos
                string query = "SELECT Puntos, Ptos_Generados FROM Puntos WHERE NumCtrl = @NumCtrl";
                SqlParameter[] parameters = { new SqlParameter("@NumCtrl", idCliente) };

                // Usar DatabaseHelper para ejecutar la consulta
                DataTable dtPuntos = dbHelper.ExecuteQueryWithParameters(query, parameters);

                if (dtPuntos.Rows.Count > 0)
                {
                    DataRow row = dtPuntos.Rows[0];
                    decimal puntosAcumulados = Convert.ToDecimal(row["Puntos"]);
                    decimal puntosGenerados = Convert.ToDecimal(row["Ptos_Generados"]);

                    // Mostrar los puntos acumulados en el TextBox
                    Ptstxt.Text = puntosAcumulados.ToString();

                    // Guardar los puntos generados en la propiedad PuntosGenerados
                    PuntosGenerados = (int)puntosGenerados;
                }
                else
                {
                    MessageBox.Show($"Cliente con número de control {idCliente} no encontrado en la tabla Puntos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los puntos del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _consultaRealizada = false; // Restablecer la bandera
            }
        }



        private void PtsUsartxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Verificar si la tecla presionada es Enter
            {
                e.SuppressKeyPress = true; // Evitar que el TextBox procese el Enter

                try
                {
                    // ✅ Validar que el usuario ingrese solo números decimales y que el valor no sea negativo
                    if (!decimal.TryParse(PtsUsartxt.Text.Trim(), out decimal puntosAUsar) || puntosAUsar < 0)
                    {
                        MessageBox.Show("Por favor, ingresa un número válido para los puntos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        PtsUsartxt.Text = "0"; // Resetear el valor a 0.00
                        PtsUsartxt.SelectionStart = PtsUsartxt.Text.Length; // Mantener el cursor al final
                        return; // Salir de la función para evitar errores
                    }

                    // ✅ Validar que el saldo de puntos sea un número decimal válido
                    if (!decimal.TryParse(Ptstxt.Text.Trim(), out decimal saldoPuntos) || saldoPuntos < 0)
                    {
                        MessageBox.Show("El saldo de puntos no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir de la función para evitar errores
                    }

                    // ✅ Validar que el monto original sea un número decimal válido
                    if (!decimal.TryParse(txtCobro.Tag?.ToString() ?? txtCobro.Text, out decimal cobroOriginal) || cobroOriginal < 0)
                    {
                        MessageBox.Show("El monto original no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir de la función para evitar errores
                    }

                    // Guardar el monto original en Tag la primera vez
                    if (txtCobro.Tag == null)
                    {
                        txtCobro.Tag = cobroOriginal; // Guardar el monto original en la propiedad Tag
                    }

                    // ✅ Validar que los puntos a usar no excedan el saldo de puntos
                    if (puntosAUsar > saldoPuntos)
                    {
                        MessageBox.Show("No puedes usar más puntos de los que tienes disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        PtsUsartxt.Text = saldoPuntos.ToString("F2"); // Limitar a los puntos disponibles
                        PtsUsartxt.SelectionStart = PtsUsartxt.Text.Length; // Mantener el cursor al final
                        puntosAUsar = saldoPuntos; // Ajustar el valor
                    }

                    // Calcular el nuevo total restando los puntos usados
                    decimal nuevoCobro = cobroOriginal - puntosAUsar;

                    // Actualizar el txtCobro con el nuevo total
                    txtCobro.Text = nuevoCobro >= 0 ? nuevoCobro.ToString("F2") : "0.00"; // Asegurar que no sea negativo
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, ingresa valores válidos para los puntos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PtsUsartxt.Text = "0"; // Resetear el valor en caso de error
                    PtsUsartxt.SelectionStart = PtsUsartxt.Text.Length; // Mantener el cursor al final
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al calcular el total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Calcular
        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Verificar si la tecla presionada es Enter
            {
                e.SuppressKeyPress = true; // Evitar que el TextBox procese el Enter

                try
                {
                    // Obtener el monto a cobrar (txtCobro)
                    if (!decimal.TryParse(txtCobro.Text.Trim(), out decimal montoCobro) || montoCobro < 0)
                    {
                        MessageBox.Show("El monto a cobrar no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir de la función si el monto no es válido
                    }

                    // Obtener el monto que el cliente va a pagar (txtPago)
                    if (!decimal.TryParse(txtPago.Text.Trim(), out decimal montoPago) || montoPago < 0)
                    {
                        MessageBox.Show("Por favor, ingresa un monto válido para el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00"; // Resetear el cambio si el pago no es válido
                        return; // Salir de la función si el pago no es válido
                    }

                    // Calcular el cambio
                    if (montoPago >= montoCobro)
                    {
                        // Si el pago es mayor o igual al monto a cobrar, calcular el cambio
                        decimal cambio = montoPago - montoCobro;
                        txtCambio.Text = cambio.ToString("F2"); // Mostrar el cambio con dos decimales
                    }
                    else
                    {
                        // Si el pago es menor que el monto a cobrar, mostrar un mensaje y resetear el cambio
                        MessageBox.Show("El pago es menor que el monto a cobrar. Faltan: " + (montoCobro - montoPago).ToString("F2"), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00"; // Resetear el cambio
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, ingresa valores válidos para el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCambio.Text = "0.00"; // Resetear el cambio en caso de error
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al calcular el cambio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCambio.Text = "0.00"; // Resetear el cambio en caso de error
                }
            }
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los puntos usados (si los hay)
                decimal puntosUsados = string.IsNullOrEmpty(PtsUsartxt.Text) ? 0 : decimal.Parse(PtsUsartxt.Text);

                // Obtener el total de la venta
                if (!decimal.TryParse(txtCobro.Text.Trim(), out decimal totalVenta) || totalVenta < 0)
                {
                    MessageBox.Show("El total de la venta no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calcular los puntos generados por la venta (10% del total de la venta)
                decimal puntosGenerados = totalVenta * 0.10m;

                // Actualizar los puntos en la base de datos
                if (puntosUsados > 0)
                {
                    string updateQuery = "UPDATE Puntos SET Puntos = Puntos - @PuntosUsados WHERE NumCtrl = @NumCtrl";
                    SqlParameter[] parameters = {
                new SqlParameter("@PuntosUsados", puntosUsados),
                new SqlParameter("@NumCtrl", IdCliente)
            };
                    dbHelper.ExecuteNonQueryWithParameters(updateQuery, parameters);
                    MessageBox.Show("Puntos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string updateQuery = @"
                UPDATE Puntos 
                SET Puntos = Puntos + @PuntosGenerados, 
                    Ptos_Generados = Ptos_Generados + @PuntosGenerados 
                WHERE NumCtrl = @NumCtrl";
                    SqlParameter[] parameters = {
                new SqlParameter("@PuntosGenerados", puntosGenerados),
                new SqlParameter("@NumCtrl", IdCliente)
            };
                    dbHelper.ExecuteNonQueryWithParameters(updateQuery, parameters);
                   
                }

                // Generar una nueva venta y guardarla en la base de datos
                int idVenta = ObtenerNuevoIdVenta();

                string insertVentaQuery = @"
            INSERT INTO Venta (ID_VENTA, NumCtrl, Fecha_Venta, Total_Venta)
            VALUES (@ID_VENTA, @NumCtrl, @Fecha_Venta, @Total_Venta)";

                SqlParameter[] ventaParameters = {
            new SqlParameter("@ID_VENTA", idVenta),
            new SqlParameter("@NumCtrl", IdCliente),
            new SqlParameter("@Fecha_Venta", DateTime.Now),
            new SqlParameter("@Total_Venta", totalVenta)
        };
                dbHelper.ExecuteNonQueryWithParameters(insertVentaQuery, ventaParameters);

                // Registrar los productos vendidos en DetalleVenta
                foreach (var producto in ProductosVenta)
                {
                    // Calcular el subtotal (precio unitario * cantidad)
                    decimal subtotal = producto.Precio * producto.Cantidad; // Asumiendo cantidad = 1

                    string insertDetalleQuery = @"
                INSERT INTO DetalleVenta 
               (ID_Venta, ID_Producto, Nombre, Cantidad, Precio_Unitario, Subtotal)
                VALUES (@venta_id, @producto_id,@nombre, @cantidad, @precio_unitario, @subtotal)";

                    SqlParameter[] detalleParameters = {
                new SqlParameter("@venta_id", idVenta),
                new SqlParameter("@producto_id", producto.IdProducto),
                new SqlParameter("@nombre", producto.Nombre),
                new SqlParameter("@cantidad", producto.Cantidad), // Asumiendo 1 unidad por producto
                new SqlParameter("@precio_unitario", producto.Precio),
                new SqlParameter("@subtotal", subtotal)
            };

                    dbHelper.ExecuteNonQueryWithParameters(insertDetalleQuery, detalleParameters);
                }

                

                GuardarTicketEnEscritorio();

                // Limpiar la lista de productos después de registrar la venta
                ProductosVenta.Clear();


                this.Close();

                Menu menu = new Menu();
                menu.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para generar un nuevo ID_VENTA único
        private int ObtenerNuevoIdVenta()
        {
            string query = "SELECT ISNULL(MAX(ID_VENTA), 0) + 1 FROM Venta";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return Convert.ToInt32(dt.Rows[0][0]);
        }



        private string GenerarTicket()
        {
            // Verificación crítica - ¿Tiene productos?
            if (ProductosVenta == null || ProductosVenta.Count == 0)
            {
                return "ERROR: No hay productos en el ticket";
            }

            // Usar StringBuilder para mejor performance con muchos productos
            StringBuilder ticketBuilder = new StringBuilder();

            // Encabezado del ticket
            ticketBuilder.AppendLine("====================================");
            ticketBuilder.AppendLine($"No.Control: {IdCliente}");
            ticketBuilder.AppendLine("====================================");
            ticketBuilder.AppendLine("CANT  PRODUCTO                PRECIO");
            ticketBuilder.AppendLine("------------------------------------");

            // Productos con formato mejorado
            foreach (var producto in ProductosVenta)
            {
                ticketBuilder.AppendLine(
                    $"{producto.Cantidad.ToString().PadRight(5)} " +
                    $"{producto.Nombre.Trim().PadRight(22)} " +
                    $"{producto.PrecioTotal.ToString("C2").PadLeft(10)}"
                );
            }

            // Convertir los textos a decimal y luego formatear como moneda
            decimal total = decimal.Parse(txtCobro.Text);

            // Datos de pago con formato monetario
            ticketBuilder.AppendLine("------------------------------------");
            ticketBuilder.AppendLine($"TOTAL: {total.ToString("C2").PadLeft(35)}");
            ticketBuilder.AppendLine($"MÉTODO: {"Efectivo".PadLeft(34)}");
            ticketBuilder.AppendLine($"PUNTOS: {(string.IsNullOrWhiteSpace(PtsUsartxt.Text) ? "0" : PtsUsartxt.Text).PadLeft(33)}");
            ticketBuilder.AppendLine("------------------------------------");
            ticketBuilder.AppendLine($"FECHA: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").PadLeft(34)}");
            ticketBuilder.AppendLine("====================================");
            ticketBuilder.AppendLine("¡GRACIAS POR SU COMPRA!");
            ticketBuilder.AppendLine("====================================");

            return ticketBuilder.ToString();
        }

        private void GuardarTicketEnEscritorio()
        {
            try
            {
                // Generar el ticket
                string ticket = GenerarTicket();

                // Obtener la ruta del escritorio
                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Definir el nombre del archivo
                string nombreArchivo = $"Ticket_{IdCliente}_{DateTime.Now:yyyyMMddHHmmss}.txt";

                // Ruta completa del archivo
                string rutaArchivo = Path.Combine(rutaEscritorio, nombreArchivo);

                // Guardar el ticket en un archivo de texto
                File.WriteAllText(rutaArchivo, ticket);

                // Informar al usuario
                MessageBox.Show($"El ticket se ha guardado correctamente en:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

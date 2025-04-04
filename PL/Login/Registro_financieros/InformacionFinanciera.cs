using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class InformacionFinanciera : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";

        public InformacionFinanciera()
        {
            InitializeComponent();
            ConfigureControls();
        }

        private void ConfigureControls()
        {

            // Configurar eventos para el campo de ingreso mensual
            Ingreso_mensual.Leave += rjTexbox1_Leave;
            Ingreso_mensual.Enter += rjTexbox1_Enter;
            Ingreso_mensual.KeyPress += rjTexbox1_KeyPress;

            // Configurar valores por defecto para los combobox
            Deudas_Activas.SelectedIndex = -1;
            Cargo.SelectedIndex = -1;
        }

        private void rjTexbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void rjTexbox1_Leave(object sender, EventArgs e)
        {
            // Formatear como moneda al salir del campo
            if (decimal.TryParse(Ingreso_mensual.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal valor))
            {
                Ingreso_mensual.Text = valor.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        private void rjTexbox1_Enter(object sender, EventArgs e)
        {
            // Quitar formato de moneda al entrar al campo
            string text = Ingreso_mensual.Text.Replace("$", "").Replace(",", "").Trim();
            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                Ingreso_mensual.Text = valor.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos antes de proceder
                if (!ValidarCampos())
                    return;

                // Mostrar confirmación antes de guardar
                DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea guardar su información financiera?",
                                                          "Confirmar",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                new AsignacionTarjeta1().Show();


                if (confirmacion != DialogResult.Yes)
                    return;

                // Guardar la información
                if (GuardarInformacionFinanciera())
                {
                    MessageBox.Show("Información financiera guardada exitosamente.", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la información financiera.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}\n\nVerifique que todos los datos sean correctos.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del ingreso mensual no es válido.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            
            }

            //new Verificación().Show();
        }

        private bool ValidarCampos()
        {
            // Validación del ingreso mensual
            string ingresoText = Ingreso_mensual.Text.Replace("$", "").Replace(",", "").Trim();

            if (string.IsNullOrWhiteSpace(ingresoText))
            {
                MostrarError("Por favor ingrese su ingreso mensual estimado.", Ingreso_mensual);
                return false;
            }

            // Validar que sea un número válido
            if (!decimal.TryParse(ingresoText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ingreso) || ingreso <= 0)
            {
                MostrarError("El ingreso mensual debe ser un número positivo mayor que cero.", Ingreso_mensual);
                return false;
            }

            // Validar fuente de ingreso
            if (Cargo.SelectedIndex == -1)
            {
                MostrarError("Por favor seleccione una fuente de ingreso.", Cargo);
                return false;
            }

            // Validar tipo de tarjeta preferida
            if (Deudas_Activas.SelectedIndex == -1)
            {
                MostrarError("Por favor seleccione un tipo de tarjeta preferida.", Deudas_Activas);
                return false;
            }

            
            return true;
        }

        private void MostrarError(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            if (control is TextBox)
                ((TextBox)control).SelectAll();
        }

        private bool GuardarInformacionFinanciera()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO InformacionFinanciera 
                                    (IngresoMensualEstimado, FuenteIngreso, TipoTarjetaPreferida, 
                                     UsaTransferenciaBancaria, UsaPagosEnLinea, UsaCajeroAutomatico, UsuarioRegistro)
                                    VALUES 
                                    (@IngresoMensual, @FuenteIngreso, @TipoTarjeta, 
                                     @Transferencia, @PagosOnline, @CajeroAutomatico, @Usuario)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Convertir el ingreso mensual a decimal
                        string ingresoText = Ingreso_mensual.Text.Replace("$", "").Replace(",", "").Trim();
                        decimal ingresoMensual = decimal.Parse(ingresoText, CultureInfo.InvariantCulture);

                        // Configurar parámetros con tipos específicos
                        command.Parameters.Add("@IngresoMensual", SqlDbType.Decimal).Value = ingresoMensual;
                        command.Parameters["@IngresoMensual"].Precision = 18;
                        command.Parameters["@IngresoMensual"].Scale = 2;

                        
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void LimpiarFormulario()
        {
            Ingreso_mensual.Text = "";
            Deudas_Activas.SelectedIndex = -1;
            Cargo.SelectedIndex = -1;
           
        }

        // Eventos restantes
        private void label6_Click(object sender, EventArgs e) { }
        private void roundButton1_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void rjTexbox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
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
            rjTexbox1.Leave += rjTexbox1_Leave;
            rjTexbox1.Enter += rjTexbox1_Enter;
            rjTexbox1.KeyPress += rjTexbox1_KeyPress;

            // Configurar valores por defecto para los combobox
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
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
            if (decimal.TryParse(rjTexbox1.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal valor))
            {
                rjTexbox1.Text = valor.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        private void rjTexbox1_Enter(object sender, EventArgs e)
        {
            // Quitar formato de moneda al entrar al campo
            string text = rjTexbox1.Text.Replace("$", "").Replace(",", "").Trim();
            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                rjTexbox1.Text = valor.ToString(CultureInfo.InvariantCulture);
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
            string ingresoText = rjTexbox1.Text.Replace("$", "").Replace(",", "").Trim();

            if (string.IsNullOrWhiteSpace(ingresoText))
            {
                MostrarError("Por favor ingrese su ingreso mensual estimado.", rjTexbox1);
                return false;
            }

            // Validar que sea un número válido
            if (!decimal.TryParse(ingresoText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ingreso) || ingreso <= 0)
            {
                MostrarError("El ingreso mensual debe ser un número positivo mayor que cero.", rjTexbox1);
                return false;
            }

            // Validar fuente de ingreso
            if (comboBox2.SelectedIndex == -1)
            {
                MostrarError("Por favor seleccione una fuente de ingreso.", comboBox2);
                return false;
            }

            // Validar tipo de tarjeta preferida
            if (comboBox1.SelectedIndex == -1)
            {
                MostrarError("Por favor seleccione un tipo de tarjeta preferida.", comboBox1);
                return false;
            }

            // Validar al menos un método de pago seleccionado
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                MessageBox.Show("Por favor seleccione al menos un método de pago.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string ingresoText = rjTexbox1.Text.Replace("$", "").Replace(",", "").Trim();
                        decimal ingresoMensual = decimal.Parse(ingresoText, CultureInfo.InvariantCulture);

                        // Configurar parámetros con tipos específicos
                        command.Parameters.Add("@IngresoMensual", SqlDbType.Decimal).Value = ingresoMensual;
                        command.Parameters["@IngresoMensual"].Precision = 18;
                        command.Parameters["@IngresoMensual"].Scale = 2;

                        command.Parameters.Add("@FuenteIngreso", SqlDbType.VarChar, 100).Value = comboBox2.SelectedItem.ToString();
                        command.Parameters.Add("@TipoTarjeta", SqlDbType.VarChar, 100).Value = comboBox1.SelectedItem.ToString();
                        command.Parameters.Add("@Transferencia", SqlDbType.Bit).Value = checkBox1.Checked;
                        command.Parameters.Add("@PagosOnline", SqlDbType.Bit).Value = checkBox2.Checked;
                        command.Parameters.Add("@CajeroAutomatico", SqlDbType.Bit).Value = checkBox3.Checked;
                        command.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = Environment.UserName;

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
            rjTexbox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
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
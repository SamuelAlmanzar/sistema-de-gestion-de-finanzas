using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL.CRUD_CUENTAS
{
    public partial class FORMCUENTAS : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";

        public FORMCUENTAS()
        {
            InitializeComponent();
            guna2DateTimePicker1.Value = DateTime.Today;
            CargarTiposCuenta();
            rjTexbox1.Focus();

            // Asignar el mismo manejador de eventos a ambos botones
            roundButton2.Click += roundButton2_Click;
            roundButton2.Click += roundButton2_Click_1;
        }

        private void CargarTiposCuenta()
        {
            comboBox2.Items.AddRange(new object[] { "Ahorros", "Corriente", "Nómina", "Inversión" });
        }

        private void SeleccionarTodoTexto(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = textBox.Text.Length;
            }
            else if (control.GetType().GetProperty("SelectionStart") != null)
            {
                control.GetType().GetProperty("SelectionStart").SetValue(control, 0);
                control.GetType().GetProperty("SelectionLength").SetValue(control, control.Text.Length);
            }
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            ProcesarGuardado();
        }

        private void roundButton2_Click_1(object sender, EventArgs e)
        {
            ProcesarGuardado();
        }

        private void ProcesarGuardado()
        {
            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO CUENTAS 
                                   (propietario, numero_cuenta, tipo_cuenta, banco, saldo, Fecha) 
                                   VALUES 
                                   (@Propietario, @NumeroCuenta, @TipoCuenta, @Banco, @Saldo, @Fecha)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Propietario", rjTexbox1.Texts.Trim());
                        cmd.Parameters.AddWithValue("@NumeroCuenta", rjTexbox2.Texts.Trim());
                        cmd.Parameters.AddWithValue("@TipoCuenta", comboBox2.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Banco", rjTexbox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Saldo", decimal.Parse(rjTexbox4.Texts));
                        cmd.Parameters.AddWithValue("@Fecha", guna2DateTimePicker1.Value);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("¡Cuenta guardada exitosamente!", "Éxito",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un valor numérico válido para el saldo", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                rjTexbox4.Focus();
                SeleccionarTodoTexto(rjTexbox4);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(rjTexbox1.Texts))
            {
                MessageBox.Show("Ingrese el nombre del propietario", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rjTexbox1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox2.Texts))
            {
                MessageBox.Show("Ingrese el número de cuenta", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rjTexbox2.Focus();
                return false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de cuenta", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox2.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox3.Texts))
            {
                MessageBox.Show("Ingrese el nombre del banco", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rjTexbox3.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox4.Texts) || !decimal.TryParse(rjTexbox4.Texts, out _))
            {
                MessageBox.Show("Ingrese un saldo válido", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rjTexbox4.Focus();
                return false;
            }

            return true;
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void roundButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
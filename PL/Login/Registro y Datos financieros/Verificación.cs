using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class Verificación : Form
    {
        private int _idCliente;
        private string _codigoCorrecto;
        private string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";

        public Verificación(int idCliente, string codigoCorrecto)
        {
            InitializeComponent();
            _idCliente = idCliente;
            _codigoCorrecto = codigoCorrecto;
            CargarTiposDocumento();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
        }

        private void CargarTiposDocumento()
        {
            comboBox1.Items.Add("Cédula");
            comboBox1.Items.Add("Pasaporte");
            comboBox1.Items.Add("Código Verificación");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Código Verificación")
            {
                label2.Text = "Código de Verificación:";
                rjTexbox2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
            else
            {
                label2.Text = "Número de Documento:";
                label3.Text = "Número:";
                label4.Text = "Código:";
                rjTexbox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Código Verificación")
            {
                if (string.IsNullOrWhiteSpace(rjTexbox1.Texts))
                {
                    MessageBox.Show("Por favor ingrese el código de verificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                VerificarCodigo();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(rjTexbox1.Texts) || string.IsNullOrWhiteSpace(rjTexbox2.Texts))
                {
                    MessageBox.Show("Por favor complete todos los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                VerificarDocumento();
            }
        }

        private void VerificarCodigo()
        {
            // Validación inicial del código
            if (rjTexbox1.Texts.Trim() != _codigoCorrecto)
            {
                MessageBox.Show("El código de verificación ingresado no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Primero verificar si el código existe y está pendiente
                    string checkQuery = @"SELECT COUNT(1) FROM Verificacion 
                                       WHERE ID_Cliente = @ID_Cliente 
                                       AND CodigoVerificacion = @Codigo
                                       AND Estado = 'Pendiente'";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                        checkCmd.Parameters.AddWithValue("@Codigo", rjTexbox1.Texts.Trim());

                        if ((int)checkCmd.ExecuteScalar() == 0)
                        {
                            MessageBox.Show("Este código ya ha sido utilizado o no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Si pasa la validación, proceder con la transacción
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Actualizar la verificación
                            string updateQuery = @"UPDATE Verificacion 
                                                SET Estado = 'Completado', 
                                                    FechaVerificacion = GETDATE(),
                                                    TipoDocumento = @TipoDocumento
                                                WHERE ID_Cliente = @ID_Cliente 
                                                AND CodigoVerificacion = @Codigo";

                            using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                                cmdUpdate.Parameters.AddWithValue("@Codigo", rjTexbox1.Texts.Trim());
                                cmdUpdate.Parameters.AddWithValue("@TipoDocumento", comboBox1.SelectedItem.ToString());
                                cmdUpdate.ExecuteNonQuery();
                            }

                            // Marcar cliente como verificado
                            string updateCliente = @"UPDATE Cliente 
                                                   SET Verificado = 1 
                                                   WHERE ID = @ID_Cliente";

                            using (SqlCommand cmdCliente = new SqlCommand(updateCliente, connection, transaction))
                            {
                                cmdCliente.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                                cmdCliente.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("¡Verificación exitosa!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            new InformacionFinanciera().Show();
                        }
                        catch (Exception ex)
                        {
                            try { transaction.Rollback(); } catch { }
                            MessageBox.Show($"Error durante la verificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VerificarDocumento()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Registrar la verificación por documento
                            string insertQuery = @"INSERT INTO Verificacion 
                                                (ID_Cliente, TipoDocumento, CodigoVerificacion, FechaVerificacion, Estado)
                                                VALUES 
                                                (@ID_Cliente, @TipoDocumento, @Codigo, GETDATE(), 'Completado')";

                            using (SqlCommand cmdInsert = new SqlCommand(insertQuery, connection, transaction))
                            {
                                cmdInsert.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                                cmdInsert.Parameters.AddWithValue("@TipoDocumento", comboBox1.SelectedItem.ToString());
                                cmdInsert.Parameters.AddWithValue("@Codigo", rjTexbox2.Texts.Trim());
                                cmdInsert.ExecuteNonQuery();
                            }

                            // Marcar cliente como verificado
                            string updateCliente = @"UPDATE Cliente 
                                                   SET Verificado = 1 
                                                   WHERE ID = @ID_Cliente";

                            using (SqlCommand cmdCliente = new SqlCommand(updateCliente, connection, transaction))
                            {
                                cmdCliente.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                                cmdCliente.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Verificación por documento exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                            new AsignacionTarjeta1().Show();
                        }
                        catch (Exception ex)
                        {
                            try { transaction.Rollback(); } catch { }
                            MessageBox.Show($"Error durante la verificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Verificación_Load(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class Verificación : Form
    {
        private int _idCliente;
        private string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";

        public Verificación(int idCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
            CargarTiposDocumento();
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Iniciar transacción
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Verificar el código
                            string queryVerificacion = @"SELECT COUNT(1) FROM Verificacion 
                                                      WHERE ID_Cliente = @ID_Cliente 
                                                      AND CodigoVerificacion = @Codigo
                                                      AND Estado = 'Pendiente'";

                            using (SqlCommand command = new SqlCommand(queryVerificacion, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                                command.Parameters.AddWithValue("@Codigo", rjTexbox1.Texts.Trim());

                                if ((int)command.ExecuteScalar() == 0)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Código de verificación incorrecto o ya utilizado",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            // 2. Actualizar el estado de verificación
                            string updateVerificacion = @"UPDATE Verificacion 
                                                       SET Estado = 'Completado', 
                                                           FechaVerificacion = GETDATE()
                                                       WHERE ID_Cliente = @ID_Cliente 
                                                       AND CodigoVerificacion = @Codigo";

                            using (SqlCommand cmdUpdate = new SqlCommand(updateVerificacion, connection, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                                cmdUpdate.Parameters.AddWithValue("@Codigo", rjTexbox1.Texts.Trim());
                                cmdUpdate.ExecuteNonQuery();
                            }

                            // 3. Marcar al cliente como verificado
                            string updateCliente = @"UPDATE Cliente 
                                                   SET Verificado = 1 
                                                   WHERE ID = @ID_Cliente";

                            using (SqlCommand cmdCliente = new SqlCommand(updateCliente, connection, transaction))
                            {
                                cmdCliente.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                                cmdCliente.ExecuteNonQuery();
                            }

                            // Confirmar transacción si todo fue bien
                            transaction.Commit();

                            MessageBox.Show("Verificación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            // Intentar hacer rollback en caso de error
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception rollbackEx)
                            {
                                Console.WriteLine("Error al hacer rollback: " + rollbackEx.Message);
                            }

                            MessageBox.Show($"Error durante la verificación: {ex.Message}",
                                          "Error",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
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

                    // Iniciar transacción
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Marcar al cliente como verificado
                            string updateCliente = @"UPDATE Cliente 
                                                   SET Verificado = 1 
                                                   WHERE ID = @ID_Cliente";

                            using (SqlCommand cmdCliente = new SqlCommand(updateCliente, connection, transaction))
                            {
                                cmdCliente.Parameters.AddWithValue("@ID_Cliente", _idCliente);
                                cmdCliente.ExecuteNonQuery();
                            }

                            // Confirmar transacción
                            transaction.Commit();

                            MessageBox.Show("Verificación por documento exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            // Intentar hacer rollback en caso de error
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception rollbackEx)
                            {
                                Console.WriteLine("Error al hacer rollback: " + rollbackEx.Message);
                            }

                            MessageBox.Show($"Error durante la verificación: {ex.Message}",
                                          "Error",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
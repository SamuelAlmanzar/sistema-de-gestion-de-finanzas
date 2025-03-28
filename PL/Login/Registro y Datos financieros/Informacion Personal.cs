using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class Registro : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";
        private string _codigoVerificacion;
        private int _idClienteTemporal;

        // Evento para notificar registro exitoso
        public event EventHandler RegistroExitoso;

        public Registro()
        {
            InitializeComponent();
            rjTexbox3.KeyPress += new KeyPressEventHandler(rjTexbox3_KeyPress);
            rjTexbox5.PasswordChar = true;
            rjTexbox5.PlaceholderText = "";
        }

        protected virtual void OnRegistroExitoso()
        {
            RegistroExitoso?.Invoke(this, EventArgs.Empty);
        }

        private void MostrarError(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            control.Focus();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos() || !ValidarDatos())
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar si el correo ya existe
                    string checkQuery = "SELECT COUNT(1) FROM Cliente WHERE CorreoElectronico = @CorreoElectronico";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@CorreoElectronico", rjTexbox2.Texts.Trim());
                        bool existe = (int)checkCommand.ExecuteScalar() > 0;

                        if (existe)
                        {
                            MostrarError("El correo electrónico ya está registrado", rjTexbox2);
                            return;
                        }
                    }

                    // Generar código de verificación de 6 dígitos
                    Random random = new Random();
                    _codigoVerificacion = random.Next(100000, 999999).ToString();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar nuevo cliente
                            string insertQuery = @"INSERT INTO Cliente 
                                                (NombreCompleto, CorreoElectronico, Telefono, FechaNacimiento, Direccion, Contrasena, Verificado) 
                                                VALUES 
                                                (@NombreCompleto, @CorreoElectronico, @Telefono, @FechaNacimiento, @Direccion, @Contrasena, 0);
                                                SELECT SCOPE_IDENTITY();";

                            using (SqlCommand command = new SqlCommand(insertQuery, connection, transaction))
                            {
                                command.Parameters.Add("@NombreCompleto", SqlDbType.NVarChar, 100).Value = rjTexbox1.Texts.Trim();
                                command.Parameters.Add("@CorreoElectronico", SqlDbType.NVarChar, 100).Value = rjTexbox2.Texts.Trim();
                                command.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = rjTexbox3.Texts.Trim();
                                command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = guna2DateTimePicker1.Value.Date;
                                command.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = rjTexbox4.Texts.Trim();
                                command.Parameters.Add("@Contrasena", SqlDbType.NVarChar, 100).Value = rjTexbox5.Texts.Trim();

                                _idClienteTemporal = Convert.ToInt32(command.ExecuteScalar());

                                // Guardar código de verificación
                                string insertVerificacion = @"INSERT INTO Verificacion 
                                                            (ID_Cliente, TipoDocumento, CodigoVerificacion, Estado) 
                                                            VALUES 
                                                            (@ID_Cliente, 'Código Verificación', @CodigoVerificacion, 'Pendiente')";

                                using (SqlCommand cmdVerificacion = new SqlCommand(insertVerificacion, connection, transaction))
                                {
                                    cmdVerificacion.Parameters.AddWithValue("@ID_Cliente", _idClienteTemporal);
                                    cmdVerificacion.Parameters.AddWithValue("@CodigoVerificacion", _codigoVerificacion);
                                    cmdVerificacion.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                // Mostrar código al usuario
                                MessageBox.Show($"¡Registro exitoso!\n\nTu código de verificación es: {_codigoVerificacion}",
                                              "Código de Verificación",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Information);

                                // Mostrar formulario de verificación
                                Verificación formVerificacion = new Verificación(_idClienteTemporal, _codigoVerificacion);
                                this.Hide();

                                if (formVerificacion.ShowDialog() == DialogResult.OK)
                                {
                                    // Notificar que el registro fue exitoso
                                    OnRegistroExitoso();
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    this.Show();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error al registrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CamposCompletos()
        {
            if (string.IsNullOrWhiteSpace(rjTexbox1.Texts))
            {
                MostrarError("Nombre completo es requerido", rjTexbox1);
                return false;
            }
            if (string.IsNullOrWhiteSpace(rjTexbox2.Texts))
            {
                MostrarError("Correo electrónico es requerido", rjTexbox2);
                return false;
            }
            if (string.IsNullOrWhiteSpace(rjTexbox3.Texts))
            {
                MostrarError("Teléfono es requerido", rjTexbox3);
                return false;
            }
            if (string.IsNullOrWhiteSpace(rjTexbox4.Texts))
            {
                MostrarError("Dirección es requerida", rjTexbox4);
                return false;
            }
            if (string.IsNullOrWhiteSpace(rjTexbox5.Texts))
            {
                MostrarError("Contraseña es requerida", rjTexbox5);
                return false;
            }
            if (guna2DateTimePicker1.Value > DateTime.Now)
            {
                MostrarError("Fecha de nacimiento no puede ser futura", guna2DateTimePicker1);
                return false;
            }

            return true;
        }

        private bool ValidarDatos()
        {
            if (!ValidarCorreoElectronico(rjTexbox2.Texts))
            {
                MostrarError("Formato de correo electrónico inválido", rjTexbox2);
                return false;
            }

            if (!Regex.IsMatch(rjTexbox3.Texts, @"^\d{8,15}$"))
            {
                MostrarError("El teléfono debe contener entre 8 y 15 dígitos", rjTexbox3);
                return false;
            }

            if (rjTexbox1.Texts.Trim().Split(' ').Length < 2)
            {
                MostrarError("Ingrese al menos nombre y apellido", rjTexbox1);
                return false;
            }

            if (rjTexbox5.Texts.Length < 8)
            {
                MostrarError("La contraseña debe tener al menos 8 caracteres", rjTexbox5);
                return false;
            }

            return true;
        }

        private bool ValidarCorreoElectronico(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void rjTexbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnMostrarContrasena_Click(object sender, EventArgs e)
        {
            rjTexbox5.PasswordChar = !rjTexbox5.PasswordChar;
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            if (!ProbarConexion())
            {
                MessageBox.Show("La aplicación no puede continuar sin conexión a la base de datos",
                              "Error crítico",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                this.Close();
            }
            guna2DateTimePicker1.MaxDate = DateTime.Now;
            guna2DateTimePicker1.Value = DateTime.Now.AddYears(-18);
        }

        private bool ProbarConexion()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
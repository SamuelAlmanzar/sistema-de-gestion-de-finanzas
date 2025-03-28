using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL.CRUD_CUENTAS
{
    public partial class CRUDUSUARIOS : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";
        public event EventHandler UsuarioRegistrado;

        public CRUDUSUARIOS()
        {
            InitializeComponent();
            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            // Configurar DatePicker
            guna2DateTimePicker1.MaxDate = DateTime.Today;
            guna2DateTimePicker1.Value = DateTime.Today.AddYears(-18);

            // Configurar campo de contraseña
            rjTexbox5.PasswordChar = true;

            // Configurar validación de teléfono
            rjTexbox3.KeyPress += SoloNumeros_KeyPress;
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            GuardarUsuario();
        }

        private void GuardarUsuario()
        {
            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (CorreoYaExiste(connection))
                    {
                        MostrarError("El correo electrónico ya está registrado", rjTexbox2);
                        return;
                    }

                    RegistrarNuevoUsuario(connection);

                    MessageBox.Show("Usuario registrado exitosamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    OnUsuarioRegistrado();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CorreoYaExiste(SqlConnection connection)
        {
            string query = "SELECT COUNT(1) FROM Cliente WHERE CorreoElectronico = @Correo";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Correo", rjTexbox2.Texts.Trim());
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void RegistrarNuevoUsuario(SqlConnection connection)
        {
            string query = @"INSERT INTO Cliente 
                           (NombreCompleto, CorreoElectronico, Telefono, 
                            FechaNacimiento, Direccion, Contrasena) 
                           VALUES 
                           (@Nombre, @Correo, @Telefono, @FechaNacimiento, @Direccion, @Contrasena)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Nombre", rjTexbox1.Texts.Trim());
                cmd.Parameters.AddWithValue("@Correo", rjTexbox2.Texts.Trim());
                cmd.Parameters.AddWithValue("@Telefono", rjTexbox3.Texts.Trim());
                cmd.Parameters.AddWithValue("@FechaNacimiento", guna2DateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Direccion", rjTexbox4.Texts.Trim());
                cmd.Parameters.AddWithValue("@Contrasena", rjTexbox5.Texts.Trim());

                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(rjTexbox1.Texts))
            {
                MostrarError("Ingrese el nombre completo", rjTexbox1);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox2.Texts) || !EsEmailValido(rjTexbox2.Texts))
            {
                MostrarError("Ingrese un correo electrónico válido", rjTexbox2);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox3.Texts))
            {
                MostrarError("Ingrese el teléfono", rjTexbox3);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox4.Texts))
            {
                MostrarError("Ingrese la dirección", rjTexbox4);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox5.Texts))
            {
                MostrarError("Ingrese la contraseña", rjTexbox5);
                return false;
            }

            if (guna2DateTimePicker1.Value > DateTime.Today)
            {
                MostrarError("La fecha de nacimiento no puede ser futura", guna2DateTimePicker1);
                return false;
            }

            return true;
        }

        private bool EsEmailValido(string email)
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

        private void MostrarError(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
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

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected virtual void OnUsuarioRegistrado()
        {
            UsuarioRegistrado?.Invoke(this, EventArgs.Empty);
        }
    }
}
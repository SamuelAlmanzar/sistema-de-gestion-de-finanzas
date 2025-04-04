using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class oldpassword : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;";
        private int failedAttempts = 0;
        private const int MaxAttempts = 3;

        public oldpassword()
        {
            InitializeComponent();
            ConfigureEvents();
        }

        private void ConfigureEvents()
        {
            rjTexbox1.Leave += (s, e) => roundButton2_Click(s, e);
            rjTexbox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) roundButton2_Click(s, e);
            };
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            if (failedAttempts >= MaxAttempts)
            {
                MessageBox.Show("Demasiados intentos fallidos. Por favor intente más tarde.",
                              "Acceso bloqueado",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }

            string correo = rjTexbox1.Texts.Trim();

            if (!IsValidEmail(correo))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido",
                              "Formato incorrecto",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Contrasena FROM Cliente WHERE CorreoElectronico = @Correo";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // Reset failed attempts on success
                            failedAttempts = 0;

                            string contrasena = result.ToString();
                            MessageBox.Show($"Su contraseña es: {contrasena}",
                                          "Contraseña recuperada",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                        else
                        {
                            failedAttempts++;
                            MessageBox.Show($"Correo no registrado. Intentos restantes: {MaxAttempts - failedAttempts}",
                                          "Cuenta no encontrada",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                failedAttempts++;
                MessageBox.Show($"Error de base de datos: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                failedAttempts++;
                MessageBox.Show($"Error inesperado: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Simple regex for basic email validation
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            // Close or cancel operation
            this.Close();
        }

        private void oldpassword_Load(object sender, EventArgs e)
        {
            // Focus on the email field when form loads
            rjTexbox1.Focus();
        }
    }
}
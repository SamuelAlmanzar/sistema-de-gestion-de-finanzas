using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL.CRUD_CUENTAS
{
    public partial class CRUDUSUARIOS : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=BancoDB;Integrated Security=True;Connect Timeout=30;";
        public event EventHandler UsuarioRegistrado;

        public CRUDUSUARIOS()
        {
            InitializeComponent();
            ConfigurarControles();
            UsuarioRegistrado += CRUDUSUARIOS_UsuarioRegistrado; // Suscripción al evento
        }

        private void ConfigurarControles()
        {
            guna2DateTimePicker1.MaxDate = DateTime.Today;
            guna2DateTimePicker1.Value = DateTime.Today.AddYears(-18);
            rjTexbox3.KeyPress += SoloNumeros_KeyPress;
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            GuardarUsuario();
            new GestionCliente().Show();
        }

        private void GuardarUsuario()
        {
            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (DocumentoYaExiste(connection))
                    {
                        MostrarError("El número de documento ya está registrado", comboBox1);
                        return;
                    }

                    RegistrarNuevoUsuario(connection);

                    MessageBox.Show("Usuario registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    OnUsuarioRegistrado(); // Disparar el evento
                    AbrirGestionCliente(); // Abrir el formulario de gestión de clientes

                    //this.DialogResult = DialogResult.OK;
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DocumentoYaExiste(SqlConnection connection)
        {
            string query = "SELECT COUNT(1) FROM Cliente WHERE NumeroDocumento = @Documento";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Documento", comboBox1.Text.Trim());
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void RegistrarNuevoUsuario(SqlConnection connection)
        {
            string query = @"INSERT INTO Cliente 
                             (Nombres, Apellidos, Genero, FechaNacimiento, TipoDocumento, NumeroDocumento, CorreoElectronico, Telefono)
                             VALUES
                             (@Nombres, @Apellidos, @Genero, @FechaNacimiento, @TipoDocumento, @NumeroDocumento, @Correo, @Telefono)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Nombres", rjTexbox1.Texts.Trim());
                cmd.Parameters.AddWithValue("@Apellidos", rjTexbox6.Texts.Trim());
                cmd.Parameters.AddWithValue("@Genero", comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@FechaNacimiento", guna2DateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@TipoDocumento", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@NumeroDocumento", rjTexbox8.Texts.Trim());
                cmd.Parameters.AddWithValue("@Correo", rjTexbox2.Texts.Trim());
                cmd.Parameters.AddWithValue("@Telefono", rjTexbox3.Texts.Trim());

                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(rjTexbox1.Texts))
            {
                MostrarError("Ingrese los nombres", rjTexbox1);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox6.Texts))
            {
                MostrarError("Ingrese los apellidos", rjTexbox6);
                return false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MostrarError("Seleccione el género", comboBox2);
                return false;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MostrarError("Seleccione el tipo de documento", comboBox1);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text.Trim()))
            {
                MostrarError("Ingrese el número de documento", comboBox1);
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

        private void roundButton1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        // Manejo del evento UsuarioRegistrado
        private void CRUDUSUARIOS_UsuarioRegistrado(object sender, EventArgs e)
        {
            GestionCliente gestionClienteForm = new GestionCliente();
            gestionClienteForm.Show();
        }

        // Método para disparar el evento
        protected virtual void OnUsuarioRegistrado()
        {
            UsuarioRegistrado?.Invoke(this, EventArgs.Empty);
        }

        // Método para abrir el formulario de gestión de clientes
        private void AbrirGestionCliente()
        {
            GestionCliente gestionClienteForm = new GestionCliente();
            gestionClienteForm.Show();
        }

        private void roundButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

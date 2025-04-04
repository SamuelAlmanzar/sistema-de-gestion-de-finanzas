using System;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using ProyectoFinalMargarita;
using System.Data.SqlClient;

namespace ProyectoFinalMargarita
{
    public partial class Login : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";
        private static readonly string filePath = "Relogin.json"; // Archivo JSON

        public Login()
        {
            InitializeComponent();
            VerificarSesionGuardada(); // Verifica si hay una sesión guardada
        }

        private void VerificarSesionGuardada()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var data = JsonConvert.DeserializeObject<dynamic>(json);
                    string usuarioGuardado = data.Usuario;

                    if (!string.IsNullOrEmpty(usuarioGuardado))
                    {
                        Main mainForm = new Main(usuarioGuardado);
                        mainForm.Show();
                        this.Hide(); // Oculta el Login
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la sesión: " + ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            string nombreCompleto = rjTexbox1.Texts;
            string contraseña = rjTexbox2.Texts;

            if (string.IsNullOrEmpty(nombreCompleto) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor ingrese nombre completo y contraseña", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidarCliente(nombreCompleto, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                GuardarUsuario(nombreCompleto); // Guarda el usuario en JSON
                Main mainForm = new Main(nombreCompleto);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nombre completo o contraseña incorrectos", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCliente(string nombreCompleto, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT NombreCompleto FROM Cliente WHERE NombreCompleto = @NombreCompleto AND Contrasena = @Contraseña";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                        object result = cmd.ExecuteScalar();
                        return result != null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void GuardarUsuario(string nombreUsuario)
        {
            try
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(new { Usuario = nombreUsuario }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la sesión: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Registro().Show();
        }
    }
}

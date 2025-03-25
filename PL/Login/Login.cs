using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProyectoFinalMargarita.PL.MainPage;

namespace ProyectoFinalMargarita
{
    public partial class Login : Form
    {
        // Cadena de conexión a tu base de datos
        string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";

        // Variable para almacenar el ID del cliente
        public static int ClienteID { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            string nombreCompleto = rjTexbox1.Texts; // Cambiado de "usuario" a "nombreCompleto"
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
                // Abrir formulario principal
                Main mainForm = new Main();
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

                    // Consulta directa a la tabla Cliente
                    string query = @"
                    SELECT ID 
                    FROM Cliente
                    WHERE NombreCompleto = @NombreCompleto 
                    AND Contrasena = @Contraseña";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            ClienteID = Convert.ToInt32(result);
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro Rgister = new Registro();
            Rgister.Show();
            this.Hide();

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
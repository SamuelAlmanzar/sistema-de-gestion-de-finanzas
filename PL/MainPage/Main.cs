using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL.MainPage
{
    public partial class Main : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";
        private string nombreUsuario;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CargarNombreUsuario();
        }

        private void CargarNombreUsuario()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obtener el nombre del último usuario activo (logeado o registrado)
                    string query = @"
                    SELECT TOP 1 NombreCompleto 
                    FROM Cliente 
                    WHERE UltimoAcceso IS NOT NULL
                    ORDER BY UltimoAcceso DESC";

                    // Alternativa si no tienes campo UltimoAcceso:
                    /*
                    string query = @"
                    SELECT TOP 1 NombreCompleto 
                    FROM Cliente 
                    ORDER BY CASE WHEN UltimoAcceso IS NOT NULL THEN 0 ELSE 1 END, 
                             UltimoAcceso DESC, 
                             ID DESC";
                    */

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        nombreUsuario = cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Mostrar solo el primer nombre si es muy largo
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                string nombreMostrar = nombreUsuario;
                if (nombreUsuario.Contains(" "))
                {
                    nombreMostrar = nombreUsuario.Split(' ')[0];
                }
                roundButton5.Text = nombreMostrar;
            }
            else
            {
                roundButton5.Text = "Usuario";
            }
        }

        private void roundButton5_Click(object sender, EventArgs e)
        {
            // Mostrar información del usuario al hacer clic
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show($"Usuario actual: {nombreUsuario}",
                              "Información de Usuario",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }

        // Resto de tus métodos existentes...
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void guna2CircleButton2_Click(object sender, EventArgs e) { }
        private void roundButton4_Click(object sender, EventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
    }
}
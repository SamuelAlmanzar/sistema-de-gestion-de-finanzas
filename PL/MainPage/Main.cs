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

                    // Obtener el último usuario registrado o logeado
                    string query = @"
                    SELECT TOP 1 NombreCompleto 
                    FROM Cliente 
                    ORDER BY ID DESC"; // Asume que ID es autoincremental

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

            roundButton5.Text = !string.IsNullOrEmpty(nombreUsuario) ? nombreUsuario : "Usuario";
        }

        // Resto de tus métodos existentes...
    }
}
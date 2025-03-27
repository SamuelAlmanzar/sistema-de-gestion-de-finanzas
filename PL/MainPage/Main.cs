using System;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProyectoFinalMargarita.PL.CRUD_CUENTAS;
using ProyectoFinalMargarita.PL.Ingreso_Egreso;


namespace ProyectoFinalMargarita
{
    public partial class Main : Form
    {
        private static readonly string filePath = "Relogin.json"; // Archivo JSON
        private string nombreUsuario;
        private string correoUsuario;

        string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";

        public Main(string actualUserName)
        {
            InitializeComponent();
            nombreUsuario = actualUserName;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario(); // Obtiene los datos desde la base de datos

            roundButton5.Text = !string.IsNullOrEmpty(nombreUsuario) ? nombreUsuario : "Usuario";
        }

        private void CargarDatosUsuario()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var data = JsonConvert.DeserializeObject<dynamic>(json);
                    correoUsuario = data.Correo;

                    if (!string.IsNullOrEmpty(correoUsuario))
                    {
                        ObtenerDatosDesdeDB(correoUsuario);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ObtenerDatosDesdeDB(string correo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT NombreCompleto FROM Cliente WHERE CorreoElectronico = @Correo";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            nombreUsuario = reader["NombreCompleto"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos del usuario: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Botón para cerrar sesión
        private void roundButton6_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Mostrar el formulario de Login
            Login loginForm = new Login();
            loginForm.Show();

            // Cerrar el formulario actual
            this.Close();
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            new CRUDCUENTASBANCARIASNEW().Show();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            new Ingreso_Egreso().Show();
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            new Ahorro().Show();
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using ProyectoFinalMargarita;

namespace ProyectoFinalMargarita.PL
{

    public partial class CRUD_Cuentas_Bancarias : Form
    {
        private string connectionString = "Data Source=DESKTOP-K8E3C18;Initial Catalog=Sistema_Finanzas_Personales;Integrated Security=True";
        

        public CRUD_Cuentas_Bancarias()
        {
            InitializeComponent();
        }

        private void prueba_Load(object sender, EventArgs e)
        {
            CargarCuentas();
        }

        public void CrearCuenta(CuentaBancaria cuenta)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CuentasBancarias (usuario_id, banco, tipo_cuenta, numero_cuenta, saldo, moneda, fecha_creacion) VALUES (@UsuarioId, @Banco, @TipoCuenta, @NumeroCuenta, @Saldo, @Moneda, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", cuenta.UsuarioId);
                cmd.Parameters.AddWithValue("@Banco", cuenta.Banco);
                cmd.Parameters.AddWithValue("@TipoCuenta", cuenta.TipoCuenta);
                cmd.Parameters.AddWithValue("@NumeroCuenta", cuenta.NumeroCuenta);
                cmd.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                cmd.Parameters.AddWithValue("@Moneda", cuenta.Moneda);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public List<CuentaBancaria> ObtenerCuentas(int usuarioId)
        {
            List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM CuentasBancarias WHERE usuario_id = @UsuarioId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cuentas.Add(new CuentaBancaria()
                    {
                        Id = (int)reader["id"],
                        UsuarioId = (int)reader["usuario_id"],
                        Banco = reader["banco"].ToString(),
                        TipoCuenta = reader["tipo_cuenta"].ToString(),
                        NumeroCuenta = reader["numero_cuenta"].ToString(),
                        Saldo = (decimal)reader["saldo"],
                        Moneda = reader["moneda"].ToString(),
                        FechaCreacion = (DateTime)reader["fecha_creacion"]
                    });
                }
            }
            return cuentas;
        }

        public void EditarCuenta(CuentaBancaria cuenta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE CuentasBancarias SET banco = @Banco, tipo_cuenta = @TipoCuenta, saldo = @Saldo, moneda = @Moneda WHERE id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", cuenta.Id);
                cmd.Parameters.AddWithValue("@Banco", cuenta.Banco);
                cmd.Parameters.AddWithValue("@TipoCuenta", cuenta.TipoCuenta);
                cmd.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                cmd.Parameters.AddWithValue("@Moneda", cuenta.Moneda);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void EliminarCuenta(int cuentaId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CuentasBancarias WHERE id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", cuentaId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para cargar las cuentas en el DataGridView
        private void CargarCuentas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT c.id, u.nombre AS Propietario, c.Banco, c.Tipo_cuenta, 
                           c.Numero_cuenta, c.Saldo, c.Fecha_creacion as Fecha_de_creacion
                    FROM CuentasBancarias c
                    INNER JOIN usuarios u ON c.usuario_id = u.id";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DatosCuentas.DataSource = dt;
            }
        }


        private void DatosCuentas_SelectionChanged(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Evento que se activa cuando se selecciona una fila en el DataGridView
        private void DatosCuentas_SelectionChanged_1(object sender, EventArgs e)
        {
            if (DatosCuentas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = DatosCuentas.SelectedRows[0];

                // Asigna los valores a los TextBox
                textPropietario.Text = fila.Cells["Propietario"].Value.ToString();
                textBanco.Text = fila.Cells["Banco"].Value.ToString();
                textTipoCuenta.Text = fila.Cells["Tipo_cuenta"].Value.ToString();
                numeroDeCuenta.Text = fila.Cells["Numero_cuenta"].Value.ToString();
                textSaldo.Text = fila.Cells["Saldo"].Value.ToString();
                textCreacion.Text = fila.Cells["Fecha_de_creacion"].Value.ToString();

                // 🔹 Formatear saldo como dinero
                decimal saldo = Convert.ToDecimal(fila.Cells["saldo"].Value);
                textSaldo.Text = saldo.ToString("C", new CultureInfo("es-DO")); // Formato en pesos dominicanos

            }
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            textPropietario.Text = "";
            textBanco.Text = " ";
            textTipoCuenta.Text = " ";
            numeroDeCuenta.Text = " ";
            textSaldo.Text = "";
            textCreacion.Text = " ";
        }

        private void agregar_Click(object sender, EventArgs e)
        {
           
        }
    }
}   

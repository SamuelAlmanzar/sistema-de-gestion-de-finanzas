using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL.CRUD_CUENTAS
{
    public partial class Historial : Form
    {
        private string connectionString = "tu_cadena_de_conexion_aqui";
        private int ClienteID;

        public Historial(int clienteID)
        {
            InitializeComponent();
            ClienteID = clienteID;
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            CargarHistorialTransacciones();
        }

        private void CargarHistorialTransacciones()
        {
            string query = @"
                SELECT 
                    T.ID AS TransaccionID,
                    T.TipoTransaccion,
                    T.Monto,
                    T.Descripcion,
                    T.Categoria,
                    T.Fecha,
                    CASE 
                        WHEN T.TipoTransaccion = 'Egreso' THEN 'Otro cliente'
                        ELSE 'N/A' 
                    END AS HaciaQuien,
                    T.Monto AS Cuanto,
                    T.Fecha AS Cuando,
                    CASE 
                        WHEN T.TipoTransaccion = 'Ingreso' THEN 'Sí'
                        ELSE 'No'
                    END AS DepositoATi
                FROM 
                    Transacciones T
                INNER JOIN 
                    Cuentas C ON T.CuentaID = C.ID
                WHERE 
                    C.ClienteID = @ClienteID
                ORDER BY 
                    T.Fecha DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ClienteID", ClienteID);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                guna2DataGridView1.DataSource = dataTable;
            }
        }
    }
}

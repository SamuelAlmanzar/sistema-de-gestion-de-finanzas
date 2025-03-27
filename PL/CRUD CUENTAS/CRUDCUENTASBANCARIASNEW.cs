using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL.CRUD_CUENTAS
{
    public partial class CRUDCUENTASBANCARIASNEW : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;Connect Timeout=30;";
        private int selectedId = -1;

        public CRUDCUENTASBANCARIASNEW()
        {
            InitializeComponent();
            CargarDatos();
            ConfigurarDataGridView();
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                    id AS 'ID',
                                    propietario AS 'Propietario',
                                    numero_cuenta AS 'Número de Cuenta',
                                    tipo_cuenta AS 'Tipo',
                                    banco AS 'Banco',
                                    FORMAT(saldo, 'C2') AS 'Saldo',
                                    CONVERT(VARCHAR, Fecha, 103) AS 'Fecha'
                                    FROM CUENTAS
                                    ORDER BY Fecha DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            guna2DataGridView1.EnableHeadersVisualStyles = false;
            guna2DataGridView1.ColumnHeadersHeight = 35;

            // Evento para selección de filas
            guna2DataGridView1.SelectionChanged += (s, e) =>
            {
                if (guna2DataGridView1.SelectedRows.Count > 0)
                {
                    selectedId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ID"].Value);
                }
            };
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Seleccione una cuenta para eliminar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea eliminar esta cuenta?", "Confirmar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM CUENTAS WHERE id = @Id";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", selectedId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cuenta eliminada correctamente", "Éxito",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarDatos(); // Refrescar los datos
                                selectedId = -1; // Resetear el ID seleccionado
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            new FORMCUENTAS().Show();
        }

        // ... (mantén el resto de tus métodos existentes igual)
    }
}
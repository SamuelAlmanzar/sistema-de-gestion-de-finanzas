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
            ConfigurarDataGridView();
        }

        private void CRUDCUENTASBANCARIASNEW_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos iniciales: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarDatosClientes()
        {
            try
            {
                guna2DataGridView1.DataSource = null;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                    ID AS 'ID',
                                    NombreCompleto AS 'Nombre Completo',
                                    CorreoElectronico AS 'Correo',
                                    Telefono AS 'Teléfono',
                                    CONVERT(VARCHAR, FechaNacimiento, 103) AS 'Fecha Nacimiento',
                                    Direccion AS 'Dirección',
                                    CONVERT(VARCHAR, FechaRegistro, 120) AS 'Fecha Registro'
                                   FROM Cliente
                                   ORDER BY ID DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    guna2DataGridView1.DataSource = dt;

                    // Restablecer la selección después de cargar
                    selectedId = -1;
                    ActualizarEstadoBotones();

                    // Seleccionar automáticamente la primera fila si existe
                    if (guna2DataGridView1.Rows.Count > 0)
                    {
                        guna2DataGridView1.Rows[0].Selected = true;
                        selectedId = Convert.ToInt32(guna2DataGridView1.Rows[0].Cells["ID"].Value);
                        ActualizarEstadoBotones();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            guna2DataGridView1.EnableHeadersVisualStyles = false;
            guna2DataGridView1.ColumnHeadersHeight = 35;
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            guna2DataGridView1.MultiSelect = false;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < guna2DataGridView1.Rows.Count)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                if (row.Cells["ID"].Value != null)
                {
                    selectedId = Convert.ToInt32(row.Cells["ID"].Value);
                    ActualizarEstadoBotones();
                }
            }
        }

        private void ActualizarEstadoBotones()
        {
            roundButton4.Enabled = (selectedId > 0);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatosClientes();
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            var formUsuarios = new CRUDUSUARIOS();

            // Suscribirse al evento de registro exitoso
            formUsuarios.UsuarioRegistrado += (s, ev) =>
            {
                // Esto se ejecutará cuando se registre un nuevo usuario
                this.Invoke((MethodInvoker)delegate
                {
                    CargarDatosClientes();
                    MessageBox.Show("Cliente registrado correctamente. Los datos se han actualizado.", "Éxito",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            };

            formUsuarios.Show();
        }

        private void roundButton4_Click_1(object sender, EventArgs e)
        {
            if (selectedId > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este cliente?",
                                                   "Confirmar Eliminación",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Verificación de relaciones
                            string[] posiblesColumnas = { "ID_Cliente", "ClienteID", "Cliente_ID" };
                            bool tieneRelaciones = false;

                            foreach (string columna in posiblesColumnas)
                            {
                                try
                                {
                                    string checkQuery = $"SELECT COUNT(*) FROM CuentasBancarias WHERE {columna} = @ID";
                                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                                    {
                                        checkCmd.Parameters.AddWithValue("@ID", selectedId);
                                        int count = (int)checkCmd.ExecuteScalar();

                                        if (count > 0)
                                        {
                                            tieneRelaciones = true;
                                            break;
                                        }
                                    }
                                }
                                catch { /* Si falla, probamos con la siguiente columna */ }
                            }

                            if (tieneRelaciones)
                            {
                                MessageBox.Show("No se puede eliminar el cliente porque tiene cuentas bancarias asociadas",
                                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string deleteQuery = "DELETE FROM Cliente WHERE ID = @ID";
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@ID", selectedId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cliente eliminado correctamente", "Éxito",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Actualizar los datos y selección
                                    CargarDatosClientes();
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró el cliente a eliminar", "Advertencia",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        string mensaje = sqlEx.Number == 547 ?
                            "No se puede eliminar el cliente porque tiene registros relacionados en otras tablas" :
                            $"Error SQL al eliminar cliente (Código {sqlEx.Number}): {sqlEx.Message}";

                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error general al eliminar cliente: {ex.Message}", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente primero", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void roundButton3_Click_2(object sender, EventArgs e)
        {
            new CRUDUSUARIOS().Show();

        }
    }
}
using ProyectoFinalMargarita.PL;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class Ahorro : Form
    {
        private FormAhorro formAhorro;
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=BancoDB;Integrated Security=True;";

        public Ahorro()
        {
            InitializeComponent();
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Ahorro_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarMetasAhorro();
        }

        private void ConfigurarDataGridView()
        {
            guna2DataGridView1.Columns.Clear();

            guna2DataGridView1.Columns.Add("Meta", "Meta");
            guna2DataGridView1.Columns.Add("MontoObjetivo", "Monto Objetivo");
            guna2DataGridView1.Columns.Add("MontoAhorrado", "Monto Ahorrado");
            guna2DataGridView1.Columns.Add("FechaObjetivo", "Fecha Objetivo");
            guna2DataGridView1.Columns.Add("DiasRestantes", "Días Restantes");
            guna2DataGridView1.Columns.Add("Progreso", "Progreso");

            guna2DataGridView1.Columns["MontoObjetivo"].DefaultCellStyle.Format = "C";
            guna2DataGridView1.Columns["MontoAhorrado"].DefaultCellStyle.Format = "C";
            guna2DataGridView1.Columns["Progreso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void CargarMetasAhorro()
        {
            try
            {
                guna2DataGridView1.Rows.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT NombreMeta, MontoObjetivo, MontoAhorrado, FechaObjetivo FROM MetasAhorro ORDER BY FechaObjetivo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string meta = reader["NombreMeta"].ToString();
                            decimal monto = Convert.ToDecimal(reader["MontoObjetivo"]);
                            decimal ahorrado = Convert.ToDecimal(reader["MontoAhorrado"]);
                            DateTime fecha = Convert.ToDateTime(reader["FechaObjetivo"]);

                            int diasRestantes = (fecha - DateTime.Today).Days;
                            diasRestantes = diasRestantes > 0 ? diasRestantes : 0;

                            decimal porcentaje = monto > 0 ? (ahorrado / monto) * 100 : 0;
                            porcentaje = porcentaje > 100 ? 100 : porcentaje;

                            guna2DataGridView1.Rows.Add(
                                meta,
                                monto,
                                ahorrado,
                                fecha.ToString("yyyy-MM-dd"),
                                diasRestantes,
                                porcentaje.ToString("0.00") + "%"
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar metas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            if (formAhorro == null || formAhorro.IsDisposed)
            {
                formAhorro = new FormAhorro();
                formAhorro.DatosGuardados += CargarMetasAhorro;
                formAhorro.Show();
            }
            else
            {
                formAhorro.BringToFront();
            }
        }

        private void roundButton5_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                string nombreMeta = selectedRow.Cells["Meta"].Value.ToString();
                decimal montoObjetivo = Convert.ToDecimal(selectedRow.Cells["MontoObjetivo"].Value);
                decimal montoAhorrado = Convert.ToDecimal(selectedRow.Cells["MontoAhorrado"].Value);
                DateTime fechaObjetivo = Convert.ToDateTime(selectedRow.Cells["FechaObjetivo"].Value);

                FormAhorro formEdicion = new FormAhorro();
                formEdicion.ModoEdicion = true;
                formEdicion.MetaOriginal = nombreMeta;
                formEdicion.CargarDatosParaEdicion(nombreMeta, montoObjetivo, montoAhorrado, fechaObjetivo);
                formEdicion.DatosGuardados += CargarMetasAhorro;
                formEdicion.Show();
            }
            else
            {
                MessageBox.Show("Por favor seleccione una meta para editar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("¿Está seguro de eliminar esta meta de ahorro?",
                                                   "Confirmar Eliminación",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        string meta = guna2DataGridView1.SelectedRows[0].Cells["Meta"].Value.ToString();

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "DELETE FROM MetasAhorro WHERE NombreMeta = @NombreMeta";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@NombreMeta", meta);
                                int result = command.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    MessageBox.Show("Meta eliminada correctamente", "Éxito",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargarMetasAhorro();
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
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Ahorro_Activated(object sender, EventArgs e)
        {
            CargarMetasAhorro();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica adicional para clicks en celdas si es necesario
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una meta para eliminar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener la meta seleccionada
            string nombreMeta = guna2DataGridView1.SelectedRows[0].Cells["Meta"].Value.ToString();

            // Pedir confirmación
            var confirmResult = MessageBox.Show($"¿Está seguro que desea eliminar la meta '{nombreMeta}'?",
                                              "Confirmar Eliminación",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM MetasAhorro WHERE NombreMeta = @NombreMeta";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@NombreMeta", nombreMeta);
                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Meta eliminada correctamente", "Éxito",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarMetasAhorro(); // Refrescar el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la meta para eliminar", "Advertencia",
                                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    string errorMessage = "Error al eliminar la meta:\n";

                    // Manejo específico de errores comunes
                    if (sqlEx.Number == 547) // Error de restricción FK
                    {
                        errorMessage += "No se puede eliminar porque tiene registros relacionados.";
                    }
                    else
                    {
                        errorMessage += sqlEx.Message;
                    }

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
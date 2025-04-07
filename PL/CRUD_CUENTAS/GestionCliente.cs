using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL
{
    public partial class GestionCliente : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=BancoDB;Integrated Security=True;Connect Timeout=30;";
        private DataTable dataTable;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder commandBuilder;

        public GestionCliente()
        {
            InitializeComponent();
        }

        private void GestionCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            string query = "SELECT ID, Nombres, Apellidos, Genero, FechaNacimiento, TipoDocumento, NumeroDocumento, CorreoElectronico, Telefono FROM Cliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(query, connection);
                commandBuilder = new SqlCommandBuilder(adapter); // Esto crea los comandos de actualización necesarios
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridView1.DataSource = dataTable;

                // Configuración del DataGridView
                guna2DataGridView1.Columns["ID"].Visible = false; // Ocultar columna ID
                guna2DataGridView1.ReadOnly = false; // Habilitar la edición de celdas
                guna2DataGridView1.AllowUserToAddRows = false;
                guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                guna2DataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2; // Permitir edición al presionar F2 o escribir
            }
        }

        // Este evento se activa después de que se edita una celda
        private void guna2DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GuardarCambios();
        }

        private void GuardarCambios()
        {
            try
            {
                if (dataTable != null)
                {
                    // Usamos el SqlDataAdapter para actualizar los cambios en la base de datos
                    adapter.Update(dataTable);
                    MessageBox.Show("Cambios guardados correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
                int idCliente = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                DialogResult result = MessageBox.Show("¿Estás seguro que deseas eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    EliminarCliente(idCliente);
                    CargarClientes(); // Refrescar el DataGridView
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarCliente(int idCliente)
        {
            string deleteQuery = "DELETE FROM Cliente WHERE ID = @IdCliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void roundButton5_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

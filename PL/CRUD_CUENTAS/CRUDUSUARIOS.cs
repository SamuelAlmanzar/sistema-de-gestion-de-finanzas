using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL.CRUD_CUENTAS
{
    public partial class CRUDUSUARIOS : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=BancoDB;Integrated Security=True;Connect Timeout=30;";
        private bool esEdicion = false;
        private int idCliente;

        public CRUDUSUARIOS()
        {
            InitializeComponent();
        }

        public void LlenarDatosParaEditar(int id, string nombres, string apellidos, string genero, DateTime fechaNacimiento, string tipoDocumento, string numeroDocumento, string correo, string telefono)
        {
            esEdicion = true;
            idCliente = id;

            rjTexbox1.Texts = nombres;
            rjTexbox6.Texts = apellidos;
            comboBox2.SelectedItem = genero;
            guna2DateTimePicker1.Value = fechaNacimiento;
            comboBox1.SelectedItem = tipoDocumento;
            rjTexbox8.Texts = numeroDocumento;
            rjTexbox2.Texts = correo;
            rjTexbox3.Texts = telefono;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (esEdicion)
                {
                    string updateQuery = @"UPDATE Cliente SET 
                        Nombres = @Nombres,
                        Apellidos = @Apellidos,
                        Genero = @Genero,
                        FechaNacimiento = @FechaNacimiento,
                        TipoDocumento = @TipoDocumento,
                        NumeroDocumento = @NumeroDocumento,
                        CorreoElectronico = @Correo,
                        Telefono = @Telefono
                        WHERE ID = @IdCliente";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", rjTexbox1.Texts.Trim());
                        cmd.Parameters.AddWithValue("@Apellidos", rjTexbox6.Texts.Trim());
                        cmd.Parameters.AddWithValue("@Genero", comboBox2.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@FechaNacimiento", guna2DateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@TipoDocumento", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@NumeroDocumento", rjTexbox8.Texts.Trim());
                        cmd.Parameters.AddWithValue("@Correo", rjTexbox2.Texts.Trim());
                        cmd.Parameters.AddWithValue("@Telefono", rjTexbox3.Texts.Trim());
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cliente actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cierra el formulario después de guardar
                }
                else
                {
                    // Aquí va tu lógica de nuevo registro si lo deseas
                }
            }
        }
    }
}

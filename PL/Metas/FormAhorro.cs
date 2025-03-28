using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL
{
    public partial class FormAhorro : Form
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=FINANCETRACK;Integrated Security=True;";
        public event Action DatosGuardados;
        public bool ModoEdicion { get; set; } = false;
        public string MetaOriginal { get; set; }

        public FormAhorro()
        {
            InitializeComponent();
            guna2DateTimePicker1.MinDate = DateTime.Today;
        }

        public void CargarDatosParaEdicion(string nombreMeta, decimal montoObjetivo, decimal montoAhorrado, DateTime fechaObjetivo)
        {
            rjTexbox1.Texts = nombreMeta;
            rjTexbox2.Texts = montoObjetivo.ToString("0.00");
            rjTexbox3.Texts = montoAhorrado.ToString("0.00");
            guna2DateTimePicker1.Value = fechaObjetivo;
            guna2Button1.Text = "Actualizar Meta";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            GuardarMetaAhorro();
        }

        private void GuardarMetaAhorro()
        {
            if (!ValidarCampos())
                return;

            if (!ObtenerValores(out string nombreMeta, out decimal montoObjetivo, out decimal montoAhorrado))
                return;

            if (!ValidarReglasNegocio(montoObjetivo, montoAhorrado))
                return;

            GuardarEnBaseDeDatos(nombreMeta, montoObjetivo, montoAhorrado);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(rjTexbox1.Texts))
            {
                MostrarError("Por favor ingrese el nombre de la meta", rjTexbox1);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox2.Texts))
            {
                MostrarError("Por favor ingrese el monto objetivo", rjTexbox2);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rjTexbox3.Texts))
            {
                rjTexbox3.Texts = "0";
            }

            return true;
        }

        private bool ObtenerValores(out string nombreMeta, out decimal montoObjetivo, out decimal montoAhorrado)
        {
            nombreMeta = rjTexbox1.Texts.Trim();
            montoObjetivo = 0;
            montoAhorrado = 0;

            if (!decimal.TryParse(rjTexbox2.Texts, out montoObjetivo) || montoObjetivo <= 0)
            {
                MostrarError("El monto objetivo debe ser un número mayor a cero", rjTexbox2);
                return false;
            }

            if (!decimal.TryParse(rjTexbox3.Texts, out montoAhorrado) || montoAhorrado < 0)
            {
                MostrarError("El monto ahorrado debe ser un número positivo", rjTexbox3);
                return false;
            }

            return true;
        }

        private bool ValidarReglasNegocio(decimal montoObjetivo, decimal montoAhorrado)
        {
            if (montoAhorrado > montoObjetivo)
            {
                MostrarError("El monto ahorrado no puede ser mayor al monto objetivo", rjTexbox3);
                return false;
            }

            if (guna2DateTimePicker1.Value < DateTime.Today)
            {
                MostrarError("La fecha objetivo no puede ser anterior al día de hoy", guna2DateTimePicker1);
                return false;
            }

            return true;
        }

        private void GuardarEnBaseDeDatos(string nombreMeta, decimal montoObjetivo, decimal montoAhorrado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query;
                    if (ModoEdicion)
                    {
                        query = @"UPDATE MetasAhorro 
                                SET NombreMeta = @NombreMeta, 
                                    MontoObjetivo = @MontoObjetivo, 
                                    MontoAhorrado = @MontoAhorrado, 
                                    FechaObjetivo = @FechaObjetivo
                                WHERE NombreMeta = @MetaOriginal";
                    }
                    else
                    {
                        query = @"INSERT INTO MetasAhorro 
                                (NombreMeta, MontoObjetivo, MontoAhorrado, FechaObjetivo) 
                                VALUES 
                                (@NombreMeta, @MontoObjetivo, @MontoAhorrado, @FechaObjetivo);
                                SELECT SCOPE_IDENTITY();";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreMeta", nombreMeta);
                        command.Parameters.AddWithValue("@MontoObjetivo", montoObjetivo);
                        command.Parameters.AddWithValue("@MontoAhorrado", montoAhorrado);
                        command.Parameters.AddWithValue("@FechaObjetivo", guna2DateTimePicker1.Value.Date);

                        if (ModoEdicion)
                        {
                            command.Parameters.AddWithValue("@MetaOriginal", MetaOriginal);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MostrarExito("Meta actualizada exitosamente");
                                LimpiarCampos();
                                DatosGuardados?.Invoke();
                                this.Close();
                            }
                            else
                            {
                                MostrarError("No se pudo actualizar la meta de ahorro");
                            }
                        }
                        else
                        {
                            int newId = Convert.ToInt32(command.ExecuteScalar());
                            if (newId > 0)
                            {
                                MostrarExito("Meta de ahorro guardada exitosamente");
                                LimpiarCampos();
                                DatosGuardados?.Invoke();
                                this.Close();
                            }
                            else
                            {
                                MostrarError("No se pudo guardar la meta de ahorro");
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                string mensajeError = $"Error de base de datos (SQL #{sqlEx.Number}):\n";

                switch (sqlEx.Number)
                {
                    case -1:
                        mensajeError += "No se pudo conectar al servidor. Verifique:\n";
                        mensajeError += "1. Que SQL Server esté corriendo\n";
                        mensajeError += "2. Que el nombre del servidor sea correcto\n";
                        mensajeError += "3. Que su red esté funcionando\n";
                        break;
                    case 18456:
                        mensajeError += "Error de autenticación. Verifique usuario y contraseña.";
                        break;
                    case 2627: // Violación de clave única
                        mensajeError += "Ya existe una meta con ese nombre. Por favor use un nombre diferente.";
                        break;
                    default:
                        mensajeError += sqlEx.Message;
                        break;
                }

                MostrarError(mensajeError);
            }
            catch (Exception ex)
            {
                MostrarError($"Error inesperado: {ex.Message}");
            }
        }

        private void MostrarError(string mensaje, Control control = null)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            control?.Focus();
        }

        private void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarCampos()
        {
            rjTexbox1.Texts = "";
            rjTexbox2.Texts = "";
            rjTexbox3.Texts = "";
            guna2DateTimePicker1.Value = DateTime.Today;
            rjTexbox1.Focus();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rjTexbox2__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rjTexbox2.Texts) && !decimal.TryParse(rjTexbox2.Texts, out _))
            {
                MessageBox.Show("Solo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rjTexbox2.Texts = "";
            }
        }

        private void rjTexbox3__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rjTexbox3.Texts) && !decimal.TryParse(rjTexbox3.Texts, out _))
            {
                MessageBox.Show("Solo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rjTexbox3.Texts = "";
            }
        }
    }
}
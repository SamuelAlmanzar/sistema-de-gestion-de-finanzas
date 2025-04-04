using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class Registro : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=BancoDB;Integrated Security=True;Connect Timeout=30;";
        private bool isEditing = false;


        public Registro()
        {
            InitializeComponent();
            telefono_persona.KeyPress += Telefono_KeyPress;
            telefono_persona.TextChanged += Telefono_TextChanged;
            Siguiente_Personal.Click += Siguiente_Personal_Click;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        private bool CamposCompletos()
        {
            if (string.IsNullOrWhiteSpace(Nombre_Personal.Texts) ||
                string.IsNullOrWhiteSpace(Apellidos_Personal.Texts) ||
                string.IsNullOrWhiteSpace(Numerodoc_personal.Text) ||
                string.IsNullOrWhiteSpace(Correo_personal.Texts) ||
                string.IsNullOrWhiteSpace(telefono_persona.Text) ||
                Genero.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidarDatos()
        {
            if (!Regex.IsMatch(Correo_personal.Texts.Trim(), @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                MessageBox.Show("Correo electrónico debe ser un Gmail válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Telefono_TextChanged(object sender, EventArgs e)
        {
            string numero = Regex.Replace(telefono_persona.Text, "[^0-9]", "");
            if (numero.Length > 10) numero = numero.Substring(0, 10);

            if (numero.Length > 6)
                telefono_persona.Text = $"({numero.Substring(0, 3)}) {numero.Substring(3, 3)}-{numero.Substring(6)}";
            else if (numero.Length > 3)
                telefono_persona.Text = $"({numero.Substring(0, 3)}) {numero.Substring(3)}";
            else if (numero.Length > 0)
                telefono_persona.Text = $"({numero}";

            telefono_persona.SelectionStart = telefono_persona.Text.Length;
        }




        private void Siguiente_Personal_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos() || !ValidarDatos())
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Cliente (Nombres, Apellidos, Genero, FechaNacimiento, TipoDocumento, NumeroDocumento, CorreoElectronico, Telefono) 
                                  VALUES (@Nombres, @Apellidos, @Genero, @FechaNacimiento,@TipoDocumento, @NumeroDocumento, @Correo, @Telefono);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombres", Nombre_Personal.Texts.Trim());
                        command.Parameters.AddWithValue("@Apellidos", Apellidos_Personal.Texts.Trim());
                        command.Parameters.AddWithValue("@Genero", Genero.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@FechaNacimiento", guna2DateTimePicker1.Value.Date);
                        command.Parameters.AddWithValue("@TipoDocumento", TipoDoc.Text.Trim());
                        command.Parameters.AddWithValue("@NumeroDocumento", Numerodoc_personal.Text.Trim());
                        command.Parameters.AddWithValue("@Correo", Correo_personal.Texts.Trim());
                        command.Parameters.AddWithValue("@Telefono", telefono_persona.Text.Trim());

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registro exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InformacionFinanciera infoFinancieraForm = new InformacionFinanciera();
                infoFinancieraForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void Numerodoc_personal_Leave_1(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"(\w{3})(\w{4})");

            StringBuilder builder = new StringBuilder();

            Match[] matches = regex.Matches(Numerodoc_personal.Text).Cast<Match>().ToArray();

            foreach (Match match in matches)
            {

                builder.Append($"{match.Value}-");
            }

            builder.Remove(builder.Length - 1, 1);

            Numerodoc_personal.Text = builder.ToString();
        }

        private void Numerodoc_personal_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
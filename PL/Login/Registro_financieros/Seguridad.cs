using ProyectoFinalMargarita.Clases.Class_registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;


namespace ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros
{
    public partial class Seguridad : Form
    {
        public Seguridad()
        {
            InitializeComponent();

            // Cargar datos existentes si los hay
            CargarDatosExistentes();
        }




        private void CargarDatosExistentes()
        {
            if (DatosTemporales.Seguridad != null)
            {
                if (!string.IsNullOrEmpty(DatosTemporales.Seguridad.MetodoRecuperacion))
                    Metodo_de_recuperacion.SelectedItem = DatosTemporales.Seguridad.MetodoRecuperacion;

                Aunteticacion_Dos_pasos.SelectedIndex = DatosTemporales.Seguridad.AutenticacionDosPasos ? 1 : 0;

                Nombre_mascota.Text = DatosTemporales.Seguridad.RespuestaSeguridad;
                Ciudad_Donde_nacio.Text = DatosTemporales.Seguridad.PreguntaSeguridad;
            }
        }

        private bool ValidarContraseñas()
        {
            if (string.IsNullOrWhiteSpace(Contraseña.Text))
            {
                MessageBox.Show("Por favor ingrese una contraseña");
                return false;
            }

            if (Contraseña.Text.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres");
                return false;
            }

            if (Contraseña.Text != Confirmarcontraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return false;
            }

            return true;
        }

        private bool ValidarPreguntasSeguridad()
        {
            if (string.IsNullOrWhiteSpace(Nombre_mascota.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre de su primera mascota");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Ciudad_Donde_nacio.Text))
            {
                MessageBox.Show("Por favor ingrese la ciudad donde nació");
                return false;
            }

            return true;
        }

        private void roundButton3_Click(object sender, EventArgs e) // Botón Atrás
        {
            // Guardar datos temporalmente antes de volver
            if (Metodo_de_recuperacion.SelectedIndex != -1)
                DatosTemporales.Seguridad.MetodoRecuperacion = Metodo_de_recuperacion.SelectedItem.ToString();

            DatosTemporales.Seguridad.AutenticacionDosPasos = Aunteticacion_Dos_pasos.SelectedIndex == 1;
            DatosTemporales.Seguridad.PreguntaSeguridad = Ciudad_Donde_nacio.Text;
            DatosTemporales.Seguridad.RespuestaSeguridad = Nombre_mascota.Text;

            // Volver al formulario anterior
            var formAnterior = new Proposito_de_Cuenta();
            formAnterior.Show();
            this.Close();
        }

        private void roundButton2_Click(object sender, EventArgs e) // Botón Finalizar
        {
           

            
        }

        private void GuardarDatosEnJson()
        {
            try
            {
                // Crear objeto con todos los datos
                var datosCompletos = new
                {
                    Cliente = DatosTemporales.Cliente,
                    InformacionFinanciera = DatosTemporales.InfoFinanciera,
                    PropositoCuenta = DatosTemporales.Proposito,
                    SeguridadCuenta = DatosTemporales.Seguridad,
                    FechaRegistro = DateTime.Now
                };

                // Serializar a JSON
                string json = JsonSerializer.Serialize(datosCompletos, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Para caracteres especiales
                });

                // Crear directorio si no existe
                string directorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RegistrosBanco");
                Directory.CreateDirectory(directorio);

                // Crear nombre de archivo único
                string nombreArchivo = $"Registro_{DatosTemporales.Cliente.NumeroDocumento}_{DateTime.Now:yyyyMMddHHmmss}.json";
                string rutaCompleta = Path.Combine(directorio, nombreArchivo);

                // Guardar archivo
                File.WriteAllText(rutaCompleta, json);

                // Opcional: Mostrar mensaje con la ubicación del archivo
                MessageBox.Show($"Datos guardados en:\n{rutaCompleta}", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para encriptar contraseña
        private string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool ContraseñaEsFuerte(string contraseña)
        {
            // Al menos 8 caracteres
            if (contraseña.Length < 8)
            {
                MessageBox.Show("Debe tener almenos 8 caracteres");
                return false;
            }


            // Al menos una mayúscula
            if (!contraseña.Any(char.IsUpper))
            {
                MessageBox.Show("Debe tener al menos una mayuscula");
                return false;
            }



            // Al menos un número
            if (!contraseña.Any(char.IsDigit))
            {
                MessageBox.Show("Debe tener almenos un numero");
                return false;
            }



            // Al menos un carácter especial
            if (!contraseña.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Debe tener un caracter especial");
                return false;
            }


            return true;
        }

        private void roundButton2_Click_1(object sender, EventArgs e)
        {
            // Validar campos
            if (!ValidarContraseñas() || !ValidarPreguntasSeguridad() || !ContraseñaEsFuerte(Contraseña.Text))
                return;

            DatosTemporales.Seguridad.Contraseña = EncriptarContraseña(Contraseña.Text);
            DatosTemporales.Seguridad.MetodoRecuperacion = Metodo_de_recuperacion.SelectedItem.ToString();
            DatosTemporales.Seguridad.AutenticacionDosPasos = Aunteticacion_Dos_pasos.SelectedIndex == 1;
            DatosTemporales.Seguridad.PreguntaSeguridad = Ciudad_Donde_nacio.Text;
            DatosTemporales.Seguridad.RespuestaSeguridad = Nombre_mascota.Text;

            // Guardar en JSON
            GuardarDatosEnJson();

            // Mostrar mensaje de éxito
            MessageBox.Show("Registro completado exitosamente. Los datos han sido guardados.");
        }
    }




}

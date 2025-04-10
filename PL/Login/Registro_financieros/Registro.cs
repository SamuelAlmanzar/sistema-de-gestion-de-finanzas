using ProyectoFinalMargarita.Clases.Class_registro;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace ProyectoFinalMargarita
{
    public partial class Registro : Form
    {

        public Registro()
        {
            InitializeComponent();

            // Configurar formato de documento mientras se escribe
            Numerodoc_personal.TextChanged += Numerodoc_personal_TextChanged;

            // Configurar formato de teléfono mientras se escribe
            telefono_persona.TextChanged += Telefono_persona_TextChanged;

            CargarDatosExistente();
        }

        private void Numerodoc_personal_TextChanged(object sender, EventArgs e)
        {
            // Eliminar el evento temporalmente para evitar bucles
            Numerodoc_personal.TextChanged -= Numerodoc_personal_TextChanged;

            try
            {
                // Obtener solo dígitos
                string digits = new string(Numerodoc_personal.Text.Where(char.IsDigit).ToArray());

                // Limitar a 11 caracteres (para formato XXX-XXXXXX-X)
                if (digits.Length > 11)
                {
                    digits = digits.Substring(0, 11);
                }

                // Aplicar formato
                string formatted = digits;
                if (digits.Length > 0) formatted = digits.Insert(0, "-");
                if (digits.Length > 3) formatted = formatted.Insert(4, "-");
                if (digits.Length > 7) formatted = formatted.Insert(8, "-");

                Numerodoc_personal.Text = formatted.TrimStart('-');
                Numerodoc_personal.SelectionStart = Numerodoc_personal.Text.Length;

                // Guardar solo dígitos en la clase temporal
                DatosTemporales.Cliente.NumeroDocumento = digits;
            }
            finally
            {
                // Volver a habilitar el evento
                Numerodoc_personal.TextChanged += Numerodoc_personal_TextChanged;
            }
        }

        private void Telefono_persona_TextChanged(object sender, EventArgs e)
        {
            // Eliminar el evento temporalmente para evitar bucles
            telefono_persona.TextChanged -= Telefono_persona_TextChanged;

            try
            {
                // Obtener solo dígitos
                string digits = new string(telefono_persona.Text.Where(char.IsDigit).ToArray());

                // Limitar a 10 caracteres (para formato (XXX) XXX-XXXX)
                if (digits.Length > 10)
                {
                    digits = digits.Substring(0, 10);
                }

                // Aplicar formato
                string formatted = digits;
                if (digits.Length > 0) formatted = "(" + digits;
                if (digits.Length > 3) formatted = formatted.Insert(4, ") ");
                if (digits.Length > 6) formatted = formatted.Insert(9, "-");

                telefono_persona.Text = formatted;
                telefono_persona.SelectionStart = telefono_persona.Text.Length;

                // Guardar solo dígitos en la clase temporal
                DatosTemporales.Cliente.Telefono = digits;
            }
            finally
            {
                // Volver a habilitar el evento
                telefono_persona.TextChanged += Telefono_persona_TextChanged;
            }
        }

        private bool ValidarCorreo(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }



        private void CargarDatosExistente()
        {
            // Si hay datos en la clase temporal, cargarlos en los controles
            if (DatosTemporales.Cliente != null)
            {
                Nombre_info.Text = DatosTemporales.Cliente.Nombres;
                Apellido_info.Text = DatosTemporales.Cliente.Apellidos;
                Genero.Text = DatosTemporales.Cliente.Genero;

                // Para el ComboBox (Tipo de Documento)
                if (!string.IsNullOrEmpty(DatosTemporales.Cliente.TipoDocumento))
                {
                    TipoDoc.SelectedItem = DatosTemporales.Cliente.TipoDocumento;
                }

                // Para la fecha de nacimiento
                if (DatosTemporales.Cliente.FechaNacimiento != default(DateTime))
                {
                    FechaNacimiento.Value = DatosTemporales.Cliente.FechaNacimiento;
                }

                // Para documentos y teléfono (aplicando formato)
                if (!string.IsNullOrEmpty(DatosTemporales.Cliente.NumeroDocumento))
                {
                    Numerodoc_personal.Text = FormatearDocumento(DatosTemporales.Cliente.NumeroDocumento);
                }

                if (!string.IsNullOrEmpty(DatosTemporales.Cliente.Telefono))
                {
                    telefono_persona.Text = FormatearTelefono(DatosTemporales.Cliente.Telefono);
                }

                CorreoElectronico_info.Text = DatosTemporales.Cliente.CorreoElectronico;
            }
        }

        private string FormatearDocumento(string documento)
        {
            documento = new string(documento.Where(char.IsDigit).ToArray());
            if (documento.Length > 0) documento = documento.Insert(0, "-");
            if (documento.Length > 4) documento = documento.Insert(4, "-");
            if (documento.Length > 10) documento = documento.Insert(10, "-");
            return documento.TrimStart('-');
        }

        private string FormatearTelefono(string telefono)
        {
            telefono = new string(telefono.Where(char.IsDigit).ToArray());
            if (telefono.Length > 0) telefono = "(" + telefono;
            if (telefono.Length > 4) telefono = telefono.Insert(4, ") ");
            return telefono;
        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {

            // Validar longitud de cédula (11 dígitos)
            string docSinFormato = new string(Numerodoc_personal.Text.Where(char.IsDigit).ToArray());
            if (docSinFormato.Length != 11)
            {
                MessageBox.Show("El número de documento debe tener 11 dígitos");
                Numerodoc_personal.Focus();
                return;
            }

            // Validar longitud de teléfono (10 dígitos)
            string telSinFormato = new string(telefono_persona.Text.Where(char.IsDigit).ToArray());
            if (telSinFormato.Length != 10)
            {
                MessageBox.Show("El número de teléfono debe tener 10 dígitos");
                telefono_persona.Focus();
                return;
            }

            if (!ValidarCorreo(CorreoElectronico_info.Text))
            {
                MessageBox.Show("Correo electronico invalido");
                return;
            }

            string email = CorreoElectronico_info.Text.Trim();

            if (!EmailValidator.EsEmailValido(email))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido",
                               "Error de validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
            }

            // Si el email es válido, continuar con el proceso
            DatosTemporales.Cliente.CorreoElectronico = email;

            // Resto de tus validaciones existentes...

            // Guardar datos (ya se actualizan automáticamente en los TextChanged)
            // Solo necesitamos guardar los demás campos:
            DatosTemporales.Cliente.Nombres = Nombre_info.Text;
            DatosTemporales.Cliente.Apellidos = Apellido_info.Text;
            DatosTemporales.Cliente.Genero = Genero.Text;
            DatosTemporales.Cliente.FechaNacimiento = FechaNacimiento.Value;
            DatosTemporales.Cliente.TipoDocumento = TipoDoc.SelectedItem?.ToString();
            DatosTemporales.Cliente.CorreoElectronico = CorreoElectronico_info.Text;

            // Continuar al siguiente formulario
            var formInfoFinanciera = new InformacionFinanciera();
            formInfoFinanciera.Show();
            this.Hide();

        }


        public static class EmailValidator
        {
            // Expresión regular mejorada para validación de emails
            private static readonly Regex EmailRegex = new Regex(
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled,
                TimeSpan.FromMilliseconds(250));

            /// <summary>
            /// Valida una dirección de correo electrónico con múltiples verificaciones
            /// </summary>
            public static bool EsEmailValido(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                try
                {
                    // Verificación básica de estructura
                    if (!EmailRegex.IsMatch(email))
                        return false;

                    // Verificación de dominios conocidos como inválidos
                    if (EsDominioInvalido(email))
                        return false;

                    // Verificación de longitud máxima (254 caracteres según RFC)
                    if (email.Length > 254)
                        return false;

                    // Verificación adicional de sintaxis
                    return VerificarSintaxisProfunda(email);
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            }

            private static bool EsDominioInvalido(string email)
            {
                var dominiosInvalidos = new[]
                {
            "example.com",
            "test.com",
            "fake.com",
            "mailinator.com"
            // Agrega otros dominios que quieras bloquear
        };

                var dominio = email.Split('@').Last().ToLower();
                return dominiosInvalidos.Contains(dominio);
            }

            private static bool VerificarSintaxisProfunda(string email)
            {
                try
                {
                    // Dividir en parte local y dominio
                    var partes = email.Split('@');
                    if (partes.Length != 2)
                        return false;

                    var parteLocal = partes[0];
                    var dominio = partes[1];

                    // La parte local no debe empezar o terminar con punto
                    if (parteLocal.StartsWith(".") || parteLocal.EndsWith("."))
                        return false;

                    // El dominio debe tener al menos un punto
                    if (!dominio.Contains("."))
                        return false;

                    // El dominio no debe tener caracteres consecutivos inválidos
                    if (dominio.Contains("..") || dominio.Contains("--"))
                        return false;

                    // La parte local no debe exceder los 64 caracteres
                    if (parteLocal.Length > 64)
                        return false;

                    return true;
                }
                catch
                {
                    return false;
                }
            }


        }
    }

}
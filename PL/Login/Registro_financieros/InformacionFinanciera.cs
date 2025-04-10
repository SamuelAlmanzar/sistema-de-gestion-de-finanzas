using ProyectoFinalMargarita.Clases.Class_registro;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros;

namespace ProyectoFinalMargarita
{
    public partial class InformacionFinanciera : Form
    {

        public InformacionFinanciera()
        {
            InitializeComponent();

            // Configurar el formato de moneda
            Ingreso_mensual.TextChanged += Ingreso_mensual_TextChanged;

            // Cargar datos existentes si los hay
            CargarDatosExistente();
        }



        private void CargarDatosExistente()
        {
            if (DatosTemporales.InfoFinanciera != null)
            {
                Nombre_Empresa.Text = DatosTemporales.InfoFinanciera.NombreEmpresa;

                if (!string.IsNullOrEmpty(DatosTemporales.InfoFinanciera.Cargo))
                    Cargo_Empresa.SelectedItem = DatosTemporales.InfoFinanciera.Cargo;

                if (DatosTemporales.InfoFinanciera.TiempoEnEmpresa > 0)
                {
                    string tiempoTexto = ConvertirTiempoATexto(DatosTemporales.InfoFinanciera.TiempoEnEmpresa);
                    Tiempo_Empresa.SelectedItem = tiempoTexto;
                }

                if (DatosTemporales.InfoFinanciera.IngresoMensualEstimado > 0)
                    Ingreso_mensual.Text = DatosTemporales.InfoFinanciera.IngresoMensualEstimado.ToString("C");

                Deudas_Activas.SelectedIndex = DatosTemporales.InfoFinanciera.DeudasActivas ? 1 : 0;
                Credito_Antes.SelectedIndex = DatosTemporales.InfoFinanciera.HaTenidoCredito ? 1 : 0;
            }
        }

        private string ConvertirTiempoATexto(int años)
        {
            if (años < 1) return "Menos de 1 año";
            if (años <= 3) return "1-3 años";
            if (años <= 5) return "3-5 años";
            if (años <= 10) return "5-10 años";
            return "Más de 10 años";
        }

        private int ConvertirTextoATiempo(string texto)
        {
            switch (texto)
            {
                case "Menos de 1 año": return 0;
                case "1-3 años": return 2;
                case "3-5 años": return 4;
                case "5-10 años": return 7;
                case "Más de 10 años": return 11;
                default: return 0;
            }
        }

        private void Ingreso_mensual_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Ingreso_mensual.Text)) return;

            // Eliminar el evento temporalmente para evitar bucles
            Ingreso_mensual.TextChanged -= Ingreso_mensual_TextChanged;

            try
            {
                // Obtener solo dígitos
                string digits = new string(Ingreso_mensual.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

                if (decimal.TryParse(digits, out decimal valor))
                {
                    // Formatear como moneda
                    Ingreso_mensual.Text = valor.ToString("C");
                    Ingreso_mensual.SelectionStart = Ingreso_mensual.Text.Length;

                    // Guardar el valor numérico
                    DatosTemporales.InfoFinanciera.IngresoMensualEstimado = valor;
                }
            }
            finally
            {
                // Volver a habilitar el evento
                Ingreso_mensual.TextChanged += Ingreso_mensual_TextChanged;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }



        private void roundButton3_Click(object sender, EventArgs e)
        {
            // Guardar datos antes de volver (aunque no estén validados)
            DatosTemporales.InfoFinanciera.NombreEmpresa = Nombre_Empresa.Text;
            if (Cargo_Empresa.SelectedIndex != -1)
                DatosTemporales.InfoFinanciera.Cargo = Cargo_Empresa.SelectedItem.ToString();
            if (Tiempo_Empresa.SelectedIndex != -1)
                DatosTemporales.InfoFinanciera.TiempoEnEmpresa = ConvertirTextoATiempo(Tiempo_Empresa.SelectedItem.ToString());

            decimal ingreso;
            if (decimal.TryParse(Ingreso_mensual.Text, NumberStyles.Currency, null, out ingreso))
                DatosTemporales.InfoFinanciera.IngresoMensualEstimado = ingreso;

            DatosTemporales.InfoFinanciera.DeudasActivas = Deudas_Activas.SelectedIndex == 1;
            DatosTemporales.InfoFinanciera.HaTenidoCredito = Credito_Antes.SelectedIndex == 1;

            Login lo = new Login();
            lo.Show();
            this.Hide();


        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(Nombre_Empresa.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre de la empresa");
                Nombre_Empresa.Focus();
                return;
            }

            if (Cargo_Empresa.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione su cargo en la empresa");
                Cargo_Empresa.Focus();
                return;
            }

            if (Tiempo_Empresa.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione su tiempo en la empresa");
                Tiempo_Empresa.Focus();
                return;
            }

            if (DatosTemporales.InfoFinanciera.IngresoMensualEstimado <= 0)
            {
                MessageBox.Show("Por favor ingrese un ingreso mensual válido");
                Ingreso_mensual.Focus();
                return;
            }

            // Guardar todos los datos
            DatosTemporales.InfoFinanciera.NombreEmpresa = Nombre_Empresa.Text;
            DatosTemporales.InfoFinanciera.Cargo = Cargo_Empresa.SelectedItem.ToString();
            DatosTemporales.InfoFinanciera.TiempoEnEmpresa = ConvertirTextoATiempo(Tiempo_Empresa.SelectedItem.ToString());
            DatosTemporales.InfoFinanciera.DeudasActivas = Deudas_Activas.SelectedIndex == 1;
            DatosTemporales.InfoFinanciera.HaTenidoCredito = Credito_Antes.SelectedIndex == 1;

            this.Hide();
            Proposito_de_Cuenta  proposito = new Proposito_de_Cuenta();
            proposito.Show();

        }

        private void entrar()
        {

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }

        private void InformacionFinanciera_Load(object sender, EventArgs e)
        {

        }

        private void AbrirFormularioRegistro()
        {
            try
            {
                // Verifica si ya existe una instancia del formulario
                Form formularioExistente = Application.OpenForms["Registro"];

                if (formularioExistente != null)
                {
                    // Si existe, lo trae al frente
                    formularioExistente.BringToFront();
                    formularioExistente.WindowState = FormWindowState.Normal;
                }
                else
                {
                    // Si no existe, crea una nueva instancia
                    Registro nuevoFormulario = new Registro();
                    nuevoFormulario.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
    }
}
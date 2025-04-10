using ProyectoFinalMargarita.Clases.Class_registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros
{
    public partial class Proposito_de_Cuenta : Form
    {
        public Proposito_de_Cuenta()
        {
            InitializeComponent();
            // Configurar el formato de moneda automático
            MontoPromedioRetiros.TextChanged += MontoPromedioRetiros_TextChanged;
            MontoPromedioRetiros.Text = "0";
            MontoPromedioRetiros.SelectionStart = 1;

            // Cargar datos existentes si los hay
            CargarDatosExistentes();
        }



        private void CargarDatosExistentes()
        {
            // Cargar datos desde la clase temporal
            if (DatosTemporales.Proposito != null)
            {
                // Seleccionar el ítem en el ComboBox de motivo
                if (!string.IsNullOrEmpty(DatosTemporales.Proposito.Motivo))
                {
                    Motivo_cuenta.SelectedItem = DatosTemporales.Proposito.Motivo;
                }

                // Formatear el monto promedio
                if (DatosTemporales.Proposito.MontoPromedio > 0)
                {
                    MontoPromedioRetiros.Text = DatosTemporales.Proposito.MontoPromedio.ToString("C");
                }

                // Seleccionar frecuencia de transacciones
                if (!string.IsNullOrEmpty(DatosTemporales.Proposito.FrecuenciaTransacciones))
                {
                    Frecuencia_Transacciones.SelectedItem = DatosTemporales.Proposito.FrecuenciaTransacciones;
                }

                // Seleccionar transacciones internacionales
                Transacciones_internacionales.SelectedIndex = DatosTemporales.Proposito.TransaccionesInternacionales ? 1 : 0;
            }
        }

        private void MontoPromedioRetiros_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MontoPromedioRetiros.Text))
            {
                MontoPromedioRetiros.Text = "0";
                MontoPromedioRetiros.SelectionStart = 1;
                return;
            }

            // Desconectar el evento temporalmente
            MontoPromedioRetiros.TextChanged -= MontoPromedioRetiros_TextChanged;

            try
            {
                // Guardar posición y selección actual del cursor
                int cursorPos = MontoPromedioRetiros.SelectionStart;
                int selectionLength = MontoPromedioRetiros.SelectionLength;
                string currentText = MontoPromedioRetiros.Text;

                // Obtener solo dígitos y separador decimal
                string cleanText = new string(currentText
                    .Where(c => char.IsDigit(c) || c == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0])
                    .ToArray());

                if (decimal.TryParse(cleanText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
                {
                    // Formatear como moneda
                    string formattedText = amount.ToString("C");

                    // Calcular nueva posición del cursor
                    if (selectionLength == 0) // Solo si no hay texto seleccionado
                    {
                        // Manejar caso especial del primer dígito
                        if (currentText == "0" && cursorPos == 1 && cleanText.Length == 1)
                        {
                            cursorPos = 1; // Mantener posición después del símbolo de moneda
                        }
                        else
                        {
                            // Ajuste general de posición
                            int nonDigitCount = currentText.Take(cursorPos).Count(c => !char.IsDigit(c));
                            cursorPos = Math.Max(1, cursorPos - nonDigitCount);
                        }
                    }

                    MontoPromedioRetiros.Text = formattedText;
                    MontoPromedioRetiros.SelectionStart = cursorPos;
                    MontoPromedioRetiros.SelectionLength = selectionLength;

                    // Guardar el valor en los datos temporales
                    DatosTemporales.Proposito.MontoPromedio = amount;
                }
                else
                {
                    MontoPromedioRetiros.Text = "0";
                    MontoPromedioRetiros.SelectionStart = 1;
                }
            }
            finally
            {
                // Volver a conectar el evento
                MontoPromedioRetiros.TextChanged += MontoPromedioRetiros_TextChanged;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

        }


        private void roundButton3_Click(object sender, EventArgs e)
        {

            // Guardar datos temporalmente antes de volver
            if (Motivo_cuenta.SelectedIndex != -1)
                DatosTemporales.Proposito.Motivo = Motivo_cuenta.SelectedItem.ToString();

            if (Frecuencia_Transacciones.SelectedIndex != -1)
                DatosTemporales.Proposito.FrecuenciaTransacciones = Frecuencia_Transacciones.SelectedItem.ToString();

            DatosTemporales.Proposito.TransaccionesInternacionales = Transacciones_internacionales.SelectedIndex == 1;

            this.Hide();
            InformacionFinanciera inforFina = new InformacionFinanciera();
            inforFina.Show();

        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (Motivo_cuenta.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione el motivo para abrir la cuenta");
                Motivo_cuenta.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(MontoPromedioRetiros.Text) ||
                DatosTemporales.Proposito.MontoPromedio <= 0)
            {
                MessageBox.Show("Por favor ingrese un monto promedio válido");
                MontoPromedioRetiros.Focus();
                return;
            }

            if (Frecuencia_Transacciones.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione la frecuencia de transacciones");
                Frecuencia_Transacciones.Focus();
                return;
            }

            // Guardar todos los datos en la clase temporal
            DatosTemporales.Proposito.Motivo = Motivo_cuenta.SelectedItem.ToString();
            DatosTemporales.Proposito.FrecuenciaTransacciones = Frecuencia_Transacciones.SelectedItem.ToString();
            DatosTemporales.Proposito.TransaccionesInternacionales = Transacciones_internacionales.SelectedIndex == 1;

            // Navegar al siguiente formulario
            var formSeguridad = new Seguridad();
            formSeguridad.Show();
            this.Hide();
        }
    }
}

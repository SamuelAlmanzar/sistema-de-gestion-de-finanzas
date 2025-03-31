using System;
using System.Windows.Forms;


namespace ProyectoFinalMargarita
{
    public partial class AsignacionTarjeta1 : Form
    {
        public AsignacionTarjeta1()
        {
            InitializeComponent();
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            // Verificar si el checkbox está marcado
            if (!checkBox2.Checked)
            {
                MessageBox.Show("Debe aceptar los términos y condiciones para continuar",
                              "Atención",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            // Si el checkbox está marcado, abrir el formulario principal
            new Main("").Show();
            // Cerrar este formulario
            this.Hide();
        }

        private void AsignacionTarjeta1_Load(object sender, EventArgs e)
        {
            // Puedes inicializar cosas aquí si es necesario
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Puedes añadir lógica adicional cuando cambia el estado del checkbox si es necesario
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
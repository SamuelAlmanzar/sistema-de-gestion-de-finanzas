using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProyectoFinalMargarita
{
    public partial class Login : Form
    {
        private Panel panelShadow;
        private Button iconButton1; // Declaración del botón

        public Login()
        {
            InitializeComponent();


            // Inicialización de iconButton1

        }









        private GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            if (radius > 0)
            {
                path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(bounds);
            }

            return path;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Manejar el cambio de texto en textBox1
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Manejar el cambio de texto en textBox2
        }

        private void IconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un objeto ProcessStartInfo
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://accounts.google.com/", // La URL que deseas abrir
                    UseShellExecute = true // Usar el shell del sistema para abrir la URL
                };

                // Iniciar el proceso
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                MessageBox.Show($"Error al abrir la URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IconButton1_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 15; // Ajusta el radio según tu diseño
            using (GraphicsPath path = RoundedRectangle(iconButton1.ClientRectangle, borderRadius))
            {
                iconButton1.Region = new Region(path);
                using (Pen pen = new Pen(Color.Gray, 1)) // Puedes cambiar el color del borde
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            // Manejar el clic en iconButton2
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Código que se ejecuta al cargar el formulario
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            // Manejar el evento Paint del panel1
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
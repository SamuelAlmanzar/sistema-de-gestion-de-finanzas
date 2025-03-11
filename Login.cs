using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class Login : Form
    {
        private Panel panelShadow;

        public Login()
        {
            InitializeComponent();
            ConfigurarPanelSombra();
            panel1.Paint += Panel1_Paint;
            textBox1.Paint += TextBox_Paint;
            textBox2.Paint += TextBox_Paint;
        }

        private void ConfigurarPanelSombra()
        {
            // Crear el panel de sombra
            panelShadow = new Panel
            {
                Size = panel1.Size,
                Location = new Point(panel1.Location.X + 5, panel1.Location.Y + 5), // Desplazamiento para la sombra
                BackColor = Color.Transparent // Hacerlo transparente
            };

            this.Controls.Add(panelShadow);
            panelShadow.SendToBack(); // Enviar la sombra detrás del panel1
            panelShadow.Paint += PanelShadow_Paint;
        }

        private void PanelShadow_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 20; // Radio de los bordes redondeados
            using (GraphicsPath path = RoundedRectangle(panelShadow.ClientRectangle, borderRadius))
            {
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(100, 0, 0, 0); // Color negro con transparencia
                    brush.SurroundColors = new Color[] { Color.Transparent }; // Borde difuminado
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 20;
            using (GraphicsPath path = RoundedRectangle(panel1.ClientRectangle, borderRadius))
            {
                panel1.Region = new Region(path);
            }
        }

        private void TextBox_Paint(object sender, PaintEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int borderRadius = 10; // Radio de los bordes redondeados
                using (GraphicsPath path = RoundedRectangle(textBox.ClientRectangle, borderRadius))
                {
                    textBox.Region = new Region(path);
                    using (Pen pen = new Pen(Color.Gray, 1))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
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

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

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

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
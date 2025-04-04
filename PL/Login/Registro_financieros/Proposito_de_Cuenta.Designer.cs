namespace ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros
{
    partial class Proposito_de_Cuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roundButton1 = new RoundButton();
            label5 = new Label();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            label8 = new Label();
            label1 = new Label();
            label2 = new Label();
            MontoPromedioRetiros = new TextBox();
            Motivo_cuenta = new ComboBox();
            Frecuencia_Transacciones = new ComboBox();
            label3 = new Label();
            Transacciones_internacionales = new ComboBox();
            roundButton3 = new RoundButton();
            roundButton2 = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.White;
            roundButton1.BackgroundColor = Color.White;
            roundButton1.BorderColor = Color.White;
            roundButton1.BorderRadius = 20;
            roundButton1.BorderSize = 0;
            roundButton1.FlatAppearance.BorderColor = Color.White;
            roundButton1.FlatAppearance.BorderSize = 10;
            roundButton1.FlatAppearance.MouseDownBackColor = Color.White;
            roundButton1.FlatAppearance.MouseOverBackColor = Color.White;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(95, 12);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(1030, 992);
            roundButton1.TabIndex = 26;
            roundButton1.TextColor = Color.Black;
            roundButton1.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Inter Medium", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(175, 175, 180);
            label5.Location = new Point(263, 262);
            label5.Name = "label5";
            label5.Size = new Size(678, 42);
            label5.TabIndex = 31;
            label5.Text = "Ingrese los datos de forma correcta para poder entender su objetivo \r\n                                      dentro de nuestro banco\r\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Inter Black", 14F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(450, 219);
            label6.Name = "label6";
            label6.Size = new Size(338, 34);
            label6.TabIndex = 30;
            label6.Text = " Propósito de la Cuenta";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(476, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(157, 432);
            label8.Name = "label8";
            label8.Size = new Size(305, 26);
            label8.TabIndex = 32;
            label8.Text = "Motivo para abrir la cuenta";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(665, 432);
            label1.Name = "label1";
            label1.Size = new Size(446, 26);
            label1.TabIndex = 32;
            label1.Text = "Frecuencia de transacciones esperadas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(157, 575);
            label2.Name = "label2";
            label2.Size = new Size(435, 26);
            label2.TabIndex = 32;
            label2.Text = "Monto promedio de depósitos y retiros";
            // 
            // MontoPromedioRetiros
            // 
            MontoPromedioRetiros.Font = new Font("Inter", 11F, FontStyle.Bold);
            MontoPromedioRetiros.ForeColor = Color.Black;
            MontoPromedioRetiros.Location = new Point(157, 604);
            MontoPromedioRetiros.Multiline = true;
            MontoPromedioRetiros.Name = "MontoPromedioRetiros";
            MontoPromedioRetiros.Size = new Size(413, 35);
            MontoPromedioRetiros.TabIndex = 79;
            // 
            // Motivo_cuenta
            // 
            Motivo_cuenta.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Motivo_cuenta.ForeColor = Color.Black;
            Motivo_cuenta.FormattingEnabled = true;
            Motivo_cuenta.Items.AddRange(new object[] { "Ahorro y gestión financiera", "Pagos y transacciones", "Recepción de ingresos ", "Créditos y financiamiento", "Negocios y emprendimientos" });
            Motivo_cuenta.Location = new Point(157, 463);
            Motivo_cuenta.Name = "Motivo_cuenta";
            Motivo_cuenta.Size = new Size(405, 34);
            Motivo_cuenta.TabIndex = 80;
            Motivo_cuenta.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // Frecuencia_Transacciones
            // 
            Frecuencia_Transacciones.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Frecuencia_Transacciones.ForeColor = Color.Black;
            Frecuencia_Transacciones.FormattingEnabled = true;
            Frecuencia_Transacciones.Items.AddRange(new object[] { "Diaria", "Semanal", "Mensual" });
            Frecuencia_Transacciones.Location = new Point(665, 461);
            Frecuencia_Transacciones.Name = "Frecuencia_Transacciones";
            Frecuencia_Transacciones.Size = new Size(405, 34);
            Frecuencia_Transacciones.TabIndex = 80;
            Frecuencia_Transacciones.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(665, 549);
            label3.Name = "label3";
            label3.Size = new Size(412, 52);
            label3.TabIndex = 32;
            label3.Text = "¿Usará la cuenta para transacciones \r\ninternacionales?";
            // 
            // Transacciones_internacionales
            // 
            Transacciones_internacionales.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Transacciones_internacionales.ForeColor = Color.Black;
            Transacciones_internacionales.FormattingEnabled = true;
            Transacciones_internacionales.Items.AddRange(new object[] { "Si ", "No" });
            Transacciones_internacionales.Location = new Point(665, 605);
            Transacciones_internacionales.Name = "Transacciones_internacionales";
            Transacciones_internacionales.Size = new Size(405, 34);
            Transacciones_internacionales.TabIndex = 80;
            Transacciones_internacionales.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // roundButton3
            // 
            roundButton3.BackColor = Color.FromArgb(4, 120, 87);
            roundButton3.BackgroundColor = Color.FromArgb(4, 120, 87);
            roundButton3.BorderColor = Color.Empty;
            roundButton3.BorderRadius = 8;
            roundButton3.BorderSize = 0;
            roundButton3.FlatAppearance.BorderColor = Color.FromArgb(4, 120, 87);
            roundButton3.FlatAppearance.BorderSize = 0;
            roundButton3.FlatAppearance.MouseDownBackColor = Color.FromArgb(4, 120, 87);
            roundButton3.FlatAppearance.MouseOverBackColor = Color.FromArgb(4, 120, 87);
            roundButton3.FlatStyle = FlatStyle.Flat;
            roundButton3.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton3.ForeColor = Color.White;
            roundButton3.Location = new Point(157, 905);
            roundButton3.Name = "roundButton3";
            roundButton3.Size = new Size(266, 54);
            roundButton3.TabIndex = 83;
            roundButton3.Text = "Atras";
            roundButton3.TextColor = Color.White;
            roundButton3.UseVisualStyleBackColor = false;
            // 
            // roundButton2
            // 
            roundButton2.BackColor = Color.FromArgb(4, 120, 87);
            roundButton2.BackgroundColor = Color.FromArgb(4, 120, 87);
            roundButton2.BorderColor = Color.Empty;
            roundButton2.BorderRadius = 8;
            roundButton2.BorderSize = 0;
            roundButton2.FlatAppearance.BorderColor = Color.FromArgb(4, 120, 87);
            roundButton2.FlatAppearance.BorderSize = 0;
            roundButton2.FlatAppearance.MouseDownBackColor = Color.FromArgb(4, 120, 87);
            roundButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(4, 120, 87);
            roundButton2.FlatStyle = FlatStyle.Flat;
            roundButton2.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton2.ForeColor = Color.White;
            roundButton2.Location = new Point(804, 905);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(266, 54);
            roundButton2.TabIndex = 82;
            roundButton2.Text = "Siguiente";
            roundButton2.TextColor = Color.White;
            roundButton2.UseVisualStyleBackColor = false;
            // 
            // Proposito_de_Cuenta
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1308, 1050);
            Controls.Add(roundButton3);
            Controls.Add(roundButton2);
            Controls.Add(Frecuencia_Transacciones);
            Controls.Add(Transacciones_internacionales);
            Controls.Add(Motivo_cuenta);
            Controls.Add(MontoPromedioRetiros);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(roundButton1);
            Name = "Proposito_de_Cuenta";
            Text = "Informacion_de_Cuenta";
            Load += Proposito_de_Cuenta_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RoundButton roundButton1;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox1;
        private Label label8;
        private Label label1;
        private Label label2;
        private TextBox MontoPromedioRetiros;
        private ComboBox Motivo_cuenta;
        private ComboBox Frecuencia_Transacciones;
        private Label label3;
        private ComboBox Transacciones_internacionales;
        private RoundButton roundButton3;
        private RoundButton roundButton2;
    }
}
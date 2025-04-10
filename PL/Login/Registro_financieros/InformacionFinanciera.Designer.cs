namespace ProyectoFinalMargarita
{
    partial class InformacionFinanciera
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Cargo_Empresa = new ComboBox();
            roundButton2 = new RoundButton();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            Ingreso_mensual = new TextBox();
            label8 = new Label();
            Nombre_Empresa = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            roundButton3 = new RoundButton();
            Deudas_Activas = new ComboBox();
            Tiempo_Empresa = new ComboBox();
            Credito_Antes = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).BeginInit();
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
            roundButton1.Location = new Point(149, 12);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(1030, 992);
            roundButton1.TabIndex = 25;
            roundButton1.TextColor = Color.Black;
            roundButton1.UseVisualStyleBackColor = false;
            roundButton1.Click += roundButton1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(563, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(537, 222);
            label1.Name = "label1";
            label1.Size = new Size(325, 32);
            label1.TabIndex = 27;
            label1.Text = "Información Financiera";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(175, 175, 180);
            label2.Location = new Point(370, 268);
            label2.Name = "label2";
            label2.Size = new Size(659, 22);
            label2.TabIndex = 28;
            label2.Text = "Por favor proporcione su información financiera para evaluar su solicitud";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(743, 403);
            label3.Name = "label3";
            label3.Size = new Size(292, 26);
            label3.TabIndex = 29;
            label3.Text = "Ingreso mensual estimado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(743, 527);
            label4.Name = "label4";
            label4.Size = new Size(175, 26);
            label4.TabIndex = 31;
            label4.Text = "Deudas activas";
            // 
            // Cargo_Empresa
            // 
            Cargo_Empresa.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Cargo_Empresa.ForeColor = Color.Black;
            Cargo_Empresa.FormattingEnabled = true;
            Cargo_Empresa.Items.AddRange(new object[] { "Director General (CEO)", "Gerente de Operaciones", "Gerente Financiero (CFO)", "Gerente de Recursos Humanos", "Contador", "Tesorero", "Analista Financiero", "Gerente de Ventas", "Ejecutivo de Ventas", "Gerente de Marketing", "Community Manager", "Jefe de Producción", "Coordinador de Logística", "Supervisor de Almacén", "Gerente de TI", "Desarrollador de Software", "Soporte Técnico", "Otros (A po tu no hace na vago)" });
            Cargo_Empresa.Location = new Point(221, 556);
            Cargo_Empresa.Name = "Cargo_Empresa";
            Cargo_Empresa.Size = new Size(405, 34);
            Cargo_Empresa.TabIndex = 33;
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
            roundButton2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton2.ForeColor = Color.White;
            roundButton2.Location = new Point(882, 879);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(266, 54);
            roundButton2.TabIndex = 41;
            roundButton2.Text = "Siguiente";
            roundButton2.TextColor = Color.White;
            roundButton2.UseVisualStyleBackColor = false;
            roundButton2.Click += roundButton2_Click;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.BackColor = Color.White;
            iconPictureBox3.ForeColor = Color.FromArgb(4, 120, 87);
            iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            iconPictureBox3.IconColor = Color.FromArgb(4, 120, 87);
            iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox3.IconSize = 36;
            iconPictureBox3.Location = new Point(699, 440);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Size = new Size(38, 36);
            iconPictureBox3.TabIndex = 75;
            iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox4
            // 
            iconPictureBox4.BackColor = Color.White;
            iconPictureBox4.ForeColor = Color.FromArgb(33, 162, 122);
            iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            iconPictureBox4.IconColor = Color.FromArgb(33, 162, 122);
            iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox4.IconSize = 36;
            iconPictureBox4.Location = new Point(699, 554);
            iconPictureBox4.Name = "iconPictureBox4";
            iconPictureBox4.Size = new Size(38, 36);
            iconPictureBox4.TabIndex = 76;
            iconPictureBox4.TabStop = false;
            // 
            // Ingreso_mensual
            // 
            Ingreso_mensual.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            Ingreso_mensual.ForeColor = Color.Black;
            Ingreso_mensual.Location = new Point(743, 441);
            Ingreso_mensual.Multiline = true;
            Ingreso_mensual.Name = "Ingreso_mensual";
            Ingreso_mensual.Size = new Size(405, 35);
            Ingreso_mensual.TabIndex = 78;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(221, 398);
            label8.Name = "label8";
            label8.Size = new Size(254, 26);
            label8.TabIndex = 29;
            label8.Text = "Nombre de la empresa";
            // 
            // Nombre_Empresa
            // 
            Nombre_Empresa.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            Nombre_Empresa.ForeColor = Color.Black;
            Nombre_Empresa.Location = new Point(221, 441);
            Nombre_Empresa.Multiline = true;
            Nombre_Empresa.Name = "Nombre_Empresa";
            Nombre_Empresa.Size = new Size(413, 35);
            Nombre_Empresa.TabIndex = 78;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(221, 518);
            label9.Name = "label9";
            label9.Size = new Size(234, 26);
            label9.TabIndex = 29;
            label9.Text = "Cargo en la empresa";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(221, 646);
            label10.Name = "label10";
            label10.Size = new Size(248, 26);
            label10.TabIndex = 29;
            label10.Text = "Tiempo en la empresa";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.White;
            label11.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(741, 646);
            label11.Name = "label11";
            label11.Size = new Size(284, 26);
            label11.TabIndex = 29;
            label11.Text = "¿Ha tenido credito antes?";
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
            roundButton3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton3.ForeColor = Color.White;
            roundButton3.Location = new Point(221, 879);
            roundButton3.Name = "roundButton3";
            roundButton3.Size = new Size(266, 54);
            roundButton3.TabIndex = 41;
            roundButton3.Text = "Atras";
            roundButton3.TextColor = Color.White;
            roundButton3.UseVisualStyleBackColor = false;
            roundButton3.Click += roundButton3_Click;
            // 
            // Deudas_Activas
            // 
            Deudas_Activas.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Deudas_Activas.ForeColor = Color.Black;
            Deudas_Activas.FormattingEnabled = true;
            Deudas_Activas.Items.AddRange(new object[] { "Tarjetas de crédito", "Préstamos", "Hipotecas", "No" });
            Deudas_Activas.Location = new Point(743, 556);
            Deudas_Activas.Name = "Deudas_Activas";
            Deudas_Activas.Size = new Size(405, 34);
            Deudas_Activas.TabIndex = 33;
            // 
            // Tiempo_Empresa
            // 
            Tiempo_Empresa.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Tiempo_Empresa.ForeColor = Color.Black;
            Tiempo_Empresa.FormattingEnabled = true;
            Tiempo_Empresa.Items.AddRange(new object[] { "Menos de 1 año", "1-3 años", "3-5 años", "5-10 años", "Más de 10 años" });
            Tiempo_Empresa.Location = new Point(221, 685);
            Tiempo_Empresa.Name = "Tiempo_Empresa";
            Tiempo_Empresa.Size = new Size(405, 34);
            Tiempo_Empresa.TabIndex = 33;
            // 
            // Credito_Antes
            // 
            Credito_Antes.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Credito_Antes.ForeColor = Color.Black;
            Credito_Antes.FormattingEnabled = true;
            Credito_Antes.Items.AddRange(new object[] { "Si ", "No" });
            Credito_Antes.Location = new Point(743, 685);
            Credito_Antes.Name = "Credito_Antes";
            Credito_Antes.Size = new Size(405, 34);
            Credito_Antes.TabIndex = 33;
            // 
            // InformacionFinanciera
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 251);
            ClientSize = new Size(1308, 1050);
            Controls.Add(Nombre_Empresa);
            Controls.Add(Ingreso_mensual);
            Controls.Add(iconPictureBox4);
            Controls.Add(iconPictureBox3);
            Controls.Add(roundButton3);
            Controls.Add(roundButton2);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(Credito_Antes);
            Controls.Add(Deudas_Activas);
            Controls.Add(Tiempo_Empresa);
            Controls.Add(Cargo_Empresa);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(roundButton1);
            ForeColor = Color.FromArgb(246, 248, 251);
            Name = "InformacionFinanciera";
            Text = "InformacionFinanciera";
            Load += InformacionFinanciera_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundButton roundButton1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox Cargo_Empresa;
        private RoundButton roundButton2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private TextBox Ingreso_mensual;
        private Label label8;
        private TextBox Nombre_Empresa;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox a;
        private RoundButton roundButton3;
        private ComboBox Deudas_Activas;
        private ComboBox Tiempo_Empresa;
        private ComboBox Credito_Antes;
    }
}
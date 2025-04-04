namespace ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros
{
    partial class Seguridad
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
            Metodo_de_recuperacion = new ComboBox();
            Contraseña = new TextBox();
            label8 = new Label();
            label1 = new Label();
            Confirmarcontraseña = new TextBox();
            label2 = new Label();
            Nombre_mascota = new TextBox();
            label3 = new Label();
            label4 = new Label();
            Aunteticacion_Dos_pasos = new ComboBox();
            label7 = new Label();
            Ciudad_Donde_nacio = new TextBox();
            roundButton2 = new RoundButton();
            roundButton3 = new RoundButton();
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
            roundButton1.Location = new Point(139, 24);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(1030, 992);
            roundButton1.TabIndex = 27;
            roundButton1.TextColor = Color.Black;
            roundButton1.UseVisualStyleBackColor = false;
            roundButton1.Click += roundButton1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Inter Medium", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(175, 175, 180);
            label5.Location = new Point(386, 297);
            label5.Name = "label5";
            label5.Size = new Size(588, 21);
            label5.TabIndex = 34;
            label5.Text = "Ingrese las medidas de seguridad que desea para su cuenta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Inter Black", 14F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(510, 249);
            label6.Name = "label6";
            label6.Size = new Size(336, 34);
            label6.TabIndex = 33;
            label6.Text = "Seguridad de la cuenta";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(536, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // Metodo_de_recuperacion
            // 
            Metodo_de_recuperacion.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Metodo_de_recuperacion.ForeColor = Color.Black;
            Metodo_de_recuperacion.FormattingEnabled = true;
            Metodo_de_recuperacion.Items.AddRange(new object[] { "Correo electronico ", "Telefono " });
            Metodo_de_recuperacion.Location = new Point(240, 571);
            Metodo_de_recuperacion.Name = "Metodo_de_recuperacion";
            Metodo_de_recuperacion.Size = new Size(413, 34);
            Metodo_de_recuperacion.TabIndex = 83;
            Metodo_de_recuperacion.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // Contraseña
            // 
            Contraseña.Font = new Font("Inter", 11F, FontStyle.Bold);
            Contraseña.ForeColor = Color.Black;
            Contraseña.Location = new Point(240, 453);
            Contraseña.Multiline = true;
            Contraseña.Name = "Contraseña";
            Contraseña.Size = new Size(413, 35);
            Contraseña.TabIndex = 82;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(240, 424);
            label8.Name = "label8";
            label8.Size = new Size(141, 26);
            label8.TabIndex = 81;
            label8.Text = "Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(709, 424);
            label1.Name = "label1";
            label1.Size = new Size(256, 26);
            label1.TabIndex = 81;
            label1.Text = "Confirmar contraseña";
            // 
            // Confirmarcontraseña
            // 
            Confirmarcontraseña.Font = new Font("Inter", 11F, FontStyle.Bold);
            Confirmarcontraseña.ForeColor = Color.Black;
            Confirmarcontraseña.Location = new Point(709, 453);
            Confirmarcontraseña.Multiline = true;
            Confirmarcontraseña.Name = "Confirmarcontraseña";
            Confirmarcontraseña.Size = new Size(413, 35);
            Confirmarcontraseña.TabIndex = 82;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(240, 649);
            label2.Name = "label2";
            label2.Size = new Size(348, 26);
            label2.TabIndex = 81;
            label2.Text = "Nombre de tu primera mascota";
            // 
            // Nombre_mascota
            // 
            Nombre_mascota.Font = new Font("Inter", 11F, FontStyle.Bold);
            Nombre_mascota.ForeColor = Color.Black;
            Nombre_mascota.Location = new Point(240, 678);
            Nombre_mascota.Multiline = true;
            Nombre_mascota.Name = "Nombre_mascota";
            Nombre_mascota.Size = new Size(413, 35);
            Nombre_mascota.TabIndex = 82;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(240, 542);
            label3.Name = "label3";
            label3.Size = new Size(385, 26);
            label3.TabIndex = 81;
            label3.Text = "Método principal de recuperación ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(709, 542);
            label4.Name = "label4";
            label4.Size = new Size(398, 26);
            label4.TabIndex = 81;
            label4.Text = "Activar autenticación en dos pasos";
            // 
            // Aunteticacion_Dos_pasos
            // 
            Aunteticacion_Dos_pasos.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Aunteticacion_Dos_pasos.ForeColor = Color.Black;
            Aunteticacion_Dos_pasos.FormattingEnabled = true;
            Aunteticacion_Dos_pasos.Items.AddRange(new object[] { "Correo electronico ", "Telefono " });
            Aunteticacion_Dos_pasos.Location = new Point(709, 571);
            Aunteticacion_Dos_pasos.Name = "Aunteticacion_Dos_pasos";
            Aunteticacion_Dos_pasos.Size = new Size(413, 34);
            Aunteticacion_Dos_pasos.TabIndex = 83;
            Aunteticacion_Dos_pasos.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(709, 649);
            label7.Name = "label7";
            label7.Size = new Size(250, 26);
            label7.TabIndex = 81;
            label7.Text = "Ciudad donde naciste";
            // 
            // Ciudad_Donde_nacio
            // 
            Ciudad_Donde_nacio.Font = new Font("Inter", 11F, FontStyle.Bold);
            Ciudad_Donde_nacio.ForeColor = Color.Black;
            Ciudad_Donde_nacio.Location = new Point(709, 678);
            Ciudad_Donde_nacio.Multiline = true;
            Ciudad_Donde_nacio.Name = "Ciudad_Donde_nacio";
            Ciudad_Donde_nacio.Size = new Size(413, 35);
            Ciudad_Donde_nacio.TabIndex = 82;
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
            roundButton2.Location = new Point(856, 924);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(266, 54);
            roundButton2.TabIndex = 84;
            roundButton2.Text = "Finalizar";
            roundButton2.TextColor = Color.White;
            roundButton2.UseVisualStyleBackColor = false;
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
            roundButton3.Location = new Point(240, 924);
            roundButton3.Name = "roundButton3";
            roundButton3.Size = new Size(266, 54);
            roundButton3.TabIndex = 85;
            roundButton3.Text = "Atras";
            roundButton3.TextColor = Color.White;
            roundButton3.UseVisualStyleBackColor = false;
            // 
            // Seguridad
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1308, 1050);
            Controls.Add(roundButton3);
            Controls.Add(roundButton2);
            Controls.Add(Aunteticacion_Dos_pasos);
            Controls.Add(Metodo_de_recuperacion);
            Controls.Add(label4);
            Controls.Add(Ciudad_Donde_nacio);
            Controls.Add(Nombre_mascota);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(Confirmarcontraseña);
            Controls.Add(label2);
            Controls.Add(Contraseña);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(roundButton1);
            Name = "Seguridad";
            Text = "Seguridad";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundButton roundButton1;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox1;
        private ComboBox Metodo_de_recuperacion;
        private TextBox Contraseña;
        private Label label8;
        private Label label1;
        private TextBox Confirmarcontraseña;
        private Label label2;
        private TextBox Nombre_mascota;
        private Label label3;
        private Label label4;
        private ComboBox Aunteticacion_Dos_pasos;
        private Label label7;
        private TextBox Ciudad_Donde_nacio;
        private RoundButton roundButton2;
        private RoundButton roundButton3;
    }
}
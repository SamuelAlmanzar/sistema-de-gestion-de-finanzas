namespace ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros
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
            ñemon = new RJTexbox();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            label7 = new Label();
            roundButton2 = new RoundButton();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            rjTexbox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
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
            label1.Font = new Font("Inter Black", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(537, 222);
            label1.Name = "label1";
            label1.Size = new Size(339, 34);
            label1.TabIndex = 27;
            label1.Text = "Información Financiera";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Inter Medium", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(175, 175, 180);
            label2.Location = new Point(370, 280);
            label2.Name = "label2";
            label2.Size = new Size(710, 21);
            label2.TabIndex = 28;
            label2.Text = "Por favor proporcione su información financiera para evaluar su solicitud";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(379, 371);
            label3.Name = "label3";
            label3.Size = new Size(302, 26);
            label3.TabIndex = 29;
            label3.Text = "Ingreso mensual estimado";
            // 
            // ñemon
            // 
            ñemon.BackColor = SystemColors.Window;
            ñemon.BorderColor = Color.Black;
            ñemon.BorderFocusColor = Color.HotPink;
            ñemon.BorderRadius = 5;
            ñemon.BorderSize = 2;
            ñemon.Font = new Font("Inter", 11F, FontStyle.Bold);
            ñemon.ForeColor = Color.Black;
            ñemon.Location = new Point(22, 31);
            ñemon.Multiline = true;
            ñemon.Name = "ñemon";
            ñemon.Padding = new Padding(10, 7, 10, 7);
            ñemon.PasswordChar = false;
            ñemon.PlaceholderColor = Color.DarkGray;
            ñemon.PlaceholderText = "";
            ñemon.Size = new Size(613, 52);
            ñemon.TabIndex = 30;
            ñemon.Texts = "";
            ñemon.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(379, 488);
            label4.Name = "label4";
            label4.Size = new Size(206, 26);
            label4.TabIndex = 31;
            label4.Text = "Fuente de ingreso";
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox2.ForeColor = Color.Black;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Empleo", "Autónomo", " Negocios", " Otros" });
            comboBox2.Location = new Point(379, 522);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(613, 34);
            comboBox2.TabIndex = 33;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(379, 581);
            label5.Name = "label5";
            label5.Size = new Size(277, 26);
            label5.TabIndex = 34;
            label5.Text = "Tipo de tarjeta preferida";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.ForeColor = Color.Black;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tarjeta de crédito estándar", " Tarjeta de débito", " Tarjeta prepagada" });
            comboBox1.Location = new Point(379, 615);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(613, 34);
            comboBox1.TabIndex = 35;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(379, 677);
            label6.Name = "label6";
            label6.Size = new Size(277, 26);
            label6.TabIndex = 36;
            label6.Text = "Tipo de tarjeta preferida";
            label6.Click += label6_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.White;
            checkBox1.Font = new Font("Inter Medium", 9F, FontStyle.Bold);
            checkBox1.ForeColor = Color.Black;
            checkBox1.Location = new Point(379, 763);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(256, 25);
            checkBox1.TabIndex = 37;
            checkBox1.Text = "Transferencia bancaria";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.White;
            checkBox2.Font = new Font("Inter Medium", 9F, FontStyle.Bold);
            checkBox2.ForeColor = Color.Black;
            checkBox2.Location = new Point(379, 798);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(176, 25);
            checkBox2.TabIndex = 38;
            checkBox2.Text = "Pagos en línea";
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = Color.White;
            checkBox3.Font = new Font("Inter Medium", 9F, FontStyle.Bold);
            checkBox3.ForeColor = Color.Black;
            checkBox3.Location = new Point(379, 833);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(211, 25);
            checkBox3.TabIndex = 39;
            checkBox3.Text = "Cajero automático";
            checkBox3.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Inter Medium", 9F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(175, 175, 180);
            label7.Location = new Point(379, 718);
            label7.Name = "label7";
            label7.Size = new Size(559, 21);
            label7.TabIndex = 40;
            label7.Text = "Seleccione los métodos que prefiere para realizar pagos.";
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
            roundButton2.Location = new Point(284, 883);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(750, 54);
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
            iconPictureBox3.Location = new Point(335, 366);
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
            iconPictureBox4.Location = new Point(335, 483);
            iconPictureBox4.Name = "iconPictureBox4";
            iconPictureBox4.Size = new Size(38, 36);
            iconPictureBox4.TabIndex = 76;
            iconPictureBox4.TabStop = false;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.White;
            iconPictureBox2.ForeColor = Color.FromArgb(33, 162, 122);
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Pager;
            iconPictureBox2.IconColor = Color.FromArgb(33, 162, 122);
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconPictureBox2.IconSize = 36;
            iconPictureBox2.Location = new Point(335, 576);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(38, 36);
            iconPictureBox2.TabIndex = 77;
            iconPictureBox2.TabStop = false;
            // 
            // rjTexbox1
            // 
            rjTexbox1.Location = new Point(379, 409);
            rjTexbox1.Name = "rjTexbox1";
            rjTexbox1.Size = new Size(613, 31);
            rjTexbox1.TabIndex = 78;
            rjTexbox1.TextChanged += rjTexbox1_TextChanged;
            // 
            // InformacionFinanciera
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 251);
            ClientSize = new Size(1308, 1050);
            Controls.Add(rjTexbox1);
            Controls.Add(iconPictureBox2);
            Controls.Add(iconPictureBox4);
            Controls.Add(iconPictureBox3);
            Controls.Add(roundButton2);
            Controls.Add(label7);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(ñemon);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(roundButton1);
            ForeColor = Color.FromArgb(246, 248, 251);
            Name = "InformacionFinanciera";
            Text = "InformacionFinanciera";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundButton roundButton1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private RJTexbox ñemon;
        private Label label4;
        private ComboBox comboBox2;
        private Label label5;
        private ComboBox comboBox1;
        private Label label6;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Label label7;
        private RoundButton roundButton2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private TextBox rjTexbox1;
    }
}
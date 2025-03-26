namespace ProyectoFinalMargarita
{
    partial class Verificación
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
            label1 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            rjTexbox1 = new RJTexbox();
            rjTexbox2 = new RJTexbox();
            label4 = new Label();
            roundButton2 = new RoundButton();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.White;
            roundButton1.BackgroundColor = Color.White;
            roundButton1.BorderColor = Color.Black;
            roundButton1.BorderRadius = 20;
            roundButton1.BorderSize = 0;
            roundButton1.FlatAppearance.BorderColor = Color.White;
            roundButton1.FlatAppearance.BorderSize = 10;
            roundButton1.FlatAppearance.MouseDownBackColor = Color.White;
            roundButton1.FlatAppearance.MouseOverBackColor = Color.White;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(383, 12);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(673, 682);
            roundButton1.TabIndex = 23;
            roundButton1.TextColor = Color.Black;
            roundButton1.UseVisualStyleBackColor = false;
            roundButton1.Click += roundButton1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Inter Black", 16F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(607, 185);
            label1.Name = "label1";
            label1.Size = new Size(253, 45);
            label1.TabIndex = 25;
            label1.Text = "VERIFICACIÓN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(538, 283);
            label3.Name = "label3";
            label3.Size = new Size(335, 31);
            label3.TabIndex = 27;
            label3.Text = "Tipo Documento de Identidad";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.ForeColor = Color.Black;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Pasaporte", "Cédula" });
            comboBox1.Location = new Point(538, 317);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(420, 39);
            comboBox1.TabIndex = 29;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.logo;
            pictureBox2.Location = new Point(607, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(262, 152);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 31;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(538, 376);
            label2.Name = "label2";
            label2.Size = new Size(281, 31);
            label2.TabIndex = 32;
            label2.Text = "Documento de Identidad";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rjTexbox1
            // 
            rjTexbox1.BackColor = SystemColors.Window;
            rjTexbox1.BorderColor = Color.Black;
            rjTexbox1.BorderFocusColor = Color.HotPink;
            rjTexbox1.BorderRadius = 5;
            rjTexbox1.BorderSize = 2;
            rjTexbox1.Font = new Font("Inter", 11F, FontStyle.Bold);
            rjTexbox1.ForeColor = Color.Black;
            rjTexbox1.Location = new Point(538, 410);
            rjTexbox1.Multiline = true;
            rjTexbox1.Name = "rjTexbox1";
            rjTexbox1.Padding = new Padding(10, 7, 10, 7);
            rjTexbox1.PasswordChar = false;
            rjTexbox1.PlaceholderColor = Color.DarkGray;
            rjTexbox1.PlaceholderText = "";
            rjTexbox1.Size = new Size(420, 52);
            rjTexbox1.TabIndex = 33;
            rjTexbox1.Texts = "";
            rjTexbox1.UnderlinedStyle = false;
            // 
            // rjTexbox2
            // 
            rjTexbox2.BackColor = SystemColors.Window;
            rjTexbox2.BorderColor = Color.Black;
            rjTexbox2.BorderFocusColor = Color.HotPink;
            rjTexbox2.BorderRadius = 5;
            rjTexbox2.BorderSize = 2;
            rjTexbox2.Font = new Font("Inter", 11F, FontStyle.Bold);
            rjTexbox2.ForeColor = Color.Black;
            rjTexbox2.Location = new Point(538, 519);
            rjTexbox2.Multiline = true;
            rjTexbox2.Name = "rjTexbox2";
            rjTexbox2.Padding = new Padding(10, 7, 10, 7);
            rjTexbox2.PasswordChar = false;
            rjTexbox2.PlaceholderColor = Color.DarkGray;
            rjTexbox2.PlaceholderText = "";
            rjTexbox2.Size = new Size(420, 52);
            rjTexbox2.TabIndex = 34;
            rjTexbox2.Texts = "";
            rjTexbox2.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Inter Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(538, 485);
            label4.Name = "label4";
            label4.Size = new Size(233, 31);
            label4.TabIndex = 35;
            label4.Text = "Código Verificación";
            label4.TextAlign = ContentAlignment.MiddleCenter;
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
            roundButton2.Location = new Point(617, 592);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(225, 77);
            roundButton2.TabIndex = 37;
            roundButton2.Text = "Siguiente";
            roundButton2.TextColor = Color.White;
            roundButton2.UseVisualStyleBackColor = false;
            roundButton2.Click += roundButton2_Click;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.BackColor = Color.White;
            iconPictureBox3.ForeColor = Color.FromArgb(4, 120, 87);
            iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            iconPictureBox3.IconColor = Color.FromArgb(4, 120, 87);
            iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox3.IconSize = 36;
            iconPictureBox3.Location = new Point(494, 376);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Size = new Size(38, 36);
            iconPictureBox3.TabIndex = 76;
            iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.ForeColor = Color.FromArgb(4, 120, 87);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ClipboardQuestion;
            iconPictureBox1.IconColor = Color.FromArgb(4, 120, 87);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 36;
            iconPictureBox1.Location = new Point(494, 283);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(38, 36);
            iconPictureBox1.TabIndex = 77;
            iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.White;
            iconPictureBox2.ForeColor = Color.FromArgb(4, 120, 87);
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            iconPictureBox2.IconColor = Color.FromArgb(4, 120, 87);
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 36;
            iconPictureBox2.Location = new Point(494, 485);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(38, 36);
            iconPictureBox2.TabIndex = 78;
            iconPictureBox2.TabStop = false;
            // 
            // Verificación
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 251);
            ClientSize = new Size(1386, 730);
            Controls.Add(iconPictureBox2);
            Controls.Add(iconPictureBox1);
            Controls.Add(iconPictureBox3);
            Controls.Add(roundButton2);
            Controls.Add(label4);
            Controls.Add(rjTexbox2);
            Controls.Add(rjTexbox1);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(roundButton1);
            ForeColor = Color.FromArgb(246, 248, 251);
            Name = "Verificación";
            Text = "Verificación";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundButton roundButton1;
        private Label label1;
        private Label label3;
        private ComboBox comboBox1;
        private PictureBox pictureBox2;
        private Label label2;
        private RJTexbox rjTexbox1;
        private RJTexbox rjTexbox2;
        private Label label4;
        private RoundButton roundButton2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
    }
}
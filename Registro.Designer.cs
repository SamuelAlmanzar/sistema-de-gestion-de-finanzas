namespace ProyectoFinalMargarita
{
    partial class Registro
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
            pictureBox1 = new PictureBox();
            label5 = new Label();
            panel1 = new Panel();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            checkBox1 = new CheckBox();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.finance_track;
            pictureBox1.Location = new Point(895, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(101, 75);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Inter Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(4, 120, 87);
            label5.ImageAlign = ContentAlignment.BottomCenter;
            label5.Location = new Point(809, 80);
            label5.Name = "label5";
            label5.Size = new Size(265, 52);
            label5.TabIndex = 3;
            label5.Text = "FinanceTrack";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(489, 158);
            panel1.Name = "panel1";
            panel1.Size = new Size(872, 794);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint_1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(281, 598);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(400, 31);
            textBox4.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(281, 560);
            label7.Name = "label7";
            label7.Size = new Size(279, 35);
            label7.TabIndex = 13;
            label7.Text = "Confirmar Contraseña";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(281, 255);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(400, 31);
            textBox3.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(281, 217);
            label6.Name = "label6";
            label6.Size = new Size(109, 35);
            label6.TabIndex = 11;
            label6.Text = "Nombre";
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.FromArgb(4, 120, 87);
            iconButton2.Font = new Font("Inter", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.ImageAlign = ContentAlignment.MiddleRight;
            iconButton2.Location = new Point(272, 667);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(420, 69);
            iconButton2.TabIndex = 10;
            iconButton2.Text = "Ingresar";
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Inter", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(281, 485);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(226, 30);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Recordar Contraseña";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(281, 448);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(400, 31);
            textBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(281, 410);
            label4.Name = "label4";
            label4.Size = new Size(152, 35);
            label4.TabIndex = 6;
            label4.Text = "Contraseña";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(281, 347);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "name@example.com";
            textBox1.Size = new Size(400, 29);
            textBox1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(281, 309);
            label3.Name = "label3";
            label3.Size = new Size(80, 35);
            label3.TabIndex = 4;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(337, 105);
            label2.Name = "label2";
            label2.Size = new Size(223, 26);
            label2.TabIndex = 1;
            label2.Text = "Ingresa tus Credenciales";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Inter Black", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(363, 44);
            label1.Name = "label1";
            label1.Size = new Size(161, 40);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO";
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1924, 964);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Name = "Registro";
            Text = "Registro";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label5;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private Label label6;
        private CheckBox checkBox1;
        private TextBox textBox4;
        private Label label7;
    }
}
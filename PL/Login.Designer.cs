namespace ProyectoFinalMargarita
{
    partial class Login
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
            panel1 = new Panel();
            linkLabel2 = new LinkLabel();
            label6 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            checkBox1 = new CheckBox();
            linkLabel1 = new LinkLabel();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(426, 136);
            panel1.Name = "panel1";
            panel1.Size = new Size(873, 634);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint_1;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Inter Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel2.LinkColor = Color.FromArgb(33, 162, 122);
            linkLabel2.Location = new Point(585, 589);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(107, 26);
            linkLabel2.TabIndex = 12;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Registrate";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Inter", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(272, 589);
            label6.Name = "label6";
            label6.Size = new Size(307, 26);
            label6.TabIndex = 11;
            label6.Text = "Si no Tienes Cuenta Registra Aquí";
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
            iconButton2.Location = new Point(272, 506);
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
            checkBox1.Location = new Point(281, 454);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(226, 30);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Recordar Contraseña";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Inter Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.FromArgb(33, 162, 122);
            linkLabel1.Location = new Point(575, 379);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(245, 26);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Olvidaste tu contraseña?";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(281, 417);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(400, 31);
            textBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(281, 379);
            label4.Name = "label4";
            label4.Size = new Size(152, 35);
            label4.TabIndex = 6;
            label4.Text = "Contraseña";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(281, 311);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "name@example.com";
            textBox1.Size = new Size(400, 29);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(281, 264);
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
            label2.Location = new Point(374, 150);
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
            label1.Location = new Point(431, 76);
            label1.Name = "label1";
            label1.Size = new Size(105, 40);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Inter Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(4, 120, 87);
            label5.ImageAlign = ContentAlignment.BottomCenter;
            label5.Location = new Point(737, 81);
            label5.Name = "label5";
            label5.Size = new Size(265, 52);
            label5.TabIndex = 1;
            label5.Text = "FinanceTrack";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.finance_track;
            pictureBox1.Location = new Point(823, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(101, 75);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1419, 786);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private LinkLabel linkLabel1;
        private CheckBox checkBox1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private LinkLabel linkLabel2;
        private Label label6;
        private Label label5;
        private PictureBox pictureBox1;
    }
}
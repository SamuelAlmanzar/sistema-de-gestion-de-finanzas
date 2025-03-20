namespace ProyectoFinalMargarita.PL.MainPage
{
    partial class Main
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
            roundButton2 = new RoundButton();
            pictureBox2 = new PictureBox();
            roundButton3 = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.White;
            roundButton1.BackgroundColor = Color.White;
            roundButton1.BorderColor = Color.White;
            roundButton1.BorderRadius = 5;
            roundButton1.BorderSize = 0;
            roundButton1.FlatAppearance.BorderColor = Color.White;
            roundButton1.FlatAppearance.BorderSize = 10;
            roundButton1.FlatAppearance.MouseDownBackColor = Color.White;
            roundButton1.FlatAppearance.MouseOverBackColor = Color.White;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(1, 0);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(1925, 170);
            roundButton1.TabIndex = 31;
            roundButton1.TextColor = Color.Black;
            roundButton1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(21, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(262, 148);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
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
            roundButton2.FlatAppearance.MouseDownBackColor = Color.Black;
            roundButton2.FlatAppearance.MouseOverBackColor = Color.Black;
            roundButton2.FlatStyle = FlatStyle.Flat;
            roundButton2.Font = new Font("Inter Black", 10F, FontStyle.Bold);
            roundButton2.ForeColor = Color.White;
            roundButton2.Location = new Point(1639, 49);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(251, 70);
            roundButton2.TabIndex = 46;
            roundButton2.Text = "Cerrar sesión";
            roundButton2.TextColor = Color.White;
            roundButton2.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(4, 120, 87);
            pictureBox2.Image = Properties.Resources.puerta_abierta;
            pictureBox2.Location = new Point(1650, 66);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 47;
            pictureBox2.TabStop = false;
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
            roundButton3.FlatAppearance.MouseDownBackColor = Color.Black;
            roundButton3.FlatAppearance.MouseOverBackColor = Color.Black;
            roundButton3.FlatStyle = FlatStyle.Flat;
            roundButton3.Font = new Font("Inter Black", 10F, FontStyle.Bold);
            roundButton3.ForeColor = Color.White;
            roundButton3.Location = new Point(1394, 49);
            roundButton3.Name = "roundButton3";
            roundButton3.Size = new Size(214, 71);
            roundButton3.TabIndex = 48;
            roundButton3.Text = "Mi Cuenta";
            roundButton3.TextColor = Color.White;
            roundButton3.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1924, 1050);
            Controls.Add(roundButton3);
            Controls.Add(pictureBox2);
            Controls.Add(roundButton2);
            Controls.Add(pictureBox1);
            Controls.Add(roundButton1);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundButton roundButton1;
        private PictureBox pictureBox1;
        private RoundButton roundButton2;
        private PictureBox pictureBox2;
        private RoundButton roundButton3;
    }
}
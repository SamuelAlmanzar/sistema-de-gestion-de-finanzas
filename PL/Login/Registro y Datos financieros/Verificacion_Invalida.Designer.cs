namespace ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros
{
    partial class Verificacion_Invalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verificacion_Invalida));
            roundButton1 = new RoundButton();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            roundButton2 = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.White;
            roundButton1.BackgroundColor = Color.White;
            roundButton1.BorderColor = Color.Black;
            roundButton1.BorderRadius = 10;
            roundButton1.BorderSize = 0;
            roundButton1.FlatAppearance.BorderColor = Color.White;
            roundButton1.FlatAppearance.BorderSize = 10;
            roundButton1.FlatAppearance.MouseDownBackColor = Color.White;
            roundButton1.FlatAppearance.MouseOverBackColor = Color.White;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(128, 12);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(548, 426);
            roundButton1.TabIndex = 25;
            roundButton1.TextColor = Color.Black;
            roundButton1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(293, 85);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 167);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(273, 285);
            label1.Name = "label1";
            label1.Size = new Size(235, 35);
            label1.TabIndex = 27;
            label1.Text = "Verficación Fallida";
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
            roundButton2.ForeColor = Color.Black;
            roundButton2.Location = new Point(273, 342);
            roundButton2.Name = "roundButton2";
            roundButton2.Size = new Size(225, 77);
            roundButton2.TabIndex = 39;
            roundButton2.Text = "Volver a Intentar";
            roundButton2.TextColor = Color.Black;
            roundButton2.UseVisualStyleBackColor = false;
            // 
            // Verificacion_Invalida
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 251);
            ClientSize = new Size(800, 450);
            Controls.Add(roundButton2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(roundButton1);
            Name = "Verificacion_Invalida";
            Text = "Verificacion_Invalida";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundButton roundButton1;
        private PictureBox pictureBox1;
        private Label label1;
        private RoundButton roundButton2;
    }
}
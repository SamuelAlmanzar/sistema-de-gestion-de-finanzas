namespace ProyectoFinalMargarita.PL.CRUD_CUENTAS
{
    partial class FORMCUENTAS
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
            SuspendLayout();
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.White;
            roundButton1.BackgroundColor = Color.White;
            roundButton1.BorderColor = Color.Black;
            roundButton1.BorderRadius = 40;
            roundButton1.BorderSize = 0;
            roundButton1.FlatAppearance.BorderColor = Color.White;
            roundButton1.FlatAppearance.BorderSize = 10;
            roundButton1.FlatAppearance.MouseDownBackColor = Color.White;
            roundButton1.FlatAppearance.MouseOverBackColor = Color.White;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(44, 12);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(853, 1026);
            roundButton1.TabIndex = 23;
            roundButton1.TextColor = Color.Black;
            roundButton1.UseVisualStyleBackColor = false;
            // 
            // FORMCUENTAS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 251);
            ClientSize = new Size(940, 1050);
            Controls.Add(roundButton1);
            Name = "FORMCUENTAS";
            Text = "FORMCUENTAS";
            ResumeLayout(false);
        }

        #endregion

        private RoundButton roundButton1;
    }
}
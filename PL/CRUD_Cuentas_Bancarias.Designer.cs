namespace ProyectoFinalMargarita.PL
{
    partial class CRUD_Cuentas_Bancarias
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
            DatosCuentas = new DataGridView();
            label1 = new Label();
            textPropietario = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            numeroDeCuenta = new TextBox();
            label88 = new Label();
            textSaldo = new TextBox();
            label5 = new Label();
            textCreacion = new TextBox();
            textTipoCuenta = new ComboBox();
            textBanco = new TextBox();
            Nuevo = new Button();
            agregar = new Button();
            Editar = new Button();
            Eliminar = new Button();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)DatosCuentas).BeginInit();
            SuspendLayout();
            // 
            // DatosCuentas
            // 
            DatosCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatosCuentas.Location = new Point(12, 279);
            DatosCuentas.Name = "DatosCuentas";
            DatosCuentas.RowHeadersWidth = 62;
            DatosCuentas.Size = new Size(1208, 225);
            DatosCuentas.TabIndex = 0;
            DatosCuentas.SelectionChanged += DatosCuentas_SelectionChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 157);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 1;
            label1.Text = "Propietario ";
            // 
            // textPropietario
            // 
            textPropietario.Location = new Point(267, 146);
            textPropietario.Name = "textPropietario";
            textPropietario.Size = new Size(205, 31);
            textPropietario.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(503, 157);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 1;
            label2.Text = "Banco";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 229);
            label3.Name = "label3";
            label3.Size = new Size(129, 25);
            label3.TabIndex = 1;
            label3.Text = "Tipo de cuenta";
            label3.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 193);
            label4.Name = "label4";
            label4.Size = new Size(168, 25);
            label4.TabIndex = 1;
            label4.Text = "Numero de cuenta: ";
            label4.Click += label2_Click;
            // 
            // numeroDeCuenta
            // 
            numeroDeCuenta.Location = new Point(267, 188);
            numeroDeCuenta.Name = "numeroDeCuenta";
            numeroDeCuenta.Size = new Size(205, 31);
            numeroDeCuenta.TabIndex = 2;
            // 
            // label88
            // 
            label88.AutoSize = true;
            label88.Location = new Point(503, 191);
            label88.Name = "label88";
            label88.Size = new Size(66, 25);
            label88.TabIndex = 1;
            label88.Text = "Saldo: ";
            label88.Click += label2_Click;
            // 
            // textSaldo
            // 
            textSaldo.Location = new Point(677, 186);
            textSaldo.Name = "textSaldo";
            textSaldo.Size = new Size(205, 31);
            textSaldo.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(503, 228);
            label5.Name = "label5";
            label5.Size = new Size(152, 25);
            label5.TabIndex = 1;
            label5.Text = "Fecha de creacion";
            label5.Click += label2_Click;
            // 
            // textCreacion
            // 
            textCreacion.Location = new Point(677, 223);
            textCreacion.Name = "textCreacion";
            textCreacion.Size = new Size(205, 31);
            textCreacion.TabIndex = 2;
            // 
            // textTipoCuenta
            // 
            textTipoCuenta.FormattingEnabled = true;
            textTipoCuenta.Items.AddRange(new object[] { "Corriente ", "Ahorro ", "Inversión " });
            textTipoCuenta.Location = new Point(267, 229);
            textTipoCuenta.Name = "textTipoCuenta";
            textTipoCuenta.Size = new Size(205, 33);
            textTipoCuenta.TabIndex = 3;
            // 
            // textBanco
            // 
            textBanco.Location = new Point(677, 146);
            textBanco.Name = "textBanco";
            textBanco.Size = new Size(205, 31);
            textBanco.TabIndex = 2;
            // 
            // Nuevo
            // 
            Nuevo.Location = new Point(904, 162);
            Nuevo.Name = "Nuevo";
            Nuevo.Size = new Size(112, 34);
            Nuevo.TabIndex = 4;
            Nuevo.Text = "Nuevo";
            Nuevo.UseVisualStyleBackColor = true;
            Nuevo.Click += Nuevo_Click;
            // 
            // agregar
            // 
            agregar.Location = new Point(1038, 162);
            agregar.Name = "agregar";
            agregar.Size = new Size(112, 34);
            agregar.TabIndex = 4;
            agregar.Text = "Agregar";
            agregar.UseVisualStyleBackColor = true;
            agregar.Click += agregar_Click;
            // 
            // Editar
            // 
            Editar.Location = new Point(904, 208);
            Editar.Name = "Editar";
            Editar.Size = new Size(112, 34);
            Editar.TabIndex = 4;
            Editar.Text = "Editar";
            Editar.UseVisualStyleBackColor = true;
            // 
            // Eliminar
            // 
            Eliminar.Location = new Point(1038, 208);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(112, 34);
            Eliminar.TabIndex = 4;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("SimSun-ExtB", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(392, 27);
            label6.Name = "label6";
            label6.Size = new Size(517, 40);
            label6.TabIndex = 5;
            label6.Text = "Crud de cuentas bancarias";
            // 
            // prueba
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 592);
            Controls.Add(label6);
            Controls.Add(Eliminar);
            Controls.Add(Editar);
            Controls.Add(agregar);
            Controls.Add(Nuevo);
            Controls.Add(textTipoCuenta);
            Controls.Add(textCreacion);
            Controls.Add(textSaldo);
            Controls.Add(numeroDeCuenta);
            Controls.Add(label5);
            Controls.Add(label88);
            Controls.Add(label4);
            Controls.Add(textBanco);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textPropietario);
            Controls.Add(label1);
            Controls.Add(DatosCuentas);
            Name = "prueba";
            Text = "prueba";
            Load += prueba_Load;
            ((System.ComponentModel.ISupportInitialize)DatosCuentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DatosCuentas;
        private Label label1;
        private TextBox textPropietario;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox numeroDeCuenta;
        private Label label88;
        private TextBox textSaldo;
        private Label label5;
        private TextBox textCreacion;
        private ComboBox textTipoCuenta;
        private TextBox textBanco;
        private Button Nuevo;
        private Button agregar;
        private Button Editar;
        private Button Eliminar;
        private Label label6;
    }
}
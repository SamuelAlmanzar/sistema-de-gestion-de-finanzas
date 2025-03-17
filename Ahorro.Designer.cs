namespace ProyectoFinalMargarita
{
    partial class Ahorro
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
            label6 = new Label();
            Eliminar = new Button();
            Editar = new Button();
            Nuevo = new Button();
            monto = new TextBox();
            label4 = new Label();
            label2 = new Label();
            fecha = new DateTimePicker();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            Meta = new TextBox();
            MontoAhorrado = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("SimSun-ExtB", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(532, 35);
            label6.Name = "label6";
            label6.Size = new Size(317, 40);
            label6.TabIndex = 22;
            label6.Text = "Metas de Ahorro";
            // 
            // Eliminar
            // 
            Eliminar.Location = new Point(721, 292);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(112, 34);
            Eliminar.TabIndex = 21;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = true;
            Eliminar.Click += Eliminar_Click;
            // 
            // Editar
            // 
            Editar.Location = new Point(805, 215);
            Editar.Name = "Editar";
            Editar.Size = new Size(112, 34);
            Editar.TabIndex = 20;
            Editar.Text = "Editar";
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // Nuevo
            // 
            Nuevo.Location = new Point(655, 215);
            Nuevo.Name = "Nuevo";
            Nuevo.Size = new Size(112, 34);
            Nuevo.TabIndex = 18;
            Nuevo.Text = "Nuevo";
            Nuevo.UseVisualStyleBackColor = true;
            Nuevo.Click += Nuevo_Click;
            // 
            // monto
            // 
            monto.Location = new Point(401, 181);
            monto.Name = "monto";
            monto.Size = new Size(205, 31);
            monto.TabIndex = 14;
      
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(227, 187);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 9;
            label4.Text = "Monto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 301);
            label2.Name = "label2";
            label2.Size = new Size(57, 25);
            label2.TabIndex = 7;
            label2.Text = "Fecha";
            // 
            // fecha
            // 
            fecha.Format = DateTimePickerFormat.Short;
            fecha.Location = new Point(401, 296);
            fecha.Name = "fecha";
            fecha.Size = new Size(205, 31);
            fecha.TabIndex = 24;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(113, 370);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1177, 569);
            dataGridView1.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(227, 262);
            label3.Name = "label3";
            label3.Size = new Size(52, 25);
            label3.TabIndex = 8;
            label3.Text = "Meta";
            // 
            // Meta
            // 
            Meta.Location = new Point(401, 255);
            Meta.Name = "Meta";
            Meta.Size = new Size(205, 31);
            Meta.TabIndex = 23;
            // 
            // MontoAhorrado
            // 
            MontoAhorrado.Location = new Point(401, 218);
            MontoAhorrado.Name = "MontoAhorrado";
            MontoAhorrado.Size = new Size(205, 31);
            MontoAhorrado.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(205, 224);
            label5.Name = "label5";
            label5.Size = new Size(147, 25);
            label5.TabIndex = 28;
            label5.Text = "Monto Ahorrado";
            // 
            // Ahorro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1375, 1050);
            Controls.Add(MontoAhorrado);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(fecha);
            Controls.Add(Meta);
            Controls.Add(label6);
            Controls.Add(Eliminar);
            Controls.Add(Editar);
            Controls.Add(Nuevo);
            Controls.Add(monto);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Ahorro";
            Text = "Ahorro";
            Load += Ahorro_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Button Eliminar;
        private Button Editar;
        private Button Nuevo;
        private TextBox monto;
        private Label label4;
        private Label label2;
        private DateTimePicker fecha;
        private DataGridView dataGridView1;
        private Label label3;
        private TextBox Meta;
        private TextBox MontoAhorrado;
        private Label label5;
    }
}
namespace ProyectoFinalMargarita
{
    partial class Registro_Ingresos_Egresos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            comboBox2 = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(204, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(1191, 759);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.Location = new Point(82, 672);
            button1.Name = "button1";
            button1.Size = new Size(183, 55);
            button1.TabIndex = 11;
            button1.Text = "AGREGAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(466, 193);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(659, 534);
            dataGridView1.TabIndex = 10;
            // 
            // Column1
            // 
            Column1.HeaderText = "Monto";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tipo";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 150;
            // 
            // Column3
            // 
            Column3.HeaderText = "Categoría";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Fecha";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Salario", "Bonificaciones", "", "Ventas", "", "", "Donaciones", "", "Alimentación", "Transporte ", "Vivienda", "Salud", "Educación", "Ropa y accesorios" });
            comboBox2.Location = new Point(73, 458);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(192, 33);
            comboBox2.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(113, 413);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 8;
            label5.Text = "Categoría";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 548);
            label4.Name = "label4";
            label4.Size = new Size(57, 25);
            label4.TabIndex = 7;
            label4.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(73, 589);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(192, 31);
            dateTimePicker1.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Ingreso", "Egreso" });
            comboBox1.Location = new Point(73, 322);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 33);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(135, 279);
            label3.Name = "label3";
            label3.Size = new Size(47, 25);
            label3.TabIndex = 4;
            label3.Text = "Tipo";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(73, 193);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(192, 31);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 165);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 2;
            label2.Text = "Monto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(436, 15);
            label1.Name = "label1";
            label1.Size = new Size(410, 45);
            label1.TabIndex = 0;
            label1.Text = "Registro Ingresos y Egresos";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Registro_Ingresos_Egresos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 240);
            ClientSize = new Size(1533, 815);
            Controls.Add(panel1);
            Name = "Registro_Ingresos_Egresos";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label5;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private FileSystemWatcher fileSystemWatcher1;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}

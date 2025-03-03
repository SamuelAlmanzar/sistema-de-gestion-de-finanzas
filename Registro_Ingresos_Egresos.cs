namespace ProyectoFinalMargarita
{
    public partial class Registro_Ingresos_Egresos : Form
    {
        public Registro_Ingresos_Egresos()
        {
            InitializeComponent();
        }

        private void Registro_Ingresos_Egresos_Load(object sender, EventArgs e)
        {
            // Configura las columnas del DataGridView
            dataGridView1.Columns.Add("Tipo", "Tipo");
            dataGridView1.Columns.Add("Categoría", "Categoría");
            dataGridView1.Columns.Add("Monto", "Monto");
            dataGridView1.Columns.Add("Fecha", "Fecha");

            // Formato de las columnas
            dataGridView1.Columns["Monto"].DefaultCellStyle.Format = "C2"; // Formato de moneda
            dataGridView1.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy"; // Formato de fecha

            // Agrega las opciones de "Ingreso" y "Egreso" al ComboBox1
            comboBox1.Items.Add("Ingreso");
            comboBox1.Items.Add("Egreso");
            comboBox1.SelectedIndex = 0; // Selecciona "Ingreso" por defecto

            // Actualiza las categorías según la selección inicial
            ActualizarCategorias();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualiza las categorías cuando cambia la selección en ComboBox1
            ActualizarCategorias();
        }

        private void ActualizarCategorias()
        {
            // Limpia las categorías anteriores
            comboBox2.Items.Clear();

            // Agrega las categorías según la selección de "Ingreso" o "Egreso"
            if (comboBox1.SelectedItem.ToString() == "Ingreso")
            {
                comboBox2.Items.AddRange(new string[] {
                    "Salario", "Bonificaciones", "Ventas",
                    "Donaciones"
                });
            }
            else if (comboBox1.SelectedItem.ToString() == "Egreso")
            {
                comboBox2.Items.AddRange(new string[] {
                    "Alimentación", "Transporte", "Vivienda",
                    "Salud", "Educación",
                    "Ropa y accesorios",
                });
            }

            // Selecciona la primera categoría por defecto
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }

    

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Código de pintura del panel si es necesario
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            if (!decimal.TryParse(textBox1.Text, out decimal monto))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        
            string tipo = comboBox1.SelectedItem.ToString();
            string categoria = comboBox2.SelectedItem.ToString();
            string fecha = dateTimePicker1.Value.ToString("dd/MM/yyyy"); 

           
            dataGridView1.Rows.Add(tipo, categoria, monto, fecha);

            comboBox1.SelectedIndex = 0; 
            comboBox2.SelectedIndex = 0; 
            dateTimePicker1.Value = DateTime.Now; 
        }
    }
}
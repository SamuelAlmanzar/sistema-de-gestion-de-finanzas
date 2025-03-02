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
          
            comboBox1.Items.Add("Ingreso");
            comboBox1.Items.Add("Egreso");

            comboBox1.SelectedIndex = 0; 
            ActualizarCategorias(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCategorias();
        }

        private void ActualizarCategorias()
        {
            comboBox2.Items.Clear(); 

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

            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0; 
        }
    }
}

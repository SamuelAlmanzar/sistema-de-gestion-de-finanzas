using System;
using System.Windows.Forms;

namespace ProyectoFinalMargarita
{
    public partial class Ahorro : Form
    {
        public Ahorro()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Ahorro_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Monto", "Monto");
            dataGridView1.Columns.Add("MontoAhorrado", "Monto Ahorrado");
            dataGridView1.Columns.Add("Meta", "Meta");
            dataGridView1.Columns.Add("Fecha", "Fecha");
            dataGridView1.Columns.Add("AhorroDiario", "Ahorro Diario");
            dataGridView1.Columns.Add("AhorroSemanal", "Ahorro Semanal");
            dataGridView1.Columns.Add("AhorroMensual", "Ahorro Mensual");
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(monto.Text) && !string.IsNullOrEmpty(Meta.Text))
            {
                double montoTotal;
                if (!double.TryParse(monto.Text, out montoTotal) || montoTotal <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un monto válido.");
                    return;
                }

                DateTime fechaLimite = fecha.Value;
                if (fechaLimite <= DateTime.Now)
                {
                    MessageBox.Show("La fecha límite debe ser mayor que la fecha actual.");
                    return;
                }

                TimeSpan diferencia = fechaLimite - DateTime.Now;
                int diasDisponibles = (int)diferencia.TotalDays;

                double ahorroDiario = montoTotal / diasDisponibles;
                double ahorroSemanal = ahorroDiario * 7;

                string ahorroMensual = "N/A";
                if (diasDisponibles > 90)
                {
                    double mesesDisponibles = diasDisponibles / 30.0;
                    ahorroMensual = (montoTotal / mesesDisponibles).ToString("C");
                }

                dataGridView1.Rows.Add(montoTotal.ToString("C"), "0", Meta.Text, fechaLimite.ToString("yyyy-MM-dd"), ahorroDiario.ToString("C"), ahorroSemanal.ToString("C"), ahorroMensual);

                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                double montoTotal;
                if (!double.TryParse(monto.Text, out montoTotal) || montoTotal <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un monto válido.");
                    return;
                }

                DateTime fechaLimite = fecha.Value;
                if (fechaLimite <= DateTime.Now)
                {
                    MessageBox.Show("La fecha límite debe ser mayor que la fecha actual.");
                    return;
                }

                TimeSpan diferencia = fechaLimite - DateTime.Now;
                int diasDisponibles = (int)diferencia.TotalDays;

                double ahorroDiario = montoTotal / diasDisponibles;
                double ahorroSemanal = ahorroDiario * 7;

                string ahorroMensual = "N/A";
                if (diasDisponibles > 90)
                {
                    double mesesDisponibles = diasDisponibles / 30.0;
                    ahorroMensual = (montoTotal / mesesDisponibles).ToString("C");
                }

                selectedRow.Cells["Monto"].Value = montoTotal.ToString("C");
                selectedRow.Cells["Meta"].Value = Meta.Text;
                selectedRow.Cells["Fecha"].Value = fechaLimite.ToString("yyyy-MM-dd");
                selectedRow.Cells["AhorroDiario"].Value = ahorroDiario.ToString("C");
                selectedRow.Cells["AhorroSemanal"].Value = ahorroSemanal.ToString("C");
                selectedRow.Cells["AhorroMensual"].Value = ahorroMensual;

                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.");
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                monto.Text = row.Cells["Monto"].Value.ToString().Replace("$", "").Replace(",", "");
                Meta.Text = row.Cells["Meta"].Value.ToString();
                fecha.Value = DateTime.Parse(row.Cells["Fecha"].Value.ToString());
            }
        }

        private void LimpiarControles()
        {
            monto.Clear();
            Meta.Clear();
            fecha.Value = DateTime.Now;
        }
    }
}
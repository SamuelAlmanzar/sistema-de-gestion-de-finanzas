using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMargarita.Clases.Registro
{
    public partial class DatosCliente : Component
    {
        public DatosCliente()
        {
            InitializeComponent();
        }

        public DatosCliente(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}

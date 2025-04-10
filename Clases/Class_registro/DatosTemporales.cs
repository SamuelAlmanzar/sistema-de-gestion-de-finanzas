using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMargarita.Clases.Class_registro
{
    public static class DatosTemporales
    {
        public static Cliente Cliente { get; set; } = new Cliente();
        public static InformacionFinanciera InfoFinanciera { get; set; } = new InformacionFinanciera();
        public static ClassPropositoCuenta Proposito { get; set; } = new ClassPropositoCuenta();
        public static SeguridadCuenta Seguridad { get; set; } = new SeguridadCuenta();

        public static void Limpiar()
        {
            Cliente = new Cliente();
            InfoFinanciera = new InformacionFinanciera();
            Proposito = new ClassPropositoCuenta();
            Seguridad = new SeguridadCuenta();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMargarita
{
        public class CuentaBancaria
        {
            public int Id { get; set; }
            public int UsuarioId { get; set; }
            public string Banco { get; set; }
            public string TipoCuenta { get; set; }
            public string NumeroCuenta { get; set; }
            public decimal Saldo { get; set; }
            public string Moneda { get; set; }
            public DateTime FechaCreacion { get; set; }
        }
    
}

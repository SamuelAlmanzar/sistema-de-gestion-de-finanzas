using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMargarita.Clases.Class_registro
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class InformacionFinanciera
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public string NombreEmpresa { get; set; }
        public string Cargo { get; set; }
        public int TiempoEnEmpresa { get; set; }
        public decimal IngresoMensualEstimado { get; set; }
        public bool DeudasActivas { get; set; }
        public bool HaTenidoCredito { get; set; }
    }

    public class ClassPropositoCuenta
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public string Motivo { get; set; }
        public decimal MontoPromedio { get; set; }
        public string FrecuenciaTransacciones { get; set; }
        public bool TransaccionesInternacionales { get; set; }

    }

    public class SeguridadCuenta
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public string Contraseña { get; set; }
        public string MetodoRecuperacion { get; set; }
        public string PreguntaSeguridad { get; set; }
        public string RespuestaSeguridad { get; set; }
        public bool AutenticacionDosPasos { get; set; }
    }
}

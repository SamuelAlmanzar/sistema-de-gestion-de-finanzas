using ProyectoFinalMargarita.PL;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProyectoFinalMargarita;
using ProyectoFinalMargarita.PL.CRUD_CUENTAS;

namespace ProyectoFinalMargarita
{
    internal static class Program
    {
        private static HubConnection connection; // Conexi�n con el servidor SignalR
        private static readonly string filePath = "Relogin.json"; // Archivo JSON para sesi�n



        [STAThread]
        static void Main()
        {
            // Configuraci�n de la aplicaci�n
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar la conexi�n SignalR
            InitializeSignalR().ConfigureAwait(false);


            // Verificar si hay una sesi�n guardada
            if (SesionActiva())
            {
                string usuarioGuardado = ObtenerUsuarioGuardado();
                Application.Run(new Main(usuarioGuardado)); // Abre el formulario principal
            }
            else
            {
                Application.Run(new oldpassword()); // Si no hay sesi�n, muestra el login
            }
        }

        private static bool SesionActiva()
        {
            return File.Exists(filePath) && !string.IsNullOrEmpty(ObtenerUsuarioGuardado());
        }

        private static string ObtenerUsuarioGuardado()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    var data = JsonConvert.DeserializeObject<dynamic>(json);
                    return data.Usuario;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo de sesi�n: " + ex.Message);
            }
            return null;

            // Ejecutar el formulario principal
            //El Form de informacion personal se llama Registro
            Application.Run(new Registro());
        }

        private static async Task InitializeSignalR()
        {
            try
            {
                connection = new HubConnectionBuilder()
                    .WithUrl("https://tuservidor.com/hub") // Reemplaza con la URL de tu servidor SignalR
                    .Build();

                await connection.StartAsync();
                Console.WriteLine("Conectado al servidor SignalR.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con SignalR: {ex.Message}");
            }
        }
    }
}

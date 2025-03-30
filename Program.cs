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
        private static HubConnection connection; // Conexión con el servidor SignalR
        private static readonly string filePath = "Relogin.json"; // Archivo JSON para sesión

        [STAThread]
        static void Main()
        {
            // Configuración de la aplicación
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar la conexión SignalR
            InitializeSignalR().ConfigureAwait(false);

            // Verificar si hay una sesión guardada
            if (SesionActiva())
            {
                string usuarioGuardado = ObtenerUsuarioGuardado();
                Application.Run(new Main(usuarioGuardado)); // Abre el formulario principal
            }
            else
            {
                Application.Run(new Registro()); // Si no hay sesión, muestra el login
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
                Console.WriteLine("Error al leer el archivo de sesión: " + ex.Message);
            }
            return null;
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

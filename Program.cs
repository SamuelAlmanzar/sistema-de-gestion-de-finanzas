using ProyectoFinalMargarita.PL;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros;

namespace ProyectoFinalMargarita
{
    internal static class Program
    {
        private static HubConnection connection; // Conexión con el servidor SignalR

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuración de la aplicación
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar la conexión SignalR
            InitializeSignalR().ConfigureAwait(false);

            // Ejecutar el formulario principal
            Application.Run(new Verificación());
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
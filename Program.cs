using ProyectoFinalMargarita.PL;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalMargarita;
using ProyectoFinalMargarita.PL.Login.Registro_y_Datos_financieros;
using ProyectoFinalMargarita.PL.CRUD_CUENTAS;
using ProyectoFinalMargarita.PL.MainPage;
using ProyectoFinalMargarita.PL.Ingreso_Egreso;



namespace ProyectoFinalMargarita
{
    internal static class Program
    {
        private static HubConnection connection; // Conexi�n con el servidor SignalR

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuraci�n de la aplicaci�n
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar la conexi�n SignalR
            InitializeSignalR().ConfigureAwait(false);

            // Ejecutar el formulario principal
            //El Form de informacion personal se llama Registro
            Application.Run(new InformacionFinanciera());
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
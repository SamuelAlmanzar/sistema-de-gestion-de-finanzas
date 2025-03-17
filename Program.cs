using ProyectoFinalMargarita.PL;
using Microsoft.AspNetCore.SignalR.Client;
namespace ProyectoFinalMargarita
{
    internal static class Program
    {
        private static HubConnection connection; // Conexión con el servidor SignalR
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async System.Threading.Tasks.Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
<<<<<<< HEAD
            Application.Run(new CRUD_Cuentas_Bancarias());
        
=======

            Application.Run(new Registro());


>>>>>>> a05dc71618f85b8a89567940752d947f67baccea
        }

    }

}

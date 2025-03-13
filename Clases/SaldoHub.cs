using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ProyectoFinalMargarita.Clases
{
    public class TransferenciaHub : Hub
    {
        public async Task EnviarTransferencia(int cuentaOrigen, int cuentaDestino, decimal monto)
        {
            // Notificar solo a los clientes que estén escuchando la cuenta de destino
            await Clients.All.SendAsync("RecibirTransferencia", cuentaOrigen, cuentaDestino, monto);
        }
    }
}

using Microsoft.AspNetCore.SignalR;

namespace KirikiServer.Hubs
{
    public class KirikiHub : Hub
    {
        public async Task Tirar(int dado1, int dado2)
        {
            await Clients.All.SendAsync("Tirar", dado1, dado2);
        } 

        public async Task PasarTurno()
        {
            await Clients.All.SendAsync("PasarTurno");
        }

        public async Task CalcularVida()
        {
            await Clients.All.SendAsync("CalcularVida");
        }

    }
}

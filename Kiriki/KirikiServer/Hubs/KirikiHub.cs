using Microsoft.AspNetCore.SignalR;

namespace KirikiServer.Hubs
{
    public class KirikiHub : Hub
    {
        public async Task MostrarDado(String dado1, String dado2)
        {
            await Clients.All.SendAsync("MostrarDado", dado1, dado2);
        } 

        public async Task PasarTurno(String turno, bool tuTurno)
        {
            await Clients.All.SendAsync("PasarTurno", turno);
        }

        public async Task CalcularVida(int vida)
        {
            await Clients.All.SendAsync("CalcularVida", vida);
        }

    }
}

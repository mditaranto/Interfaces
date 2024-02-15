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
            Clients.Others.SendAsync("PasarTurno");
        }

        public void CalcularVida()
        {
            Clients.Others.SendAsync("CalcularVida");
        }

        public async Task asignarTurno()
        {
            GameInfo.numJugadores += 1;
            if (GameInfo.numJugadores <= 1)
            {
                Clients.Caller.SendAsync("PasarTurno");
            }
        }

    }
}

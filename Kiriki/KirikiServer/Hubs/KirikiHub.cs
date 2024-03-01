using Microsoft.AspNetCore.SignalR;

namespace KirikiServer.Hubs
{
    public class KirikiHub : Hub
    {
        #region juego
        public async Task Tirar(int dado1, int dado2)
        {
            await Clients.All.SendAsync("Tirar", dado1, dado2);
        } 

        public async Task PasarTurno()
        {
            Clients.Others.SendAsync("PasarTurno");
        }

        public async Task CalcularVida()
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

        public async Task terminarJuego(string perdedor)
        {
            GameInfo.numJugadores = 0;
            Clients.All.SendAsync("terminarJuego", perdedor);
            
        }
        #endregion

        #region salas
        public async Task CrearSala(string nombre)
        {
            GameInfo.salas.Add(nombre);
            await Groups.AddToGroupAsync(Context.ConnectionId, nombre);
            await Clients.Others.SendAsync("SalaCreada", nombre);
        }

        public async Task UnirseSala(string nombre)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, nombre);
            GameInfo.salas.Remove(nombre);
            await Clients.Others.SendAsync("SalaUnida", nombre);

        }

        #endregion

    }
}

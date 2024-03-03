using Microsoft.AspNetCore.SignalR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KirikiServer.Hubs
{
    public class KirikiHub : Hub
    {
        #region juego
        /// <summary>
        /// Funcion que se encarga de enviar los valores de los dados a los jugadores de la sala
        /// </summary>
        /// <param name="dado1"></param>
        /// <param name="dado2"></param>
        /// <param name="nombresala"></param>
        /// <returns></returns>
        public async Task Tirar(int dado1, int dado2, string nombresala)
        {
            await Clients.Group(nombresala).SendAsync("Tirar", dado1, dado2);
        } 

        /// <summary>
        /// Funcion que se encarga de permitir que el otro jugador tenga turno
        /// </summary>
        /// <param name="nombresala"></param>
        /// <returns></returns>
        public async Task PasarTurno(string nombresala)
        {
            await Clients.OthersInGroup(nombresala).SendAsync("PasarTurno");
        }

        /// <summary>
        /// Funcion que se encarga de calcular la vida del jugador
        /// </summary>
        /// <param name="nombresala"></param>
        /// <returns></returns>
        public async Task CalcularVida(string nombresala)
        {
            await Clients.OthersInGroup(nombresala).SendAsync("CalcularVida");
        }

        /// <summary>
        /// Funcion que se encarga de asignar el turno al jugador al entrar por 1º vez a la sala
        /// </summary>
        /// <param name="nombresala"></param>
        /// <returns></returns>
        public async Task asignarTurno(string nombresala)
        {
            
            if (GameInfo.salas.Find(x => x.Nombre == nombresala).NumJugadores <= 1 )
            {
                await Clients.Caller.SendAsync("PasarTurno");

            } else
            {
                // Si ya hay 2 jugadores, la sala se borra para que nadie mas pueda entrar
                GameInfo.salas.Remove(GameInfo.salas.Find(x => x.Nombre == nombresala));

                // Añade el jugador al grupo
                List<string> salas = new List<string>();
                await Groups.AddToGroupAsync(Context.ConnectionId, nombresala);

                foreach (clsSalaServer sala in GameInfo.salas)
                {
                    salas.Add(sala.Nombre);
                }
                //Se envia la lista sin la sala
                await Clients.Others.SendAsync("SalaUnida", salas);
            }
        }

        /// <summary>
        /// Funcion que se encarga de terminar el juego
        /// </summary>
        /// <param name="perdedor"></param>
        /// <param name="sala"></param>
        /// <returns></returns>
        public async Task terminarJuego(string perdedor, string sala)
        {
            await Clients.Group(sala).SendAsync("terminarJuego", perdedor);
            
        }
        #endregion

        #region salas
        /// <summary>
        /// Funcion que suma 1 jugador a la sala
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public async Task UnirseSala(string nombre)
        {   
            GameInfo.salas.Find(x => x.Nombre == nombre).NumJugadores++;
        }

        /// <summary>
        /// Funcion que crea una sala y envia una lista de las salas
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public async Task CrearSala(string nombre)
        {
            List<string> salas = new List<string>();

            clsSalaServer sala = new clsSalaServer(nombre);
            GameInfo.salas.Add(sala);
            await Groups.AddToGroupAsync(Context.ConnectionId, nombre);
            foreach (clsSalaServer salasas in GameInfo.salas)
            {
                salas.Add(salasas.Nombre);
            }
            await Clients.Others.SendAsync("SalaCreada", salas);
        }

        /// <summary>
        /// Funcion que envia una lista de las salas
        /// </summary>
        /// <returns></returns>
        public async Task rellenarSalas()
        {
            List<string> salas = new List<string>();
            foreach (clsSalaServer sala in GameInfo.salas)
            {
                salas.Add(sala.Nombre);
            }
            await Clients.Caller.SendAsync("rellenarSalas", salas);
        }

        /// <summary>
        /// Funcion que al terminar el juego borra la sala e informa a los demas jugadores
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public async Task borrarSala(string nombre)
        {
            if (GameInfo.salas.Contains(GameInfo.salas.Find(x => x.Nombre == nombre)))
            {
                GameInfo.salas.Remove(GameInfo.salas.Find(x => x.Nombre == nombre));
            }
            await Clients.Others.SendAsync("salaBorrada", nombre);
        }

        #endregion

    }
}

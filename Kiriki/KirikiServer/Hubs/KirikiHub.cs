using Microsoft.AspNetCore.SignalR;

namespace KirikiServer.Hubs
{
    public class KirikiHub : Hub
    {
        public async Task MostrarDado(String dado1, String dado2)
        {
            await Clients.All.SendAsync("MostrarDado", dado1, dado2);
        } 
    }
}

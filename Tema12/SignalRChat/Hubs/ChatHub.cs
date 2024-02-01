using Microsoft.AspNetCore.SignalR;
using Models;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario oMensajeUsuario)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("ReceiveMessage", oMensajeUsuario);
        }   
    }
}

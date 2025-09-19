using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs
{
    public class CounterHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // Broadcast to all clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

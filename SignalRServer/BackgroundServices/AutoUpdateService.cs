
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;

namespace SignalRServer.BackgroundServices
{
    public class AutoUpdateService : BackgroundService
    {
        private readonly IHubContext<CounterHub> _hubContext;

        public AutoUpdateService(IHubContext<CounterHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int counter = 1;
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.All.SendAsync(
                    "ReceiveMessage",
                    "Server",
                    $"Auto update #{counter++}",
                    stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

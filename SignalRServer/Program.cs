using SignalRServer.BackgroundServices;
using SignalRServer.Hubs;

namespace SignalRServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHostedService<AutoUpdateService>();

            builder.Services.AddSignalR();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.MapHub<CounterHub>("/counterHub");

            app.Run();
        }
    }
}

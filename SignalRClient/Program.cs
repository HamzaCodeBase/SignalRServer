using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient
{
    internal class Program
    {
        static async Task Main()
        {
            // Create connection to hub
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7116/counterHub")
                .Build();

            // Listen for messages from server
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"{user}: {message}");
            });

            await connection.StartAsync();
            Console.WriteLine("Connected to SignalR server!");

            await Task.Delay(-1);
            // Loop to send messages
            //while (true)
            //{
            //    //Console.Write("Enter your name: ");
            //    //var user = Console.ReadLine();
            //    //Console.Write("Enter message: ");
            //    //var msg = Console.ReadLine();

            //    //await connection.InvokeAsync("SendMessage", user, msg);
            //}
        }
    }
}

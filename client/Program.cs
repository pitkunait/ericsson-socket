using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using client.Services;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ISocketService socketService = new SocketService();
            Socket socket = null;

            while (!socketService.IsConnected(socket))
            {
                string host = Environment.GetEnvironmentVariable("HOST");
                string port = Environment.GetEnvironmentVariable("PORT");
                socket = await socketService.Connect(host, port);
                await socketService.ListenForever(socket);
                Console.WriteLine("\nDisconnected.");
                await Task.Delay(1000);
            }
        }
    }
}
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
                socket = await socketService.Connect("stdin-server", 8765);
                await socketService.ListenForever(socket);
                Console.WriteLine("\nDisconnected.");
                await Task.Delay(1000);
            }
        }
    }
}
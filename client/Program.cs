using System;
using System.Threading.Tasks;
using client.Services;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ISocketService socketService = new SocketService();
            var socket = await socketService.Connect("127.0.0.1", 8765);
            await socketService.ListenForever(socket);
        }
    }
}

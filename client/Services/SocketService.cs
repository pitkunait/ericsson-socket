using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    public class SocketService : ISocketService
    {
        public SocketService(ILogger<int> logger)
        {
            // logger.
        }
        public async Task<Socket> Connect(string host, int port)
        {
            Console.Write($"Trying to connect to {host}:{port}");
            while (true)
            {
                try
                { 
                    var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    var localEndPoint = new IPEndPoint(IPAddress.Parse(host), port);
                    Console.Write(".");
                    await client.ConnectAsync(localEndPoint);
                    Console.WriteLine("\nConnected.");
                    return client;
                }
                catch (Exception)
                {
                    await Task.Delay(1000);
                }
            }
        }

        public async Task ListenForever(Socket socket)
        {
            while (true)
            {
                var message = await Receive(socket);
                Console.Write(message);
            }
        }

        public  async Task<string> Receive(Socket socket)
        {
            var buffer = new ArraySegment<byte>(new byte[2048]);
            var result = await socket.ReceiveAsync(buffer, SocketFlags.None);
            return buffer.Array != null ? Encoding.ASCII.GetString(buffer.Array, 0, result) : "";
        }
    }

    public interface ILogger<T>
    {
    }
}
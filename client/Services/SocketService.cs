using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    public class SocketService : ISocketService
    {
        public async Task<Socket> Connect(string host, string port)
        {
            Console.Write($"\nTrying to connect to {host}:{port}");
            while (true)
            {
                try
                {
                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    var endpoint = new DnsEndPoint(host, int.Parse(port));
                    Console.Write(".");
                    await socket.ConnectAsync(endpoint);
                    Console.WriteLine("\nConnected.");
                    return socket;
                }
                catch (Exception)
                {
                    await Task.Delay(1000);
                }
            }
        }

        public bool IsConnected(Socket socket)
        {
            if (socket == null)
            {
                return false;
            }
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0) && socket.Connected;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public async Task ListenForever(Socket socket)
        {
            while (IsConnected(socket))
            {
                try
                {
                    var message = await Receive(socket);
                    Console.Write(message);
                }
                catch (SocketException)
                {
                    return;
                }
            }
        }

        public async Task<string> Receive(Socket socket)
        {
            var buffer = new ArraySegment<byte>(new byte[2048]);
            var result = await socket.ReceiveAsync(buffer, SocketFlags.None);
            return buffer.Array != null ? Encoding.ASCII.GetString(buffer.Array, 0, result) : "";
        }
    }
}
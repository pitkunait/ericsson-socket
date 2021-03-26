using System.Net.Sockets;
using System.Threading.Tasks;

namespace client.Services
{
    public interface ISocketService
    {
        Task<Socket> Connect(string host, int port);
        Task ListenForever(Socket socket);
        Task<string> Receive(Socket socket);
    }
}
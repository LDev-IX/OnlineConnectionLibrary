using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace OnlineConnectionLibrary
{
    public class Server
    {
        public Socket[] SocketArray;
        public Socket ServerSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public int Port = 0;
        public List<Byte[]> ReceiveBuffer;
        public void Start()
        {
            foreach(Socket fServerSocket in SocketArray)
            {
                fServerSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
                fServerSocket.Listen(0);
            }

            while (true)
            {
                foreach(Socket fServerSocket in SocketArray)
                {
                    if (fServerSocket.Connected)
                    {
                        Receive(fServerSocket);
                    }
                }
            }
        }

        public async void Receive(Socket aServerSocket)
        {
            await aServerSocket.ReceiveAsync(ReceiveBuffer[0], SocketFlags.None);
        }
    }
}

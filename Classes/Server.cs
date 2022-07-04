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
        }

        public async void ReceiveFromAll()
        {
            int bufferIndex = 0;
            while (true)
            {
                bufferIndex = 0;
                foreach (Socket fServerSocket in SocketArray)
                {
                    if (fServerSocket.Connected)
                    {
                        await fServerSocket.ReceiveAsync(ReceiveBuffer[bufferIndex], SocketFlags.None);
                    }
                    bufferIndex = bufferIndex + 1;
                }
            }
        }
    }
}

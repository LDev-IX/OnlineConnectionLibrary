using System.Net;
using System.Net.Sockets;

namespace OnlineConnectionLibrary
{
    public class Server
    {
        public int Port = 0;
        public int QueuedConnectionsLimit = 0;
        public Byte[] ReceivedData;
        public void startOneToOne()
        {
            Socket S = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            S.Bind(new IPEndPoint(IPAddress.Any, Port));
            S.Listen(QueuedConnectionsLimit);
            while (S.Connected)
            {
                S.Receive(ReceivedData);
            }
        }
    }
}

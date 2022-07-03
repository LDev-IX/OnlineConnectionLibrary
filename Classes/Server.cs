using System.Net;
using System.Net.Sockets;

namespace OnlineConnectionLibrary
{
    public class Server
    {
        public void startOneToOne(Byte[] aReceivedData, int aPort = 0, int aQueuedConnectionsLimit = 0)
        {
            Socket S = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            S.Bind(new IPEndPoint(IPAddress.Any, aPort));
            S.Listen(aQueuedConnectionsLimit);
            while (S.Connected)
            {
                S.Receive(aReceivedData);
            }
        }
    }
}

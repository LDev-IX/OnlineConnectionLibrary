using System.Net;
using System.Net.Sockets;

namespace OnlineConnectionLibrary
{
    public class Client
    {
        public void startOneToOne(EndPoint aEP, Byte[] aDataToSend)
        {
            Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            S.Connect(aEP);
            S.Send(aDataToSend);
        }
    }
}
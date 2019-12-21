using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MOVE.Shared
{
    public class SocketWriter
    {
        private Socket _clientsocket;

        public SocketWriter(Socket clientsocket)
        {
            _clientsocket = clientsocket;
        }

        public void WriteBufferedString(string s)
        {
            byte[] responseBuffer = Encoding.ASCII.GetBytes(s);
            _clientsocket.Send(responseBuffer);
        }
    }
}

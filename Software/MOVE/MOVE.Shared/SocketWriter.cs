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
        #region Variablen 
        private Socket _clientsocket;
        #endregion
        #region Konstruktor
        public SocketWriter(Socket clientsocket)
        {
            _clientsocket = clientsocket;
        }
        #endregion
        #region Methoden
        public void WriteBufferedString(string s)
        {
            byte[] responseBuffer = Encoding.ASCII.GetBytes(s);
            _clientsocket.Send(responseBuffer);
        }
    }
}
#endregion
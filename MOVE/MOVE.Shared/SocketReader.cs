using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MOVE.Shared
{
    public class SocketReader
    {
        #region Variablen
        private Socket _clientsocket;
        #endregion
        #region Konstruktor
        public SocketReader(Socket clientsocket)
        {
            _clientsocket = clientsocket;
        }
        #endregion
        #region Methoden
        public string ReadBufferedString()
        {
            byte[] receiveBuffer = new byte[1024];
            _clientsocket.Receive(receiveBuffer);

            string s = Encoding.ASCII.GetString(receiveBuffer);
            s = s.Substring(0, s.IndexOf('\0'));
            return s;
        }
    }
}
#endregion
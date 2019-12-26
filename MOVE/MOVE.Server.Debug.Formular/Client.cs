using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MOVE.Shared;

namespace MOVE.Server.Debug.Formular
{
    public class Client
    {
        #region Klasseninstanzvariablen
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Variablen
        private int _port;
        IPAddress _adr;
        IPEndPoint _ep;
        Socket _clientsocket;
        SocketReader _sr;
        SocketWriter _sw;
        #endregion
        #region Konstruktor
        public Client(int port, IPAddress adr)
        {
            _port = port;
            _adr = adr;
            _ep = new IPEndPoint(_adr, port);
            _clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _sr = new SocketReader(_clientsocket);
            _sw = new SocketWriter(_clientsocket);
        }
        #endregion
        #region Methoden
        public void Start()
        {
            try
            {
                _clientsocket.Connect(_ep);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }

        }
        public void Send(string text)
        {
            try
            {
                byte[] sendmessage = Encoding.ASCII.GetBytes(text);
                _clientsocket.Send(sendmessage);
            }
            catch (Exception ex)
            {

                elw.WriteErrorLog(ex.Message);
            }
        }

    }
}
#endregion
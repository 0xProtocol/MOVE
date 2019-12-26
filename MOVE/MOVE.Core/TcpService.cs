using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MOVE.Shared;

namespace MOVE.Core
{
    public class TcpService
    {
        #region Klasseninstanzvariablen
        ClientHandler _ch;
        IServiceLogger _servicelogger;
        ErrorLogWriter elw = new ErrorLogWriter();

        #endregion
        #region Variablen
        private int _port;
        IPAddress _adr;
        IPEndPoint _ep;
        Socket _serversocket;
        #endregion
        #region Konstruktor
        public TcpService(int port, IServiceLogger servicelogger, IPAddress adr)
        {
            try
            {
                _port = port;
                _servicelogger = servicelogger;
                _adr = adr;
                _ep = new IPEndPoint(_adr, _port);
                _serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serversocket.Bind(_ep);
                _ch = new ClientHandler(_serversocket, _servicelogger);

                ThreadStart ts = new ThreadStart(_ch.Acceptclients);
                Thread t = new Thread(ts);
                t.IsBackground = true;
                t.Start();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        #endregion
        #region Methoden
        public void Start()
        {
            try
            {
                _serversocket.Listen(20);
                _ch.Acceptclients();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
            
        }
    }
}
#endregion


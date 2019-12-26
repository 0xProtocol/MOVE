using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MOVE.Shared;

namespace MOVE.Core
{
   public class ClientHandler
    {
        #region Klasseninstanzvariablen
        Socket _serversocket;
        IServiceLogger _isl;
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Konstruktor
        public ClientHandler(Socket serversocket, IServiceLogger servicelogger)
        {
            _serversocket = serversocket;
            _isl = servicelogger;
        }
        #endregion
        #region Methoden
        public void Acceptclients()
        {
            while (true)
            {
                try
                {
                    _isl.LogServiceinformation("Waiting for connection...");
                    Socket clientsocket = _serversocket.Accept();
                    string text2 = "wird gesendet an: ";
                    _isl.LogServiceinformation(text2 + clientsocket.RemoteEndPoint);
                    SessionHandler sh = new SessionHandler(clientsocket, _isl);
                    sh.HandleSingleSession();

                    ThreadStart ts = new ThreadStart(sh.HandleSingleSession);
                    Thread t = new Thread(ts);
                    t.Name = clientsocket.RemoteEndPoint.ToString();
                    t.IsBackground = true;
                    t.Start();
                }
                catch (Exception ex)
                {
                    elw.WriteErrorLog(ex.ToString());
                }
                }
        }
    }
}
#endregion

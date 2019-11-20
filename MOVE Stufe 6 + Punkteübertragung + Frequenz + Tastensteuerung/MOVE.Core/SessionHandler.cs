    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MOVE.Shared;

namespace MOVE.Core
{
  public  class SessionHandler
    {
        Socket _clientsocket;
        IServiceLogger _isl;

        public SessionHandler(Socket clientSocket, IServiceLogger servicelogger)
        {
            _clientsocket = clientSocket;
            _isl = servicelogger;
        }

        public void HandleSingleSession()
        {
            while (true)
            {
                SocketReader sr = new SocketReader(_clientsocket);
                SocketWriter sw = new SocketWriter(_clientsocket);

                string request = sr.ReadBufferedString();
                MOVERequestHandler regh = new MOVERequestHandler(request, _isl);
                string req=regh.GetResponse();
                _isl.LogRequestInformation(req);
            }
        }


        public void Close()
        {
            _clientsocket.Shutdown(SocketShutdown.Both);
            _clientsocket.Close();
        }
    }
}


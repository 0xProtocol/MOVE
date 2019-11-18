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
        Socket _serversocket;
        IServiceLogger _isl;

        public ClientHandler(Socket serversocket, IServiceLogger servicelogger)
        {
            _serversocket = serversocket;
            _isl = servicelogger;
        }

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
                    FileStream fs = new FileStream("ErrorLog.txt", FileMode.Open);
                    StreamWriter writer = new StreamWriter(fs);

                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                        "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    writer.Close();
                }
                }
        }
    }
}

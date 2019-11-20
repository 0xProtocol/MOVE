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

namespace MOVE.Client.Debug.Formular
{
   public class Client
    {
        private int _port;
        IPAddress _adr;
        IPEndPoint _ep;
        Socket _clientsocket;
        SocketReader _sr;
        SocketWriter _sw;
        Thread t1;
        string _command;

        public Client(int port, IPAddress adr)
        {
            _port = port;
            _adr = adr;
            _ep = new IPEndPoint(_adr, port);
            _clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _sr = new SocketReader(_clientsocket);
            _sw = new SocketWriter(_clientsocket);
        }

        public void Start()
        {
            try
            {



                _clientsocket.Connect(_ep);
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

        public void Send(string text)
        {
            _command = text;

            if (_command == "")
            {
                Send(text);
            }
            else
            {
                try
                {
                    byte[] sendmessage = Encoding.ASCII.GetBytes(_command);
                    _clientsocket.Send(sendmessage);

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

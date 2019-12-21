using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOVE.Client.Debug.Formular
{
   public class NetworkDiscovery
    {
        public string output;
        public string networkips;
        public string serverAddr;
        int port = 11000;

        public void FillArpResults(TextBox discovery)
        {
            serverAddr = discovery.Text;
            string text = "hello";
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            for (int i = 1; i < 255; i++)
            {
                IPAddress fullserverAddr = IPAddress.Parse(serverAddr + i);
                IPEndPoint endPoint = new IPEndPoint(fullserverAddr, port);
                byte[] send_buffer = Encoding.ASCII.GetBytes(text);
                sock.SendTo(send_buffer, endPoint);
                Thread.Sleep(5);
            }
        }

        public string GetArpResult()
        {
            Process p = null;

            try
            {
                p = Process.Start(new ProcessStartInfo("arp", "-a")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                });
                output = p.StandardOutput.ReadToEnd();
                p.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("IPInfo: Error Retrieving 'arp -a' Results", ex);
            }
            finally
            {
                if (p != null)
                {
                    p.Close();
                }
            }
            return output;
        }

        public void QuickSearch(string text, ListBox listboxitems, ProgressBar progressbar)
        {
            progressbar.Value = 0;
            for (int i = 1; i < 255; i++)
            {
                progressbar.Maximum = 254;
                progressbar.Value += 1;
                if (output.Contains(text + i))
                {
                    listboxitems.Items.Add(text + i);
                }
            }
        }

        public void DeepSearch(string text, ListBox listboxitems, ProgressBar progressbar)
        {
            progressbar.Value = 0;
            for (int i = 1; i < 255; i++)
            {
                progressbar.Maximum = 254;
                progressbar.Value += 1;
                if (output.Contains(text + i))
                {
                    Ping myPing;
                    PingReply reply;
                    IPAddress addr;
                    IPHostEntry host;
                    string subnetn = i.ToString();
                    myPing = new Ping();
                    reply = myPing.Send(text + i, 90);

                    if (reply.Status == IPStatus.Success)
                    {
                        try
                        {
                            addr = IPAddress.Parse(text + subnetn);
                            host = Dns.GetHostEntry(addr);
                            networkips = text + i;
                            listboxitems.Items.Add(networkips + " " + host.HostName);
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        private string getIp()
        {
            string ip = string.Empty;
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ip = address.ToString();
                }
            }
            return ip;
        }

        public string getSubnet()
        {
            string ip = getIp();
            string[] split = ip.Split('.');
            return split[0] + "." + split[1] + "." + split[2] + "."; //ohne . normal
        }
    }
}

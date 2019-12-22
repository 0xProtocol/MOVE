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

namespace MOVE.Server.Debug.Formular
{
   public class NetworkDiscovery
    {
            public string output;
            public string networkips;
            public string serverAddr;
            int port = 11001;
            int sector1;
            int sector2;
            int sector3;
            int sector4;


            public void getSubnet(TextBox subnetmask)
            {
                string subnet = subnetmask.Text;
                string[] tmp = subnet.Split('.');

                sector1 = Convert.ToInt32(tmp[0]);
                sector2 = Convert.ToInt32(tmp[1]);
                sector3 = Convert.ToInt32(tmp[2]);
                sector4 = Convert.ToInt32(tmp[3]);
                sector1 = 255 - sector1;
                sector2 = 255 - sector2;
                sector3 = 255 - sector3;
                sector4 = 255 - sector4;
            }
            public void FillArpResults(TextBox discovery)
            {
                serverAddr = discovery.Text;
                string text = "hello";
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                if (sector1 == 0 && sector2 == 0 && sector3 == 0)
                {
                    for (int i = 1; i < sector4; i++)
                    {
                        string[] tmpserveraddr = serverAddr.Split('.');
                        string serveraddr24 = tmpserveraddr[0] + '.' + tmpserveraddr[1] + '.' + tmpserveraddr[2] + '.';
                        IPAddress fullserverAddr = IPAddress.Parse(serveraddr24 + i);
                        IPEndPoint endPoint = new IPEndPoint(fullserverAddr, port);
                        byte[] send_buffer = Encoding.ASCII.GetBytes(text);
                        sock.SendTo(send_buffer, endPoint);
                        Thread.Sleep(5);
                    }
                }
                else if (sector1 == 0 && sector2 == 0)
                {
                    for (int j = 0; j < sector3; j++)
                    {


                        for (int i = 1; i < sector4; i++)
                        {
                            string[] tmpserveraddr = serverAddr.Split('.');
                            string serveraddr16 = tmpserveraddr[0] + '.' + tmpserveraddr[1] + '.';
                            IPAddress fullserverAddr = IPAddress.Parse(serveraddr16 + j + '.' + i);
                            IPEndPoint endPoint = new IPEndPoint(fullserverAddr, port);
                            byte[] send_buffer = Encoding.ASCII.GetBytes(text);
                            sock.SendTo(send_buffer, endPoint);
                            Thread.Sleep(5);
                        }
                    }
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
                string[] tmp = text.Split('.');
                progressbar.Value = 0;
                if (sector1 == 0 && sector2 == 0 && sector3 == 0)
                {
                    string splittedipadd = tmp[0] + '.' + tmp[1] + '.' + tmp[2] + '.';
                    for (int i = 1; i < sector4; i++)
                    {
                        progressbar.Maximum = 254;
                        progressbar.Value += 1;
                        if (output.Contains(splittedipadd + i))
                        {
                            listboxitems.Items.Add(splittedipadd + i);
                        }
                    }
                }
                else if (sector1 == 0 && sector2 == 0)
                {
                    progressbar.Value = 0;
                    string splittedipadd = tmp[0] + '.' + tmp[1] + '.';
                    for (int j = 0; j < sector3; j++)
                    {
                        progressbar.Maximum = 254;
                        progressbar.Value += 1;
                        for (int i = 1; i < sector4; i++)
                        {

                            if (output.Contains(splittedipadd + j + '.' + i))
                            {
                                listboxitems.Items.Add(splittedipadd + j + '.' + i);
                            }
                        }
                    }
                }
            }

            public void DeepSearch(string text, ListBox listboxitems, ProgressBar progressbar)
            {
                string[] tmp = text.Split('.');

                progressbar.Value = 0;

                if (sector1 == 0 && sector2 == 0 && sector3 == 0)
                {
                    string splittedipadd = tmp[0] + '.' + tmp[1] + '.' + tmp[2] + '.';
                    for (int i = 1; i < sector4; i++)
                    {
                        progressbar.Maximum = 254;
                        progressbar.Value += 1;
                        if (output.Contains(splittedipadd + i))
                        {
                            Ping myPing;
                            PingReply reply;
                            IPAddress addr;
                            IPHostEntry host;
                            myPing = new Ping();
                            reply = myPing.Send(splittedipadd + i, 90);

                            if (reply.Status == IPStatus.Success)
                            {
                                try
                                {
                                    addr = IPAddress.Parse(splittedipadd + i);
                                    host = Dns.GetHostEntry(addr);
                                    networkips = splittedipadd + i;
                                    listboxitems.Items.Add(networkips + " " + host.HostName);
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
                else if (sector1 == 0 && sector2 == 0)
                {
                    progressbar.Value = 0;
                    string splittedipadd = tmp[0] + '.' + tmp[1] + '.';
                    for (int j = 0; j < sector3; j++)
                    {
                        progressbar.Maximum = 254;
                        progressbar.Value += 1;
                        for (int i = 1; i < sector4; i++)
                        {

                            if (output.Contains(splittedipadd + j + '.' + i))
                            {
                                Ping myPing;
                                PingReply reply;
                                IPAddress addr;
                                IPHostEntry host;
                                myPing = new Ping();
                                reply = myPing.Send(splittedipadd + j + '.' + i, 90);

                                if (reply.Status == IPStatus.Success)
                                {
                                    try
                                    {
                                        addr = IPAddress.Parse(splittedipadd + j + '.' + i);
                                        host = Dns.GetHostEntry(addr);
                                        networkips = splittedipadd + j + '.' + i;
                                        listboxitems.Items.Add(networkips + " " + host.HostName);
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }

            public void getip(ListBox lst)
            {
                NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface Interface in Interfaces)
                {
                    if (Interface.NetworkInterfaceType == NetworkInterfaceType.Loopback) continue;
                    Console.WriteLine(Interface.Description);
                    UnicastIPAddressInformationCollection UnicastIPInfoCol = Interface.GetIPProperties().UnicastAddresses;
                    foreach (UnicastIPAddressInformation UnicatIPInfo in UnicastIPInfoCol)
                    {
                        string desc = Interface.Description;
                        string ipaddress = Convert.ToString(UnicatIPInfo.Address);
                        string subnetmsk = Convert.ToString(UnicatIPInfo.IPv4Mask);
                        if (ipaddress.StartsWith("169") == false)
                        {
                            if (subnetmsk.StartsWith("0") == false)
                            {
                                if (desc.StartsWith("VirtualBox") == false)
                                {
                                    lst.Items.Add(desc);
                                    lst.Items.Add(ipaddress);
                                    lst.Items.Add(subnetmsk);
                                }
                            }
                        }
                    }
                }
            }
        }
    }


using MOVE.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOVE.Client.Debug.Formular
{
   public class NetworkDiscovery
    {

        #region Import
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);
      

        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Variablen
        List<IPAddress> ipAddressList = new List<IPAddress>();
        public string output;
        public string networkips;
        public string serverAddr;
        public string firstvalue;
        int sector1;
        int sector2;
        int sector3;
        int sector4;
        public bool isworking;

        #endregion
        #region Methoden
        public void getip(ListBox lst)
        {
            NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface Interface in Interfaces)
            {
                if (Interface.NetworkInterfaceType == NetworkInterfaceType.Loopback) continue;
                UnicastIPAddressInformationCollection UnicastIPInfoCol = Interface.GetIPProperties().UnicastAddresses;
                foreach (UnicastIPAddressInformation UnicatIPInfo in UnicastIPInfoCol)
                {
                    string desc = Interface.Description;
                    string ipaddress = Convert.ToString(UnicatIPInfo.Address);
                    string subnetmsk = Convert.ToString(UnicatIPInfo.IPv4Mask);
                    if (ipaddress.StartsWith("169")) continue;
                    if (subnetmsk.StartsWith("0")) continue;
                    if (desc.StartsWith("VirtualBox")) continue;
                    lst.Items.Add(desc + " | " + ipaddress + " | " + subnetmsk);
                    firstvalue = (desc + "|" + ipaddress + "|" + subnetmsk);
                }
            }
        }

        public void getSubnet(TextBox subnetmask)
        {
            isworking = true;
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

        public void FillArpResults(TextBox discovery, ListBox lst)
        {
            serverAddr = discovery.Text;

            if (sector1 == 0 && sector2 == 0 && sector3 == 0)
            {
                ipAddressList.Clear();
                for (int i = 1; i < sector4; i++)
                {
                    string[] tmpserveraddr = serverAddr.Split('.');
                    string serveraddr24 = tmpserveraddr[0] + '.' + tmpserveraddr[1] + '.' + tmpserveraddr[2] + '.';
                    ipAddressList.Add(IPAddress.Parse(serveraddr24 + i));
                }
            }
            else if (sector1 == 0 && sector2 == 0)
            {
                ipAddressList.Clear();
                for (int j = 0; j < sector3; j++)
                {
                    for (int i = 1; i < sector4; i++)
                    {
                        string[] tmpserveraddr = serverAddr.Split('.');
                        string serveraddr16 = tmpserveraddr[0] + '.' + tmpserveraddr[1] + '.';
                        ipAddressList.Add(IPAddress.Parse(serveraddr16 + j + "." + i));
                    }
                }
            }
        }
        #endregion
        #region QuickSearch
        public void QuickSearch(ListBox lst, ProgressBar pb)
        {
            pb.Value = 0;
            foreach (IPAddress ip in ipAddressList)
            {
                pb.Maximum = ipAddressList.Count;
                pb.Value += 1;
                Thread thread = new Thread(() => SendArpRequestQuickSearch(ip, lst));
                thread.Start();
                Thread.Sleep(25);

            }
            isworking = false;
        }
        private void SendArpRequestQuickSearch(IPAddress dst, ListBox lst)
        {
            byte[] macAddr = new byte[6];
            uint macAddrLen = (uint)macAddr.Length;
            int uintAddress = BitConverter.ToInt32(dst.GetAddressBytes(), 0);
            if (SendARP(uintAddress, 0, macAddr, ref macAddrLen) == 0)
            {
                lst.Items.Add(dst.ToString());
            }
        }
        #endregion
        #region DeepSearch
        public void DeepSearch(ListBox lst, ProgressBar pb)
        {
            pb.Value = 0;
            foreach (IPAddress ip in ipAddressList)
            {
                pb.Maximum = ipAddressList.Count;
                pb.Value += 1;
                Thread thread = new Thread(() => SendArpRequestDeepSearch(ip, lst));
                thread.Start();
                Thread.Sleep(25);
            }
            isworking = false;
        }

        private void SendArpRequestDeepSearch(IPAddress dst, ListBox lst)
        {
            byte[] macAddr = new byte[6];
            uint macAddrLen = (uint)macAddr.Length;
            int uintAddress = BitConverter.ToInt32(dst.GetAddressBytes(), 0);

            if (SendARP(uintAddress, 0, macAddr, ref macAddrLen) == 0)
            {
                Ping myPing;
                PingReply reply;
                IPAddress addr;
                IPHostEntry host;
                myPing = new Ping();
                reply = myPing.Send(dst.ToString(), 90);

                if (reply.Status == IPStatus.Success)
                {
                    try
                    {
                        addr = IPAddress.Parse((dst.ToString()));
                        host = Dns.GetHostEntry(addr);
                        networkips = (dst.ToString());
                        int length = macAddr.Length;
                        string macAddress = BitConverter.ToString(macAddr, 0, length);
                        lst.Items.Add(networkips + " | " + host.HostName + " | " + macAddress);
                    }
                    catch(Exception ex)
                    {
                        elw.WriteErrorLog(ex.ToString());
                    }
                }
            }
        }

    }
}
#endregion

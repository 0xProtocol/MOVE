using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVE.Server.Debug.Formular
{
    public class FirewallSettings
    {
        #region FirewallOn
        public void FirewallOn()
        {
            System.Diagnostics.ProcessStartInfo netshprocess = new System.Diagnostics.ProcessStartInfo();
            netshprocess.FileName = "netsh.exe";

            string temp = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            netshprocess.Verb = "runas";
            netshprocess.Arguments = "Advfirewall set allprofiles state on";
            netshprocess.UseShellExecute = true;
            try
            {
                System.Diagnostics.Process.Start(netshprocess).WaitForExit();
            }
            catch (Exception)
            {
                //logging
            }
        }
            #endregion
            #region FirewallOff
            public void FirewallOff()
        {
            System.Diagnostics.ProcessStartInfo netshprocess = new System.Diagnostics.ProcessStartInfo();
            netshprocess.FileName = "netsh.exe";

            string temp = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            netshprocess.Verb = "runas";
            netshprocess.Arguments = "Advfirewall set allprofiles state off";
            netshprocess.UseShellExecute = true;
            try
            {
                System.Diagnostics.Process.Start(netshprocess).WaitForExit();
            }
            catch (Exception)
            {
                //logging
            }
        }
    }
}
#endregion

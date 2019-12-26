using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVE.Client.Debug.Formular
{
   public class FirewallSettings
    {
        #region FirewallOn
        public void FirewallOn()
        {
            Process proc = new Process();
            string top = "netsh.exe";
            proc.StartInfo.Arguments = "Advfirewall set allprofiles state on";
            proc.StartInfo.FileName = top;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();
        }
        #endregion
        #region FirewallOff
        public void FirewallOff()
        {
            Process proc = new Process();
            string top = "netsh.exe";
            proc.StartInfo.Arguments = "Advfirewall set allprofiles state off";
            proc.StartInfo.FileName = top;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();
        }
    }
}
#endregion

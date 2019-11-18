using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOVE.Server.Debug.Formular
{
    public partial class ServerSettings : Form
    {
        Thread t1;
        NetworkDiscovery nd = new NetworkDiscovery();
        FirewallSettings fs = new FirewallSettings();

        public ServerSettings()
        {
            InitializeComponent();
            string emp = ConfigurationManager.AppSettings["tuning"];
            tbempfindlichkeit.Value = Convert.ToInt32(emp);
            string glät = ConfigurationManager.AppSettings["glättung"];
            tbGlättung.Value = Convert.ToInt32(glät);
        }

        private void tbempfindlichkeit_Scroll(object sender, EventArgs e)
        {

        }

        private void ServerSettings_Load(object sender, EventArgs e)
        {
            tbx_Discovery.Text = nd.getSubnet();
        }

        private void btn_Discover_Click(object sender, EventArgs e)
        {
            nd.FillArpResults(tbx_Discovery);
            nd.GetArpResult();
            if (cbQuickSearch.Checked && cbDeepSearch.Checked)
            {
                

            }
            else if (cbQuickSearch.Checked == true)
            {
                ThreadStart start = delegate { nd.QuickSearch(tbx_Discovery.Text, lsb_discover, pbnetwork); };
                t1 = new Thread(new ThreadStart(start));
                t1.Start();

            }
            else if (cbDeepSearch.Checked == true)
            {
                ThreadStart start = delegate { nd.DeepSearch(tbx_Discovery.Text, lsb_discover, pbnetwork); };
                t1 = new Thread(new ThreadStart(start));
                t1.Start();
            }
        }

        private void btn_ActivateFirewall_Click(object sender, EventArgs e)
        {
            fs.FirewallOn();
        }

        private void btn_deactivatefirewall_Click(object sender, EventArgs e)
        {
            fs.FirewallOff();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string split = lsb_discover.GetItemText(lsb_discover.SelectedItem);
            string[] splitzeile = split.Split(' ');
            tbx_IPClient.Text = splitzeile[0];
        }

        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string split = lsb_discover.GetItemText(lsb_discover.SelectedItem);
            string[] splitzeile = split.Split(' ');
            tbx_IPServer.Text = splitzeile[0];
        }

        private void tbGlättung_Scroll(object sender, EventArgs e)
        {

        }

        private void tcGameSettings_Click(object sender, EventArgs e)
        {

        }
    }
}

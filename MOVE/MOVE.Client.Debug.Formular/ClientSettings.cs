using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MOVE.Client.Debug.Formular
{
    public partial class ClientSettings : Form
    {
        Thread t1;
        NetworkDiscovery nd = new NetworkDiscovery();
        FirewallSettings fs = new FirewallSettings();
        public ClientSettings()
        {
            InitializeComponent();
            string emp = ConfigurationManager.AppSettings["empfindlichkeit"];
            tbEmpfindlichkeit.Value = Convert.ToInt32(emp);
            string glät = ConfigurationManager.AppSettings["glättung"];
            tbGlättungsstufe.Value = Convert.ToInt32(glät);
        }

        public int FrequenzSetting()
        {
            if (rBBass.Checked == true)
            {
                return 1;
            }
            if (rBBartion.Checked == true)
            {
                return 2;
            }
            if (rBTenor.Checked == true)
            {
                return 3;
            }
            if (rBMaenneralt.Checked == true)
            {
                return 4;
            }
            if (rBMezzosopran.Checked == true)
            {
                return 5;
            }
            if (rBSopran.Checked == true)
            {
                return 6;
            }
            if (rBPfeifen.Checked == true)
            {
                return 7;
            }
            return 0;
        }

        private void ClientSettings_Load(object sender, EventArgs e)
        {
            tbx_Discovery.Text = nd.getSubnet();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tbEmpfindlichkeit_Scroll(object sender, EventArgs e)
        {

        }

        private void tbGlättungsstufe_Scroll(object sender, EventArgs e)
        {

        }

        private void btn_Discover_Click(object sender, EventArgs e)
        {
            nd.FillArpResults(tbx_Discovery);
            nd.GetArpResult();
            if (cbQuickSearch.Checked && cbDeepSearch.Checked)
            {
                /*/
            ThreadStart start = delegate { nd.QuickSearch(tbx_Discovery.Text, lsb_discover, pbnetwork); };
                t1 = new Thread(new ThreadStart(start));
                t1.Start();

                ThreadStart start2 = delegate { nd.DeepSearch(tbx_Discovery.Text, lsb_discover, pbnetwork); };
                t2 = new Thread(new ThreadStart(start2));
                t2.Start();
                /*/

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

        private void pbnetwork_Click(object sender, EventArgs e)
        {

        }

        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_deactivatefirewall_Click(object sender, EventArgs e)
        {
            fs.FirewallOff();
        }

        private void btn_ActivateFirewall_Click(object sender, EventArgs e)
        {
            fs.FirewallOn();
        }

        private void lsb_discover_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string split = lsb_discover.GetItemText(lsb_discover.SelectedItem);
            string[] splitzeile = split.Split(' ');
            tbx_IPClient.Text = splitzeile[0];
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string split = lsb_discover.GetItemText(lsb_discover.SelectedItem);
            string[] splitzeile = split.Split(' ');
            tbx_IPServer.Text = splitzeile[0];
        }

        private void iPConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cbDeepSearch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tc_Click(object sender, EventArgs e)
        {

        }

        private void cbQuickSearch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Discovery_TextChanged(object sender, EventArgs e)
        {

        }

        private void tcsettings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rBBass_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rBBartion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rBTenor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rBMaenneralt_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tcGameSettingsFreq_Click(object sender, EventArgs e)
        {

        }

        private void rBSopran_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rBPfeifen_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

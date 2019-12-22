using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
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
        SpeechRecognitionEngine _recognizersettings = new SpeechRecognitionEngine();

        public ServerSettings()
        {
            InitializeComponent();
            string emp = ConfigurationManager.AppSettings["empfindlichkeit"];
            tbempfindlichkeit.Value = Convert.ToInt32(emp);
            string glät = ConfigurationManager.AppSettings["glättung"];
            tbGlättung.Value = Convert.ToInt32(glät);
            ServerSettingsListener();
            this.Focus();
        }
        public void ServerSettingsListener()
        {
            _recognizersettings.SetInputToDefaultAudioDevice();
            _recognizersettings.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"Server.txt")))));
            _recognizersettings.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizersettings.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
           
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "exit")
            {
                CloseWindow();
            }
        }

        public void CloseWindow()
        {
            this.Hide();

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

        public void SetBass()
        {
            rBBass.Checked = true;
        }
        public void SetBariton()
        {
            rBBartion.Checked = true;
        }
        public void SetTenor()
        {
            rBTenor.Checked = true;
        }
        public void SetMänneralt()
        {
            rBMaenneralt.Checked = true;
        }
        public void SetMezzosopran()
        {
            rBMezzosopran.Checked = true;
        }
        public void SetSopran()
        {
            rBSopran.Checked = true;
        }
        public void SetPfeifen()
        {
            rBPfeifen.Checked = true;
        }


        private void tbempfindlichkeit_Scroll(object sender, EventArgs e)
        {

        }

        private void ServerSettings_Load(object sender, EventArgs e)
        {
            nd.getip(lsb_discover);
            string ip = (Convert.ToString(lsb_discover.Items[1]));
            Text = ip.ToString();
            string subnet = (Convert.ToString(lsb_discover.Items[2]));
            Text = subnet.ToString();
            tbx_Discovery.Text = ip;
            textBox1.Text = subnet;
        }
        public void Discover(string value)
        {
            nd.getSubnet(textBox1);
            lsb_discover.Items.Clear();
            nd.FillArpResults(tbx_Discovery);
            nd.GetArpResult();
            if (cbQuickSearch.Checked && cbDeepSearch.Checked)
            {

            }
            if (value == "0")
            {
                ThreadStart start = delegate { nd.QuickSearch(tbx_Discovery.Text, lsb_discover, pbnetwork); };
                t1 = new Thread(new ThreadStart(start));
                t1.Start();

            }
            else if (value == "1")
            {
                ThreadStart start = delegate { nd.DeepSearch(tbx_Discovery.Text, lsb_discover, pbnetwork); };
                t1 = new Thread(new ThreadStart(start));
                t1.Start();
            }
        }
      
        private void btn_Discover_Click(object sender, EventArgs e)
        {
            if (cbQuickSearch.Checked == true)
            {
                ThreadStart start = delegate {Discover("0"); };
                t1 = new Thread(new ThreadStart(start));
                t1.Start();
            }
            if (cbDeepSearch.Checked == true)
            {
                ThreadStart start = delegate { Discover("1"); };
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

        private void tcIPConfiguration_Click(object sender, EventArgs e)
        {

        }

        private void rBBartion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tcNetworkDicovery_Click(object sender, EventArgs e)
        {

        }

        string get;
        private void ServerSettings_Activated(object sender, EventArgs e)
        {
            get = "true";
        }

        public string Get()
        {
            return get;
        }

        private void ServerSettings_Deactivate(object sender, EventArgs e)
        {
            get = "false";
        }
    }
}

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
        int counter;
        public ServerSettings()
        {
            InitializeComponent();
            string emp = ConfigurationManager.AppSettings["empfindlichkeit"];
            tbempfindlichkeit.Value = Convert.ToInt32(emp);
            string glät = ConfigurationManager.AppSettings["glättung"];
            tbGlättung.Value = Convert.ToInt32(glät);
            this.Focus();
        }
        public void ServerSettingsListener()
        {
            _recognizersettings.SetInputToDefaultAudioDevice();
            _recognizersettings.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandsserversettings.txt")))));
            _recognizersettings.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSettings_SpeechRecognized);
            _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void StartthisListener()
        {
            if (counter < 1)
            {
                ServerSettingsListener();
                counter++;
            }
            else
            {
                ActivateServerListener();
            }
        }

        public void DefaultSettings_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                if (speech == "Empfindlichkeit eins")
                {
                    tbempfindlichkeit.Value = 1;
                }
                if (speech == "Empfindlichkeit zwei")
                {
                    tbempfindlichkeit.Value = 2;
                }
                if (speech == "Empfindlichkeit drei")
                {
                    tbempfindlichkeit.Value = 3;
                }
                if (speech == "Glättungsstufe eins")
                {
                    tbGlättung.Value = 1;
                }
                if (speech == "Glättungsstufe zwei")
                {
                    tbGlättung.Value = 2;
                }
                if (speech == "Glättungsstufe drei")
                {
                    tbGlättung.Value = 3;
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                if (speech == "Bass")
                {
                    rBBass.Checked = true;
                }
                if (speech == "Bariton")
                {
                    rBBartion.Checked = true;
                }
                if (speech == "Tenor")
                {
                    rBTenor.Checked = true;
                }
                if (speech == "Männeralt")
                {
                    rBMaenneralt.Checked = true;
                }
                if (speech == "Mezzosopran")
                {
                    rBMezzosopran.Checked = true;
                }
                if (speech == "Sopran")
                {
                    rBSopran.Checked = true;
                }
                if (speech == "Pfeifen")
                {
                    rBPfeifen.Checked = true;
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[3])
            {
                if (speech == "Starte Deepsearch")
                {
                    Discover("1");
                }
                if (speech == "Starte Quicksearch")
                {
                    Discover("0");
                }
                if (speech == "Activate Firewall")
                {
                    ActivateFirewall();
                }
                if (speech == "Deactivate Firewall")
                {
                    DeactivateFirewall();
                }
            }
            if (speech=="Game Settings")
            {
                tabControl1.SelectedIndex = 0;
            }
            if (speech == "Frequenztuning")
            {
                tabControl1.SelectedIndex = 1;
            }
            if (speech == "IP Konfiguration")
            {
                tabControl1.SelectedIndex = 2;
            }
            if (speech == "Network Discovery")
            {
                tabControl1.SelectedIndex = 3;
            }

            if (speech == "exit")
                 {
                CloseWindow();
                  }
        }


        private void ActivateFirewall()
        {
            fs.FirewallOn();
        }

        private void DeactivateFirewall()
        {
            fs.FirewallOff();
        }
        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
           
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
            
            lsb_networkadapter.Items.Clear();
            nd.getip(lsb_networkadapter);
            string[] splitzeile = nd.firstvalue.Split('|');
            tbx_Discovery.Text = splitzeile[1];
            textBox1.Text = splitzeile[2];
            
        }
        public void Discover(string value)
        {
            nd.getSubnet(textBox1);
            lsb_discover.Items.Clear();
            nd.FillArpResults(tbx_Discovery,lsb_discover);
            if (cbQuickSearch.Checked && cbDeepSearch.Checked)
            {

            }
            if (value == "0")
            {
                ThreadStart start = delegate { nd.QuickSearch(lsb_discover,pbnetwork); };
                t1 = new Thread(new ThreadStart(start));
                t1.Start();

            }
            else if (value == "1")
            {
                ThreadStart start = delegate { nd.DeepSearch(lsb_discover, pbnetwork); };
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
            string[] seperator = { "| " };
            string[] splitzeile = split.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            tbx_IPClient.Text = splitzeile[0];
        }

        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string split = lsb_discover.GetItemText(lsb_discover.SelectedItem);
            string[] seperator = { "| " };
            string[] splitzeile = split.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
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
        public void ActivateServerListener()
        {
            try
            {
                _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }
        public void CancelServerListener()
        {
            try
            {
                _recognizersettings.RecognizeAsyncCancel();
            }
            catch (Exception ex)
            {

            }
        }
        private void ServerSettings_Activated(object sender, EventArgs e)
        {
            StartthisListener();

        }


        private void ServerSettings_Deactivate(object sender, EventArgs e)
        {
            CancelServerListener();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pbnetwork_Click(object sender, EventArgs e)
        {

        }

        private void lsb_networkadapter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsb_networkadapter_DragOver(object sender, DragEventArgs e)
        {
          
        }

        private void lsb_networkadapter_Click(object sender, EventArgs e)
        {
            cms.Items[0].Visible = false; cms.Items[1].Visible = false;
            cms.Items[2].Visible = true;
        }

        private void lsb_discover_Click(object sender, EventArgs e)
        {
            cms.Items[0].Visible = true; cms.Items[1].Visible = true;
            cms.Items[2].Visible = false;
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void iPToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void subnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
              
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string split = lsb_networkadapter.GetItemText(lsb_networkadapter.SelectedItem);
            string[] seperator = { "| " };
            string[] splitzeile = split.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            tbx_Discovery.Text = splitzeile[1];
            textBox1.Text = splitzeile[2];
        }

        private void TcNetworkDicovery_Click_1(object sender, EventArgs e)
        {

        }
    }
}

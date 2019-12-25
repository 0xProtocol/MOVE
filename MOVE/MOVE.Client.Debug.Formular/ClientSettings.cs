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
using System.Speech.Recognition;
using System.IO;
using System.Speech.Synthesis;

namespace MOVE.Client.Debug.Formular
{
    public partial class ClientSettings : Form
    {
        Thread t1;
        NetworkDiscovery nd = new NetworkDiscovery();
        FirewallSettings fs = new FirewallSettings();
        SpeechRecognitionEngine _recognizersettings = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();
        int counter;
        public ClientSettings()
        {
            InitializeComponent();
            string emp = ConfigurationManager.AppSettings["empfindlichkeit"];
            tbEmpfindlichkeit.Value = Convert.ToInt32(emp);
            string glät = ConfigurationManager.AppSettings["glättung"];
            tbGlättungsstufe.Value = Convert.ToInt32(glät);
        }

        public void ClientSettingsListener()
        {
            _recognizersettings.SetInputToDefaultAudioDevice();
            _recognizersettings.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandsclientsettings.txt")))));
            _recognizersettings.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSettings_SpeechRecognized);
            _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
        }
        private void StartthisListener()
        {
            if (counter < 1)
            {
                ClientSettingsListener();
                counter++;
            }
            else
            {
                ActivateClientListener();
            }
        }
        public void DefaultSettings_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (tcsettings.SelectedTab == tcsettings.TabPages[0])
            {
                if (speech == "Empfindlichkeit eins")
                {
                    tbEmpfindlichkeit.Value = 1;
                }
                if (speech == "Empfindlichkeit zwei")
                {
                    tbEmpfindlichkeit.Value = 2;
                }
                if (speech == "Empfindlichkeit drei")
                {
                    tbEmpfindlichkeit.Value = 3;
                }
                if (speech == "Glättungsstufe eins")
                {
                    tbGlättungsstufe.Value = 1;
                }
                if (speech == "Glättungsstufe zwei")
                {
                    tbGlättungsstufe.Value = 2;
                }
                if (speech == "Glättungsstufe drei")
                {
                    tbGlättungsstufe.Value = 3;
                }
            }
            if (tcsettings.SelectedTab == tcsettings.TabPages[1])
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
            if (tcsettings.SelectedTab == tcsettings.TabPages[3])
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
                if (speech == "Der erste Adapter")
                {
                    SelectFirstAdapter();
                }
                if (speech == "Der zweite Adapter")
                {
                    SelectSecondAdapter();
                }
                if (speech == "Der dritte Adapter")
                {
                    SelectThirdAdapter();

                }
                if (speech == "Der vierte Adapter")
                {
                    SelectFourthAdapter();
                }
                if (speech == "Einen Adapter weiter")
                {
                    try
                    {
                        lsb_networkadapter.SelectedIndex++;
                    }
                    catch (Exception)
                    {

                    }
                }
                if (speech == "Die erste Adresse")
                {
                    SelectFirstAddress();
                }
                if (speech == "Die zweite Adresse")
                {
                    SelectSecondAddress();
                }
                if (speech == "Die dritte Adresse")
                {
                    SelectThirdAddress();
                }
                if (speech == "Die vierte Adresse")
                {
                    SelectFourhtAddress();
                }
                if (speech == "Die fünfte Adresse")
                {
                    SelectFifthAddress();
                }
                if (speech == "Eine Adresse weiter")
                {
                    try
                    {
                        lsb_discover.SelectedIndex++;
                    }
                    catch (Exception)
                    {

                    }
                }
                if (speech == "Fünf Adressen weiter")
                {
                    try
                    {
                        lsb_discover.SelectedIndex += 5;
                    }
                    catch (Exception)
                    {

                    }
                }
                if (speech == "Adresse für Server")
                {
                    GiveSelectedIPinIPConfigurationServer();
                }
                if (speech == "Adresse für Client")
                {
                    GiveSelectedIPinIPConfigurationClient();
                }
            }
            if (speech == "Game Settings")
            {
                tcsettings.SelectedIndex = 0;
            }
            if (speech == "Frequenztuning")
            {
                tcsettings.SelectedIndex = 1;
            }
            if (speech == "IP Konfiguration")
            {
                tcsettings.SelectedIndex = 2;
            }
            if (speech == "Network Discovery")
            {
                tcsettings.SelectedIndex = 3;
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

        private void CloseWindow()
        {
            this.Hide();
        }

        private void SelectFirstAdapter()
        {
            try
            {

            lsb_networkadapter.SelectedIndex = 0;
            lsb_networkadapter.Focus();
            GiveSelectedAdapterinTextBox();
            }
            catch (Exception)
            {

            }
        }

        private void SelectSecondAdapter()
        {
            try
            {
                lsb_networkadapter.SelectedIndex = 1;
                lsb_networkadapter.Focus();
                GiveSelectedAdapterinTextBox();
            }
            catch (Exception)
            {

            }

        }
        private void SelectThirdAdapter()
        {
            try
            {
                lsb_networkadapter.SelectedIndex = 2;
                lsb_networkadapter.Focus();
                GiveSelectedAdapterinTextBox();
            }
            catch (Exception)
            {

               
            }
        }
        private void SelectFourthAdapter()
        {
            try
            {
                lsb_networkadapter.SelectedIndex = 3;
                lsb_networkadapter.Focus();
                GiveSelectedAdapterinTextBox();
            }
            catch (Exception)
            {

            }
        }

        private void SelectFirstAddress()
        {
            try
            {
                lsb_discover.SelectedIndex = 0;
                lsb_discover.Focus();
                ShowMessageBox();
            }
            catch (Exception)
            {

            }
        }
        private void SelectSecondAddress()
        {
            try
            {
                lsb_discover.SelectedIndex = 1;
                lsb_discover.Focus();
                ShowMessageBox();
            }
            catch (Exception)
            {

            }
        }
        private void SelectThirdAddress()
        {
            try
            {
                lsb_discover.SelectedIndex = 2;
                lsb_discover.Focus();
                ShowMessageBox();
            }
            catch (Exception)
            {

            }
        }
        private void SelectFourhtAddress()
        {
            try
            {
                lsb_discover.SelectedIndex = 3;
                lsb_discover.Focus();
                ShowMessageBox();
            }
            catch (Exception)
            {

            }
        }
        private void SelectFifthAddress()
        {
            try
            {
                lsb_discover.SelectedIndex = 4;
                lsb_discover.Focus();
                ShowMessageBox();
            }
            catch (Exception)
            {

            }
        }

        private void ShowMessageBox()
        {
            com.SpeakAsync("Wollen Sie die Adresse dem Server oder dem Cleient zuweisen?");
        }

        private void GiveSelectedAdapterinTextBox()
        {
            string split = lsb_networkadapter.GetItemText(lsb_networkadapter.SelectedItem);
            string[] seperator = { "| " };
            string[] splitzeile = split.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            tbx_Discovery.Text = splitzeile[1];
            textBox1.Text = splitzeile[2];
        }

        private void GiveSelectedIPinIPConfigurationClient()
        {
            string split = lsb_discover.GetItemText(lsb_discover.SelectedItem);
            string[] seperator = { "| " };
            string[] splitzeile = split.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            tbx_IPClient.Text = splitzeile[0];
        }
        private void GiveSelectedIPinIPConfigurationServer()
        {
            string split = lsb_discover.GetItemText(lsb_discover.SelectedItem);
            string[] seperator = { "| " };
            string[] splitzeile = split.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            tbx_IPServer.Text = splitzeile[0];
        }
        private void ActivateClientListener()
        {
            try
            {
                _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }

        private void CancelClientListener()
        {
            try
            {
                _recognizersettings.RecognizeAsyncCancel();
            }
            catch (Exception ex)
            {

            }
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
            
            lsb_networkadapter.Items.Clear();
            nd.getip(lsb_networkadapter);
            string[] splitzeile = nd.firstvalue.Split('|');
            tbx_Discovery.Text = splitzeile[1];
            textBox1.Text = splitzeile[2];
            
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

        public void Discover(string value)
        {
            nd.getSubnet(textBox1);
            lsb_discover.Items.Clear();
            nd.FillArpResults(tbx_Discovery, lsb_discover);
            if (cbQuickSearch.Checked && cbDeepSearch.Checked)
            {

            }
            if (value == "0")
            {
                ThreadStart start = delegate { nd.QuickSearch(lsb_discover, pbnetwork); };
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
                ThreadStart start = delegate { Discover("0"); };
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
            GiveSelectedIPinIPConfigurationClient();
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveSelectedIPinIPConfigurationServer();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveSelectedAdapterinTextBox();
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

        private void ClientSettings_Activated(object sender, EventArgs e)
        {
            StartthisListener();
        }

        private void ClientSettings_Deactivate(object sender, EventArgs e)
        {
            CancelClientListener();
        }
    }
}

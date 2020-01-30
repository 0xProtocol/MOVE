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
using MOVE.Shared;

namespace MOVE.Client.Debug.Formular
{
    public partial class ClientSettings : Form
    {
        #region Klasseninstanzvariablen
        NetworkDiscovery nd = new NetworkDiscovery();
        FirewallSettings fs = new FirewallSettings();
        SpeechRecognitionEngine _recognizersettings = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Variablen
        Thread discoverythread;
        int counter;
        int speechmodulevalue = 1;
        int calState = 0;
        #endregion
        #region klassengenerierte Methoden
        public ClientSettings()
        {
            InitializeComponent();
            string emp = ConfigurationManager.AppSettings["sensitivity"];
            tbEmpfindlichkeit.Value = Convert.ToInt32(emp);
            string glät = ConfigurationManager.AppSettings["smoothing"];
            tbGlättungsstufe.Value = Convert.ToInt32(glät);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);
        }
        private void ClientSettings_Load(object sender, EventArgs e)
        {
            lsb_networkadapter.Items.Clear();
            nd.getip(lsb_networkadapter);
            string[] splitzeile = nd.firstvalue.Split('|');
            tbx_Discovery.Text = splitzeile[1];
            textBox1.Text = splitzeile[2];
        }
        private void btn_Discover_Click(object sender, EventArgs e)
        {
            if (nd.isworking == false)
            {
                if (cbQuickSearch.Checked == true)
                {
                    Discover("0");
                }
                if (cbDeepSearch.Checked == true)
                {
                    Discover("1");
                }
            }
            else
            {
                com.SpeakAsync("Der Vorgang ist bereits gestartet worden, warten Sie bitte!");
            }
        }
        private void ClientSettings_Activated(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                StartthisListener();
            }
            else
            {
                //
            }
        }

        private void ClientSettings_Deactivate(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                CancelClientListener();
            }
            else
            {
                //
            }
        }
        private void btn_deactivatefirewall_Click(object sender, EventArgs e)
        {
            fs.FirewallOff();
        }

        private void btn_ActivateFirewall_Click(object sender, EventArgs e)
        {
            fs.FirewallOn();
        }
        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveSelectedIPinIPConfigurationClient();
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveSelectedIPinIPConfigurationServer();
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
        #endregion
        #region Speech Recognition
        public void ClientSettingsListener()
        {
            try
            {
            _recognizersettings.SetInputToDefaultAudioDevice();
            _recognizersettings.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandsclientsettings.txt")))));
            _recognizersettings.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSettings_SpeechRecognized);
            _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
                    if (nd.isworking == false)
                    {
                        Discover("1");
                    }
                    else
                    {
                        com.SpeakAsync("Warten Sie, Vorgang noch nicht beendet!");
                    }
                }
                if (speech == "Starte Quicksearch")
                {
                    if (nd.isworking == false)
                    {
                        Discover("0");
                    }
                    else
                    {
                        com.SpeakAsync("Warten Sie, Vorgang noch nicht beendet!");
                    }
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
                        GiveSelectedAdapterinTextBox();
                    }
                    catch (Exception ex)
                    {
                        elw.WriteErrorLog(ex.ToString());

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
                        ShowMessageBox();
                    }
                    catch (Exception ex)
                    {
                        elw.WriteErrorLog(ex.ToString());
                    }
                }
                if (speech == "Fünf Adressen weiter")
                {
                    try
                    {
                        lsb_discover.SelectedIndex += 5;
                        ShowMessageBox();
                    }
                    catch (Exception ex)
                    {
                        elw.WriteErrorLog(ex.ToString());
                    }
                }
                if (speech == "Adresse für Server")
                {
                    GiveSelectedIPinIPConfigurationServer();
                    com.SpeakAsync("Adresse wurde dem Server zugewiesen");
                }
                if (speech == "Adresse für Client")
                {
                    GiveSelectedIPinIPConfigurationClient();
                    com.SpeakAsync("Adresse wurde dem Client zugewiesen");
                }
            }
            if (speech == "Spieleinstellungen")
            {
                tcsettings.SelectedIndex = 0;
            }
            if (speech == "Frequenztuning")
            {
                tcsettings.SelectedIndex = 1;
            }
            if (speech == "Adresseinstellungen")
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
        private void ActivateClientListener()
        {
            try
            {
                _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
                elw.WriteErrorLog(ex.ToString());
            }
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
        #endregion
        #region Methoden 
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
            this.Close();
        }
        private void SelectFirstAdapter()
        {
            try
            {

            lsb_networkadapter.SelectedIndex = 0;
            lsb_networkadapter.Focus();
            GiveSelectedAdapterinTextBox();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
            catch (Exception ex) 
            {
                elw.WriteErrorLog(ex.ToString());
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
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
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
            if (rBkalibrieren.Checked == true)
            {
                return 8;
            }
            return 0;
        }

        public double FrequenzThreshold()
        {
            double threshold = Convert.ToDouble(tbThreshold.Value) / 10;
            return threshold;
        }
        private void btnStartCal_Click_1(object sender, EventArgs e)
        {
            calState = 1;
        }

        private void btnStopCal_Click_1(object sender, EventArgs e)
        {
            calState = 2;
            rBkalibrieren.Checked = true;
        }
        public int GetCalSate()
        {
            return calState;
        }

        public void Discover(string value)
        {
            try
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
                    discoverythread = new Thread(new ThreadStart(start));
                    discoverythread.Start();

                }
                else if (value == "1")
                {
                    ThreadStart start = delegate { nd.DeepSearch(lsb_discover, pbnetwork); };
                    discoverythread = new Thread(new ThreadStart(start));
                    discoverythread.Start();
                }
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        #endregion
        #region funktionslose Methoden
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
   

        private void pbnetwork_Click(object sender, EventArgs e)
        {

        }

        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void lsb_discover_MouseDown(object sender, MouseEventArgs e)
        {

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

        private void btnStopCal_Click(object sender, EventArgs e)
        {

        }

        private void btnStartCal_Click(object sender, EventArgs e)
        {

        }
    }
}
#endregion
using MOVE.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOVE.Server.Debug.Formular
{
    public partial class ServerSettings : Form
    {
        #region Klasseninstanzierungen
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
        public ServerSettings()
        {
            InitializeComponent();
            string emp = ConfigurationManager.AppSettings["sensitivity"];
            tbempfindlichkeit.Value = Convert.ToInt32(emp);
            string glät = ConfigurationManager.AppSettings["smoothing"];
            tbGlättung.Value = Convert.ToInt32(glät);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);
            this.Focus();
        }
        private void ServerSettings_Load(object sender, EventArgs e)
        {

            lsb_networkadapter.Items.Clear();
            nd.getip(lsb_networkadapter);
            string[] splitzeile = nd.firstvalue.Split('|');
            tbx_Discovery.Text = splitzeile[1];
            textBox1.Text = splitzeile[2];
        }
        private void selectAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveSelectedAdapterinTextBox();
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
        private void btn_ActivateFirewall_Click(object sender, EventArgs e)
        {
            fs.FirewallOn();
        }
        private void btn_deactivatefirewall_Click(object sender, EventArgs e)
        {
            fs.FirewallOff();
        }
        private void ServerSettings_Activated(object sender, EventArgs e)
        {
            if(speechmodulevalue==1)
            {
                StartthisListener();
            }
            else
            {
                //
            }

        }
        private void ServerSettings_Deactivate(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                CancelServerListener();
            }

            else
            {
                //
            }
        }
        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveSelectedIPinIPConfigurationClient();
        }
        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveSelectedIPinIPConfigurationServer();
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
        private void ServerSettingsListener()
        {
            try
            {
            _recognizersettings.SetInputToDefaultAudioDevice();
            _recognizersettings.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandsserversettings.txt")))));
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
                tabControl1.SelectedIndex = 0;
            }
            if (speech == "Frequenztuning")
            {
                tabControl1.SelectedIndex = 1;
            }
            if (speech == "Adresseinstellungen")
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
        public void ActivateServerListener()
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
        public void CancelServerListener()
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
                ServerSettingsListener();
                counter++;
            }
            else
            {
                ActivateServerListener();
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

        private void btnStartCal_Click(object sender, EventArgs e)
        {
            calState = 1;
        }

        private void btnStopCal_Click(object sender, EventArgs e)
        {
            calState = 2;
            rBkalibrieren.Checked = true;
        }

        public int GetCalSate()
        {
            return calState;
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
        private void tbempfindlichkeit_Scroll(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void TcNetworkDicovery_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
#endregion
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
using System.Globalization;

namespace MOVE.Client.Debug.Formular
{
    public partial class ClientSettings : Form
    {
        #region Klasseninstanzvariablen
        NetworkDiscovery nd = new NetworkDiscovery();
        FirewallSettings fs = new FirewallSettings();
        SpeechRecognitionEngine _recognizerserversettingsgerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerserversettingsenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        SpeechSynthesizer com = new SpeechSynthesizer();
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Variablen
        Thread discoverythread;
        int counter;
        int speechmodulevalue = 1;
        int calState = 0;
        int speechvalue;
        int helpvalue=0;
        #endregion
        #region klassengenerierte Methoden
        public ClientSettings()
        {
            InitializeComponent();
            string emp = ConfigurationManager.AppSettings["sensitivity"];
            tbEmpfindlichkeit.Value = Convert.ToInt32(emp);
            string glät = ConfigurationManager.AppSettings["smoothing"];
            tbGlättungsstufe.Value = Convert.ToInt32(glät);
            string language = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(language);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);
            this.Focus();
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
                if (speechvalue == 0)
                {
                    com.SpeakAsync("Der Vorgang ist bereits gestartet worden, warten Sie bitte!");
                }
                if (speechvalue == 1)
                {
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("The process has already started, please wait!");
                }
            }
        }
        private void ClientSettings_Activated(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    StartthisListenerGerman();
                    DesignChangesGerman();
                }
                else if (speechvalue == 1)
                {
                    StartthisListenerEnglish();
                    DesignChangesEnglish();
                }
            }
            else
            {
                if (speechvalue == 0)
                {
                    DesignChangesGerman();
                }
                if (speechvalue == 1)
                {
                    DesignChangesEnglish();
                }
            }
        }

        private void ClientSettings_Deactivate(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    CancelDefaultGermanListener();
                }
                else if (speechvalue == 1)
                {
                    CancelDefaultEnglishListener();
                }
            }
            else
            {
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
        public void DefaultListenerGerman()
        {
            try
            {
                _recognizerserversettingsgerman.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandsclientsettings.txt")));
                gb.Culture = new CultureInfo("de-DE");
                Grammar g = new Grammar(gb);
                _recognizerserversettingsgerman.LoadGrammar(g);
                _recognizerserversettingsgerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultClientSettingsGerman_SpeechRecognized);
                _recognizerserversettingsgerman.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }

        public void DefaultListenerEnglish()
        {
            try
            {
                _recognizerserversettingsenglish.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandsclientsettings.txt")));
                gb.Culture = new CultureInfo("en-GB");
                Grammar g = new Grammar(gb);
                _recognizerserversettingsenglish.LoadGrammar(g);
                _recognizerserversettingsenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultClientSettingsEnglish_SpeechRecognized);
                _recognizerserversettingsenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }

        public void DefaultClientSettingsEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (tcsettings.SelectedTab == tcsettings.TabPages[0])
            {
                if (speech == "sensitivity one")
                {
                    tbEmpfindlichkeit.Value = 1;
                }
                if (speech == "sensitivity two")
                {
                    tbEmpfindlichkeit.Value = 2;
                }
                if (speech == "sensitivity three")
                {
                    tbEmpfindlichkeit.Value = 3;
                }
                if (speech == "smoothinglevel one")
                {
                    tbGlättungsstufe.Value = 1;
                }
                if (speech == "smoothinglevel two")
                {
                    tbGlättungsstufe.Value = 2;
                }
                if (speech == "smoothinglevel three")
                {
                    tbGlättungsstufe.Value = 3;
                }
            }
            if (tcsettings.SelectedTab == tcsettings.TabPages[1])
            {
                if (speech == "bass")
                {
                    rBBass.Checked = true;
                }
                if (speech == "bariton")
                {
                    rBBartion.Checked = true;
                }
                if (speech == "tenor")
                {
                    rBTenor.Checked = true;
                }
                if (speech == "männeralt")
                {
                    rBMaenneralt.Checked = true;
                }
                if (speech == "mezzosopran")
                {
                    rBMezzosopran.Checked = true;
                }
                if (speech == "sopran")
                {
                    rBSopran.Checked = true;
                }
                if (speech == "whistle")
                {
                    rBPfeifen.Checked = true;
                }
                if (speech == "calibrated")
                {
                    rBkalibrieren.Checked = true;
                }
                if (speech == "start calibration")
                {
                    StartCal();
                }
                if (speech == "stop calibration")
                {
                    StopCal();
                }
                if(speech=="set smoothing level to one")
                {
                    tbSmoothing.Value = 0;
                }
                if (speech == "set smoothing level to two")
                {
                    tbSmoothing.Value = 1;

                }
                if (speech == "set smoothing level to three")
                {
                    tbSmoothing.Value = 2;
                }
                if (speech == "set smoothing level to four")
                {
                    tbSmoothing.Value = 3;
                }
                if (speech == "set recording threshold to one")
                {
                    tbThreshold.Value = 1;
                }
                if (speech == "set recording threshold to two")
                {
                    tbThreshold.Value = 2;
                }
                if (speech == "set recording threshold to three")
                {
                    tbThreshold.Value = 3;
                }
                if (speech == "set recording threshold to four")
                {
                    tbThreshold.Value = 4;
                }
                if (speech == "set recording threshold to five")
                {
                    tbThreshold.Value = 5;
                }
                if (speech == "set recording threshold to six")
                {
                    tbThreshold.Value = 6;
                }
                if (speech == "set recording threshold to seven")
                {
                    tbThreshold.Value = 7;
                }
                if (speech == "set recording threshold to eight")
                {
                    tbThreshold.Value = 8;
                }
                if (speech == "set recording threshold to nine")
                {
                    tbThreshold.Value = 9;
                }
            }
            if (tcsettings.SelectedTab == tcsettings.TabPages[3])
            {
                if (speech == "start deepsearch")
                {
                    if (nd.isworking == false)
                    {
                        Discover("1");
                    }
                    else
                    {
                        com.SelectVoice("Microsoft Hazel Desktop");
                        com.SpeakAsync("Wait, process not yet finished!");
                    }
                }
                if (speech == "start quicksearch")
                {
                    if (nd.isworking == false)
                    {
                        Discover("0");
                    }
                    else
                    {
                        com.SelectVoice("Microsoft Hazel Desktop");
                        com.SpeakAsync("Wait, process not yet finished!");
                    }
                }
                if (speech == "activate firewall")
                {
                    ActivateFirewall();
                }
                if (speech == "deactivate firewall")
                {
                    DeactivateFirewall();
                }
                if (speech == "the first adapter")
                {
                    SelectFirstAdapter();
                }
                if (speech == "the second adapter")
                {
                    SelectSecondAdapter();
                }
                if (speech == "the third adapter")
                {
                    SelectThirdAdapter();

                }
                if (speech == "the fourth adapter")
                {
                    SelectFourthAdapter();
                }
                if (speech == "one adapter further")
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
                if (speech == "the first address")
                {
                    SelectFirstAddress();
                }
                if (speech == "the second address")
                {
                    SelectSecondAddress();
                }
                if (speech == "the third address")
                {
                    SelectThirdAddress();
                }
                if (speech == "the fourth address")
                {
                    SelectFourhtAddress();
                }
                if (speech == "the fifth address")
                {
                    SelectFifthAddress();
                }
                if (speech == "one address further")
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
                if (speech == "five addresses further")
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
                if (speech == "address for server")
                {
                    GiveSelectedIPinIPConfigurationServer();
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("Address was assigned to the server");
                }
                if (speech == "address for client")
                {
                    GiveSelectedIPinIPConfigurationClient();
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("Address was assigned to the client");
                }
            }
            if (speech == "settings")
            {
                tcsettings.SelectedIndex = 0;
            }
            if (speech == "frequency")
            {
                tcsettings.SelectedIndex = 1;
            }
            if (speech == "address configuration")
            {
                tcsettings.SelectedIndex = 2;
            }
            if (speech == "network discovery")
            {
                tcsettings.SelectedIndex = 3;
            }
            if (speech == "exit")
            {
                CloseWindow();
            }
            if (speech == "Which commands are avaiable?")
            {
                CheckActiveTabControl();
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineEnglish\\commandsclientsettings.txt",helpvalue);
                h.ShowDialog();
            }
        }

        public void DefaultClientSettingsGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
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
                if (speech == "Kalibriert")
                {
                    rBkalibrieren.Checked = true;
                }
                if (speech == "Starte Kalibrierung")
                {
                    StartCal();
                }
                if (speech == "Stoppe Kalibrierung")
                {
                    StopCal();
                }
                if (speech == "Setze Glättungstufe auf eins")
                {
                    tbSmoothing.Value = 0;
                }
                if (speech == "Setze Glättungstufe auf zwei")
                {
                    tbSmoothing.Value = 1;

                }
                if (speech == "Setze Glättungstufe auf drei")
                {
                    tbSmoothing.Value = 2;
                }
                if (speech == "Setze Glättungstufe auf vier")
                {
                    tbSmoothing.Value = 3;
                }
                if (speech == "Setze Aufnahmeschwelle auf eins")
                {
                    tbThreshold.Value = 1;
                }
                if (speech == "Setze Aufnahmeschwelle auf zwei")
                {
                    tbThreshold.Value = 2;
                }
                if (speech == "Setze Aufnahmeschwelle auf drei")
                {
                    tbThreshold.Value = 3;
                }
                if (speech == "Setze Aufnahmeschwelle auf vier")
                {
                    tbThreshold.Value = 4;
                }
                if (speech == "Setze Aufnahmeschwelle auf fünf")
                {
                    tbThreshold.Value = 5;
                }
                if (speech == "Setze Aufnahmeschwelle auf sechs")
                {
                    tbThreshold.Value = 6;
                }
                if (speech == "Setze Aufnahmeschwelle auf sieben")
                {
                    tbThreshold.Value = 7;
                }
                if (speech == "Setze Aufnahmeschwelle auf acht")
                {
                    tbThreshold.Value = 8;
                }
                if (speech == "Setze Aufnahmeschwelle auf neun")
                {
                    tbThreshold.Value = 9;
                }
            }
            if (tcsettings.SelectedTab == tcsettings.TabPages[3])
            {
                if (speech == "Starte Tiefsuche")
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
                if (speech == "Starte Schnellsuche")
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
                if (speech == "Aktiviere die Firewall")
                {
                    ActivateFirewall();
                }
                if (speech == "Deaktiviere die Firewall")
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
            if (speech == "Frequenzeinstellungen")
            {
                tcsettings.SelectedIndex = 1;
            }
            if (speech == "Adresseinstellungen")
            {
                tcsettings.SelectedIndex = 2;
            }
            if (speech == "Netzwerkerkennung")
            {
                tcsettings.SelectedIndex = 3;
            }
            if (speech == "Schließen")
            {
                CloseWindow();
            }
            if (speech == "Welche Befehle gibt es?")
            {
                CheckActiveTabControl();
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineGerman\\commandsclientsettings.txt",helpvalue);
                h.ShowDialog();
            }
        }
        public void CancelDefaultGermanListener()
        {
            try
            {
                _recognizerserversettingsgerman.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        public void ActivateDefaultGermanListener()
        {
            try
            {
                _recognizerserversettingsgerman.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        public void CancelDefaultEnglishListener()
        {
            try
            {
                _recognizerserversettingsenglish.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        public void ActivateDefaultEnglishListener()
        {
            try
            {
                _recognizerserversettingsenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        private void DesignChangesGerman()
        {

        }
        private void DesignChangesEnglish()
        {
            tcGameSettings.Text = "Game Settings";
            tcFrequency.Text = "Frequency Settings";
            tcAddress.Text = "Adressconfiguration";
            tcNetworkDiscovery.Text = "Network Discovery";
            lblEmpfindlichkeit.Text = "Sensitivity";
            lblGlättungsstufe.Text = "Smoothing level";
            label1.Text = "Admission threshold";
            rBPfeifen.Text = "Whistle";
            cbDeepSearch.Text = "Deep Search";
            cbQuickSearch.Text = "Quick Search";
            btn_Discover.Text = "Start Discovery";
            btn_ActivateFirewall.Text = "Activate Firewall";
            btn_deactivatefirewall.Text = "Deactivate Firewall";
        }
        private void StartthisListenerGerman()
        {
            if (counter < 1)
            {
                DefaultListenerGerman();
                counter++;
            }
            else
            {
                ActivateDefaultGermanListener();
            }
        }
        private void StartthisListenerEnglish()
        {
            if (counter < 1)
            {
                DefaultListenerEnglish();
                counter++;
            }
            else
            {
                ActivateDefaultEnglishListener();
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
        private void CheckActiveTabControl()
        {
            if (tcsettings.SelectedTab == tcsettings.TabPages[0])
            {
                helpvalue = 1;
            }
            if (tcsettings.SelectedTab == tcsettings.TabPages[1])
            {
                helpvalue = 2;
            }
            if (tcsettings.SelectedTab == tcsettings.TabPages[2])
            {
                helpvalue = 0;
            }
            if (tcsettings.SelectedTab == tcsettings.TabPages[3])
            {
                helpvalue = 3;
            }
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
            if (speechvalue == 0)
            {
                com.SpeakAsync("Wollen Sie die Adresse dem Server oder dem Client zuweisen?");
            }
            if (speechvalue == 1)
            {
                com.SelectVoice("Microsoft Hazel Desktop");
                com.SpeakAsync("Do you want to assign the address to the server or the client?");
            }
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
            btnStartCal.Enabled = false;
            StartCal();
            btnStopCal.Enabled = true;
        }

        private void btnStopCal_Click_1(object sender, EventArgs e)
        {
            btnStopCal.Enabled = false;
            StopCal();
            btnStartCal.Enabled = true;
        }
        private void StartCal()
        {
            calState = 1;
        }

        private void StopCal()
        {
            calState = 2;
            rBkalibrieren.Checked = true;
        }
        public int GetCalState()
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
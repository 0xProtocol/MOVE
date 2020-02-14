using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MOVE.Core;
using MOVE.Shared;
using System.IO;
using System.Windows.Markup;
using System.Xaml;
using System.Windows.Forms.Integration;
using System.Windows.Controls;
using MOVE.AudioLayer;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Configuration;
using System.Globalization;

namespace MOVE.Client.Debug.Formular
{
    public partial class ClientForms : Form, IServiceLogger
    {
        #region Klasseninstanzvariablen
        Client c;
        TcpService tcp;
        SoundInput si = new SoundInput();
        FrequenzInput fi = new FrequenzInput();
        SpeechRecognitionEngine _recognizerclientgerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerclientenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        SpeechSynthesizer com = new SpeechSynthesizer();
        ClientSettings cs = new ClientSettings();
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Variablen
        Thread t1;  //Start Server
        Thread t2;  //Connect Client
        int WertXlocal = 15;
        int WertXnetwork = 15;
        int WertYnetworkball = 15;
        int WertXnetworkball = 15;
        int pointsBlue = 0;
        int pointsGreen = 0;
        int counterstartserver;
        int counterconnectserver;
        int counterstartgame;
        Action<string> logRequestInformation;
        Action<string> logServiceInformation;
        private static Random rnd = new Random();
        const int yValue = 65;
        public List<int> savedValues = new List<int>();
        public int positionValue = 0;
        public int wertGlaettung = 3;
        public string output;
        int paddlexlocal;
        int counter = -2;
        double player = 0;
        int speechmodulevalue = 1;
        int speechvalue;
        #endregion
        #region klassengenerierte Methoden
        public ClientForms()
        {
            InitializeComponent();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            int s = Convert.ToInt32(screenHeight);
            double zahl = (7000 / 1080) * s;
            player = zahl / 10;
            logRequestInformation = new Action<string>(LogRequestInformation);
            logServiceInformation = new Action<string>(LogServiceinformation);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            si.Loading();
            fi.Start();
            string language = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(language);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    DefaultListenerGerman();
                    DesignChangesGerman();
                }
                if (speechvalue == 1)
                {
                    DefaultListenerEnglish();
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
        #region Service/Request
        public void LogServiceinformation(string message)
        {
            if (message.Contains("Waiting for connection"))
            {
                lblSchrittEins.Text = "Korrektes IP-Netzwerk ausgewählt: ✓";
            }
            if (message.Contains("wird gesendet an"))
            {
                lblSchrittZwei.Text = "Verbindung zu Server hergestellt: ✓";
            }
        }
        public void LogRequestInformation(string message)
        {
            string[] msg = message.Split('|');
            string xball = msg[0];
            string yball = msg[1];
            string xs = msg[2];
            string pointsBlue1 = msg[4];
            string pointsGreen1 = msg[3];
            if (message.Contains("|"))
            {
                lblSchrittDrei.Text = "Übertragung der Schlägerkoordinaten: ✓";
            }
            if (pbx_uplocal.InvokeRequired)
            {
                pbx_downnetwork.Invoke(logRequestInformation, message);
                // Ball.Invoke(logRequestInformation, message);
                WertXnetworkball = Convert.ToInt32(msg[0]);
                WertYnetworkball = Convert.ToInt32(msg[1]);
                WertXnetwork = Convert.ToInt32(msg[2]);
                pointsBlue = Convert.ToInt32(msg[4]);
                pointsGreen = Convert.ToInt32(msg[3]);
            }
            else
            {
                //counter++;
                pbx_downnetwork.Location = new Point(WertXnetwork, (int)player);
                Ball.Location = new Point(WertXnetworkball, WertYnetworkball);
                points1.Text = pointsGreen.ToString();
                points2.Text = pointsBlue.ToString();

            }
        }

        #endregion
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            try
            {
                if (rBFrequenz.Checked == true)
                {
                    fi.CalculateData(cs.GetCalState());

                    positionValue = fi.CalculatePaddleLocationX(cs.FrequenzSetting(), cs.FrequenzThreshold());

                    if (positionValue < 0)
                    {
                        positionValue = 0;
                    }
                    if (positionValue > 1350)
                    {
                        positionValue = 1350;
                    }

                    if (cs.tbSmoothing.Value == 0)
                    {
                        pbx_uplocal.Location = new Point(positionValue + 60, 65);
                    }
                    if (cs.tbSmoothing.Value == 1)
                    {
                        savedValues.Add(positionValue);
                        Glaettung(2);
                    }
                    if (cs.tbSmoothing.Value == 2)
                    {
                        savedValues.Add(positionValue);
                        Glaettung(4);
                    }
                    if (cs.tbSmoothing.Value == 3)
                    {
                        savedValues.Add(positionValue);
                        Glaettung(6);
                    }
                }

                if (rBSound.Checked == true)
                {
                    double frac = si.soundValueTwo / si.soundValueOne;
                    if (cs.tbEmpfindlichkeit.Value == 1)
                    {
                        positionValue = (int)(((frac * 3) * 668)) - 2;
                        //lblFineTuning.Text = "Empfindlichkeit: wenig";

                    }
                    else if (cs.tbEmpfindlichkeit.Value == 2)
                    {
                        positionValue = (int)(((frac * 5) * 668)) - 3;
                       // lblFineTuning.Text = "Empfindlichkeit: mittel";

                    }
                    else if (cs.tbEmpfindlichkeit.Value == 3)
                    {
                        positionValue = (int)(((frac * 8) * 668)) - 5;
                        //lblFineTuning.Text = "Empfindlichkeit: hoch";

                    }
                    if (cs.tbGlättungsstufe.Value == 1)
                    {
                        wertGlaettung = 3;
                        Glaettung(wertGlaettung);
                       // lblGlaettung.Text = "Glättungsstufe: 1";
                    }
                    if (cs.tbGlättungsstufe.Value == 2)
                    {
                        wertGlaettung = 4;
                        Glaettung(wertGlaettung);
                        //lblGlaettung.Text = "Glättungsstufe: 2";
                    }
                    if (cs.tbGlättungsstufe.Value == 3)
                    {
                        wertGlaettung = 6;
                        Glaettung(wertGlaettung);
                        //lblGlaettung.Text = "Glättungsstufe: 3";
                    }
                    //double newfrac = Math.Round(frac, 0, MidpointRounding.AwayFromZero);
                    if (positionValue < 0)
                    {
                        positionValue = 0;
                    }
                    if (positionValue > 1300)
                    {
                        positionValue = 1300;
                    }
                    savedValues.Add(positionValue);

                    Glaettung(wertGlaettung);
                }

                c.Send("move:\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X));
              
            }

            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
        private void cbAusblenden_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnWerteAufzeichnen_Click(object sender, EventArgs e)
        {
            ExportToTxt("savePong.txt");
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
           
        }

        private void dgv_playfieldclient_KeyDown(object sender, KeyEventArgs e)
        {
            rbKeyboard.Checked = true;
            try
            {
                if (e.KeyCode == Keys.Right)
            {
                    WertXlocal += 25;
                    if (WertXlocal > 1350)
                    {
                        WertXlocal = 1350;
                    }
                        pbx_uplocal.Location = new Point(WertXlocal, 65);
                        c.Send("move:\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X));

            }
            if (e.KeyCode == Keys.Left)
            {
                    WertXlocal -= 25;
                    if (WertXlocal < 70)
                    {
                        WertXlocal = 70;
                    }
                pbx_uplocal.Location = new Point(WertXlocal, 65);
                c.Send("move:\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X));
            }
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }

        }
        private void ClientForms_Activated(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    ActivateDefaultGermanListener();
                }
                else if (speechvalue == 1)
                {
                    ActivateDefaultEnglishListener();
                }
            }
            else
            {
            }
        }

        private void ClientForms_Deactivate(object sender, EventArgs e)
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
        #endregion
        #region Speech Recognition
        public void DefaultListenerGerman()
        {
            try
            {
                _recognizerclientgerman.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandsclient.txt")));
                gb.Culture = new CultureInfo("de-DE");
                Grammar g = new Grammar(gb);
                _recognizerclientgerman.LoadGrammar(g);
                _recognizerclientgerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultClientGerman_SpeechRecognized);
                _recognizerclientgerman.RecognizeAsync(RecognizeMode.Multiple);
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
                _recognizerclientenglish.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandsclient.txt")));
                gb.Culture = new CultureInfo("en-GB");
                Grammar g = new Grammar(gb);
                _recognizerclientenglish.LoadGrammar(g);
                _recognizerclientenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultClientEnglish_SpeechRecognized);
                _recognizerclientenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }

        private void DefaultClientGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Starte Server")
            {
                if (counterstartserver < 1)
                {
                    Start();
                    com.SpeakAsync("Server wurde gestartet");
                    counterstartserver++;
                }
                else
                {
                    com.SpeakAsync("Server wurde bereits gestartet");
                }
            }

            if (speech == "Verbinde zum Server")
            {
                if (counterconnectserver < 1)
                {
                    Connect();
                    com.SpeakAsync("Verbindung zum Server wurde hergestellt");
                    counterconnectserver++;
                }
                else
                {
                    com.SpeakAsync("Verbindung zum Server wurde bereits hergestellt");
                }
            }

            if (speech == "Starte das Spiel")
            {
                if (counterstartgame < 1)
                {
                    StartGame();
                    counterstartgame++;
                }
                else
                {
                    com.SpeakAsync("Spiel wurde bereits gestartet");
                }
            }

            if (speech == "Einstellungen")
            {
                Settings();
            }
            if (speech == "Sound")
            {
                EnableSound();
            }
            if (speech == "Tonfrequenz")
            {
                EnableFrequenz();
            }
            if (speech == "Tastatur")
            {
                EnableTastatur();
                dgv_playfieldclient.Focus();
            }

            if (speech == "Menü ausblenden")
            {
                Disablemenu();
            }
            if (speech == "Menü einblenden")
            {
                Enablemenu();
            }
            if (speech == "Schließe das Spiel")
            {
                this.Close();
            }
            if (speech == "Welche Befehle gibt es?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineGerman\\commandsclient.txt");
                h.ShowDialog();
            }
        }

        private void DefaultClientEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "start server")
            {
                if (counterstartserver < 1)
                {
                    Start();
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("Server starting");
                    counterstartserver++;
                }
                else
                {
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("Server has already been started");
                }
            }

            if (speech == "connect to server")
            {
                if (counterconnectserver < 1)
                {
                    Connect();
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("Connection to the server has been established");
                    counterconnectserver++;
                }
                else
                {
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("Connection to the server has already been established");
                }
            }

            if (speech == "move it")
            {
                if (counterstartgame < 1)
                {
                    StartGame();
                    counterstartgame++;
                }
                else
                {
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("Game has already been started");
                }
            }
            if (speech == "settings")
            {
                Settings();
            }
            if (speech == "sound")
            {
                EnableSound();
            }
            if (speech == "frequency")
            {
                EnableFrequenz();
            }
            if (speech == "keyboard")
            {
                EnableTastatur();
                dgv_playfieldclient.Focus();
            }

            if (speech == "disable menu")
            {
                Disablemenu();
            }
            if (speech == "activate menu")
            {
                Enablemenu();
            }
            if (speech == "exit the window")
            {
                this.Close();
            }
            if (speech == "Which commands are avaiable?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineEnglish\\commandsclient.txt");
                h.ShowDialog();
            }

        }
        public void CancelDefaultGermanListener()
        {
            try
            {
                _recognizerclientgerman.RecognizeAsyncStop();
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
                _recognizerclientgerman.RecognizeAsync(RecognizeMode.Multiple);
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
                _recognizerclientenglish.RecognizeAsyncStop();
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
                _recognizerclientenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        #endregion
        #region Methoden
        private void Settings()
        {
            cs.ShowDialog();
        }
        private void DesignChangesGerman()
        {

        }

        private void DesignChangesEnglish()
        {
            btnSettings.Text = "Settings";
            btn_Connect.Text = "Connect";
            rBSound.Text = "Sound";
            rBFrequenz.Text = "Frequency";
            rbKeyboard.Text = "Keyboard";
            lblSchrittDrei.Text = "Transmission of the panel coordinates:";
            lblSchrittZwei.Text = "Connection to client established:";
            lblSchrittEins.Text = "Correct IP network selected:";
        }
        private void EnableSound()
        {
            rBSound.Checked = true;
            rBFrequenz.Checked = false;
            rbKeyboard.Checked = false;
        }
        private void EnableFrequenz()
        {
            rBSound.Checked = false;
            rBFrequenz.Checked = true;
            rbKeyboard.Checked = false;
        }
        private void EnableTastatur()
        {
            rBSound.Checked = false;
            rBFrequenz.Checked = false;
            rbKeyboard.Checked = true;
        }
        private void Disablemenu()
        {
            //cbAusblenden.Checked = true;
        }
        private void Enablemenu()
        {
            //cbAusblenden.Checked = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anzahl"></param>
        public void Glaettung(int anzahl)
        {
            int  summe = 0;
            if (savedValues.Count == anzahl)
            {
                for (int i = 0; i < anzahl; i++)
                {
                    summe += savedValues[i];
                }
                si.average = summe / anzahl;
                si.mod = (si.average % anzahl);
                paddlexlocal = (si.average - si.mod) + 15;
                pbx_uplocal.Location = new Point(paddlexlocal + 60, 65);
                savedValues.Clear();
            }
        }
        public void ExportToTxt(string pfad)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(pfad, FileMode.OpenOrCreate);
                sw = new StreamWriter(fs);

                // Jede dieser Zeilen repräsentiert einen Eintrag in die .txt Datei
                for (int i = 0; i < savedValues.Count; i++)
                {
                    sw.Write(Convert.ToString(savedValues[i] + ';'));
                }
            }
            // Exceptions werden mit dieser MessageBox umgangen
            catch (IOException ex)
            {
                elw.WriteErrorLog(ex.ToString());
                MessageBox.Show("Hier ist ein Fehler entstanden!");
            }
            // Anschließend werden streamwriter und fiilestream geschlossen
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        private void Start()
        {
            try
            {
                int port = Convert.ToInt32(cs.tbx_PortServer.Text);
                IPAddress ipaddress = IPAddress.Parse(cs.tbx_IPServer.Text);
                tcp = new TcpService(port, this, ipaddress);
                t1 = new Thread(tcp.Start)
                {
                    IsBackground = true
                };
                t1.Start();
                btn_Start.Enabled = false;
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        private void Connect()
        {
            try
            {
                int port = Convert.ToInt32(cs.tbx_PortClient.Text);
                IPAddress ipaddress = IPAddress.Parse(cs.tbx_IPClient.Text);
                c = new Client(port, ipaddress);
                t2 = new Thread(c.Start)
                {
                    IsBackground = true
                };
                t2.Start();
                btn_Connect.Enabled = false;
            }

            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        private void StartGame()
        {
            timer2.Enabled = true;
        }

        double screenheightvalue;
        double yourcomputerheightvalue;

        private double GetScreenResolution()
        {
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            screenheightvalue = Convert.ToInt32(screenHeight);
            yourcomputerheightvalue = (8000/screenheightvalue);
            return yourcomputerheightvalue;
           // double zahl = (7650 / 1080) * screenheightvalue;
           // player = (((zahl / 10) * screenScalingValue) / 15.334) * diagonal;

            //width
        }
        #endregion
        #region funktionslose Methoden

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void btnSettings_Click(object sender, EventArgs e)
        {
            cs.ShowDialog();
            if (panel1.BackColor == Color.Red && panel2.BackColor == Color.Red)
            {
                panel1.BackColor = Color.Orange;
                panel2.BackColor = Color.Orange;
                panel3.BackColor = Color.Orange;
                panel4.BackColor = Color.Orange;
                panel5.BackColor = Color.Orange;
                panel6.BackColor = Color.Orange;
                panel7.BackColor = Color.Orange;
                panel8.BackColor = Color.Orange;
            }
            if (panel1.BackColor == Color.Blue && panel2.BackColor == Color.Purple)
            {
                panel1.BackColor = Color.Blue;
                panel2.BackColor = Color.Purple;
                panel3.BackColor = Color.Pink;
                panel4.BackColor = Color.Blue;
                panel5.BackColor = Color.Blue;
                panel6.BackColor = Color.Purple;
                panel7.BackColor = Color.Pink;
                panel8.BackColor = Color.Pink;
            }
        }

        private void btn_Connect_Click_1(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Yellow;
            panel2.BackColor = Color.Yellow;
            panel3.BackColor = Color.Yellow;
            panel4.BackColor = Color.Yellow;
            panel5.BackColor = Color.Yellow;
            panel6.BackColor = Color.Yellow;
            panel7.BackColor = Color.Yellow;
            panel8.BackColor = Color.Yellow;
            Connect();
        }

        private void btn_Start_Click_1(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Green;
            panel2.BackColor = Color.Green;
            panel3.BackColor = Color.Green;
            panel4.BackColor = Color.Green;
            panel5.BackColor = Color.Green;
            panel6.BackColor = Color.Green;
            panel7.BackColor = Color.Green;
            panel8.BackColor = Color.Green;
            Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Blue;
            panel2.BackColor = Color.Purple;
            panel3.BackColor = Color.Pink;
            panel4.BackColor = Color.Blue;
            panel5.BackColor = Color.Blue;
            panel6.BackColor = Color.Purple;
            panel7.BackColor = Color.Pink;
            panel8.BackColor = Color.Pink;
            StartGame();
        }

        private void dgv_playfieldclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rBSound_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbKeyboard_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void rBFrequenz_Click(object sender, EventArgs e)
        {
            savedValues.Clear();
        }
        /*/
private void cbAusblenden_CheckedChanged_1(object sender, EventArgs e)
{
if (cbAusblenden.Checked == true)
{

lblFineTuning.Visible = false;
lblGlaettung.Visible = false;

lsb_Information.Visible = false;
btnSettings.Visible = false;
lblSchwierigkeit.Visible = false;
btn_Start.Visible = false;
btn_Connect.Visible = false;
btnStart.Visible = false;
lblSchrittEins.Visible = false;
lblSchrittZwei.Visible = false;
lblSchrittDrei.Visible = false;
lblBallSpeed.Visible = false;
}
if (cbAusblenden.Checked == false)
{

lblFineTuning.Visible = true;
lblGlaettung.Visible = true;

lsb_Information.Visible = true;
btnSettings.Visible = true;
lblSchwierigkeit.Visible = true;
btn_Start.Visible = true;
btn_Connect.Visible = true;
btnStart.Visible = true;
lblSchrittEins.Visible = true;
lblSchrittZwei.Visible = true;
lblSchrittDrei.Visible = true;
lblBallSpeed.Visible = true;
}
}
/*/
    }
}
#endregion
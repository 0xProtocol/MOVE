using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MOVE.Shared;
using MOVE.Core;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;
using NAudio.Wave;
using System.IO;
using MOVE.AudioLayer;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace MOVE.Server.Debug.Formular
{
    public partial class ServerForms : Form, IServiceLogger
    {
        #region Variablen
        Thread t1; //Start Server
        Thread t2; //Connect Client
        Thread t3; //Sending Thread
        DebugWriter dw = new DebugWriter();
        //ondataavaiable
        //glättung
        //variablen
        //konstruktor
        TcpService ts;
        Action<string> logRequestInformation;
        Action<string> logServiceInformation;
        int WertXlocal = 15;
        int WertXnetwork = 15;
        int WertYnetworkball = 15;
        int WertXnetworkball = 15;
        int punkteGegner = 0;
        int punkteSpieler = 0;
        int counterstartserver;
        int counterconnectserver;
        int counterstartgame;
        Client c;
        Thread scanThread = null;
        private static double audioValueMax = 0;
        private static double audioValueLast = 0;
        private static int audioCount = 0;
        private static int RATE = 44100;
        private static int BUFFER_SAMPLES = 2048;
        const int yValue = 703;
        List<int> savedValues = new List<int>();
        int positionValue = 0;
        int wertGlaettung = 3;
        int average;
        int mod;
        int summe = 0;
        string output;
        public int speed_left = 5;
        public int speed_top = 5;
        FrequenzInput fi = new FrequenzInput();
        SpeechRecognitionEngine _recognizerserver = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();
        FirewallSettings fs = new FirewallSettings();
        NetworkDiscovery nd = new NetworkDiscovery();
        ServerSettings ss = new ServerSettings();
        #endregion

        public ServerForms()
        {
            InitializeComponent();
            logRequestInformation = new Action<string>(LogRequestInformation);
            logServiceInformation = new Action<string>(LogServiceinformation);
            Control.CheckForIllegalCrossThreadCalls = false;
            var waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(RATE, 1);
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.BufferMilliseconds = (int)((double)BUFFER_SAMPLES / (double)RATE * 1000.0);
            waveIn.StartRecording();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            fi.Start();
            ServerListener();
        }

        public void ServerListener()
        {
            _recognizerserver.SetInputToDefaultAudioDevice();
            _recognizerserver.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandsserver.txt")))));
            _recognizerserver.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizerserver.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
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

            if (speech == "Los")
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

            if (speech == "Settings")
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
            else
            {

            }
        }
        public void ActivateServerListener()
        {
            try
            {
                _recognizerserver.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }
        public void CancelServerListener()
        {
            try
            {
                _recognizerserver.RecognizeAsyncCancel();
            }
            catch (Exception ex)
            {

            }
        }
       
        private void Settings()
        {
            ss.Show();
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
            cbAusblenden.Checked = true;
        }
        public void SaveFunction(string pfad)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(pfad, FileMode.Open);
                sw = new StreamWriter(fs);

                // Jede dieser Zeilen repräsentiert einen Eintrag in die .txt Datei
                for (int i = 0; i < auswertungsWerte.Count; i++)
                    sw.WriteLine(Convert.ToString(auswertungsWerte[i]));

                auswertungsWerte.Clear();

            }
            // Exceptions werden mit dieser MessageBox umgangen
            catch (IOException IOex)
            {
                MessageBox.Show("Hier ist ein Fehler entstanden!");
            }
            // Anschließend werden streamwriter und fiilestream geschlossen
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        private void OnDataAvailable(object sender, WaveInEventArgs args)
        {

            float max = 0;

            // interpret as 16 bit audio
            for (int index = 0; index < args.BytesRecorded; index += 2)
            {
                short sample = (short)((args.Buffer[index + 1] << 8) |
                                        args.Buffer[index + 0]);
                var sample32 = sample / 32768f; // to floating point
                if (sample32 < 0) sample32 = -sample32; // absolute value 
                if (sample32 > max) max = sample32; // is this the max value?
            }

            // calculate what fraction this peak is of previous peaks
            if (max > audioValueMax)
            {
                audioValueMax = (double)max;
            }
            audioValueLast = max;
            audioCount += 1;
        }
        public void Glaettung(int anzahl)
        {
            summe = 0;
            if (savedValues.Count == anzahl)
            {
                for (int i = 0; i < anzahl; i++)
                {
                    summe += savedValues[i];
                }
                average = summe / anzahl;
                mod = (average % anzahl);
                pbx_downlocal.Location = new Point((average - mod) + 75, yValue);
                savedValues.Clear();
            }
        }

        #region Service/Request
        public void LogServiceinformation(string message)
        {
            if (lsb_Information.InvokeRequired)
            {
                lsb_Information.Invoke(logServiceInformation, message);
            }
            else
            {
                lsb_Information.Items.Add(message);
            }
        }

        public void LogRequestInformation(string message)
        {
            string[] msg = message.Split('|');
            string x = msg[1];

            if (pbx_downlocal.InvokeRequired)
            {
                pbx_upnetwork.Invoke(logRequestInformation, message);
                WertXnetwork = Convert.ToInt32(msg[1]);
            }
            else
            {
                pbx_upnetwork.Location = new Point(WertXnetwork, 65);
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgv_playfieldServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                WertXlocal += 25;
                pbx_downlocal.Location = new Point(WertXlocal, 400);

            }
            if (e.KeyCode == Keys.Left)
            {
                WertXlocal -= 25;
                pbx_downlocal.Location = new Point(WertXlocal, 400);
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            Connect();

        }

        public void Connect()
        {
            try
            {
                int port = Convert.ToInt32(ss.tbx_PortClient.Text);
                IPAddress ipaddress = IPAddress.Parse(ss.tbx_IPClient.Text);
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

                FileStream fs = new FileStream("ErrorLog.txt", FileMode.Open);
                StreamWriter writer = new StreamWriter(fs);

                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                    "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                writer.Close();
            }
        }
        int counter = 0;
        string today = "Minute:" + System.DateTime.Now.Minute.ToString() + "Second:" + System.DateTime.Now.Second.ToString() + "mm:" + System.DateTime.Now.Millisecond.ToString();
        private void dgv_playfieldclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void timer2_Tick(object sender, EventArgs e)
        {

            if (rBFrequenz.Checked == true)
            {

                fi.CalculateData();

                positionValue = fi.CalculatePaddleLocationX(ss.FrequenzSetting());

                if (positionValue < 12)
                {
                    positionValue = 12;
                }
                if (positionValue > 1600)
                {
                    positionValue = 1600;
                }

                pbx_downlocal.Location = new Point(positionValue, 703);
            }

            if (rBSound.Checked == true)
            {
                double frac = audioValueLast / audioValueMax;
                if (ss.tbempfindlichkeit.Value == 1)
                {
                    positionValue = (int)(((frac * 3) * 668)) - 2;
                    lblFineTuning.Text = "Empfindlichkeit: wenig";

                }
                if (ss.tbempfindlichkeit.Value == 2)
                {
                    positionValue = (int)(((frac * 5) * 668)) - 3;
                    lblFineTuning.Text = "Empfindlichkeit: mittel";

                }
                if (ss.tbempfindlichkeit.Value == 3)
                {
                    positionValue = (int)(((frac * 8) * 668)) - 5;
                    lblFineTuning.Text = "Empfindlichkeit: hoch";

                }

                if (ss.tbGlättung.Value == 1)
                {
                    wertGlaettung = 3;
                    Glaettung(wertGlaettung);
                    lblGlaettung.Text = "Glättungsstufe: 1";
                }
                if (ss.tbGlättung.Value == 2)
                {
                    wertGlaettung = 4;
                    Glaettung(wertGlaettung);
                    lblGlaettung.Text = "Glättungsstufe: 2";
                }
                if (ss.tbGlättung.Value == 3)
                {
                    wertGlaettung = 6;
                    Glaettung(wertGlaettung);
                    lblGlaettung.Text = "Glättungsstufe: 3";
                }
                //double newfrac = Math.Round(frac, 0, MidpointRounding.AwayFromZero);
                if (positionValue < 0)
                {
                    positionValue = 0;
                }
                if (positionValue > 1350)
                {
                    positionValue = 1350;
                }
                savedValues.Add(positionValue);

                Glaettung(wertGlaettung);

            }

            counter++;
            auswertungsWerte.Add(pbx_downlocal.Location.X);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            ThreadStart processTaskThreadball = delegate { c.Send("move:\\" + "lb" + "|" + Convert.ToString(Ball.Location.X) + "|" + Convert.ToString(Ball.Location.Y) + "|" + Convert.ToString(pbx_downlocal.Location.X) + "|" + Convert.ToString(punkteGegner) + "|" + Convert.ToString(punkteSpieler)); };
            new Thread(processTaskThreadball).Start();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            dw.PaddleThread(elapsedMs.ToString());



            //c.send
            string sa = ":\\" + "l" + "|" + Convert.ToString(pbx_downlocal.Location.X);
            dw.SendDebug("ss " + sa + today + "counter " + counter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }
        private void cbAusblenden_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAusblenden.Checked == true)
            {

                lblFineTuning.Visible = false;
                lblGlaettung.Visible = false;
                btnSettings.Visible = false;
                lsb_Information.Visible = false;
                lblSchwierigkeit.Visible = false;
                btn_Start.Visible = false;
                btn_Connect.Visible = false;

                lblBallSpeed.Visible = false;

                btnStart.Visible = false;
            }
            if (cbAusblenden.Checked == false)
            {
                lblFineTuning.Visible = true;
                lblGlaettung.Visible = true;
                lsb_Information.Visible = true;
                lblSchwierigkeit.Visible = true;
                btn_Start.Visible = true;
                btn_Connect.Visible = true;
                btnSettings.Visible = true;
                lblBallSpeed.Visible = true;
                btnStart.Visible = true;
            }
        }

        private void btn_Start_Click_1(object sender, EventArgs e)
        {
            Start();
            panel1.BackColor = Color.Yellow;
            panel2.BackColor = Color.Yellow;
            panel3.BackColor = Color.Yellow;
            panel4.BackColor = Color.Yellow;
            panel5.BackColor = Color.Yellow;
            panel6.BackColor = Color.Yellow;
            panel7.BackColor = Color.Yellow;
            panel8.BackColor = Color.Yellow;
        }

        public void Start()
        {
            int port = Convert.ToInt32(ss.tbx_PortServer.Text);
            IPAddress ipaddress = IPAddress.Parse(ss.tbx_IPServer.Text);
            ts = new TcpService(port, this, ipaddress);
            t1 = new Thread(ts.Start)
            {
                IsBackground = true
            };
            t1.Start();
            btn_Start.Enabled = false;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
            panel1.BackColor = Color.Blue;
            panel2.BackColor = Color.Purple;
            panel3.BackColor = Color.Pink;
            panel4.BackColor = Color.Blue;
            panel5.BackColor = Color.Blue;
            panel6.BackColor = Color.Purple;
            panel7.BackColor = Color.Pink;
            panel8.BackColor = Color.Pink;
        }

        public void StartGame()
        {
            timer2.Enabled = true;
            timer1.Enabled = true;
        }

        private void btn_Discover_Click(object sender, EventArgs e)
        {

        }

        private void btn_deactivatefirewall_Click_1(object sender, EventArgs e)
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

        private void btn_ActivateFirewall_Click_1(object sender, EventArgs e)
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

        private void btn_Connect_Click_1(object sender, EventArgs e)
        {
            Connect();
            panel1.BackColor = Color.Green;
            panel2.BackColor = Color.Green;
            panel3.BackColor = Color.Green;
            panel4.BackColor = Color.Green;
            panel5.BackColor = Color.Green;
            panel6.BackColor = Color.Green;
            panel7.BackColor = Color.Green;
            panel8.BackColor = Color.Green;
        }

        private void lblGlaettung_Click(object sender, EventArgs e)
        {

        }

        private void tbGlaettung_Scroll(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ss.Visible = false;
            ss.Show();
            panel1.BackColor = Color.Orange;
            panel2.BackColor = Color.Orange;
            panel3.BackColor = Color.Orange;
            panel4.BackColor = Color.Orange;
            panel5.BackColor = Color.Orange;
            panel6.BackColor = Color.Orange;
            panel7.BackColor = Color.Orange;
            panel8.BackColor = Color.Orange;

        }

        private void Connection_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Ball.Left += speed_left;
            Ball.Top += speed_top;

            // Berührung des Balls mit dem unteren Schläger
            /*if (Ball.Bottom >= pbx_downlocal.Top && Ball.Bottom <= pbx_downlocal.Bottom && Ball.Left >= pbx_downlocal.Left && Ball.Right <= pbx_downlocal.Right)
            {
                speed_top += 0;
                speed_left += 0;
                speed_top = -speed_top;
                
            }*/

            if (pbx_downlocal.Bounds.IntersectsWith(Ball.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y - 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
            }
            // Berührung des Balls mit dem oberen Schläger
            /*if (Ball.Top <= pbx_upnetwork.Bottom && Ball.Top >= pbx_upnetwork.Top && Ball.Left >= pbx_upnetwork.Left && Ball.Right <= pbx_upnetwork.Right)
            {

                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;

            }*/
            if (pbx_upnetwork.Bounds.IntersectsWith(Ball.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 5);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
            }
            if (Ball.Left <= dgv_playfieldclient.Left)
            {
                speed_left = -speed_left;
            }
            if (Ball.Right >= dgv_playfieldclient.Right - 200)
            {
                speed_left = -speed_left;
            }
            if (Ball.Top <= dgv_playfieldclient.Top)
            {
                speed_top = -speed_top * (-1);
            }
            if (Ball.Bottom >= dgv_playfieldclient.Bottom)
            {
                Ball.Visible = false;
                timer1.Enabled = false;
                Ball.Location = new Point(179, 134);
                Ball.Visible = true;
                timer1.Enabled = true;
                punkteGegner++;
                points1.Text = punkteGegner.ToString();
            }
            if (Ball.Top <= dgv_playfieldclient.Top)
            {
                Ball.Visible = false;
                timer1.Enabled = false;
                Ball.Location = new Point(179, 334);
                Ball.Visible = true;
                timer1.Enabled = true;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
            }
            counter++;

        }
        List<int> auswertungsWerte = new List<int>();
        private void btnWerteAufzeichnen_Click(object sender, EventArgs e)
        {
            SaveFunction("savePong.txt");
        }

        private void dgv_playfieldclient_Click(object sender, EventArgs e)
        {

        }

        private void dgv_playfieldclient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                WertXlocal += 25;
                pbx_downlocal.Location = new Point(WertXlocal, 663);

            }
            if (e.KeyCode == Keys.Left)
            {
                WertXlocal -= 25;
                pbx_downlocal.Location = new Point(WertXlocal, 663);
            }
        }

        private void lblFineTuning_Click(object sender, EventArgs e)
        {

        }

        private void lblBallSpeed_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ServerForms_Activated(object sender, EventArgs e)
        {
            ActivateServerListener();
        }

        private void ServerForms_Deactivate(object sender, EventArgs e)
        {
            CancelServerListener();
        }
    }
}


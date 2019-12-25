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
using NAudio.Wave;
using System.IO;
using System.Windows.Markup;
using System.Xaml;
using System.Windows.Forms.Integration;
using System.Windows.Controls;
using MOVE.AudioLayer;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace MOVE.Client.Debug.Formular
{
    public partial class ClientForms : Form, IServiceLogger
    {
        // ClientApplication

        #region Variablen
        Thread t1;  //Start Server
        Thread t2;  //Connect Client
        Thread t3;  //Sending Thread
        Client c;
        TcpService tcp;
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
        Thread scanThread = null;
        private static Random rnd = new Random();
        const int yValue = 65;
        public List<int> savedValues = new List<int>();
        public int positionValue = 0;
        public int wertGlaettung = 3;
        public string output;
        SoundInput si = new SoundInput();
        FrequenzInput fi = new FrequenzInput();
        SpeechRecognitionEngine _recognizerclient = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();
        ClientSettings cs = new ClientSettings();
        int paddlexlocal;
        #endregion

        public ClientForms()
        {
            InitializeComponent();
            logRequestInformation = new Action<string>(LogRequestInformation);
            logServiceInformation = new Action<string>(LogServiceinformation);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            si.Loading();
            fi.Start();
            ClientListener();
        }

        public void ClientListener()
        {
            _recognizerclient.SetInputToDefaultAudioDevice();
            _recognizerclient.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandsclient.txt")))));
            _recognizerclient.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizerclient.RecognizeAsync(RecognizeMode.Multiple);
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
        public void ActivateClientListener()
        {
            try
            {
                _recognizerclient.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }

        public void CancelClientListener()
        {
            try
            {
                _recognizerclient.RecognizeAsyncCancel();
            }
            catch (Exception ex)
            {

            }
        }

        private void Settings()
        {
            cs.Show();
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


        public void Glaettung(int anzahl)
        {
            int summe = 0;
            if (savedValues.Count == anzahl)
            {
                for (int i = 0; i < anzahl; i++)
                {
                    summe += savedValues[i];
                }
                si.average = summe / anzahl;
                si.mod = (si.average % anzahl);
                paddlexlocal = (si.average - si.mod) + 15;
                pbx_uplocal.Location = new Point(paddlexlocal + 60, yValue);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tbx_PortClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                FileStream fs = new FileStream("ErrorLog.txt", FileMode.Open);
                StreamWriter writer = new StreamWriter(fs);

                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                    "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                writer.Close();
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
                using (StreamWriter sw = new StreamWriter("ErrorLog.txt"))
                {
                    sw.Write("irgendwas");
                    sw.Close();
                }
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
        private void btn_Start_Click(object sender, EventArgs e)
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

        private void btn_Connect_Click(object sender, EventArgs e)
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
        DebugWriter dw = new DebugWriter();
        int counter = -2;


        /*public void PaintMethod(int ballxnetwork, int ballynetwork, int paddlexnetwork, int paddlexlocal, int punkteBlau, int punkteGruen)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Ball.Location = new Point(ballxnetwork, ballynetwork);
            pbx_uplocal.Location = new Point(paddlexlocal, yValue);
            points1.Text = punkteBlau.ToString();
            points2.Text = punkteGruen.ToString();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            dw.PaintMethod(elapsedMs.ToString()+ " ms");
        }*/


        public void LogRequestInformation(string message)
        {
            string[] msg = message.Split('|');
            string xball = msg[0];
            string yball = msg[1];
            string xs = msg[2];
            string pointsBlue1 = msg[4];
            string pointsGreen1 = msg[3];

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
                pbx_downnetwork.Location = new Point(WertXnetwork, 703);
                Ball.Location = new Point(WertXnetworkball, WertYnetworkball);
                points1.Text = pointsGreen.ToString();
                points2.Text = pointsBlue.ToString();
                // dw.ReceiveDebug("ss "+ ":\\" + "l" + "|" + WertXnetwork + today + "counter" + counter);
            }
        }

        #endregion

        private void dgv_playfieldclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pbx_downnetwork_Click(object sender, EventArgs e)
        {

        }

        private void lsb_Information_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_deactivatefirewall_Click(object sender, EventArgs e)
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

        private void btn_activatefirewall_Click(object sender, EventArgs e)
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
        private void button1_Click_1(object sender, EventArgs e)
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

        public void StartGame()
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (rBFrequenz.Checked == true)
            {

                fi.CalculateData();
                positionValue = fi.CalculatePaddleLocationX(cs.FrequenzSetting());

                if (positionValue < 12)
                {
                    positionValue = 12;
                }
                if (positionValue > 1167)
                {
                    positionValue = 1167;
                }

                pbx_uplocal.Location = new Point(positionValue + 60, 65);
            }

            if (rBSound.Checked == true)
            {
                double frac = si.audioValueLast / si.audioValueMax;
                if (cs.tbEmpfindlichkeit.Value == 1)
                {
                    positionValue = (int)(((frac * 3) * 668)) - 2;
                    lblFineTuning.Text = "Empfindlichkeit: wenig";

                }
                else if (cs.tbEmpfindlichkeit.Value == 2)
                {
                    positionValue = (int)(((frac * 5) * 668)) - 3;
                    lblFineTuning.Text = "Empfindlichkeit: mittel";

                }
                else if (cs.tbEmpfindlichkeit.Value == 3)
                {
                    positionValue = (int)(((frac * 8) * 668)) - 5;
                    lblFineTuning.Text = "Empfindlichkeit: hoch";

                }
                if (cs.tbGlättungsstufe.Value == 1)
                {
                    wertGlaettung = 3;
                    Glaettung(wertGlaettung);
                    lblGlaettung.Text = "Glättungsstufe: 1";
                }
                if (cs.tbGlättungsstufe.Value == 2)
                {
                    wertGlaettung = 4;
                    Glaettung(wertGlaettung);
                    lblGlaettung.Text = "Glättungsstufe: 2";
                }
                if (cs.tbGlättungsstufe.Value == 3)
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
                if (positionValue > 1300)
                {
                    positionValue = 1300;
                }
                savedValues.Add(positionValue);

                Glaettung(wertGlaettung);
            }

            ThreadStart processTaskThreadball = delegate { c.Send("move:\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X)); };
            new Thread(processTaskThreadball).Start();
        }

        private void cbAusblenden_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAusblenden.Checked == true)
            {

                lblFineTuning.Visible = false;
                lblGlaettung.Visible = false;

                lsb_Information.Visible = false;

                lblSchwierigkeit.Visible = false;
                btn_Start.Visible = false;
                btn_Connect.Visible = false;
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
                btnStart.Visible = true;
            }
        }

        private void tbGlaettung_Scroll(object sender, EventArgs e)
        {

        }

        private void tbFineTuning_Scroll(object sender, EventArgs e)
        {

        }

        private void lblGlaettung_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ServerStart_Click(object sender, EventArgs e)
        {

        }

        private void lbl_PortServer_Click(object sender, EventArgs e)
        {

        }

        private void lbl_IPServer_Click(object sender, EventArgs e)
        {

        }

        private void tbx_IPServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_PortServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Discovery_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Client_Click(object sender, EventArgs e)
        {

        }

        private void tbx_IPClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_PortClient_Click(object sender, EventArgs e)
        {

        }

        private void lbl_IPClient_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ClientConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnWerteAufzeichnen_Click(object sender, EventArgs e)
        {
            ExportToTxt("savePong.txt");
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            cs.ShowDialog();
            panel1.BackColor = Color.Orange;
            panel2.BackColor = Color.Orange;
            panel3.BackColor = Color.Orange;
            panel4.BackColor = Color.Orange;
            panel5.BackColor = Color.Orange;
            panel6.BackColor = Color.Orange;
            panel7.BackColor = Color.Orange;
            panel8.BackColor = Color.Orange;
        }

        private void tbBallSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void lblSchwierigkeit_Click(object sender, EventArgs e)
        {

        }

        private void tbSchwierigkeit_Scroll(object sender, EventArgs e)
        {

        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
        }

        private void rBFrequenz_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rBFrequenz_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void rbKeyboard_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbKeyboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                WertXlocal += 25;
                pbx_uplocal.Location = new Point(WertXlocal, 50);
                ThreadStart processTaskThreadball = delegate { c.Send("move:\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X)); };
                new Thread(processTaskThreadball).Start();

            }
            if (e.KeyCode == Keys.Left)
            {
                WertXlocal -= 25;
                pbx_uplocal.Location = new Point(WertXlocal, 50);
                ThreadStart processTaskThreadball = delegate { c.Send("move:\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X)); };
                new Thread(processTaskThreadball).Start();
            }
        }

        private void dgv_playfieldclient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                WertXlocal += 25;
                pbx_uplocal.Location = new Point(WertXlocal, 50);
                ThreadStart processTaskThreadball = delegate { c.Send("move:\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X)); };
                new Thread(processTaskThreadball).Start();

            }
            if (e.KeyCode == Keys.Left)
            {
                WertXlocal -= 25;
                pbx_uplocal.Location = new Point(WertXlocal, 50);
                ThreadStart processTaskThreadball = delegate { c.Send("move:\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X)); };
                new Thread(processTaskThreadball).Start();
            }
        }
        private void ClientForms_Activated(object sender, EventArgs e)
        {
          ActivateClientListener();
        }

        private void ClientForms_Deactivate(object sender, EventArgs e)
        {
            CancelClientListener();
        }
    }
}

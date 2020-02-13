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
using MOVE.AudioLayer;
using MOVE.Core;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;
using NAudio.Wave;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Globalization;
using System.Configuration;

namespace MOVE.Server.Debug.Formular
{
    public partial class SinglePlayerForms : Form
    {
        #region Variablen
        SpeechRecognitionEngine _recognizergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        ErrorLogWriter elw = new ErrorLogWriter();
        FrequenzInput fi = new FrequenzInput();
        private static Random rnd = new Random();
        private static double soundValueOne = 0;
        private static double soundValueTwo = 0;
        private static int audioCount = 0;
        private static int samplingRate = 44100;
        private static int bufferSize = 2048;
        const int yValue = 663;
        List<int> savedValues = new List<int>();
        int positionValue = 0;
        int wertGlaettung = 3;
        int playerScore;
        int average;
        int mod;
        int summe = 0;
        int WertXLocal = 70;
        public int speed_left = 4;
        public int speed_top = 4;
        double player = 0;
        int lifes = 5;
        int speechmodulevalue;
        int speechvalue;
        #endregion


        public  SinglePlayerForms()
        {
            InitializeComponent();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            int s = Convert.ToInt32(screenHeight);
            double zahl = (7000 / 1080) * s;
            player = zahl / 10;
            Control.CheckForIllegalCrossThreadCalls = false;
            var waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(samplingRate, 1);
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.BufferMilliseconds = (int)((double)bufferSize / (double)samplingRate * 1000.0);
            waveIn.StartRecording();
            fi.Start();
            lblLifes.Text = "Leben: " + lifes.ToString();
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
        public void DefaultListenerGerman()
        {
            try
            {
                _recognizergerman.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandssingleplayerform.txt")));
                gb.Culture = new CultureInfo("de-DE");
                Grammar g = new Grammar(gb);
                _recognizergerman.LoadGrammar(g);
                _recognizergerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSinglePlayerFormGerman_SpeechRecognized);
                _recognizergerman.RecognizeAsync(RecognizeMode.Multiple);
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
                _recognizerenglish.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandssingleplayerform.txt")));
                gb.Culture = new CultureInfo("en-GB");
                Grammar g = new Grammar(gb);
                _recognizerenglish.LoadGrammar(g);
                _recognizerenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSinglePlayerFormEnglish_SpeechRecognized);
                _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }
        public void DefaultSinglePlayerFormGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if(speech=="Start")
            {
                Start();
            }
            if(speech=="Spieleinstellungen")
            {
                Settings();
            }
            if(speech=="Sound")
            {
                rBSound.Checked = true;
                rBFrequenz.Checked = false;
                rbKeyboard.Checked = false;
            }
            if (speech == "Frequenz")
            {
                rBSound.Checked = false;
                rBFrequenz.Checked = true;
                rbKeyboard.Checked = false;
            }
            if (speech == "Tastatur")
            {
                rBSound.Checked = false;
                rBFrequenz.Checked = false;
                rbKeyboard.Checked = true;
            }
            if(speech=="Menü ausblenden")
            {
                //cbAusblenden.Checked = true;
            }
            if (speech == "Menü einblenden")
            {
                //cbAusblenden.Checked = false;
            }
            if (speech == "Welche Befehle gibt es?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineGerman\\commandssingleplayerform.txt");
                h.ShowDialog();
            }

        }
    
    public void DefaultSinglePlayerFormEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
            string speech = e.Result.Text;
            if (speech == "start")
            {
                Start();
            }
            if (speech == "settings")
            {
                Settings();
            }
            if (speech == "sound")
            {
                rBSound.Checked = true;
                rBFrequenz.Checked = false;
                rbKeyboard.Checked = false;
            }
            if (speech == "frequency")
            {
                rBSound.Checked = false;
                rBFrequenz.Checked = true;
                rbKeyboard.Checked = false;
            }
            if (speech == "keyboard")
            {
                rBSound.Checked = false;
                rBFrequenz.Checked = false;
                rbKeyboard.Checked = true;
            }
            if (speech == "disable menu")
            {
                //cbAusblenden.Checked = true;
            }
            if (speech == "activate menu")
            {
               //cbAusblenden.Checked = false;
            }
            if (speech == "Which commands are avaiable?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineEnglish\\commandssingleplayerform.txt");
                h.ShowDialog();
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
            if (max > soundValueOne)
            {
                soundValueOne = (double)max;
            }
            soundValueTwo = max;
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
                // Spiel auf WPF umbauen - 3EIC
                // Recognize - Christoph

                // neue Ziele:
                // 
                pbx_downlocal.Location = new Point((average - mod) + 30, (int)player);
                savedValues.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dgv_playfieldclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        ServerSettings ss = new ServerSettings();

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void tbGlaettung_Scroll(object sender, EventArgs e)
        {

        }

        List<int> auswertungsWerte = new List<int>();

        private void cbAusblenden_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (rBFrequenz.Checked == true)
            {
                fi.CalculateData(ss.GetCalSate());

                positionValue = fi.CalculatePaddleLocationX(ss.FrequenzSetting(), ss.FrequenzThreshold());

                if (positionValue < 0)
                {
                    positionValue = 0;
                }
                if (positionValue > 1350)
                {
                    positionValue = 1350;
                }

                pbx_downlocal.Location = new Point(positionValue + 60, (int)player);
            }
            if (rBSound.Checked == true)
            {
                double frac = soundValueTwo / soundValueOne;
                if (ss.tbempfindlichkeit.Value == 1)
                {
                    positionValue = (int)(((frac * 3) * 668)) - 2;

                }
                if (ss.tbempfindlichkeit.Value == 2)
                {
                    positionValue = (int)(((frac * 5) * 668)) - 3;

                }
                if (ss.tbempfindlichkeit.Value == 3)
                {
                    positionValue = (int)(((frac * 8) * 668)) - 5;

                }

                if (ss.tbGlättung.Value == 1)
                {
                    wertGlaettung = 3;
                    Glaettung(wertGlaettung);
                }
                if (ss.tbGlättung.Value == 2)
                {
                    wertGlaettung = 4;
                    Glaettung(wertGlaettung);
                }
                if (ss.tbGlättung.Value == 3)
                {
                    wertGlaettung = 6;
                    Glaettung(wertGlaettung);
                }
                //double newfrac = Math.Round(frac, 0, MidpointRounding.AwayFromZero);
                if (positionValue < 70)
                {
                    positionValue = 70;
                }
                if (positionValue > 1300)
                {
                    positionValue = 1300;
                }
                savedValues.Add(positionValue);
                Glaettung(wertGlaettung);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Ball.Left += speed_left;
            Ball.Top += speed_top;

            if (pbx_downlocal.Bounds.IntersectsWith(Ball.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y - 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject1.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject1.Visible = false;
                singlePlayerObject1.Size = new Size(0, 0);
                singlePlayerObject1.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject2.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject2.Visible = false;
                singlePlayerObject2.Size = new Size(0, 0);
                singlePlayerObject2.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject3.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject3.Visible = false;
                singlePlayerObject3.Size = new Size(0, 0);
                singlePlayerObject3.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject4.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject4.Visible = false;
                singlePlayerObject4.Size = new Size(0, 0);
                singlePlayerObject4.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject5.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject5.Visible = false;
                singlePlayerObject5.Size = new Size(0, 0);
                singlePlayerObject5.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject6.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject6.Visible = false;
                singlePlayerObject6.Size = new Size(0, 0);
                singlePlayerObject6.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject7.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject7.Visible = false;
                singlePlayerObject7.Size = new Size(0, 0);
                singlePlayerObject7.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject8.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject8.Visible = false;
                singlePlayerObject8.Size = new Size(0, 0);
                singlePlayerObject8.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject10.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject10.Visible = false;
                singlePlayerObject10.Size = new Size(0, 0);
                singlePlayerObject10.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject11.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject11.Visible = false;
                singlePlayerObject11.Size = new Size(0, 0);
                singlePlayerObject11.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject12.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject12.Visible = false;
                singlePlayerObject12.Size = new Size(0, 0);
                singlePlayerObject12.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject9.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                singlePlayerObject9.Visible = false;
                singlePlayerObject9.Size = new Size(0, 0);
                singlePlayerObject9.Location = new Point(1650, 587);
                UpdateScore();
            }
            if (singlePlayerObject1.Visible == false && singlePlayerObject2.Visible == false && singlePlayerObject3.Visible == false && singlePlayerObject4.Visible == false && singlePlayerObject5.Visible == false && singlePlayerObject6.Visible == false && singlePlayerObject7.Visible == false && singlePlayerObject8.Visible == false && singlePlayerObject9.Visible == false && singlePlayerObject10.Visible == false && singlePlayerObject11.Visible == false && singlePlayerObject12.Visible == false)
            {
                Ball.Location = new Point(179, 134);
                singlePlayerObject1.Size = new Size(247, 33);
                singlePlayerObject1.Location = new Point(38, 32);
                singlePlayerObject2.Size = new Size(247, 33);
                singlePlayerObject2.Location = new Point(38, 73);
                singlePlayerObject3.Size = new Size(247, 33);
                singlePlayerObject3.Location = new Point(293, 32);
                singlePlayerObject4.Size = new Size(247, 33);
                singlePlayerObject4.Location = new Point(293, 73);
                singlePlayerObject5.Size = new Size(247, 33);
                singlePlayerObject5.Location = new Point(548, 32);
                singlePlayerObject6.Size = new Size(247, 33);
                singlePlayerObject6.Location = new Point(548, 73);
                singlePlayerObject7.Size = new Size(247, 33);
                singlePlayerObject7.Location = new Point(803, 32);
                singlePlayerObject8.Size = new Size(247, 33);
                singlePlayerObject8.Location = new Point(803, 73);
                singlePlayerObject9.Size = new Size(247, 33);
                singlePlayerObject9.Location = new Point(1058, 32);
                singlePlayerObject10.Size = new Size(247, 33);
                singlePlayerObject10.Location = new Point(1058, 73);
                singlePlayerObject11.Size = new Size(247, 33);
                singlePlayerObject11.Location = new Point(1313, 32);
                singlePlayerObject12.Size = new Size(247, 33);
                singlePlayerObject12.Location = new Point(1313, 73);
                singlePlayerObject1.Visible = true;
                singlePlayerObject2.Visible = true;
                singlePlayerObject3.Visible = true;
                singlePlayerObject4.Visible = true;
                singlePlayerObject5.Visible = true;
                singlePlayerObject6.Visible = true;
                singlePlayerObject7.Visible = true;
                singlePlayerObject8.Visible = true;
                singlePlayerObject9.Visible = true;
                singlePlayerObject10.Visible = true;
                singlePlayerObject11.Visible = true;
                singlePlayerObject12.Visible = true;

            }
            // Berührung des Balls mit dem oberen Schläger
            /*if (Ball.Top <= pbx_upnetwork.Bottom && Ball.Top >= pbx_upnetwork.Top && Ball.Left >= pbx_upnetwork.Left && Ball.Right <= pbx_upnetwork.Right)
            {

                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;

            }*/
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
                lifes--;
                lblLifes.Text = "Leben: " + lifes.ToString();
                if (lifes != 0)
                {
                    Ball.Location = new Point(179, 154);
                    Ball.Visible = true;
                    timer1.Enabled = true;
                }
                if (lifes == 0)
                {
                    HighscoreForms hf = new HighscoreForms();
                    hf.SetPlayerScore(playerScore);
                    hf.ShowDialog();
                    this.Close();
                }
            }
            if (Ball.Top <= dgv_playfieldclient.Top)
            {
                speed_top = -speed_top;
            }
        }

        private void btn_Start_Click_1(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            btn_Start.Enabled = false;
            timer1.Enabled = true;
            timer2.Enabled = true;
            lifes = 5;

        }
        private void DesignChangesGerman()
        {

        }
        private void DesignChangesEnglish()
        {
            btnSettings.Text = "Settings";
            btn_Start.Text = "Start";
            rBSound.Text = "Sound";
            rBFrequenz.Text = "Frequency";
            rbKeyboard.Text = "Keyboard";
            lblLifes.Text = "Lives";
            lbl_Gamer.Text = "Singleplayer";
        }
        private void Settings()
        {
            ss.ShowDialog();
            panel1.BackColor = Color.Orange;
            panel2.BackColor = Color.Orange;
            panel3.BackColor = Color.Orange;
            panel4.BackColor = Color.Orange;
            panel5.BackColor = Color.Orange;
            panel6.BackColor = Color.Orange;
            panel7.BackColor = Color.Orange;
            panel8.BackColor = Color.Orange;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings();

        }

        private void UpdateScore()
        {
            playerScore++;
            points2.Text = playerScore.ToString();
        }

        private void SinglePlayerForms_Load(object sender, EventArgs e)
        {

        }

        private void points2_Click(object sender, EventArgs e)
        {

        }

        public void CancelDefaultGermanListener()
        {
            try
            {
                _recognizergerman.RecognizeAsyncStop();
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
                _recognizergerman.RecognizeAsync(RecognizeMode.Multiple);
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
                _recognizerenglish.RecognizeAsyncStop();
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
                _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        private void SinglePlayerForms_Activated(object sender, EventArgs e)
        {
            if (speechvalue == 0)
            {
                ActivateDefaultGermanListener();
            }
            else if (speechvalue == 1)
            {
                ActivateDefaultEnglishListener();
            }
            if (btn_Start.Enabled == false)
            {
                startBall();
            }
        }

        private void SinglePlayerForms_Deactivate(object sender, EventArgs e)
        {
            if (speechvalue == 0)
            {
                CancelDefaultGermanListener();
            }
            else if (speechvalue == 1)
            {
                CancelDefaultEnglishListener();
            }
            pauseBall();
        }

        private void pauseBall()
        {
            timer1.Stop();
        }

        private void startBall()
        {
            timer1.Start();
        }

        private void dgv_playfieldclient_KeyDown(object sender, KeyEventArgs e)
        {
            rbKeyboard.Checked = true;
            try
            {
                
                if (e.KeyCode == Keys.Right)
                {
                    timer2.Enabled = false;
                    WertXLocal += 25;
                    if (WertXLocal > 1350)
                    {
                        WertXLocal = 1350;
                    }
                    pbx_downlocal.Location = new Point(WertXLocal, (int)player);
                }

                if (e.KeyCode == Keys.Left)
                {
                    timer2.Enabled = false;
                    WertXLocal -= 25;
                    if (WertXLocal < 70)
                    {
                        WertXLocal = 70;
                    }
                    pbx_downlocal.Location = new Point(WertXLocal, (int)player);
                }
            }
            catch (Exception ex)
            {
                //elw.WriteErrorLog(ex.ToString());
            }
        }

        private void Lbl_Gamer_Click(object sender, EventArgs e)
        {

        }

        private void rBFrequenz_CheckedChanged(object sender, EventArgs e)
        {

        }
        /*/
private void cbAusblenden_CheckedChanged(object sender, EventArgs e)
{
if (cbAusblenden.Checked == true)
{

lblFineTuning.Visible = false;
lblGlaettung.Visible = false;
btnSettings.Visible = false;
lblSchwierigkeit.Visible = false;
btn_Start.Visible = false;

lblBallSpeed.Visible = false;

}
if (cbAusblenden.Checked == false)
{
lblFineTuning.Visible = true;
lblGlaettung.Visible = true;
lblSchwierigkeit.Visible = true;
btn_Start.Visible = true;
btnSettings.Visible = true;
lblBallSpeed.Visible = true;
}
}
/*/
    }
}

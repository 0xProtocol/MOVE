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

namespace MOVE.Server.Debug.Formular
{
    public partial class SinglePlayerForms : Form
    {
        #region Variablen
        TcpService ts;
        Thread scanThread = null;
        private static Random rnd = new Random();
        private static double audioValueMax = 0;
        private static double audioValueLast = 0;
        private static int audioCount = 0;
        private static int RATE = 44100;
        private static int BUFFER_SAMPLES = 2048;
        const int yValue = 663;
        List<int> savedValues = new List<int>();
        int positionValue = 0;
        int wertGlaettung = 3;
        int punkteSpieler;
        int average;
        int mod;
        int summe = 0;
        public int speed_left = 4;
        public int speed_top = 4;
        #endregion


        public SinglePlayerForms()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            var waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(RATE, 1);
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.BufferMilliseconds = (int)((double)BUFFER_SAMPLES / (double)RATE * 1000.0);
            waveIn.StartRecording();
            //this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

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
                // Spiel auf WPF umbauen - 3EIC
                // Recognize - Christoph

                // neue Ziele:
                // 
                pbx_downlocal.Location = new Point((average - mod) + 15, yValue);
                savedValues.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /*private void dgv_playfieldServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                WertXlocal += 1;
                pbx_downlocal.Location = new Point(WertXlocal, 400);

            }
            if (e.KeyCode == Keys.Left)
            {
                WertXlocal -= 1;
                pbx_downlocal.Location = new Point(WertXlocal, 400);
            }
        }*/

        private void dgv_playfieldclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        ServerSettings ss = new ServerSettings();

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void lblGlaettung_Click(object sender, EventArgs e)
        {

        }

        private void tbGlaettung_Scroll(object sender, EventArgs e)
        {

        }

        List<int> auswertungsWerte = new List<int>();

        private void cbAusblenden_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbAusblenden.Checked == true)
            {

                lblFineTuning.Visible = false;
                lblGlaettung.Visible = false;

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

                lblBallSpeed.Visible = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
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
            if (positionValue > 1300)
            {
                positionValue = 1300;
            }
            savedValues.Add(positionValue);
            Glaettung(wertGlaettung);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball.Left += speed_left;
            Ball.Top += speed_top;

            if (pbx_downlocal.Bounds.IntersectsWith(Ball.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y - 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject1.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject1.Visible = false;
                singlePlayerObject1.Size = new Size(0, 0);
                singlePlayerObject1.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject2.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject2.Visible = false;
                singlePlayerObject2.Size = new Size(0, 0);
                singlePlayerObject2.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject3.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject3.Visible = false;
                singlePlayerObject3.Size = new Size(0, 0);
                singlePlayerObject3.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject4.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject4.Visible = false;
                singlePlayerObject4.Size = new Size(0, 0);
                singlePlayerObject4.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject5.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject5.Visible = false;
                singlePlayerObject5.Size = new Size(0, 0);
                singlePlayerObject5.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject6.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject6.Visible = false;
                singlePlayerObject6.Size = new Size(0, 0);
                singlePlayerObject6.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject7.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject7.Visible = false;
                singlePlayerObject7.Size = new Size(0, 0);
                singlePlayerObject7.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject8.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject8.Visible = false;
                singlePlayerObject8.Size = new Size(0, 0);
                singlePlayerObject8.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject10.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject10.Visible = false;
                singlePlayerObject10.Size = new Size(0, 0);
                singlePlayerObject10.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject11.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject11.Visible = false;
                singlePlayerObject11.Size = new Size(0, 0);
                singlePlayerObject11.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject12.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject12.Visible = false;
                singlePlayerObject12.Size = new Size(0, 0);
                singlePlayerObject12.Location = new Point(1650, 587);

            }
            if (Ball.Bounds.IntersectsWith(singlePlayerObject9.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 10);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
                punkteSpieler++;
                points2.Text = punkteSpieler.ToString();
                singlePlayerObject9.Visible = false;
                singlePlayerObject9.Size = new Size(0, 0);
                singlePlayerObject9.Location = new Point(1650, 587);

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
                Ball.Location = new Point(179, 134);
                Ball.Visible = true;
                timer1.Enabled = true;
            }
            if (Ball.Top <= dgv_playfieldclient.Top)
            {
                speed_top = -speed_top;

            }
        }

        private void btn_Start_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ss.ShowDialog();
        }
    }
}

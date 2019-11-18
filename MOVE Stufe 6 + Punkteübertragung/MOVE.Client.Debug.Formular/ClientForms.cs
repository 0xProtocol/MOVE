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

namespace MOVE.Client.Debug.Formular
{
    public partial class ClientForms : Form,IServiceLogger
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
        Action<string> logRequestInformation;
        Action<string> logServiceInformation;
        Thread scanThread = null;
        private static Random rnd = new Random();
        const int yValue = 35;
        public List<int> savedValues = new List<int>();
        public int positionValue = 0;
        public int wertGlaettung = 3;
        public string output;
        SoundInput si = new SoundInput();
        FrequenzInput fi = new FrequenzInput();
        #endregion

        public ClientForms()
        {
            InitializeComponent();
            logRequestInformation = new Action<string>(LogRequestInformation);
            logServiceInformation = new Action<string>(LogServiceinformation);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            si.Loading();
            fi.Start();

        }


        int paddlexlocal;

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
                paddlexlocal = (si.average - si.mod) +15;
                pbx_uplocal.Location = new Point(paddlexlocal, yValue);
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
                for(int i = 0; i < savedValues.Count; i++)
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

        /*private void dgv_playfieldclient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                WertXlocal += 1;
                pbx_uplocal.Location = new Point(WertXlocal, 50);
                c.Send(Convert.ToString(WertXlocal));

            }
            if (e.KeyCode == Keys.Left)
            {
                WertXlocal -= 1;
                pbx_uplocal.Location = new Point(WertXlocal, 50);
                c.Send(Convert.ToString(WertXlocal));
            }
        }*/

      

        private void tbx_PortClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  string value = lsb_discover.SelectedItem.ToString();
            //string[] split = value.Split(';');
        }
        string today = "Minute:" + System.DateTime.Now.Minute.ToString() + "Second:" + System.DateTime.Now.Second.ToString() + "mm:" + System.DateTime.Now.Millisecond.ToString();
        private void btn_Start_Click(object sender, EventArgs e)
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

        private void btn_Connect_Click(object sender, EventArgs e)
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
          //  string pointsBlue1 = msg[4];
           // string pointsGreen1 = msg[3];

            if (pbx_uplocal.InvokeRequired)
            {
                pbx_downnetwork.Invoke(logRequestInformation, message);
               // Ball.Invoke(logRequestInformation, message);
                WertXnetworkball = Convert.ToInt32(msg[0]);
                WertYnetworkball = Convert.ToInt32(msg[1]);
                WertXnetwork = Convert.ToInt32(msg[2]);
                //pointsBlue = Convert.ToInt32(msg[4]);
                //pointsGreen = Convert.ToInt32(msg[3]);
            }
            else
            {
                //counter++;
                pbx_downnetwork.Location = new Point(WertXnetwork, 663);
                Ball.Location = new Point(WertXnetworkball, WertYnetworkball);
               // points1.Text = pointsGreen.ToString();
                //points2.Text = pointsBlue.ToString();
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
            timer2.Enabled = true;

        }
        ClientSettings cs = new ClientSettings();
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            // int xvalue = fi.PlotLatestData(pbx_uplocal);
            // pbx_uplocal.Location = new Point(xvalue, 35);
            //fi.CalculateData(pbx_uplocal);
            if (rBFrequenz.Checked == true)
            {
                fi.CalculateData();

                positionValue = fi.CalculatePaddleLocationX();

                if (positionValue < 12)
                {
                    positionValue = 12;
                }
                if (positionValue > 1300)
                {
                    positionValue = 1300;
                }

                pbx_uplocal.Location = new Point(positionValue, 30);
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
                //paddle.Location = new Point(positionValue, 360);

                Glaettung(wertGlaettung);
            }
                      
            lblAnzeige1.Text = "Position: " + Convert.ToString(pbx_uplocal.Location.X);
            //  ThreadStart processTaskThread = delegate { c.Send(":\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X)); };
            //  new Thread(processTaskThread).Start();
            ThreadStart processTaskThreadball = delegate { c.Send(":\\" + "l" + "|"+ Convert.ToString(pbx_uplocal.Location.X)); };
            new Thread(processTaskThreadball).Start();
            //c.Send(":\\" + "l" + "|" + Convert.ToString(pbx_uplocal.Location.X));
            lblAnzeige2.Text = "Position: " + Convert.ToString(pbx_downnetwork.Location.X);
        }

        private void cbAusblenden_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAusblenden.Checked == true)
            { 

                lblAnzeige1.Visible = false;
                lblAnzeige2.Visible = false;
                lblBallPosition.Visible = false;
                lblFineTuning.Visible = false;
                lblGlaettung.Visible = false;

                lsb_Information.Visible = false;
            
                pause_txt.Visible = false;
                lblSchwierigkeit.Visible = false;
                btn_Start.Visible = false;
                btn_Connect.Visible = false;
                btnStart.Visible = false;
            }
            if(cbAusblenden.Checked == false)
            {

                lblAnzeige1.Visible = true;
                lblAnzeige2.Visible = true;
                lblBallPosition.Visible = true;
                lblFineTuning.Visible = true;
                lblGlaettung.Visible = true;

                lsb_Information.Visible = true;

                pause_txt.Visible = true;
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
    }
}

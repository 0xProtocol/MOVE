using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOVE.Server.Debug.Formular
{
    public partial class HighscoreForms : Form
    {
        ScoreManager sm = ScoreManager.GetInstance();
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();
        #region Variablen
        int value = 0;
        #endregion
        public HighscoreForms()
        {
            InitializeComponent();
            LoadScore();
            DefaultListener();
        }
        #region Speech Recognition
        private void DefaultListener()
        {
            try
            {

                _recognizer.SetInputToDefaultAudioDevice();
                _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandshighscoreform.txt")))));
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
              // elw.WriteErrorLog(ex.Message);
            }
        }
        public void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Bestätigen")
            {
                Bestätige();
            }
            if (speech == "Schließen")
            {
                this.Close();
            }
            if(speech=="Der erste Spieler")
            {
                lsvScores.SelectedItems.Clear();
                value = 0;
                lsvScores.Items[value].Selected = true;
            }
            if (speech == "Der zweite Spieler")
            {
                lsvScores.SelectedItems.Clear();
                value = 1;
                lsvScores.Items[value].Selected = true;
            }
            if (speech == "Der dritte Spieler")
            {
                lsvScores.SelectedItems.Clear();
                value = 2;
                lsvScores.Items[value].Selected = true;
            }
            if (speech=="Ein Spieler weiter")
            {
                if (lsvScores.SelectedItems.Count > 0)
                {
                    value = lsvScores.Items.IndexOf(lsvScores.SelectedItems[0]) + 1;
                }
                if (value < lsvScores.Items.Count)
                {
                    lsvScores.SelectedItems.Clear();
                    lsvScores.Items[value].Selected = true;
                }
                else
                {
                    value--;
                    com.SpeakAsync("Sie sind bereits beim letzten Spieler angekommen");
                }
            }

        }
        #endregion
        public void SetPlayerScore(int playerscore)
        {
            tbxScore.Text = Convert.ToString(playerscore);
        }

        private void HighscoreForms_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Bestätige();            
        }
        private void Bestätige()
        {

            btnInsert.Enabled = false;
            if (tbxName.Text == "")
            {
                MessageBox.Show("Bitte geben Sie einen Spielernamen ein");
                btnInsert.Enabled = true;
                panel2.BackColor = Color.Orange;
                panel3.BackColor = Color.Orange;
                panel4.BackColor = Color.Orange;
                panel5.BackColor = Color.Orange;
                panel6.BackColor = Color.Orange;
                panel7.BackColor = Color.Orange;
                panel8.BackColor = Color.Orange;
                panel9.BackColor = Color.Orange;
            }
            else if (tbxName.Text.Contains(';') == true)
            {
                MessageBox.Show("Bitte geben Sie einen Spielernamen ohne ';' ein");
                btnInsert.Enabled = true;
                panel2.BackColor = Color.Orange;
                panel3.BackColor = Color.Orange;
                panel4.BackColor = Color.Orange;
                panel5.BackColor = Color.Orange;
                panel6.BackColor = Color.Orange;
                panel7.BackColor = Color.Orange;
                panel8.BackColor = Color.Orange;
                panel9.BackColor = Color.Orange;
            }
            else
            {
                sm.SaveScoreToCSV(tbxName.Text, Convert.ToInt32(tbxScore.Text));
                LoadScore();
                panel2.BackColor = Color.Green;
                panel3.BackColor = Color.Green;
                panel4.BackColor = Color.Green;
                panel5.BackColor = Color.Green;
                panel6.BackColor = Color.Green;
                panel7.BackColor = Color.Green;
                panel8.BackColor = Color.Green;
                panel9.BackColor = Color.Green;
            }
        }
        //sm.SaveScoreToDB(tbxName.Text, tbxScore.Text);

        private void LoadScore()
        {
            sm.LoadScoreFromCSV();
            lsvScores.Items.Clear();
            foreach (Score s in sm.GetSortedScoreList())
            {
                ListViewItem lvi = new ListViewItem(s.PlayerName);
                lvi.SubItems.Add(s.Points.ToString());
                lvi.SubItems.Add(s.DateTime.ToString());
                lsvScores.Items.Add(lvi);
            }
        }

        private void lsvScores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbxName.Text = lsvScores.SelectedItems[0].Text;
            }
            catch (Exception)
            {

            }
            
        }

        private void lsvScores_Click(object sender, EventArgs e)
        {
            
        }
    }
}

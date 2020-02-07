using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        SpeechRecognitionEngine _recognizergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        SpeechSynthesizer com = new SpeechSynthesizer();
        #region Variablen
        int value = 0;
        int speechmodulevalue;
        int speechvalue;
        #endregion
        public HighscoreForms()
        {
            InitializeComponent();
            LoadScore();
            string language = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(language);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    DefaultListenerGerman();
                }
                if (speechvalue == 1)
                {
                    DefaultListenerEnglish();
                }
            }
        }
        #region Speech Recognition
        public void DefaultListenerGerman()
        {
            try
            {
                _recognizergerman.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandshighscoreform.txt")));
                gb.Culture = new CultureInfo("de-DE");
                Grammar g = new Grammar(gb);
                _recognizergerman.LoadGrammar(g);
                _recognizergerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultGerman_SpeechRecognized);
                _recognizergerman.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                //elw.WriteErrorLog(ex.Message);
            }
        }

        public void DefaultListenerEnglish()
        {
            try
            {
                _recognizerenglish.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandshighscoreform.txt")));
                gb.Culture = new CultureInfo("en-GB");
                Grammar g = new Grammar(gb);
                _recognizerenglish.LoadGrammar(g);
                _recognizerenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultEnglish_SpeechRecognized);
                _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
             //   elw.WriteErrorLog(ex.Message);
            }
        }
        public void DefaultGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
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
            if (speech == "Der erste Spieler")
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
            if (speech == "Ein Spieler weiter")
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
            if (speech == "Welche Befehle gibt es?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineGerman\\commandshighscoreform.txt");
                h.ShowDialog();
            }
        }
            public void DefaultEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                string speech = e.Result.Text;
                if (speech == "Confirm")
                {
                    Bestätige();
                }
                if (speech == "exit")
                {
                    this.Close();
                }
                if (speech == "the first player")
                {
                    lsvScores.SelectedItems.Clear();
                    value = 0;
                    lsvScores.Items[value].Selected = true;
                }
                if (speech == "the second player")
                {
                    lsvScores.SelectedItems.Clear();
                    value = 1;
                    lsvScores.Items[value].Selected = true;
                }
                if (speech == "the third player")
                {
                    lsvScores.SelectedItems.Clear();
                    value = 2;
                    lsvScores.Items[value].Selected = true;
                }
                if (speech == "one player further")
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
                    com.SelectVoice("Microsoft Hazel Desktop");
                    com.SpeakAsync("You have already arrived at the last player");
                    }
                }
            if (speech == "Which commands are avaiable?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineEnglish\\commandshighscoreform.txt");
                h.ShowDialog();
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

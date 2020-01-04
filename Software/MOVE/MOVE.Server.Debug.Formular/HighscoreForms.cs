using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOVE.Server.Debug.Formular
{
    public partial class HighscoreForms : Form
    {
        ScoreManager sm = ScoreManager.GetInstance();
        public HighscoreForms()
        {
            InitializeComponent();
            LoadScore();
        }

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
            btnInsert.Enabled = false;
            if (tbxName.Text == "")
            {
                MessageBox.Show("Bitte geben Sie einen Spielernamen ein");
                btnInsert.Enabled = true;
            }
            else
            {
                sm.SaveScoreToDB(tbxName.Text, tbxScore.Text);
                LoadScore();
            }   
        }

        private void LoadScore()
        {
            sm.LoadScoresFromDB();
            lsvScores.Items.Clear();
            foreach (Score s in sm.GetSortedScoreList())
            {
                ListViewItem lvi = new ListViewItem(s.PlayerName);
                lvi.SubItems.Add(s.Points.ToString());
                lsvScores.Items.Add(lvi);
            }
        }
    }
}

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

        }
    }
}

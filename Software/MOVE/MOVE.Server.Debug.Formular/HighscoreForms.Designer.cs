namespace MOVE.Server.Debug.Formular
{
    partial class HighscoreForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbxScore = new System.Windows.Forms.TextBox();
            this.lsvScores = new System.Windows.Forms.ListView();
            this.cSpielername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPunkte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblHighscoreMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 17F);
            this.label1.Location = new System.Drawing.Point(45, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Punkte:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbxScore
            // 
            this.tbxScore.Enabled = false;
            this.tbxScore.Location = new System.Drawing.Point(172, 146);
            this.tbxScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxScore.Name = "tbxScore";
            this.tbxScore.Size = new System.Drawing.Size(565, 22);
            this.tbxScore.TabIndex = 1;
            // 
            // lsvScores
            // 
            this.lsvScores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSpielername,
            this.cPunkte,
            this.cdatum});
            this.lsvScores.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lsvScores.HideSelection = false;
            this.lsvScores.Location = new System.Drawing.Point(45, 176);
            this.lsvScores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsvScores.Name = "lsvScores";
            this.lsvScores.Size = new System.Drawing.Size(800, 421);
            this.lsvScores.TabIndex = 6;
            this.lsvScores.UseCompatibleStateImageBehavior = false;
            this.lsvScores.View = System.Windows.Forms.View.Details;
            this.lsvScores.SelectedIndexChanged += new System.EventHandler(this.lsvScores_SelectedIndexChanged);
            this.lsvScores.Click += new System.EventHandler(this.lsvScores_Click);
            // 
            // cSpielername
            // 
            this.cSpielername.Text = "Spielername";
            this.cSpielername.Width = 292;
            // 
            // cPunkte
            // 
            this.cPunkte.Text = "Punkte";
            this.cPunkte.Width = 155;
            // 
            // cdatum
            // 
            this.cdatum.Text = "Datum";
            this.cdatum.Width = 178;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(172, 106);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(565, 22);
            this.tbxName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 17F);
            this.label2.Location = new System.Drawing.Point(45, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Spieler:";
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Rockwell", 7.8F);
            this.btnInsert.Location = new System.Drawing.Point(745, 106);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 63);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "Bestätigen";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Location = new System.Drawing.Point(28, 22);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(11, 590);
            this.panel7.TabIndex = 116;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(28, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(835, 10);
            this.panel2.TabIndex = 118;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(852, 23);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 588);
            this.panel3.TabIndex = 118;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(31, 603);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(831, 10);
            this.panel4.TabIndex = 119;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Location = new System.Drawing.Point(868, 7);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(11, 617);
            this.panel5.TabIndex = 119;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Red;
            this.panel6.Location = new System.Drawing.Point(12, 7);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(861, 10);
            this.panel6.TabIndex = 119;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Red;
            this.panel8.Location = new System.Drawing.Point(12, 617);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(865, 10);
            this.panel8.TabIndex = 120;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Red;
            this.panel9.Location = new System.Drawing.Point(12, 11);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(11, 610);
            this.panel9.TabIndex = 118;
            // 
            // lblHighscoreMessage
            // 
            this.lblHighscoreMessage.AutoSize = true;
            this.lblHighscoreMessage.Font = new System.Drawing.Font("Rockwell", 7.8F);
            this.lblHighscoreMessage.Location = new System.Drawing.Point(48, 52);
            this.lblHighscoreMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHighscoreMessage.Name = "lblHighscoreMessage";
            this.lblHighscoreMessage.Size = new System.Drawing.Size(246, 17);
            this.lblHighscoreMessage.TabIndex = 121;
            this.lblHighscoreMessage.Text = "Tragen Sie bitte Ihren Highscore ein:";
            // 
            // HighscoreForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(885, 634);
            this.Controls.Add(this.lblHighscoreMessage);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lsvScores);
            this.Controls.Add(this.tbxScore);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HighscoreForms";
            this.Text = "HighscoreForms";
            this.Load += new System.EventHandler(this.HighscoreForms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxScore;
        private System.Windows.Forms.ListView lsvScores;
        private System.Windows.Forms.ColumnHeader cSpielername;
        private System.Windows.Forms.ColumnHeader cPunkte;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ColumnHeader cdatum;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblHighscoreMessage;
    }
}
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbxScore
            // 
            this.tbxScore.Enabled = false;
            this.tbxScore.Location = new System.Drawing.Point(132, 101);
            this.tbxScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxScore.Name = "tbxScore";
            this.tbxScore.Size = new System.Drawing.Size(131, 22);
            this.tbxScore.TabIndex = 1;
            // 
            // lsvScores
            // 
            this.lsvScores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSpielername,
            this.cPunkte,
            this.columnHeader1});
            this.lsvScores.HideSelection = false;
            this.lsvScores.Location = new System.Drawing.Point(37, 133);
            this.lsvScores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsvScores.Name = "lsvScores";
            this.lsvScores.Size = new System.Drawing.Size(441, 244);
            this.lsvScores.TabIndex = 6;
            this.lsvScores.UseCompatibleStateImageBehavior = false;
            this.lsvScores.View = System.Windows.Forms.View.Details;
            this.lsvScores.SelectedIndexChanged += new System.EventHandler(this.lsvScores_SelectedIndexChanged);
            // 
            // cSpielername
            // 
            this.cSpielername.Text = "Spielername";
            this.cSpielername.Width = 160;
            // 
            // cPunkte
            // 
            this.cPunkte.Text = "Punkte";
            this.cPunkte.Width = 65;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Datum";
            this.columnHeader1.Width = 103;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(132, 69);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(131, 22);
            this.tbxName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Spielername:";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(380, 69);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 28);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "Eintragen";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Controls.Add(this.panel1);
            this.panel7.Location = new System.Drawing.Point(12, 11);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 438);
            this.panel7.TabIndex = 116;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 438);
            this.panel1.TabIndex = 117;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(15, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 10);
            this.panel2.TabIndex = 118;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(496, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 438);
            this.panel3.TabIndex = 118;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(18, 440);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(485, 10);
            this.panel4.TabIndex = 119;
            // 
            // HighscoreForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 461);
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
            this.panel7.ResumeLayout(false);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}
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
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbxScore
            // 
            this.tbxScore.Enabled = false;
            this.tbxScore.Location = new System.Drawing.Point(86, 38);
            this.tbxScore.Name = "tbxScore";
            this.tbxScore.Size = new System.Drawing.Size(99, 20);
            this.tbxScore.TabIndex = 1;
            // 
            // lsvScores
            // 
            this.lsvScores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSpielername,
            this.cPunkte,
            this.columnHeader1});
            this.lsvScores.HideSelection = false;
            this.lsvScores.Location = new System.Drawing.Point(15, 64);
            this.lsvScores.Name = "lsvScores";
            this.lsvScores.Size = new System.Drawing.Size(332, 199);
            this.lsvScores.TabIndex = 6;
            this.lsvScores.UseCompatibleStateImageBehavior = false;
            this.lsvScores.View = System.Windows.Forms.View.Details;
            this.lsvScores.SelectedIndexChanged += new System.EventHandler(this.lsvScores_SelectedIndexChanged);
            // 
            // cSpielername
            // 
            this.cSpielername.Text = "Spielername";
            this.cSpielername.Width = 269;
            // 
            // cPunkte
            // 
            this.cPunkte.Text = "Punkte";
            this.cPunkte.Width = 59;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(86, 12);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(99, 20);
            this.tbxName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Spielername:";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(272, 12);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "Eintragen";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Datum";
            this.columnHeader1.Width = 129;
            // 
            // HighscoreForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 272);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lsvScores);
            this.Controls.Add(this.tbxScore);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
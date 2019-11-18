namespace MOVE.Server.Debug.Formular
{
    partial class ServerForms
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgv_playfieldclient = new System.Windows.Forms.DataGridView();
            this.pbx_upnetwork = new System.Windows.Forms.PictureBox();
            this.pbx_downlocal = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblSchwierigkeit = new System.Windows.Forms.Label();
            this.lblGlaettung = new System.Windows.Forms.Label();
            this.lblBallPosition = new System.Windows.Forms.Label();
            this.lblBallSpeed = new System.Windows.Forms.Label();
            this.lblFineTuning = new System.Windows.Forms.Label();
            this.lblAnzeige2 = new System.Windows.Forms.Label();
            this.lblAnzeige1 = new System.Windows.Forms.Label();
            this.pause_txt = new System.Windows.Forms.Label();
            this.points2 = new System.Windows.Forms.Label();
            this.points1 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lsb_Information = new System.Windows.Forms.ListBox();
            this.lbl_Client = new System.Windows.Forms.Label();
            this.cbAusblenden = new System.Windows.Forms.CheckBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Ball = new System.Windows.Forms.PictureBox();
            this.btnWerteAufzeichnen = new System.Windows.Forms.Button();
            this.rBFrequenz = new System.Windows.Forms.RadioButton();
            this.rBSound = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_playfieldclient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_upnetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_downlocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_playfieldclient
            // 
            this.dgv_playfieldclient.BackgroundColor = System.Drawing.Color.Black;
            this.dgv_playfieldclient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_playfieldclient.Location = new System.Drawing.Point(12, 12);
            this.dgv_playfieldclient.Name = "dgv_playfieldclient";
            this.dgv_playfieldclient.Size = new System.Drawing.Size(1340, 580);
            this.dgv_playfieldclient.TabIndex = 1;
            this.dgv_playfieldclient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_playfieldclient_CellContentClick);
            this.dgv_playfieldclient.Click += new System.EventHandler(this.dgv_playfieldclient_Click);
            this.dgv_playfieldclient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_playfieldclient_KeyDown);
            // 
            // pbx_upnetwork
            // 
            this.pbx_upnetwork.BackColor = System.Drawing.Color.Blue;
            this.pbx_upnetwork.Location = new System.Drawing.Point(31, 30);
            this.pbx_upnetwork.Name = "pbx_upnetwork";
            this.pbx_upnetwork.Size = new System.Drawing.Size(185, 27);
            this.pbx_upnetwork.TabIndex = 3;
            this.pbx_upnetwork.TabStop = false;
            // 
            // pbx_downlocal
            // 
            this.pbx_downlocal.BackColor = System.Drawing.Color.Lime;
            this.pbx_downlocal.Location = new System.Drawing.Point(31, 539);
            this.pbx_downlocal.Name = "pbx_downlocal";
            this.pbx_downlocal.Size = new System.Drawing.Size(185, 27);
            this.pbx_downlocal.TabIndex = 4;
            this.pbx_downlocal.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblSchwierigkeit
            // 
            this.lblSchwierigkeit.AutoSize = true;
            this.lblSchwierigkeit.BackColor = System.Drawing.Color.Black;
            this.lblSchwierigkeit.ForeColor = System.Drawing.Color.Coral;
            this.lblSchwierigkeit.Location = new System.Drawing.Point(1359, 398);
            this.lblSchwierigkeit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSchwierigkeit.Name = "lblSchwierigkeit";
            this.lblSchwierigkeit.Size = new System.Drawing.Size(119, 13);
            this.lblSchwierigkeit.TabIndex = 49;
            this.lblSchwierigkeit.Text = "Schwierigkeit: Anfänger";
            // 
            // lblGlaettung
            // 
            this.lblGlaettung.AutoSize = true;
            this.lblGlaettung.BackColor = System.Drawing.Color.Black;
            this.lblGlaettung.ForeColor = System.Drawing.Color.Coral;
            this.lblGlaettung.Location = new System.Drawing.Point(1365, 339);
            this.lblGlaettung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGlaettung.Name = "lblGlaettung";
            this.lblGlaettung.Size = new System.Drawing.Size(87, 13);
            this.lblGlaettung.TabIndex = 47;
            this.lblGlaettung.Text = "Glättungsstufe: 1";
            this.lblGlaettung.Click += new System.EventHandler(this.lblGlaettung_Click);
            // 
            // lblBallPosition
            // 
            this.lblBallPosition.AutoSize = true;
            this.lblBallPosition.BackColor = System.Drawing.Color.Black;
            this.lblBallPosition.ForeColor = System.Drawing.Color.Coral;
            this.lblBallPosition.Location = new System.Drawing.Point(1357, 61);
            this.lblBallPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBallPosition.Name = "lblBallPosition";
            this.lblBallPosition.Size = new System.Drawing.Size(68, 13);
            this.lblBallPosition.TabIndex = 43;
            this.lblBallPosition.Text = "Position: 0, 0";
            // 
            // lblBallSpeed
            // 
            this.lblBallSpeed.AutoSize = true;
            this.lblBallSpeed.BackColor = System.Drawing.Color.Black;
            this.lblBallSpeed.ForeColor = System.Drawing.Color.Coral;
            this.lblBallSpeed.Location = new System.Drawing.Point(1364, 266);
            this.lblBallSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBallSpeed.Name = "lblBallSpeed";
            this.lblBallSpeed.Size = new System.Drawing.Size(154, 13);
            this.lblBallSpeed.TabIndex = 41;
            this.lblBallSpeed.Text = "Geschwindigkeit-Ball: Standard";
            // 
            // lblFineTuning
            // 
            this.lblFineTuning.AutoSize = true;
            this.lblFineTuning.BackColor = System.Drawing.Color.Black;
            this.lblFineTuning.ForeColor = System.Drawing.Color.Coral;
            this.lblFineTuning.Location = new System.Drawing.Point(1357, 129);
            this.lblFineTuning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFineTuning.Name = "lblFineTuning";
            this.lblFineTuning.Size = new System.Drawing.Size(84, 13);
            this.lblFineTuning.TabIndex = 39;
            this.lblFineTuning.Text = "Empfindlichkeit: ";
            // 
            // lblAnzeige2
            // 
            this.lblAnzeige2.AutoSize = true;
            this.lblAnzeige2.BackColor = System.Drawing.Color.Black;
            this.lblAnzeige2.ForeColor = System.Drawing.Color.Coral;
            this.lblAnzeige2.Location = new System.Drawing.Point(1357, 36);
            this.lblAnzeige2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnzeige2.Name = "lblAnzeige2";
            this.lblAnzeige2.Size = new System.Drawing.Size(56, 13);
            this.lblAnzeige2.TabIndex = 38;
            this.lblAnzeige2.Text = "Position: 0";
            // 
            // lblAnzeige1
            // 
            this.lblAnzeige1.AutoSize = true;
            this.lblAnzeige1.BackColor = System.Drawing.Color.Black;
            this.lblAnzeige1.ForeColor = System.Drawing.Color.Coral;
            this.lblAnzeige1.Location = new System.Drawing.Point(1357, 12);
            this.lblAnzeige1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnzeige1.Name = "lblAnzeige1";
            this.lblAnzeige1.Size = new System.Drawing.Size(56, 13);
            this.lblAnzeige1.TabIndex = 36;
            this.lblAnzeige1.Text = "Position: 0";
            // 
            // pause_txt
            // 
            this.pause_txt.AutoSize = true;
            this.pause_txt.BackColor = System.Drawing.Color.Black;
            this.pause_txt.ForeColor = System.Drawing.Color.White;
            this.pause_txt.Location = new System.Drawing.Point(1357, 209);
            this.pause_txt.Name = "pause_txt";
            this.pause_txt.Size = new System.Drawing.Size(43, 13);
            this.pause_txt.TabIndex = 35;
            this.pause_txt.Text = "Paused";
            // 
            // points2
            // 
            this.points2.AutoSize = true;
            this.points2.BackColor = System.Drawing.Color.Black;
            this.points2.Font = new System.Drawing.Font("Courier New", 60F);
            this.points2.ForeColor = System.Drawing.Color.Lime;
            this.points2.Location = new System.Drawing.Point(1234, 493);
            this.points2.Name = "points2";
            this.points2.Size = new System.Drawing.Size(85, 85);
            this.points2.TabIndex = 34;
            this.points2.Text = "0";
            // 
            // points1
            // 
            this.points1.AutoSize = true;
            this.points1.BackColor = System.Drawing.Color.Black;
            this.points1.Font = new System.Drawing.Font("Courier New", 60F);
            this.points1.ForeColor = System.Drawing.Color.Blue;
            this.points1.Location = new System.Drawing.Point(1234, 30);
            this.points1.Name = "points1";
            this.points1.Size = new System.Drawing.Size(85, 85);
            this.points1.TabIndex = 33;
            this.points1.Text = "0";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(1359, 514);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(100, 23);
            this.btn_Connect.TabIndex = 55;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click_1);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(1359, 543);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(100, 23);
            this.btn_Start.TabIndex = 60;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(653, 612);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(53, 23);
            this.btnStart.TabIndex = 69;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lsb_Information
            // 
            this.lsb_Information.FormattingEnabled = true;
            this.lsb_Information.Location = new System.Drawing.Point(12, 635);
            this.lsb_Information.Name = "lsb_Information";
            this.lsb_Information.Size = new System.Drawing.Size(266, 95);
            this.lsb_Information.TabIndex = 66;
            // 
            // lbl_Client
            // 
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.BackColor = System.Drawing.Color.Black;
            this.lbl_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.lbl_Client.ForeColor = System.Drawing.Color.Lime;
            this.lbl_Client.Location = new System.Drawing.Point(625, 690);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(132, 44);
            this.lbl_Client.TabIndex = 72;
            this.lbl_Client.Text = "Server";
            // 
            // cbAusblenden
            // 
            this.cbAusblenden.AutoSize = true;
            this.cbAusblenden.Location = new System.Drawing.Point(1362, 576);
            this.cbAusblenden.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbAusblenden.Name = "cbAusblenden";
            this.cbAusblenden.Size = new System.Drawing.Size(112, 17);
            this.cbAusblenden.TabIndex = 73;
            this.cbAusblenden.Text = "Menü Ausblenden";
            this.cbAusblenden.UseVisualStyleBackColor = true;
            this.cbAusblenden.CheckedChanged += new System.EventHandler(this.cbAusblenden_CheckedChanged);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(1358, 427);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(100, 23);
            this.btnSettings.TabIndex = 74;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Magenta;
            this.Ball.Location = new System.Drawing.Point(1109, 109);
            this.Ball.Margin = new System.Windows.Forms.Padding(2);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(38, 41);
            this.Ball.TabIndex = 76;
            this.Ball.TabStop = false;
            // 
            // btnWerteAufzeichnen
            // 
            this.btnWerteAufzeichnen.Location = new System.Drawing.Point(1359, 457);
            this.btnWerteAufzeichnen.Name = "btnWerteAufzeichnen";
            this.btnWerteAufzeichnen.Size = new System.Drawing.Size(83, 23);
            this.btnWerteAufzeichnen.TabIndex = 77;
            this.btnWerteAufzeichnen.Text = "Aufzeichnen";
            this.btnWerteAufzeichnen.UseVisualStyleBackColor = true;
            this.btnWerteAufzeichnen.Click += new System.EventHandler(this.btnWerteAufzeichnen_Click);
            // 
            // rBFrequenz
            // 
            this.rBFrequenz.AutoSize = true;
            this.rBFrequenz.Location = new System.Drawing.Point(1250, 651);
            this.rBFrequenz.Name = "rBFrequenz";
            this.rBFrequenz.Size = new System.Drawing.Size(69, 17);
            this.rBFrequenz.TabIndex = 82;
            this.rBFrequenz.TabStop = true;
            this.rBFrequenz.Text = "Frequenz";
            this.rBFrequenz.UseVisualStyleBackColor = true;
            // 
            // rBSound
            // 
            this.rBSound.AutoSize = true;
            this.rBSound.Location = new System.Drawing.Point(1250, 628);
            this.rBSound.Name = "rBSound";
            this.rBSound.Size = new System.Drawing.Size(56, 17);
            this.rBSound.TabIndex = 81;
            this.rBSound.TabStop = true;
            this.rBSound.Text = "Sound";
            this.rBSound.UseVisualStyleBackColor = true;
            // 
            // ServerForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 742);
            this.Controls.Add(this.rBFrequenz);
            this.Controls.Add(this.rBSound);
            this.Controls.Add(this.btnWerteAufzeichnen);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.cbAusblenden);
            this.Controls.Add(this.lbl_Client);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lsb_Information);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.lblSchwierigkeit);
            this.Controls.Add(this.lblGlaettung);
            this.Controls.Add(this.lblBallPosition);
            this.Controls.Add(this.lblBallSpeed);
            this.Controls.Add(this.lblFineTuning);
            this.Controls.Add(this.lblAnzeige2);
            this.Controls.Add(this.lblAnzeige1);
            this.Controls.Add(this.pause_txt);
            this.Controls.Add(this.points2);
            this.Controls.Add(this.points1);
            this.Controls.Add(this.pbx_downlocal);
            this.Controls.Add(this.pbx_upnetwork);
            this.Controls.Add(this.dgv_playfieldclient);
            this.Name = "ServerForms";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_playfieldclient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_upnetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_downlocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_playfieldclient;
        private System.Windows.Forms.PictureBox pbx_upnetwork;
        private System.Windows.Forms.PictureBox pbx_downlocal;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblSchwierigkeit;
        private System.Windows.Forms.Label lblGlaettung;
        private System.Windows.Forms.Label lblBallPosition;
        private System.Windows.Forms.Label lblBallSpeed;
        private System.Windows.Forms.Label lblFineTuning;
        private System.Windows.Forms.Label lblAnzeige2;
        private System.Windows.Forms.Label lblAnzeige1;
        private System.Windows.Forms.Label pause_txt;
        private System.Windows.Forms.Label points2;
        private System.Windows.Forms.Label points1;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lsb_Information;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.CheckBox cbAusblenden;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.Button btnWerteAufzeichnen;
        private System.Windows.Forms.RadioButton rBFrequenz;
        private System.Windows.Forms.RadioButton rBSound;
    }
}


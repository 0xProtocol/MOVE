﻿namespace MOVE.Server.Debug.Formular
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
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblSchwierigkeit = new System.Windows.Forms.Label();
            this.lblGlaettung = new System.Windows.Forms.Label();
            this.lblBallSpeed = new System.Windows.Forms.Label();
            this.lblFineTuning = new System.Windows.Forms.Label();
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
            this.rBFrequenz = new System.Windows.Forms.RadioButton();
            this.rBSound = new System.Windows.Forms.RadioButton();
            this.rbKeyboard = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.pbx_downlocal = new System.Windows.Forms.PictureBox();
            this.pbx_upnetwork = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_playfieldclient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_downlocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_upnetwork)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_playfieldclient
            // 
            this.dgv_playfieldclient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_playfieldclient.BackgroundColor = System.Drawing.Color.Black;
            this.dgv_playfieldclient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_playfieldclient.Location = new System.Drawing.Point(51, 41);
            this.dgv_playfieldclient.Name = "dgv_playfieldclient";
            this.dgv_playfieldclient.Size = new System.Drawing.Size(1340, 580);
            this.dgv_playfieldclient.TabIndex = 1;
            this.dgv_playfieldclient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_playfieldclient_CellContentClick);
            this.dgv_playfieldclient.Click += new System.EventHandler(this.dgv_playfieldclient_Click);
            this.dgv_playfieldclient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_playfieldclient_KeyDown);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblSchwierigkeit
            // 
            this.lblSchwierigkeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSchwierigkeit.AutoSize = true;
            this.lblSchwierigkeit.BackColor = System.Drawing.SystemColors.Control;
            this.lblSchwierigkeit.Font = new System.Drawing.Font("Courier New", 13.2F, System.Drawing.FontStyle.Bold);
            this.lblSchwierigkeit.ForeColor = System.Drawing.Color.Coral;
            this.lblSchwierigkeit.Location = new System.Drawing.Point(1049, 722);
            this.lblSchwierigkeit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSchwierigkeit.Name = "lblSchwierigkeit";
            this.lblSchwierigkeit.Size = new System.Drawing.Size(263, 21);
            this.lblSchwierigkeit.TabIndex = 49;
            this.lblSchwierigkeit.Text = "Schwierigkeit: Anfänger";
            // 
            // lblGlaettung
            // 
            this.lblGlaettung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGlaettung.AutoSize = true;
            this.lblGlaettung.BackColor = System.Drawing.SystemColors.Control;
            this.lblGlaettung.Font = new System.Drawing.Font("Courier New", 13.2F, System.Drawing.FontStyle.Bold);
            this.lblGlaettung.ForeColor = System.Drawing.Color.Coral;
            this.lblGlaettung.Location = new System.Drawing.Point(872, 722);
            this.lblGlaettung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGlaettung.Name = "lblGlaettung";
            this.lblGlaettung.Size = new System.Drawing.Size(197, 21);
            this.lblGlaettung.TabIndex = 47;
            this.lblGlaettung.Text = "Glättungsstufe: 1";
            this.lblGlaettung.Click += new System.EventHandler(this.lblGlaettung_Click);
            // 
            // lblBallSpeed
            // 
            this.lblBallSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBallSpeed.AutoSize = true;
            this.lblBallSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.lblBallSpeed.Font = new System.Drawing.Font("Courier New", 13.2F, System.Drawing.FontStyle.Bold);
            this.lblBallSpeed.ForeColor = System.Drawing.Color.Coral;
            this.lblBallSpeed.Location = new System.Drawing.Point(1049, 742);
            this.lblBallSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBallSpeed.Name = "lblBallSpeed";
            this.lblBallSpeed.Size = new System.Drawing.Size(340, 21);
            this.lblBallSpeed.TabIndex = 41;
            this.lblBallSpeed.Text = "Geschwindigkeit-Ball: Standard";
            this.lblBallSpeed.Click += new System.EventHandler(this.lblBallSpeed_Click);
            // 
            // lblFineTuning
            // 
            this.lblFineTuning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFineTuning.AutoSize = true;
            this.lblFineTuning.BackColor = System.Drawing.SystemColors.Control;
            this.lblFineTuning.Font = new System.Drawing.Font("Courier New", 13.2F, System.Drawing.FontStyle.Bold);
            this.lblFineTuning.ForeColor = System.Drawing.Color.Coral;
            this.lblFineTuning.Location = new System.Drawing.Point(872, 742);
            this.lblFineTuning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFineTuning.Name = "lblFineTuning";
            this.lblFineTuning.Size = new System.Drawing.Size(197, 21);
            this.lblFineTuning.TabIndex = 39;
            this.lblFineTuning.Text = "Empfindlichkeit: ";
            this.lblFineTuning.Click += new System.EventHandler(this.lblFineTuning_Click);
            // 
            // points2
            // 
            this.points2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.points2.AutoSize = true;
            this.points2.BackColor = System.Drawing.Color.Black;
            this.points2.Font = new System.Drawing.Font("Courier New", 60F);
            this.points2.ForeColor = System.Drawing.Color.Lime;
            this.points2.Location = new System.Drawing.Point(1228, 509);
            this.points2.Name = "points2";
            this.points2.Size = new System.Drawing.Size(85, 85);
            this.points2.TabIndex = 34;
            this.points2.Text = "0";
            // 
            // points1
            // 
            this.points1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.points1.AutoSize = true;
            this.points1.BackColor = System.Drawing.Color.Black;
            this.points1.Font = new System.Drawing.Font("Courier New", 60F);
            this.points1.ForeColor = System.Drawing.Color.Blue;
            this.points1.Location = new System.Drawing.Point(1228, 58);
            this.points1.Name = "points1";
            this.points1.Size = new System.Drawing.Size(85, 85);
            this.points1.TabIndex = 33;
            this.points1.Text = "0";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Connect.BackColor = System.Drawing.Color.Yellow;
            this.btn_Connect.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_Connect.Location = new System.Drawing.Point(458, 627);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(202, 36);
            this.btn_Connect.TabIndex = 55;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click_1);
            // 
            // btn_Start
            // 
            this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Start.BackColor = System.Drawing.Color.Orange;
            this.btn_Start.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_Start.Location = new System.Drawing.Point(250, 627);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(202, 36);
            this.btn_Start.TabIndex = 60;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(667, 627);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(202, 36);
            this.btnStart.TabIndex = 69;
            this.btnStart.Text = "Move it!";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lsb_Information
            // 
            this.lsb_Information.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsb_Information.FormattingEnabled = true;
            this.lsb_Information.Location = new System.Drawing.Point(57, 681);
            this.lsb_Information.Name = "lsb_Information";
            this.lsb_Information.Size = new System.Drawing.Size(234, 82);
            this.lsb_Information.TabIndex = 66;
            // 
            // lbl_Client
            // 
            this.lbl_Client.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.cbAusblenden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAusblenden.AutoSize = true;
            this.cbAusblenden.Location = new System.Drawing.Point(1277, 690);
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
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.BackColor = System.Drawing.Color.Red;
            this.btnSettings.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnSettings.Location = new System.Drawing.Point(57, 627);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(187, 36);
            this.btnSettings.TabIndex = 74;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rBFrequenz
            // 
            this.rBFrequenz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBFrequenz.AutoSize = true;
            this.rBFrequenz.BackColor = System.Drawing.Color.Purple;
            this.rBFrequenz.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rBFrequenz.Location = new System.Drawing.Point(977, 681);
            this.rBFrequenz.Name = "rBFrequenz";
            this.rBFrequenz.Size = new System.Drawing.Size(134, 29);
            this.rBFrequenz.TabIndex = 82;
            this.rBFrequenz.TabStop = true;
            this.rBFrequenz.Text = "Frequenz";
            this.rBFrequenz.UseVisualStyleBackColor = false;
            // 
            // rBSound
            // 
            this.rBSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBSound.AutoSize = true;
            this.rBSound.BackColor = System.Drawing.Color.Blue;
            this.rBSound.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rBSound.Location = new System.Drawing.Point(876, 681);
            this.rBSound.Name = "rBSound";
            this.rBSound.Size = new System.Drawing.Size(95, 29);
            this.rBSound.TabIndex = 81;
            this.rBSound.TabStop = true;
            this.rBSound.Text = "Sound";
            this.rBSound.UseVisualStyleBackColor = false;
            // 
            // rbKeyboard
            // 
            this.rbKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbKeyboard.AutoSize = true;
            this.rbKeyboard.BackColor = System.Drawing.Color.Pink;
            this.rbKeyboard.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rbKeyboard.Location = new System.Drawing.Point(1117, 681);
            this.rbKeyboard.Name = "rbKeyboard";
            this.rbKeyboard.Size = new System.Drawing.Size(134, 29);
            this.rbKeyboard.TabIndex = 83;
            this.rbKeyboard.TabStop = true;
            this.rbKeyboard.Text = "Tastatur";
            this.rbKeyboard.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(1426, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 610);
            this.panel1.TabIndex = 84;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(1414, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 610);
            this.panel2.TabIndex = 85;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(1402, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 610);
            this.panel3.TabIndex = 86;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Location = new System.Drawing.Point(9, 10);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 610);
            this.panel5.TabIndex = 91;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Red;
            this.panel6.Location = new System.Drawing.Point(21, 10);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(8, 610);
            this.panel6.TabIndex = 90;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Location = new System.Drawing.Point(33, 10);
            this.panel7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(8, 610);
            this.panel7.TabIndex = 89;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(9, 10);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1425, 8);
            this.panel4.TabIndex = 90;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.Red;
            this.panel8.Location = new System.Drawing.Point(33, 23);
            this.panel8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1377, 8);
            this.panel8.TabIndex = 91;
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Magenta;
            this.Ball.Location = new System.Drawing.Point(1148, 137);
            this.Ball.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(38, 41);
            this.Ball.TabIndex = 76;
            this.Ball.TabStop = false;
            // 
            // pbx_downlocal
            // 
            this.pbx_downlocal.BackColor = System.Drawing.Color.Lime;
            this.pbx_downlocal.Location = new System.Drawing.Point(70, 567);
            this.pbx_downlocal.Name = "pbx_downlocal";
            this.pbx_downlocal.Size = new System.Drawing.Size(185, 27);
            this.pbx_downlocal.TabIndex = 4;
            this.pbx_downlocal.TabStop = false;
            // 
            // pbx_upnetwork
            // 
            this.pbx_upnetwork.BackColor = System.Drawing.Color.Blue;
            this.pbx_upnetwork.Location = new System.Drawing.Point(70, 58);
            this.pbx_upnetwork.Name = "pbx_upnetwork";
            this.pbx_upnetwork.Size = new System.Drawing.Size(185, 27);
            this.pbx_upnetwork.TabIndex = 3;
            this.pbx_upnetwork.TabStop = false;
            // 
            // ServerForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 799);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbKeyboard);
            this.Controls.Add(this.rBFrequenz);
            this.Controls.Add(this.rBSound);
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
            this.Controls.Add(this.lblBallSpeed);
            this.Controls.Add(this.lblFineTuning);
            this.Controls.Add(this.points2);
            this.Controls.Add(this.points1);
            this.Controls.Add(this.pbx_downlocal);
            this.Controls.Add(this.pbx_upnetwork);
            this.Controls.Add(this.dgv_playfieldclient);
            this.Name = "ServerForms";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.ServerForms_Activated);
            this.Deactivate += new System.EventHandler(this.ServerForms_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_playfieldclient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_downlocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_upnetwork)).EndInit();
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
        private System.Windows.Forms.Label lblBallSpeed;
        private System.Windows.Forms.Label lblFineTuning;
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
        private System.Windows.Forms.RadioButton rBFrequenz;
        private System.Windows.Forms.RadioButton rBSound;
        private System.Windows.Forms.RadioButton rbKeyboard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
    }
}


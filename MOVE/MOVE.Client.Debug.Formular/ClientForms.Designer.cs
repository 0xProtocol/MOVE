namespace MOVE.Client.Debug.Formular
{
    partial class ClientForms
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
            this.lbl_Client = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lsb_Information = new System.Windows.Forms.ListBox();
            this.lblSchwierigkeit = new System.Windows.Forms.Label();
            this.lblGlaettung = new System.Windows.Forms.Label();
            this.lblFineTuning = new System.Windows.Forms.Label();
            this.points2 = new System.Windows.Forms.Label();
            this.points1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.cbAusblenden = new System.Windows.Forms.CheckBox();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.rBSound = new System.Windows.Forms.RadioButton();
            this.rBFrequenz = new System.Windows.Forms.RadioButton();
            this.rbKeyboard = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.pbx_uplocal = new System.Windows.Forms.PictureBox();
            this.pbx_downnetwork = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_playfieldclient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_uplocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_downnetwork)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_playfieldclient
            // 
            this.dgv_playfieldclient.BackgroundColor = System.Drawing.Color.Black;
            this.dgv_playfieldclient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_playfieldclient.Location = new System.Drawing.Point(51, 41);
            this.dgv_playfieldclient.Name = "dgv_playfieldclient";
            this.dgv_playfieldclient.Size = new System.Drawing.Size(1340, 580);
            this.dgv_playfieldclient.TabIndex = 0;
            this.dgv_playfieldclient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_playfieldclient_CellContentClick);
            this.dgv_playfieldclient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_playfieldclient_KeyDown);
            // 
            // lbl_Client
            // 
            this.lbl_Client.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.BackColor = System.Drawing.Color.Black;
            this.lbl_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.lbl_Client.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Client.Location = new System.Drawing.Point(625, 690);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(118, 44);
            this.lbl_Client.TabIndex = 3;
            this.lbl_Client.Text = "Client";
            this.lbl_Client.Click += new System.EventHandler(this.lbl_Client_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Start.BackColor = System.Drawing.Color.Yellow;
            this.btn_Start.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_Start.Location = new System.Drawing.Point(458, 627);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(187, 36);
            this.btn_Start.TabIndex = 17;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lsb_Information
            // 
            this.lsb_Information.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsb_Information.FormattingEnabled = true;
            this.lsb_Information.Location = new System.Drawing.Point(57, 681);
            this.lsb_Information.Name = "lsb_Information";
            this.lsb_Information.Size = new System.Drawing.Size(266, 95);
            this.lsb_Information.TabIndex = 18;
            this.lsb_Information.SelectedIndexChanged += new System.EventHandler(this.lsb_Information_SelectedIndexChanged);
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
            this.lblSchwierigkeit.TabIndex = 63;
            this.lblSchwierigkeit.Text = "Schwierigkeit: Anfänger";
            this.lblSchwierigkeit.Click += new System.EventHandler(this.lblSchwierigkeit_Click);
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
            this.lblGlaettung.TabIndex = 61;
            this.lblGlaettung.Text = "Glättungsstufe: 1";
            this.lblGlaettung.Click += new System.EventHandler(this.lblGlaettung_Click);
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
            this.lblFineTuning.TabIndex = 56;
            this.lblFineTuning.Text = "Empfindlichkeit: ";
            // 
            // points2
            // 
            this.points2.AutoSize = true;
            this.points2.BackColor = System.Drawing.Color.Black;
            this.points2.Font = new System.Drawing.Font("Courier New", 60F);
            this.points2.ForeColor = System.Drawing.Color.Lime;
            this.points2.Location = new System.Drawing.Point(1228, 509);
            this.points2.Name = "points2";
            this.points2.Size = new System.Drawing.Size(85, 85);
            this.points2.TabIndex = 51;
            this.points2.Text = "0";
            // 
            // points1
            // 
            this.points1.AutoSize = true;
            this.points1.BackColor = System.Drawing.Color.Black;
            this.points1.Font = new System.Drawing.Font("Courier New", 60F);
            this.points1.ForeColor = System.Drawing.Color.Blue;
            this.points1.Location = new System.Drawing.Point(1228, 58);
            this.points1.Name = "points1";
            this.points1.Size = new System.Drawing.Size(85, 85);
            this.points1.TabIndex = 50;
            this.points1.Text = "0";
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(821, 627);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(188, 36);
            this.btnStart.TabIndex = 64;
            this.btnStart.Text = "Move it!";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cbAusblenden
            // 
            this.cbAusblenden.AutoSize = true;
            this.cbAusblenden.Location = new System.Drawing.Point(1277, 681);
            this.cbAusblenden.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbAusblenden.Name = "cbAusblenden";
            this.cbAusblenden.Size = new System.Drawing.Size(112, 17);
            this.cbAusblenden.TabIndex = 65;
            this.cbAusblenden.Text = "Menü Ausblenden";
            this.cbAusblenden.UseVisualStyleBackColor = true;
            this.cbAusblenden.CheckedChanged += new System.EventHandler(this.cbAusblenden_CheckedChanged);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Settings.BackColor = System.Drawing.Color.Red;
            this.btn_Settings.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_Settings.Location = new System.Drawing.Point(57, 627);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(187, 36);
            this.btn_Settings.TabIndex = 76;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = false;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Connect.BackColor = System.Drawing.Color.Orange;
            this.btn_Connect.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_Connect.Location = new System.Drawing.Point(250, 627);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(202, 36);
            this.btn_Connect.TabIndex = 12;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // rBSound
            // 
            this.rBSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBSound.AutoSize = true;
            this.rBSound.BackColor = System.Drawing.Color.Blue;
            this.rBSound.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rBSound.Location = new System.Drawing.Point(1015, 631);
            this.rBSound.Name = "rBSound";
            this.rBSound.Size = new System.Drawing.Size(95, 29);
            this.rBSound.TabIndex = 79;
            this.rBSound.TabStop = true;
            this.rBSound.Text = "Sound";
            this.rBSound.UseVisualStyleBackColor = false;
            // 
            // rBFrequenz
            // 
            this.rBFrequenz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBFrequenz.AutoSize = true;
            this.rBFrequenz.BackColor = System.Drawing.Color.Purple;
            this.rBFrequenz.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rBFrequenz.Location = new System.Drawing.Point(1115, 631);
            this.rBFrequenz.Name = "rBFrequenz";
            this.rBFrequenz.Size = new System.Drawing.Size(134, 29);
            this.rBFrequenz.TabIndex = 80;
            this.rBFrequenz.TabStop = true;
            this.rBFrequenz.Text = "Frequenz";
            this.rBFrequenz.UseVisualStyleBackColor = false;
            this.rBFrequenz.CheckedChanged += new System.EventHandler(this.rBFrequenz_CheckedChanged);
            this.rBFrequenz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rBFrequenz_KeyDown);
            // 
            // rbKeyboard
            // 
            this.rbKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbKeyboard.AutoSize = true;
            this.rbKeyboard.BackColor = System.Drawing.Color.Pink;
            this.rbKeyboard.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rbKeyboard.Location = new System.Drawing.Point(1255, 631);
            this.rbKeyboard.Name = "rbKeyboard";
            this.rbKeyboard.Size = new System.Drawing.Size(134, 29);
            this.rbKeyboard.TabIndex = 84;
            this.rbKeyboard.TabStop = true;
            this.rbKeyboard.Text = "Tastatur";
            this.rbKeyboard.UseVisualStyleBackColor = false;
            this.rbKeyboard.CheckedChanged += new System.EventHandler(this.rbKeyboard_CheckedChanged);
            this.rbKeyboard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbKeyboard_KeyDown);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.Red;
            this.panel8.Location = new System.Drawing.Point(33, 23);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1377, 8);
            this.panel8.TabIndex = 98;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(9, 10);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1425, 8);
            this.panel4.TabIndex = 96;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Location = new System.Drawing.Point(9, 12);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 610);
            this.panel5.TabIndex = 99;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Red;
            this.panel6.Location = new System.Drawing.Point(21, 12);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(8, 610);
            this.panel6.TabIndex = 97;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Location = new System.Drawing.Point(33, 12);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(8, 610);
            this.panel7.TabIndex = 95;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(1402, 12);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 610);
            this.panel3.TabIndex = 94;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(1414, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 610);
            this.panel2.TabIndex = 93;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(1426, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 610);
            this.panel1.TabIndex = 92;
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Magenta;
            this.Ball.Location = new System.Drawing.Point(1148, 137);
            this.Ball.Margin = new System.Windows.Forms.Padding(2);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(38, 41);
            this.Ball.TabIndex = 78;
            this.Ball.TabStop = false;
            // 
            // pbx_uplocal
            // 
            this.pbx_uplocal.BackColor = System.Drawing.Color.Blue;
            this.pbx_uplocal.Location = new System.Drawing.Point(70, 58);
            this.pbx_uplocal.Name = "pbx_uplocal";
            this.pbx_uplocal.Size = new System.Drawing.Size(185, 27);
            this.pbx_uplocal.TabIndex = 2;
            this.pbx_uplocal.TabStop = false;
            // 
            // pbx_downnetwork
            // 
            this.pbx_downnetwork.BackColor = System.Drawing.Color.Lime;
            this.pbx_downnetwork.Location = new System.Drawing.Point(70, 567);
            this.pbx_downnetwork.Name = "pbx_downnetwork";
            this.pbx_downnetwork.Size = new System.Drawing.Size(185, 27);
            this.pbx_downnetwork.TabIndex = 1;
            this.pbx_downnetwork.TabStop = false;
            this.pbx_downnetwork.Click += new System.EventHandler(this.pbx_downnetwork_Click);
            // 
            // ClientForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1443, 800);
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
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.cbAusblenden);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblSchwierigkeit);
            this.Controls.Add(this.lblGlaettung);
            this.Controls.Add(this.lblFineTuning);
            this.Controls.Add(this.points2);
            this.Controls.Add(this.points1);
            this.Controls.Add(this.lsb_Information);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.lbl_Client);
            this.Controls.Add(this.pbx_uplocal);
            this.Controls.Add(this.pbx_downnetwork);
            this.Controls.Add(this.dgv_playfieldclient);
            this.Name = "ClientForms";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.ClientForms_Activated);
            this.Deactivate += new System.EventHandler(this.ClientForms_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_playfieldclient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_uplocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_downnetwork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_playfieldclient;
        private System.Windows.Forms.PictureBox pbx_downnetwork;
        private System.Windows.Forms.PictureBox pbx_uplocal;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ListBox lsb_Information;
        private System.Windows.Forms.Label lblSchwierigkeit;
        private System.Windows.Forms.Label lblGlaettung;
        private System.Windows.Forms.Label lblFineTuning;
        private System.Windows.Forms.Label points2;
        private System.Windows.Forms.Label points1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox cbAusblenden;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.RadioButton rBSound;
        private System.Windows.Forms.RadioButton rBFrequenz;
        private System.Windows.Forms.RadioButton rbKeyboard;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}


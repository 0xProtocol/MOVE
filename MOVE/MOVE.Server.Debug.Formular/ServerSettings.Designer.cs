namespace MOVE.Server.Debug.Formular
{
    partial class ServerSettings
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
            this.components = new System.ComponentModel.Container();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbx_IPClient = new System.Windows.Forms.TextBox();
            this.lbl_IPServer = new System.Windows.Forms.Label();
            this.lbl_ServerStart = new System.Windows.Forms.Label();
            this.lbl_IPClient = new System.Windows.Forms.Label();
            this.lbl_PortClient = new System.Windows.Forms.Label();
            this.tbx_PortServer = new System.Windows.Forms.TextBox();
            this.lbl_ClientConnect = new System.Windows.Forms.Label();
            this.tbx_IPServer = new System.Windows.Forms.TextBox();
            this.tbx_PortClient = new System.Windows.Forms.TextBox();
            this.lbl_PortServer = new System.Windows.Forms.Label();
            this.btn_ActivateFirewall = new System.Windows.Forms.Button();
            this.btn_deactivatefirewall = new System.Windows.Forms.Button();
            this.btn_Discover = new System.Windows.Forms.Button();
            this.pbnetwork = new System.Windows.Forms.ProgressBar();
            this.tbx_Discovery = new System.Windows.Forms.TextBox();
            this.cbQuickSearch = new System.Windows.Forms.CheckBox();
            this.cbDeepSearch = new System.Windows.Forms.CheckBox();
            this.lsb_discover = new System.Windows.Forms.ListBox();
            this.tbGlättung = new System.Windows.Forms.TrackBar();
            this.tbempfindlichkeit = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tcGameSettings = new System.Windows.Forms.TabPage();
            this.lblGlättungsstufe = new System.Windows.Forms.Label();
            this.lblEmpfindlichkeit = new System.Windows.Forms.Label();
            this.pbTrackBar = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rBPfeifen = new System.Windows.Forms.RadioButton();
            this.rBSopran = new System.Windows.Forms.RadioButton();
            this.rBMezzosopran = new System.Windows.Forms.RadioButton();
            this.rBMaenneralt = new System.Windows.Forms.RadioButton();
            this.rBTenor = new System.Windows.Forms.RadioButton();
            this.rBBartion = new System.Windows.Forms.RadioButton();
            this.rBBass = new System.Windows.Forms.RadioButton();
            this.tcIPConfiguration = new System.Windows.Forms.TabPage();
            this.pbNet2 = new System.Windows.Forms.PictureBox();
            this.tcNetworkDicovery = new System.Windows.Forms.TabPage();
            this.pbGlasses2 = new System.Windows.Forms.PictureBox();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGlättung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbempfindlichkeit)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tcGameSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrackBar)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tcIPConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNet2)).BeginInit();
            this.tcNetworkDicovery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGlasses2)).BeginInit();
            this.SuspendLayout();
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientToolStripMenuItem,
            this.serverToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(107, 48);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.clientToolStripMenuItem.Text = "Client";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.serverToolStripMenuItem.Text = "Server";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.serverToolStripMenuItem_Click);
            // 
            // tbx_IPClient
            // 
            this.tbx_IPClient.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.tbx_IPClient.Location = new System.Drawing.Point(74, 225);
            this.tbx_IPClient.Name = "tbx_IPClient";
            this.tbx_IPClient.Size = new System.Drawing.Size(228, 39);
            this.tbx_IPClient.TabIndex = 73;
            this.tbx_IPClient.Text = "127.0.0.1";
            // 
            // lbl_IPServer
            // 
            this.lbl_IPServer.AutoSize = true;
            this.lbl_IPServer.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lbl_IPServer.Location = new System.Drawing.Point(8, 232);
            this.lbl_IPServer.Name = "lbl_IPServer";
            this.lbl_IPServer.Size = new System.Drawing.Size(37, 31);
            this.lbl_IPServer.TabIndex = 74;
            this.lbl_IPServer.Text = "IP";
            // 
            // lbl_ServerStart
            // 
            this.lbl_ServerStart.AutoSize = true;
            this.lbl_ServerStart.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lbl_ServerStart.Location = new System.Drawing.Point(68, 192);
            this.lbl_ServerStart.Name = "lbl_ServerStart";
            this.lbl_ServerStart.Size = new System.Drawing.Size(89, 31);
            this.lbl_ServerStart.TabIndex = 76;
            this.lbl_ServerStart.Text = "Client";
            // 
            // lbl_IPClient
            // 
            this.lbl_IPClient.AutoSize = true;
            this.lbl_IPClient.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lbl_IPClient.Location = new System.Drawing.Point(335, 232);
            this.lbl_IPClient.Name = "lbl_IPClient";
            this.lbl_IPClient.Size = new System.Drawing.Size(37, 31);
            this.lbl_IPClient.TabIndex = 78;
            this.lbl_IPClient.Text = "IP";
            // 
            // lbl_PortClient
            // 
            this.lbl_PortClient.AutoSize = true;
            this.lbl_PortClient.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lbl_PortClient.Location = new System.Drawing.Point(311, 271);
            this.lbl_PortClient.Name = "lbl_PortClient";
            this.lbl_PortClient.Size = new System.Drawing.Size(63, 31);
            this.lbl_PortClient.TabIndex = 79;
            this.lbl_PortClient.Text = "Port";
            // 
            // tbx_PortServer
            // 
            this.tbx_PortServer.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.tbx_PortServer.Location = new System.Drawing.Point(376, 269);
            this.tbx_PortServer.Name = "tbx_PortServer";
            this.tbx_PortServer.Size = new System.Drawing.Size(228, 39);
            this.tbx_PortServer.TabIndex = 80;
            this.tbx_PortServer.Text = "4712";
            // 
            // lbl_ClientConnect
            // 
            this.lbl_ClientConnect.AutoSize = true;
            this.lbl_ClientConnect.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lbl_ClientConnect.Location = new System.Drawing.Point(371, 192);
            this.lbl_ClientConnect.Name = "lbl_ClientConnect";
            this.lbl_ClientConnect.Size = new System.Drawing.Size(95, 31);
            this.lbl_ClientConnect.TabIndex = 77;
            this.lbl_ClientConnect.Text = "Server";
            // 
            // tbx_IPServer
            // 
            this.tbx_IPServer.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.tbx_IPServer.Location = new System.Drawing.Point(376, 225);
            this.tbx_IPServer.Name = "tbx_IPServer";
            this.tbx_IPServer.Size = new System.Drawing.Size(228, 39);
            this.tbx_IPServer.TabIndex = 81;
            this.tbx_IPServer.Text = "127.0.0.1";
            // 
            // tbx_PortClient
            // 
            this.tbx_PortClient.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.tbx_PortClient.Location = new System.Drawing.Point(74, 271);
            this.tbx_PortClient.Name = "tbx_PortClient";
            this.tbx_PortClient.Size = new System.Drawing.Size(228, 39);
            this.tbx_PortClient.TabIndex = 72;
            this.tbx_PortClient.Text = "4711";
            // 
            // lbl_PortServer
            // 
            this.lbl_PortServer.AutoSize = true;
            this.lbl_PortServer.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lbl_PortServer.Location = new System.Drawing.Point(8, 271);
            this.lbl_PortServer.Name = "lbl_PortServer";
            this.lbl_PortServer.Size = new System.Drawing.Size(63, 31);
            this.lbl_PortServer.TabIndex = 75;
            this.lbl_PortServer.Text = "Port";
            // 
            // btn_ActivateFirewall
            // 
            this.btn_ActivateFirewall.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.btn_ActivateFirewall.Location = new System.Drawing.Point(336, 161);
            this.btn_ActivateFirewall.Name = "btn_ActivateFirewall";
            this.btn_ActivateFirewall.Size = new System.Drawing.Size(262, 40);
            this.btn_ActivateFirewall.TabIndex = 85;
            this.btn_ActivateFirewall.Text = "Activate Firewall";
            this.btn_ActivateFirewall.UseVisualStyleBackColor = true;
            this.btn_ActivateFirewall.Click += new System.EventHandler(this.btn_ActivateFirewall_Click);
            // 
            // btn_deactivatefirewall
            // 
            this.btn_deactivatefirewall.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.btn_deactivatefirewall.Location = new System.Drawing.Point(336, 207);
            this.btn_deactivatefirewall.Name = "btn_deactivatefirewall";
            this.btn_deactivatefirewall.Size = new System.Drawing.Size(262, 40);
            this.btn_deactivatefirewall.TabIndex = 86;
            this.btn_deactivatefirewall.Text = "Deactivate Firewall";
            this.btn_deactivatefirewall.UseVisualStyleBackColor = true;
            this.btn_deactivatefirewall.Click += new System.EventHandler(this.btn_deactivatefirewall_Click);
            // 
            // btn_Discover
            // 
            this.btn_Discover.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.btn_Discover.Location = new System.Drawing.Point(336, 254);
            this.btn_Discover.Name = "btn_Discover";
            this.btn_Discover.Size = new System.Drawing.Size(262, 41);
            this.btn_Discover.TabIndex = 83;
            this.btn_Discover.Text = "Start Discovery";
            this.btn_Discover.UseVisualStyleBackColor = true;
            this.btn_Discover.Click += new System.EventHandler(this.btn_Discover_Click);
            // 
            // pbnetwork
            // 
            this.pbnetwork.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbnetwork.ForeColor = System.Drawing.Color.Lime;
            this.pbnetwork.Location = new System.Drawing.Point(336, 301);
            this.pbnetwork.Name = "pbnetwork";
            this.pbnetwork.Size = new System.Drawing.Size(262, 18);
            this.pbnetwork.TabIndex = 89;
            // 
            // tbx_Discovery
            // 
            this.tbx_Discovery.Location = new System.Drawing.Point(6, 301);
            this.tbx_Discovery.Name = "tbx_Discovery";
            this.tbx_Discovery.Size = new System.Drawing.Size(320, 20);
            this.tbx_Discovery.TabIndex = 84;
            // 
            // cbQuickSearch
            // 
            this.cbQuickSearch.AutoSize = true;
            this.cbQuickSearch.Font = new System.Drawing.Font("Rockwell", 17.8F);
            this.cbQuickSearch.Location = new System.Drawing.Point(167, 126);
            this.cbQuickSearch.Name = "cbQuickSearch";
            this.cbQuickSearch.Size = new System.Drawing.Size(175, 31);
            this.cbQuickSearch.TabIndex = 87;
            this.cbQuickSearch.Text = "QuickSearch";
            this.cbQuickSearch.UseVisualStyleBackColor = true;
            // 
            // cbDeepSearch
            // 
            this.cbDeepSearch.AutoSize = true;
            this.cbDeepSearch.Font = new System.Drawing.Font("Rockwell", 17.8F);
            this.cbDeepSearch.Location = new System.Drawing.Point(6, 126);
            this.cbDeepSearch.Name = "cbDeepSearch";
            this.cbDeepSearch.Size = new System.Drawing.Size(169, 31);
            this.cbDeepSearch.TabIndex = 88;
            this.cbDeepSearch.Text = "DeepSearch";
            this.cbDeepSearch.UseVisualStyleBackColor = true;
            // 
            // lsb_discover
            // 
            this.lsb_discover.ContextMenuStrip = this.cms;
            this.lsb_discover.FormattingEnabled = true;
            this.lsb_discover.Location = new System.Drawing.Point(6, 161);
            this.lsb_discover.Name = "lsb_discover";
            this.lsb_discover.Size = new System.Drawing.Size(320, 134);
            this.lsb_discover.TabIndex = 82;
            this.lsb_discover.SelectedIndexChanged += new System.EventHandler(this.lsb_discover_SelectedIndexChanged);
            // 
            // tbGlättung
            // 
            this.tbGlättung.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tbGlättung.Location = new System.Drawing.Point(10, 192);
            this.tbGlättung.Maximum = 3;
            this.tbGlättung.Minimum = 1;
            this.tbGlättung.Name = "tbGlättung";
            this.tbGlättung.Size = new System.Drawing.Size(601, 45);
            this.tbGlättung.TabIndex = 1;
            this.tbGlättung.Value = 1;
            this.tbGlättung.Scroll += new System.EventHandler(this.tbGlättung_Scroll);
            // 
            // tbempfindlichkeit
            // 
            this.tbempfindlichkeit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tbempfindlichkeit.Location = new System.Drawing.Point(12, 48);
            this.tbempfindlichkeit.Maximum = 3;
            this.tbempfindlichkeit.Minimum = 1;
            this.tbempfindlichkeit.Name = "tbempfindlichkeit";
            this.tbempfindlichkeit.Size = new System.Drawing.Size(599, 45);
            this.tbempfindlichkeit.TabIndex = 0;
            this.tbempfindlichkeit.Value = 1;
            this.tbempfindlichkeit.Scroll += new System.EventHandler(this.tbempfindlichkeit_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tcGameSettings);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tcIPConfiguration);
            this.tabControl1.Controls.Add(this.tcNetworkDicovery);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 360);
            this.tabControl1.TabIndex = 90;
            // 
            // tcGameSettings
            // 
            this.tcGameSettings.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tcGameSettings.Controls.Add(this.lblGlättungsstufe);
            this.tcGameSettings.Controls.Add(this.lblEmpfindlichkeit);
            this.tcGameSettings.Controls.Add(this.pbTrackBar);
            this.tcGameSettings.Controls.Add(this.tbempfindlichkeit);
            this.tcGameSettings.Controls.Add(this.tbGlättung);
            this.tcGameSettings.Location = new System.Drawing.Point(4, 22);
            this.tcGameSettings.Name = "tcGameSettings";
            this.tcGameSettings.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tcGameSettings.Size = new System.Drawing.Size(607, 334);
            this.tcGameSettings.TabIndex = 0;
            this.tcGameSettings.Text = "Game Settings";
            this.tcGameSettings.Click += new System.EventHandler(this.tcGameSettings_Click);
            // 
            // lblGlättungsstufe
            // 
            this.lblGlättungsstufe.AutoSize = true;
            this.lblGlättungsstufe.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblGlättungsstufe.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lblGlättungsstufe.ForeColor = System.Drawing.Color.Brown;
            this.lblGlättungsstufe.Location = new System.Drawing.Point(218, 158);
            this.lblGlättungsstufe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGlättungsstufe.Name = "lblGlättungsstufe";
            this.lblGlättungsstufe.Size = new System.Drawing.Size(191, 31);
            this.lblGlättungsstufe.TabIndex = 11;
            this.lblGlättungsstufe.Text = "Glättungsstufe";
            // 
            // lblEmpfindlichkeit
            // 
            this.lblEmpfindlichkeit.AutoSize = true;
            this.lblEmpfindlichkeit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblEmpfindlichkeit.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lblEmpfindlichkeit.ForeColor = System.Drawing.Color.Brown;
            this.lblEmpfindlichkeit.Location = new System.Drawing.Point(210, 15);
            this.lblEmpfindlichkeit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpfindlichkeit.Name = "lblEmpfindlichkeit";
            this.lblEmpfindlichkeit.Size = new System.Drawing.Size(210, 31);
            this.lblEmpfindlichkeit.TabIndex = 10;
            this.lblEmpfindlichkeit.Text = "Empfindlichkeit";
            // 
            // pbTrackBar
            // 
            this.pbTrackBar.Image = global::MOVE.Server.Debug.Formular.Properties.Resources.track_and_status_controls_trackbar_programming_radtrackbar020;
            this.pbTrackBar.Location = new System.Drawing.Point(129, 228);
            this.pbTrackBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbTrackBar.Name = "pbTrackBar";
            this.pbTrackBar.Size = new System.Drawing.Size(348, 99);
            this.pbTrackBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTrackBar.TabIndex = 9;
            this.pbTrackBar.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.rBPfeifen);
            this.tabPage1.Controls.Add(this.rBSopran);
            this.tabPage1.Controls.Add(this.rBMezzosopran);
            this.tabPage1.Controls.Add(this.rBMaenneralt);
            this.tabPage1.Controls.Add(this.rBTenor);
            this.tabPage1.Controls.Add(this.rBBartion);
            this.tabPage1.Controls.Add(this.rBBass);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(607, 334);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Frequenztuning";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MOVE.Server.Debug.Formular.Properties.Resources.Move;
            this.pictureBox1.Location = new System.Drawing.Point(262, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 312);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // rBPfeifen
            // 
            this.rBPfeifen.AutoSize = true;
            this.rBPfeifen.Checked = true;
            this.rBPfeifen.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBPfeifen.Location = new System.Drawing.Point(23, 281);
            this.rBPfeifen.Name = "rBPfeifen";
            this.rBPfeifen.Size = new System.Drawing.Size(116, 35);
            this.rBPfeifen.TabIndex = 9;
            this.rBPfeifen.TabStop = true;
            this.rBPfeifen.Text = "Pfeifen";
            this.rBPfeifen.UseVisualStyleBackColor = true;
            // 
            // rBSopran
            // 
            this.rBSopran.AutoSize = true;
            this.rBSopran.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBSopran.Location = new System.Drawing.Point(23, 238);
            this.rBSopran.Name = "rBSopran";
            this.rBSopran.Size = new System.Drawing.Size(118, 35);
            this.rBSopran.TabIndex = 8;
            this.rBSopran.Text = "Sopran";
            this.rBSopran.UseVisualStyleBackColor = true;
            // 
            // rBMezzosopran
            // 
            this.rBMezzosopran.AutoSize = true;
            this.rBMezzosopran.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBMezzosopran.Location = new System.Drawing.Point(23, 195);
            this.rBMezzosopran.Name = "rBMezzosopran";
            this.rBMezzosopran.Size = new System.Drawing.Size(194, 35);
            this.rBMezzosopran.TabIndex = 7;
            this.rBMezzosopran.Text = "Mezzosopran";
            this.rBMezzosopran.UseVisualStyleBackColor = true;
            // 
            // rBMaenneralt
            // 
            this.rBMaenneralt.AutoSize = true;
            this.rBMaenneralt.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBMaenneralt.Location = new System.Drawing.Point(23, 156);
            this.rBMaenneralt.Name = "rBMaenneralt";
            this.rBMaenneralt.Size = new System.Drawing.Size(156, 35);
            this.rBMaenneralt.TabIndex = 6;
            this.rBMaenneralt.Text = "Männeralt";
            this.rBMaenneralt.UseVisualStyleBackColor = true;
            // 
            // rBTenor
            // 
            this.rBTenor.AutoSize = true;
            this.rBTenor.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBTenor.Location = new System.Drawing.Point(23, 113);
            this.rBTenor.Name = "rBTenor";
            this.rBTenor.Size = new System.Drawing.Size(103, 35);
            this.rBTenor.TabIndex = 5;
            this.rBTenor.Text = "Tenor";
            this.rBTenor.UseVisualStyleBackColor = true;
            // 
            // rBBartion
            // 
            this.rBBartion.AutoSize = true;
            this.rBBartion.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBBartion.Location = new System.Drawing.Point(23, 70);
            this.rBBartion.Name = "rBBartion";
            this.rBBartion.Size = new System.Drawing.Size(119, 35);
            this.rBBartion.TabIndex = 4;
            this.rBBartion.Text = "Bariton";
            this.rBBartion.UseVisualStyleBackColor = true;
            this.rBBartion.CheckedChanged += new System.EventHandler(this.rBBartion_CheckedChanged);
            // 
            // rBBass
            // 
            this.rBBass.AutoSize = true;
            this.rBBass.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBBass.Location = new System.Drawing.Point(23, 27);
            this.rBBass.Name = "rBBass";
            this.rBBass.Size = new System.Drawing.Size(86, 35);
            this.rBBass.TabIndex = 1;
            this.rBBass.Text = "Bass";
            this.rBBass.UseVisualStyleBackColor = true;
            // 
            // tcIPConfiguration
            // 
            this.tcIPConfiguration.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tcIPConfiguration.Controls.Add(this.pbNet2);
            this.tcIPConfiguration.Controls.Add(this.tbx_PortServer);
            this.tcIPConfiguration.Controls.Add(this.tbx_PortClient);
            this.tcIPConfiguration.Controls.Add(this.tbx_IPClient);
            this.tcIPConfiguration.Controls.Add(this.lbl_IPServer);
            this.tcIPConfiguration.Controls.Add(this.lbl_PortServer);
            this.tcIPConfiguration.Controls.Add(this.lbl_ServerStart);
            this.tcIPConfiguration.Controls.Add(this.lbl_ClientConnect);
            this.tcIPConfiguration.Controls.Add(this.lbl_IPClient);
            this.tcIPConfiguration.Controls.Add(this.lbl_PortClient);
            this.tcIPConfiguration.Controls.Add(this.tbx_IPServer);
            this.tcIPConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tcIPConfiguration.Name = "tcIPConfiguration";
            this.tcIPConfiguration.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tcIPConfiguration.Size = new System.Drawing.Size(607, 334);
            this.tcIPConfiguration.TabIndex = 1;
            this.tcIPConfiguration.Text = "IP-Configuration";
            this.tcIPConfiguration.Click += new System.EventHandler(this.tcIPConfiguration_Click);
            // 
            // pbNet2
            // 
            this.pbNet2.Image = global::MOVE.Server.Debug.Formular.Properties.Resources.World2;
            this.pbNet2.Location = new System.Drawing.Point(247, 16);
            this.pbNet2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbNet2.Name = "pbNet2";
            this.pbNet2.Size = new System.Drawing.Size(154, 154);
            this.pbNet2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNet2.TabIndex = 82;
            this.pbNet2.TabStop = false;
            // 
            // tcNetworkDicovery
            // 
            this.tcNetworkDicovery.BackColor = System.Drawing.Color.LawnGreen;
            this.tcNetworkDicovery.Controls.Add(this.pbGlasses2);
            this.tcNetworkDicovery.Controls.Add(this.lsb_discover);
            this.tcNetworkDicovery.Controls.Add(this.btn_Discover);
            this.tcNetworkDicovery.Controls.Add(this.pbnetwork);
            this.tcNetworkDicovery.Controls.Add(this.tbx_Discovery);
            this.tcNetworkDicovery.Controls.Add(this.cbDeepSearch);
            this.tcNetworkDicovery.Controls.Add(this.btn_ActivateFirewall);
            this.tcNetworkDicovery.Controls.Add(this.cbQuickSearch);
            this.tcNetworkDicovery.Controls.Add(this.btn_deactivatefirewall);
            this.tcNetworkDicovery.Location = new System.Drawing.Point(4, 22);
            this.tcNetworkDicovery.Name = "tcNetworkDicovery";
            this.tcNetworkDicovery.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tcNetworkDicovery.Size = new System.Drawing.Size(607, 334);
            this.tcNetworkDicovery.TabIndex = 2;
            this.tcNetworkDicovery.Text = "NetworkDiscovery";
            // 
            // pbGlasses2
            // 
            this.pbGlasses2.Image = global::MOVE.Server.Debug.Formular.Properties.Resources.lupe_ani1_optlins_aus;
            this.pbGlasses2.Location = new System.Drawing.Point(424, 38);
            this.pbGlasses2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbGlasses2.Name = "pbGlasses2";
            this.pbGlasses2.Size = new System.Drawing.Size(174, 109);
            this.pbGlasses2.TabIndex = 90;
            this.pbGlasses2.TabStop = false;
            // 
            // ServerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 393);
            this.Controls.Add(this.tabControl1);
            this.Name = "ServerSettings";
            this.Text = "ServerSettings";
            this.Activated += new System.EventHandler(this.ServerSettings_Activated);
            this.Deactivate += new System.EventHandler(this.ServerSettings_Deactivate);
            this.Load += new System.EventHandler(this.ServerSettings_Load);
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbGlättung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbempfindlichkeit)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tcGameSettings.ResumeLayout(false);
            this.tcGameSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrackBar)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tcIPConfiguration.ResumeLayout(false);
            this.tcIPConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNet2)).EndInit();
            this.tcNetworkDicovery.ResumeLayout(false);
            this.tcNetworkDicovery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGlasses2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        public System.Windows.Forms.TextBox tbx_IPClient;
        public System.Windows.Forms.Label lbl_IPServer;
        public System.Windows.Forms.Label lbl_ServerStart;
        public System.Windows.Forms.Label lbl_IPClient;
        public System.Windows.Forms.Label lbl_PortClient;
        public System.Windows.Forms.TextBox tbx_PortServer;
        public System.Windows.Forms.Label lbl_ClientConnect;
        public System.Windows.Forms.TextBox tbx_IPServer;
        public System.Windows.Forms.TextBox tbx_PortClient;
        public System.Windows.Forms.Label lbl_PortServer;
        private System.Windows.Forms.Button btn_ActivateFirewall;
        private System.Windows.Forms.Button btn_deactivatefirewall;
        private System.Windows.Forms.Button btn_Discover;
        private System.Windows.Forms.ProgressBar pbnetwork;
        private System.Windows.Forms.TextBox tbx_Discovery;
        private System.Windows.Forms.CheckBox cbQuickSearch;
        private System.Windows.Forms.CheckBox cbDeepSearch;
        private System.Windows.Forms.ListBox lsb_discover;
        public System.Windows.Forms.TrackBar tbGlättung;
        public System.Windows.Forms.TrackBar tbempfindlichkeit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tcGameSettings;
        private System.Windows.Forms.TabPage tcIPConfiguration;
        private System.Windows.Forms.TabPage tcNetworkDicovery;
        private System.Windows.Forms.PictureBox pbTrackBar;
        private System.Windows.Forms.Label lblGlättungsstufe;
        private System.Windows.Forms.Label lblEmpfindlichkeit;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.RadioButton rBBass;
        public System.Windows.Forms.RadioButton rBMaenneralt;
        public System.Windows.Forms.RadioButton rBTenor;
        public System.Windows.Forms.RadioButton rBBartion;
        public System.Windows.Forms.RadioButton rBPfeifen;
        public System.Windows.Forms.RadioButton rBSopran;
        public System.Windows.Forms.RadioButton rBMezzosopran;
        public System.Windows.Forms.PictureBox pbGlasses2;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pbNet2;
    }
}
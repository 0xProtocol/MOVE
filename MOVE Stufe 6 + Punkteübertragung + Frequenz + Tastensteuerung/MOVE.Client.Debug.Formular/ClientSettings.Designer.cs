namespace MOVE.Client.Debug.Formular
{
    partial class ClientSettings
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
            this.tbEmpfindlichkeit = new System.Windows.Forms.TrackBar();
            this.tbGlättungsstufe = new System.Windows.Forms.TrackBar();
            this.lbl_PortClient = new System.Windows.Forms.Label();
            this.lbl_IPClient = new System.Windows.Forms.Label();
            this.tbx_IPClient = new System.Windows.Forms.TextBox();
            this.tbx_PortClient = new System.Windows.Forms.TextBox();
            this.lbl_ClientConnect = new System.Windows.Forms.Label();
            this.lbl_ServerStart = new System.Windows.Forms.Label();
            this.lbl_PortServer = new System.Windows.Forms.Label();
            this.lbl_IPServer = new System.Windows.Forms.Label();
            this.tbx_IPServer = new System.Windows.Forms.TextBox();
            this.tbx_PortServer = new System.Windows.Forms.TextBox();
            this.btn_deactivatefirewall = new System.Windows.Forms.Button();
            this.btn_ActivateFirewall = new System.Windows.Forms.Button();
            this.tbx_Discovery = new System.Windows.Forms.TextBox();
            this.btn_Discover = new System.Windows.Forms.Button();
            this.lsb_discover = new System.Windows.Forms.ListBox();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbQuickSearch = new System.Windows.Forms.CheckBox();
            this.cbDeepSearch = new System.Windows.Forms.CheckBox();
            this.pbnetwork = new System.Windows.Forms.ProgressBar();
            this.tcsettings = new System.Windows.Forms.TabControl();
            this.tcGameSettings = new System.Windows.Forms.TabPage();
            this.lblGlättungsstufe = new System.Windows.Forms.Label();
            this.lblEmpfindlichkeit = new System.Windows.Forms.Label();
            this.tcIPConfiguration = new System.Windows.Forms.TabPage();
            this.tcNetworkDiscovery = new System.Windows.Forms.TabPage();
            this.tcGameSettingsFreq = new System.Windows.Forms.TabPage();
            this.rBBass = new System.Windows.Forms.RadioButton();
            this.rBBartion = new System.Windows.Forms.RadioButton();
            this.rBTenor = new System.Windows.Forms.RadioButton();
            this.rBMaenneralt = new System.Windows.Forms.RadioButton();
            this.rBMezzosopran = new System.Windows.Forms.RadioButton();
            this.rBSopran = new System.Windows.Forms.RadioButton();
            this.rBPfeifen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpfindlichkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGlättungsstufe)).BeginInit();
            this.cms.SuspendLayout();
            this.tcsettings.SuspendLayout();
            this.tcGameSettings.SuspendLayout();
            this.tcIPConfiguration.SuspendLayout();
            this.tcNetworkDiscovery.SuspendLayout();
            this.tcGameSettingsFreq.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbEmpfindlichkeit
            // 
            this.tbEmpfindlichkeit.BackColor = System.Drawing.Color.Indigo;
            this.tbEmpfindlichkeit.Location = new System.Drawing.Point(6, 6);
            this.tbEmpfindlichkeit.Maximum = 3;
            this.tbEmpfindlichkeit.Minimum = 1;
            this.tbEmpfindlichkeit.Name = "tbEmpfindlichkeit";
            this.tbEmpfindlichkeit.Size = new System.Drawing.Size(605, 45);
            this.tbEmpfindlichkeit.TabIndex = 4;
            this.tbEmpfindlichkeit.Value = 1;
            this.tbEmpfindlichkeit.Scroll += new System.EventHandler(this.tbEmpfindlichkeit_Scroll);
            // 
            // tbGlättungsstufe
            // 
            this.tbGlättungsstufe.BackColor = System.Drawing.Color.Indigo;
            this.tbGlättungsstufe.Location = new System.Drawing.Point(6, 154);
            this.tbGlättungsstufe.Maximum = 3;
            this.tbGlättungsstufe.Minimum = 1;
            this.tbGlättungsstufe.Name = "tbGlättungsstufe";
            this.tbGlättungsstufe.Size = new System.Drawing.Size(605, 45);
            this.tbGlättungsstufe.TabIndex = 5;
            this.tbGlättungsstufe.Value = 1;
            this.tbGlättungsstufe.Scroll += new System.EventHandler(this.tbGlättungsstufe_Scroll);
            // 
            // lbl_PortClient
            // 
            this.lbl_PortClient.AutoSize = true;
            this.lbl_PortClient.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.lbl_PortClient.Location = new System.Drawing.Point(298, 103);
            this.lbl_PortClient.Name = "lbl_PortClient";
            this.lbl_PortClient.Size = new System.Drawing.Size(120, 33);
            this.lbl_PortClient.TabIndex = 40;
            this.lbl_PortClient.Text = "Port";
            // 
            // lbl_IPClient
            // 
            this.lbl_IPClient.AutoSize = true;
            this.lbl_IPClient.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.lbl_IPClient.Location = new System.Drawing.Point(298, 58);
            this.lbl_IPClient.Name = "lbl_IPClient";
            this.lbl_IPClient.Size = new System.Drawing.Size(76, 33);
            this.lbl_IPClient.TabIndex = 39;
            this.lbl_IPClient.Text = "IP";
            // 
            // tbx_IPClient
            // 
            this.tbx_IPClient.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.tbx_IPClient.Location = new System.Drawing.Point(375, 53);
            this.tbx_IPClient.Name = "tbx_IPClient";
            this.tbx_IPClient.Size = new System.Drawing.Size(237, 40);
            this.tbx_IPClient.TabIndex = 38;
            this.tbx_IPClient.Text = "127.0.0.1";
            // 
            // tbx_PortClient
            // 
            this.tbx_PortClient.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.tbx_PortClient.Location = new System.Drawing.Point(416, 98);
            this.tbx_PortClient.Name = "tbx_PortClient";
            this.tbx_PortClient.Size = new System.Drawing.Size(196, 40);
            this.tbx_PortClient.TabIndex = 37;
            this.tbx_PortClient.Text = "4712";
            // 
            // lbl_ClientConnect
            // 
            this.lbl_ClientConnect.AutoSize = true;
            this.lbl_ClientConnect.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.lbl_ClientConnect.Location = new System.Drawing.Point(298, 15);
            this.lbl_ClientConnect.Name = "lbl_ClientConnect";
            this.lbl_ClientConnect.Size = new System.Drawing.Size(155, 33);
            this.lbl_ClientConnect.TabIndex = 36;
            this.lbl_ClientConnect.Text = "Client";
            // 
            // lbl_ServerStart
            // 
            this.lbl_ServerStart.AutoSize = true;
            this.lbl_ServerStart.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.lbl_ServerStart.Location = new System.Drawing.Point(8, 185);
            this.lbl_ServerStart.Name = "lbl_ServerStart";
            this.lbl_ServerStart.Size = new System.Drawing.Size(172, 33);
            this.lbl_ServerStart.TabIndex = 35;
            this.lbl_ServerStart.Text = "Server";
            // 
            // lbl_PortServer
            // 
            this.lbl_PortServer.AutoSize = true;
            this.lbl_PortServer.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.lbl_PortServer.Location = new System.Drawing.Point(8, 271);
            this.lbl_PortServer.Name = "lbl_PortServer";
            this.lbl_PortServer.Size = new System.Drawing.Size(120, 33);
            this.lbl_PortServer.TabIndex = 34;
            this.lbl_PortServer.Text = "Port";
            // 
            // lbl_IPServer
            // 
            this.lbl_IPServer.AutoSize = true;
            this.lbl_IPServer.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.lbl_IPServer.Location = new System.Drawing.Point(8, 225);
            this.lbl_IPServer.Name = "lbl_IPServer";
            this.lbl_IPServer.Size = new System.Drawing.Size(76, 33);
            this.lbl_IPServer.TabIndex = 33;
            this.lbl_IPServer.Text = "IP";
            // 
            // tbx_IPServer
            // 
            this.tbx_IPServer.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.tbx_IPServer.Location = new System.Drawing.Point(85, 223);
            this.tbx_IPServer.Name = "tbx_IPServer";
            this.tbx_IPServer.Size = new System.Drawing.Size(237, 40);
            this.tbx_IPServer.TabIndex = 32;
            this.tbx_IPServer.Text = "127.0.0.1";
            // 
            // tbx_PortServer
            // 
            this.tbx_PortServer.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.tbx_PortServer.Location = new System.Drawing.Point(126, 271);
            this.tbx_PortServer.Name = "tbx_PortServer";
            this.tbx_PortServer.Size = new System.Drawing.Size(196, 40);
            this.tbx_PortServer.TabIndex = 31;
            this.tbx_PortServer.Text = "4711";
            // 
            // btn_deactivatefirewall
            // 
            this.btn_deactivatefirewall.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.btn_deactivatefirewall.Location = new System.Drawing.Point(336, 132);
            this.btn_deactivatefirewall.Name = "btn_deactivatefirewall";
            this.btn_deactivatefirewall.Size = new System.Drawing.Size(262, 82);
            this.btn_deactivatefirewall.TabIndex = 45;
            this.btn_deactivatefirewall.Text = "Deactivate Firewall";
            this.btn_deactivatefirewall.UseVisualStyleBackColor = true;
            this.btn_deactivatefirewall.Click += new System.EventHandler(this.btn_deactivatefirewall_Click);
            // 
            // btn_ActivateFirewall
            // 
            this.btn_ActivateFirewall.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.btn_ActivateFirewall.Location = new System.Drawing.Point(336, 44);
            this.btn_ActivateFirewall.Name = "btn_ActivateFirewall";
            this.btn_ActivateFirewall.Size = new System.Drawing.Size(262, 82);
            this.btn_ActivateFirewall.TabIndex = 44;
            this.btn_ActivateFirewall.Text = "Activate Firewall";
            this.btn_ActivateFirewall.UseVisualStyleBackColor = true;
            this.btn_ActivateFirewall.Click += new System.EventHandler(this.btn_ActivateFirewall_Click);
            // 
            // tbx_Discovery
            // 
            this.tbx_Discovery.Location = new System.Drawing.Point(6, 301);
            this.tbx_Discovery.Name = "tbx_Discovery";
            this.tbx_Discovery.Size = new System.Drawing.Size(320, 20);
            this.tbx_Discovery.TabIndex = 43;
            this.tbx_Discovery.TextChanged += new System.EventHandler(this.tbx_Discovery_TextChanged);
            // 
            // btn_Discover
            // 
            this.btn_Discover.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.btn_Discover.Location = new System.Drawing.Point(336, 242);
            this.btn_Discover.Name = "btn_Discover";
            this.btn_Discover.Size = new System.Drawing.Size(262, 79);
            this.btn_Discover.TabIndex = 42;
            this.btn_Discover.Text = "Start Discovery";
            this.btn_Discover.UseVisualStyleBackColor = true;
            this.btn_Discover.Click += new System.EventHandler(this.btn_Discover_Click);
            // 
            // lsb_discover
            // 
            this.lsb_discover.ContextMenuStrip = this.cms;
            this.lsb_discover.FormattingEnabled = true;
            this.lsb_discover.Location = new System.Drawing.Point(6, 174);
            this.lsb_discover.Name = "lsb_discover";
            this.lsb_discover.Size = new System.Drawing.Size(320, 121);
            this.lsb_discover.TabIndex = 41;
            this.lsb_discover.SelectedIndexChanged += new System.EventHandler(this.lsb_discover_SelectedIndexChanged);
            this.lsb_discover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsb_discover_MouseDown);
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
            // cbQuickSearch
            // 
            this.cbQuickSearch.AutoSize = true;
            this.cbQuickSearch.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.cbQuickSearch.Location = new System.Drawing.Point(6, 89);
            this.cbQuickSearch.Name = "cbQuickSearch";
            this.cbQuickSearch.Size = new System.Drawing.Size(333, 37);
            this.cbQuickSearch.TabIndex = 46;
            this.cbQuickSearch.Text = "QuickSearch";
            this.cbQuickSearch.UseVisualStyleBackColor = true;
            this.cbQuickSearch.CheckedChanged += new System.EventHandler(this.cbQuickSearch_CheckedChanged);
            // 
            // cbDeepSearch
            // 
            this.cbDeepSearch.AutoSize = true;
            this.cbDeepSearch.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.cbDeepSearch.Location = new System.Drawing.Point(6, 132);
            this.cbDeepSearch.Name = "cbDeepSearch";
            this.cbDeepSearch.Size = new System.Drawing.Size(309, 37);
            this.cbDeepSearch.TabIndex = 47;
            this.cbDeepSearch.Text = "DeepSearch";
            this.cbDeepSearch.UseVisualStyleBackColor = true;
            this.cbDeepSearch.CheckedChanged += new System.EventHandler(this.cbDeepSearch_CheckedChanged);
            // 
            // pbnetwork
            // 
            this.pbnetwork.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbnetwork.ForeColor = System.Drawing.Color.Lime;
            this.pbnetwork.Location = new System.Drawing.Point(336, 221);
            this.pbnetwork.Name = "pbnetwork";
            this.pbnetwork.Size = new System.Drawing.Size(262, 15);
            this.pbnetwork.TabIndex = 48;
            this.pbnetwork.Click += new System.EventHandler(this.pbnetwork_Click);
            // 
            // tcsettings
            // 
            this.tcsettings.Controls.Add(this.tcGameSettings);
            this.tcsettings.Controls.Add(this.tcGameSettingsFreq);
            this.tcsettings.Controls.Add(this.tcIPConfiguration);
            this.tcsettings.Controls.Add(this.tcNetworkDiscovery);
            this.tcsettings.Location = new System.Drawing.Point(12, 12);
            this.tcsettings.Name = "tcsettings";
            this.tcsettings.SelectedIndex = 0;
            this.tcsettings.Size = new System.Drawing.Size(623, 369);
            this.tcsettings.TabIndex = 49;
            // 
            // tcGameSettings
            // 
            this.tcGameSettings.BackColor = System.Drawing.Color.Indigo;
            this.tcGameSettings.Controls.Add(this.lblGlättungsstufe);
            this.tcGameSettings.Controls.Add(this.lblEmpfindlichkeit);
            this.tcGameSettings.Controls.Add(this.tbEmpfindlichkeit);
            this.tcGameSettings.Controls.Add(this.tbGlättungsstufe);
            this.tcGameSettings.Location = new System.Drawing.Point(4, 22);
            this.tcGameSettings.Name = "tcGameSettings";
            this.tcGameSettings.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tcGameSettings.Size = new System.Drawing.Size(615, 343);
            this.tcGameSettings.TabIndex = 0;
            this.tcGameSettings.Text = "GameSettings";
            this.tcGameSettings.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lblGlättungsstufe
            // 
            this.lblGlättungsstufe.AutoSize = true;
            this.lblGlättungsstufe.BackColor = System.Drawing.Color.Indigo;
            this.lblGlättungsstufe.Font = new System.Drawing.Font("Wide Latin", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlättungsstufe.ForeColor = System.Drawing.Color.White;
            this.lblGlättungsstufe.Location = new System.Drawing.Point(5, 196);
            this.lblGlättungsstufe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGlättungsstufe.Name = "lblGlättungsstufe";
            this.lblGlättungsstufe.Size = new System.Drawing.Size(355, 33);
            this.lblGlättungsstufe.TabIndex = 7;
            this.lblGlättungsstufe.Text = "Glättungsstufe";
            // 
            // lblEmpfindlichkeit
            // 
            this.lblEmpfindlichkeit.AutoSize = true;
            this.lblEmpfindlichkeit.BackColor = System.Drawing.Color.Indigo;
            this.lblEmpfindlichkeit.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.lblEmpfindlichkeit.ForeColor = System.Drawing.Color.White;
            this.lblEmpfindlichkeit.Location = new System.Drawing.Point(5, 41);
            this.lblEmpfindlichkeit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpfindlichkeit.Name = "lblEmpfindlichkeit";
            this.lblEmpfindlichkeit.Size = new System.Drawing.Size(398, 33);
            this.lblEmpfindlichkeit.TabIndex = 6;
            this.lblEmpfindlichkeit.Text = "Empfindlichkeit";
            // 
            // tcIPConfiguration
            // 
            this.tcIPConfiguration.BackColor = System.Drawing.Color.Red;
            this.tcIPConfiguration.Controls.Add(this.tbx_IPClient);
            this.tcIPConfiguration.Controls.Add(this.tbx_PortServer);
            this.tcIPConfiguration.Controls.Add(this.tbx_IPServer);
            this.tcIPConfiguration.Controls.Add(this.lbl_IPServer);
            this.tcIPConfiguration.Controls.Add(this.lbl_PortServer);
            this.tcIPConfiguration.Controls.Add(this.lbl_ServerStart);
            this.tcIPConfiguration.Controls.Add(this.lbl_ClientConnect);
            this.tcIPConfiguration.Controls.Add(this.tbx_PortClient);
            this.tcIPConfiguration.Controls.Add(this.lbl_IPClient);
            this.tcIPConfiguration.Controls.Add(this.lbl_PortClient);
            this.tcIPConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tcIPConfiguration.Name = "tcIPConfiguration";
            this.tcIPConfiguration.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tcIPConfiguration.Size = new System.Drawing.Size(615, 343);
            this.tcIPConfiguration.TabIndex = 1;
            this.tcIPConfiguration.Text = "IP-Configuration";
            // 
            // tcNetworkDiscovery
            // 
            this.tcNetworkDiscovery.BackColor = System.Drawing.Color.DarkGreen;
            this.tcNetworkDiscovery.Controls.Add(this.cbQuickSearch);
            this.tcNetworkDiscovery.Controls.Add(this.lsb_discover);
            this.tcNetworkDiscovery.Controls.Add(this.pbnetwork);
            this.tcNetworkDiscovery.Controls.Add(this.btn_Discover);
            this.tcNetworkDiscovery.Controls.Add(this.cbDeepSearch);
            this.tcNetworkDiscovery.Controls.Add(this.tbx_Discovery);
            this.tcNetworkDiscovery.Controls.Add(this.btn_ActivateFirewall);
            this.tcNetworkDiscovery.Controls.Add(this.btn_deactivatefirewall);
            this.tcNetworkDiscovery.Location = new System.Drawing.Point(4, 22);
            this.tcNetworkDiscovery.Name = "tcNetworkDiscovery";
            this.tcNetworkDiscovery.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tcNetworkDiscovery.Size = new System.Drawing.Size(615, 343);
            this.tcNetworkDiscovery.TabIndex = 2;
            this.tcNetworkDiscovery.Text = "NetworkDiscovery";
            this.tcNetworkDiscovery.Click += new System.EventHandler(this.tc_Click);
            // 
            // tcGameSettingsFreq
            // 
            this.tcGameSettingsFreq.BackColor = System.Drawing.Color.Silver;
            this.tcGameSettingsFreq.Controls.Add(this.rBPfeifen);
            this.tcGameSettingsFreq.Controls.Add(this.rBSopran);
            this.tcGameSettingsFreq.Controls.Add(this.rBMezzosopran);
            this.tcGameSettingsFreq.Controls.Add(this.rBMaenneralt);
            this.tcGameSettingsFreq.Controls.Add(this.rBTenor);
            this.tcGameSettingsFreq.Controls.Add(this.rBBartion);
            this.tcGameSettingsFreq.Controls.Add(this.rBBass);
            this.tcGameSettingsFreq.Location = new System.Drawing.Point(4, 22);
            this.tcGameSettingsFreq.Name = "tcGameSettingsFreq";
            this.tcGameSettingsFreq.Padding = new System.Windows.Forms.Padding(3);
            this.tcGameSettingsFreq.Size = new System.Drawing.Size(615, 343);
            this.tcGameSettingsFreq.TabIndex = 3;
            this.tcGameSettingsFreq.Text = "GameSettings";
            // 
            // rBBass
            // 
            this.rBBass.AutoSize = true;
            this.rBBass.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.rBBass.Location = new System.Drawing.Point(23, 27);
            this.rBBass.Name = "rBBass";
            this.rBBass.Size = new System.Drawing.Size(145, 37);
            this.rBBass.TabIndex = 0;
            this.rBBass.TabStop = true;
            this.rBBass.Text = "Bass";
            this.rBBass.UseVisualStyleBackColor = true;
            // 
            // rBBartion
            // 
            this.rBBartion.AutoSize = true;
            this.rBBartion.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.rBBartion.Location = new System.Drawing.Point(23, 70);
            this.rBBartion.Name = "rBBartion";
            this.rBBartion.Size = new System.Drawing.Size(213, 37);
            this.rBBartion.TabIndex = 1;
            this.rBBartion.TabStop = true;
            this.rBBartion.Text = "Bariton";
            this.rBBartion.UseVisualStyleBackColor = true;
            // 
            // rBTenor
            // 
            this.rBTenor.AutoSize = true;
            this.rBTenor.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.rBTenor.Location = new System.Drawing.Point(23, 113);
            this.rBTenor.Name = "rBTenor";
            this.rBTenor.Size = new System.Drawing.Size(171, 37);
            this.rBTenor.TabIndex = 2;
            this.rBTenor.TabStop = true;
            this.rBTenor.Text = "Tenor";
            this.rBTenor.UseVisualStyleBackColor = true;
            // 
            // rBMaenneralt
            // 
            this.rBMaenneralt.AutoSize = true;
            this.rBMaenneralt.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.rBMaenneralt.Location = new System.Drawing.Point(23, 156);
            this.rBMaenneralt.Name = "rBMaenneralt";
            this.rBMaenneralt.Size = new System.Drawing.Size(274, 37);
            this.rBMaenneralt.TabIndex = 3;
            this.rBMaenneralt.TabStop = true;
            this.rBMaenneralt.Text = "Männeralt";
            this.rBMaenneralt.UseVisualStyleBackColor = true;
            // 
            // rBMezzosopran
            // 
            this.rBMezzosopran.AutoSize = true;
            this.rBMezzosopran.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.rBMezzosopran.Location = new System.Drawing.Point(23, 195);
            this.rBMezzosopran.Name = "rBMezzosopran";
            this.rBMezzosopran.Size = new System.Drawing.Size(339, 37);
            this.rBMezzosopran.TabIndex = 4;
            this.rBMezzosopran.TabStop = true;
            this.rBMezzosopran.Text = "Mezzosopran";
            this.rBMezzosopran.UseVisualStyleBackColor = true;
            // 
            // rBSopran
            // 
            this.rBSopran.AutoSize = true;
            this.rBSopran.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.rBSopran.Location = new System.Drawing.Point(23, 238);
            this.rBSopran.Name = "rBSopran";
            this.rBSopran.Size = new System.Drawing.Size(200, 37);
            this.rBSopran.TabIndex = 5;
            this.rBSopran.TabStop = true;
            this.rBSopran.Text = "Sopran";
            this.rBSopran.UseVisualStyleBackColor = true;
            // 
            // rBPfeifen
            // 
            this.rBPfeifen.AutoSize = true;
            this.rBPfeifen.Checked = true;
            this.rBPfeifen.Font = new System.Drawing.Font("Wide Latin", 19.8F);
            this.rBPfeifen.Location = new System.Drawing.Point(23, 281);
            this.rBPfeifen.Name = "rBPfeifen";
            this.rBPfeifen.Size = new System.Drawing.Size(206, 37);
            this.rBPfeifen.TabIndex = 6;
            this.rBPfeifen.TabStop = true;
            this.rBPfeifen.Text = "Pfeifen";
            this.rBPfeifen.UseVisualStyleBackColor = true;
            // 
            // ClientSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 393);
            this.Controls.Add(this.tcsettings);
            this.Name = "ClientSettings";
            this.Text = "ClientSettings";
            this.Load += new System.EventHandler(this.ClientSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpfindlichkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGlättungsstufe)).EndInit();
            this.cms.ResumeLayout(false);
            this.tcsettings.ResumeLayout(false);
            this.tcGameSettings.ResumeLayout(false);
            this.tcGameSettings.PerformLayout();
            this.tcIPConfiguration.ResumeLayout(false);
            this.tcIPConfiguration.PerformLayout();
            this.tcNetworkDiscovery.ResumeLayout(false);
            this.tcNetworkDiscovery.PerformLayout();
            this.tcGameSettingsFreq.ResumeLayout(false);
            this.tcGameSettingsFreq.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TrackBar tbEmpfindlichkeit;
        public System.Windows.Forms.TrackBar tbGlättungsstufe;
        public System.Windows.Forms.Label lbl_PortClient;
        public System.Windows.Forms.Label lbl_IPClient;
        public System.Windows.Forms.TextBox tbx_IPClient;
        public System.Windows.Forms.TextBox tbx_PortClient;
        public System.Windows.Forms.Label lbl_ClientConnect;
        public System.Windows.Forms.Label lbl_ServerStart;
        public System.Windows.Forms.Label lbl_PortServer;
        public System.Windows.Forms.Label lbl_IPServer;
        public System.Windows.Forms.TextBox tbx_IPServer;
        public System.Windows.Forms.TextBox tbx_PortServer;
        private System.Windows.Forms.Button btn_deactivatefirewall;
        private System.Windows.Forms.Button btn_ActivateFirewall;
        private System.Windows.Forms.TextBox tbx_Discovery;
        private System.Windows.Forms.Button btn_Discover;
        private System.Windows.Forms.ListBox lsb_discover;
        private System.Windows.Forms.CheckBox cbQuickSearch;
        private System.Windows.Forms.CheckBox cbDeepSearch;
        private System.Windows.Forms.ProgressBar pbnetwork;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.TabControl tcsettings;
        private System.Windows.Forms.TabPage tcGameSettings;
        private System.Windows.Forms.TabPage tcIPConfiguration;
        private System.Windows.Forms.TabPage tcNetworkDiscovery;
        private System.Windows.Forms.Label lblGlättungsstufe;
        private System.Windows.Forms.Label lblEmpfindlichkeit;
        private System.Windows.Forms.TabPage tcGameSettingsFreq;
        private System.Windows.Forms.RadioButton rBPfeifen;
        private System.Windows.Forms.RadioButton rBSopran;
        private System.Windows.Forms.RadioButton rBMezzosopran;
        private System.Windows.Forms.RadioButton rBMaenneralt;
        private System.Windows.Forms.RadioButton rBTenor;
        private System.Windows.Forms.RadioButton rBBartion;
        private System.Windows.Forms.RadioButton rBBass;
    }
}
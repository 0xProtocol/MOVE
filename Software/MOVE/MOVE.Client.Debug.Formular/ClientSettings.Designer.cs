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
            this.selectAdapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbQuickSearch = new System.Windows.Forms.CheckBox();
            this.cbDeepSearch = new System.Windows.Forms.CheckBox();
            this.pbnetwork = new System.Windows.Forms.ProgressBar();
            this.tcsettings = new System.Windows.Forms.TabControl();
            this.tcGameSettings = new System.Windows.Forms.TabPage();
            this.pbTrackBar = new System.Windows.Forms.PictureBox();
            this.lblGlättungsstufe = new System.Windows.Forms.Label();
            this.lblEmpfindlichkeit = new System.Windows.Forms.Label();
            this.tcFrequency = new System.Windows.Forms.TabPage();
            this.btnStopCal = new System.Windows.Forms.Button();
            this.btnStartCal = new System.Windows.Forms.Button();
            this.rBkalibrieren = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbThreshold = new System.Windows.Forms.TrackBar();
            this.pbMelody = new System.Windows.Forms.PictureBox();
            this.rBPfeifen = new System.Windows.Forms.RadioButton();
            this.rBSopran = new System.Windows.Forms.RadioButton();
            this.rBMezzosopran = new System.Windows.Forms.RadioButton();
            this.rBMaenneralt = new System.Windows.Forms.RadioButton();
            this.rBTenor = new System.Windows.Forms.RadioButton();
            this.rBBartion = new System.Windows.Forms.RadioButton();
            this.rBBass = new System.Windows.Forms.RadioButton();
            this.tcAddress = new System.Windows.Forms.TabPage();
            this.pbNet = new System.Windows.Forms.PictureBox();
            this.tcNetworkDiscovery = new System.Windows.Forms.TabPage();
            this.lsb_networkadapter = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pbGlasses = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpfindlichkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGlättungsstufe)).BeginInit();
            this.cms.SuspendLayout();
            this.tcsettings.SuspendLayout();
            this.tcGameSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrackBar)).BeginInit();
            this.tcFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMelody)).BeginInit();
            this.tcAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNet)).BeginInit();
            this.tcNetworkDiscovery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGlasses)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEmpfindlichkeit
            // 
            this.tbEmpfindlichkeit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tbEmpfindlichkeit.Location = new System.Drawing.Point(16, 59);
            this.tbEmpfindlichkeit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbEmpfindlichkeit.Maximum = 3;
            this.tbEmpfindlichkeit.Minimum = 1;
            this.tbEmpfindlichkeit.Name = "tbEmpfindlichkeit";
            this.tbEmpfindlichkeit.Size = new System.Drawing.Size(799, 56);
            this.tbEmpfindlichkeit.TabIndex = 4;
            this.tbEmpfindlichkeit.Value = 1;
            this.tbEmpfindlichkeit.Scroll += new System.EventHandler(this.tbEmpfindlichkeit_Scroll);
            // 
            // tbGlättungsstufe
            // 
            this.tbGlättungsstufe.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tbGlättungsstufe.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbGlättungsstufe.Location = new System.Drawing.Point(13, 236);
            this.tbGlättungsstufe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbGlättungsstufe.Maximum = 3;
            this.tbGlättungsstufe.Minimum = 1;
            this.tbGlättungsstufe.Name = "tbGlättungsstufe";
            this.tbGlättungsstufe.Size = new System.Drawing.Size(801, 56);
            this.tbGlättungsstufe.TabIndex = 5;
            this.tbGlättungsstufe.Value = 1;
            this.tbGlättungsstufe.Scroll += new System.EventHandler(this.tbGlättungsstufe_Scroll);
            // 
            // lbl_PortClient
            // 
            this.lbl_PortClient.AutoSize = true;
            this.lbl_PortClient.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PortClient.Location = new System.Drawing.Point(415, 334);
            this.lbl_PortClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PortClient.Name = "lbl_PortClient";
            this.lbl_PortClient.Size = new System.Drawing.Size(79, 37);
            this.lbl_PortClient.TabIndex = 40;
            this.lbl_PortClient.Text = "Port";
            // 
            // lbl_IPClient
            // 
            this.lbl_IPClient.AutoSize = true;
            this.lbl_IPClient.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IPClient.Location = new System.Drawing.Point(447, 286);
            this.lbl_IPClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_IPClient.Name = "lbl_IPClient";
            this.lbl_IPClient.Size = new System.Drawing.Size(45, 37);
            this.lbl_IPClient.TabIndex = 39;
            this.lbl_IPClient.Text = "IP";
            // 
            // tbx_IPClient
            // 
            this.tbx_IPClient.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_IPClient.Location = new System.Drawing.Point(501, 277);
            this.tbx_IPClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_IPClient.Name = "tbx_IPClient";
            this.tbx_IPClient.Size = new System.Drawing.Size(303, 46);
            this.tbx_IPClient.TabIndex = 38;
            this.tbx_IPClient.Text = "127.0.0.1";
            // 
            // tbx_PortClient
            // 
            this.tbx_PortClient.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_PortClient.Location = new System.Drawing.Point(501, 331);
            this.tbx_PortClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_PortClient.Name = "tbx_PortClient";
            this.tbx_PortClient.Size = new System.Drawing.Size(303, 46);
            this.tbx_PortClient.TabIndex = 37;
            this.tbx_PortClient.Text = "4712";
            // 
            // lbl_ClientConnect
            // 
            this.lbl_ClientConnect.AutoSize = true;
            this.lbl_ClientConnect.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ClientConnect.Location = new System.Drawing.Point(495, 235);
            this.lbl_ClientConnect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ClientConnect.Name = "lbl_ClientConnect";
            this.lbl_ClientConnect.Size = new System.Drawing.Size(110, 37);
            this.lbl_ClientConnect.TabIndex = 36;
            this.lbl_ClientConnect.Text = "Client";
            // 
            // lbl_ServerStart
            // 
            this.lbl_ServerStart.AutoSize = true;
            this.lbl_ServerStart.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ServerStart.Location = new System.Drawing.Point(91, 235);
            this.lbl_ServerStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ServerStart.Name = "lbl_ServerStart";
            this.lbl_ServerStart.Size = new System.Drawing.Size(119, 37);
            this.lbl_ServerStart.TabIndex = 35;
            this.lbl_ServerStart.Text = "Server";
            // 
            // lbl_PortServer
            // 
            this.lbl_PortServer.AutoSize = true;
            this.lbl_PortServer.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PortServer.Location = new System.Drawing.Point(11, 334);
            this.lbl_PortServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PortServer.Name = "lbl_PortServer";
            this.lbl_PortServer.Size = new System.Drawing.Size(79, 37);
            this.lbl_PortServer.TabIndex = 34;
            this.lbl_PortServer.Text = "Port";
            // 
            // lbl_IPServer
            // 
            this.lbl_IPServer.AutoSize = true;
            this.lbl_IPServer.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IPServer.Location = new System.Drawing.Point(11, 286);
            this.lbl_IPServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_IPServer.Name = "lbl_IPServer";
            this.lbl_IPServer.Size = new System.Drawing.Size(45, 37);
            this.lbl_IPServer.TabIndex = 33;
            this.lbl_IPServer.Text = "IP";
            // 
            // tbx_IPServer
            // 
            this.tbx_IPServer.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_IPServer.Location = new System.Drawing.Point(99, 277);
            this.tbx_IPServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_IPServer.Name = "tbx_IPServer";
            this.tbx_IPServer.Size = new System.Drawing.Size(303, 46);
            this.tbx_IPServer.TabIndex = 32;
            this.tbx_IPServer.Text = "127.0.0.1";
            // 
            // tbx_PortServer
            // 
            this.tbx_PortServer.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_PortServer.Location = new System.Drawing.Point(99, 334);
            this.tbx_PortServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_PortServer.Name = "tbx_PortServer";
            this.tbx_PortServer.Size = new System.Drawing.Size(303, 46);
            this.tbx_PortServer.TabIndex = 31;
            this.tbx_PortServer.Text = "4711";
            // 
            // btn_deactivatefirewall
            // 
            this.btn_deactivatefirewall.Font = new System.Drawing.Font("Rockwell", 18.5F);
            this.btn_deactivatefirewall.Location = new System.Drawing.Point(448, 255);
            this.btn_deactivatefirewall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_deactivatefirewall.Name = "btn_deactivatefirewall";
            this.btn_deactivatefirewall.Size = new System.Drawing.Size(349, 49);
            this.btn_deactivatefirewall.TabIndex = 45;
            this.btn_deactivatefirewall.Text = "Firewall deaktivieren";
            this.btn_deactivatefirewall.UseVisualStyleBackColor = true;
            this.btn_deactivatefirewall.Click += new System.EventHandler(this.btn_deactivatefirewall_Click);
            // 
            // btn_ActivateFirewall
            // 
            this.btn_ActivateFirewall.Font = new System.Drawing.Font("Rockwell", 18.5F);
            this.btn_ActivateFirewall.Location = new System.Drawing.Point(448, 198);
            this.btn_ActivateFirewall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ActivateFirewall.Name = "btn_ActivateFirewall";
            this.btn_ActivateFirewall.Size = new System.Drawing.Size(349, 49);
            this.btn_ActivateFirewall.TabIndex = 44;
            this.btn_ActivateFirewall.Text = "Firewall aktivieren";
            this.btn_ActivateFirewall.UseVisualStyleBackColor = true;
            this.btn_ActivateFirewall.Click += new System.EventHandler(this.btn_ActivateFirewall_Click);
            // 
            // tbx_Discovery
            // 
            this.tbx_Discovery.Location = new System.Drawing.Point(8, 361);
            this.tbx_Discovery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_Discovery.Name = "tbx_Discovery";
            this.tbx_Discovery.Size = new System.Drawing.Size(425, 23);
            this.tbx_Discovery.TabIndex = 43;
            this.tbx_Discovery.TextChanged += new System.EventHandler(this.tbx_Discovery_TextChanged);
            // 
            // btn_Discover
            // 
            this.btn_Discover.Font = new System.Drawing.Font("Rockwell", 18.5F);
            this.btn_Discover.Location = new System.Drawing.Point(448, 313);
            this.btn_Discover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Discover.Name = "btn_Discover";
            this.btn_Discover.Size = new System.Drawing.Size(349, 50);
            this.btn_Discover.TabIndex = 42;
            this.btn_Discover.Text = "Starte Erkennung";
            this.btn_Discover.UseVisualStyleBackColor = true;
            this.btn_Discover.Click += new System.EventHandler(this.btn_Discover_Click);
            // 
            // lsb_discover
            // 
            this.lsb_discover.ContextMenuStrip = this.cms;
            this.lsb_discover.FormattingEnabled = true;
            this.lsb_discover.ItemHeight = 16;
            this.lsb_discover.Location = new System.Drawing.Point(13, 188);
            this.lsb_discover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsb_discover.Name = "lsb_discover";
            this.lsb_discover.Size = new System.Drawing.Size(425, 148);
            this.lsb_discover.TabIndex = 41;
            this.lsb_discover.Click += new System.EventHandler(this.lsb_discover_Click);
            this.lsb_discover.SelectedIndexChanged += new System.EventHandler(this.lsb_discover_SelectedIndexChanged);
            this.lsb_discover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsb_discover_MouseDown);
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.selectAdapterToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(177, 76);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.clientToolStripMenuItem.Text = "Client";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.serverToolStripMenuItem.Text = "Server";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.serverToolStripMenuItem_Click);
            // 
            // selectAdapterToolStripMenuItem
            // 
            this.selectAdapterToolStripMenuItem.Name = "selectAdapterToolStripMenuItem";
            this.selectAdapterToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.selectAdapterToolStripMenuItem.Text = "Select Adapter";
            this.selectAdapterToolStripMenuItem.Click += new System.EventHandler(this.selectAdapterToolStripMenuItem_Click);
            // 
            // cbQuickSearch
            // 
            this.cbQuickSearch.AutoSize = true;
            this.cbQuickSearch.Font = new System.Drawing.Font("Rockwell", 17.8F);
            this.cbQuickSearch.Location = new System.Drawing.Point(232, 143);
            this.cbQuickSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbQuickSearch.Name = "cbQuickSearch";
            this.cbQuickSearch.Size = new System.Drawing.Size(219, 39);
            this.cbQuickSearch.TabIndex = 46;
            this.cbQuickSearch.Text = "Schnellsuche";
            this.cbQuickSearch.UseVisualStyleBackColor = true;
            this.cbQuickSearch.CheckedChanged += new System.EventHandler(this.cbQuickSearch_CheckedChanged);
            // 
            // cbDeepSearch
            // 
            this.cbDeepSearch.AutoSize = true;
            this.cbDeepSearch.Font = new System.Drawing.Font("Rockwell", 17.8F);
            this.cbDeepSearch.Location = new System.Drawing.Point(13, 143);
            this.cbDeepSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDeepSearch.Name = "cbDeepSearch";
            this.cbDeepSearch.Size = new System.Drawing.Size(170, 39);
            this.cbDeepSearch.TabIndex = 47;
            this.cbDeepSearch.Text = "Tiefsuche";
            this.cbDeepSearch.UseVisualStyleBackColor = true;
            this.cbDeepSearch.CheckedChanged += new System.EventHandler(this.cbDeepSearch_CheckedChanged);
            // 
            // pbnetwork
            // 
            this.pbnetwork.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbnetwork.ForeColor = System.Drawing.Color.Lime;
            this.pbnetwork.Location = new System.Drawing.Point(448, 370);
            this.pbnetwork.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbnetwork.Name = "pbnetwork";
            this.pbnetwork.Size = new System.Drawing.Size(349, 22);
            this.pbnetwork.TabIndex = 48;
            this.pbnetwork.Click += new System.EventHandler(this.pbnetwork_Click);
            // 
            // tcsettings
            // 
            this.tcsettings.Controls.Add(this.tcGameSettings);
            this.tcsettings.Controls.Add(this.tcFrequency);
            this.tcsettings.Controls.Add(this.tcAddress);
            this.tcsettings.Controls.Add(this.tcNetworkDiscovery);
            this.tcsettings.Font = new System.Drawing.Font("Rockwell", 7.8F);
            this.tcsettings.Location = new System.Drawing.Point(16, 15);
            this.tcsettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcsettings.Name = "tcsettings";
            this.tcsettings.SelectedIndex = 0;
            this.tcsettings.Size = new System.Drawing.Size(831, 454);
            this.tcsettings.TabIndex = 49;
            this.tcsettings.SelectedIndexChanged += new System.EventHandler(this.tcsettings_SelectedIndexChanged);
            // 
            // tcGameSettings
            // 
            this.tcGameSettings.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tcGameSettings.Controls.Add(this.pbTrackBar);
            this.tcGameSettings.Controls.Add(this.lblGlättungsstufe);
            this.tcGameSettings.Controls.Add(this.lblEmpfindlichkeit);
            this.tcGameSettings.Controls.Add(this.tbEmpfindlichkeit);
            this.tcGameSettings.Controls.Add(this.tbGlättungsstufe);
            this.tcGameSettings.Location = new System.Drawing.Point(4, 25);
            this.tcGameSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcGameSettings.Name = "tcGameSettings";
            this.tcGameSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcGameSettings.Size = new System.Drawing.Size(823, 425);
            this.tcGameSettings.TabIndex = 0;
            this.tcGameSettings.Text = "Spieleinstellungen";
            this.tcGameSettings.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // pbTrackBar
            // 
            this.pbTrackBar.Image = global::MOVE.Client.Debug.Formular.Properties.Resources.track_and_status_controls_trackbar_programming_radtrackbar020;
            this.pbTrackBar.Location = new System.Drawing.Point(172, 281);
            this.pbTrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbTrackBar.Name = "pbTrackBar";
            this.pbTrackBar.Size = new System.Drawing.Size(464, 122);
            this.pbTrackBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTrackBar.TabIndex = 8;
            this.pbTrackBar.TabStop = false;
            // 
            // lblGlättungsstufe
            // 
            this.lblGlättungsstufe.AutoSize = true;
            this.lblGlättungsstufe.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblGlättungsstufe.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lblGlättungsstufe.ForeColor = System.Drawing.Color.Brown;
            this.lblGlättungsstufe.Location = new System.Drawing.Point(291, 194);
            this.lblGlättungsstufe.Name = "lblGlättungsstufe";
            this.lblGlättungsstufe.Size = new System.Drawing.Size(238, 37);
            this.lblGlättungsstufe.TabIndex = 7;
            this.lblGlättungsstufe.Text = "Glättungsstufe";
            // 
            // lblEmpfindlichkeit
            // 
            this.lblEmpfindlichkeit.AutoSize = true;
            this.lblEmpfindlichkeit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblEmpfindlichkeit.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.lblEmpfindlichkeit.ForeColor = System.Drawing.Color.Brown;
            this.lblEmpfindlichkeit.Location = new System.Drawing.Point(280, 18);
            this.lblEmpfindlichkeit.Name = "lblEmpfindlichkeit";
            this.lblEmpfindlichkeit.Size = new System.Drawing.Size(262, 37);
            this.lblEmpfindlichkeit.TabIndex = 6;
            this.lblEmpfindlichkeit.Text = "Empfindlichkeit";
            // 
            // tcFrequency
            // 
            this.tcFrequency.BackColor = System.Drawing.Color.Silver;
            this.tcFrequency.Controls.Add(this.btnStopCal);
            this.tcFrequency.Controls.Add(this.btnStartCal);
            this.tcFrequency.Controls.Add(this.rBkalibrieren);
            this.tcFrequency.Controls.Add(this.label1);
            this.tcFrequency.Controls.Add(this.tbThreshold);
            this.tcFrequency.Controls.Add(this.pbMelody);
            this.tcFrequency.Controls.Add(this.rBPfeifen);
            this.tcFrequency.Controls.Add(this.rBSopran);
            this.tcFrequency.Controls.Add(this.rBMezzosopran);
            this.tcFrequency.Controls.Add(this.rBMaenneralt);
            this.tcFrequency.Controls.Add(this.rBTenor);
            this.tcFrequency.Controls.Add(this.rBBartion);
            this.tcFrequency.Controls.Add(this.rBBass);
            this.tcFrequency.Location = new System.Drawing.Point(4, 25);
            this.tcFrequency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcFrequency.Name = "tcFrequency";
            this.tcFrequency.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcFrequency.Size = new System.Drawing.Size(823, 425);
            this.tcFrequency.TabIndex = 3;
            this.tcFrequency.Text = "Frequenzeinstellungen";
            this.tcFrequency.Click += new System.EventHandler(this.tcGameSettingsFreq_Click);
            // 
            // btnStopCal
            // 
            this.btnStopCal.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.btnStopCal.Location = new System.Drawing.Point(355, 357);
            this.btnStopCal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopCal.Name = "btnStopCal";
            this.btnStopCal.Size = new System.Drawing.Size(111, 49);
            this.btnStopCal.TabIndex = 89;
            this.btnStopCal.Text = "Stop";
            this.btnStopCal.UseVisualStyleBackColor = true;
            this.btnStopCal.Click += new System.EventHandler(this.btnStopCal_Click_1);
            // 
            // btnStartCal
            // 
            this.btnStartCal.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.btnStartCal.Location = new System.Drawing.Point(236, 357);
            this.btnStartCal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartCal.Name = "btnStartCal";
            this.btnStartCal.Size = new System.Drawing.Size(111, 49);
            this.btnStartCal.TabIndex = 88;
            this.btnStartCal.Text = "Start";
            this.btnStartCal.UseVisualStyleBackColor = true;
            this.btnStartCal.Click += new System.EventHandler(this.btnStartCal_Click_1);
            // 
            // rBkalibrieren
            // 
            this.rBkalibrieren.AutoSize = true;
            this.rBkalibrieren.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBkalibrieren.Location = new System.Drawing.Point(8, 361);
            this.rBkalibrieren.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBkalibrieren.Name = "rBkalibrieren";
            this.rBkalibrieren.Size = new System.Drawing.Size(185, 41);
            this.rBkalibrieren.TabIndex = 10;
            this.rBkalibrieren.Text = "Kalibriert";
            this.rBkalibrieren.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 19.8F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(349, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Aufnahmeschwelle";
            // 
            // tbThreshold
            // 
            this.tbThreshold.BackColor = System.Drawing.Color.Silver;
            this.tbThreshold.LargeChange = 1;
            this.tbThreshold.Location = new System.Drawing.Point(357, 63);
            this.tbThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbThreshold.Maximum = 9;
            this.tbThreshold.Minimum = 1;
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(447, 56);
            this.tbThreshold.TabIndex = 8;
            this.tbThreshold.Value = 1;
            // 
            // pbMelody
            // 
            this.pbMelody.Image = global::MOVE.Client.Debug.Formular.Properties.Resources.Move;
            this.pbMelody.Location = new System.Drawing.Point(537, 159);
            this.pbMelody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbMelody.Name = "pbMelody";
            this.pbMelody.Size = new System.Drawing.Size(267, 246);
            this.pbMelody.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMelody.TabIndex = 7;
            this.pbMelody.TabStop = false;
            // 
            // rBPfeifen
            // 
            this.rBPfeifen.AutoSize = true;
            this.rBPfeifen.Checked = true;
            this.rBPfeifen.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBPfeifen.Location = new System.Drawing.Point(8, 310);
            this.rBPfeifen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBPfeifen.Name = "rBPfeifen";
            this.rBPfeifen.Size = new System.Drawing.Size(144, 41);
            this.rBPfeifen.TabIndex = 6;
            this.rBPfeifen.TabStop = true;
            this.rBPfeifen.Text = "Pfeifen";
            this.rBPfeifen.UseVisualStyleBackColor = true;
            this.rBPfeifen.CheckedChanged += new System.EventHandler(this.rBPfeifen_CheckedChanged);
            // 
            // rBSopran
            // 
            this.rBSopran.AutoSize = true;
            this.rBSopran.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBSopran.Location = new System.Drawing.Point(8, 260);
            this.rBSopran.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBSopran.Name = "rBSopran";
            this.rBSopran.Size = new System.Drawing.Size(147, 41);
            this.rBSopran.TabIndex = 5;
            this.rBSopran.Text = "Sopran";
            this.rBSopran.UseVisualStyleBackColor = true;
            this.rBSopran.CheckedChanged += new System.EventHandler(this.rBSopran_CheckedChanged);
            // 
            // rBMezzosopran
            // 
            this.rBMezzosopran.AutoSize = true;
            this.rBMezzosopran.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBMezzosopran.Location = new System.Drawing.Point(8, 209);
            this.rBMezzosopran.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBMezzosopran.Name = "rBMezzosopran";
            this.rBMezzosopran.Size = new System.Drawing.Size(241, 41);
            this.rBMezzosopran.TabIndex = 4;
            this.rBMezzosopran.Text = "Mezzosopran";
            this.rBMezzosopran.UseVisualStyleBackColor = true;
            // 
            // rBMaenneralt
            // 
            this.rBMaenneralt.AutoSize = true;
            this.rBMaenneralt.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBMaenneralt.Location = new System.Drawing.Point(8, 159);
            this.rBMaenneralt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBMaenneralt.Name = "rBMaenneralt";
            this.rBMaenneralt.Size = new System.Drawing.Size(194, 41);
            this.rBMaenneralt.TabIndex = 3;
            this.rBMaenneralt.Text = "Männeralt";
            this.rBMaenneralt.UseVisualStyleBackColor = true;
            this.rBMaenneralt.CheckedChanged += new System.EventHandler(this.rBMaenneralt_CheckedChanged);
            // 
            // rBTenor
            // 
            this.rBTenor.AutoSize = true;
            this.rBTenor.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBTenor.Location = new System.Drawing.Point(8, 108);
            this.rBTenor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBTenor.Name = "rBTenor";
            this.rBTenor.Size = new System.Drawing.Size(128, 41);
            this.rBTenor.TabIndex = 2;
            this.rBTenor.Text = "Tenor";
            this.rBTenor.UseVisualStyleBackColor = true;
            this.rBTenor.CheckedChanged += new System.EventHandler(this.rBTenor_CheckedChanged);
            // 
            // rBBartion
            // 
            this.rBBartion.AutoSize = true;
            this.rBBartion.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBBartion.Location = new System.Drawing.Point(8, 58);
            this.rBBartion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBBartion.Name = "rBBartion";
            this.rBBartion.Size = new System.Drawing.Size(147, 41);
            this.rBBartion.TabIndex = 1;
            this.rBBartion.Text = "Bariton";
            this.rBBartion.UseVisualStyleBackColor = true;
            this.rBBartion.CheckedChanged += new System.EventHandler(this.rBBartion_CheckedChanged);
            // 
            // rBBass
            // 
            this.rBBass.AutoSize = true;
            this.rBBass.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBBass.Location = new System.Drawing.Point(8, 7);
            this.rBBass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBBass.Name = "rBBass";
            this.rBBass.Size = new System.Drawing.Size(105, 41);
            this.rBBass.TabIndex = 0;
            this.rBBass.Text = "Bass";
            this.rBBass.UseVisualStyleBackColor = true;
            this.rBBass.CheckedChanged += new System.EventHandler(this.rBBass_CheckedChanged);
            // 
            // tcAddress
            // 
            this.tcAddress.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tcAddress.Controls.Add(this.pbNet);
            this.tcAddress.Controls.Add(this.tbx_IPClient);
            this.tcAddress.Controls.Add(this.tbx_PortServer);
            this.tcAddress.Controls.Add(this.tbx_IPServer);
            this.tcAddress.Controls.Add(this.lbl_IPServer);
            this.tcAddress.Controls.Add(this.lbl_PortServer);
            this.tcAddress.Controls.Add(this.lbl_ServerStart);
            this.tcAddress.Controls.Add(this.lbl_ClientConnect);
            this.tcAddress.Controls.Add(this.tbx_PortClient);
            this.tcAddress.Controls.Add(this.lbl_IPClient);
            this.tcAddress.Controls.Add(this.lbl_PortClient);
            this.tcAddress.Location = new System.Drawing.Point(4, 25);
            this.tcAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcAddress.Name = "tcAddress";
            this.tcAddress.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcAddress.Size = new System.Drawing.Size(823, 425);
            this.tcAddress.TabIndex = 1;
            this.tcAddress.Text = "Adresseinstellungen";
            // 
            // pbNet
            // 
            this.pbNet.Image = global::MOVE.Client.Debug.Formular.Properties.Resources.World2;
            this.pbNet.Location = new System.Drawing.Point(329, 20);
            this.pbNet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbNet.Name = "pbNet";
            this.pbNet.Size = new System.Drawing.Size(205, 190);
            this.pbNet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNet.TabIndex = 41;
            this.pbNet.TabStop = false;
            // 
            // tcNetworkDiscovery
            // 
            this.tcNetworkDiscovery.BackColor = System.Drawing.Color.LawnGreen;
            this.tcNetworkDiscovery.Controls.Add(this.lsb_networkadapter);
            this.tcNetworkDiscovery.Controls.Add(this.textBox1);
            this.tcNetworkDiscovery.Controls.Add(this.pbGlasses);
            this.tcNetworkDiscovery.Controls.Add(this.cbQuickSearch);
            this.tcNetworkDiscovery.Controls.Add(this.lsb_discover);
            this.tcNetworkDiscovery.Controls.Add(this.pbnetwork);
            this.tcNetworkDiscovery.Controls.Add(this.btn_Discover);
            this.tcNetworkDiscovery.Controls.Add(this.cbDeepSearch);
            this.tcNetworkDiscovery.Controls.Add(this.tbx_Discovery);
            this.tcNetworkDiscovery.Controls.Add(this.btn_ActivateFirewall);
            this.tcNetworkDiscovery.Controls.Add(this.btn_deactivatefirewall);
            this.tcNetworkDiscovery.Location = new System.Drawing.Point(4, 25);
            this.tcNetworkDiscovery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcNetworkDiscovery.Name = "tcNetworkDiscovery";
            this.tcNetworkDiscovery.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcNetworkDiscovery.Size = new System.Drawing.Size(823, 425);
            this.tcNetworkDiscovery.TabIndex = 2;
            this.tcNetworkDiscovery.Text = "Netzwerkerkennung";
            this.tcNetworkDiscovery.Click += new System.EventHandler(this.tc_Click);
            // 
            // lsb_networkadapter
            // 
            this.lsb_networkadapter.ContextMenuStrip = this.cms;
            this.lsb_networkadapter.FormattingEnabled = true;
            this.lsb_networkadapter.ItemHeight = 16;
            this.lsb_networkadapter.Location = new System.Drawing.Point(13, 18);
            this.lsb_networkadapter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsb_networkadapter.Name = "lsb_networkadapter";
            this.lsb_networkadapter.Size = new System.Drawing.Size(425, 100);
            this.lsb_networkadapter.TabIndex = 93;
            this.lsb_networkadapter.Click += new System.EventHandler(this.lsb_networkadapter_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 390);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(425, 23);
            this.textBox1.TabIndex = 50;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pbGlasses
            // 
            this.pbGlasses.Image = global::MOVE.Client.Debug.Formular.Properties.Resources.lupe_ani1_optlins_aus1;
            this.pbGlasses.Location = new System.Drawing.Point(565, 47);
            this.pbGlasses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbGlasses.Name = "pbGlasses";
            this.pbGlasses.Size = new System.Drawing.Size(232, 134);
            this.pbGlasses.TabIndex = 49;
            this.pbGlasses.TabStop = false;
            // 
            // ClientSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 484);
            this.Controls.Add(this.tcsettings);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClientSettings";
            this.Text = "ClientSettings";
            this.Activated += new System.EventHandler(this.ClientSettings_Activated);
            this.Deactivate += new System.EventHandler(this.ClientSettings_Deactivate);
            this.Load += new System.EventHandler(this.ClientSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpfindlichkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGlättungsstufe)).EndInit();
            this.cms.ResumeLayout(false);
            this.tcsettings.ResumeLayout(false);
            this.tcGameSettings.ResumeLayout(false);
            this.tcGameSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrackBar)).EndInit();
            this.tcFrequency.ResumeLayout(false);
            this.tcFrequency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMelody)).EndInit();
            this.tcAddress.ResumeLayout(false);
            this.tcAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNet)).EndInit();
            this.tcNetworkDiscovery.ResumeLayout(false);
            this.tcNetworkDiscovery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGlasses)).EndInit();
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
        private System.Windows.Forms.TabPage tcAddress;
        private System.Windows.Forms.TabPage tcNetworkDiscovery;
        private System.Windows.Forms.Label lblGlättungsstufe;
        private System.Windows.Forms.Label lblEmpfindlichkeit;
        private System.Windows.Forms.TabPage tcFrequency;
        private System.Windows.Forms.RadioButton rBPfeifen;
        private System.Windows.Forms.RadioButton rBSopran;
        private System.Windows.Forms.RadioButton rBMezzosopran;
        private System.Windows.Forms.RadioButton rBMaenneralt;
        private System.Windows.Forms.RadioButton rBTenor;
        private System.Windows.Forms.RadioButton rBBartion;
        private System.Windows.Forms.RadioButton rBBass;
        private System.Windows.Forms.PictureBox pbMelody;
        private System.Windows.Forms.PictureBox pbNet;
        private System.Windows.Forms.PictureBox pbGlasses;
        private System.Windows.Forms.PictureBox pbTrackBar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lsb_networkadapter;
        private System.Windows.Forms.ToolStripMenuItem selectAdapterToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TrackBar tbThreshold;
        private System.Windows.Forms.RadioButton rBkalibrieren;
        private System.Windows.Forms.Button btnStopCal;
        private System.Windows.Forms.Button btnStartCal;
    }
}
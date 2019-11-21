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
            this.tcIPConfiguration = new System.Windows.Forms.TabPage();
            this.tcNetworkDicovery = new System.Windows.Forms.TabPage();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGlättung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbempfindlichkeit)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tcGameSettings.SuspendLayout();
            this.tcIPConfiguration.SuspendLayout();
            this.tcNetworkDicovery.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms
            // 
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
            this.tbx_IPClient.Location = new System.Drawing.Point(337, 260);
            this.tbx_IPClient.Name = "tbx_IPClient";
            this.tbx_IPClient.Size = new System.Drawing.Size(100, 20);
            this.tbx_IPClient.TabIndex = 73;
            this.tbx_IPClient.Text = "127.0.0.1";
            // 
            // lbl_IPServer
            // 
            this.lbl_IPServer.AutoSize = true;
            this.lbl_IPServer.Location = new System.Drawing.Point(315, 260);
            this.lbl_IPServer.Name = "lbl_IPServer";
            this.lbl_IPServer.Size = new System.Drawing.Size(17, 13);
            this.lbl_IPServer.TabIndex = 74;
            this.lbl_IPServer.Text = "IP";
            // 
            // lbl_ServerStart
            // 
            this.lbl_ServerStart.AutoSize = true;
            this.lbl_ServerStart.Location = new System.Drawing.Point(407, 245);
            this.lbl_ServerStart.Name = "lbl_ServerStart";
            this.lbl_ServerStart.Size = new System.Drawing.Size(33, 13);
            this.lbl_ServerStart.TabIndex = 76;
            this.lbl_ServerStart.Text = "Client";
            // 
            // lbl_IPClient
            // 
            this.lbl_IPClient.AutoSize = true;
            this.lbl_IPClient.Location = new System.Drawing.Point(471, 260);
            this.lbl_IPClient.Name = "lbl_IPClient";
            this.lbl_IPClient.Size = new System.Drawing.Size(17, 13);
            this.lbl_IPClient.TabIndex = 78;
            this.lbl_IPClient.Text = "IP";
            // 
            // lbl_PortClient
            // 
            this.lbl_PortClient.AutoSize = true;
            this.lbl_PortClient.Location = new System.Drawing.Point(462, 287);
            this.lbl_PortClient.Name = "lbl_PortClient";
            this.lbl_PortClient.Size = new System.Drawing.Size(26, 13);
            this.lbl_PortClient.TabIndex = 79;
            this.lbl_PortClient.Text = "Port";
            // 
            // tbx_PortServer
            // 
            this.tbx_PortServer.Location = new System.Drawing.Point(494, 286);
            this.tbx_PortServer.Name = "tbx_PortServer";
            this.tbx_PortServer.Size = new System.Drawing.Size(100, 20);
            this.tbx_PortServer.TabIndex = 80;
            this.tbx_PortServer.Text = "4712";
            // 
            // lbl_ClientConnect
            // 
            this.lbl_ClientConnect.AutoSize = true;
            this.lbl_ClientConnect.Location = new System.Drawing.Point(560, 242);
            this.lbl_ClientConnect.Name = "lbl_ClientConnect";
            this.lbl_ClientConnect.Size = new System.Drawing.Size(38, 13);
            this.lbl_ClientConnect.TabIndex = 77;
            this.lbl_ClientConnect.Text = "Server";
            // 
            // tbx_IPServer
            // 
            this.tbx_IPServer.Location = new System.Drawing.Point(494, 260);
            this.tbx_IPServer.Name = "tbx_IPServer";
            this.tbx_IPServer.Size = new System.Drawing.Size(100, 20);
            this.tbx_IPServer.TabIndex = 81;
            this.tbx_IPServer.Text = "127.0.0.1";
            // 
            // tbx_PortClient
            // 
            this.tbx_PortClient.Location = new System.Drawing.Point(337, 286);
            this.tbx_PortClient.Name = "tbx_PortClient";
            this.tbx_PortClient.Size = new System.Drawing.Size(100, 20);
            this.tbx_PortClient.TabIndex = 72;
            this.tbx_PortClient.Text = "4711";
            // 
            // lbl_PortServer
            // 
            this.lbl_PortServer.AutoSize = true;
            this.lbl_PortServer.Location = new System.Drawing.Point(305, 285);
            this.lbl_PortServer.Name = "lbl_PortServer";
            this.lbl_PortServer.Size = new System.Drawing.Size(26, 13);
            this.lbl_PortServer.TabIndex = 75;
            this.lbl_PortServer.Text = "Port";
            // 
            // btn_ActivateFirewall
            // 
            this.btn_ActivateFirewall.Location = new System.Drawing.Point(201, 164);
            this.btn_ActivateFirewall.Name = "btn_ActivateFirewall";
            this.btn_ActivateFirewall.Size = new System.Drawing.Size(120, 23);
            this.btn_ActivateFirewall.TabIndex = 85;
            this.btn_ActivateFirewall.Text = "Activate Firewall";
            this.btn_ActivateFirewall.UseVisualStyleBackColor = true;
            this.btn_ActivateFirewall.Click += new System.EventHandler(this.btn_ActivateFirewall_Click);
            // 
            // btn_deactivatefirewall
            // 
            this.btn_deactivatefirewall.Location = new System.Drawing.Point(201, 193);
            this.btn_deactivatefirewall.Name = "btn_deactivatefirewall";
            this.btn_deactivatefirewall.Size = new System.Drawing.Size(120, 23);
            this.btn_deactivatefirewall.TabIndex = 86;
            this.btn_deactivatefirewall.Text = "Deactivate Firewall";
            this.btn_deactivatefirewall.UseVisualStyleBackColor = true;
            this.btn_deactivatefirewall.Click += new System.EventHandler(this.btn_deactivatefirewall_Click);
            // 
            // btn_Discover
            // 
            this.btn_Discover.Location = new System.Drawing.Point(201, 262);
            this.btn_Discover.Name = "btn_Discover";
            this.btn_Discover.Size = new System.Drawing.Size(120, 23);
            this.btn_Discover.TabIndex = 83;
            this.btn_Discover.Text = "Start Discovery";
            this.btn_Discover.UseVisualStyleBackColor = true;
            this.btn_Discover.Click += new System.EventHandler(this.btn_Discover_Click);
            // 
            // pbnetwork
            // 
            this.pbnetwork.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbnetwork.ForeColor = System.Drawing.Color.Lime;
            this.pbnetwork.Location = new System.Drawing.Point(201, 246);
            this.pbnetwork.Name = "pbnetwork";
            this.pbnetwork.Size = new System.Drawing.Size(120, 10);
            this.pbnetwork.TabIndex = 89;
            // 
            // tbx_Discovery
            // 
            this.tbx_Discovery.Location = new System.Drawing.Point(3, 291);
            this.tbx_Discovery.Name = "tbx_Discovery";
            this.tbx_Discovery.Size = new System.Drawing.Size(192, 20);
            this.tbx_Discovery.TabIndex = 84;
            // 
            // cbQuickSearch
            // 
            this.cbQuickSearch.AutoSize = true;
            this.cbQuickSearch.Location = new System.Drawing.Point(3, 141);
            this.cbQuickSearch.Name = "cbQuickSearch";
            this.cbQuickSearch.Size = new System.Drawing.Size(88, 17);
            this.cbQuickSearch.TabIndex = 87;
            this.cbQuickSearch.Text = "QuickSearch";
            this.cbQuickSearch.UseVisualStyleBackColor = true;
            // 
            // cbDeepSearch
            // 
            this.cbDeepSearch.AutoSize = true;
            this.cbDeepSearch.Location = new System.Drawing.Point(109, 141);
            this.cbDeepSearch.Name = "cbDeepSearch";
            this.cbDeepSearch.Size = new System.Drawing.Size(86, 17);
            this.cbDeepSearch.TabIndex = 88;
            this.cbDeepSearch.Text = "DeepSearch";
            this.cbDeepSearch.UseVisualStyleBackColor = true;
            // 
            // lsb_discover
            // 
            this.lsb_discover.ContextMenuStrip = this.cms;
            this.lsb_discover.FormattingEnabled = true;
            this.lsb_discover.Location = new System.Drawing.Point(3, 164);
            this.lsb_discover.Name = "lsb_discover";
            this.lsb_discover.Size = new System.Drawing.Size(192, 121);
            this.lsb_discover.TabIndex = 82;
            this.lsb_discover.SelectedIndexChanged += new System.EventHandler(this.lsb_discover_SelectedIndexChanged);
            // 
            // tbGlättung
            // 
            this.tbGlättung.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbGlättung.Location = new System.Drawing.Point(6, 57);
            this.tbGlättung.Maximum = 3;
            this.tbGlättung.Minimum = 1;
            this.tbGlättung.Name = "tbGlättung";
            this.tbGlättung.Size = new System.Drawing.Size(104, 45);
            this.tbGlättung.TabIndex = 1;
            this.tbGlättung.Value = 1;
            this.tbGlättung.Scroll += new System.EventHandler(this.tbGlättung_Scroll);
            // 
            // tbempfindlichkeit
            // 
            this.tbempfindlichkeit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbempfindlichkeit.Location = new System.Drawing.Point(6, 6);
            this.tbempfindlichkeit.Maximum = 3;
            this.tbempfindlichkeit.Minimum = 1;
            this.tbempfindlichkeit.Name = "tbempfindlichkeit";
            this.tbempfindlichkeit.Size = new System.Drawing.Size(104, 45);
            this.tbempfindlichkeit.TabIndex = 0;
            this.tbempfindlichkeit.Value = 1;
            this.tbempfindlichkeit.Scroll += new System.EventHandler(this.tbempfindlichkeit_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tcGameSettings);
            this.tabControl1.Controls.Add(this.tcIPConfiguration);
            this.tabControl1.Controls.Add(this.tcNetworkDicovery);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 343);
            this.tabControl1.TabIndex = 90;
            // 
            // tcGameSettings
            // 
            this.tcGameSettings.Controls.Add(this.tbempfindlichkeit);
            this.tcGameSettings.Controls.Add(this.tbGlättung);
            this.tcGameSettings.Location = new System.Drawing.Point(4, 22);
            this.tcGameSettings.Name = "tcGameSettings";
            this.tcGameSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tcGameSettings.Size = new System.Drawing.Size(607, 317);
            this.tcGameSettings.TabIndex = 0;
            this.tcGameSettings.Text = "Game Settings";
            this.tcGameSettings.UseVisualStyleBackColor = true;
            this.tcGameSettings.Click += new System.EventHandler(this.tcGameSettings_Click);
            // 
            // tcIPConfiguration
            // 
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
            this.tcIPConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tcIPConfiguration.Size = new System.Drawing.Size(607, 317);
            this.tcIPConfiguration.TabIndex = 1;
            this.tcIPConfiguration.Text = "IPConfiguration";
            this.tcIPConfiguration.UseVisualStyleBackColor = true;
            // 
            // tcNetworkDicovery
            // 
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
            this.tcNetworkDicovery.Padding = new System.Windows.Forms.Padding(3);
            this.tcNetworkDicovery.Size = new System.Drawing.Size(607, 317);
            this.tcNetworkDicovery.TabIndex = 2;
            this.tcNetworkDicovery.Text = "NetworkDiscovery";
            this.tcNetworkDicovery.UseVisualStyleBackColor = true;
            // 
            // ServerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 367);
            this.Controls.Add(this.tabControl1);
            this.Name = "ServerSettings";
            this.Text = "ServerSettings";
            this.Load += new System.EventHandler(this.ServerSettings_Load);
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbGlättung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbempfindlichkeit)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tcGameSettings.ResumeLayout(false);
            this.tcGameSettings.PerformLayout();
            this.tcIPConfiguration.ResumeLayout(false);
            this.tcIPConfiguration.PerformLayout();
            this.tcNetworkDicovery.ResumeLayout(false);
            this.tcNetworkDicovery.PerformLayout();
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
    }
}
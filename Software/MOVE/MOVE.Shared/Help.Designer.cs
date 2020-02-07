namespace MOVE.Shared
{
    partial class Help
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
            this.helpbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // helpbox
            // 
            this.helpbox.FormattingEnabled = true;
            this.helpbox.Location = new System.Drawing.Point(12, 12);
            this.helpbox.Name = "helpbox";
            this.helpbox.Size = new System.Drawing.Size(277, 589);
            this.helpbox.TabIndex = 0;
            this.helpbox.SelectedIndexChanged += new System.EventHandler(this.Helpbox_SelectedIndexChanged);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(299, 620);
            this.Controls.Add(this.helpbox);
            this.Name = "Help";
            this.Opacity = 0.9D;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox helpbox;
    }
}
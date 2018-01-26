namespace RobloxVersionMonitor
{
    partial class RobloxVersionMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobloxVersionMonitor));
            this.coreTabControl = new System.Windows.Forms.TabControl();
            this.statusTabContainer = new System.Windows.Forms.TabPage();
            this.historyTabContainer = new System.Windows.Forms.TabPage();
            this.updateNotifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusTabControl = new System.Windows.Forms.TabControl();
            this.historyTabControl = new System.Windows.Forms.TabControl();
            this.coreTabControl.SuspendLayout();
            this.statusTabContainer.SuspendLayout();
            this.historyTabContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // coreTabControl
            // 
            this.coreTabControl.Controls.Add(this.statusTabContainer);
            this.coreTabControl.Controls.Add(this.historyTabContainer);
            this.coreTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coreTabControl.Location = new System.Drawing.Point(0, 0);
            this.coreTabControl.Name = "coreTabControl";
            this.coreTabControl.SelectedIndex = 0;
            this.coreTabControl.Size = new System.Drawing.Size(433, 421);
            this.coreTabControl.TabIndex = 1;
            // 
            // statusTabContainer
            // 
            this.statusTabContainer.Controls.Add(this.statusTabControl);
            this.statusTabContainer.Location = new System.Drawing.Point(4, 22);
            this.statusTabContainer.Name = "statusTabContainer";
            this.statusTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.statusTabContainer.Size = new System.Drawing.Size(425, 395);
            this.statusTabContainer.TabIndex = 0;
            this.statusTabContainer.Text = "Live Status";
            this.statusTabContainer.UseVisualStyleBackColor = true;
            // 
            // historyTabContainer
            // 
            this.historyTabContainer.Controls.Add(this.historyTabControl);
            this.historyTabContainer.Location = new System.Drawing.Point(4, 22);
            this.historyTabContainer.Name = "historyTabContainer";
            this.historyTabContainer.Padding = new System.Windows.Forms.Padding(3);
            this.historyTabContainer.Size = new System.Drawing.Size(425, 395);
            this.historyTabContainer.TabIndex = 1;
            this.historyTabContainer.Text = "History";
            this.historyTabContainer.UseVisualStyleBackColor = true;
            // 
            // updateNotifier
            // 
            this.updateNotifier.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.updateNotifier.BalloonTipText = "Double click for details.";
            this.updateNotifier.BalloonTipTitle = "Roblox Update Detected!";
            this.updateNotifier.Icon = ((System.Drawing.Icon)(resources.GetObject("updateNotifier.Icon")));
            this.updateNotifier.Text = "Roblox Update Notifier";
            this.updateNotifier.Visible = true;
            this.updateNotifier.BalloonTipClicked += new System.EventHandler(this.updateNotifier_BalloonTipClicked);
            // 
            // statusTabControl
            // 
            this.statusTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusTabControl.Location = new System.Drawing.Point(3, 3);
            this.statusTabControl.Name = "statusTabControl";
            this.statusTabControl.SelectedIndex = 0;
            this.statusTabControl.Size = new System.Drawing.Size(419, 389);
            this.statusTabControl.TabIndex = 1;
            // 
            // historyTabControl
            // 
            this.historyTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyTabControl.Location = new System.Drawing.Point(3, 3);
            this.historyTabControl.Name = "historyTabControl";
            this.historyTabControl.SelectedIndex = 0;
            this.historyTabControl.Size = new System.Drawing.Size(419, 389);
            this.historyTabControl.TabIndex = 2;
            // 
            // RobloxVersionMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(433, 421);
            this.Controls.Add(this.coreTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RobloxVersionMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roblox Version Monitor";
            this.Load += new System.EventHandler(this.RobloxVersionMonitor_Load);
            this.coreTabControl.ResumeLayout(false);
            this.statusTabContainer.ResumeLayout(false);
            this.historyTabContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl coreTabControl;
        private System.Windows.Forms.TabPage statusTabContainer;
        private System.Windows.Forms.TabPage historyTabContainer;
        private System.Windows.Forms.NotifyIcon updateNotifier;
        private System.Windows.Forms.TabControl statusTabControl;
        private System.Windows.Forms.TabControl historyTabControl;
    }
}


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
            this.statusTabControl = new System.Windows.Forms.TabControl();
            this.statusTabPageProd = new System.Windows.Forms.TabPage();
            this.statusTabPageGT1 = new System.Windows.Forms.TabPage();
            this.statusTabPageGT2 = new System.Windows.Forms.TabPage();
            this.historyTabContainer = new System.Windows.Forms.TabPage();
            this.historyTabControl = new System.Windows.Forms.TabControl();
            this.historyTabPageProd = new System.Windows.Forms.TabPage();
            this.historyTabPageGT1 = new System.Windows.Forms.TabPage();
            this.historyTabPageGT2 = new System.Windows.Forms.TabPage();
            this.updateNotifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.coreTabControl.SuspendLayout();
            this.statusTabContainer.SuspendLayout();
            this.statusTabControl.SuspendLayout();
            this.historyTabContainer.SuspendLayout();
            this.historyTabControl.SuspendLayout();
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
            // statusTabControl
            // 
            this.statusTabControl.Controls.Add(this.statusTabPageProd);
            this.statusTabControl.Controls.Add(this.statusTabPageGT1);
            this.statusTabControl.Controls.Add(this.statusTabPageGT2);
            this.statusTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusTabControl.Location = new System.Drawing.Point(3, 3);
            this.statusTabControl.Name = "statusTabControl";
            this.statusTabControl.SelectedIndex = 0;
            this.statusTabControl.Size = new System.Drawing.Size(419, 389);
            this.statusTabControl.TabIndex = 1;
            // 
            // statusTabPageProd
            // 
            this.statusTabPageProd.Location = new System.Drawing.Point(4, 22);
            this.statusTabPageProd.Name = "statusTabPageProd";
            this.statusTabPageProd.Padding = new System.Windows.Forms.Padding(3);
            this.statusTabPageProd.Size = new System.Drawing.Size(411, 363);
            this.statusTabPageProd.TabIndex = 0;
            this.statusTabPageProd.Text = "roblox";
            this.statusTabPageProd.ToolTipText = "roblox";
            this.statusTabPageProd.UseVisualStyleBackColor = true;
            // 
            // statusTabPageGT1
            // 
            this.statusTabPageGT1.Location = new System.Drawing.Point(4, 22);
            this.statusTabPageGT1.Name = "statusTabPageGT1";
            this.statusTabPageGT1.Padding = new System.Windows.Forms.Padding(3);
            this.statusTabPageGT1.Size = new System.Drawing.Size(411, 363);
            this.statusTabPageGT1.TabIndex = 1;
            this.statusTabPageGT1.Text = "gametest1";
            this.statusTabPageGT1.ToolTipText = "gametest1.robloxlabs";
            this.statusTabPageGT1.UseVisualStyleBackColor = true;
            // 
            // statusTabPageGT2
            // 
            this.statusTabPageGT2.Location = new System.Drawing.Point(4, 22);
            this.statusTabPageGT2.Name = "statusTabPageGT2";
            this.statusTabPageGT2.Size = new System.Drawing.Size(411, 363);
            this.statusTabPageGT2.TabIndex = 2;
            this.statusTabPageGT2.Text = "gametest2";
            this.statusTabPageGT2.ToolTipText = "gametest2.robloxlabs";
            this.statusTabPageGT2.UseVisualStyleBackColor = true;
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
            // historyTabControl
            // 
            this.historyTabControl.Controls.Add(this.historyTabPageProd);
            this.historyTabControl.Controls.Add(this.historyTabPageGT1);
            this.historyTabControl.Controls.Add(this.historyTabPageGT2);
            this.historyTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyTabControl.Location = new System.Drawing.Point(3, 3);
            this.historyTabControl.Name = "historyTabControl";
            this.historyTabControl.SelectedIndex = 0;
            this.historyTabControl.Size = new System.Drawing.Size(419, 389);
            this.historyTabControl.TabIndex = 2;
            // 
            // historyTabPageProd
            // 
            this.historyTabPageProd.Location = new System.Drawing.Point(4, 22);
            this.historyTabPageProd.Name = "historyTabPageProd";
            this.historyTabPageProd.Padding = new System.Windows.Forms.Padding(3);
            this.historyTabPageProd.Size = new System.Drawing.Size(411, 363);
            this.historyTabPageProd.TabIndex = 0;
            this.historyTabPageProd.Text = "roblox";
            this.historyTabPageProd.ToolTipText = "roblox";
            this.historyTabPageProd.UseVisualStyleBackColor = true;
            // 
            // historyTabPageGT1
            // 
            this.historyTabPageGT1.Location = new System.Drawing.Point(4, 22);
            this.historyTabPageGT1.Name = "historyTabPageGT1";
            this.historyTabPageGT1.Padding = new System.Windows.Forms.Padding(3);
            this.historyTabPageGT1.Size = new System.Drawing.Size(411, 363);
            this.historyTabPageGT1.TabIndex = 1;
            this.historyTabPageGT1.Text = "gametest1";
            this.historyTabPageGT1.ToolTipText = "gametest1.robloxlabs";
            this.historyTabPageGT1.UseVisualStyleBackColor = true;
            // 
            // historyTabPageGT2
            // 
            this.historyTabPageGT2.Location = new System.Drawing.Point(4, 22);
            this.historyTabPageGT2.Name = "historyTabPageGT2";
            this.historyTabPageGT2.Size = new System.Drawing.Size(411, 363);
            this.historyTabPageGT2.TabIndex = 2;
            this.historyTabPageGT2.Text = "gametest2";
            this.historyTabPageGT2.ToolTipText = "gametest2.robloxlabs";
            this.historyTabPageGT2.UseVisualStyleBackColor = true;
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
            this.statusTabControl.ResumeLayout(false);
            this.historyTabContainer.ResumeLayout(false);
            this.historyTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl coreTabControl;
        private System.Windows.Forms.TabPage statusTabContainer;
        private System.Windows.Forms.TabPage historyTabContainer;
        private System.Windows.Forms.TabControl statusTabControl;
        private System.Windows.Forms.TabPage statusTabPageProd;
        private System.Windows.Forms.TabPage statusTabPageGT1;
        private System.Windows.Forms.TabPage statusTabPageGT2;
        private System.Windows.Forms.TabControl historyTabControl;
        private System.Windows.Forms.TabPage historyTabPageProd;
        private System.Windows.Forms.TabPage historyTabPageGT1;
        private System.Windows.Forms.TabPage historyTabPageGT2;
        private System.Windows.Forms.NotifyIcon updateNotifier;
    }
}


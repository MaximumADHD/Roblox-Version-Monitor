namespace RobloxVersionMonitor
{
    partial class RobloxUpdateLog
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
            this.log = new System.Windows.Forms.RichTextBox();
            this.dismiss = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Top;
            this.log.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.log.Size = new System.Drawing.Size(560, 232);
            this.log.TabIndex = 0;
            this.log.Text = "";
            this.log.WordWrap = false;
            // 
            // dismiss
            // 
            this.dismiss.Location = new System.Drawing.Point(209, 235);
            this.dismiss.Margin = new System.Windows.Forms.Padding(200, 0, 200, 1);
            this.dismiss.Name = "dismiss";
            this.dismiss.Size = new System.Drawing.Size(132, 23);
            this.dismiss.TabIndex = 1;
            this.dismiss.Text = "Dismiss";
            this.dismiss.UseVisualStyleBackColor = true;
            this.dismiss.Click += new System.EventHandler(this.dismiss_Click);
            // 
            // RobloxUpdateLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 261);
            this.Controls.Add(this.dismiss);
            this.Controls.Add(this.log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RobloxUpdateLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roblox Update Log";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.Button dismiss;
    }
}
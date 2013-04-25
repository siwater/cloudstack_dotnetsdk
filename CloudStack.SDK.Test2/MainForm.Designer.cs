namespace CloudStack.SDK.Test2 {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useAPIKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelOutput = new System.Windows.Forms.Label();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.labelLoggedOnAs = new System.Windows.Forms.Label();
            this.labelCurrentUser = new System.Windows.Forms.Label();
            this.cloneSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(144, 59);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(286, 20);
            this.textBoxUrl.TabIndex = 0;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(27, 59);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(78, 13);
            this.labelUrl.TabIndex = 3;
            this.labelUrl.Text = "CloudStack Url";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(30, 155);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(544, 185);
            this.textBoxLog.TabIndex = 15;
            this.textBoxLog.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.commandToolStripMenuItem,
            this.listToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(623, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // commandToolStripMenuItem
            // 
            this.commandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.ssoToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.useAPIKeysToolStripMenuItem,
            this.cloneSessionToolStripMenuItem});
            this.commandToolStripMenuItem.Name = "commandToolStripMenuItem";
            this.commandToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.commandToolStripMenuItem.Text = "Authentication";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.logonToolStripMenuItem_Click);
            // 
            // ssoToolStripMenuItem
            // 
            this.ssoToolStripMenuItem.Name = "ssoToolStripMenuItem";
            this.ssoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ssoToolStripMenuItem.Text = "Single Sign On";
            this.ssoToolStripMenuItem.Click += new System.EventHandler(this.ssoToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logOffToolStripMenuItem_Click);
            // 
            // useAPIKeysToolStripMenuItem
            // 
            this.useAPIKeysToolStripMenuItem.Name = "useAPIKeysToolStripMenuItem";
            this.useAPIKeysToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.useAPIKeysToolStripMenuItem.Text = "Use API Keys";
            this.useAPIKeysToolStripMenuItem.Click += new System.EventHandler(this.useAPIKeysToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listZonesToolStripMenuItem});
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.listToolStripMenuItem.Text = "List";
            // 
            // listZonesToolStripMenuItem
            // 
            this.listZonesToolStripMenuItem.Name = "listZonesToolStripMenuItem";
            this.listZonesToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.listZonesToolStripMenuItem.Text = "ListZones";
            this.listZonesToolStripMenuItem.Click += new System.EventHandler(this.listZonesToolStripMenuItem_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(27, 130);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(63, 13);
            this.labelOutput.TabIndex = 17;
            this.labelOutput.Text = "Output Log:";
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearLog.Location = new System.Drawing.Point(499, 356);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 18;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // labelLoggedOnAs
            // 
            this.labelLoggedOnAs.AutoSize = true;
            this.labelLoggedOnAs.Location = new System.Drawing.Point(30, 94);
            this.labelLoggedOnAs.Name = "labelLoggedOnAs";
            this.labelLoggedOnAs.Size = new System.Drawing.Size(69, 13);
            this.labelLoggedOnAs.TabIndex = 20;
            this.labelLoggedOnAs.Text = "Current User:";
            // 
            // labelCurrentUser
            // 
            this.labelCurrentUser.AutoSize = true;
            this.labelCurrentUser.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelCurrentUser.Location = new System.Drawing.Point(144, 94);
            this.labelCurrentUser.Name = "labelCurrentUser";
            this.labelCurrentUser.Size = new System.Drawing.Size(74, 13);
            this.labelCurrentUser.TabIndex = 21;
            this.labelCurrentUser.Text = "Not logged on";
            // 
            // cloneSessionToolStripMenuItem
            // 
            this.cloneSessionToolStripMenuItem.Name = "cloneSessionToolStripMenuItem";
            this.cloneSessionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cloneSessionToolStripMenuItem.Text = "Clone Session";
            this.cloneSessionToolStripMenuItem.Click += new System.EventHandler(this.cloneSessionToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 391);
            this.Controls.Add(this.labelCurrentUser);
            this.Controls.Add(this.labelLoggedOnAs);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Test  CloudStack SDK";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.RichTextBox textBoxLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ssoToolStripMenuItem;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Label labelLoggedOnAs;
        private System.Windows.Forms.Label labelCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem useAPIKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listZonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneSessionToolStripMenuItem;
        
    }
}


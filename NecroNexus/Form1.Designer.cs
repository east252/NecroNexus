namespace NecroNexus
{
    partial class NecroNexus
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NecroNexus));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            installSteamToolStripMenuItem = new ToolStripMenuItem();
            installServerToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            programFolderToolStripMenuItem = new ToolStripMenuItem();
            saveFolderToolStripMenuItem = new ToolStripMenuItem();
            logsFolderToolStripMenuItem = new ToolStripMenuItem();
            backupToolStripMenuItem = new ToolStripMenuItem();
            backupSaveOnlyToolStripMenuItem = new ToolStripMenuItem();
            backupAllToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            terminal = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            commandBox = new TextBox();
            startServer = new Button();
            stopServer = new Button();
            autoRestart = new CheckBox();
            experimentalCheckbox = new CheckBox();
            killServerButton = new Button();
            instructionsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, backupToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1996, 42);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { installSteamToolStripMenuItem, installServerToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 38);
            fileToolStripMenuItem.Text = "File";
            // 
            // installSteamToolStripMenuItem
            // 
            installSteamToolStripMenuItem.Name = "installSteamToolStripMenuItem";
            installSteamToolStripMenuItem.Size = new Size(283, 44);
            installSteamToolStripMenuItem.Text = "Install Steam";
            installSteamToolStripMenuItem.Click += installSteamToolStripMenuItem_Click;
            // 
            // installServerToolStripMenuItem
            // 
            installServerToolStripMenuItem.Name = "installServerToolStripMenuItem";
            installServerToolStripMenuItem.Size = new Size(283, 44);
            installServerToolStripMenuItem.Text = "Install Server";
            installServerToolStripMenuItem.Click += installServerToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(283, 44);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { programFolderToolStripMenuItem, saveFolderToolStripMenuItem, logsFolderToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(120, 38);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // programFolderToolStripMenuItem
            // 
            programFolderToolStripMenuItem.Name = "programFolderToolStripMenuItem";
            programFolderToolStripMenuItem.Size = new Size(311, 44);
            programFolderToolStripMenuItem.Text = "Program Folder";
            programFolderToolStripMenuItem.Click += programFolderToolStripMenuItem_Click;
            // 
            // saveFolderToolStripMenuItem
            // 
            saveFolderToolStripMenuItem.Name = "saveFolderToolStripMenuItem";
            saveFolderToolStripMenuItem.Size = new Size(311, 44);
            saveFolderToolStripMenuItem.Text = "Save Folder";
            saveFolderToolStripMenuItem.Click += saveFolderToolStripMenuItem_Click;
            // 
            // logsFolderToolStripMenuItem
            // 
            logsFolderToolStripMenuItem.Name = "logsFolderToolStripMenuItem";
            logsFolderToolStripMenuItem.Size = new Size(311, 44);
            logsFolderToolStripMenuItem.Text = "Logs Folder";
            logsFolderToolStripMenuItem.Click += logsFolderToolStripMenuItem_Click;
            // 
            // backupToolStripMenuItem
            // 
            backupToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupSaveOnlyToolStripMenuItem, backupAllToolStripMenuItem });
            backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            backupToolStripMenuItem.Size = new Size(111, 38);
            backupToolStripMenuItem.Text = "Backup";
            // 
            // backupSaveOnlyToolStripMenuItem
            // 
            backupSaveOnlyToolStripMenuItem.Name = "backupSaveOnlyToolStripMenuItem";
            backupSaveOnlyToolStripMenuItem.Size = new Size(338, 44);
            backupSaveOnlyToolStripMenuItem.Text = "Backup Save Only";
            backupSaveOnlyToolStripMenuItem.Click += backupSaveOnlyToolStripMenuItem_Click;
            // 
            // backupAllToolStripMenuItem
            // 
            backupAllToolStripMenuItem.Name = "backupAllToolStripMenuItem";
            backupAllToolStripMenuItem.Size = new Size(338, 44);
            backupAllToolStripMenuItem.Text = "Backup All";
            backupAllToolStripMenuItem.Click += backupAllToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, instructionsToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(84, 38);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(359, 44);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // terminal
            // 
            terminal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            terminal.BackColor = Color.Black;
            terminal.ForeColor = Color.LimeGreen;
            terminal.Location = new Point(1046, 265);
            terminal.Name = "terminal";
            terminal.ReadOnly = true;
            terminal.Size = new Size(898, 702);
            terminal.TabIndex = 1;
            terminal.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1049, 213);
            label1.Name = "label1";
            label1.Size = new Size(105, 32);
            label1.TabIndex = 2;
            label1.Text = "Terminal";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(898, 995);
            label2.Name = "label2";
            label2.Size = new Size(125, 32);
            label2.TabIndex = 3;
            label2.Text = "Command";
            // 
            // commandBox
            // 
            commandBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            commandBox.Location = new Point(1047, 995);
            commandBox.Name = "commandBox";
            commandBox.Size = new Size(897, 39);
            commandBox.TabIndex = 4;
            // 
            // startServer
            // 
            startServer.Location = new Point(25, 119);
            startServer.Name = "startServer";
            startServer.Size = new Size(150, 46);
            startServer.TabIndex = 5;
            startServer.Text = "Start Server";
            startServer.UseVisualStyleBackColor = true;
            startServer.Click += startServer_Click;
            // 
            // stopServer
            // 
            stopServer.Location = new Point(25, 171);
            stopServer.Name = "stopServer";
            stopServer.Size = new Size(150, 46);
            stopServer.TabIndex = 6;
            stopServer.Text = "Stop Server";
            stopServer.UseVisualStyleBackColor = true;
            stopServer.Click += stopServer_Click;
            // 
            // autoRestart
            // 
            autoRestart.AutoSize = true;
            autoRestart.Location = new Point(238, 129);
            autoRestart.Name = "autoRestart";
            autoRestart.Size = new Size(176, 36);
            autoRestart.TabIndex = 7;
            autoRestart.Text = "Auto Restart";
            autoRestart.UseVisualStyleBackColor = true;
            autoRestart.CheckedChanged += autoRestart_CheckedChanged;
            // 
            // experimentalCheckbox
            // 
            experimentalCheckbox.AutoSize = true;
            experimentalCheckbox.Location = new Point(238, 171);
            experimentalCheckbox.Name = "experimentalCheckbox";
            experimentalCheckbox.Size = new Size(184, 36);
            experimentalCheckbox.TabIndex = 9;
            experimentalCheckbox.Text = "Experimental";
            experimentalCheckbox.TextImageRelation = TextImageRelation.ImageAboveText;
            experimentalCheckbox.UseVisualStyleBackColor = true;
            experimentalCheckbox.CheckedChanged += experimentalCheckbox_CheckedChanged;
            // 
            // killServerButton
            // 
            killServerButton.Location = new Point(25, 223);
            killServerButton.Name = "killServerButton";
            killServerButton.Size = new Size(150, 46);
            killServerButton.TabIndex = 10;
            killServerButton.Text = "Kill Server";
            killServerButton.UseVisualStyleBackColor = true;
            killServerButton.Click += killServerButton_Click;
            // 
            // instructionsToolStripMenuItem
            // 
            instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            instructionsToolStripMenuItem.Size = new Size(359, 44);
            instructionsToolStripMenuItem.Text = "Instructions";
            instructionsToolStripMenuItem.Click += instructionsToolStripMenuItem_Click;
            // 
            // NecroNexus
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(1996, 1117);
            Controls.Add(killServerButton);
            Controls.Add(experimentalCheckbox);
            Controls.Add(autoRestart);
            Controls.Add(stopServer);
            Controls.Add(startServer);
            Controls.Add(commandBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(terminal);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(2000, 1100);
            Name = "NecroNexus";
            Text = "NecroNexus";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem backupToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private RichTextBox terminal;
        private Label label1;
        private Label label2;
        private TextBox commandBox;
        private Button startServer;
        private Button stopServer;
        private ToolStripMenuItem installSteamToolStripMenuItem;
        private ToolStripMenuItem installServerToolStripMenuItem;
        private CheckBox autoRestart;
        private CheckBox experimentalCheckbox;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem programFolderToolStripMenuItem;
        private ToolStripMenuItem saveFolderToolStripMenuItem;
        private ToolStripMenuItem logsFolderToolStripMenuItem;
        private Button killServerButton;
        private ToolStripMenuItem backupSaveOnlyToolStripMenuItem;
        private ToolStripMenuItem backupAllToolStripMenuItem;
        private ToolStripMenuItem instructionsToolStripMenuItem;
    }
}

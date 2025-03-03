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
            instructionsToolStripMenuItem = new ToolStripMenuItem();
            terminal = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            commandBox = new TextBox();
            startServer = new Button();
            stopServer = new Button();
            autoRestart = new CheckBox();
            experimentalCheckbox = new CheckBox();
            killServerButton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, backupToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1126, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { installSteamToolStripMenuItem, installServerToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // installSteamToolStripMenuItem
            // 
            installSteamToolStripMenuItem.Name = "installSteamToolStripMenuItem";
            installSteamToolStripMenuItem.Size = new Size(214, 34);
            installSteamToolStripMenuItem.Text = "Install Steam";
            installSteamToolStripMenuItem.Click += installSteamToolStripMenuItem_Click;
            // 
            // installServerToolStripMenuItem
            // 
            installServerToolStripMenuItem.Name = "installServerToolStripMenuItem";
            installServerToolStripMenuItem.Size = new Size(214, 34);
            installServerToolStripMenuItem.Text = "Install Server";
            installServerToolStripMenuItem.Click += installServerToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(214, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { programFolderToolStripMenuItem, saveFolderToolStripMenuItem, logsFolderToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(92, 29);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // programFolderToolStripMenuItem
            // 
            programFolderToolStripMenuItem.Name = "programFolderToolStripMenuItem";
            programFolderToolStripMenuItem.Size = new Size(238, 34);
            programFolderToolStripMenuItem.Text = "Program Folder";
            programFolderToolStripMenuItem.Click += programFolderToolStripMenuItem_Click;
            // 
            // saveFolderToolStripMenuItem
            // 
            saveFolderToolStripMenuItem.Name = "saveFolderToolStripMenuItem";
            saveFolderToolStripMenuItem.Size = new Size(238, 34);
            saveFolderToolStripMenuItem.Text = "Save Folder";
            saveFolderToolStripMenuItem.Click += saveFolderToolStripMenuItem_Click;
            // 
            // logsFolderToolStripMenuItem
            // 
            logsFolderToolStripMenuItem.Name = "logsFolderToolStripMenuItem";
            logsFolderToolStripMenuItem.Size = new Size(238, 34);
            logsFolderToolStripMenuItem.Text = "Logs Folder";
            logsFolderToolStripMenuItem.Click += logsFolderToolStripMenuItem_Click;
            // 
            // backupToolStripMenuItem
            // 
            backupToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupSaveOnlyToolStripMenuItem, backupAllToolStripMenuItem });
            backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            backupToolStripMenuItem.Size = new Size(85, 29);
            backupToolStripMenuItem.Text = "Backup";
            // 
            // backupSaveOnlyToolStripMenuItem
            // 
            backupSaveOnlyToolStripMenuItem.Name = "backupSaveOnlyToolStripMenuItem";
            backupSaveOnlyToolStripMenuItem.Size = new Size(255, 34);
            backupSaveOnlyToolStripMenuItem.Text = "Backup Save Only";
            backupSaveOnlyToolStripMenuItem.Click += backupSaveOnlyToolStripMenuItem_Click;
            // 
            // backupAllToolStripMenuItem
            // 
            backupAllToolStripMenuItem.Name = "backupAllToolStripMenuItem";
            backupAllToolStripMenuItem.Size = new Size(255, 34);
            backupAllToolStripMenuItem.Text = "Backup All";
            backupAllToolStripMenuItem.Click += backupAllToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, instructionsToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(206, 34);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // instructionsToolStripMenuItem
            // 
            instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            instructionsToolStripMenuItem.Size = new Size(206, 34);
            instructionsToolStripMenuItem.Text = "Instructions";
            instructionsToolStripMenuItem.Click += instructionsToolStripMenuItem_Click;
            // 
            // terminal
            // 
            terminal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            terminal.BackColor = Color.Black;
            terminal.ForeColor = Color.LimeGreen;
            terminal.Location = new Point(359, 101);
            terminal.Margin = new Padding(2);
            terminal.Name = "terminal";
            terminal.ReadOnly = true;
            terminal.Size = new Size(737, 454);
            terminal.TabIndex = 1;
            terminal.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(359, 74);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 2;
            label1.Text = "Terminal";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(241, 576);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 3;
            label2.Text = "Command";
            // 
            // commandBox
            // 
            commandBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            commandBox.Location = new Point(359, 576);
            commandBox.Margin = new Padding(2);
            commandBox.Name = "commandBox";
            commandBox.Size = new Size(737, 31);
            commandBox.TabIndex = 4;
            // 
            // startServer
            // 
            startServer.Location = new Point(19, 93);
            startServer.Margin = new Padding(2);
            startServer.Name = "startServer";
            startServer.Size = new Size(115, 36);
            startServer.TabIndex = 5;
            startServer.Text = "Start Server";
            startServer.UseVisualStyleBackColor = true;
            startServer.Click += startServer_Click;
            // 
            // stopServer
            // 
            stopServer.Location = new Point(19, 134);
            stopServer.Margin = new Padding(2);
            stopServer.Name = "stopServer";
            stopServer.Size = new Size(115, 36);
            stopServer.TabIndex = 6;
            stopServer.Text = "Stop Server";
            stopServer.UseVisualStyleBackColor = true;
            stopServer.Click += stopServer_Click;
            // 
            // autoRestart
            // 
            autoRestart.AutoSize = true;
            autoRestart.Location = new Point(183, 101);
            autoRestart.Margin = new Padding(2);
            autoRestart.Name = "autoRestart";
            autoRestart.Size = new Size(136, 29);
            autoRestart.TabIndex = 7;
            autoRestart.Text = "Auto Restart";
            autoRestart.UseVisualStyleBackColor = true;
            autoRestart.CheckedChanged += autoRestart_CheckedChanged;
            // 
            // experimentalCheckbox
            // 
            experimentalCheckbox.AutoSize = true;
            experimentalCheckbox.Location = new Point(183, 134);
            experimentalCheckbox.Margin = new Padding(2);
            experimentalCheckbox.Name = "experimentalCheckbox";
            experimentalCheckbox.Size = new Size(139, 29);
            experimentalCheckbox.TabIndex = 9;
            experimentalCheckbox.Text = "Experimental";
            experimentalCheckbox.TextImageRelation = TextImageRelation.ImageAboveText;
            experimentalCheckbox.UseVisualStyleBackColor = true;
            experimentalCheckbox.CheckedChanged += experimentalCheckbox_CheckedChanged;
            // 
            // killServerButton
            // 
            killServerButton.Location = new Point(19, 174);
            killServerButton.Margin = new Padding(2);
            killServerButton.Name = "killServerButton";
            killServerButton.Size = new Size(115, 36);
            killServerButton.TabIndex = 10;
            killServerButton.Text = "Kill Server";
            killServerButton.UseVisualStyleBackColor = true;
            killServerButton.Click += killServerButton_Click;
            // 
            // NecroNexus
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(1126, 672);
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
            Margin = new Padding(2);
            MinimumSize = new Size(951, 590);
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

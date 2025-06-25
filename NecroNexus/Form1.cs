using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using System.Xml;

namespace NecroNexus
{
    public partial class NecroNexus : Form
    {

        #region Constants
        // ✅ Constants (Never Change)
        private const string SteamURL = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";

        // ✅ Static Readonly (Evaluated at Runtime, but Never Changes After)
        private static readonly string InstallLocation = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string SteamCMDPath = Path.Combine(InstallLocation, "SteamCMD");
        private static readonly string SteamEXEPath = Path.Combine(SteamCMDPath, "steamcmd.exe");
        private static readonly string ServerPath = Path.Combine(InstallLocation, "Server");
        private static readonly string UserDataFolder = Path.Combine(ServerPath, "UserDataFolder");
        private static readonly string BackupFolder = Path.Combine(ServerPath, "Backup");
        private static readonly string ProgramBackupFolder = Path.Combine(InstallLocation, "Program Backups");
        private static readonly string ServerConfigPath = Path.Combine(ServerPath, "serverconfig.xml");
        private static readonly string LogsFolder = Path.Combine(ServerPath, "Logs");
        private static readonly string AdminPath = Path.Combine(ServerPath, "UserDataFolder", "Saves", "serveradmin.xml");

        // Server process & logging
        private Process? serverProcess;
        private ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();
        private List<string> logBuffer = new List<string>(); // Buffer for last 20 lines
        private readonly int bufferLimit = 20;

        #endregion

        #region Initialization
        public NecroNexus() // Main Function  
        {
            InitializeComponent();
            WriteToTerminal("[INFO] NecroNexus Online.");
        }
        #endregion

        #region Buttons
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // Menu File -> Exit  
        {
            // Close the applications
            Close();
        }
        private async void installSteamToolStripMenuItem_Click(object sender, EventArgs e) // Menu File -> Instal Steam  
        {
            await InstallSteam();
        }
        private async void installServerToolStripMenuItem_Click(object sender, EventArgs e) // Menu File -> Install Server  
        {
            await InstallServer();
        }
        private void experimentalCheckbox_CheckedChanged(object sender, EventArgs e) // Checkbox - Experimental  
        {
            // ✅ Only show a warning when enabling experimental mode
            if (experimentalCheckbox.Checked)
            {
                DialogResult result = MessageBox.Show(
                    "WARNING: The Experimental version may cause instability.\n\nAre you sure you want to enable Experimental mode?",
                    "Confirm Experimental Mode",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    // 🚫 If user cancels, uncheck the box
                    experimentalCheckbox.Checked = false;
                    WriteToTerminal("[INFO] Experimental mode canceled.");
                }
                else
                {
                    WriteToTerminal("[INFO] Experimental mode enabled.");
                }
            }
            else
            {
                WriteToTerminal("[INFO] Experimental mode disabled.");
            }
        }
        private async void startServer_Click(object sender, EventArgs e) // Start Server 
        {
            await StartServer();
        }
        private async void stopServer_Click(object sender, EventArgs e) // Stop Server Gracefully  
        {
            await StopServer();
        }
        private async void killServerButton_Click(object sender, EventArgs e) // Kill Server  
        {
            string processName = "7DaysToDieServer";
            WriteToTerminal("[INFO] Locating and terminating 7 Days");

            await Task.Run(() =>
            {
                foreach (var process in Process.GetProcessesByName(processName))
                {
                    try
                    {
                        WriteToTerminal($"⚠️ Found running instance of {processName}. Killing process...");
                        process.Kill();
                        process.WaitForExit();

                        WriteToTerminal($"✅ {processName} process terminated.");
                    }
                    catch (Exception ex)
                    {
                        WriteToTerminal($"❌ Failed to kill {processName}: {ex.Message}");
                    }
                }
                WriteToTerminal("[INFO] Termination Task Complete");
            });
        }
        private void autoRestart_CheckedChanged(object sender, EventArgs e) // Checkbox - Auto Restart  
        {
            if (autoRestart.Checked)
            {
                WriteToTerminal("🔄 Auto Restart Activated");

                // ✅ If server is already running, start the monitor loop
                if (serverProcess != null && !serverProcess.HasExited)
                {
                    monitorTokenSource?.Cancel(); // Cancel any existing monitor
                    monitorTokenSource = new CancellationTokenSource();
                    _ = Task.Run(() => MonitorServer(monitorTokenSource.Token));
                }
            }
            else
            {
                WriteToTerminal("🔄 Auto Restart Deactivated");
                monitorTokenSource?.Cancel(); // Stop monitoring when unchecked
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) // Help -> About  
        {
            MessageBox.Show(
            "NecroNexus Server Manager\nVersion: 1.0.0\n\nCreated by: Njinir 😎\n\nThis tool helps manage 7 Days to Die servers efficiently.",
            "About NecroNexus",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
        }
        private void logsFolderToolStripMenuItem_Click(object sender, EventArgs e) // Logs Folder  
        {
            string logsPath = Path.Combine(InstallLocation, "server", "Logs");

            if (Directory.Exists(logsPath))
            {
                Debug.WriteLine($"Opening logs folder: {logsPath}");
                Process.Start("explorer.exe", logsPath);
            }
            else
            {
                Debug.WriteLine("Logs folder does not exist.");
                MessageBox.Show("Logs folder not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveFolderToolStripMenuItem_Click(object sender, EventArgs e) // Save Folder  
        {
            string savesPath = Path.Combine(InstallLocation, "server", "UserDataFolder");

            if (Directory.Exists(savesPath))
            {
                Debug.WriteLine($"Opening UserDataFolder: {savesPath}");
                Process.Start("explorer.exe", savesPath);
            }
            else
            {
                Debug.WriteLine("Saves folder does not exist.");
                MessageBox.Show("UserDataFolder not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void programFolderToolStripMenuItem_Click(object sender, EventArgs e) // Program Folder  
        {

            if (Directory.Exists(InstallLocation))
            {
                Debug.WriteLine($"Opening Program folder: {InstallLocation}");
                Process.Start("explorer.exe", InstallLocation);
            }
            else
            {
                Debug.WriteLine("Program Folder does not exist.");
                MessageBox.Show("Program Folder not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backupSaveOnlyToolStripMenuItem_Click(object sender, EventArgs e) // Backup UserDataFolder 
        {
            string? tempPath = CopyUserDataToTemp();
            if (!string.IsNullOrEmpty(tempPath))
                CompressBackupAsync(tempPath);
        }
        private void backupAllToolStripMenuItem_Click(object sender, EventArgs e) // Backup All  
        {
            BackupAll();
        }
        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e) // Instructions  
        {
            MessageBox.Show(
            "Terminal and UserDataFolder are hardcoded.\n Other functions should be as expected",
            "About NecroNexus",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
        }

        #endregion

        #region Helper Functions

        public void WriteToTerminal(string message) // Write to Rich Text Box  
        {
            if (terminal.InvokeRequired) // if invoke required
            {
                terminal.Invoke(new Action(() => WriteToTerminal(message))); // allow other threads to send writes
            }
            else
            {
                terminal.SelectionStart = terminal.TextLength; // move cursor to end of text line (otherwise it could write backwards)
                terminal.SelectionLength = 0; // no text is selected before applying formatting
                terminal.SelectionColor = Color.Lime; // color
                terminal.AppendText(message + "\n"); // send the message, preserve formatting
                terminal.ScrollToCaret(); // Auto scroll down to latest message
            }
        }
        public async Task InstallSteam()  // Install SteamCMD  
        {
            // ✅ Define SteamCMD ZIP path
            string steamCmdZipPath = Path.Combine(InstallLocation, "steamcmd.zip");

            // ✅ Ensure SteamCMD folder exists
            if (!Directory.Exists(SteamCMDPath))
            {
                Directory.CreateDirectory(SteamCMDPath);
                WriteToTerminal("📂 SteamCMD folder created.");
            }

            // ✅ Check if SteamCMD is already installed
            string steamCmdExe = Path.Combine(SteamCMDPath, "steamcmd.exe");
            if (File.Exists(steamCmdExe))
            {
                WriteToTerminal("✔ SteamCMD is already installed. Skipping installation.");
                return;
            }

            // ✅ Download SteamCMD
            WriteToTerminal("⬇ Downloading SteamCMD...");

            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(SteamURL, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    using (FileStream fs = new FileStream(steamCmdZipPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                }
                WriteToTerminal("✔ SteamCMD Download Completed.");
            }
            catch (HttpRequestException ex)
            {
                WriteToTerminal($"❌ Download failed: {ex.Message}");
                return;
            }

            // ✅ Extract SteamCMD ZIP
            WriteToTerminal("📦 Extracting SteamCMD...");

            try
            {
                ZipFile.ExtractToDirectory(steamCmdZipPath, SteamCMDPath);
                File.Delete(steamCmdZipPath); // Remove ZIP after extraction
                WriteToTerminal("✔ SteamCMD Installed.");
            }
            catch (Exception ex)
            {
                WriteToTerminal($"❌ Extraction failed: {ex.Message}");
            }

            // ✅ Auto-scroll is already handled inside WriteToTerminal()
        }
        public async Task InstallServer() // Install 7D Server  
        {
            // If steamcmd isn't installed - install it.
            if (!File.Exists(SteamEXEPath))
            {
                WriteToTerminal("[WARNING] SteamCMD not installed!");
                WriteToTerminal("[INFO] Installing Steamcmd");
                await InstallSteam();

                if (!File.Exists(SteamEXEPath)) // verify installed
                {
                    WriteToTerminal("[ERROR] SteamCMD installation failed!! Cannot continue.");
                    return;
                }
            }
            WriteToTerminal("[INFO] SteamCMD located. Installation beginning.");

            WriteToTerminal($"🚀 Installing 7 Days to Die server in: {ServerPath}");

            // Validate if Experimental
            if (experimentalCheckbox.Checked)
            {
                WriteToTerminal("Experimental version selected!");
            }
            else
            {
                WriteToTerminal("Experimental version is not selected.");
            }

            string arguments = $"+force_install_dir \"{ServerPath}\" +login anonymous +app_update 294420 validate";
            if (experimentalCheckbox.Checked) arguments += " -beta latest_experimental";
            arguments += " +quit";

            WriteToTerminal("Server installation in progres...");

            WriteToTerminal($"[INFO] Running SteamCMD with arguments: {arguments}");
            WriteToTerminal("This is the part that takes a minute. Grab a drink and come back later.");

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = SteamEXEPath,  // ✅ Correctly reference the SteamCMD executable
                    Arguments = arguments,    // ✅ Pass the arguments
                    WorkingDirectory = SteamCMDPath, // ✅ Set the working directory
                    RedirectStandardOutput = true,   // ✅ Capture output
                    RedirectStandardError = true,    // ✅ Capture errors
                    UseShellExecute = false,         // ✅ Required for redirection
                    CreateNoWindow = true            // ✅ Runs in the background
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                            WriteToTerminal(e.Data);
                    };

                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                            WriteToTerminal($"❌ {e.Data}");
                    };

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    await process.WaitForExitAsync();
                }

                WriteToTerminal("[INFO] 7 Days to Die server installation completed.");
            }
            catch (Exception ex)
            {
                WriteToTerminal($"❌ An error occurred while running SteamCMD: {ex.Message}");
            }
        }
        private async Task StartServer() // Start 7D Server  
        {
            if (!Directory.Exists(ServerPath))
            {
                WriteToTerminal("[WARNING] Install Server First");
                WriteToTerminal(ServerPath);
                return;
            }

            if (!Directory.Exists(SteamCMDPath))
            {
                WriteToTerminal("[WARNING] Install SteamCMD First");
                return;
            }

            Process.GetProcessesByName("7DaysToDieServer").ToList().ForEach(p => p.Kill()); // kill any existing 7D Server.
            await FileSetup();
            try
            {
                string serverFolder = Path.Combine(InstallLocation, "server");
                string logsFolder = Path.Combine(serverFolder, "Logs");
                Directory.CreateDirectory(logsFolder); // Ensure log directory exists

                string logTimestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string mainLogPath = Path.Combine(logsFolder, $"log_{logTimestamp}.txt");
                string errorLogPath = Path.Combine(logsFolder, $"error_{logTimestamp}.txt");

                WriteToTerminal($"🚀 Starting server...");

                // Start the server process
                string serverExe = Path.Combine(serverFolder, "7DaysToDieServer.exe");
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = serverExe,
                    Arguments = "-quit -batchmode -nographics -configfile=serverconfig.xml -dedicated",
                    WorkingDirectory = serverFolder,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Minimized,
                    CreateNoWindow = true
                };

                serverProcess = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };
                serverProcess.OutputDataReceived += (sender, e) => ProcessLogLine(e.Data, mainLogPath, errorLogPath);
                serverProcess.ErrorDataReceived += (sender, e) => ProcessLogLine(e.Data, mainLogPath, errorLogPath);

                serverProcess.Start();
                serverProcess.BeginOutputReadLine();
                serverProcess.BeginErrorReadLine();

                // ✅ Start monitoring server logs (PASS THE PARAMETERS)
                _ = Task.Run(() => StreamLogsToFiles(mainLogPath, errorLogPath));

                // ✅ Start server monitoring to detect crashes
                monitorTokenSource?.Cancel(); // Stop any old monitor
                monitorTokenSource = new CancellationTokenSource();
                _ = Task.Run(() => MonitorServer(monitorTokenSource.Token));

                // ✅ Ensure async behavior is correct
                await Task.Delay(1);
            }
            catch (Exception ex)
            {
                string crashLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash_log.txt");
                File.AppendAllText(crashLogPath, $"{DateTime.Now}: {ex}\n");
                WriteToTerminal($"❌ Error: {ex.Message}. See crash_log.txt for details.");
            }
        }
        private async Task MonitorServer(CancellationToken token) // Monitor for restart
        {
            WriteToTerminal("🛠️ Server monitoring started...");
            await Task.Delay(5000);

            while (autoRestart.Checked && !token.IsCancellationRequested)
            {
                bool serverRunning = serverProcess != null && !serverProcess.HasExited;

                if (!serverRunning)
                {
                    WriteToTerminal("❌ Server has stopped! Attempting restart...");
                    await Task.Delay(5000);

                    string? tempPath = null;

                    // Step 1: copy save if last backup was over 30 minutes ago
                    if ((DateTime.Now - lastBackupTime).TotalMinutes >= 30)
                    {
                        tempPath = CopyUserDataToTemp();
                        if (!string.IsNullOrEmpty(tempPath))
                        {
                            lastBackupTime = DateTime.Now;
                            WriteToTerminal("📦 Backup copied. Will compress after server starts.");
                        }
                    }
                    else
                    {
                        WriteToTerminal("⏱ Skipping backup: last backup was less than 30 minutes ago.");
                    }

                    // Step 2: start server
                    await StartServer();

                    // Step 3: compress backup in background (if any)
                    if (!string.IsNullOrEmpty(tempPath))
                        CompressBackupAsync(tempPath);
                }

                await Task.Delay(10000);
            }
        }

        #region Stop Server Functions
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_RETURN = 0x0D; // Enter key

        private static Process? FindSevenDaysProcess()
        {
            foreach (Process p in Process.GetProcessesByName("7DaysToDieServer"))
            {
                return p; // Return first found instance
            }
            return null;
        }
        private static void SendEnterKey(IntPtr hWnd)
        {
            if (hWnd != IntPtr.Zero)
            {
                SendKeys.SendWait("{ENTER}");
            }
        }
        private async Task StopServer()
        {
            WriteToTerminal("[INFO] Searching for 7 Days to Die server process...");

            Process? p = FindSevenDaysProcess();
            if (p == null)
            {
                WriteToTerminal("[INFO] 7 Days to Die server is not running.");
                return;
            }

            WriteToTerminal("[INFO] Attempting to close 7 Days to Die gracefully...");

            // 1️⃣ Bring the window to the foreground
            if (p.MainWindowHandle != IntPtr.Zero)
            {
                WriteToTerminal("[INFO] Setting main window...");
                SetForegroundWindow(p.MainWindowHandle);
            }
            else
            {
                WriteToTerminal("[INFO] Main window handle is zero. The game might be running headless.");
            }

            // 2️⃣ Send CloseMainWindow() command
            WriteToTerminal("[INFO] Closing main window...");
            p.CloseMainWindow();

            // 3️⃣ Wait a moment
            await Task.Delay(1000);

            // 4️⃣ Send {ENTER} key using PostMessage()
            WriteToTerminal("[INFO] Sending ENTER key to confirm shutdown...");
            SendEnterKey(p.MainWindowHandle);

            // 5️⃣ Wait to see if it closes gracefully
            await Task.Delay(5000);

            // 6️⃣ If the process is still running, force kill it
            if (!p.HasExited)
            {
                WriteToTerminal("[INFO] Process did not exit gracefully. Forcing termination...");
                p.Kill();
            }

            Debug.WriteLine("[INFO] 7 Days to Die server has been stopped.");
            WriteToTerminal("[INFO] 7 Days Server stopped.");
        }
        #endregion

        private void ProcessLogLine(string? line, string logPath, string errorLogPath) // Process Log Lines 
        {
            if (string.IsNullOrWhiteSpace(line)) return;
            logQueue.Enqueue(line);
        }
        private async Task StreamLogsToFiles(string logPath, string errorLogPath)
        {
            using StreamWriter mainWriter = new StreamWriter(logPath, true);
            using StreamWriter errorWriter = new StreamWriter(errorLogPath, true);

            string? lastLine = null;
            int repeatCount = 0;
            DateTime lastLineTime = DateTime.Now;

            List<string> contextBuffer = new List<string>();

            while (serverProcess != null && !serverProcess.HasExited)
            {
                if (logQueue.TryDequeue(out string? line))
                {
                    // Filter unwanted lines
                    if (string.IsNullOrWhiteSpace(line) || line.Contains("Shader"))
                        continue;

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string formattedLine = $"[{timestamp}] {line}";

                    if (line == lastLine)
                    {
                        repeatCount++;
                        continue;
                    }
                    else
                    {
                        // Write the repeat summary if needed
                        if (repeatCount > 0)
                        {
                            string repeatSummary = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] (Previous line repeated {repeatCount} times)";
                            mainWriter.WriteLine(repeatSummary);
                            mainWriter.Flush();
                            WriteToTerminal(repeatSummary);
                            repeatCount = 0;
                        }

                        // Write the new line
                        mainWriter.WriteLine(formattedLine);
                        mainWriter.Flush();
                        WriteToTerminal(formattedLine);
                        lastLine = line;
                        lastLineTime = DateTime.Now;

                        // Update context buffer
                        contextBuffer.Add(formattedLine);
                        if (contextBuffer.Count > bufferLimit)
                            contextBuffer.RemoveAt(0);

                        // Log to error log if it looks like an error
                        if (line.Contains("ERROR") || line.Contains("ERR") || line.Contains("Exception"))
                        {
                            errorWriter.WriteLine("\n===== ERROR DETECTED =====");
                            foreach (var prev in contextBuffer)
                                errorWriter.WriteLine(prev);
                            errorWriter.WriteLine("==========================\n");
                            errorWriter.Flush();
                        }
                    }
                }
                else
                {
                    await Task.Delay(100);
                }
            }

            // Final write if loop exits with buffered repeats
            if (repeatCount > 0 && !string.IsNullOrEmpty(lastLine))
            {
                string repeatSummary = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] (Final repeat: {repeatCount} more)";
                mainWriter.WriteLine(repeatSummary);
                mainWriter.Flush();
                WriteToTerminal(repeatSummary);
            }
        }
        private string? CopyUserDataToTemp()
        {
            try
            {
                if (!Directory.Exists(BackupFolder))
                    Directory.CreateDirectory(BackupFolder);

                if (!Directory.Exists(UserDataFolder))
                {
                    WriteToTerminal("UserDataFolder does not exist. Backup aborted.");
                    return null;
                }

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string tempBackupPath = Path.Combine(BackupFolder, $"UserDataBackup_{timestamp}");
                Directory.CreateDirectory(tempBackupPath);
                WriteToTerminal($"Copying UserDataFolder to: {tempBackupPath}");
                CopyDirectory(UserDataFolder, tempBackupPath);
                return tempBackupPath;
            }
            catch (Exception ex)
            {
                WriteToTerminal($"Backup copy failed: {ex.Message}");
                return null;
            }
        } // Copy files for zip/backup
        private void CompressBackupAsync(string tempBackupPath)
        {
            _ = Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(5000); // Give time to ensure server has launched

                    if (Directory.Exists(tempBackupPath))
                    {
                        string zipFilePath = tempBackupPath + ".zip";
                        ZipFile.CreateFromDirectory(tempBackupPath, zipFilePath);
                        WriteToTerminal($"✅ Backup compressed: {zipFilePath}");

                        try
                        {
                            Directory.Delete(tempBackupPath, true);
                            WriteToTerminal("🧹 Temp folder deleted after compression.");
                        }
                        catch (Exception deleteEx)
                        {
                            WriteToTerminal($"❌ Failed to delete temp folder: {deleteEx.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteToTerminal($"❌ Compression failed: {ex.Message}");
                }
            });
        }
        private static void CopyDirectory(string sourceDir, string targetDir) // Copy folder, for Backup  
        {
            foreach (var dir in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dir.Replace(sourceDir, targetDir));
            }
            foreach (var file in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(file, file.Replace(sourceDir, targetDir), true);
            }
        }
        private void BackupAll() // Backup ALL folders to Program Backups 
        {
            try
            {
                // Ensure the backup folder exists
                if (!Directory.Exists(ProgramBackupFolder))
                {
                    Directory.CreateDirectory(ProgramBackupFolder);
                    WriteToTerminal($"Created backup directory: {ProgramBackupFolder}");
                }

                // Ensure InstallLocation exists before backing up
                if (!Directory.Exists(InstallLocation))
                {
                    WriteToTerminal("InstallLocation does not exist. Backup aborted.");
                    MessageBox.Show("InstallLocation not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a timestamped backup folder inside Program Backups
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string tempBackupPath = Path.Combine(ProgramBackupFolder, $"InstallBackup_{timestamp}");
                Directory.CreateDirectory(tempBackupPath);

                WriteToTerminal($"Backing up InstallLocation to: {tempBackupPath}");

                // Copy files and folders, EXCLUDING "Program Backups"
                foreach (string dir in Directory.GetDirectories(InstallLocation))
                {
                    if (Path.GetFileName(dir) == "Program Backups") continue; // Skip the backup folder itself

                    string destDir = Path.Combine(tempBackupPath, Path.GetFileName(dir));
                    CopyDirectory(dir, destDir);
                }

                foreach (string file in Directory.GetFiles(InstallLocation))
                {
                    string destFile = Path.Combine(tempBackupPath, Path.GetFileName(file));
                    File.Copy(file, destFile, true);
                }

                // Create a ZIP file containing everything
                string zipFilePath = Path.Combine(ProgramBackupFolder, $"InstallBackup_{timestamp}.zip");
                ZipFile.CreateFromDirectory(tempBackupPath, zipFilePath);

                WriteToTerminal($"Backup completed: {zipFilePath}");

                // Delete the temporary backup folder after compression
                Directory.Delete(tempBackupPath, true);
                WriteToTerminal("Temporary backup folder deleted.");
            }
            catch (Exception ex)
            {
                WriteToTerminal($"Backup failed: {ex.Message}");
                MessageBox.Show($"Backup failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task FileSetup() // Check and create folders 
        {
            try
            {
                // 1️⃣ Ensure required folders exist
                CreateFolderIfNotExists(ProgramBackupFolder);
                CreateFolderIfNotExists(BackupFolder);
                CreateFolderIfNotExists(LogsFolder);

                // 2️⃣ Wait for serverconfig.xml to be generated (max 30 sec)
                Debug.WriteLine("Waiting for serverconfig.xml to appear...");
                for (int i = 0; i < 6; i++) // 6 attempts (5s each) = 30 seconds max
                {
                    if (File.Exists(ServerConfigPath))
                    {
                        Debug.WriteLine("serverconfig.xml found. Proceeding to edit.");
                        break;
                    }
                    await Task.Delay(5000); // Wait 5 seconds before checking again
                }

                // 3️⃣ If serverconfig.xml still doesn’t exist, abort
                if (!File.Exists(ServerConfigPath))
                {
                    Debug.WriteLine("serverconfig.xml did not appear within 30 seconds. Aborting setup.");
                    return;
                }

                // 4️⃣ Modify serverconfig.xml to ensure required properties are set
                EditServerConfig();

                // 5️⃣ Stop the server after editing config
                Debug.WriteLine("Stopping server to apply configuration...");
                await StopServer();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"FileSetup() failed: {ex.Message}");
            }
        }
        private static void CreateFolderIfNotExists(string path) // Create folders if not exist
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.WriteLine($"Created folder: {path}");
            }
        }
        public void EditServerConfig() // Hardcode serverconfig.xml  
        {
            try
            {
                Debug.WriteLine("Loading serverconfig.xml for modification...");

                string configText = File.ReadAllText(ServerConfigPath);
                bool updated = false;

                // Ensure UserDataFolder is set properly
                if (configText.Contains("UserDataFolder"))
                {
                    Debug.WriteLine("UserDataFolder property found. Ensuring it's set correctly...");
                    string updatedText = System.Text.RegularExpressions.Regex.Replace(
                        configText,
                        @"<!--\s*<property\s+name=""UserDataFolder""\s+value="".*?""\s*/>\s*-->",
                        @"<property name=""UserDataFolder"" value=""UserDataFolder"" />"
                    );

                    if (updatedText != configText)
                    {
                        configText = updatedText;
                        Debug.WriteLine("UserDataFolder was commented out. It has been restored.");
                        updated = true;
                    }
                }
                else
                {
                    Debug.WriteLine("UserDataFolder property not found. Adding it...");
                    configText = configText.Replace("<!-- Other technical settings -->",
                        "<property name=\"UserDataFolder\" value=\"UserDataFolder\" />\n<!-- Other technical settings -->");
                    updated = true;
                }

                // Ensure TerminalWindowEnabled is always true
                if (!configText.Contains("<property name=\"TerminalWindowEnabled\" value=\"true\" />"))
                {
                    Debug.WriteLine("TerminalWindowEnabled property missing or incorrect. Fixing it...");
                    configText = System.Text.RegularExpressions.Regex.Replace(
                        configText,
                        @"<property\s+name=""TerminalWindowEnabled""\s+value="".*?""\s*/>",
                        @"<property name=""TerminalWindowEnabled"" value=""true"" />"
                    );
                    updated = true;
                }

                // Save only if updates were made
                if (updated)
                {
                    File.WriteAllText(ServerConfigPath, configText);
                    Debug.WriteLine("serverconfig.xml updated successfully.");
                    WriteToTerminal("serverconfig.xml updated: UserDataFolder and TerminalWindowEnabled fixed.");
                }
                else
                {
                    Debug.WriteLine("No changes needed in serverconfig.xml.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to edit serverconfig.xml: {ex.Message}");
            }
        }
        private CancellationTokenSource? monitorTokenSource = null; // Track the monitoring of the server
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            monitorTokenSource?.Cancel(); // stop background loop
            base.OnFormClosing(e);        // continue closing
        } // Kill loops when app killed
        private DateTime lastBackupTime = DateTime.MinValue; // Track the last backup time

        #endregion
    }
}
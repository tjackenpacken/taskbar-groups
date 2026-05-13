using client.Classes;
using client.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace client
{
    static class client
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        public static string[] arguments = Environment.GetCommandLineArgs();

        // Define functions to set AppUserModelID
        [DllImport("shell32.dll", SetLastError = true)]
        static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

        // ADDED: Win32 calls used to restore and focus the existing TaskbarGroups window.
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        // ADDED: Restores minimized windows.
        private const int SW_RESTORE = 9;


        [STAThread]
        static void Main()
        {
            // Use existing methods to obtain cursor already imported as to not import any extra functions
            // Pass as two variables instead of Point due to Point requiring System.Drawing
            int cursorX = Cursor.Position.X;
            int cursorY = Cursor.Position.Y;

            // Set the MainPath to the absolute path where the exe is located
            MainPath.path = Path.GetFullPath(new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath);
            MainPath.exeString = Path.GetFullPath(new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);

            // Creats folder for JIT compilation 
            Directory.CreateDirectory($"{MainPath.path}\\JITComp");

            // Creates directory in case it does not exist for config files
            Directory.CreateDirectory($"{MainPath.path}\\config");
            Directory.CreateDirectory($"{MainPath.path}\\Shortcuts");

            System.Runtime.ProfileOptimization.SetProfileRoot(MainPath.path + "\\JITComp");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                System.IO.File.Create(MainPath.path + "\\directoryTestingDocument.txt").Close();
                System.IO.File.Delete(MainPath.path + "\\directoryTestingDocument.txt");
            }
            catch
            {
                using (Process configTool = new Process())
                {
                    configTool.StartInfo.FileName = MainPath.exeString;
                    configTool.StartInfo.Verb = "runas";
                    try
                    {
                        configTool.Start();
                    } catch
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }

            if (arguments.Length > 1) // Checks for additional arguments; opens either main application or taskbar drawer application
            {
                // Sets the AppUserModelID to tjackenpacken.taskbarGroup.menu.groupName
                // Distinguishes each shortcut process from one another to prevent them from stacking with the main application
                //SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.menu."+ arguments[1]);

                // CHANGED: Use hummbugg AppUserModelID for maintained fork.
                SetCurrentProcessExplicitAppUserModelID("hummbugg.taskbarGroup.menu." + arguments[1]);


                Application.Run(new frmMain(arguments[1], cursorX, cursorY));


            }
            else
            {
                // ADDED: Prevent multiple main TaskbarGroups configuration windows from running.
                // This is only applied to the main app window, not the taskbar drawer/group windows.
                bool createdNew;
                using (Mutex singleInstanceMutex = new Mutex(true, "TaskbarGroups_Main_SingleInstance_Mutex", out createdNew))
                {
                    if (!createdNew)
                    {
                        // ADDED: If the main app is already running, bring an existing TaskbarGroups window forward.
                        Process currentProcess = Process.GetCurrentProcess();
                        Process[] runningProcesses = Process.GetProcessesByName(currentProcess.ProcessName);

                        foreach (Process process in runningProcesses)
                        {
                            if (process.Id != currentProcess.Id && process.MainWindowHandle != IntPtr.Zero)
                            {
                                ShowWindowAsync(process.MainWindowHandle, SW_RESTORE);
                                SetForegroundWindow(process.MainWindowHandle);
                                break;
                            }
                        }

                        return;
                    }

                    // See comment above
                    //SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.main");
                    // CHANGED: Use hummbugg AppUserModelID for maintained fork.
                    SetCurrentProcessExplicitAppUserModelID("hummbugg.taskbarGroup.main");
                    Application.Run(new frmClient());
                }
            }
        }
    }
}

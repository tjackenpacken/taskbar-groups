using client.Forms;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using client.Classes;
using System.Diagnostics;
using System.Linq;
using System.Threading;

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
        
        [STAThread]

        static void Main()
        {
            // Use existing methods to obtain cursor already imported as to not import any extra functions
            // Pass as two variables instead of Point due to Point requiring System.Drawing

            // OLD - No longer handled here
            //int cursorX = Cursor.Position.X;
            //int cursorY = Cursor.Position.Y;

            // Creates folder for JIT compilation.
            System.Runtime.ProfileOptimization.SetProfileRoot(Paths.OptimizationProfilePath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            try
            {
                System.IO.File.Create(Paths.path + "\\directoryTestingDocument.txt").Close();
                System.IO.File.Delete(Paths.path + "\\directoryTestingDocument.txt");
            }
            catch
            {
                /*
                using (Process configTool = new Process())
                {
                    configTool.StartInfo.FileName = Paths.exeString;
                    configTool.StartInfo.Verb = "runas";
                    try
                    {
                        configTool.Start();
                    } catch
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
                */
                MessageBox.Show("This program does not have access to this directory!");
                Process.GetCurrentProcess().Kill();
            }

            /*
            if (arguments.Length > 1) // Checks for additional arguments; opens either main application or taskbar drawer application
            {
                if (Directory.Exists(Path.Combine(Paths.ConfigPath, arguments[1])))
                {
                    // Sets the AppUserModelID to tjackenpacken.taskbarGroup.menu.groupName
                    // Distinguishes each shortcut process from one another to prevent them from stacking with the main application
                    SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.menu." + arguments[1]);

                    System.Threading.Mutex mutexThread = new Mutex(true, "tjackenpacken.taskbarGroup.menu." + arguments[1]);

                    try
                    {
                        if (!mutexThread.WaitOne(TimeSpan.Zero, false))
                        {
                            Application.Exit();
                        }
                    }
                    catch { }
                    //Application.Run(new frmMain(arguments[1], cursorX, cursorY, arguments.ToList(), mutexThread));
                } else if (arguments[1] == "editingGroupMode")
                {
                    // See comment above
                    SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.main");
                    Application.Run(new frmClient(arguments.ToList()));
                } else
                {
                    Application.Exit();
                }
            } else
            {
                // See comment above
                SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.main");
                Application.Run(new frmClient(arguments.ToList()));
            }
            */

            SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.main");
            Application.Run(new frmClient(arguments.ToList()));
        }
    }
}

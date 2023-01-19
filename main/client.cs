using client.Forms;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using client.Classes;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Reflection;

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

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetProcessDpiAwarenessContext(int dpiFlag);

        [DllImport("SHCore.dll", SetLastError = true)]
        internal static extern bool SetProcessDpiAwareness(PROCESS_DPI_AWARENESS awareness);

        [DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();

        internal enum PROCESS_DPI_AWARENESS
        {
            Process_DPI_Unaware = 0,
            Process_System_DPI_Aware = 1,
            Process_Per_Monitor_DPI_Aware = 2
        }

        internal enum DPI_AWARENESS_CONTEXT
        {
            DPI_AWARENESS_CONTEXT_UNAWARE = 16,
            DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = 17,
            DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = 18,
            DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = 34
        }

        [STAThread]

        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(Assembly.GetExecutingAssembly().GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            if (Environment.OSVersion.Version >= new Version(6, 3, 0)) // win 8.1 added support for per monitor dpi
            {
                if (Environment.OSVersion.Version >= new Version(10, 0, 15063)) // win 10 creators update added support for per monitor v2
                {
                    SetProcessDpiAwarenessContext((int)DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
                }
                else SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.Process_Per_Monitor_DPI_Aware);
            }
            else SetProcessDPIAware();
            // Use existing methods to obtain cursor already imported as to not import any extra functions
            // Pass as two variables instead of Point due to Point requiring System.Drawing

            // OLD - No longer handled here
            //int cursorX = Cursor.Position.X;
            //int cursorY = Cursor.Position.Y;

            // Creates folder for JIT compilation.
            try
            {System.Runtime.ProfileOptimization.SetProfileRoot(Paths.OptimizationProfilePath);} catch (Exception ex){}

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
                Process.GetCurrentProcess().Close();
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

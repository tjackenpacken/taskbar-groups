using client.Forms;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using client.Classes;


namespace client
{
    static class client
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        public static string[] arguments = Environment.GetCommandLineArgs();

        [DllImport("shell32.dll", SetLastError = true)]
        static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);
        
        [STAThread]

        static void Main()
        {
            MainPath.path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).AbsolutePath;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (arguments.Length > 1) // Checks for additional arguments; opens either main application or taskbar drawer application
            {
                SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.menu."+ arguments[1]);
                Application.Run(new frmMain(arguments[1]));
            } else
            {
                System.IO.Directory.CreateDirectory(new Uri($"{MainPath.path}\\config").AbsolutePath);
                SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.main");
                Application.Run(new frmClient());
            }
        }
    }
}

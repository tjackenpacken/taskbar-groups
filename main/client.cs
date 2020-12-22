using client.Forms;
using System;
using System.Windows.Forms;

namespace client
{
    static class client
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainControl()); 
        }
    }
}

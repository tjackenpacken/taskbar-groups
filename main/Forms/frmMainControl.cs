using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.Forms
{
    public partial class frmMainControl : Form
    {
        public frmMainControl()
        {
            InitializeComponent();
            // Won't need to check if directory exists; the default function already does it
            System.IO.Directory.CreateDirectory(new Uri($"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)}\\config").AbsolutePath);
        }

        private void OnShown(object sender, EventArgs e)
        {
            this.Hide(); // Hide main window; show other windows


            string[] arguments = Environment.GetCommandLineArgs(); // Gets any passed arguments

            if (arguments.Length > 1) // Checks for additional arguments; opens either main application or taskbar drawer application
            {
                frmMain shortcutTask = new frmMain(arguments[1]);
                shortcutTask.Closed += (s, args) => this.Close(); // Close main window when other window is closed
                shortcutTask.Show();
            }
            else
            {
                frmClient mainForm = new frmClient();
                mainForm.Closed += (s, args) => this.Close(); // Close main window when other window is closed
                mainForm.Show();
            }
        }
    }
}

﻿using backgroundClient.Classes;
using IWshRuntimeLibrary;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backgroundClient
{

    class SingleInstanceApp : WindowsFormsApplicationBase
    {
        // Define functions to set AppUserModelID
        [DllImport("shell32.dll", SetLastError = true)]
        static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

        public SingleInstanceApp()
            : base()
        {
            this.IsSingleInstance = true;
        }

        protected override void OnStartupNextInstance(
            StartupNextInstanceEventArgs e)
        {
            base.OnStartupNextInstance(e);

            string[] secondInstanceArgumens = e.CommandLine.ToArray();

            if (secondInstanceArgumens.Length > 1) // Checks for additional arguments; opens either main application or taskbar drawer application
            {
                if (bkgProcess.loadedCategories.ContainsKey(secondInstanceArgumens[1]))
                {
                    String group = secondInstanceArgumens[1];
                    String argument = "";

                    if (secondInstanceArgumens.Length > 2)
                    {
                        for (int i = 2; i < secondInstanceArgumens.Length; i++)
                        {
                            argument += secondInstanceArgumens[i].Trim();
                        }
                    }
                    SetCurrentProcessExplicitAppUserModelID("tjackenpacken.taskbarGroup.menu." + secondInstanceArgumens[1]);

                    bkgProcess.showFormCat(group, argument);
                }
                else if (secondInstanceArgumens[1] == "editingGroupMode")
                {
                    if (bkgProcess.loadedCategories.ContainsKey(secondInstanceArgumens[2]))
                    {
                        bkgProcess.openEditor("editingGroupMode" + " " + secondInstanceArgumens[2]);
                    }
                } else if (secondInstanceArgumens[1] == "exitApplicationModeReserved")
                {
                    Application.Exit();
                }
            }
        }

        protected override void OnCreateMainForm()
        {
            string[] arguments = Environment.GetCommandLineArgs();

            base.OnCreateMainForm();

            this.MainForm = new bkgProcess();

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            if (arguments.Length > 1) // Checks for additional arguments; opens either main application or taskbar drawer application
            {
                if (bkgProcess.loadedCategories.ContainsKey(arguments[1]) || arguments[1] == "editingGroupMode")
                {
                    Process p = new Process();
                    p.StartInfo.FileName = Paths.exeString;

                    String argument = "";

                    if (arguments.Length > 2)
                    {
                        for (int i = 2; i < arguments.Length; i++)
                        {
                            argument += arguments[i].Trim();
                        }
                    }

                    p.StartInfo.Arguments = arguments[1] + " " + argument;
                    p.Start();
                }
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            new SingleInstanceApp().Run(Environment.GetCommandLineArgs());
        }
    }
}

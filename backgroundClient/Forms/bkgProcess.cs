using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using backgroundClient.Classes;
using IWshRuntimeLibrary;
using static backgroundClient.bkgProcess;

namespace backgroundClient
{
    public partial class bkgProcess : Form
    {
        public static Dictionary<String, Category> loadedCategories = new Dictionary<String, Category>();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int flags);
        [DllImport("dwmapi.dll", EntryPoint = "#127")]
        public static extern void DwmGetColorizationParameters(out DWMCOLORIZATIONPARAMS parameters);

        public static Color SystemColors = Color.FromArgb(31, 31, 31);

        public struct DWMCOLORIZATIONPARAMS
        {
            public uint ColorizationColor,
                ColorizationAfterglow,
                ColorizationColorBalance,
                ColorizationAfterglowBalance,
                ColorizationBlurBalance,
                ColorizationGlassReflectionIntensity,
                ColorizationOpaqueBlend;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                Params.ExStyle |= 0x08000000;
                return Params;
            }
        }
        

        public bkgProcess()
        {
            //Make background transparent
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.ShowInTaskbar = false;
            this.Opacity = 0;

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };

            InitializeComponent();
            updateColor();
            this.Hide();

            string[] folders = Directory.GetDirectories(Paths.ConfigPath);
            foreach (string folderName in folders)
            {
                if (System.IO.File.Exists(Path.Combine(folderName, "ObjectData.xml")))
                {
                    loadedCategories.Add(new DirectoryInfo(folderName).Name, new Category(folderName));
                }
            }



            notifyIcon1.Visible = true;
            notifyIcon1.Icon = backgroundClient.Properties.Resources.Icon;

            ContextMenu trayContext = new ContextMenu();

            trayContext.MenuItems.Add("Exit", (s,e) => {
                Application.Exit();
            });
            notifyIcon1.ContextMenu = trayContext;
        }

        private void updateColor()
        {
            DWMCOLORIZATIONPARAMS windowsColors = new DWMCOLORIZATIONPARAMS();
            DwmGetColorizationParameters(out windowsColors);

            SystemColors = Color.FromArgb(
                (byte)(255),
                (byte)(windowsColors.ColorizationColor >> 16),
                (byte)(windowsColors.ColorizationColor >> 8),
                (byte)windowsColors.ColorizationColor);
        }


        public static void showFormCat( string category, string arguments)
        {
            try
            {
                new frmMain(loadedCategories[category], arguments.Split(' ')).Show();
            }
            catch { }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            openEditor();
        }

        public static void openEditor(string arguments="")
        {
            if (System.IO.File.Exists(Paths.MainClientShortcut) && Paths.MainClientShortcut != Paths.exeString)
            {
                WshShell shell = new WshShell(); //Create a new WshShell Interface
                IWshShortcut mainClientShortcut = (IWshShortcut)shell.CreateShortcut(Paths.MainClientShortcut); //Link the interface to our shortcut

                // Chcek if the editor actually exists
                if (System.IO.File.Exists(mainClientShortcut.TargetPath))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = mainClientShortcut.TargetPath;

                    p.StartInfo.Arguments = arguments;
                    p.Start();
                }
                else
                {
                    MessageBox.Show("The editor has moved since the last time you've used it. Reopen it for it to relink the shortcut needed to use this feature!");
                }
            }
            else
            {
                MessageBox.Show("Please reopen your Taskbar Groups editor to set the location of itself so you can use this feature!");
            }
        }

        // Get system color window changes
        const int WM_DWMCOLORIZATIONCOLORCHANGED = 0x320;
        protected override void WndProc(ref Message m)
        {
            // Cancel any maximize message sent to the window
            if (m.Msg == 0x320)
            {
                updateColor();
            }
            base.WndProc(ref m);
        }
    }
}

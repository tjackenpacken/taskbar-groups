using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using backgroundClient.Classes;

namespace backgroundClient
{
    public partial class bkgProcess : Form
    {
        protected override void DefWndProc(ref Message m)
        {
            const int WM_MOUSEACTIVATE = 0x21;
            const int MA_NOACTIVATE = 0x0003;

            switch (m.Msg)
            {
                case WM_MOUSEACTIVATE:
                    m.Result = (IntPtr)MA_NOACTIVATE;
                    return;
            }
            base.DefWndProc(ref m);
        }


        public static Dictionary<String, LoadedCategory> loadedCategories = new Dictionary<String, LoadedCategory>();

        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }

        public bkgProcess()
        {
            //Make background transparent
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;

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
            this.Hide();

            string[] folders = Directory.GetDirectories(Paths.ConfigPath);
            foreach (string folderName in folders)
            {
                if (File.Exists(Path.Combine(folderName, "ObjectData.xml")))
                {
                    loadedCategories.Add(new DirectoryInfo(folderName).Name, new LoadedCategory(folderName));
                }
            }

            

            notifyIcon1.Visible = true;
            notifyIcon1.Icon = backgroundClient.Properties.Resources.Icon;

            ContextMenu trayContext = new ContextMenu();

            trayContext.MenuItems.Add("Exit", (s, e) => Application.Exit());

            notifyIcon1.ContextMenu = trayContext;
        }


        public static void showFormCat( string category, string arguments)
        {
            try
            {
                new frmMain(loadedCategories[category], arguments.Split(' ')).Show();
            }
            catch { }
        }
    }
}

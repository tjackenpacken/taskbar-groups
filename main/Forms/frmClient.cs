using ChinhDo.Transactions;
using client.Classes;
using client.User_controls;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Windows.Data.Json;
using System.Runtime.InteropServices;
using Kaitai;
using System.Security.Cryptography.X509Certificates;

namespace client.Forms
{
    public partial class frmClient : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private List<Category> categoryList = new List<Category>();
        public bool editOpened = false;

        public frmClient(List<string> arguments)
        {
            System.Runtime.ProfileOptimization.StartProfile("frmClient.Profile");
            InitializeComponent();
            eDpi = Display(DpiType.Effective);
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.MinimumSize = new Size(Size.Width + 1, Size.Height);  // +1 seems to fix the bottomscroll bar randomly appearing.
            Reload();

            currentVersion.Text = "v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();

            githubVersion.Text = Task.Run(() => getVersionData()).Result;

            if (arguments.Count > 2 && arguments[1] == "editingGroupMode" && Directory.Exists(Path.Combine(Paths.ConfigPath, arguments[2])))
            {

                try
                {
                    frmGroup editGroup = new frmGroup(this, categoryList.Where(cat => cat.Name == arguments[2]).First());
                    editGroup.TopMost = true;
                    editGroup.Show();
                }
                catch { }
            }

            if (Settings.settingInfo.portableMode)
            {
                portabilityButton.Tag = "y";
                portabilityButton.Image = Properties.Resources.toggleOn;

                string[] files =
    Directory.GetFiles(Paths.ShortcutsPath, "*.lnk");

                foreach (string lnkPath in files)
                {
                    WindowsLnkFile lk = WindowsLnkFile.FromFile(lnkPath);
                    if (lk.RelPath == null || string.IsNullOrEmpty(lk.RelPath.Str) || lk.RelPath.Str != "..\\Taskbar Groups Background.exe")
                    {
                        changeAllShortcuts();
                        break;
                    }

                }
            }
            else
            {
                portabilityButton.Tag = "n";
                portabilityButton.Image = Properties.Resources.toggleOff;
            }
            
            if (Paths.justWritten)
            {
                changeAllShortcuts();
            }
            //pnlExistingGroups.AutoScroll = true;
            //pnlExistingGroups.AutoSize = true;
            //flowLayoutPanel1.AutoScroll = true;
            pnlExistingShortcuts.AutoSize = true;
            Reset();
        }

        public static uint eDpi { get; set; } // Effective DPI

        public uint Display(DpiType type)
        {
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                screen.GetDpi(DpiType.Effective, out uint x, out _);
                eDpi = x;
                return (x);
            }
            return (eDpi);
        }
        public void Reload()
        {
            // flush and reload existing groups
            pnlExistingShortcuts.Controls.Clear();

            List<String> subDirectories = new List<String>();

            using(IEnumerator<String> enumeratorDrectories = Directory.EnumerateDirectories(Paths.ConfigPath).GetEnumerator())
            {
                while (true)
                {
                    try
                    {
                        if (!enumeratorDrectories.MoveNext())
                            break;
                        subDirectories.Add(enumeratorDrectories.Current);
                        // processing
                    }
                    catch (Exception e)
                    {
                    }
                }
            }


            //string[] subDirectories = Directory.GetDirectories(Paths.ConfigPath);
            pnlExistingShortcuts.SuspendLayout();
            foreach (string dir in subDirectories)
            {
                try
                {
                    LoadCategory(Path.Combine(Paths.ConfigPath, dir));
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            pnlExistingShortcuts.ResumeLayout(true);

            /*
            if (pnlExistingGroups.HasChildren) // helper if no group is created
            {
                lblHelpTitle.Text = "Click on a group to add a taskbar shortcut";
                pnlHelp.Visible = true;
            }
            else // helper if groups are created
            {
                lblHelpTitle.Text = "Press on \"Add Taskbar group\" to get started";
                pnlHelp.Visible = false;
            }
            */
            //pnlBottomMain.Location = new Point(pnlBottomMain.Location.X, tableLayoutPanel1.Bottom + (int)(20 * eDpi / 96)); // spacing between existing groups and add new group btn

            Reset();
        }

        public void LoadCategory(string dir)
        {
            Category category = new Category(dir);
            categoryList.Add(category);

            ucCategoryPanel newCategory = new ucCategoryPanel(this, category);
            pnlExistingShortcuts.RowCount += 1;
            pnlExistingShortcuts.Controls.Add(newCategory,0, pnlExistingShortcuts.RowCount - 1);
            newCategory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            //newCategory.Top = pnlExistingGroups.Height - newCategory.Height;
            //newCategory.Dock = DockStyle.Top;
            newCategory.Show();
            newCategory.BringToFront();
            newCategory.MouseEnter += new System.EventHandler((sender, e) => EnterControl(sender, e, newCategory));
            newCategory.MouseLeave += new System.EventHandler((sender, e) => LeaveControl(sender, e, newCategory));
        }

        public void Reset()
        {
            if(eDpi == 0)
            {
                eDpi = Display(DpiType.Effective);
            }
            pnlAddGroup.Top = pnlExistingShortcuts.Bottom + (int)(20 * eDpi / 96);
            pnlAddGroup.Left = ((this.ClientSize.Width+pnlLeftColumn.Width) - pnlAddGroup.Width) / 2 ;
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            frmGroup newGroup = new frmGroup(this);
            newGroup.Show();
            newGroup.BringToFront();
        }

        private void pnlAddGroup_MouseLeave(object sender, EventArgs e)
        {
            pnlAddGroup.BackColor = Color.FromArgb(3, 3, 3);
        }

        private void pnlAddGroup_MouseEnter(object sender, EventArgs e)
        {
            pnlAddGroup.BackColor = Color.FromArgb(31, 31, 31);
        }

        public void EnterControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(31, 31, 31);
        }
        public void LeaveControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(3, 3, 3);
        }

        private static async Task<String> getVersionData()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "taskbar-groups");
                var res = await client.GetAsync("https://api.github.com/repos/PikeNote/taskbar-groups-pike-beta/releases");
                res.EnsureSuccessStatusCode();
                string responseBody = await res.Content.ReadAsStringAsync();

                JsonArray responseJSON = JsonArray.Parse(responseBody);
                JsonObject jsonObjectData = responseJSON[0].GetObject();

                return jsonObjectData["tag_name"].GetString();
            }
            catch { return "Not found"; }
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/PikeNote/taskbar-groups-pike-beta");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((string)portabilityButton.Tag != "n")
            {

                DialogResult res = MessageBox.Show("NOTE: Pressing OK will move the following folders back to the AppData folder (config, Shortcuts) and will move Taskbar Groups Background exe back to AppData.\r\n\r\nWARNING: PLASE DO NOT CLOSE THIS APPLICATION UNTIL A COMPLETION POPUP APPEARS.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    portibleModeToggle(0);
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("NOTE: Pressing OK will move the following folders to the CURRENT folder (config, Shortcuts) and will move Taskbar Groups Background exe to the CURENT folder.\r\n\r\nWARNING: PLASE DO NOT CLOSE THIS APPLICATION UNTIL A COMPLETION POPUP APPEARS.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    portibleModeToggle(1);
                }
            }
        }

        public static void changeAllShortcuts()
        {
            string[] files = System.IO.Directory.GetFiles(Paths.ShortcutsPath, "*.lnk");
            WshShell wshShell = new WshShell();
            foreach (string filePath in files)
            {
                IWshRuntimeLibrary.IWshShortcut newShortcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(filePath);
                newShortcut.TargetPath = Paths.BackgroundApplication;
                newShortcut.IconLocation = Path.Combine(Paths.ConfigPath, newShortcut.Arguments.Trim(), "GroupIcon.ico");
                newShortcut.WorkingDirectory = Path.Combine(Paths.ConfigPath, newShortcut.Arguments.Trim());
                newShortcut.Save();
            }
        }

        // Moves files from AppData to current folder and vice versa
        // This is based off of the array below
        // Index 0 = Current Path
        // Index 1 = Default Path

        // Mode 0 = Current path -> Default Path (Turning off)
        // Mode 1 = Default path -> Current Path (Turning on)
        private void portibleModeToggle(int mode)
        {
            String[,] folderArray = new string[,] { { Path.Combine(Paths.exeFolder, "config"), Paths.defaultConfigPath }, { Path.Combine(Paths.exeFolder, "Shortcuts"), Paths.defaultShortcutsPath }};
            String[,] fileArray = new string[,] { { Path.Combine(Paths.exeFolder, "Taskbar Groups Background.exe"), Paths.defaultBackgroundPath }, { Path.Combine(Paths.exeFolder, "Settings.xml"), Settings.defaultSettingsPath } };

            int int1;
            int int2;
            if (mode == 0)
            {
                int1 = 0;
                int2 = 1;
            } else
            {
                int1 = 1;
                int2 = 0;
            }

            try
            {
                // Kill off the background process
                Category.closeBackgroundApp();

                IFileManager fm = new TxFileManager();
                using (TransactionScope scope1 = new TransactionScope())
                {

                    Settings.settingInfo.portableMode = true;
                    Settings.writeXML();

                    for (int i = 0; i < folderArray.Length/2; i++)
                    {
                        if (fm.DirectoryExists(folderArray[i, int1]))
                        {
                            // Need to use another method to move from one partition to another
                            Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(folderArray[i, int1], folderArray[i, int2]);

                            // Folders may still reside after being moved
                            if (fm.DirectoryExists(folderArray[i, int1]) && !Directory.EnumerateFileSystemEntries(folderArray[i, int1]).Any())
                            {
                                fm.DeleteDirectory(folderArray[i, int1]);
                            }
                        }
                        else
                        {
                            fm.CreateDirectory(folderArray[i, int2]);
                        }
                    }

                    for (int i = 0; i < fileArray.Length/2; i++)
                    {
                        if (fm.FileExists(fileArray[i, int1]))
                        {
                            // Delete if a file is already there (edge cases where the background or another group is created)
                            if(fm.FileExists(fileArray[i, int2]))
                            {
                                fm.Delete(fileArray[i, int2]);
                            }
                            fm.Move(fileArray[i, int1], fileArray[i, int2]);
                        }
                    }

                    if (mode == 0)
                    {
                        Paths.ConfigPath = Paths.defaultConfigPath;
                        Paths.ShortcutsPath = Paths.defaultShortcutsPath;
                        Paths.BackgroundApplication = Paths.defaultBackgroundPath;
                        Settings.settingsPath = Settings.defaultSettingsPath;

                        portabilityButton.Tag = "n";
                        portabilityButton.Image = Properties.Resources.toggleOff;

                    } else
                    {
                        Paths.ConfigPath = folderArray[0, 0];
                        Paths.ShortcutsPath = folderArray[1, 0];

                        Paths.BackgroundApplication = fileArray[0, 0];
                        Settings.settingsPath = fileArray[1, 0];

                        portabilityButton.Tag = "y";
                        portabilityButton.Image = Properties.Resources.toggleOn;

                    }

                    changeAllShortcuts();

                    
                    scope1.Complete();

                    MessageBox.Show("File moving done!");
                }
            }
            catch(IOException e) {
                MessageBox.Show("The application does not have access to this directory!\r\n\r\nError: " + e.Message);
            }
        }

        private void frmClient_SizeChanged(object sender, EventArgs e)
        {
            Reset();
        }
    }

    
}

using client.Classes;
using client.User_controls;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Data.Json;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace client.Forms
{
    public partial class frmClient : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public frmClient()
        {
            System.Runtime.ProfileOptimization.StartProfile("frmClient.Profile");
            InitializeComponent();
            eDpi = Display(DpiType.Effective);
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.MinimumSize = new Size(Size.Width + 1, Size.Height);  // +1 seems to fix the bottomscroll bar randomly appearing.
            Reload();

            currentVersion.Text = "v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();

            githubVersion.Text = Task.Run(() => getVersionData()).Result;
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
            pnlVersionInfo.Location = new Point((int)(19 * eDpi / 96), (int)(615 * eDpi / 96)); // eDpi position ajustments
            pnlExistingGroups.Controls.Clear();
            pnlExistingGroups.Height = 0;

            string configPath = @MainPath.path + @"\config";
            string[] subDirectories = Directory.GetDirectories(configPath);
            foreach (string dir in subDirectories)
            {
                try
                {
                    LoadCategory(dir);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

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
            pnlBottomMain.Top = pnlExistingGroups.Bottom + (int)(20 * eDpi / 96); // spacing between existing groups and add new group btn

            Reset();
        }

        public void LoadCategory(string dir)
        {
            Category category = new Category(dir);
            ucCategoryPanel newCategory = new ucCategoryPanel(this, category);
            pnlExistingGroups.Height += newCategory.Height;
            pnlExistingGroups.Controls.Add(newCategory);
            newCategory.Top = pnlExistingGroups.Height - newCategory.Height;
            newCategory.Show();
            newCategory.BringToFront();
            newCategory.MouseEnter += new System.EventHandler((sender, e) => EnterControl(sender, e, newCategory));
            newCategory.MouseLeave += new System.EventHandler((sender, e) => LeaveControl(sender, e, newCategory));
        }

        public void Reset()
        {
            if (pnlBottomMain.Bottom > this.Bottom)
                pnlLeftColumn.Height = pnlBottomMain.Bottom;
            else
                pnlLeftColumn.Height = this.RectangleToScreen(this.ClientRectangle).Height; // making left column pnl dynamic
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
                var res = await client.GetAsync("https://api.github.com/repos/tjackenpacken/taskbar-groups/releases");
                res.EnsureSuccessStatusCode();
                string responseBody = await res.Content.ReadAsStringAsync();

                JsonArray responseJSON = JsonArray.Parse(responseBody);
                JsonObject jsonObjectData = responseJSON[0].GetObject();

                return jsonObjectData["tag_name"].GetString();
            } catch {return "Not found";}
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/tjackenpacken/taskbar-groups/releases");
        }

        private void frmClient_Resize(object sender, EventArgs e)
        {
            Reset();
        }
    }

    // Get DPI function below
    public static class ScreenExtensions
    {
        public static void GetDpi(this System.Windows.Forms.Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
        {
            var pnt = new System.Drawing.Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
            var mon = MonitorFromPoint(pnt, 2/*MONITOR_DEFAULTTONEAREST*/);
            GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
        }

        //https://msdn.microsoft.com/en-us/library/windows/desktop/dd145062(v=vs.85).aspx
        [DllImport("User32.dll")]
        private static extern IntPtr MonitorFromPoint([In] System.Drawing.Point pt, [In] uint dwFlags);

        //https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510(v=vs.85).aspx
        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX, [Out] out uint dpiY);
    }

    //https://msdn.microsoft.com/en-us/library/windows/desktop/dn280511(v=vs.85).aspx
    public enum DpiType
    {
        Effective = 0,
        Angular = 1,
        Raw = 2,
    }
}

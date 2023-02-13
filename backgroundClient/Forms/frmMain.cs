using backgroundClient.Classes;
using backgroundClient.User_controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace backgroundClient
{

    public partial class frmMain : Form
    {
        [DllImport("User32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool turnOn);


        // Allow doubleBuffering drawing each frame to memory and then onto screen
        // Solves flickering issues mostly as the entire rendering of the screen is done in 1 operation after being first loaded to memory
        /*
        protected override CreateParams CreateParams

        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        */

        public List<ucShortcut> ControlList;
        Keys[] keyList = new Keys[] {Keys.D1, Keys.D2,Keys.D3, Keys.D4,Keys.D5, Keys.D6,Keys.D7, Keys.D8,Keys.D9, Keys.D0};
        public Color HoverColor;
        public static uint eDpi { get; set; } // Effective DPI
        public static decimal xDpi { get; set; } // eDpi ratio for HDPi conversions

        //private string passedDirec;
        public Point mouseClick;

        private string[] argumentList;

        private Category loadedCat;

        private Jumplist jumpList;

        public int ucShortcutSize;
        public int ucShortcutIconSize;
        public int ucShortcutIconLocation;

        //------------------------------------------------------------------------------------
        // CTOR AND LOAD
        //
        public frmMain(Category category, string[] arguments)
        {
            /*
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
            */

            

            InitializeComponent();

            loadedCat = category;

            System.Runtime.ProfileOptimization.StartProfile("frmMain.Profile");
            mouseClick = new Point(Cursor.Position.X, Cursor.Position.Y); // Consstruct point p based on passed x y mouse values
            eDpi = Display(DpiType.Effective); // Get Dpi from clicked screen
            xDpi = eDpi / 96; // Get eDpi conversion ratio
            FormBorderStyle = FormBorderStyle.None;
            argumentList = arguments;

            this.Icon = category.groupIco;

            ControlList = new List<ucShortcut>();

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Category.FromString(category.ColorString);
            Opacity = (1 - (category.Opacity / 100));

            this.TopLevel = true;
            this.TopMost = true;
            
            /*
            if (BackColor.R * 0.2126 + BackColor.G * 0.7152 + BackColor.B * 0.0722 > 255 / 2)
            {
                // Do prior calculations on darker colors to prevent color values going negative
                int backColorR = BackColor.R - 50 >= 0 ? BackColor.R - 50 : 0;
                int backColorG = BackColor.G - 50 >= 0 ? BackColor.G - 50 : 0;
                int backColorB = BackColor.B - 50 >= 0 ? BackColor.B - 50 : 0;

                //if backcolor is light, set hover color as darker
                HoverColor = Color.FromArgb(BackColor.A, backColorR, backColorG, backColorB);
            }
            else
            {
                // Do prior calculations on darker colors to prevent color values going over 255
                int backColorR = BackColor.R + 50 <= 255 ? BackColor.R + 50 : 255;
                int backColorG = BackColor.G + 50 <= 255 ? BackColor.G + 50 : 255;
                int backColorB = BackColor.B + 50 <= 255 ? BackColor.B + 50 : 255;

                //light backcolor is light, set hover color as darker
                HoverColor = Color.FromArgb(BackColor.A, (BackColor.R + 50), (BackColor.G + 50), (BackColor.B + 50));
            }*/

            if (category.HoverColor == null)
            {
                HoverColor = category.calculateHoverColor();
            } else
            {
                HoverColor = ColorTranslator.FromHtml(category.HoverColor);
            }

            jumpList = new Jumplist(this.Handle);
            jumpList.buildJumplist(category.allowOpenAll, category.Name);

            if (arguments[0] == "setGroupContextMenu")
            {
                this.Close();
            }
        }

        // eDpi Calculations Below -----------------
        public uint Display(DpiType type)
        {
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                if (screen.Bounds.Contains(mouseClick)) // Get what screen to target eDpi
                {
                    screen.GetDpi(DpiType.Effective, out uint x, out _);
                eDpi = x;
                return (x);
                }
            }
            return (eDpi);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadCategory();

            /*
            if (argumentList.Length >= 2)
            {
                string jointArgument = String.Join(" ", argumentList).Trim();
                ucShortcut[] argumentMatch = ControlList.Where(prmShortcut => prmShortcut.Psc.name == jointArgument).ToArray();

                if (jointArgument == "tskBaropen_allGroup")
                {
                    foreach (ucShortcut usc in this.ControlList)
                        usc.ucShortcut_Click(usc, new EventArgs());
                }
                this.Close();
            }*/
 

            if (argumentList[0] == "tskBaropen_allGroup")
            {
                foreach (ucShortcut usc in this.ControlList)
                    usc.ucShortcut_Click(usc, new EventArgs());
                this.Close();
            }
            SetLocation();

            //this.TopMost = false;

            SetForegroundWindow(this.Handle);
            SwitchToThisWindow(this.Handle, true);

        System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = 50;
            t.AutoReset = false; 
            t.Elapsed += new ElapsedEventHandler(TimerElapsed);
            t.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.Deactivate += frmMain_Deactivate;
            this.LostFocus += frmMain_Deactivate;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();


        // Sets location of form
        private void SetLocation()
        {
            Dictionary<String, Rectangle> taskbarList = FindDockedTaskBars();
            Rectangle taskbar = new Rectangle();
            Rectangle screen = new Rectangle();

            int locationy;
            int locationx;
            if (taskbarList.Count != 0)
            {
                foreach (var scr in Screen.AllScreens) // Get what screen user clicked on
                {
                    if (scr.Bounds.Contains(mouseClick))
                    {
                        screen.X = scr.Bounds.X;
                        screen.Y = scr.Bounds.Y;
                        screen.Width = scr.Bounds.Width;
                        screen.Height = scr.Bounds.Height;
                        taskbarList.TryGetValue(scr.DeviceName, out taskbar);
                        break;
                    }
                }

                if (taskbar.Contains(mouseClick)) // Click on taskbar
                {
                    if (taskbar.Top == screen.Top && taskbar.Width == screen.Width)
                    {
                        // TOP
                        locationy = screen.Y + taskbar.Height + 10;
                        locationx = mouseClick.X - (this.Width / 2);
                    }
                    else if (taskbar.Bottom == screen.Bottom && taskbar.Width == screen.Width)
                    {
                        // BOTTOM
                        locationy = screen.Y + screen.Height - this.Height - taskbar.Height - 10;
                        locationx = mouseClick.X - (this.Width / 2);
                    }
                    else if (taskbar.Left == screen.Left)
                    {
                        // LEFT
                        locationy = mouseClick.Y - (this.Height / 2);
                        locationx = screen.X + taskbar.Width + 10;

                    }
                    else
                    {
                        // RIGHT
                        locationy = mouseClick.Y - (this.Height / 2);
                        locationx = screen.X + screen.Width - this.Width - taskbar.Width - 10;
                    }

                }
                else // not click on taskbar
                {
                    locationy = mouseClick.Y - this.Height - 20;
                    locationx = mouseClick.X - (this.Width / 2);

                }

                this.Location = new Point(locationx, locationy);

                // If form goes over screen edge
                if (this.Left < screen.Left)
                    this.Left = screen.Left + 10;
                if (this.Top < screen.Top)
                    this.Top = screen.Top + 10;
                if (this.Right > screen.Right)
                    this.Left = screen.Right - this.Width - 10;

                // If form goes over taskbar
                if (taskbar.Contains(this.Left, this.Top) && taskbar.Contains(this.Right, this.Top)) // Top taskbar
                    this.Top = screen.Top + 10 + taskbar.Height;
                if (taskbar.Contains(this.Left, this.Top)) // Left taskbar
                    this.Left = screen.Left + 10 + taskbar.Width;
                if (taskbar.Contains(this.Right, this.Top))  // Right taskbar
                    this.Left = screen.Right - this.Width - 10 - taskbar.Width;

            }
            else // Hidded taskbar
            {
                foreach (var scr in Screen.AllScreens) // get what screen user clicked on
                {
                    if (scr.Bounds.Contains(mouseClick))
                    {
                        screen.X = scr.Bounds.X;
                        screen.Y = scr.Bounds.Y;
                        screen.Width = scr.Bounds.Width;
                        screen.Height = scr.Bounds.Height;
                    }
                }

                if (mouseClick.Y > Screen.PrimaryScreen.Bounds.Height - 35)
                    locationy = Screen.PrimaryScreen.Bounds.Height - this.Height - 45;
                else
                    locationy = mouseClick.Y - this.Height - 20;
                locationx = mouseClick.X - (this.Width / 2);

                this.Location = new Point(locationx, locationy);

                // If form goes over screen edge
                if (this.Left < screen.Left)
                    this.Left = screen.Left + 10;
                if (this.Top < screen.Top)
                    this.Top = screen.Top + 10;
                if (this.Right > screen.Right)
                    this.Left = screen.Right - this.Width - 10;

                // If form goes over taskbar
                if (taskbar.Contains(this.Left, this.Top) && taskbar.Contains(this.Right, this.Top)) // Top taskbar
                    this.Top = screen.Top + 10 + taskbar.Height;
                if (taskbar.Contains(this.Left, this.Top)) // Left taskbar
                    this.Left = screen.Left + 10 + taskbar.Width;
                if (taskbar.Contains(this.Right, this.Top))  // Right taskbar
                    this.Left = screen.Right - this.Width - 10 - taskbar.Width;
            }
        }
        // Search for active taskbars on screen
        public static Dictionary<String, Rectangle> FindDockedTaskBars()
        {
            var dockedRects = new Dictionary<String, Rectangle>();

            foreach (var tmpScrn in Screen.AllScreens)
            {
                if (!tmpScrn.Bounds.Equals(tmpScrn.WorkingArea))
                {
                    Rectangle rect = new Rectangle();

                    var leftDockedWidth = Math.Abs((Math.Abs(tmpScrn.Bounds.Left) - Math.Abs(tmpScrn.WorkingArea.Left)));
                    var topDockedHeight = Math.Abs((Math.Abs(tmpScrn.Bounds.Top) - Math.Abs(tmpScrn.WorkingArea.Top)));
                    var rightDockedWidth = ((tmpScrn.Bounds.Width - leftDockedWidth) - tmpScrn.WorkingArea.Width);
                    var bottomDockedHeight = ((tmpScrn.Bounds.Height - topDockedHeight) - tmpScrn.WorkingArea.Height);
                    if ((leftDockedWidth > 0))
                    {
                        rect.X = tmpScrn.Bounds.Left;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = leftDockedWidth;
                        rect.Height = tmpScrn.Bounds.Height;
                    }
                    else if ((rightDockedWidth > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Right;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = rightDockedWidth;
                        rect.Height = tmpScrn.Bounds.Height;
                    }
                    else if ((topDockedHeight > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Left;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = tmpScrn.WorkingArea.Width;
                        rect.Height = topDockedHeight;
                    }
                    else if ((bottomDockedHeight > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Left;
                        rect.Y = tmpScrn.WorkingArea.Bottom;
                        rect.Width = tmpScrn.WorkingArea.Width;
                        rect.Height = bottomDockedHeight;
                    }
                    else
                    {
                        // Nothing found!
                    }

                    dockedRects.Add(tmpScrn.DeviceName, rect);
                }
            }

            if (dockedRects.Count == 0)
            {
                // Taskbar is set to "Auto-Hide".
            }

            return dockedRects;
        }
        //
        //------------------------------------------------------------------------------------
        //

        // Loading category and building shortcuts
        private void LoadCategory()
        {
            this.Width = 0;
            this.Height = (int)((loadedCat.IconSize + loadedCat.Separation * 2) * xDpi);
            ucShortcutSize = this.Height;
            ucShortcutIconSize = (int)(loadedCat.IconSize * xDpi);
            ucShortcutIconLocation = (int)(loadedCat.Separation * xDpi);
            int x = 0;
            int y = 0;
            int width = loadedCat.Width;
            int columns = 1;

            // Check if icon caches exist for the category being loaded
            // If not then rebuild the icon cache

            /*
            if (!Directory.Exists(Path.Combine(Paths.ConfigPath, loadedCat.Name, "Icons")))
            {
                ThisCategory.cacheIcons();
            }
            */

            for (int i=0; i<loadedCat.ShortcutList.Count; i++)
            {
                ProgramShortcut psc = loadedCat.ShortcutList[i];

                if (columns > width)  // creating new row if there are more psc than max width
                {
                    x = 0;
                    y += (int)((loadedCat.IconSize + loadedCat.Separation * 2) * xDpi);
                    this.Height += (int)((loadedCat.IconSize + loadedCat.Separation * 2) * xDpi);
                    columns = 1;
                }

                if (this.Width < ((width * (int)((loadedCat.IconSize + loadedCat.Separation * 2) * xDpi))))
                    this.Width += ((int)((loadedCat.IconSize + loadedCat.Separation * 2) * (xDpi)));

                // OLD
                //BuildShortcutPanel(x, y, psc);

                // Building shortcut controls
                ucShortcut pscPanel = new ucShortcut()
                {
                    Psc = psc,
                    MotherForm = this,
                    bkgImage = loadedCat.programImages[i],
                    loadedCategory = loadedCat
                };
                pscPanel.Location = new System.Drawing.Point(x, y);
                this.Controls.Add(pscPanel);
                this.ControlList.Add(pscPanel);
                pscPanel.Show();
                pscPanel.BringToFront();

                // Reset values
                x += (int)((loadedCat.IconSize + loadedCat.Separation * 2) * xDpi);
                columns++;
            }

            // this.Width -= 2; // For some reason the width is 2 pixels larger than the shortcuts. Temporary fix
            // Fixed by setting the width of the ucPanel to the real value up here 
        }

        // OLD (Having some issues with the uc build, so keeping the old code below)
        /*
        private void BuildShortcutPanel(int x, int y, ProgramShortcut psc)
        {
            this.shortcutPic = new System.Windows.Forms.PictureBox();
            this.shortcutPic.BackColor = System.Drawing.Color.Transparent;
            this.shortcutPic.Location = new System.Drawing.Point(25, 15);
            this.shortcutPic.Size = new System.Drawing.Size(25, 25);
            this.shortcutPic.BackgroundImage = ThisCategory.loadImageCache(psc); // Use the local icon cache for the file specified as the icon image
            this.shortcutPic.BackgroundImageLayout = ImageLayout.Stretch;
            this.shortcutPic.TabStop = false;
            this.shortcutPic.Click += new System.EventHandler((sender, e) => OpenFile(psc.Arguments, psc.FilePath, psc.WorkingDirectory));
            this.shortcutPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shortcutPanel.Controls.Add(this.shortcutPic);
            this.shortcutPic.Show();
            this.shortcutPic.BringToFront();
            this.shortcutPic.MouseEnter += new System.EventHandler((sender, e) => this.shortcutPanel.BackColor = Color.Black);
            this.shortcutPic.MouseLeave += new System.EventHandler((sender, e) => this.shortcutPanel.BackColor = System.Drawing.Color.Transparent);
        }
        */

        // Click handler for shortcuts
        public void OpenFile(string arguments, string path, string workingDirec)
        {
            // starting program from psc panel click
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.Arguments = arguments;
            proc.FileName = path;
            proc.WorkingDirectory = workingDirec;

            /*
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = path;
            */

            try
            {
                Process.Start(proc);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        // Closes application upon deactivation
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
           
            if (GetForegroundWindow() != this.Handle)
            {
                // closes program if user clicks outside form
                this.Close();
            }
        }

        // Keyboard shortcut handlers
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {

                if (keyList.Contains(e.KeyCode)) {
                    ControlList[Array.IndexOf(keyList, e.KeyCode)].ucShortcut_MouseEnter(sender, e);
                }
                /*
                switch (e.KeyCode)
                {

                    case Keys.D1:
                        ControlList[0].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D2:
                        ControlList[1].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D3:
                        ControlList[2].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D4:
                        ControlList[3].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D5:
                        ControlList[4].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D6:
                        ControlList[5].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D7:
                        ControlList[6].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D8:
                        ControlList[7].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D9:
                        ControlList[8].ucShortcut_MouseEnter(sender, e);
                        break;
                    case Keys.D0:
                        ControlList[9].ucShortcut_MouseEnter(sender, e);
                        break;
                }
                */
            }
            catch
            {

            }
            
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter && loadedCat.allowOpenAll)
            {
                foreach (ucShortcut usc in this.ControlList)
                    usc.ucShortcut_Click(sender, e);
            }

            try
            {
                if (keyList.Contains(e.KeyCode))
                {
                    ControlList[Array.IndexOf(keyList, e.KeyCode)].ucShortcut_MouseEnter(sender, e);
                    ControlList[Array.IndexOf(keyList, e.KeyCode)].ucShortcut_Click(sender, e);
                }

                /*
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        ControlList[0].ucShortcut_MouseLeave(sender, e);
                        ControlList[0].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D2:
                        ControlList[1].ucShortcut_MouseLeave(sender, e);
                        ControlList[1].ucShortcut_Click(sender, e);

                        break;
                    case Keys.D3:
                        ControlList[2].ucShortcut_MouseLeave(sender, e);
                        ControlList[2].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D4:
                        ControlList[3].ucShortcut_MouseLeave(sender, e);
                        ControlList[3].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D5:
                        ControlList[4].ucShortcut_MouseLeave(sender, e);
                        ControlList[4].ucShortcut_Click(sender, e);f
                        break;
                    case Keys.D6:
                        ControlList[5].ucShortcut_MouseLeave(sender, e);
                        ControlList[5].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D7:
                        ControlList[6].ucShortcut_MouseLeave(sender, e);
                        ControlList[6].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D8:
                        ControlList[7].ucShortcut_MouseLeave(sender, e);
                        ControlList[7].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D9:
                        ControlList[8].ucShortcut_MouseLeave(sender, e);
                        ControlList[8].ucShortcut_Click(sender, e);
                        break;
                    case Keys.D0:
                        ControlList[9].ucShortcut_MouseLeave(sender, e);
                        ControlList[9].ucShortcut_Click(sender, e);
                        break;
                }
                */
            }
            catch
            {

            }
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MAXIMIZE = 0xf030;

        protected override void WndProc(ref Message m)
        {
            // Cancel any maximize message sent to the window
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_MAXIMIZE)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        //
        // endregion
        //
        public System.Windows.Forms.PictureBox shortcutPic;
        public System.Windows.Forms.Panel shortcutPanel;



        //
        // END OF CLASS
        //
    }
}

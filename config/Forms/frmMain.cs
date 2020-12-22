using config.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace config
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Opacity = .95;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            Category category = new Category(@"ObjectData.xml");
            LoadCategory(category);
            SetLocation();
        }

        private void SetLocation()
        {
            POINT p = new POINT();

            NativeMethods.GetCursorPos(ref p); // catch cursor location
            List<Rectangle> taskbarList = FindDockedTaskBars();
            Rectangle taskbar = new Rectangle();
            Rectangle screen = new Rectangle();

            System.Drawing.Point mouseClick = new System.Drawing.Point(p.x, p.y);
            int i = 0;
            int locationy;
            int locationx;
            if (taskbarList.Count != 0)
            {
                foreach (var scr in Screen.AllScreens) // get what screen user clicked on
                {
                    if (scr.Bounds.Contains(mouseClick))
                    {
                        screen.X = scr.Bounds.X;
                        screen.Y = scr.Bounds.Y;
                        screen.Width = scr.Bounds.Width;
                        screen.Height = scr.Bounds.Height;
                        taskbar = taskbarList[i];
                    }
                    i++;
                }

                if (taskbar.Contains(mouseClick)) // click on taskbar
                {
                    if (taskbar.Top == screen.Top && taskbar.Width == screen.Width)
                    {
                        // TOP
                        locationy = screen.Y + taskbar.Height + 10;
                        locationx = p.x - (this.Width / 2);
                    }
                    else if (taskbar.Bottom == screen.Bottom && taskbar.Width == screen.Width)
                    {
                        // BOTTOM
                        locationy = screen.Y + screen.Height - this.Height - taskbar.Height - 10;
                        locationx = p.x - (this.Width / 2);
                    }
                    else if (taskbar.Left == screen.Left)
                    {
                        // LEFT
                        locationy = p.y - (this.Height / 2);
                        locationx = screen.X + taskbar.Width + 10;

                    }
                    else
                    {
                        // RIGHT
                        locationy = p.y - (this.Height / 2);
                        locationx = screen.X + screen.Width - this.Width - taskbar.Width - 10;
                    }

                }
                else // not click on taskbar
                {
                    locationy = p.y - this.Height - 20;
                    locationx = p.x - (this.Width / 2);
                }

                this.Location = new Point(locationx, locationy);
                if (this.Left < screen.Left)
                    this.Left = screen.Left + 10;
                if (this.Top < screen.Top)
                    this.Top = screen.Top + 10;
                if (this.Right > screen.Right)
                    this.Left = screen.Right - this.Width - 10;
            }
            else // not click on taskbar
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
                    i++;
                }

                if (p.y > Screen.PrimaryScreen.Bounds.Height - 35)
                    locationy = Screen.PrimaryScreen.Bounds.Height - this.Height - 45;
                else
                    locationy = p.y - this.Height - 20;
                locationx = p.x - (this.Width / 2);

                this.Location = new Point(locationx, locationy);
                if (this.Left < screen.Left)
                    this.Left = screen.Left + 10;
                if (this.Top < screen.Top)
                    this.Top = screen.Top + 10;
                if (this.Right > screen.Right)
                    this.Left = screen.Right - this.Width - 10;
            }
        }

        private void LoadCategory(Category category)
        {
            this.Width = 25;
            this.Height = 55;
            int x = 25;
            int y = 15;
            int width = category.Width;
            int columns = 1;

            foreach (ProgramShortcut psc in category.ShortcutList)
            {

                if (columns > width)  // creating new row if there are more psc than max width
                {
                    x = 25;
                    y += 35;
                    this.Height += 35;
                    columns = 1;
                }

                if (this.Width < ((width * 50)))
                    this.Width += (25 + 25);

                BuildShortcutPanel(x, y, psc);
                x += 50;
                columns++;
            }


        }

        private void BuildShortcutPanel(int x, int y, ProgramShortcut psc)
        {
            this.shortcutPanel = new System.Windows.Forms.PictureBox();
            this.shortcutPanel.BackColor = System.Drawing.Color.Transparent;
            this.shortcutPanel.Location = new System.Drawing.Point(x, y);
            this.shortcutPanel.Size = new System.Drawing.Size(25, 25);
            this.shortcutPanel.BackgroundImage = System.Drawing.Icon.ExtractAssociatedIcon(psc.FilePath).ToBitmap();
            this.shortcutPanel.BackgroundImageLayout = ImageLayout.Stretch;
            this.shortcutPanel.TabStop = false;
            this.shortcutPanel.Click += new System.EventHandler((sender, e) => OpenFile(sender, e, psc.FilePath));
            this.shortcutPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Controls.Add(this.shortcutPanel);
            this.shortcutPanel.Show();
            this.shortcutPanel.BringToFront();
        }


        private void OpenFile(object sender, EventArgs e, string path)
        {
            // starting program from psc panel click
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = path;

            try
            {
                proc.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public static List<Rectangle> FindDockedTaskBars()
        {
            List<Rectangle> dockedRects = new List<Rectangle>();
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

                    dockedRects.Add(rect);
                }
            }

            if (dockedRects.Count == 0)
            {
                // Taskbar is set to "Auto-Hide".
            }

            return dockedRects;
        }
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            // closes program if user clicks outside form
            this.Close();
        }
        //
        // endregion
        //
        public System.Windows.Forms.PictureBox shortcutPanel;

        //
        // END OF CLASS
        //
    }
}

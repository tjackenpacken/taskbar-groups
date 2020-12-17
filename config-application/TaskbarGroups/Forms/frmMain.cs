using System;
using System.Drawing;
using System.Windows.Forms;
using TaskbarGroups.Classes;

namespace TaskbarGroups
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


            POINT p = new POINT();
            NativeMethods.GetCursorPos(ref p); // catch cursor location
            int locationy;
            if (p.y > Screen.PrimaryScreen.Bounds.Height - 35)
                locationy = Screen.PrimaryScreen.Bounds.Height - this.Height - 45;
            else
                locationy = p.y - this.Height - 20;
            int locationx = p.x - (this.Width / 2);
            this.Location = new Point
                (locationx, locationy); // set location to cursor x and bot y
        }

        private void LoadCategory(Category category)
        {
            this.Width = 25;
            this.Height = 55;
            int x = 25;
            int y = 15;
            int width = category.Width;
            int columns = 1;

            foreach (ProgramShortcut shortcut in category.ShortcutList)
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

                // building psc panel
                this.shortcutPanel = new System.Windows.Forms.PictureBox();
                this.shortcutPanel.BackColor = System.Drawing.Color.Transparent;
                this.shortcutPanel.Location = new System.Drawing.Point(x, y);
                this.shortcutPanel.Size = new System.Drawing.Size(25,25);
                this.shortcutPanel.BackgroundImage = System.Drawing.Icon.ExtractAssociatedIcon(shortcut.FilePath).ToBitmap();
                this.shortcutPanel.BackgroundImageLayout = ImageLayout.Stretch;
                this.shortcutPanel.TabStop = false;
                this.shortcutPanel.Click += new System.EventHandler((sender, e) => OpenFile(sender, e, shortcut.FilePath));
                this.shortcutPanel.Cursor = System.Windows.Forms.Cursors.Hand;
                this.Controls.Add(this.shortcutPanel);
                this.shortcutPanel.Show();
                this.shortcutPanel.BringToFront();

                x += 50;
                columns++;
            }
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

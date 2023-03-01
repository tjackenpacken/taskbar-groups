using System;
using System.Drawing;
using System.Windows.Forms;
using client.Classes;
using client.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace client.User_controls
{
    public partial class ucCategoryPanel : UserControl
    {
        public Category Category;
        public frmClient Client;
        public ucCategoryPanel(frmClient client, Category category)
        {
            InitializeComponent();
            Client = client;
            Category = category;
            lblTitle.Text = Regex.Replace(category.Name, @"(_)+", " ");
            picGroupIcon.BackgroundImage = Category.LoadIconImage();

            // starting values for position of shortcuts
            int x = (int)(90 * frmClient.eDpi / 96);
            int y = (int)(56 * frmClient.eDpi / 96);
            int columns = 1;

            if (!Directory.Exists(Path.Combine(Paths.ConfigPath, category.Name, "Icons")))
            {
                category.cacheIcons();
            }

            foreach (ProgramShortcut psc in Category.ShortcutList) // since this is calculating uc height it cant be placed in load
            {
                if (columns == 8)
                {
                    x = (int)(90 * frmClient.eDpi / 96); // resetting x
                    y += (int)(40 * frmClient.eDpi / 96); // adding new row
                    //this.Height += (int)(40 * frmClient.eDpi / 96);
                    columns = 1;
                }
                CreateShortcut(x, y, psc);
                x += (int)(50 * frmClient.eDpi / 96);
                columns++;
            }
        }

        private void CreateShortcut(int x, int y, ProgramShortcut programShortcut)
        {
            // creating shortcut picturebox from shortcut
            this.shortcutPanel = new System.Windows.Forms.PictureBox
            {
                BackColor = System.Drawing.Color.Transparent,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size((int)(30 * frmClient.eDpi / 96), (int)(30 * frmClient.eDpi / 96)),
                BackgroundImageLayout = ImageLayout.Stretch,
                TabStop = false
            };
            this.shortcutPanel.MouseEnter += new System.EventHandler((sender, e) => Client.EnterControl(sender, e, this));
            this.shortcutPanel.MouseLeave += new System.EventHandler((sender, e) => Client.LeaveControl(sender, e, this));
            this.shortcutPanel.Click += new System.EventHandler((sender, e) => OpenFolder(sender, e));

            // Check if file is stil existing and if so render it
            if (File.Exists(programShortcut.FilePath) || Directory.Exists(programShortcut.FilePath) || programShortcut.isWindowsApp)
            {
                this.shortcutPanel.BackgroundImage = ImageFunctions.ResizeImage(Category.loadImageCache(programShortcut), shortcutPanel.Width, shortcutPanel.Height);
            }
            else // if file does not exist
            {
                this.shortcutPanel.BackgroundImage = global::client.Properties.Resources.Error;
                ToolTip tt = new ToolTip
                {
                    InitialDelay = 0,
                    ShowAlways = true
                };
                tt.SetToolTip(this.shortcutPanel, "Program does not exist");
            }

            this.pnlShortcuts.Controls.Add(this.shortcutPanel);
            this.shortcutPanel.Show();
            this.shortcutPanel.BringToFront();
        }

        private void ucNewCategory_Load(object sender, EventArgs e)
        {
            cmdDelete.Top = (this.Height / 2) - (cmdDelete.Height / 2);

        }

        public void OpenFolder(object sender, EventArgs e)
        {
            // Open the shortcut folder for the group when click on category panel

            // Build path based on the directory of the main .exe file
            string filePath = Path.Combine(Paths.ShortcutsPath, Regex.Replace(Category.Name, @"_+", " ") + ".lnk");

            // Open directory in explorer and highlighting file
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", @filePath));
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (!Client.editOpened)
            {
                frmGroup editGroup = new frmGroup(Client, Category);
                editGroup.Show();
                editGroup.BringToFront();
                editGroup.FormClosed += new FormClosedEventHandler(frmGroup_Closed);
                Client.editOpened = true;
            }
        }

        public static Bitmap LoadBitmap(string path) // needed to access img without occupying read/write
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                reader.Close();
                stream.Close();
                return new Bitmap(memoryStream);
            }
        }

        private void lblTitle_MouseEnter(object sender, EventArgs e)
        {
            Client.EnterControl(sender, e, this);

        }

        private void lblTitle_MouseLeave(object sender, EventArgs e)
        {
            Client.LeaveControl(sender, e, this);
        }

        //
        // endregion
        //
        public System.Windows.Forms.PictureBox shortcutPanel;

        private void frmGroup_Closed(object sender, FormClosedEventArgs e)
        {
            Client.editOpened = false;
        }

    }
}

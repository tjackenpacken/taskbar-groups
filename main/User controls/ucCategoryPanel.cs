    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.Classes;
using client.Forms;
using System.IO;

namespace client.User_controls
{
    public partial class ucCategoryPanel : UserControl
    {
        public Category Category { get; set; }
        public frmClient Client { get; set; }
        public ucCategoryPanel(frmClient client, Category category)
        {
            InitializeComponent();
            Client = client;
            Category = category;
            lblTitle.Text = category.Name;
            picGroupIcon.BackgroundImage = Category.LoadIconImage();

            // starting values for position of shortcuts
            int x = 90;
            int y = 55;
            int columns = 1;

            foreach (ProgramShortcut psc in this.Category.ShortcutList) // since this is calculating uc height it cant be placed in load
            {
                if (columns == 8)
                {
                    x = 90; // resetting x
                    y += 40; // adding new row
                    this.Height += 40;
                    columns = 1;
                }
                CreateShortcut(x, y, psc);
                x += 50;
                columns++;
            }
        }

        private void CreateShortcut(int x, int y, ProgramShortcut programShortcut)
        {
            // creating shortcut picturebox from shortcut
            this.shortcutPanel = new System.Windows.Forms.PictureBox();
            this.shortcutPanel.BackColor = System.Drawing.Color.Transparent;
            this.shortcutPanel.Location = new System.Drawing.Point(x, y);
            this.shortcutPanel.Size = new System.Drawing.Size(30, 30);
            this.shortcutPanel.BackgroundImageLayout = ImageLayout.Stretch;
            this.shortcutPanel.TabStop = false;
            this.shortcutPanel.MouseEnter += new System.EventHandler((sender, e) => Client.EnterControl(sender, e, this));
            this.shortcutPanel.MouseLeave += new System.EventHandler((sender, e) => Client.LeaveControl(sender, e, this));

            // checking if file is stil existing
            bool exist = File.Exists(programShortcut.FilePath);
            if (exist)
            {
                String imageExtension = Path.GetExtension(programShortcut.FilePath).ToLower();

                if (imageExtension == ".lnk")
                {
                     this.shortcutPanel.BackgroundImage = frmGroup.handleLnkExt(programShortcut.FilePath);
                }
                else
                {
                     this.shortcutPanel.BackgroundImage = Icon.ExtractAssociatedIcon(programShortcut.FilePath).ToBitmap();
                }
                

                //this.shortcutPanel.BackgroundImage = System.Drawing.Icon.ExtractAssociatedIcon(programShortcut.FilePath).ToBitmap();
            }
            else // if file does not exist
            {
                this.shortcutPanel.BackgroundImage = global::client.Properties.Resources.Error;
                ToolTip tt = new ToolTip();
                tt.InitialDelay = 0;
                tt.ShowAlways = true;
                tt.SetToolTip(this.shortcutPanel, "Program does not exist");
            }

            this.Controls.Add(this.shortcutPanel);
            this.shortcutPanel.Show();
            this.shortcutPanel.BringToFront();
        }

        private void ucNewCategory_Load(object sender, EventArgs e)
        {
            cmdDelete.Top = (this.Height / 2) - (cmdDelete.Height / 2);

        }

        public void OpenFolder(object sender, EventArgs e)
        {
            // opening folder when click on category panel
            //string filePath = System.IO.Path.GetFullPath(@"Shortcuts\" + Category.Name + ".lnk");
            //System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath)); // opening folder and highlighting file
            string filePath = new Uri($"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)}\\config\\{Category.Name}\\Shortcuts\\").AbsolutePath;
            System.Diagnostics.Process.Start(@filePath); // opening folder and highlighting file
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            frmGroup editGroup = new frmGroup(Client, Category);
            editGroup.Show();
            editGroup.BringToFront();
        }

        public static Bitmap LoadBitmap(string path) // needed to access img without occupying read/write
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
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

    }
}

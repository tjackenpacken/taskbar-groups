using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using TaskbarGroups.Classes;
using TaskbarGroupsClient.Classes;

namespace TaskbarGroupsClient
{
    public partial class frmNewGroup : Form
    {
        public List<ProgramShortcut> ShortcutList { get; set; }
        public List<Control> ControlList { get; set; }
        public frmClient Client { get; set; }


        public frmNewGroup(frmClient client)
        {
            InitializeComponent();
            ShortcutList = new List<ProgramShortcut>();
            ControlList = new List<Control>();
            Client = client;
        }

        private void cmdAddGroupIcon_Click(object sender, EventArgs e)
        {
            
            lblErrorIcon.Visible = false;  //resetting error msg

            OpenFileDialog openFileDialog = new OpenFileDialog  // ask user to select img as group icon
            {
                InitialDirectory = @"C:\",
                Title = "Select Group Icon",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "img",
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cmdAddGroupIcon.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                lblAddGroupIcon.Text = "Change group icon";

            }
        }

        private void cmdAddShortcut_Click(object sender, EventArgs e)
        {
            lblErrorShortcut.Visible = false; // resetting error msg

            if (ShortcutList.Count >= 20)
            {
                lblErrorMaxShortcuts.Text = "Max 20 shortcuts in one group";
                lblErrorMaxShortcuts.BringToFront();
                lblErrorMaxShortcuts.Visible = true;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog // ask user to select exe file
            {
                InitialDirectory = @"C:\",
                Title = "Create New Shortcut",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "exe",
                Filter = "Exe Files (.exe)|*.exe",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ProgramShortcut programShortcut = new ProgramShortcut(openFileDialog.FileName); //create new shortcut obj
                this.ShortcutList.Add(programShortcut); // add to panel shortcut list
                LoadShortcuts();
            }
        }

        private void LoadShortcuts()
        {
            foreach (Control con in this.ControlList) // clear all controls
            {
                this.Controls.Remove(con);
                con.Dispose();
            }

            pnlAddShortcut.Top = 200;

            int x = 80;
            int y = 210;
            int i = 1;
            foreach (ProgramShortcut psc in this.ShortcutList) // rebuild shortcuts
            {
                if (pnlAddShortcut.Top == 200) //if this is the first shortcut, move add btn down
                    pnlAddShortcut.Top += 60;

                if (i == 6) 
                {
                    x = 80; // resetting x
                    y += 60; // adding new row
                    pnlAddShortcut.Top += 60;
                    i = 1;
                }

                // building psc panel
                this.shortcutPanel = new System.Windows.Forms.PictureBox();
                this.shortcutPanel.BackColor = System.Drawing.Color.Transparent;
                this.shortcutPanel.Location = new System.Drawing.Point(x, y);
                this.shortcutPanel.Size = new System.Drawing.Size(40, 40);
                this.shortcutPanel.BackgroundImage = System.Drawing.Icon.ExtractAssociatedIcon(psc.FilePath).ToBitmap();
                this.shortcutPanel.BackgroundImageLayout = ImageLayout.Stretch;
                this.shortcutPanel.TabStop = false;
                this.shortcutPanel.Click += new System.EventHandler((sender, e) => DeleteShortcut_Click(psc));
                this.shortcutPanel.Cursor = System.Windows.Forms.Cursors.Hand;
                this.Controls.Add(this.shortcutPanel);
                this.ControlList.Add(this.shortcutPanel);
                this.shortcutPanel.Show();
                this.shortcutPanel.BringToFront();

                x += 90;
                i++;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "Name the new group...") // Verify category name
            {
                lblErrorTitle.Text = "Must select a name";
                lblErrorTitle.Visible = true;
            }
            else if (cmdAddGroupIcon.BackgroundImage ==
                TaskbarGroupsClient.Properties.Resources.AddWhite) // Verify icon
            {
                lblErrorIcon.Text = "Must select group icon";
                lblErrorIcon.Visible = true;
            }
            else if (ShortcutList.Count == 0) // Verify shortcuts
            {
                lblErrorShortcut.Text = "Must select at least one shortcut";
                lblErrorShortcut.Visible = true;
            }

            else
            {
                try
                {
                    int width = int.Parse(lblNum.Text);
                    Category category = new Category(txtGroupName.Text, ShortcutList, width); // instantiate category
                    category.CreateConfig(cmdAddGroupIcon.BackgroundImage); // create group config files
                    Client.LoadCategory(Path.GetFullPath(@"config\" + category.Name)); // load visuals

                    this.Dispose();
                    Client.Reload();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //
        // click and hover functions
        //
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            lblErrorTitle.Visible = false;
        }

        private void txtGroupName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtGroupName.Text == "Name the new group...")
                txtGroupName.Text = "";
        }

        private void txtGroupName_Leave(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "")
                txtGroupName.Text = "Name the new group...";
        }

        private void cmdAddGroupIcon_MouseEnter(object sender, EventArgs e)
        {
            pnlGroupIcon.BackColor = Color.FromArgb(76, 76, 76);
        }

        private void cmdAddGroupIcon_MouseLeave(object sender, EventArgs e)
        {
            pnlGroupIcon.BackColor = Color.FromArgb(31, 31, 31);
        }

        private void DeleteShortcut_Click(ProgramShortcut programShortcut)
        {
            lblErrorMaxShortcuts.Visible = false; // reset max shortcut errortext
            this.ShortcutList.Remove(programShortcut); // remove shortcut from list
            LoadShortcuts();
        }

        private void cmdAddShortcut_MouseEnter(object sender, EventArgs e)
        {
            pnlAddShortcut.BackColor = Color.FromArgb(76, 76, 76);
        }

        private void cmdAddShortcut_MouseLeave(object sender, EventArgs e)
        {
            pnlAddShortcut.BackColor = Color.FromArgb(31,31,31);
        }
        //
        // endregion
        //
        public System.Windows.Forms.PictureBox shortcutPanel;

        private void cmdNumUp_Click(object sender, EventArgs e)
        {
            int num = int.Parse(lblNum.Text);
            if (num > 19)
            {
                lblErrorNum.Text = "Max width";
                lblErrorNum.Visible = true;
            }
            else
            {
                num++;
                lblErrorNum.Visible = false;
                lblNum.Text = num.ToString();
            }
        }

        private void cmdNumDown_Click(object sender, EventArgs e)
        {
            int num = int.Parse(lblNum.Text);
            if (num == 1)
            {
                lblErrorNum.Text = "Width cant be less than 1";
                lblErrorNum.Visible = true;
            }
            else
            {
                num--;
                lblErrorNum.Visible = false;
                lblNum.Text = num.ToString();
            }

        }
        //
        // END OF CLASS
        //
    }
}

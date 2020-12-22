using client.Classes;
using client.User_controls;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.Forms
{
    public partial class frmGroup : Form
    {
        public Category Category { get; set; }
        public List<ucProgramShortcut> ucShortcutList { get; set; }
        public frmClient Client { get; set; }
        public bool IsNew { get; set; }

        private String[] imageExt = new String[] { ".png", ".jpg", ".jpe", ".jfif", ".jpeg", };
        private String[] extensionExt = new String[] { ".exe", ".lnk" };
        private String[] specialImageExt = new String[] { ".ico", ".exe", ".lnk" };

        private String[] newExt;
        public frmGroup(frmClient client, Category category)
        {
            InitializeComponent();
            Category = category;
            Client = client;
            IsNew = false;
            ucShortcutList = new List<ucProgramShortcut>();

            txtGroupName.Text = Category.Name;
            cmdAddGroupIcon.BackgroundImage = Category.LoadIconImage();
            lblNum.Text = Category.Width.ToString();
            LoadShortcuts();
        }
        public frmGroup(frmClient client)
        {
            InitializeComponent();
            newExt = imageExt.Concat(specialImageExt).ToArray();
            Category = new Category { ShortcutList = new List<ProgramShortcut>() };
            Client = client;
            IsNew = true;
            ucShortcutList = new List<ucProgramShortcut>();
            LoadShortcuts();
        }

        public void LoadShortcuts()
        {
            pnlShortcuts.Height = 0;
            pnlShortcuts.Controls.Clear();
            int y = 0;
            int position = 0;

            foreach (ProgramShortcut psc in Category.ShortcutList)
            {
                ucProgramShortcut ucPsc = new ucProgramShortcut(this, psc, position);
                pnlShortcuts.Controls.Add(ucPsc);
                ucPsc.Location = new Point(0, y);
                ucShortcutList.Add(ucPsc);
                ucPsc.Show();
                ucPsc.BringToFront();
                position++;

                if (pnlShortcuts.Height < 350)
                {
                    y += 50;
                    pnlShortcuts.Height += 50;
                }
                else
                    pnlShortcuts.ScrollControlIntoView(ucPsc);
            }

            if (pnlShortcuts.Height >= 350)
            {
                if (!pnlShortcuts.AutoScroll)
                {
                    pnlShortcuts.AutoScroll = true;
                    pnlShortcuts.Width += 40;

                }
            }

            pnlAdd.Top = pnlShortcuts.Bottom;
            //if (pnlAdd.Bottom > pnlEnd.Top)
            //{
            //    this.Height += 50;
            //    pnlEnd.Top += 50;
            //}
            //this.Height = pnlAdd.Bottom + 75;
        }

        public void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            LoadShortcuts();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            Client.Reload(); //flush and reload category panels
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "Name the new group...") // Verify category name
            {
                lblErrorTitle.Text = "Must select a name";
                lblErrorTitle.Visible = true;
            }
            else if (cmdAddGroupIcon.BackgroundImage ==
                global::client.Properties.Resources.AddWhite) // Verify icon
            {
                lblErrorIcon.Text = "Must select group icon";
                lblErrorIcon.Visible = true;
            }
            else if (Category.ShortcutList.Count == 0) // Verify shortcuts
            {
                lblErrorShortcut.Text = "Must select at least one shortcut";
                lblErrorShortcut.Visible = true;
            }
            else
            {

                try
                {
                    if (!IsNew)
                    {
                        //
                        // delete old config
                        //
                        string configPath = @MainPath.path + @"\config\" + Category.Name;
                        //string shortcutPath = configPath + @"\Shortcuts\" + Category.Name + @".lnk";
                        var dir = new DirectoryInfo(configPath);

                        dir.Delete(true); // delete config directory
                        //System.IO.File.Delete(shortcutPath); // delete .lnk
                    }
                    //
                    // creating new config
                    //
                    int width = int.Parse(lblNum.Text);
                    Category category = new Category(txtGroupName.Text, Category.ShortcutList, width); // instantiate category

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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string configPath = @MainPath.path + @"\config\" + Category.Name;

                var dir = new DirectoryInfo(configPath);

                dir.Delete(true); // delete config directory
                this.Hide();
                this.Dispose();
                Client.Reload(); //flush and reload category panels
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdAddGroupIcon_Click(object sender, EventArgs e)
        {
            lblErrorIcon.Visible = false;  //resetting error msg

            OpenFileDialog openFileDialog = new OpenFileDialog  // ask user to select img as group icon
            {
                //InitialDirectory = @"C:\",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),

                Title = "Select Group Icon",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "img",
                Filter = "Image files and exec (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.exe, *.ico) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.ico; *.exe",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                String imageExtension = Path.GetExtension(openFileDialog.FileName).ToLower();

                if (specialImageExt.Contains(imageExtension))
                {
                    if (imageExtension == ".lnk")
                    {
                        cmdAddGroupIcon.BackgroundImage = handleLnkExt(openFileDialog.FileName);
                    }
                    else
                    {
                        cmdAddGroupIcon.BackgroundImage = Icon.ExtractAssociatedIcon(openFileDialog.FileName).ToBitmap();
                    }
                }
                else
                {
                   cmdAddGroupIcon.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                }
                lblAddGroupIcon.Text = "Change group icon";
            }
        }

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


        private void pnlGroupIcon_MouseEnter(object sender, EventArgs e)
        {
            pnlGroupIcon.BackColor = Color.FromArgb(23, 23, 23);
        }

        private void pnlGroupIcon_MouseLeave(object sender, EventArgs e)
        {
            pnlGroupIcon.BackColor = Color.FromArgb(31, 31, 31);

        }


        private void pnlAddShortcut_Click(object sender, EventArgs e)
        {
            lblErrorShortcut.Visible = false; // resetting error msg

            if (Category.ShortcutList.Count >= 20)
            {
                lblErrorShortcut.Text = "Max 20 shortcuts in one group";
                lblErrorShortcut.BringToFront();
                lblErrorShortcut.Visible = true;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog // ask user to select exe file
            {
                InitialDirectory = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs",
                Title = "Create New Shortcut",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "exe",
                Filter = "Exe or Shortcut (.exe, .lnk)|*.exe;*.lnk",
                FilterIndex = 2,
                RestoreDirectory = true,
                //ShowReadOnly = true,
                ReadOnlyChecked = true,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ProgramShortcut programShortcut = new ProgramShortcut(openFileDialog.FileName); //create new shortcut obj
                Category.ShortcutList.Add(programShortcut); // add to panel shortcut list
                pnlShortcuts.Controls.Clear();
                LoadShortcuts();
                pnlShortcuts.ScrollControlIntoView(pnlShortcuts.Controls[0]); // scroll to the latest created control

            }

        }

        private void pnlDragDropExt(object sender, DragEventArgs e)
        {
            var files = (String[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var file in files)
            {
                if (extensionExt.Contains(Path.GetExtension(file)) && System.IO.File.Exists(file))
                {
                    ProgramShortcut programShortcut = new ProgramShortcut(file); //create new shortcut obj
                    Category.ShortcutList.Add(programShortcut); // add to panel shortcut list
                    pnlShortcuts.Controls.Clear();
                    LoadShortcuts();
                    pnlShortcuts.ScrollControlIntoView(pnlShortcuts.Controls[0]); // scroll to the latest created control
                }
            }
        }

        private void pnlDragDropImg(object sender, DragEventArgs e)
        {
            var files = (String[])e.Data.GetData(DataFormats.FileDrop);

            String imageExtension = Path.GetExtension(files[0]).ToLower();

            if (files.Length == 1 && newExt.Contains(imageExtension) && System.IO.File.Exists(files[0]))
            {

                if (specialImageExt.Contains(imageExtension))
                {
                    if (imageExtension == ".lnk")
                    {
                        cmdAddGroupIcon.BackgroundImage = handleLnkExt(files[0]);
                    }
                    else
                    {
                        cmdAddGroupIcon.BackgroundImage = Icon.ExtractAssociatedIcon(files[0]).ToBitmap();
                    }
                }
                else
                {
                    cmdAddGroupIcon.BackgroundImage = Image.FromFile(files[0]);
                }
                lblAddGroupIcon.Text = "Change group icon";
            }
        }

        public static Image handleLnkExt(String file)
        {
                IWshShortcut lnkIcon = ((IWshShortcut)new WshShell().CreateShortcut(file));

                if (lnkIcon.IconLocation != null && !lnkIcon.IconLocation.Contains("http"))
                {
                    return Icon.ExtractAssociatedIcon(lnkIcon.IconLocation.Substring(0, lnkIcon.IconLocation.Length - 2)).ToBitmap();
                }
                else
                {
                    return Icon.ExtractAssociatedIcon(lnkIcon.TargetPath).ToBitmap();
                }
            
        }

        private void pnlDragDropEnterExt(object sender, DragEventArgs e)
        {
            if(checkExtensions(e, extensionExt))
            {
                pnlAddShortcut.BackColor = Color.FromArgb(23, 23, 23);
            }
        }

        private void pnlDragDropEnterImg(object sender, DragEventArgs e)
        {
            if(checkExtensions(e, imageExt.Concat(specialImageExt).ToArray()))
            {
                pnlGroupIcon.BackColor = Color.FromArgb(23, 23, 23);
            }
        }

        private Boolean checkExtensions(DragEventArgs e, String[] exts)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return false;
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                String ext = Path.GetExtension(file);

                if (exts.Contains(ext.ToLower()))
                {
                    e.Effect = DragDropEffects.Copy;
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }

        private void pnlAddShortcut_MouseEnter(object sender, EventArgs e)
        {
            pnlAddShortcut.BackColor = Color.FromArgb(23, 23, 23);
        }

        private void pnlAddShortcut_MouseLeave(object sender, EventArgs e)
        {
            pnlAddShortcut.BackColor = Color.FromArgb(31, 31, 31);

        }


        private void txtGroupName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtGroupName.Text == "Name the new group...")
                txtGroupName.Text = "";
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            lblErrorTitle.Visible = false;
        }

        private void txtGroupName_Leave(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "")
                txtGroupName.Text = "Name the new group...";
        }
    }
}

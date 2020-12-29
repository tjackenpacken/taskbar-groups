using client.Classes;
using client.User_controls;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace client.Forms
{
    public partial class frmGroup : Form
    {
        public Category Category { get; set; }
        public frmClient Client { get; set; }
        public bool IsNew { get; set; }

        private String[] imageExt = new String[] { ".png", ".jpg", ".jpe", ".jfif", ".jpeg", };
        private String[] extensionExt = new String[] { ".exe", ".lnk", ".url" };
        private String[] specialImageExt = new String[] { ".ico", ".exe", ".lnk" };
        private String[] newExt;

        public ucProgramShortcut selectedShortcut;

        public static Shell32.Shell shell = new Shell32.Shell();

        //--------------------------------------
        // CTOR AND LOAD
        //--------------------------------------

        // CTOR for creating a new group
        public frmGroup(frmClient client)
        {
            // Setting from profile
            System.Runtime.ProfileOptimization.StartProfile("frmGroup.Profile");

            InitializeComponent();

            // Setting default category properties
            newExt = imageExt.Concat(specialImageExt).ToArray();
            Category = new Category { ShortcutList = new List<ProgramShortcut>() };
            Client = client;
            IsNew = true;
            Category.ColorString = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(31, 31, 31));
            Category.Opacity = 10;

            // Setting default control values
            cmdDelete.Visible = false;
            cmdSave.Left += 70;
            cmdExit.Left += 70;
            radioDark.Checked = true;
        }

        // CTOR for editing an existing group
        public frmGroup(frmClient client, Category category)
        {
            // Setting form profile
            System.Runtime.ProfileOptimization.StartProfile("frmGroup.Profile");

            InitializeComponent();

            // Setting properties
            Category = category;
            Client = client;
            IsNew = false;

            // Setting control values from loaded group
            txtGroupName.Text = Regex.Replace(Category.Name, @"(_)+", " ");
            cmdAddGroupIcon.BackgroundImage = Category.LoadIconImage();
            lblNum.Text = Category.Width.ToString();
            lblOpacity.Text = Category.Opacity.ToString();
           
            if (Category.ColorString == null)  // Handles if groups is created from earlier releas w/o ColorString property
                Category.ColorString = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(31, 31, 31));

            Color categoryColor = ImageFunctions.FromString(Category.ColorString);
            
            if (categoryColor == Color.FromArgb(31, 31, 31))
                radioDark.Checked = true;
            else if (categoryColor == Color.FromArgb(230, 230, 230))
                radioLight.Checked = true;
            else
            {
                radioCustom.Checked = true;
                pnlCustomColor.Visible = true;
                pnlCustomColor.BackColor = categoryColor;
            }

            // Loading existing shortcutpanels
            int position = 0;
            foreach (ProgramShortcut psc in category.ShortcutList)
            {
                LoadShortcut(psc, position);
                position++;
            }
        }

        // Handle scaling etc(?) (WORK IN PROGRESS)
        private void frmGroup_Load(object sender, EventArgs e)
        {
            // Scaling form (WORK IN PROGRESS)
            this.MaximumSize = new Size(605, Screen.PrimaryScreen.WorkingArea.Height);
        }

        //--------------------------------------
        // SHORTCUT PANEL HANLDERS
        //--------------------------------------

        // Load up shortcut panel
        public void LoadShortcut(ProgramShortcut psc, int position)
        {
            pnlShortcuts.AutoScroll = false;
            ucProgramShortcut ucPsc = new ucProgramShortcut()
            {
                MotherForm = this,
                Shortcut = psc,
                Position = position,
            };
            pnlShortcuts.Controls.Add(ucPsc);
            ucPsc.Show();
            ucPsc.BringToFront();

            if (pnlShortcuts.Controls.Count < 6)
            {
                pnlShortcuts.Height += 50;
                pnlAddShortcut.Top += 50;
            }
            ucPsc.Location = new Point(25, (pnlShortcuts.Controls.Count * 50)-50);
            pnlShortcuts.AutoScroll = true;

        }

        // Adding shortcut by button
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
                Multiselect = true,
                DefaultExt = "exe",
                Filter = "Exe or Shortcut (.exe, .lnk)|*.exe;*.lnk;*.url",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                DereferenceLinks = false
        };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    ProgramShortcut psc = new ProgramShortcut(Environment.ExpandEnvironmentVariables(file)); //create new shortcut obj
                    Category.ShortcutList.Add(psc); // add to panel shortcut list
                    LoadShortcut(psc, Category.ShortcutList.Count - 1);
                }
            }
        }

        // Handle dropped programs into the add program/shortcut field
        private void pnlDragDropExt(object sender, DragEventArgs e)
        {
            var files = (String[])e.Data.GetData(DataFormats.FileDrop);

            // Loops through each file to make sure they exist and to add them directly to the shortcut list
            foreach (var file in files)
            {
                if (extensionExt.Contains(Path.GetExtension(file)) && System.IO.File.Exists(file) || Directory.Exists(file))
                {
                    ProgramShortcut psc = new ProgramShortcut(Environment.ExpandEnvironmentVariables(file)); //Create new shortcut obj
                    Category.ShortcutList.Add(psc); // Add to panel shortcut list
                    LoadShortcut(psc, Category.ShortcutList.Count - 1);
                }
            }
        }

        // Delete shortcut
        public void DeleteShortcut(ProgramShortcut psc)
        {
            Category.ShortcutList.Remove(psc);
            resetSelection(selectedShortcut);
            bool before = true;
            //int i = 0;

            foreach (ucProgramShortcut ucPsc in pnlShortcuts.Controls)
            {
                if (before)
                {
                    ucPsc.Top -= 50;
                }
                if (ucPsc.Shortcut == psc)
                {
                    //i = pnlShortcuts.Controls.IndexOf(ucPsc);
                    pnlShortcuts.Controls.Remove(ucPsc);
                    before = false;
                }
            }

            if (pnlShortcuts.Controls.Count < 5)
            {
                pnlShortcuts.Height -= 50;
                pnlAddShortcut.Top -= 50;
            }
        }

        // Change positions of shortcut panels
        public void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            resetSelection(selectedShortcut);
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;

            // Clears and reloads all shortcuts with new positions
            pnlShortcuts.Controls.Clear();
            pnlShortcuts.Height = 0;
            pnlAddShortcut.Top = 220;

            selectedShortcut = null;

            int position = 0;
            foreach (ProgramShortcut psc in Category.ShortcutList)
            {
                LoadShortcut(psc, position);
                position++;
            }
        }



        //--------------------------------------
        // IMAGE HANDLERS
        //--------------------------------------

        // Adding icon by button
        private void cmdAddGroupIcon_Click(object sender, EventArgs e)
        {
            lblErrorIcon.Visible = false;  //resetting error msg

            OpenFileDialog openFileDialog = new OpenFileDialog  // ask user to select img as group icon
            {
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

        // Handle drag and dropped images
        private void pnlDragDropImg(object sender, DragEventArgs e)
        {
            var files = (String[])e.Data.GetData(DataFormats.FileDrop);

            String imageExtension = Path.GetExtension(files[0]).ToLower();

            if (files.Length == 1 && newExt.Contains(imageExtension) && System.IO.File.Exists(files[0]))
            {
                // Checks if the files being added/dropped are an .exe or .lnk in which tye icons need to be extracted/processed
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

        // Handle returning images of icon files (.lnk)
        public static Image handleLnkExt(String file)
        {
            IWshShortcut lnkIcon = (IWshShortcut)new WshShell().CreateShortcut(file);
            String[] icLocation = lnkIcon.IconLocation.Split(',');
            // Check if iconLocation exists to get an .ico from; if not then take the image from the .exe it is referring to
            // Checks for link iconLocations as those are used by some applications
            if (icLocation[0] != "" && !lnkIcon.IconLocation.Contains("http"))
            {
                return Icon.ExtractAssociatedIcon(Path.GetFullPath(Environment.ExpandEnvironmentVariables(icLocation[0]))).ToBitmap();
            }
            else if (icLocation[0] == "" && lnkIcon.TargetPath == "")
            {
                return handleWindowsApp.getWindowsAppIcon(file);
            } else
            {
                return Icon.ExtractAssociatedIcon(Path.GetFullPath(Environment.ExpandEnvironmentVariables(lnkIcon.TargetPath))).ToBitmap();
            }

        }


        public static String handleExtName(String file)
        {
            string fileName = Path.GetFileName(file);
            file = Path.GetDirectoryName(Path.GetFullPath(file));
            Shell32.Folder shellFolder = shell.NameSpace(file);
            Shell32.FolderItem shellItem = shellFolder.Items().Item(fileName);

            return shellItem.Name;
        }

        // Below two functions highlights the background as you would if you hovered over it with a mosue
        // Use checkExtension to allow file dropping after a series of checks
        // Only highlights if the files being dropped are valid in extension wise
        private void pnlDragDropEnterExt(object sender, DragEventArgs e)
        {
            if (checkExtensions(e, extensionExt))
            {
                pnlAddShortcut.BackColor = Color.FromArgb(23, 23, 23);
            }
        }

        private void pnlDragDropEnterImg(object sender, DragEventArgs e)
        {
            if (checkExtensions(e, imageExt.Concat(specialImageExt).ToArray()))
            {
                pnlGroupIcon.BackColor = Color.FromArgb(23, 23, 23);
            }
        }

        // Series of checks to make sure it can be dropped
        private Boolean checkExtensions(DragEventArgs e, String[] exts)
        {
            // Make sure the file can be dragged dropped
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return false;

            // Get the list of files of the files dropped
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);

            // Loop through each file and make sure the extension is allowed as defined by a series of arrays at the top of the script
            foreach (var file in files)
            {
                String ext = Path.GetExtension(file);

                if (exts.Contains(ext.ToLower()) || Directory.Exists(file))
                {
                    // Gives the effect that it can be dropped and unlocks the ability to drop files in
                    e.Effect = DragDropEffects.Copy;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //--------------------------------------
        // SAVE/EXIT/DELETE GROUP
        //--------------------------------------

        // Exit editor
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            Client.Reload(); //flush and reload category panels
        }

        // Save group
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "Name the new group...") // Verify category name
            {
                lblErrorTitle.Text = "Must select a name";
                lblErrorTitle.Visible = true;
            }
            else if (!new Regex("^[0-9a-zA-Z \b]+$").IsMatch(txtGroupName.Text))
            {
                lblErrorTitle.Text = "Name must not have any special characters";
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
                        // Delete old config
                        //
                        string configPath = @MainPath.path + @"\config\" + Category.Name;
                        string shortcutPath = @MainPath.path + @"\Shortcuts\" + Regex.Replace(Category.Name, @"(_)+", " ") + ".lnk";
                        var dir = new DirectoryInfo(configPath);

                        dir.Delete(true); // delete config directory
                        System.IO.File.Delete(shortcutPath); // delete .lnk
                    }
                    //
                    // Creating new config
                    //
                    //int width = int.Parse(lblNum.Text);

                    Category.Width = int.Parse(lblNum.Text);

                    //Category category = new Category(txtGroupName.Text, Category.ShortcutList, width, System.Drawing.ColorTranslator.ToHtml(CategoryColor), Category.Opacity); // Instantiate category

                    // Normalize string so it can be used in path; remove spaces
                    Category.Name = Regex.Replace(txtGroupName.Text, @"\s+", "_");

                    Category.CreateConfig(cmdAddGroupIcon.BackgroundImage); // Creating group config files
                    Client.LoadCategory(Path.GetFullPath(@"config\" + Category.Name)); // Loading visuals

                    this.Dispose();
                    Client.Reload();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        // Delete group
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string configPath = @MainPath.path + @"\config\" + Category.Name;
                string shortcutPath = @MainPath.path + @"\Shortcuts\" + Regex.Replace(Category.Name, @"(_)+", " ") + ".lnk";

                var dir = new DirectoryInfo(configPath);

                System.IO.File.Delete(shortcutPath);
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

        //--------------------------------------
        // UI CUSTOMIZATION
        //--------------------------------------

        // Change category width
        private void cmdWidthUp_Click(object sender, EventArgs e)
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
        private void cmdWidthDown_Click(object sender, EventArgs e)
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

        // Color radio buttons
        private void radioCustom_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Category.ColorString = System.Drawing.ColorTranslator.ToHtml(colorDialog.Color);
                pnlCustomColor.Visible = true;
                pnlCustomColor.BackColor = colorDialog.Color;
            }
        }

        private void radioDark_Click(object sender, EventArgs e)
        {
            Category.ColorString = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(31, 31, 31));
            pnlCustomColor.Visible = false;
        }

        private void radioLight_Click(object sender, EventArgs e)
        {
            Category.ColorString = System.Drawing.ColorTranslator.ToHtml(Color.FromArgb(230, 230, 230));
            pnlCustomColor.Visible = false;
        }

        // Opacity buttons
        private void numOpacUp_Click(object sender, EventArgs e)
        {
            double op = double.Parse(lblOpacity.Text);
            op += 10;
            Category.Opacity = op;
            lblOpacity.Text = op.ToString();
            numOpacDown.Enabled = true;
            numOpacDown.BackgroundImage = global::client.Properties.Resources.NumDownWhite;

            if (op > 90)
            {
                numOpacUp.Enabled = false;
                numOpacUp.BackgroundImage = global::client.Properties.Resources.NumUpGray;
            }
        }

        private void numOpacDown_Click(object sender, EventArgs e)
        {
            double op = double.Parse(lblOpacity.Text);
            op -= 10;
            Category.Opacity = op;
            lblOpacity.Text = op.ToString();
            numOpacUp.Enabled = true;
            numOpacUp.BackgroundImage = global::client.Properties.Resources.NumUpWhite;

            if (op < 10)
            {
                numOpacDown.Enabled = false;
                numOpacDown.BackgroundImage = global::client.Properties.Resources.NumDownGray;
            }
        }

        //--------------------------------------
        // FORM VISUAL INTERACTIONS
        //--------------------------------------

        private void pnlGroupIcon_MouseEnter(object sender, EventArgs e)
        {
            pnlGroupIcon.BackColor = Color.FromArgb(23, 23, 23);
        }

        private void pnlGroupIcon_MouseLeave(object sender, EventArgs e)
        {
            pnlGroupIcon.BackColor = Color.FromArgb(31, 31, 31);
        }

        private void pnlAddShortcut_MouseEnter(object sender, EventArgs e)
        {
            pnlAddShortcut.BackColor = Color.FromArgb(23, 23, 23);
        }

        private void pnlAddShortcut_MouseLeave(object sender, EventArgs e)
        {
            pnlAddShortcut.BackColor = Color.FromArgb(31, 31, 31);
        }

        // Handles placeholder text for group name
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

        // Error labels
        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            lblErrorTitle.Visible = false;
        }

        public void resetSelection(ucProgramShortcut passedShortcut)
        {
            pnlArgumentTextbox.Enabled = false;
            if (selectedShortcut != null)
            {

                selectedShortcut.ucDeselected();

                selectedShortcut = null;
            }
        }

        public void enableSelection(ucProgramShortcut passedShortcut)
        {
            selectedShortcut = passedShortcut;
            passedShortcut.ucSelected();

            pnlArgumentTextbox.Text = Category.ShortcutList[selectedShortcut.Position].Arguments;
            pnlArgumentTextbox.Enabled = true;
        }

        private void pnlArgumentTextbox_TextChanged(object sender, EventArgs e)
        {
            Category.ShortcutList[selectedShortcut.Position].Arguments = pnlArgumentTextbox.Text;
        }
    }
}

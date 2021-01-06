using ChinhDo.Transactions;
using client.Classes;
using client.User_controls;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Dialogs; 

namespace client.Forms
{
    public partial class frmGroup : Form
    {
        public Category Category;
        public frmClient Client;
        public bool IsNew;
        private String[] imageExt = new String[] { ".png", ".jpg", ".jpe", ".jfif", ".jpeg", };
        private String[] extensionExt = new String[] { ".exe", ".lnk", ".url" };
        private String[] specialImageExt = new String[] { ".ico", ".exe", ".lnk" };
        private String[] newExt;

        public ucProgramShortcut selectedShortcut;

        public static Shell32.Shell shell = new Shell32.Shell();

        private List<ProgramShortcut> shortcutChanged = new List<ProgramShortcut>();


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
            this.Text = "Edit group";
            txtGroupName.Text = Regex.Replace(Category.Name, @"(_)+", " ");
            pnlAllowOpenAll.Checked = category.allowOpenAll;
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
            resetSelection();

            lblErrorShortcut.Visible = false; // resetting error msg

            if (Category.ShortcutList.Count >= 20)
            {
                lblErrorShortcut.Text = "Max 20 shortcuts in one group";
                lblErrorShortcut.BringToFront();
                lblErrorShortcut.Visible = true;
            }


            OpenFileDialog openFileDialog = new OpenFileDialog // ask user to select exe file
            {
                // TODO: Fix this path.
                InitialDirectory = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs",
                Title = "Create New Shortcut",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                DefaultExt = "exe",
                Filter = "Exe or Shortcut (.exe, .lnk)|*.exe;*.lnk;*.url",
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                DereferenceLinks = false
             };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    addShortcut(file);
                }
                resetSelection();
            }

            if (pnlShortcuts.Controls.Count != 0)
            {
                pnlShortcuts.ScrollControlIntoView(pnlShortcuts.Controls[0]);
            }
        }

        // Handle dropped programs into the add program/shortcut field
        private void pnlDragDropExt(object sender, DragEventArgs e)
        {
            var files = (String[])e.Data.GetData(DataFormats.FileDrop);

            if (files == null)
            {
                ShellObjectCollection ShellObj = ShellObjectCollection.FromDataObject((System.Runtime.InteropServices.ComTypes.IDataObject)e.Data);

                foreach (ShellNonFileSystemItem item in ShellObj)
                {
                    addShortcut(item.ParsingName, true);
                }
            } else
            {
                // Loops through each file to make sure they exist and to add them directly to the shortcut list
                foreach (var file in files)
                {
                    if (extensionExt.Contains(Path.GetExtension(file)) && System.IO.File.Exists(file) || Directory.Exists(file))
                    {
                        addShortcut(file);
                    }
                }
            }

            if (pnlShortcuts.Controls.Count != 0)
            {
                pnlShortcuts.ScrollControlIntoView(pnlShortcuts.Controls[0]);
            }
            
            resetSelection();
        }

        // Handle adding the shortcut to list
        private void addShortcut(String file, bool isExtension = false)
        {
            String workingDirec = getProperDirectory(file);

            ProgramShortcut psc = new ProgramShortcut() { FilePath = Environment.ExpandEnvironmentVariables(file), isWindowsApp = isExtension, WorkingDirectory = workingDirec }; //Create new shortcut obj
            Category.ShortcutList.Add(psc); // Add to panel shortcut list
            LoadShortcut(psc, Category.ShortcutList.Count - 1);
        }

        // Delete shortcut
        public void DeleteShortcut(ProgramShortcut psc)
        {
            resetSelection();

            Category.ShortcutList.Remove(psc);
            resetSelection();
            bool before = true;
            //int i = 0;

            foreach (ucProgramShortcut ucPsc in pnlShortcuts.Controls)
            {
                if (before)
                {
                    ucPsc.Top -= 50;
                    ucPsc.Position -= 1;
                }
                if (ucPsc.Shortcut == psc)
                {
                    //i = pnlShortcuts.Controls.IndexOf(ucPsc);

                    int controlIndex = pnlShortcuts.Controls.IndexOf(ucPsc);

                    pnlShortcuts.Controls.Remove(ucPsc);

                    if (controlIndex + 1 != pnlShortcuts.Controls.Count)
                    {
                        try
                        {
                            pnlShortcuts.ScrollControlIntoView(pnlShortcuts.Controls[controlIndex]);
                        } catch
                        {
                            if (pnlShortcuts.Controls.Count != 0)
                            {
                                pnlShortcuts.ScrollControlIntoView(pnlShortcuts.Controls[controlIndex - 1]);
                            }
                        }
                    }

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
            resetSelection();
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
            resetSelection();

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
                DereferenceLinks = false,
        };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                String imageExtension = Path.GetExtension(openFileDialog.FileName).ToLower();

                handleIcon(openFileDialog.FileName, imageExtension);
            }
        }

        // Handle drag and dropped images
        private void pnlDragDropImg(object sender, DragEventArgs e)
        {
            resetSelection();

            var files = (String[])e.Data.GetData(DataFormats.FileDrop);

            String imageExtension = Path.GetExtension(files[0]).ToLower();

            if (files.Length == 1 && newExt.Contains(imageExtension) && System.IO.File.Exists(files[0]))
            {
                // Checks if the files being added/dropped are an .exe or .lnk in which tye icons need to be extracted/processed
                handleIcon(files[0], imageExtension);
            }
        }

        private void handleIcon(String file, String imageExtension)
        {
            // Checks if the files being added/dropped are an .exe or .lnk in which tye icons need to be extracted/processed
            if (specialImageExt.Contains(imageExtension))
            {
                if (imageExtension == ".lnk")
                {
                    cmdAddGroupIcon.BackgroundImage = handleLnkExt(file);
                }
                else
                {
                    cmdAddGroupIcon.BackgroundImage = Icon.ExtractAssociatedIcon(file).ToBitmap();
                }
            }
            else
            {
                cmdAddGroupIcon.BackgroundImage = Image.FromFile(file);
            }
            lblAddGroupIcon.Text = "Change group icon";
        }

        // Handle returning images of icon files (.lnk)
        public static Bitmap handleLnkExt(String file)
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
            resetSelection();

            if (checkExtensions(e, extensionExt))
            {
                pnlAddShortcut.BackColor = Color.FromArgb(23, 23, 23);
            }
        }

        private void pnlDragDropEnterImg(object sender, DragEventArgs e)
        {
            resetSelection();

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

            if (e.Data.GetDataPresent("Shell IDList Array"))
            {
                 e.Effect = e.AllowedEffect;
                 return true;
            }


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
            resetSelection();

            //List <Directory> directories = 

            if (txtGroupName.Text == "Name the new group...") // Verify category name
            {
                lblErrorTitle.Text = "Must select a name";
                lblErrorTitle.Visible = true;
            }
            else if (IsNew && Directory.Exists(Path.Combine(MainPath.ConfigPath, txtGroupName.Text)) ||
                     !IsNew && Category.Name != txtGroupName.Text && Directory.Exists(Path.Combine(MainPath.ConfigPath, txtGroupName.Text)))
            {
                lblErrorTitle.Text = "There is already a group with that name";
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

                    foreach(ProgramShortcut shortcutModifiedItem in shortcutChanged)
                    {
                        if (!Directory.Exists(shortcutModifiedItem.WorkingDirectory))
                        {
                            shortcutModifiedItem.WorkingDirectory = getProperDirectory(shortcutModifiedItem.FilePath);
                        }
                    }


                    if (!IsNew)
                    {
                        //
                        // Delete old config
                        //
                        string configPath = Path.Combine(MainPath.ConfigPath, Category.Name);
                        string shortcutPath = Path.Combine(MainPath.ShortcutsPath, Regex.Replace(Category.Name, @"(_)+", " ") + ".lnk");

                        try
                        {
                            IFileManager fm = new TxFileManager();
                            using (TransactionScope scope1 = new TransactionScope())
                            {
                                fm.DeleteDirectory(configPath);
                                fm.Delete(shortcutPath);
                                scope1.Complete();
                            }
                        } catch (Exception)
                        {
                            MessageBox.Show("Please close all programs used within the taskbar group in order to save!");
                            return;
                        }
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
                    Client.LoadCategory(Path.Combine(MainPath.ConfigPath, Category.Name)); // Loading visuals
                    
                    this.Dispose();
                    Client.Reload();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Client.Reset();
            }

        }

        // Delete group
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            resetSelection();

            try
            {
                string configPath = Path.Combine(MainPath.ConfigPath, Category.Name);
                string shortcutPath = Path.Combine(MainPath.ShortcutsPath, Regex.Replace(Category.Name, @"(_)+", " ") + ".lnk");

                var dir = new DirectoryInfo(configPath);

                try
                {
                    IFileManager fm = new TxFileManager();
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        fm.DeleteDirectory(configPath);
                        fm.Delete(shortcutPath);
                        this.Hide();
                        this.Dispose();
                        Client.Reload(); //flush and reload category panels
                        scope1.Complete();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please close all programs used within the taskbar group in order to delete!");
                    return;
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Client.Reset();

        }

        //--------------------------------------
        // UI CUSTOMIZATION
        //--------------------------------------

        // Change category width
        private void cmdWidthUp_Click(object sender, EventArgs e)
        {
            resetSelection();

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
            resetSelection();

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
            resetSelection();
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

        //--------------------------------------
        // SHORTCUT/PROGRAM SELECTION
        //--------------------------------------

        // Deselect selected program/shortcut
        public void resetSelection()
        {
            pnlArgumentTextbox.Enabled = false;
            cmdSelectDirectory.Enabled = false;
            if (selectedShortcut != null)
            {
                pnlColor.Visible = true;
                pnlArguments.Visible = false;
                selectedShortcut.ucDeselected();
                selectedShortcut.IsSelected = false;
                selectedShortcut = null;
            }
        }

        // Enable the argument textbox once a shortcut/program has been selected
        public void enableSelection(ucProgramShortcut passedShortcut)
        {
            selectedShortcut = passedShortcut;
            passedShortcut.ucSelected();
            passedShortcut.IsSelected = true;

            pnlArgumentTextbox.Text = Category.ShortcutList[selectedShortcut.Position].Arguments;
            pnlArgumentTextbox.Enabled = true;

            pnlWorkingDirectory.Text = Category.ShortcutList[selectedShortcut.Position].WorkingDirectory;
            pnlWorkingDirectory.Enabled = true;
            cmdSelectDirectory.Enabled = true;

            pnlColor.Visible = false;
            pnlArguments.Visible = true;
        }

        // Set the argument property to whatever the user set
        private void pnlArgumentTextbox_TextChanged(object sender, EventArgs e)
        {
            Category.ShortcutList[selectedShortcut.Position].Arguments = pnlArgumentTextbox.Text;
        }

        // Clear textbox focus
        private void pnlArgumentTextbox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblAddGroupIcon.Focus();


                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Manage the checkbox allowing opening all shortcuts
        private void pnlAllowOpenAll_CheckedChanged(object sender, EventArgs e)
        {
            Category.allowOpenAll = pnlAllowOpenAll.Checked;
        }

        private void cmdSelectDirectory_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog()
            {
                EnsurePathExists = true,
                IsFolderPicker = true,
                InitialDirectory = Category.ShortcutList[selectedShortcut.Position].WorkingDirectory
            };

            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.Focus();
                Category.ShortcutList[selectedShortcut.Position].WorkingDirectory = openFileDialog.FileName;
            }
        }

        private void pnlWorkingDirectory_TextChanged(object sender, EventArgs e)
        {
            Category.ShortcutList[selectedShortcut.Position].WorkingDirectory = pnlWorkingDirectory.Text;

            if (!shortcutChanged.Contains(Category.ShortcutList[selectedShortcut.Position]))
            {
                shortcutChanged.Add(Category.ShortcutList[selectedShortcut.Position]);
            }
        }

        private String getProperDirectory(String file)
        {
            try {
                if (Path.GetExtension(file).ToLower() == ".lnk")
                {
                    IWshShortcut extension = (IWshShortcut)new WshShell().CreateShortcut(file);

                    return Path.GetDirectoryName(extension.TargetPath);
                }
                else
                {
                    return Path.GetDirectoryName(file);
                }
            } catch (Exception)
            {
                return MainPath.exeString;
            }
        }

        private void frmGroup_MouseClick(object sender, MouseEventArgs e)
        {
            resetSelection();
        }
    }
}

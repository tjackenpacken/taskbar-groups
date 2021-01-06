using System;
using System.Drawing;
using System.Windows.Forms;
using client.Classes;
using client.Forms;
using System.IO;
using System.Windows.Input;

namespace client.User_controls
{
    public partial class ucProgramShortcut : UserControl
    {
        public ProgramShortcut Shortcut { get; set; }
        public frmGroup MotherForm { get; set; }

        public bool IsSelected = false;
        public int Position { get; set; }

        public Bitmap logo;
        public ucProgramShortcut()
        {
            InitializeComponent();
        }

        private void ucProgramShortcut_Load(object sender, EventArgs e)
        {
            // Grab the file name without the extension to be used later as the naming scheme for the icon .jpg image

            if (Shortcut.isWindowsApp)
            {
                txtShortcutName.Text = handleWindowsApp.findWindowsAppsName(Shortcut.FilePath);
            } else if (Shortcut.name == "")
            {
                if (File.Exists(Shortcut.FilePath) && Path.GetExtension(Shortcut.FilePath).ToLower() == ".lnk")
                {
                    txtShortcutName.Text = frmGroup.handleExtName(Shortcut.FilePath);
                }
                else
                {
                    txtShortcutName.Text = Path.GetFileNameWithoutExtension(Shortcut.FilePath);
                }
            } else
            {
                txtShortcutName.Text = Shortcut.name;
            }

            Size size = TextRenderer.MeasureText(txtShortcutName.Text, txtShortcutName.Font);
            txtShortcutName.Width = size.Width;
            txtShortcutName.Height = size.Height;


            if (Shortcut.isWindowsApp)
            {
                picShortcut.BackgroundImage = handleWindowsApp.getWindowsAppIcon(Shortcut.FilePath, true);
            }
            else if (File.Exists(Shortcut.FilePath)) // Checks if the shortcut actually exists; if not then display an error image
            {
                String imageExtension = Path.GetExtension(Shortcut.FilePath).ToLower();

                // Start checking if the extension is an lnk (shortcut) file
                // Depending on the extension, the icon can be directly extracted or it has to be gotten through other methods as to not get the shortcut arrow
                if (imageExtension == ".lnk")
                {
                    picShortcut.BackgroundImage = logo = frmGroup.handleLnkExt(Shortcut.FilePath);
                }
                else
                {
                    picShortcut.BackgroundImage = logo = Icon.ExtractAssociatedIcon(Shortcut.FilePath).ToBitmap();
                }

            } else if (Directory.Exists(Shortcut.FilePath))
            {
                try
                {
                    picShortcut.BackgroundImage = logo = handleFolder.GetFolderIcon(Shortcut.FilePath).ToBitmap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                picShortcut.BackgroundImage = logo = global::client.Properties.Resources.Error;
            }

            if (Position == 0)
            {
                cmdNumUp.Enabled = false;
                cmdNumUp.BackgroundImage = global::client.Properties.Resources.NumUpGray;
            }
            if (Position == MotherForm.Category.ShortcutList.Count - 1)
            {
                cmdNumDown.Enabled = false;
                cmdNumDown.BackgroundImage = global::client.Properties.Resources.NumDownGray;

            }

        }

        private void ucProgramShortcut_MouseEnter(object sender, EventArgs e)
        {
            ucSelected();
        }

        private void ucProgramShortcut_MouseLeave(object sender, EventArgs e)
        {
            if (MotherForm.selectedShortcut != this)
            {
                ucDeselected();
            }
        }

        private void cmdNumUp_Click(object sender, EventArgs e)
        {
            MotherForm.Swap(MotherForm.Category.ShortcutList, Position, Position - 1);

        }

        private void cmdNumDown_Click(object sender, EventArgs e)
        {
            MotherForm.Swap(MotherForm.Category.ShortcutList, Position, Position + 1);

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            MotherForm.DeleteShortcut(Shortcut);
        }

        // Handle what is selected/deselected when a shortcut is clicked on
        // If current item is already selected, then deselect everything
        private void ucProgramShortcut_Click(object sender, EventArgs e)
        {
            if (MotherForm.selectedShortcut == this)
            {
                MotherForm.resetSelection();
                //IsSelected = false;
            }
            else
            {
                if (MotherForm.selectedShortcut != null)
                {
                    MotherForm.resetSelection();
                    //IsSelected = false;
                }

                MotherForm.enableSelection(this);
                //IsSelected = true;
            }
        }

        public void ucDeselected()
        {
            txtShortcutName.DeselectAll();
            txtShortcutName.Enabled = false;
            txtShortcutName.Enabled = true;
            txtShortcutName.TabStop = false; // Deselecting textbox text

            this.BackColor = Color.FromArgb(31, 31, 31);
            txtShortcutName.BackColor = Color.FromArgb(31, 31, 31);
            cmdNumUp.BackColor = Color.FromArgb(31, 31, 31);
            cmdNumDown.BackColor = Color.FromArgb(31, 31, 31);
        }

        public void ucSelected()
        {

            this.BackColor = Color.FromArgb(26, 26, 26);
            txtShortcutName.BackColor = Color.FromArgb(26, 26, 26);
            cmdNumUp.BackColor = Color.FromArgb(26, 26, 26);
            cmdNumDown.BackColor = Color.FromArgb(26, 26, 26);

        }

        private void lbTextbox_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(txtShortcutName.Text, txtShortcutName.Font);
            txtShortcutName.Width = size.Width;
            txtShortcutName.Height = size.Height;
            Shortcut.name = txtShortcutName.Text;
        }

        private void ucProgramShortcut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                picShortcut.Focus();


                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtShortcutName_Click(object sender, EventArgs e)
        {
            
            if (!IsSelected)
                ucProgramShortcut_Click(sender, e);
        }

        private void ucProgramShortcut_Enter(object sender, EventArgs e)
        {
            //IsSelected = true;
        }

        private void ucProgramShortcut_Leave(object sender, EventArgs e)
        {
            //IsSelected = false;
        }

    }
}

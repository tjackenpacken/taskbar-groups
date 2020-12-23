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
    public partial class ucProgramShortcut : UserControl
    {
        public ProgramShortcut Shortcut { get; set; }
        public frmGroup MotherForm { get; set; }
        public int Position { get; set; }
        public ucProgramShortcut(frmGroup motherForm, ProgramShortcut shortcut, int position)
        {
            InitializeComponent();
            MotherForm = motherForm;
            Shortcut = shortcut;
            Position = position;
        }

        private void ucProgramShortcut_Load(object sender, EventArgs e)
        {
            // Grab the file name without the extension to be used later as the naming scheme for the icon .jpg image
            lblName.Text = Path.GetFileNameWithoutExtension(Shortcut.FilePath);

              
            if (File.Exists(Shortcut.FilePath)) // Checks if the shortcut actually exists; if not then display an error image
            {
                String imageExtension = Path.GetExtension(Shortcut.FilePath).ToLower();

                // Start checking if the extension is an lnk (shortcut) file
                // Depending on the extension, the icon can be directly extracted or it has to be gotten through other methods as to not get the shortcut arrow
                if (imageExtension == ".lnk")
                {
                    picShortcut.BackgroundImage = frmGroup.handleLnkExt(Shortcut.FilePath);
                }
                else
                {
                    picShortcut.BackgroundImage = Icon.ExtractAssociatedIcon(Shortcut.FilePath).ToBitmap();
                }

            } else
            {
                picShortcut.BackgroundImage = global::client.Properties.Resources.Error;
            }

            //picShortcut.BackgroundImage = System.Drawing.Icon.ExtractAssociatedIcon(Shortcut.FilePath).ToBitmap();

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
            this.BackColor = Color.FromArgb(26, 26, 26);
            cmdNumUp.BackColor = Color.FromArgb(26, 26, 26);
            cmdNumDown.BackColor = Color.FromArgb(26, 26, 26);

        }

        private void ucProgramShortcut_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(31, 31, 31);
            cmdNumUp.BackColor = Color.FromArgb(31, 31, 31);
            cmdNumDown.BackColor = Color.FromArgb(31, 31, 31);
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
            MotherForm.Category.ShortcutList.Remove(Shortcut);
            MotherForm.LoadShortcuts();
        }
    }
}

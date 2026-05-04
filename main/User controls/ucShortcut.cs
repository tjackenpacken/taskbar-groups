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
using System.Diagnostics;
using System.IO;
using IWshRuntimeLibrary;

namespace client.User_controls
{
    public partial class ucShortcut : UserControl
    {
        public ProgramShortcut Psc { get; set; }
        public frmMain MotherForm { get; set; }
        public Category ThisCategory { get; set; }

        // ADDED: Tooltip used to show the shortcut/app name when hovering over the icon.
        private ToolTip shortcutToolTip = new ToolTip();

        public ucShortcut()
        {
            InitializeComponent();
        }

        private void ucShortcut_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
            this.BackColor = MotherForm.BackColor;
            picIcon.BackgroundImage = ThisCategory.loadImageCache(Psc); // Use the local icon cache for the file specified as the icon image

            // ADDED: Show a hover tooltip so identical icons can be distinguished.
            string displayName = !string.IsNullOrWhiteSpace(Psc.name)
                ? Psc.name
                : Path.GetFileNameWithoutExtension(Psc.FilePath);

            // ADDED: Attach tooltip to both the UserControl and the actual PictureBox.
            // The mouse is usually over picIcon, so setting only "this" may not be enough.
            shortcutToolTip.SetToolTip(this, displayName);
            shortcutToolTip.SetToolTip(picIcon, displayName);
        }

        public void ucShortcut_Click(object sender, EventArgs e)
        {
            if (Psc.isWindowsApp)
            {
                Process p = new Process() {StartInfo = new ProcessStartInfo() { UseShellExecute = true, FileName = $@"shell:appsFolder\{Psc.FilePath}" }};
                p.Start();
            } else
            {
                if(Path.GetExtension(Psc.FilePath).ToLower() == ".lnk" && Psc.FilePath == MainPath.exeString)

                {
                    MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, MainPath.path);
                } else
                {
                    MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, Psc.WorkingDirectory);
                }
            }
        }

        public void ucShortcut_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = MotherForm.HoverColor;
        }

        public void ucShortcut_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}

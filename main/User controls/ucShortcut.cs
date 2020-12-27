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

namespace client.User_controls
{
    public partial class ucShortcut : UserControl
    {
        public ProgramShortcut Psc { get; set; }
        public frmMain MotherForm { get; set; }
        public Category ThisCategory { get; set; }
        public ucShortcut(ProgramShortcut psc, frmMain mainForm, Category category)
        {
            InitializeComponent();
            Psc = psc;
            MotherForm = mainForm;
            ThisCategory = category;
        }

        private void ucShortcut_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
            this.BackColor = MotherForm.BackColor;
            picIcon.BackgroundImage = ThisCategory.loadImageCache(Psc.FilePath); // Use the local icon cache for the file specified as the icon image
        }

        private void ucShortcut_Click(object sender, EventArgs e)
        {
            MotherForm.OpenFile(sender, e, Psc.FilePath);
        }

        private void ucShortcut_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = MotherForm.HoverColor;
        }

        private void ucShortcut_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}

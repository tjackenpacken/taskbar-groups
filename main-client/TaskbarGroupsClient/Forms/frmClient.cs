using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TaskbarGroups.Classes;

namespace TaskbarGroupsClient
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
            Reload();
        }
        public void Reload()
        {
            // flush and reload existing groups
            pnlExistingGroups.Controls.Clear();
            pnlExistingGroups.Height = 0;

            string configPath = Directory.GetCurrentDirectory() + @"\config";
            string[] subDirectories = Directory.GetDirectories(configPath);
            foreach (string dir in subDirectories)
            {
                try
                {
                    LoadCategory(dir);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (pnlExistingGroups.HasChildren) // helper if no group is created
            {
                lblHelpTitle.Text = "Click on a group to add a taskbar shortcut";
                pnlHelp.Visible = true;
            }
            else // helper if groups are created
            {
                lblHelpTitle.Text = "Press on \"Add Taskbar group\" to get started";
                pnlHelp.Visible = false;
            }

            pnlAddGroup.Top = pnlExistingGroups.Bottom + 40; // spacing between existing groups and add new group btn
            pnlLeftColumn.Height = this.RectangleToScreen(this.ClientRectangle).Height; // making left column pnl dynamic
        }

        public void LoadCategory(string dir)
        {
            Category category = new Category(dir);
            ucCategoryPanel newCategory = new ucCategoryPanel(this, category);
            pnlExistingGroups.Height += newCategory.Height;
            pnlExistingGroups.Controls.Add(newCategory);
            newCategory.Top = pnlExistingGroups.Height - newCategory.Height;
            newCategory.Show();
            newCategory.BringToFront();
            newCategory.MouseEnter += new System.EventHandler((sender, e) => EnterControl(sender, e, newCategory));
            newCategory.MouseLeave += new System.EventHandler((sender, e) => LeaveControl(sender, e, newCategory));
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            frmNewGroup newGroup = new frmNewGroup(this);
            newGroup.Show();
            newGroup.BringToFront();
        }

        private void pnlAddGroup_MouseLeave(object sender, EventArgs e)
        {
            pnlAddGroup.BackColor = Color.Black;
        }

        private void pnlAddGroup_MouseEnter(object sender, EventArgs e)
        {
            pnlAddGroup.BackColor = Color.FromArgb(31, 31, 31);
        }

        public void EnterControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(31, 31, 31);
        }
        public void LeaveControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.Black;
        }

    }
}

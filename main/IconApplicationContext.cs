using client.Forms;
using client.Properties;
using System;
using System.Drawing;

namespace client
{
    class IconApplicationContext : TrayIconApplicationContext
    {
        private frmClient frmClient;

        public IconApplicationContext()
        {
            TrayIcon.Icon = Resources.Icon;
            TrayIcon.Visible = true;

            ContextMenu.Items.Add("Taskbar Group", null, this.SettingsContextMenuClickHandler);
            ContextMenu.Items.Add("E&xit", null, this.ExitContextMenuClickHandler);

            if (Properties.Settings.Default.FirstRun == true)
            {
                frmClient = new frmClient();
                frmClient.Show();

                //Change the value since the program has run once now
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }
        }

        protected override void OnApplicationExit(EventArgs e)
        {
            base.OnApplicationExit(e);
        }

        private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
        {
            this.ExitThread();
        }

        private void SettingsContextMenuClickHandler(object sender, EventArgs eventArgs)
        {
            this.ShowSettings();
        }

        private void ShowSettings()
        {
            if (frmClient != null)
            {
                if (frmClient.IsDisposed)
                {
                    frmClient = new frmClient();
                    frmClient.Show();
                }
                else
                {
                    frmClient.BringToFront();
                }
            }
            else
            {
                frmClient = new frmClient();
                frmClient.Show();
            }
        }
    }
}

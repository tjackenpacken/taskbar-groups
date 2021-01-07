using client.Forms;
using client.Properties;
using System;
using System.Drawing;

namespace client
{
    class IconApplicationContext : TrayIconApplicationContext
    {
        private string passedDirectory;
        private int cursorPosX;
        private int cursorPosY;

        bool isClient = false;

        private frmClient frmClient;
        private frmMain frmMain;

        public IconApplicationContext()
        {
            TrayIcon.Icon = Resources.Icon;
            TrayIcon.Visible = true;

            ContextMenu.Items.Add("Taskbar Group", null, this.SettingsContextMenuClickHandler);
            ContextMenu.Items.Add("E&xit", null, this.ExitContextMenuClickHandler);

            isClient = true;
        }

        public IconApplicationContext(string _passedDirectory, int _cursorPosX, int _cursorPosY)
        {
            TrayIcon.Icon = Resources.Icon;
            TrayIcon.Visible = true;

            ContextMenu.Items.Add("Taskbar Group", null, this.SettingsContextMenuClickHandler).Font = new Font(this.ContextMenu.Font, FontStyle.Bold);
            ContextMenu.Items.Add("E&xit", null, this.ExitContextMenuClickHandler);
            
            passedDirectory = _passedDirectory;
            cursorPosX = _cursorPosX;
            cursorPosY = _cursorPosY;

            isClient = false;
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
            if (isClient)
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
            else
            {
                if (frmMain != null)
                {
                    if (frmMain.IsDisposed)
                    {
                        frmMain = new frmMain(passedDirectory, cursorPosX, cursorPosY);
                        frmMain.Show();
                    }
                    else
                    {
                        frmMain.BringToFront();
                    }
                }
                else
                {
                    frmMain = new frmMain(passedDirectory, cursorPosX, cursorPosY);
                    frmMain.Show();                    
                }
            }
        }
    }
}

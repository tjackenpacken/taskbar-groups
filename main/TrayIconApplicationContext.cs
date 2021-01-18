using client.Forms;
using client.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace client
{
    public abstract class TrayIconApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _contextMenu;
        private frmClient _frmClient;
        protected TrayIconApplicationContext()
        {
            _contextMenu = new ContextMenuStrip();
            _notifyIcon = new NotifyIcon();
            _frmClient = new frmClient();

            Application.ApplicationExit += this.ApplicationExitHandler;
            
            this.TrayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;

            this.TrayIcon.Icon = Resources.Icon;
            this.TrayIcon.ContextMenuStrip = this.ContextMenu;
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_frmClient.IsDisposed)
            {
                _frmClient = new frmClient();
                _frmClient.Show();
            }
            else
            { _frmClient.Show(); }
        }

        protected virtual void OnApplicationExit(EventArgs e)
        {
            if (_notifyIcon != null)
            {
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();
            }
        }

        private void ApplicationExitHandler(object sender, EventArgs e)
        {
            if (_contextMenu != null)
                _contextMenu.Dispose();

            this.OnApplicationExit(e);
        }

        protected ContextMenuStrip ContextMenu
        {
            get { return _contextMenu; }
        }
        protected NotifyIcon TrayIcon
        {
            get { return _notifyIcon; }
        }
    }
}


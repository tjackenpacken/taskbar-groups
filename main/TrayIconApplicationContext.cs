using client.Properties;
using System;
using System.Windows.Forms;

namespace client
{
    public abstract class TrayIconApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _contextMenu;

        protected TrayIconApplicationContext()
        {
            _contextMenu = new ContextMenuStrip();
            _notifyIcon = new NotifyIcon();

            Application.ApplicationExit += this.ApplicationExitHandler;
            
            this.TrayIcon.MouseClick += TrayIcon_MouseClick;
            
            this.TrayIcon.Icon = Resources.Icon;
            this.TrayIcon.ContextMenuStrip = this.ContextMenu;
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            _contextMenu.Visible = true;
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


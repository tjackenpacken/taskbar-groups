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

        protected TrayIconApplicationContext()
        {
            _contextMenu = new ContextMenuStrip();
            _notifyIcon = new NotifyIcon();

            Application.ApplicationExit += this.ApplicationExitHandler;
            
            this.TrayIcon.MouseClick += TrayIcon_MouseClick;
            this.TrayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;

            this.TrayIcon.Icon = Resources.Icon;
            this.TrayIcon.ContextMenuStrip = this.ContextMenu;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        public static Point GetMousePosition()
        {
            var w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);

            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _contextMenu.Show(GetMousePosition());
            _contextMenu.Visible = true;
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            _contextMenu.Show(GetMousePosition());
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


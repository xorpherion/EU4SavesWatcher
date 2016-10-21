using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EU4SavesWatcher
{
    public class Window : IDisposable
    {
        private Form window;
        private NotifyIcon trayIcon;

        public void Dispose()
        {
            window.Dispose();
            trayIcon.Visible = false;
            trayIcon.Dispose();
        }

        public void Init()
        {
            InitWindow();
            InitTrayIcon();

            Application.Run(window);
        }

        private void InitTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.Icon = window.Icon;
            trayIcon.Visible = true;
            trayIcon.MouseClick += TrayIconOnMouseClick; 
        }

        private void TrayIconOnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            ToggleWindowVisibility();
        }

        private void ToggleWindowVisibility()
        {
            window.Visible = !window.Visible;
        }

        private void InitWindow()
        {
            window = new Form();
            window.Text = "EU4SavesWatcher";

            window.Shown += WindowOnShown;
        }

        private void WindowOnShown(object sender, EventArgs eventArgs)
        {
            ShowBallonTip("EU4SavesWatcher is running...");
            window.Hide();
        }

        public void ShowBallonTip(String text)
        {
            window.Invoke((Action)(() =>
            {
                window.Show();
                trayIcon.BalloonTipText = text;
                trayIcon.ShowBalloonTip(1000);
                window.Hide();
            }));
            
        }
    }
}

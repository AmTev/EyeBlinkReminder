using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EyeBlinkReminder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool _isExit;
        // private NotifyIcon _notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Task.Factory.StartNew(async () =>
            {
                var worker = new EyeRelievingIntervalWorker();
                while (true)
                {
                    if (!worker.IsRunning)
                    {
                        worker.Run();
                    }

                    await Task.Delay(1 * 60 * 1000);
                }
            });

            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindow_Closing;
            MainWindow.StateChanged += MainWindow_StateChanged;
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (MainWindow.WindowState == WindowState.Minimized)
                MainWindow.Hide(); // A hidden window can be shown again, a closed one not
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide(); // A hidden window can be shown again, a closed one not
            }
        }

        //private void notifyWin()
        //{
        //    _notifyIcon = new NotifyIcon();
        //    _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
        //    _notifyIcon.Icon = WindowsApp.Util.Properties.Resources.NotifyIcon;
        //    _notifyIcon.Visible = true;
        //}
    }
}
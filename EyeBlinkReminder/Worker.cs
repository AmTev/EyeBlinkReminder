using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyeBlinkReminder
{
    public class EyeRelievingIntervalWorker
    {
        public int Interval { get; set; } = 30 * 60;
        public bool IsRunning { get; set; }
        private Task _task;
        public Task Task => _task;

        public async void Run()
        {
            IsRunning = true;
            var startTime = DateTime.Now;
            _task = Task.Factory.StartNew(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var blinker = new Blinker();
                    blinker.WindowState = WindowState.Normal;

                    blinker.Show();

                    blinker.WindowState = WindowState.Maximized;
                });
            }).ContinueWith((t) =>
            {
                var elapsed = DateTime.Now - startTime;
                if (elapsed.TotalSeconds < Interval)
                {
                    Task.Delay((Interval - (int)elapsed.TotalSeconds) * 1000).Wait();
                }
                IsRunning = false; ;
            });
        }
    }
}
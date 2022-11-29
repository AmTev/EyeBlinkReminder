using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EyeBlinkReminder
{
    /// <summary>
    /// Interaction logic for Blinker.xaml
    /// </summary>
    public partial class Blinker : Window
    {
        private int count = 0;

        public Blinker()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (count == 10) this.Close();

            count++;
            mainButton.Opacity = mainButton.Opacity == 1 ? 0.5 : 1;
            mainButton.Foreground = mainButton.Foreground == Brushes.White ? Brushes.Black : Brushes.White;
        }
    }
}
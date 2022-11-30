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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EyeBlinkReminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (App.Current.Resources["textToDisplay"] != null)
            {
                textToDisplay.Text = App.Current.Resources["textToDisplay"].ToString();
            }
            if (App.Current.Resources["timer"] != null)
            {
                timer.Text = App.Current.Resources["timer"].ToString();
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textToDisplay.Text))
            {
                if (App.Current.Resources["textToDisplay"] == null)
                {
                    App.Current.Resources.Add("textToDisplay", textToDisplay.Text);
                }
                else
                {
                    App.Current.Resources["textToDisplay"] = textToDisplay.Text;
                }
            }

            if (!string.IsNullOrWhiteSpace(timer.Text))
            {
                if (App.Current.Resources["timer"] == null)
                {
                    App.Current.Resources.Add("timer", textToDisplay.Text);
                }
                else
                {
                    App.Current.Resources["timer"] = textToDisplay.Text;
                }

                App.worker.Interval = Convert.ToInt32(timer.Text) * 60;
            }
        }
    }
}
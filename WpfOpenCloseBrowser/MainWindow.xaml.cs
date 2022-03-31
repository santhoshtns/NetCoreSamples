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

namespace WpfOpenCloseBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BrowserWindow> _browserWindows = new List<BrowserWindow>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBrowser_OnClick(object sender, RoutedEventArgs e)
        {
            var browserWindow = new BrowserWindow(NavigateUrl.Text);
            _browserWindows.Add(browserWindow);
            browserWindow.Show();
        }

        private void CloseBrowser_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_browserWindows.Count > 0)
                {
                    var browserWindow = _browserWindows.First();
                    _browserWindows.Remove(browserWindow);
                    browserWindow.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

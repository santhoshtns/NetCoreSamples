using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace WpfOpenCloseBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BrowserWindow> _browserWindows = new List<BrowserWindow>();
        private List<DateTime> _browserStartTimes = new List<DateTime>();

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

        private void OpenBrowserTab_OnClick(object sender, RoutedEventArgs e)
        {
            _browserStartTimes.Add(DateTime.Now);
            Process.Start("msedge.exe", $"--new-window {NavigateUrl.Text}");
        }

        private void CloseBrowserTab_OnClick(object sender, RoutedEventArgs e)
        {
            if (_browserStartTimes.Count > 0)
            {
                var dateTime = _browserStartTimes.First();
                Process[] processes = Process.GetProcessesByName("msedge");
                foreach (var process in processes)
                {
                    var span = dateTime - process.StartTime;
                    if (span.TotalSeconds > 0 && span.TotalSeconds < 2)
                    {
                        process.Kill();
                        process.WaitForExit(2000);
                    }
                }

                _browserStartTimes.Remove(dateTime);
            }
        }

        private void OpenWindow_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("msedge.exe", $"--new-window {NavigateUrl.Text}");
        }

        private void CloseAllWindows_OnClick(object sender, RoutedEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("msedge");
            foreach (var process in processes.Where(x => x.MainWindowHandle != IntPtr.Zero))
            {
                process.Kill();
                process.WaitForExit(2000);
            }
        }
    }
}

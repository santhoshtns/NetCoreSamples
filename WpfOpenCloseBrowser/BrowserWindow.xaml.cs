using System;
using System.Windows;

namespace WpfOpenCloseBrowser
{
    /// <summary>
    /// Interaction logic for BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        private string _url;

        public BrowserWindow(string url)
        {
            _url = url;
            InitializeComponent();
            txtUrl.Text = _url;
        }

        private void BrowserWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            WebView2Browser.Source = new Uri(_url);
        }
    }
}

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using File = Google.Apis.Drive.v3.Data.File;

namespace SYST_Exam_ReadFileFromGoogleDrive_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            textBlock.Text = await GetSome();
        }
        private Task<string> GetSome()
        {
            return Task.Run(() =>
            {
                string url = @"https://docs.google.com/document/export?format=txt&id=1Tukgwu_VGTsdP0dI4ZriYBQcJ5PvRJRaq597rex0Fyk&token=AC4w5VjJ-Ji7VHeIYt8xaxiGXkcXDR7HxQ%3A1527053708273&ouid=102356211124763670632&includes_info_params=true";
                string json;

                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    json = wc.DownloadString(url);

                }
                return json;
            });
        }
    }
}
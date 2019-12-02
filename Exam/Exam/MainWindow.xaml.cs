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
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Position { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Position = 1;
            using (WebClient client = new WebClient())
            {
                string url = $"https://swapi.co/api/people/?page={Position}";
                var json = client.DownloadString(url);
                var result = JsonConvert.DeserializeObject<Page>(json);
                dataGrid.ItemsSource = result.Results;
            }
        }


        private void OnlyDigits(object sender, TextCompositionEventArgs e)
        {
            TextBox text = sender as TextBox;
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            text.MaxLength = 7;
        }

        private void LoadPage(object sender, RoutedEventArgs e)
        {
            Position = Int32.Parse(textBox.Text);
            using (WebClient client = new WebClient())
            {
                string url = $"https://swapi.co/api/people/?page={Position}";
                var json = client.DownloadString(url);
                var result = JsonConvert.DeserializeObject<Page>(json);
                dataGrid.ItemsSource = result.Results;
            }
        }
    }
}

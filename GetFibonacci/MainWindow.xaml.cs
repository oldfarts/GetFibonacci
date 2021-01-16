using System;
using System.Text;
using System.Windows;
using System.Net;
using System.IO;

namespace GetFibonacci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Number { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5000/Fibonacci");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                // Kikkailua...Ei näin :)
                string json = "{\"number\":\"7\"}";
                string temp = "7";
                var values = new StringBuilder(json);
                values.Replace(temp, textBlockInsert.Text);
                streamWriter.WriteLine(values);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                textBlock.Text = result;
            }

        }
    }
}

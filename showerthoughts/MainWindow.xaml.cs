using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
namespace showerthoughts
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] something = new string[30];
        public MainWindow()
        {
            InitializeComponent();
            APIFill();
        }

        public async void APIFill()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://www.reddit.com/r/Showerthoughts/new.json?sort=hot");
            string json = await response.Content.ReadAsStringAsync();
            dynamic c = JsonConvert.DeserializeObject(json);
            
                 
            for(int i = 0; i< 24; i++)
            {
                something[i] = c.data.children[i].data.title;
            }

            Labelforshowers.Text = something[4];

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Random r = new Random();
       
            Labelforshowers.Text = something[r.Next(0, 24)];
            //MessageBox.Show(something[0]);

        }
    }
}

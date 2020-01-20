using SearchPhotoLibrary;
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

namespace SearchPhotoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
     
        }
        
        class Images
        {
            public string imagePath { get; set; }
        }

        private async Task LoadImage()
        {
            List<Images> list = new List<Images>();
            var photo = await PhotoProcessor.LoadPhoto(Convert.ToString(text.Text));

            for (int i = 0; i < photo.uriList.Count; i++)
            {
                var uriSource = photo.uriList[i];
                
                list.Add(new Images() { imagePath = uriSource.AbsoluteUri});

            }

            ListBox1.ItemsSource = list;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        public async void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        
    }
}

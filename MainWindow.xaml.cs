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
            //ApiHelper.InitializeClient();
            
        }
        
        private async Task LoadImage(string query)
        {
            var photo = await PhotoProcessor.LoadPhoto(query);

            for (int i = 0; i < photo.uriList.Count; i++)
            {
                var uriSource = photo.uriList[i];
                switch (i)
                {
                    case 0:
                        photoImage1.Source = new BitmapImage(uriSource);
                        break;
                    case 1:
                        photoImage2.Source = new BitmapImage(uriSource);
                        break;
                    case 2:
                        photoImage3.Source = new BitmapImage(uriSource);
                        break;
                    case 3:
                        photoImage4.Source = new BitmapImage(uriSource);
                        break;
                    case 4:
                        photoImage5.Source = new BitmapImage(uriSource);
                        break;
                    case 5:
                        photoImage6.Source = new BitmapImage(uriSource);
                        break;
                    case 6:
                        photoImage7.Source = new BitmapImage(uriSource);
                        break;
                    case 7:
                        photoImage8.Source = new BitmapImage(uriSource);
                        break;
                        /*
                    case 8:
                        photoImage9.Source =new BitmapImage(uriSource);
                        break;
                    case 9:
                        photoImage10.Source = new BitmapImage(uriSource);
                        break;
                    case 10:
                        photoImage11.Source = new BitmapImage(uriSource);
                        break;
                    case 11:
                        photoImage12.Source = new BitmapImage(uriSource);
                        break;
                    case 12:
                        photoImage13.Source = new BitmapImage(uriSource);
                        break;
                    case 13:
                        photoImage14.Source = new BitmapImage(uriSource);
                        break;
                    case 14:
                        photoImage15.Source = new BitmapImage(uriSource);
                        break;
                    case 15:
                        photoImage16.Source = new BitmapImage(uriSource);
                        break;
                    case 16:
                        photoImage17.Source = new BitmapImage(uriSource);
                        break;
                    case 17:
                        photoImage18.Source = new BitmapImage(uriSource);
                        break;
                    case 18:
                        photoImage19.Source = new BitmapImage(uriSource);
                        break;
                    case 19:
                        photoImage20.Source = new BitmapImage(uriSource);
                        break;
                        */
                        
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
        }
        
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        public async void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            await LoadImage(Convert.ToString(text.Text));
        }
    }
}

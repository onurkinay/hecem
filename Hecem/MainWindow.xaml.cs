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

namespace Hecem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Giris giris = new Giris();
            giris.ShowDialog();
            _Sayfa.Navigate(new Anasayfa());
            Yenile();
        }


        void Yenile()
        {
            List<string> kullanici = Islemler.KullaniciCek(App.ka);

            ka.Text = kullanici[1];
            puan.Text = "Puan: " + kullanici[5];
        }
    

        private void _Sayfa_Navigated(object sender, NavigationEventArgs e)
        {
            if (_Sayfa.CanGoBack)
                backImg.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/back.png"));
            else backImg.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/close.png"));

           // baslik.Text = _Sayfa.
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (backImg.Source.ToString().IndexOf("back") != -1)
                _Sayfa.GoBack();
            else Close();

            baslik.Text = "Hecem";
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            if (userMenu.Visibility == Visibility.Collapsed) userMenu.Visibility = Visibility.Visible;
            else userMenu.Visibility = Visibility.Collapsed;
        }

        private void cikis_Click(object sender, RoutedEventArgs e)
        {
            App.ka = "";
            Giris giris = new Giris();
            giris.ShowDialog();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            userMenu.Visibility = Visibility.Collapsed;
        }
    }
}

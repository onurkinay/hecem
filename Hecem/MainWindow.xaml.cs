using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Hecem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Giris giris = new Giris();
        public MainWindow()
        {
            InitializeComponent();
            giris.ShowDialog();
         
            _Sayfa.Navigate(new Anasayfa());

          
        }


        public void Yenile()
        {
            List<string> kullanici = Islemler.KullaniciCek(App.ka);

            ka.Text = kullanici[1];
            puan.Text = "Puan: " + kullanici[5];
        }
    

        private void _Sayfa_Navigated(object sender, NavigationEventArgs e)
        {
            if (_Sayfa.CanGoBack && (((Page)_Sayfa.Content).Title.IndexOf("Anasayfa") == -1)  )
                backImg.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/geri.png"));
            else
                backImg.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/kapat.png"));
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
           
            if (((Page)_Sayfa.Content).Title.IndexOf("Test") != -1)
                _Sayfa.Navigate(new Anasayfa());
            else if (backImg.Source.ToString().IndexOf("geri") != -1)
                _Sayfa.GoBack();
            else Environment.Exit(0);

            baslik.Text = "Hecem";
            
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            if (userMenu.Visibility == Visibility.Collapsed)
                userMenu.Visibility = Visibility.Visible;
            else
                userMenu.Visibility = Visibility.Collapsed;
        }

        private void cikis_Click(object sender, RoutedEventArgs e)
        {
            App.ka = "";
            ka.Text = "";
            puan.Text = "";

            Giris giris = new Giris();
            giris.ShowDialog();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            userMenu.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Islemler.Yenile();
        }
    }
}

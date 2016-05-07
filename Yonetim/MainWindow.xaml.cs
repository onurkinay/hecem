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

namespace Yonetim
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Yenile();
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Ogrenci ogrenci = ((ListViewItem)sender).Content as Ogrenci;
            OgrenciW ogrYonetim = new OgrenciW(ogrenci);
            ogrYonetim.ShowDialog();
            Yenile();
        }

        private void ekle_Click(object sender, RoutedEventArgs e)
        {
            OgrenciW ogrYonetim = new OgrenciW(new Ogrenci());
            ogrYonetim.ShowDialog();
            Yenile();
        }

        private void sil_Click(object sender, RoutedEventArgs e)
        {
            Ogrenci ogrenci = Ogrenciler.SelectedItem as Ogrenci;
            MessageBoxResult result = MessageBox.Show(ogrenci.adsoyad+ " öğrenciyi silmek istediğinizden emin misiniz?", "Onayla", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
               MessageBox.Show( Islemler.OgrenciSil(ogrenci) ? "Öğrenciniz silindi":"Hata! Öğrenci silinemedi");
            }

            Yenile();
        }

        void Yenile()
        {
            Islemler.OgrencileriCek();
            Ogrenciler.ItemsSource = Islemler.ogrenciler;
        }
    }
}

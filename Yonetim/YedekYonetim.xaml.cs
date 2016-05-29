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
using System.Windows.Shapes;
using Microsoft.Win32;
namespace Yonetim
{
    /// <summary>
    /// Interaction logic for YedekYonetim.xaml
    /// </summary>
    public partial class YedekYonetim : Window
    {
        public YedekYonetim()
        {
            InitializeComponent();
            Yenile();
        }

        private void yedeksil_Click(object sender, RoutedEventArgs e)
        {
            Yedekleme.Yedek yedek = Yedekler.SelectedItem as Yedekleme.Yedek;
            MessageBoxResult sonuc = MessageBox.Show(yedek.adi+ " adlı yedek silinsin mi?", "Yedek Sil", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (sonuc == MessageBoxResult.Yes)
            {
                Yedekleme.Islemler.Sil(yedek);
                Yenile();
            }
        }

        private void yedekle_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Filter = "Veritabanı Yedeği (.dbback)|*.dbback";
            
            if (kaydet.ShowDialog() == true)
            {
                var sections = kaydet.FileName.Split('\\');
                string DosyaAd = sections[sections.Length - 1];

                Yedekleme.Islemler.Yedekle(DosyaAd.Split('.')[0], kaydet.FileName);
            }
            Yenile();

        }
        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult sonuc = MessageBox.Show("Yedek geri yüklensin mi? Geri yüklemesi durumunda mevcut veri silinecek ve yedek geri yüklenecektir.", "Geri yükle", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (sonuc == MessageBoxResult.Yes)
            {
                if (Yedekleme.Islemler.GeriYukle(Yedekler.SelectedItem as Yedekleme.Yedek))
                { MessageBox.Show("Yedek geri yüklendi!"); this.Close(); }
            }
            Yenile();
        }

        void Yenile()
        {
            Yedekler.ItemsSource = Yedekleme.Yonet.YedekleriCek();
        }
    }
}

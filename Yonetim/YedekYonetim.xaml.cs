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
            Yedekleme.Islemler.Sil(Yedekler.SelectedItem as Yedekleme.Yedek);
            Yenile();
        }

        private void yedekle_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Filter = "Veritabanı Yedeği (.dbback)|*.dbback";
            
            if (kaydet.ShowDialog() == true)
            {
                Yedekleme.Islemler.Yedekle("Yedek "+DateTime.Now.Date.ToShortDateString(),kaydet.FileName);
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

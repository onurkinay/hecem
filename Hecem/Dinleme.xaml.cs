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
    /// Interaction logic for Dinleme.xaml
    /// </summary>
    public partial class Dinleme : Page
    {
        Islemler islemler = new Islemler();int i = 1;int k = 0;
        public Dinleme(int konu)
        {
            InitializeComponent();
            DinlemeCek(i);
            k = konu;
        }

        private void btnSonraki_Click(object sender, RoutedEventArgs e)
        {
            i++;
            DinlemeCek(i);

        }

        private void btnOnceki_Click(object sender, RoutedEventArgs e)
        {
            i--;
            DinlemeCek(i);
        }

        private void btnOynat_Click(object sender, RoutedEventArgs e)
        {
            islemler.Oynat(label.Text);
        }

        private void DinlemeCek(int sira)
        {
            string[] sonuc = islemler.Getir(0, i);
            label.Text = sonuc[1];
          //  image.Source = new BitmapImage(new Uri(sonuc[2]));
        }
    }
}

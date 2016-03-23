using System.Windows;
using System.Windows.Controls;

namespace Hecem
{
    /// <summary>
    /// Interaction logic for Secim.xaml
    /// </summary>
    public partial class Secim : Page
    {
        int k; 
        public Secim(int konu)
        {
            InitializeComponent();
            k = konu;
            btnGenel.Visibility = (k == 0) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void btnSecim_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int secim = (btn.Name == "btnHarfler") ? 0 : (btn.Name == "btnHeceler") ? 1 : (btn.Name == "btnKelimeler") ? 2 : 3;

            /*  if (secim != 0 && secim != 3) Islemler.PencereAc(new HarfSec(k, secim));

              else {
                  if (k == 0) Islemler.PencereAc(new Dinleme(secim));
                  else Islemler.PencereAc(new Test(secim));
              }*/

            if (k == 0) Islemler.PencereAc(new Dinleme(secim));
            else Islemler.PencereAc(new Test(secim));
        }


    }
}

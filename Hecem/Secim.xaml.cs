using System.Windows;
using System.Windows.Controls;

namespace Hecem
{
    /// <summary>
    /// Interaction logic for Secim.xaml
    /// </summary>
    public partial class Secim : Page
    {
        int k; Anasayfa snf = new Anasayfa();
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

            if (secim != 0 && secim != 3) snf.PencereAc(new HarfSec(k, secim));
            
            else {
                if (k == 0) snf.PencereAc(new Dinleme(secim));
                else snf.PencereAc(new Test(secim));
            }
        }

    
    }
}

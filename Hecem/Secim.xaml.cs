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
    /// Interaction logic for Secim.xaml
    /// </summary>
    public partial class Secim : Page
    {
        int k; Anasayfa snf = new Anasayfa();
        public Secim(int konu)
        {
            InitializeComponent();
            k = konu;
        }

        private void btnSecim_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int secim = (btn.Name == "btnHarfler") ? 0 : (btn.Name == "btnHeceler") ? 1 : 2;

            if (secim != 0) snf.PencereAc(new HarfSec(k, secim));
            
            else {
                if (k == 0) snf.PencereAc(new Dinleme(secim));
                else snf.PencereAc(new Test(secim));
            }
        }
    }
}

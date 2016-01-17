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
        int secim; Anasayfa snf = new Anasayfa();
        public Secim(int konu)
        {
            InitializeComponent();
            secim = konu;
        }

        private void btnHarfler_Click(object sender, RoutedEventArgs e)
        {
           snf.PencereAc(new Dinleme(0));
        }
    }
}

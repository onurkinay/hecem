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
        Islemler islemler = new Islemler();
        public Dinleme(int konu)
        {
            InitializeComponent();
        }

        private void btnSonraki_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sonraki");
        }

        private void btnOnceki_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Önceki");
        }

        private void btnOynat_Click(object sender, RoutedEventArgs e)
        {
            islemler.Oynat("K");
        }
    }
}

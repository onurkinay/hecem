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
using System.IO;
namespace Hecem
{
    /// <summary>
    /// Interaction logic for Dinleme.xaml
    /// </summary>
    public partial class Dinleme : Page
    {
        Islemler islemler = new Islemler();int i = 0;int k = 0;int s = 0;
        public Dinleme(int secim, string harf = "")
        {
            InitializeComponent();
            DinlemeCek(i);
            s = secim;
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
            if (islemler.harfler.Count <= i) i = 0;
            else if (i < 0) i = islemler.harfler.Count-1;
            object[] sonuc = islemler.Getir(0, i);
            
            label.Text = sonuc[1].ToString();
            image.Source = islemler.ResimGetir(sonuc[2]);
            
            
        }
    }
}

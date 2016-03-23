using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace Hecem
{
    /// <summary>
    /// Interaction logic for Dinleme.xaml
    /// </summary>
    public partial class Dinleme : Page
    {
      
        int i = 0;
        List<List<string>> Veri;
        public Dinleme(int secim, string harf = "")
        {
            InitializeComponent();
            Veri = Islemler.VeriGetir((secim == 0) ? "harfler" : (secim == 1) ? "heceler" : "kelimeler");
            if(secim != 0) Veri = Veri.Where(x => x[1][0] == harf[0].ToString().ToLower()[0] ).ToList();
           
            DinlemeCek(i);
            
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
            Islemler.Oynat(label.Text.ToLower());
        }

        private void DinlemeCek(int sira)
        {
            if (Veri.Count <= i) i = 0;
            else if (i < 0) i = Veri.Count-1;
            
            label.Text = Veri[i][1].ToString();

            image.Source = Islemler.ResimGetir(Veri[i][1]);
            
        }
    }
}

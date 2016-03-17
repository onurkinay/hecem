using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
namespace Hecem
{
    /// <summary>
    /// Interaction logic for HarfSec.xaml
    /// </summary>
    public partial class HarfSec : Page
    {
        Islemler islemler = new Islemler(); int k; int s;
        Anasayfa snf = new Anasayfa();
        List<List<string>> Veri;
        public HarfSec(int konu, int secim)
        {
            InitializeComponent();
            HarfYukle();
            k = konu;
            s = secim;
           
        }
        private void HarfYukle()
        {
            Veri = Islemler.VeriGetir("harfler");
            foreach (var item in Veri)
            {
                if (item[1].ToLower() != "ğ")
                {
                    Button harf = new Button();

                    harf.Margin = new Thickness(5);

                    harf.Style = this.FindResource("NoChromeButton") as Style;
                    harf.Click += Harf_Click;
                    harf.Tag = item[1];

                    harf.Content = new Image
                    {
                        Source = islemler.ResimGetir(item[1])
                    };
                    harfler.Children.Add(harf);
                }
            }
        }
        private void Harf_Click(object sender, RoutedEventArgs e)
        {
            Button snd = sender as Button;
            if (k == 0) snf.PencereAc(new Dinleme(s, snd.Tag.ToString()));
            else snf.PencereAc(new Test(s, snd.Tag.ToString()));
        }
    }
}

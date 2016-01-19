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
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        int puan = 0; int secim; int onceki = -1;
        Islemler islemler = new Islemler();
        List<List<string>> Veri;
        public Test(int s, string harf = "")
        {
            InitializeComponent();
            secim = s;
            Veri = Islemler.VeriGetir((secim == 0) ? "harfler" : (secim == 1) ? "heceler" : "kelimeler");
            TestSorusuOlustur();
        }
        int kac = 1;
        private void TestSorusuOlustur()
        {
            if (kac < 21)
            {
                foreach (Grid grid in main2.Children) grid.Visibility = Visibility.Collapsed;
                Random rnd = new Random();
                int testKod = -1;

                do testKod = rnd.Next(0, 3);
                while (onceki == testKod);

                switch (testKod)
                {
                    case 0: CoktanSecmeli(); break;
                    case 1: KlavyeYazma(); break;
                    case 2: DogruYanlis(); break;
                        //    case 3: SurukleBirak(); break;
                }

                onceki = testKod;
                kac++;
            }
            else MessageBox.Show(puan.ToString());
        }

        private void CoktanSecmeli()
        {

            coktanSecmeli.Visibility = Visibility.Visible;
            secenekler.Children.Clear();
            int[] oncekiS = new int[4];
            bool cevapVar = false;
            for (int i = 0; i < 4; i++)
            {
                Random rnd = new Random();
                int sira = rnd.Next(1, Veri.Count);

                do sira = rnd.Next(1, Veri.Count);
                while (oncekiS.Contains(sira));
                oncekiS[i] = sira;

                Button secenek = new Button();
                secenek.Click += SecenekSec;
                secenek.Tag = Veri[sira][1];
                secenek.Margin = new Thickness(5);

                if ((rnd.Next(0, 2) == rnd.Next(0, 2)) && !cevapVar)
                {
                    btnOynatCoktan.Tag = secenek.Tag.ToString();
                    cevapVar = true;
                }

                secenek.Content = new Image
                {
                    Source = islemler.ResimGetir(Veri[sira][1])
                };
                secenekler.Children.Add(secenek);
            }
        }

        private void KlavyeYazma()
        {
            klavyeli.Visibility = Visibility.Visible;
            klavye.Clear();

            Random rnd = new Random();
            int sira = rnd.Next(1, Veri.Count);

            btnOynatKlavyeli.Tag = Veri[sira][1];

        }

        private void DogruYanlis()
        {
            dogruYanlis.Visibility = Visibility.Visible;
            

            Random rnd = new Random();
            bool sonuc = Convert.ToBoolean(rnd.Next(0, 2));
            int soru = rnd.Next(1, Veri.Count); int yanlis = -1;

            if (sonuc) soru = rnd.Next(1, Veri.Count);
            else yanlis = rnd.Next(1, Veri.Count);

            dogruResim.Source = islemler.ResimGetir(Veri[soru][1]);
            dogruResim.Tag = Veri[soru][1];
            btnOynat3.Tag = Veri[(yanlis == -1) ? soru : yanlis][1];
        }

        private void SurukleBirak()
        {
            surukleBirak.Visibility = Visibility.Visible;

        }

        private void btnOynat_Click(object sender, RoutedEventArgs e)
        {
            islemler.Oynat(((Button)sender).Tag.ToString());
        }

        public void SecenekSec(object sender, RoutedEventArgs e)
        {
            if (btnOynatCoktan.Tag.ToString() == ((Button)sender).Tag.ToString()) { MessageBox.Show("Doğru"); puan++;  }
            else MessageBox.Show("Yanlış");
            TestSorusuOlustur();
        }

        public void KlavyeCevap(object sender, RoutedEventArgs e)
        {
            if (klavye.Text == btnOynatKlavyeli.Tag.ToString()) { MessageBox.Show("Doğru"); puan++; }
            else MessageBox.Show("Yanlış");
            TestSorusuOlustur();
        }

        public void DYCevapla(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "yanlis":
                    if (dogruResim.Tag.ToString() != btnOynat3.Tag.ToString())
                    {
                        MessageBox.Show("Bildiniz");puan++;
                    }
                    else MessageBox.Show("Bilemediniz"); break;
                case "dogru":
                    if (dogruResim.Tag.ToString() == btnOynat3.Tag.ToString())
                    {
                        MessageBox.Show("Bildiniz"); puan++;
                    }
                    else MessageBox.Show("Bilemediniz"); break;
            }
            TestSorusuOlustur();
        }
    }
}

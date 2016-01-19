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
        int puan = 0; int konu; int onceki = -1; 
        Islemler islemler = new Islemler();
        public Test(int k, string harf = "")
        {
            InitializeComponent();
            konu = k;
            
            TestSorusuOlustur();
        }

        private void TestSorusuOlustur()
        {
            foreach (Grid grid in main2.Children) grid.Visibility = Visibility.Collapsed;
            Random rnd = new Random();
            int testKod = -1;

            do testKod = rnd.Next(0, 4);
            while (onceki == testKod);

            /*   switch (testKod)
               {
                   case 0: CoktanSecmeli(); break;
                   case 1: KlavyeYazma(); break;
                   case 2: DogruYanlis(); break;
                   case 3: SurukleBirak(); break;
               }*/
            KlavyeYazma();
            onceki = testKod;
        }

        private void CoktanSecmeli() {

            coktanSecmeli.Visibility = Visibility.Visible;

            islemler.HarfleriGetir();
            var harfler = islemler.harfler;
            int[] oncekiS = new int[4];
            bool cevapVar = false;
            for (int i = 0; i < 4; i++)
            {
                Random rnd = new Random();
                int sira = rnd.Next(1, harfler.Count);

                do sira = rnd.Next(1, harfler.Count);
                while (oncekiS.Contains(sira));
                oncekiS[i] = sira;

                Button secenek = new Button();
                secenek.Click += SecenekSec;
                secenek.Tag = harfler[sira][1];
                secenek.Margin = new Thickness(5);

                if((rnd.Next(0, 2) == rnd.Next(0, 2)) && !cevapVar)
                {
                    btnOynatCoktan.Tag = secenek.Tag.ToString();
                    cevapVar = true;
                }
                
                secenek.Content = new Image
                {
                    Source = islemler.ResimGetir(HarflerResim.ResourceManager.GetObject(harfler[sira][1]))
                };
                secenekler.Children.Add(secenek);
            }
        }

        private void KlavyeYazma()
        {
            klavyeli.Visibility = Visibility.Visible;
            
            islemler.HarfleriGetir();
            var harfler = islemler.harfler;

            Random rnd = new Random();
            int sira = rnd.Next(1, harfler.Count);

            btnOynatKlavyeli.Tag = harfler[sira][1];

        }

        private void DogruYanlis()
        {
            dogruYanlis.Visibility = Visibility.Visible;
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
            if (btnOynatCoktan.Tag.ToString() == ((Button)sender).Tag.ToString()) MessageBox.Show("Doğru");
            else MessageBox.Show("Yanlış");
        }

        public void KlavyeCevap(object sender, RoutedEventArgs e)
        {
            if (klavye.Text == btnOynatKlavyeli.Tag.ToString()) MessageBox.Show("Doğru");
            else MessageBox.Show("Yanlış");
        }
    }

}

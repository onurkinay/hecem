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
using System.Reflection;
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
        Random rnd = new Random();
        public Test(int s, string harf = "")
        {
            InitializeComponent();
            secim = s;
            Veri = Islemler.VeriGetir((secim == 0) ? "harfler" : (secim == 1) ? "heceler" : "kelimeler");
            if (secim != 0) Veri = Veri.Where(x => x[1][0] == harf[0].ToString().ToLower()[0]).ToList();
            TestSorusuOlustur();
        }
        int kac = 1;
        private void TestSorusuOlustur()
        {
            if (kac < 21)
            {
                foreach (Grid grid in main2.Children) grid.Visibility = Visibility.Collapsed;

                int testKod = -1;

                do testKod = rnd.Next(0, 4);
                while (onceki == testKod);

                switch (testKod)
                {
                    case 0: CoktanSecmeli(); break;
                    case 1: KlavyeYazma(); break;
                    case 2: DogruYanlis(); break;
                    case 3: Eslestir(); break;
                }

                onceki = testKod;
                kac++;
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).baslik.Text = "Puan: " + puan.ToString();
                    }
                }
            }
            else {
                MessageBox.Show(puan.ToString());
                Islemler.PuanEkle(App.ka, puan);
            }
        }
#region Soru oluşturma fonksiyonları
        private void CoktanSecmeli()
        {

            coktanSecmeli.Visibility = Visibility.Visible;
            secenekler.Children.Clear();
            int[] oncekiS = new int[4];
            bool cevapVar = false;
            for (int i = 0; i < 4; i++)
            {
                
                int sira = rnd.Next(0, Veri.Count);

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

            
            int sira = rnd.Next(0, Veri.Count);

            btnOynatKlavyeli.Tag = Veri[sira][1];

        }

        private void DogruYanlis()
        {
            dogruYanlis.Visibility = Visibility.Visible;
            

            
            bool sonuc = Convert.ToBoolean(rnd.Next(0, 2));
            int soru = rnd.Next(0, Veri.Count); int yanlis = -1;

            if (sonuc) soru = rnd.Next(0, Veri.Count);
            else yanlis = rnd.Next(0, Veri.Count);

            dogruResim.Source = islemler.ResimGetir(Veri[soru][ (Veri[soru][1].Length == 1) ? 1 : 2 ]);
            dogruResim.Tag = Veri[soru][1];
            btnOynat3.Tag = Veri[(yanlis == -1) ? soru : yanlis][1];
        }

        private void Eslestir()
        {
            surukleBirak.Visibility = Visibility.Visible;
            cevapCizgileri.Children.Clear();
            sol.Children.Clear();
            sag.Children.Clear();
            int[] cevaplar = new int[4];

            for (int i = 0; i < 4; i++)
            {
                int sira;

                do sira = rnd.Next(1, Veri.Count);
                while (cevaplar.Contains(sira));

                cevaplar[i] = sira;
            }
          

            for (int i = 0; i < 8; i++)
            {
                if (i == 4) cevaplar = cevaplar.OrderBy(x => rnd.Next()).ToArray();
                Button sec = new Button();
                Grid grid = (i < 4) ? sol : sag;

                Grid.SetColumn(sec, (i < 4) ? 0 : 1);
                Grid.SetRow(sec, (i < 4) ? i : (i-4));

                sec.Margin = new Thickness(10);

                if (i < 4) { sec.Content = Veri[cevaplar[i]][1]; sec.FontSize = 24; sec.Click += SolC; sec.Tag = cevaplar[i]; }
                else {
                    sec.Content = new Image() { Source = islemler.ResimGetir(Veri[cevaplar[i - 4]][(Veri[cevaplar[i - 4]][1].Length == 1) ? 1 : 2]) };
                    sec.Click += SagC;
                    sec.Tag = cevaplar[i-4];
                }

                grid.Children.Add(sec);
            }

        }
        #endregion
#region Cevaplama Fonksiyonları
        public void SecenekSec(object sender, RoutedEventArgs e)
        {
            if (btnOynatCoktan.Tag.ToString() == ((Button)sender).Tag.ToString())  puan++;  
        
            TestSorusuOlustur();
        }

        public void KlavyeCevap(object sender, RoutedEventArgs e)
        {
            if (klavye.Text == btnOynatKlavyeli.Tag.ToString()) puan++; 
            TestSorusuOlustur();
        }

        public void DYCevapla(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "yanlis":
                    if (dogruResim.Tag.ToString() != btnOynat3.Tag.ToString()) puan++;
                    break;
                case "dogru":
                    if (dogruResim.Tag.ToString() == btnOynat3.Tag.ToString()) puan++;
                    
                     break;
            }
            TestSorusuOlustur();
        }
      

        int[,] cevaplari = new int[4,2]; int c = 0;
        public void CizgiCek(Button sol, Button sag)
        {
            for (int i = 0; i < 4; i++)
            {
                if (cevaplari[i, 0] != 0 && cevaplari[i, 1] != 0)
                
                    if (cevaplari[i, 0] == Convert.ToInt32(sol.Tag.ToString()) || cevaplari[i, 1] == Convert.ToInt32(sag.Tag.ToString()))
                    
                        return;
                    
            }
            cevaplari[c ,0] = Convert.ToInt32(sol.Tag.ToString());
            cevaplari[c, 1] = Convert.ToInt32(sag.Tag.ToString());

            Line line = new Line();
            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 4;
            line.Stroke = PickBrush();
            line.Tag = c.ToString();
            Point solPoint = sol.TransformToAncestor(this)
                          .Transform(new Point(0, 0));

            Point sagPoint = sag.TransformToAncestor(this)
                         .Transform(new Point(0, 0));

            line.X1 = solPoint.X + 100;
            line.Y1 = solPoint.Y + 50;

            line.X2 = sagPoint.X;
            line.Y2 = sagPoint.Y + 50;
            
            cevapCizgileri.Children.Add(line);

            c++;
            if(c == 4)
            {
                int sonuc = 0;
                for (int i = 0; i < 4; i++) if (cevaplari[i, 0] == cevaplari[i, 1]) sonuc++;
                puan += sonuc;
                cevaplari = new int[4, 2];
                c = 0;
                TestSorusuOlustur();
            }

        }
        Button solC;
        public void SolC(object sender, RoutedEventArgs e)
        {
            solC = sender as Button;
        }
        public void SagC(object sender, RoutedEventArgs e)
        {
            CizgiCek(solC, sender as Button);
        }
        #endregion

        private void btnOynat_Click(object sender, RoutedEventArgs e)
        {
           islemler.Oynat(((Button)sender).Tag.ToString());
        }
        int pb = 0;
        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;
            
            Brush[] renkler = new Brush[] { Brushes.Black, Brushes.Blue, Brushes.Red, Brushes.Green };
            if (pb == renkler.Length) pb = 0;
            result = renkler[pb];
            pb++;
           
            return result;
        }
    }
}

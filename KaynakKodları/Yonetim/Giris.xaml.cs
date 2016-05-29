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
using System.Windows.Shapes;
using System.Windows.Threading;
namespace Yonetim
{
    /// <summary>
    /// Interaction logic for Giris.xaml
    /// </summary>
    public partial class Giris : Window
    {
        public Giris()
        {
            InitializeComponent();
            
        }

        private void giris_Click(object sender, RoutedEventArgs e)
        {
            GirisYap(ka.Text, sifre.Password);

        }

        private void ka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) GirisYap(ka.Text, sifre.Password);  
        }

        private void GirisYap(string kadi, string sif)
        {
            durum.Text = "";

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Start();
            timer.Tick += (ss, args) =>
            {
                timer.Stop();
                bool dogrula = Islemler.KullaniciDogrula(kadi, sif);
                if (dogrula)
                {

                    App.ka = kadi;
                    App.sifre = sif;
                    this.Hide();
                    MainWindow mw = new MainWindow();
                    mw.Show();

                }
                else durum.Text = "Hatalı giriş! Tekrar deneyin!";
            };
        }
    }
}

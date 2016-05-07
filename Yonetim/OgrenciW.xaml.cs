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

namespace Yonetim
{
    /// <summary>
    /// Interaction logic for OgrenciW.xaml
    /// </summary>
    public partial class OgrenciW : Window
    {
        int islemTuru = 0;
        Ogrenci ogrenci;
        string kullaniciAdi;
        public OgrenciW(Ogrenci ogr)
        { 
            InitializeComponent();
             
            if (ogr.id == -1)
            {
                islemTuru = 1;
                puanTextB.Visibility = Visibility.Collapsed;
                puanTextT.Visibility = Visibility.Collapsed;
               // ekleResim.Source = new Uri();
            }
            else
            {
                kullaniciAdi = ogr.kullaniciAdi;
                ka.Text = ogr.kullaniciAdi;
                puan.Text = ogr.puan;
                sifre.Password = ogr.sifre;
                adsoyad.Text = ogr.adsoyad;
                ogrenci = ogr;
            }

        }

        private void ekle_Click(object sender, RoutedEventArgs e)
        {
            string[] AdSoyad = Islemler.AdSoyadAyir(adsoyad.Text);

            if (islemTuru == 1)
            {
                Ogrenci ogr = new Ogrenci(-1, ka.Text, sifre.Password, AdSoyad[0], AdSoyad[1]);
                MessageBox.Show(Islemler.OgrenciEkle(ogr) ? "Öğrenci Eklendi" : "Hata oluştu. Öğrenci eklenemedi");
            }
            else
            {
                ogrenci.adsoyad = adsoyad.Text;
                ogrenci.kullaniciAdi = ka.Text;
                ogrenci.sifre = sifre.Password;

                MessageBox.Show(Islemler.OgrenciDuzenle(ogrenci, kullaniciAdi) ? "Öğrenci düzenlendi" : "Öğrenci düzenlenemedi");
            }
        }
    }
}

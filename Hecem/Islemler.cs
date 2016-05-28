using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
namespace Hecem
{
    public class Islemler
    {
        static OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hecem.accdb;Jet OLEDB:Database Password=HecemKVeri");
        

        public static List<List<string>> VeriGetir(string tablo)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from " + tablo + " ORDER BY veri", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<List<string>> Veri = new List<List<string>>();
            while (dr.Read())
            {
                List<string> veri = new List<string>();
                for (int i = 0; i < dr.FieldCount; i++) veri.Add(dr[i].ToString());
                Veri.Add(veri);
            }
            return Veri;
        }

        public static bool KullaniciVarmi(string ad, string sifre)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from kullanicilar where ka='"+ad+"' AND sifre='"+sifre+"'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<List<string>> Veri = new List<List<string>>();
            while (dr.Read())
            {
                return true;
            }
            return false;
        }

        public static List<string> KullaniciCek(string ad)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from kullanicilar where ka='" + ad + "'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<string> Veri = new List<string>();
            while (dr.Read()) for (int i = 0; i < dr.FieldCount; i++) Veri.Add(dr[i].ToString());
            return Veri;
            
        }

        public static void PuanEkle(string ad, int puan)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from kullanicilar where ka='" + ad + "'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                
                OleDbCommand puanEkle = new OleDbCommand("Update kullanicilar set puan=" + (puan + Convert.ToInt16(dr[5].ToString())).ToString() + " where ka='" + ad + "'" , con);
               
                puanEkle.ExecuteNonQuery();
                
               
            }
            con.Close();
        }

        public static void Oynat(string gelen)
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri("Resources/ses/" + gelen.ToLower() + ".mp3", UriKind.RelativeOrAbsolute));

            player.Play();

        }

        public static System.Windows.Media.Imaging.BitmapImage ResimGetir(string resim)
        {

            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(directory, "Resources\\resim\\"+  resim + ".png");
            bool varmi = File.Exists(filePath);
            System.Drawing.Bitmap dImg;
            // 
            dImg = new System.Drawing.Bitmap((!varmi) ? "Resources/gg.jpg" : "Resources/resim/" + resim + ".png");

            MemoryStream ms = new MemoryStream();
            dImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(ms.ToArray());
            bImg.EndInit();

            return bImg;
        }

        public static void Yenile()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).baslik.Text = "Hecem";
                    (window as MainWindow).Yenile();
                }
            }
        }

        public static void BaslikDegistir(string baslik)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).baslik.Text = baslik;
                }
            }
        }

        public static void PencereAc(Page page)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow)._Sayfa.Navigate(page);
                }
            }
        }


    }
}

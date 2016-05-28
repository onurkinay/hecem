using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Yonetim
{
    public class Islemler
    {
        public static OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hecem.accdb;Jet OLEDB:Database Password=HecemKVeri");
        public static List<Ogrenci> ogrenciler;
        public static bool KullaniciDogrula(string ka, string sifre)
        {
            string kadi = Properties.Settings.Default.kadi;
            string sif = Properties.Settings.Default.sif;

            if (sifre == sif && ka == kadi) return true;
            else return false;
        }
           
        public static void OgrencileriCek()
        {
            ogrenciler = new List<Ogrenci>();
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM kullanicilar" , con);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ogrenciler.Add(new Ogrenci(
                    Convert.ToInt16(dr[0].ToString()),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString(),
                    dr[4].ToString(),
                    dr[5].ToString()) );
            }
            
        }

        public static bool OgrenciEkle(Ogrenci ogrenci)
        {
            string[] adSoyad = AdSoyadAyir(ogrenci.adsoyad);
            
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO kullanicilar (ka, sifre, ad, soyad, puan) VALUES ('"+ogrenci.kullaniciAdi+"', '"+ogrenci.sifre+"', '"+adSoyad[0]+"', '"+adSoyad[1]+"', '0')", con);
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            return sonuc == 1;
        }

        public static bool OgrenciSil(Ogrenci ogrenci)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM kullanicilar WHERE id="+ogrenci.id, con);
            int sonuc = cmd.ExecuteNonQuery();
            return sonuc == 1;
        }

        public static bool OgrenciDuzenle(Ogrenci ogrenci, string ka)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            string[] adSoyad = AdSoyadAyir(ogrenci.adsoyad);
            OleDbCommand ogrenciDuzenle = new OleDbCommand("Update kullanicilar set ka='"+ogrenci.kullaniciAdi+"', sifre='"+ogrenci.sifre+"',ad='"+adSoyad[0]+"',soyad='"+adSoyad[1]+"' where ka='" + ka + "'", con);

            int sonuc = ogrenciDuzenle.ExecuteNonQuery();
            con.Close();
            return sonuc == 1;
        }

        public static bool AdminDuzenle(string ka, string sifre)
        {
            return false;
        }
         
        public static string[] AdSoyadAyir(string adsoy)
        {
            string ad = "", soyad = "";
            string[] adSoyad; //Dizimizi Tanımlıyoruz 
            adSoyad = adsoy.Split(' '); //Boşluklara göre ayırdığımız ad ve soyadını diziye aktarıyoruz.  
            if (adSoyad.Length != 1)
            {
                for (int i = 0; i < adSoyad.Length; i++)
                {
                    if (i != adSoyad.Length - 1)
                    {
                        ad += adSoyad[i]; // Diziye aktardığımız ad değerlerini Labelimize yazdırıyoruz. 
                    }
                    else
                    {
                        soyad += adSoyad[i]; // Diziye aktardığımız Soyadı değerini Labelimize yazdırıyoruz. 
                    }
                }
            }
            else ad = adSoyad[0];
            return new string[] { ad, soyad };
        }
       
    }

   

    public class Ogrenci
    {
        public int id { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public string adsoyad { get; set; }
        public string puan { get; set; }

        public Ogrenci(int ID=-1 ,string ka="", string sif="", string Ad="", string syd="", string pn="")
        {
            id = ID;
            kullaniciAdi = ka;
            sifre = sif;
            adsoyad = Ad + " "+syd; 
            puan = pn;
        }
    }
   
}

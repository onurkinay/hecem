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
        static OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hecem.accdb");
        public static List<Ogrenci> ogrenciler;
        public static bool KullaniciDogrula(string ka, string sifre)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from yetkililer where ka='" + ka + "' AND sifre='" + sifre + "'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
             
            while (dr.Read())
            {
                return true;
            }
            return false;
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
            cmd.ExecuteNonQuery();
            return true;
        }

        public static bool OgrenciSil(Ogrenci ogrenci)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM kullanicilar WHERE id="+ogrenci.id, con);
            cmd.ExecuteNonQuery();
            return false;
        }

        public static string[] AdSoyadAyir(string adsoy)
        {
            string ad = "", soyad = "";
            string[] adSoyad; //Dizimizi Tanımlıyoruz 
            adSoyad = adsoy.Split(' '); //Boşluklara göre ayırdığımız ad ve soyadını diziye aktarıyoruz. 
            for (int i = 0; i < adSoyad.Length; i++)
            {
                if (i != adSoyad.Length - 1)
                {
                    ad += adSoyad[i] + " "; // Diziye aktardığımız ad değerlerini Labelimize yazdırıyoruz. 
                }
                else
                {
                    soyad += adSoyad[i]; // Diziye aktardığımız Soyadı değerini Labelimize yazdırıyoruz. 
                }
            }
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

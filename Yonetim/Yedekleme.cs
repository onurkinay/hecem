using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
using System.Reflection;

namespace Yedekleme
{
    public class Islemler//Veritabanı yedekleme sınıfı
    {

        public static void Yedekle(string ad, string yol)
        {
            Yedek yedek = new Yedek();

            yedek.adi = ad;
            yedek.tarih = DateTime.Now.Date.ToString();
            yedek.yol = yol;

            File.Copy(@"hecem.accdb", yol);

            Yonet.YedekEkle(yedek);
        }

        public static bool GeriYukle(Yedek yedek)
        {
            if (File.Exists(yedek.yol))
            {
                Yonetim.Islemler.con.Close();
                Yonetim.Islemler.con = new System.Data.OleDb.OleDbConnection();
                File.Delete(@"hecem.accdb");
                File.Copy(yedek.yol, @"hecem.accdb");
                Yonetim.Islemler.con = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hecem.accdb");
            }
            else return false;
            
            return true;
        }

        public static bool Sil(Yedek yedek)
        {
            Yonet.YedekSil(yedek);
            return true;

        }

        public static List<Yedek> Listele()
        {
            return new List<Yedek>();
        }
    }

    public class Yonet
    {
        public static string Getir()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"yedek.json");
            using (StreamReader r = new StreamReader(path))
            {
                return r.ReadToEnd();
            }

        }

        public static bool YedekEkle(Yedek yedek)
        {
            DateTime h_Tarih = DateTime.Now;
            RootObject yedekler = JsonConvert.DeserializeObject<RootObject>(Getir());

            yedekler.yedekler.yedek.Add(yedek);

            JsonKaydet(JsonConvert.SerializeObject(yedekler));
            return true;

        }

        public static bool YedekSil(Yedek yedek)
        {
            RootObject yedekler = JsonConvert.DeserializeObject<RootObject>(Getir());
            int index = yedekler.yedekler.yedek.IndexOf(yedek,0);
            yedekler.yedekler.yedek.RemoveAt(index);
            File.Delete(yedek.yol);
            JsonKaydet(JsonConvert.SerializeObject(yedekler));
            return true;

        }

        public static List<Yedek> YedekleriCek()
        {
            RootObject yedekler = JsonConvert.DeserializeObject<RootObject>(Getir());
            return yedekler.yedekler.yedek.ToList<Yedek>();
        }

        public static bool JsonKaydet(string Json)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"yedek.json");

            using (StreamWriter r = new StreamWriter(path))
            {
                r.Write(Json);
                return true;

            }

        }
    }

    public class Yedek
    {
        public string adi { get; set; }
        public string tarih { get; set; }
        public string yol { get; set; }
    }

    public class Yedekler
    {
        public List<Yedek> yedek { get; set; }
    }

    public class RootObject
    {
        public Yedekler yedekler { get; set; }
    }

}

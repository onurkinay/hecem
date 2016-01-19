using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Data.OleDb;
using System.IO;
namespace Hecem
{
   public class Islemler
    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hecem.accdb");
        public List<List<string>> harfler = new List<List<string>>();
        public void Oynat(string gelen)
        {
            if (gelen.Length == 1) {

                SoundPlayer ses = new SoundPlayer(Harfler.ResourceManager.GetStream(gelen.ToLower()));
                ses.Play();
            }
          
        }

        public void HarfleriGetir()
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from harfler", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                List<string> veri = new List<string>();
                for (int i = 0; i < 3; i++) veri.Add(dr[i].ToString());
                harfler.Add(veri);
            }
             
        }

        public object[] Getir(int konu, int sira)
        {
            if (harfler.Count == 0) HarfleriGetir();
            return new object[3] { harfler[sira][0], harfler[sira][1] , HarflerResim.ResourceManager.GetObject(harfler[sira][1]) };
        }

        public System.Windows.Media.Imaging.BitmapImage ResimGetir(object resimObje)
        {
            System.Drawing.Bitmap dImg = new System.Drawing.Bitmap((System.Drawing.Image)resimObje);
            MemoryStream ms = new MemoryStream();
            dImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(ms.ToArray());
            bImg.EndInit();
            return bImg;
        }
    }
}

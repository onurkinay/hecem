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
        static OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hecem.accdb");
        public static List<List<string>> VeriGetir(string tablo)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from " + tablo, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            List<List<string>> Veri = new List<List<string>>();
            while (dr.Read())
            {
                List<string> veri = new List<string>();
                for (int i = 0; i < 3; i++) veri.Add(dr[i].ToString());
                Veri.Add(veri);
            }
            return Veri;
        }

        public void Oynat(string gelen)
        {
            if (gelen.Length == 1)
            {

                SoundPlayer ses = new SoundPlayer(Harfler.ResourceManager.GetStream(gelen.ToLower()));
                ses.Play();
            }

        }
        public System.Windows.Media.Imaging.BitmapImage ResimGetir(string resim)
        {
            System.Drawing.Bitmap dImg;
            if (resim.Length == 1) dImg = new System.Drawing.Bitmap((System.Drawing.Image)HarflerResim.ResourceManager.GetObject(resim));
            else dImg = new System.Drawing.Bitmap(System.Windows.Application.GetResourceStream(new Uri(resim, UriKind.RelativeOrAbsolute)).Stream);
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

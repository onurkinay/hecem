using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Data.OleDb;

namespace Hecem
{
   public class Islemler
    {

        OleDbConnection con;
        public void Oynat(string gelen)
        {
            if (gelen.Length == 1) {

                SoundPlayer ses = new SoundPlayer(Harfler.ResourceManager.GetStream(gelen.ToLower()));
                ses.Play();
            }
          
        }
        public void Baglan()
        {
           con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hecem.accdb"); con.Open();
        }

        public string[] Getir(int konu, int sira)
        {
            Baglan();
            string tablo = (konu == 0) ? "harfler" : (konu==1)? "heceler":"kelimeler";
            OleDbCommand cmd = new OleDbCommand("Select * from "+tablo+" where id="+sira, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            string[] sonuc = new string[3];
            while (dr.Read())
            {
                for (int i = 0; i < 3; i++) sonuc[i] = dr[i].ToString();
            }
            con.Close();
            return sonuc;
        }
    }
}

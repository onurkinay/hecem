using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;

namespace ResimBot
{
   public class Kaynak
    {
        public static RootObject kaynak;
        static string harf = "";
        public static void KaynakCek(string gelen)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://pixabay.com/api/?key=2103522-6e90eafd4fcc76310fb437ab4&q="+gelen+"&image_type=photo&pretty=true&lang=tr&safesearch=true");

                kaynak = JsonConvert.DeserializeObject<RootObject>(json);
               
                harf = gelen;
            }
        }

        public static Image ResimCek(ref int sira)
        {
            if (sira >= kaynak.hits.Count) sira = 0;
            
                var request = WebRequest.Create(kaynak.hits[sira].previewURL);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    return Bitmap.FromStream(stream);
                }
            
        }

        public static void ResmiKaydet(int sira)
        {
            var request = WebRequest.Create(kaynak.hits[sira].webformatURL);


            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                Image resim = Bitmap.FromStream(stream);

                resim.Save("resim/" + harf + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

    }


    public class Hit
    {
        public int previewHeight { get; set; }
        public int likes { get; set; }
        public int favorites { get; set; }
        public string tags { get; set; }
        public int webformatHeight { get; set; }
        public int views { get; set; }
        public int webformatWidth { get; set; }
        public int previewWidth { get; set; }
        public int comments { get; set; }
        public int downloads { get; set; }
        public string pageURL { get; set; }
        public string previewURL { get; set; }
        public string webformatURL { get; set; }
        public int imageWidth { get; set; }
        public int user_id { get; set; }
        public string user { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public string userImageURL { get; set; }
        public int imageHeight { get; set; }
    }

    public class RootObject
    {
        public int totalHits { get; set; }
        public List<Hit> hits { get; set; }
        public int total { get; set; }
    }

}

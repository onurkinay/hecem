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
       
        static string harf = "";
        public static void KaynakCek(string gelen)
        {
           
        }

        /*public static Image ResimCek(ref int sira)
        {
            if (sira >= kaynak.hits.Count) sira = 0;
            
                var request = WebRequest.Create(kaynak.hits[sira].previewURL);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    return Bitmap.FromStream(stream);
                }
            
        }*/

     /*   public static void ResmiKaydet(int sira)
        {
            var request = WebRequest.Create(kaynak.[sira].webformatURL);


            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                Image resim = Bitmap.FromStream(stream);

                resim.Save("resim/" + harf + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }*/

    }


    
}

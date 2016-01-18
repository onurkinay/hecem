using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Hecem
{
   public class Islemler
    {
        

        public void Oynat(string gelen)
        {
            if (gelen.Length == 1) {

                SoundPlayer ses = new SoundPlayer(Harfler.ResourceManager.GetStream(gelen.ToLower()));
                ses.Play();
            }
          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace Hecem
{
    /// <summary>
    /// Interaction logic for Dinleme.xaml
    /// </summary>
    public partial class Dinleme : Page
    {
        Islemler islemler = new Islemler();int i = 0;int k = 0;
        public Dinleme(int konu)
        {
            InitializeComponent();
            DinlemeCek(i);
            k = konu;
        }

        private void btnSonraki_Click(object sender, RoutedEventArgs e)
        {
            i++;
            DinlemeCek(i);

        }

        private void btnOnceki_Click(object sender, RoutedEventArgs e)
        {
            i--;
            DinlemeCek(i);
        }

        private void btnOynat_Click(object sender, RoutedEventArgs e)
        {
            islemler.Oynat(label.Text);
        }

        private void DinlemeCek(int sira)
        {
            if (islemler.harfler.Count <= i) i = 0;
            else if (i < 0) i = islemler.harfler.Count-1;
            object[] sonuc = islemler.Getir(0, i);
            
            label.Text = sonuc[1].ToString();

             
            System.Drawing.Bitmap dImg = new System.Drawing.Bitmap((System.Drawing.Image)sonuc[2]);
            MemoryStream ms = new MemoryStream();
            dImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(ms.ToArray());
            bImg.EndInit();
            //img is an Image control.
            image.Source = bImg;
            
            
        }
    }
}

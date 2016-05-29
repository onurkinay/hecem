using System.Windows;
using System.Windows.Controls;

namespace Hecem
{
    /// <summary>
    /// Interaction logic for Anasayfa.xaml
    /// </summary>
    public partial class Anasayfa : Page
    {
        
        public Anasayfa()
        {
            InitializeComponent();
          
        }

        private void btnDinleme_Click(object sender, RoutedEventArgs e)
        {
            Islemler.PencereAc(new Secim(0));
        }
        
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Islemler.PencereAc(new Secim(1));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

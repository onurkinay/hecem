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
            PencereAc(new Secim(0));
        }

        public void PencereAc(Page page)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow)._Sayfa.Navigate(page);
                }
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            PencereAc(new Secim(1));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

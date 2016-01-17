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
    }
}

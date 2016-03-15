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
    /// Interaction logic for TestSonuclari.xaml
    /// </summary>
    public partial class TestSonuclari : Page
    {
        public TestSonuclari(TestSonuclar testSonuclari)
        {
            InitializeComponent();
             
            puan.Text = testSonuclari.puan.ToString();
            dogru.Text = testSonuclari.cevaplar.Where(x => (x == true)).Count().ToString();
            yanlis.Text = testSonuclari.cevaplar.Where(x => (x == false)).Count().ToString();
        }
    }
}

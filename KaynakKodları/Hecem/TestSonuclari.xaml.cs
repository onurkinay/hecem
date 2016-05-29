using System.Linq;
using System.Windows.Controls;

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

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
using System.Windows.Shapes;
using Yonetim.Properties;
namespace Yonetim
{
    /// <summary>
    /// Interaction logic for AdminDegistir.xaml
    /// </summary>
    public partial class AdminDegistir : Window
    {
        public AdminDegistir()
        {
            InitializeComponent();
            ka.Text = Settings.Default.kadi;
            sifre.Password = Settings.Default.sif;
        }

        private void degistir_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.kadi = ka.Text;
            Settings.Default.sif = sifre.Password;
            Settings.Default.Save();
            MessageBox.Show("Giriş bilgileri değiştirildi", "Bilgi!",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}

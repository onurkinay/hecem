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

namespace Hecem
{
    /// <summary>
    /// Interaction logic for Giris.xaml
    /// </summary>
    public partial class Giris : Window
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void dogru_Click(object sender, RoutedEventArgs e)
        {
            Dogrula();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (App.ka == "") Application.Current.Shutdown();
        }

        private void sifre_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Dogrula();
            }
        }

        private void Dogrula(int i=0) {

            if (Islemler.KullaniciVarmi(ka.Text, sifre.Password))
            {
                App.ka = ka.Text;
                Close();
            }
            else if (i == 1) {

                App.ka = "Anonim";
                Close();

            }
            else MessageBox.Show("Kullanıcı adı ya da şifresi hatalı");
        }

        private void anon_Click_1(object sender, RoutedEventArgs e)
        {
            Dogrula(1);
        }
    }
}

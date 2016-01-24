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

            if (Islemler.KullaniciVarmi(ka.Text, sifre.Password))
            {
                App.ka = ka.Text;
                Close();
            }
            else MessageBox.Show("Kullanıcı adı ya da şifresi hatalı");
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (App.ka == "") Application.Current.Shutdown();
        }
    }
}

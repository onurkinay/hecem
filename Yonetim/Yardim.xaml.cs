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

namespace Yonetim
{
    /// <summary>
    /// Interaction logic for Yardim.xaml
    /// </summary>
    public partial class Yardim : Window
    {
        public Yardim()
        {
            InitializeComponent();
        }

        private void HelponselectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView yrd = sender as TreeView;
            TreeViewItem yardim = yrd.SelectedItem as TreeViewItem;
            frame.Navigate(new System.Uri(yardim.Tag.ToString(), UriKind.RelativeOrAbsolute));
        }
    }
}

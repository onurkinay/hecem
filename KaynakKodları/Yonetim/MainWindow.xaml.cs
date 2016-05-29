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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Yonetim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Yenile();
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Ogrenci ogrenci = ((ListViewItem)sender).Content as Ogrenci;
            OgrenciW ogrYonetim = new OgrenciW(ogrenci);
            ogrYonetim.ShowDialog();
            Yenile();
        }

        private void ekle_Click(object sender, RoutedEventArgs e)
        {
            OgrenciW ogrYonetim = new OgrenciW(new Ogrenci());
            ogrYonetim.ShowDialog();
            Yenile();
        }

        private void sil_Click(object sender, RoutedEventArgs e)
        {
            if (Ogrenciler.SelectedIndex != -1)
            {
                Ogrenci ogrenci = Ogrenciler.SelectedItem as Ogrenci;
                MessageBoxResult result = MessageBox.Show(ogrenci.adsoyad + " öğrenciyi silmek istediğinizden emin misiniz?", "Onayla", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show(Islemler.OgrenciSil(ogrenci) ? "Öğrenciniz silindi" : "Hata! Öğrenci silinemedi");
                }

                Yenile();
            }
            else MessageBox.Show("Öğrenci Seçiniz", "Hata!", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        void Yenile()
        {
            Islemler.OgrencileriCek();
            Ogrenciler.ItemsSource = Islemler.ogrenciler;
        }

        private void dbYedek_Click(object sender, RoutedEventArgs e)
        {
            YedekYonetim yedek = new YedekYonetim();
            yedek.ShowDialog();
        }

        private const uint WS_EX_CONTEXTHELP = 0x00000400;
        private const uint WS_MINIMIZEBOX = 0x00020000;
        private const uint WS_MAXIMIZEBOX = 0x00010000;
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_FRAMECHANGED = 0x0020;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_CONTEXTHELP = 0xF180;


        [DllImport("user32.dll")]
        private static extern uint GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, uint newStyle);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);


        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            uint styles = GetWindowLong(hwnd, GWL_STYLE);
            styles &= 0xFFFFFFFF ^ (WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
            SetWindowLong(hwnd, GWL_STYLE, styles);
            styles = GetWindowLong(hwnd, GWL_EXSTYLE);
            styles |= WS_EX_CONTEXTHELP;
            SetWindowLong(hwnd, GWL_EXSTYLE, styles);
            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
            ((HwndSource)PresentationSource.FromVisual(this)).AddHook(HelpHook);
        }

        private void adminBilgi_Click(object sender, RoutedEventArgs e)
        {
            AdminDegistir bilgi = new AdminDegistir();
            bilgi.ShowDialog();
        }
        private IntPtr HelpHook(IntPtr hwnd,
                int msg,
                IntPtr wParam,
                IntPtr lParam,
                ref bool handled)
        {
            if (msg == WM_SYSCOMMAND &&
                    ((int)wParam & 0xFFF0) == SC_CONTEXTHELP)
            {
                Yardim yrd = new Yardim();
                yrd.ShowDialog();
                handled = true;
            }
            return IntPtr.Zero;
        }

       
    }
}

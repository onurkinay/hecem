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
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        int puan = 0; int konu; int onceki = -1;
        public Test(int k)
        {
            InitializeComponent();
            konu = k;

            
            TestSorusuOlustur();
        }

        private void TestSorusuOlustur()
        {
            foreach (Grid grid in main2.Children) grid.Visibility = Visibility.Collapsed;
            Random rnd = new Random();
            int testKod = -1;

            do testKod = rnd.Next(0, 4);
            while (onceki == testKod); 

            switch (testKod)
            {
                case 0: CoktanSecmeli(); break;
                case 1: KlavyeYazma(); break;
                case 2: DogruYanlis(); break;
                case 3: SurukleBirak(); break;
            }
            onceki = testKod;
        }

        private void CoktanSecmeli() {

            coktanSecmeli.Visibility = Visibility.Visible;
            //
            
        }

        private void KlavyeYazma()
        {
            klavyeli.Visibility = Visibility.Visible;
        }

        private void DogruYanlis()
        {
            dogruYanlis.Visibility = Visibility.Visible;
        }

        private void SurukleBirak()
        {
            surukleBirak.Visibility = Visibility.Visible;

        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Button lblFrom = e.Source as Button;

            if (e.LeftButton == MouseButtonState.Pressed)
                DragDrop.DoDragDrop(lblFrom, lblFrom.Content, DragDropEffects.Copy);
        }

        private void Button_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            Button lblFrom = e.Source as Button;

            if (!e.KeyStates.HasFlag(DragDropKeyStates.LeftMouseButton))
                lblFrom.Content = "...";
        }

        private void Button_Drop(object sender, DragEventArgs e)
        {
            string draggedText = (string)e.Data.GetData(DataFormats.StringFormat);

            Button toLabel = e.Source as Button;
            toLabel.Content = draggedText;
        }
    }
}

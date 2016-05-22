using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
 
namespace Yonetim
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ka = "";
        public static string sifre = "";
        public App()
        {
            if (!File.Exists("hecem.accdb"))
            {
                MessageBoxResult cvp = MessageBox.Show("Veritabanı bulunamadı. En son yedekten geri döndürmek istiyor musunuz?", "Veritabanı Hatası!", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                if (cvp == MessageBoxResult.Yes)
                {
                    if (Yedekleme.Islemler.EnSonYedekGeriGetir()) MessageBox.Show("Yedek geri getirildi!");
                    Giris grs = new Giris();
                    grs.ShowDialog();
                }
            }
        }
        void App_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 0) {

                Giris giris = new Giris();
                giris.ShowDialog();

            }
            else
            {
                Dictionary<string, string> arguments = new Dictionary<string, string>();

                string[] args = Environment.GetCommandLineArgs();

                for (int index = 1; index < args.Length; index += 2)
                {
                    string arg = args[index].Replace("--", "");
                    arguments.Add(arg, args[index + 1]);
                }

                if (Yonetim.Properties.Settings.Default.sif == arguments["sifre"] && Yonetim.Properties.Settings.Default.kadi == arguments["kadi"])
                {
                    App.ka = arguments["kadi"];
                    App.sifre = arguments["sifre"];
                    MainWindow mw = new MainWindow();
                    mw.ShowDialog();
                }
                else Environment.Exit(0);
            }
        }
    }
}

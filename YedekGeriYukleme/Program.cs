using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace YedekGeriYukleme
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                if (args.Length != 3) Console.WriteLine("Geçersiz parametler!!");
                else
                {
                    Console.Title = "Yedek Geri Yükleme Aracı";
                    string yol = args[0];
                    string ka = args[1];
                    string sifre = args[2];

                    Console.WriteLine("Yedek geri yükleniyor..!");
                    System.Threading.Thread.Sleep(2000);

                    File.Delete(@"hecem.accdb");
                    File.Copy(yol, @"hecem.accdb");

                    Console.WriteLine("Geri yükleme tamamlandı..!");
                    System.Threading.Thread.Sleep(2000);

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"Yonetim.exe";
                    startInfo.Arguments = "--kadi " + ka + " --sifre " + sifre;
                    Process.Start(startInfo);

                }
            }
            catch  
            {
                Console.Clear();
                Console.WriteLine("Yedek geri yüklemede hata! Tekrar Deneyin");
            }
            }
    }
}

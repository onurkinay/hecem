using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ResimBot
{
    public partial class Form1 : Form
    {
        List<string> kaynak = new List<string>();
        int i = 0, a = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("kaynak.txt", Encoding.Default, true);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (!File.Exists("r/" + line + ".png"))
                    kaynak.Add(line);
            }

            YeniResim();
        }

        private void btnKaydetCek_Click(object sender, EventArgs e)
        {
            string link = Microsoft.VisualBasic.Interaction.InputBox("Linki gir", "Link", "");
            if (link == "gec") YeniResim();

            else if (link != "")
            {
                ResmiKaydet(i, link);
                YeniResim();
            }
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            YeniResim();
        }

        private void YeniResim()
        {
            Random rand = new Random();
            do
            {
                a = rand.Next(0, kaynak.Count);
            }
            while (File.Exists(@"r/" + kaynak[a] + ".png"));

            lbResim.Text = "Resmin kelimesi: " + kaynak[a];

        }

        public void ResmiKaydet(int sira, string link)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadFile(link, @"r/" + kaynak[a]+".png");

        }

    }
}

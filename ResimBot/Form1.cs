using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Drawing;
using System.Data.OleDb;

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
            string link = Clipboard.GetText();
            if (link.IndexOf("http") != -1)
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
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(link);
            MemoryStream ms = new MemoryStream(imageBytes);

            Image resim = Image.FromStream(ms);

            resim.Save(@"r/" + kaynak[a] + ".png", System.Drawing.Imaging.ImageFormat.Png);
             
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hecem.accdb;Jet OLEDB:Database Password=HecemKVeri");

        private void button1_Click(object sender, EventArgs e)
        {
            GereksizlerSil("heceler");
        }

        public void GereksizlerSil(string tablo)
        {
            if (!(con.State == System.Data.ConnectionState.Open)) con.Open();
            OleDbCommand cm = new OleDbCommand("Select * from " + tablo + " ORDER BY veri", con);
            OleDbDataReader dr = cm.ExecuteReader();
           
            while (dr.Read())
            {
               if(!File.Exists(@"r/" + dr[1].ToString() + ".png"))
                {
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM " + tablo + " WHERE veri='" + dr[1].ToString()+"'", con);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
namespace SesBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        string line;
        List<string> kelimeler = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            Button snd = sender as Button;
            System.IO.StreamReader file = new System.IO.StreamReader( (snd.Tag.ToString() == "0") ? "kelime.txt" : "hece.txt");

            while ((line = file.ReadLine()) != null)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://tts.voicetech.yandex.net/tts?format=mp3&quality=hi&platform=web&application=translate&lang=tr_TR&text="+line+"", "sesler/"+line+".mp3");
                }
            }
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}

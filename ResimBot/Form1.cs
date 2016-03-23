using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ResimBot
{
    public partial class Form1 : Form
    {
        List<string> kaynak = new List<string>();
        int i = 0, a  = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("kaynak.txt", Encoding.Default, true);
            string line;
            while ((line = file.ReadLine()) != null) {
                if(!File.Exists("resim/"+line+".png"))
                kaynak.Add(line);
            }
          
            YeniResim();
        }
        
        private void btnKaydetCek_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Resim kaydedilsin mi?", "Onay", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Kaynak.ResmiKaydet(i);
                YeniResim();
            }
            else if (result == DialogResult.No)
            {
                YeniResim();
            }
            else
            {
                //Devam et
            }
        }
   
        private void btnSonraki_Click(object sender, EventArgs e)
        {
            i++;
            pbImage.Image = Kaynak.ResimCek(ref i);
        }

        private void YeniResim()
        {
            
            do {
                a++;
                Kaynak.KaynakCek(kaynak[a]);
            } while (Kaynak.kaynak.hits.Count == 0);

            lbResim.Text = "Resmin kelimesi: " + kaynak[a];

            i = 0;
            pbImage.Image = Kaynak.ResimCek(ref i);
        }
    }
}

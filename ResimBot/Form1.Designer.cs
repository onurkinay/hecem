namespace ResimBot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSonraki = new System.Windows.Forms.Button();
            this.lbResim = new System.Windows.Forms.Label();
            this.btnKaydetCek = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSonraki
            // 
            this.btnSonraki.Location = new System.Drawing.Point(10, 37);
            this.btnSonraki.Name = "btnSonraki";
            this.btnSonraki.Size = new System.Drawing.Size(108, 23);
            this.btnSonraki.TabIndex = 1;
            this.btnSonraki.Text = "Geç";
            this.btnSonraki.UseVisualStyleBackColor = true;
            this.btnSonraki.Click += new System.EventHandler(this.btnSonraki_Click);
            // 
            // lbResim
            // 
            this.lbResim.AutoSize = true;
            this.lbResim.Location = new System.Drawing.Point(8, 8);
            this.lbResim.Name = "lbResim";
            this.lbResim.Size = new System.Drawing.Size(88, 13);
            this.lbResim.TabIndex = 2;
            this.lbResim.Text = "Resmin kelimesi: ";
            // 
            // btnKaydetCek
            // 
            this.btnKaydetCek.Location = new System.Drawing.Point(124, 37);
            this.btnKaydetCek.Name = "btnKaydetCek";
            this.btnKaydetCek.Size = new System.Drawing.Size(109, 23);
            this.btnKaydetCek.TabIndex = 3;
            this.btnKaydetCek.Text = "Resmi al";
            this.btnKaydetCek.UseVisualStyleBackColor = true;
            this.btnKaydetCek.Click += new System.EventHandler(this.btnKaydetCek_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Sil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 105);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnKaydetCek);
            this.Controls.Add(this.lbResim);
            this.Controls.Add(this.btnSonraki);
            this.Name = "Form1";
            this.Text = "ResimBot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSonraki;
        private System.Windows.Forms.Label lbResim;
        private System.Windows.Forms.Button btnKaydetCek;
        private System.Windows.Forms.Button button1;
    }
}


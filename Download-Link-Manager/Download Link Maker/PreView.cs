using System;
using System.Net;
using System.IO;

using System.Drawing;

using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace Download_Link_Maker
{
    public partial class 
        PreView : Form
    {
        public PreView()
        {
            this.ShowIcon = false;
            InitializeComponent();
        }


        String Primary = String.Empty;
        String Change = String.Empty;

        public void ImageChange(String P,String C, int H, int W)
        {
            try {
                Primary = Application.StartupPath + "\\Chache\\" + Path.GetRandomFileName();
                Change = Application.StartupPath + "\\Chache\\" + Path.GetRandomFileName();

                WebClient wc = new WebClient();
                wc.DownloadFile(P, Primary);
                if (C != "")
                {
                    wc = new WebClient();
                    wc.DownloadFile(C, Change);
                }


                this.Height = H + 63;
                    this.Width = W + 41;

                    pictureBox1.Height = H;
                    pictureBox1.Width = W;

                pictureBox1.BackgroundImage = Image.FromFile(Primary);
            }
            catch (Exception)
            {

            }
        }
        public bool Check = false;

        private void PreView_Load(object sender, EventArgs e)
        {
            Check = true;
        }

        private void PreView_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Check = false;
            pictureBox1.Dispose();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (Change != "")
            {
                pictureBox1.BackgroundImage = Image.FromFile(Change);
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (Change != "")
            {
                pictureBox1.BackgroundImage = Image.FromFile(Primary);
            }
        }
    }
}

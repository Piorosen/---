using System;
using System.Text;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;

namespace Download_Link_Maker
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            /*
             * Used Degined
             * https://github.com/IgnaceMaes/MaterialSkin
             * 
             */
            InitializeComponent();
            if (new DirectoryInfo(Application.StartupPath + "\\" + "Chache\\").Exists)
            {
                new DirectoryInfo(Application.StartupPath + "\\" + "Chache\\").Delete(true);
            }
            new DirectoryInfo(Application.StartupPath + "\\" + "Chache\\").Create();

        }

        private void Write()
        {
            MyLibrary.File.Config.WritePrivateProfileString("Load", "Image", materialSingleLineTextField4.Text, Application.StartupPath + "\\Load.ini");
            MyLibrary.File.Config.WritePrivateProfileString("Load", "Image2", materialSingleLineTextField5.Text, Application.StartupPath + "\\Load.ini");
            MyLibrary.File.Config.WritePrivateProfileString("Load", "Width", materialSingleLineTextField3.Text, Application.StartupPath + "\\Load.ini");
            MyLibrary.File.Config.WritePrivateProfileString("Load", "Height", materialSingleLineTextField2.Text, Application.StartupPath + "\\Load.ini");
            MyLibrary.File.Config.WritePrivateProfileString("Load", "Check", materialCheckBox2.Checked.ToString(), Application.StartupPath + "\\Load.ini");
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        { 
            textBox1.Text = "<a href=\"";
            if (materialSingleLineTextField1.Text.Length == 0) { textBox1.Text = "파일 링크가 공백입니다."; return; }
            Write();

            if (materialCheckBox1.Checked == true)
            {
                textBox1.Text += materialSingleLineTextField1.Text.Substring(0, materialSingleLineTextField1.Text.Length - 1) + "1\">";
            }//http://imgauto.naver.com/brand2/adv/18878/premiumimg/20121016131950_3jYnE3hL.jpg
            else
            {
                textBox1.Text += materialSingleLineTextField1.Text + "\">";
            }
            textBox1.Text += "<img src=\"" + materialSingleLineTextField4.Text
                + "\" width=\""+ materialSingleLineTextField3.Text + "\" height=\"" + materialSingleLineTextField2.Text
                + "\" onmouseover=\"this.src=\'" +  materialSingleLineTextField5.Text + "\'\" onmouseout=\"this.src=\'" + materialSingleLineTextField4.Text + "\'\" border=\"0\"></a>";
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Text = "";
            materialSingleLineTextField2.Text = "";
            materialSingleLineTextField3.Text = "";
            materialSingleLineTextField4.Text = "";
            materialSingleLineTextField5.Text = "";
            materialCheckBox2.Checked = false;
        }

        PreView PV = new PreView();
        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text.Length == 0)
            {
                MessageBox.Show("이미지 링크를 다시 입력해 주세요!");
                return;
            }

            Write();

            try
            {
                if (PV.Check != true)
                {
                    PV.Show();
                }
            }
            catch (Exception) { }

            if (materialCheckBox2.Checked == true)
            {
                PV.ImageChange(materialSingleLineTextField4.Text, materialSingleLineTextField5.Text,
              Int32.Parse(materialSingleLineTextField2.Text), Int32.Parse(materialSingleLineTextField3.Text));
            }
            else
            {
                PV.ImageChange(materialSingleLineTextField4.Text, "",
              Int32.Parse(materialSingleLineTextField2.Text), Int32.Parse(materialSingleLineTextField3.Text));
            }
          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            StringBuilder SB = new StringBuilder(256);
            MyLibrary.File.Config.GetPrivateProfileString("Load", "Image", "", SB, 256, Application.StartupPath + "\\Load.ini");
            materialSingleLineTextField4.Text = SB.ToString();
            MyLibrary.File.Config.GetPrivateProfileString("Load", "Width", "", SB, 256, Application.StartupPath + "\\Load.ini");
            materialSingleLineTextField3.Text = SB.ToString();
            MyLibrary.File.Config.GetPrivateProfileString("Load", "Height", "", SB, 256, Application.StartupPath + "\\Load.ini");
            materialSingleLineTextField2.Text = SB.ToString();
            MyLibrary.File.Config.GetPrivateProfileString("Load", "Image2", "", SB, 256, Application.StartupPath + "\\Load.ini");
            materialSingleLineTextField5.Text = SB.ToString();
            MyLibrary.File.Config.GetPrivateProfileString("Load", "Check", "", SB, 256, Application.StartupPath + "\\Load.ini");
            materialCheckBox2.Checked = SB.ToString() == "True" ? true :false;


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}

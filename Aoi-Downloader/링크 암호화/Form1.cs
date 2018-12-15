using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 암호화;

namespace 링크_암호화
{
    public partial class Form1 : Form
    {
        Cry Cryed = new Cry();
        public Form1()
        {
            InitializeComponent();
            Cryed.Key = "A-Bxa42569Av-＃#!%^5ㅇ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Cryed.AESEncrypt256(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Cryed.AESDecrypt256(textBox2.Text);
        }
    }
}

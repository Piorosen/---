using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naver_ID_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient w = new WebClient()) {
                String str = w.DownloadString(@"https://nid.naver.com/user2/joinAjax.nhn?m=checkId&id=" + textBox1.Text);
                
                if (str == "NNNNY")
                {
                    textBox2.Text = "이 아이디는 가능합니다.";
                }
                else
                {
                    textBox2.Text = "이 아이디는 불가능 합니다.";
                }

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}

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

namespace Naver_Password_can_use
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // https://nid.naver.com/user2/joinAjax.nhn?m=checkPswd&id=&pw=1afadsf
            using (WebClient wc = new WebClient())
            {
                string str = wc.DownloadString(@"https://nid.naver.com/user2/joinAjax.nhn?m=checkPswd&id=&pw=" + textBox1.Text);
                if (str[4] == 'F')
                {
                    textBox2.Text = "해당 비밀번호는 사용이 불가능합니다.";
                }else if (str[4] == '1')
                {
                    textBox2.Text = "많이 안전하지 않은 비밀번호 입니다.";
                }
                else if (str[4] == '2')
                {
                    textBox2.Text = "조금 안전하지 않은 비밀번호 입니다.";
                }
                else if (str[4] == '3')
                {
                    textBox2.Text = "적당한 비밀번호 입니다.";
                }
                else if (str[4] == '4')
                {
                    textBox2.Text = "안전한 비밀번호 입니다.";
                }
                else
                {
                    textBox2.Text = "등록되지 않은 경우입니다.";
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

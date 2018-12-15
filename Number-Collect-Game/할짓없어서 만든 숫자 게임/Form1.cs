using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 할짓없어서_만든_숫자_게임
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        int Solve = 0;
        int Count = 0;

        bool NowStart = false;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (NowStart)
                {
                    listBox1.Items.Add("이미 게임 진행중이잖아?");
                    return;
                }
                Count = 0;
                listBox1.Items.Clear();
                Solve = (new Random().Next(0, int.Parse(textBox1.Text)));
                label1.Text = "정답 : ";
                listBox1.Items.Add("게임이 시작 되었습니다.");
                NowStart = true;
            }
            catch (Exception)
            {
                textBox1.Text = "0";
                listBox1.Items.Add("범위 똑바로 입력해라고!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Count += 1;
                if (!NowStart)
                {
                    listBox1.Items.Add("게임 진행중이 아니잖아!");
                    return;
                }
                int Result = int.Parse(textBox1.Text);
                if (Result == Solve)
                {
                    listBox1.Items.Add("정답입니다. : " + Count + "번 에 성공했습니다.");
                    NowStart = false;
                }
                else if (Result > Solve)
                {
                    listBox1.Items.Add(Result + "보다 작은수 입니다.");
                }
                else if (Result < Solve)
                {
                    listBox1.Items.Add(Result + "보다 큰수 입니다.");
                }
                else
                {
                    listBox1.Items.Add("뭔 또 이상한 숫자 넣었노 ㄷㄷ");
                }
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            catch (Exception)
            {
                textBox1.Text = "0";
                listBox1.Items.Add("정답을 똑바로 입력해라잉~");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("프로그래밍 : Aoi Kazto\n제작자 블로그 : http://blog.naver.com/aoikazto", "정말로 끄다니 ㄷㄷ");
        }
    }
}

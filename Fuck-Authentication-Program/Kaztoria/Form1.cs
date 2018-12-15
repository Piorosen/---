using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kaztoria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
        }

        private void CheckBox1_Click(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
        }
        private void CheckBox3_Click(object sender, MouseEventArgs e)
        {
            checkBox3.Checked = !checkBox3.Checked;
        }
        private void CheckBox2_Click(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = !checkBox2.Checked;
        }
        private void CheckBox4_Click(object sender, MouseEventArgs e)
        {
            checkBox4.Checked = !checkBox4.Checked;
        }
        private void CheckBox5_Click(object sender, MouseEventArgs e)
        {
            checkBox5.Checked = !checkBox5.Checked;
        }
        private void CheckBox6_Click(object sender, MouseEventArgs e)
        {
            checkBox6.Checked = !checkBox6.Checked;
        }
        private void Check_Click(object sender, EventArgs e)
        {
            String Hint = "아이디와 비번은 ID와 Password입니다!";
            String ID1 = ID.Text;
            String PD1 = PD.Text;

            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true && checkBox6.Checked == true)
            {
                if (ID1 == "ID" && PD1 == "Password")
                {
                    MessageBox.Show("계정 확인 완료입니다.", "성공");
                }
                else
                {
                    MessageBox.Show("계정이 틀렸습니다.", "실패");
                }
            }
            else
            {
                MessageBox.Show("약관을 전부다 체크해 주세요.", "실패");
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;

        }

        private void checkBox_leave(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapCreate
{
    
    public partial class Form1 : Form
    {
        List<CustomPanel> ee;
        public Form1()
        {
            InitializeComponent();
            ee = new List<CustomPanel>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g;
            for (int y = 0; y < int.Parse(Text_Y.Text); y++)
            {
                for (int x = 0; x < int.Parse(Text_X.Text); x++)
                {
                    CustomPanel p = new CustomPanel();

                    p.Size = new Size(10, 10);
                    p.Location = new Point(x * 10 + 10, y * 10 + 50);
                    p.Click += button1_Click_1;
                    p.TextureID = int.Parse(textBox1.Text);
                    p.MouseEnter += P_MouseEnter;
                    p.BackColor = Color.Aquamarine;
                    p.Check = checkBox1.Checked;

                    this.Controls.Add(p);
                    ee.Add(p);
                    g = p.CreateGraphics();
                    g.DrawRectangle(new Pen(Color.Black, 1.0f), 0, 0, 9, 9);
                }
            }

        }
        

        bool IsClick = false;

        private void P_MouseEnter(object sender, EventArgs e)
        {
            if (IsClick)
            {
                (sender as CustomPanel).BackColor = Color.FromArgb(
                    int.Parse(Text_Alpha.Text),
                    int.Parse(Text_Red.Text),
                    int.Parse(Text_Green.Text),
                    int.Parse(Text_Blue.Text));
                (sender as CustomPanel).Check = checkBox1.Checked;
                (sender as CustomPanel).TextureID = int.Parse(textBox1.Text);
            }
        }


        // Filed/Move/TextureID/Alpha/Red/Green/Blue(' '))
        private void Btn_Map_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\" + @"Map\map.txt", false);
            for (int y = 0; y < int.Parse(Text_Y.Text); y++)
            {
                for (int x = 0; x < int.Parse(Text_X.Text); x++)
                {
                    string str = ee[y * int.Parse(Text_X.Text) + x].Check == false ? "0" : "1";
                    sw.Write("0/" + str + "/" + ee[y * int.Parse(Text_X.Text) + x].TextureID + " ");
                }
            }
            sw.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (IsClick)
            {
                (sender as CustomPanel).BackColor = Color.FromArgb(
                    int.Parse(Text_Alpha.Text),
                    int.Parse(Text_Red.Text),
                    int.Parse(Text_Green.Text),
                    int.Parse(Text_Blue.Text));
                (sender as CustomPanel).Check = checkBox1.Checked;
                (sender as CustomPanel).TextureID = int.Parse(textBox1.Text);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                IsClick = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                IsClick = false;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'Z')
            {
                IsClick = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

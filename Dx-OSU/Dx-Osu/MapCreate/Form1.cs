using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<Data> list = new List<Data>();
        Stopwatch GetStopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        // time/x/y
        private void button1_Click_1(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\\Map\\music.txt", false);
            sw.Write(list.Count.ToString() + " ");
            foreach (var d in list)
            {
                sw.Write(d.time.ToString() + "/" + d.x.ToString() + "/" + d.y + " ");
            }

            sw.Close();
        }

        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 488);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "End";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1010, 529);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private int Changesa(double origin, double panelSize, double screen)
        {
            return (int)(origin * (screen / panelSize));
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Data d = new Data();
            var g = panel1.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Black), e.X - 5, e.Y - 5, 10, 10);

            d.time = GetStopwatch.ElapsedMilliseconds;
            d.x = Changesa(e.X, panel1.Size.Width, 1920);
            d.y = Changesa(e.Y, panel1.Size.Height, 1080);
            list.Add(d);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetStopwatch.Reset();
            GetStopwatch.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetStopwatch.Stop();
            GetStopwatch.Reset();
        }

    }
}

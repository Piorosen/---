using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Mouse_Position
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread Screen = new Thread(new ThreadStart(Get));
            Screen.Start();
            
        }
        static int X = 0;
        static int Y = 0;

        delegate void Mouse();

        private void Label1()
        {
           label1.Text = new Point(X, Y).ToString();
        }
        private void Run()
        {
            label1.Invoke(new Mouse(Label1), new Object[] { });
        }
        private void Get(){
            while (true)
            {
                X = Control.MousePosition.X;
                Y = Control.MousePosition.Y;
                System.Threading.Thread.Sleep(100);
                Run();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

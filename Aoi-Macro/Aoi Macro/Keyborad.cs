using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aoi_Macro
{
    public partial class Keyborad : Form
    {
        public String Text = "";

        public Keyborad()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Text = textBox1.Text;
            this.Close();
        }
    }
}

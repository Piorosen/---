using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace USB_Security
{
    public partial class QPDKWQINSDFWEFIQ : Form
    {
        protected override void WndProc(ref Message m)
        {
            UInt32 WM_DEVICECHANGE = 0x0219;
            UInt32 DBT_DEVTUP_VOLUME = 0x02;
            UInt32 DBT_DEVICEARRIVAL = 0x8000;
            UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

            if ((m.Msg == WM_DEVICECHANGE) &&
                (m.WParam.ToInt32() == DBT_DEVICEARRIVAL))
            {

                int devType = Marshal.ReadInt32(m.LParam, 4);
                if (devType == DBT_DEVTUP_VOLUME)
                {
                    CheckDevice(true);
                }
            }
            if ((m.Msg == WM_DEVICECHANGE) &&
                (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE))
            {

                int devType = Marshal.ReadInt32(m.LParam, 4);
                if (devType == DBT_DEVTUP_VOLUME)
                {
                    CheckDevice(false);
                }
            }
            base.WndProc(ref m);
        }


        public void CheckDevice(bool chk)
        {
            if (chk)
            {
                string[] ls_drivers = System.IO.Directory.GetLogicalDrives();
                foreach (string device in ls_drivers)
                {
                    System.IO.DriveInfo dr = new System.IO.DriveInfo(device);

                    if (dr.DriveType == System.IO.DriveType.Removable)
                    {
                        long i = 0;
                        i = dr.TotalSize;
                        if (i == 15521017856)
                        {
                            this.Location = new System.Drawing.Point(-20000, -20000);
                        }
                    }
                }
            }
            else
            {
                Application.Restart();
            }
        }
        

        public QPDKWQINSDFWEFIQ()
        {
            InitializeComponent();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckDevice(true);
        }
    }
}

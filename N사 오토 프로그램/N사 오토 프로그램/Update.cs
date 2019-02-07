using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
namespace N사_오토_프로그램
{
    class Updater
    {
        private const UInt64 Version = 10;
        private const String ServerFile = @"https://www.googledrive.com/host/0B_L8fTtSsj3sTmlYai1kZDRidzg";
        private const String ServerVersion = @"https://www.googledrive.com/host/0B_L8fTtSsj3sYm9RYTd0Vkx3UUk";

        private bool Auto;
        public bool Update(bool Auto)
        {
            try {
                this.Auto = Auto;
                Download();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("관리자 권한으로 실행해 주세요!");
                return false;
            }
        }

        private bool Download()
        {
            try
            {
                WebClient WC = new WebClient();
                WC.DownloadStringCompleted += WC_DownloadStringCompleted;
                WC.DownloadStringAsync(new Uri(ServerVersion));

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private bool UpdateFilyo = false;
        private void WC_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            UInt64 Result = 0;
            if (UInt64.TryParse(e.Result, out Result))
            {
                if (Result == Version)
                {
                    UpdateFilyo = false;
                    if (!Auto) MessageBox.Show("업데이트가 필요가 없습니다.");
                }
                else
                {
                    UpdateFilyo = true;
                }
            }
            else
            {
                UpdateFilyo = true;
            }
            if (UpdateFilyo)
            {
                String DownloadPath = System.Windows.Forms.Application.StartupPath + @"\" + "N사 오토 프로그램 (By Aoi Kazto) [ " + Result + " ].exe";
                WebClient WC2 = new WebClient();
                WC2.DownloadFileCompleted += WC2_DownloadFileCompleted;
                WC2.DownloadFileAsync(new Uri(ServerFile), DownloadPath);
            }
        }

        private void WC2_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            
            Form1.Fast_Exit = "True";
            MessageBox.Show("업데이트가 완료 되었습니다.\n새로운 버전으로 실행해 주세요!");

            Application.Exit();
        }
    }
}

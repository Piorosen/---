using System;
using System.Net;
using System.Net.Sockets;
using System.Management;


namespace N사_오토_프로그램
{
    class Check
    {

        private String GetMyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = string.Empty;
            foreach (IPAddress ia in host.AddressList)
            {
                if (ia.AddressFamily == AddressFamily.InterNetwork)
                {
                    myip = ia.ToString(); break;

                }
            }
            return myip;
        }


        private String GetMacAddress(string ip)
        {
            string macAddress = null;
            System.Management.ObjectQuery query = new System.Management.ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='TRUE'");
            System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query);
            foreach (System.Management.ManagementObject obj in searcher.Get())
            {
                string[] ipAddress = (string[])obj["IPAddress"];
                if (ipAddress[0] == ip && obj["MACAddress"] != null)
                {
                    macAddress = obj["MACAddress"].ToString(); break;
                }
            }
            return macAddress;
        }


        private String Chck()
        {
            String drive = "";
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            disk.Get();
            return disk["VolumeSerialNumber"].ToString();

        }

        String ck = "";
        public bool UserCheck()
        {
            String Key = "andfoawnejfjaiwenfㅁㄴㅇ뤔ㅈ둚3245536415316ㄱㄹ651ㄹㅇㄻㅈㄷㅂ 쿵침 쿵ㅁ 둘점ㄹ뭚ㅈ다 ㄻㅈ더ㅏ라뭉나첯ㅁㅇ누라무덛ㅁㅈ ㅏ루ㅏㅓㅜㅏㅗㅅㄷ뉴ㅓㅏ";
            암호화.Cry Crypt = new 암호화.Cry();
            Key = Crypt.AESEncrypt256(Key);
            String Serial = Crypt.AESEncrypt256(Chck());
            String Temp = Crypt.AESEncrypt256("ㅁㅈㄷㄻㅈ댜aw3fji23faamiwefaewesdfa54f32wae16s5fawefㄼ43ㅓㄷㅈㅇ낢ㄴㅇ람ㅇ닒ㅇ너ㅣㅏ믖디루");

            Crypt.Key = Serial;
            Key = Crypt.AESEncrypt256(Key);
            Crypt.Key = Temp;
            ck = Crypt.AESEncrypt256(Key);

            try
            {
                WebClient WC = new WebClient();
                WC.DownloadStringCompleted += WC_DownloadStringCompleted;
                WC.DownloadStringAsync(new Uri("https://www.googledrive.com/host/0B_L8fTtSsj3sS1FNTFp5WXRWWjQ"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void WC_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result == ck)
            {

            }
            else
            {
                Form1.Fast_Exit = "True";

                System.Windows.Forms.MessageBox.Show("본 유저는 인증되지 않은 컴퓨터 입니다.");
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}

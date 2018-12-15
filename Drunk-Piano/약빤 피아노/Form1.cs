using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net;
using System.IO;

namespace 약빤_피아노
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            base.MouseDown += FMouseDown;
            base.MouseMove += FMouseMove;
            button1.MouseDown += FMouseDown;
            button1.MouseMove += FMouseMove;
            button10.MouseDown += FMouseDown;
            button10.MouseMove += FMouseMove;

            DirectoryInfo DI = new DirectoryInfo(@"C:\Aoi Project\");
            DirectoryInfo PianoDI = new DirectoryInfo(@"C:\Aoi Project\Piano\");
            if (!DI.Exists)
            {
                DI.Create();
            }
            if (!PianoDI.Exists)
            {
                PianoDI.Create();
                MessageBox.Show("음반 라이브러리를 다운로드 중입니다!!\n약 30초만 기다려 주세염~? 귀염귀염");
                String[] Link = {
                                @"http://www.googledrive.com/host/0BxsTRMuJ0OItZmhRMDZFekZoRTQ",
                                @"http://www.googledrive.com/host/0BxsTRMuJ0OItOVg5WXZIbldFXzA",
                                @"http://www.googledrive.com/host/0BxsTRMuJ0OItMkYyLW9KTW4zQlE",
                                @"http://www.googledrive.com/host/0BxsTRMuJ0OItWV80Y3RlTEdwMWc",
                                @"http://www.googledrive.com/host/0BxsTRMuJ0OItTzlXQWVZNlNCdzA",
                                @"http://www.googledrive.com/host/0BxsTRMuJ0OItRHVhOUpOY3NBWlk",
                                @"http://www.googledrive.com/host/0BxsTRMuJ0OItcllhM0NCemd0M1E",
                                @"http://www.googledrive.com/host/0BxsTRMuJ0OItOGlxTzl1UTVjWE0"
                            };
                String[] Name ={
                               @"도",
                               @"레",
                               @"미",
                               @"파",
                               @"솔",
                               @"라",
                               @"시",
                               @"높은 도"
                           };
                WebClient WC1 = new WebClient();
                WebClient WC2 = new WebClient();
                WebClient WC3 = new WebClient();
                WebClient WC4 = new WebClient();
                WebClient WC5 = new WebClient();
                WebClient WC6 = new WebClient();
                WebClient WC7 = new WebClient();
                WebClient WC8 = new WebClient();

                WC1.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                WC2.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                WC3.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                WC4.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                WC5.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                WC6.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                WC7.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                WC8.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                WC1.DownloadFileAsync(new Uri(Link[0]), @"C:\Aoi Project\Piano\" + Name[0] + @".wav");
                WC2.DownloadFileAsync(new Uri(Link[1]), @"C:\Aoi Project\Piano\" + Name[1] + @".wav");
                WC3.DownloadFileAsync(new Uri(Link[2]), @"C:\Aoi Project\Piano\" + Name[2] + @".wav");
                WC4.DownloadFileAsync(new Uri(Link[3]), @"C:\Aoi Project\Piano\" + Name[3] + @".wav");
                WC5.DownloadFileAsync(new Uri(Link[4]), @"C:\Aoi Project\Piano\" + Name[4] + @".wav");
                WC6.DownloadFileAsync(new Uri(Link[5]), @"C:\Aoi Project\Piano\" + Name[5] + @".wav");
                WC7.DownloadFileAsync(new Uri(Link[6]), @"C:\Aoi Project\Piano\" + Name[6] + @".wav");
                WC8.DownloadFileAsync(new Uri(Link[7]), @"C:\Aoi Project\Piano\" + Name[7] + @".wav");

                WC1.DownloadFileCompleted += WC_DownloadFileCompleted;
                WC2.DownloadFileCompleted += WC_DownloadFileCompleted;
                WC3.DownloadFileCompleted += WC_DownloadFileCompleted;
                WC4.DownloadFileCompleted += WC_DownloadFileCompleted;
                WC5.DownloadFileCompleted += WC_DownloadFileCompleted;
                WC6.DownloadFileCompleted += WC_DownloadFileCompleted;
                WC7.DownloadFileCompleted += WC_DownloadFileCompleted;
                WC8.DownloadFileCompleted += WC_DownloadFileCompleted;

            }
        }

        static int i = 0;
        private void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (i < 7)
            {
                i += 1;
            }
            else
            {
                MessageBox.Show("라이브러리 다운이 끝났습니다!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private Point Position = new Point(0, 0);

        private void FMouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Location.X + (Position.X + e.X),
                    this.Location.Y + (Position.Y + e.Y));// 마우스의 이동치를 Form Location에 반영한다.
            }
        }


        SoundPlayer Do = new SoundPlayer(@"C:\Aoi Project\Piano\도.wav");
        SoundPlayer Le = new SoundPlayer(@"C:\Aoi Project\Piano\레.wav");
        SoundPlayer Mi = new SoundPlayer(@"C:\Aoi Project\Piano\미.wav");
        SoundPlayer Pa = new SoundPlayer(@"C:\Aoi Project\Piano\파.wav");
        SoundPlayer Sol = new SoundPlayer(@"C:\Aoi Project\Piano\솔.wav");
        SoundPlayer La = new SoundPlayer(@"C:\Aoi Project\Piano\라.wav");
        SoundPlayer Si = new SoundPlayer(@"C:\Aoi Project\Piano\시.wav");
        SoundPlayer HighDo = new SoundPlayer(@"C:\Aoi Project\Piano\높은 도.wav");


        private void FMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                Position = new Point(-e.X, -e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("개발자 : Aoi Kazto\n개발자 블로그 : http://blog.naver.com/aoikazto\n문의 사항은 위 블로그에 해주세염~~!!");
            Application.Exit();
        }

        delegate void Play(SoundPlayer SP);

        private void Played(SoundPlayer SP)
        {
            try
            {
                SP.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("라이브러리 다 다운받을 때까지만 기다려 ㅠㅠ..");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Invoke(new Play(Played), new object[] { Do });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Invoke(new Play(Played), new object[] { Le });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Invoke(new Play(Played), new object[] { Mi });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Invoke(new Play(Played), new object[] { Pa });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Invoke(new Play(Played), new object[] { Sol });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Invoke(new Play(Played), new object[] { La });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Invoke(new Play(Played), new object[] { Si });
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Invoke(new Play(Played), new object[] { HighDo });
        }
    }
}

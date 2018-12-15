using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using 암호화;

namespace Aoi전용_파일_다운로드_관리자
{
    public partial class Form1 : Form
    {
        Cry Cryed = new Cry();

        WebClient WC = new WebClient();
        bool NowDonload = false;
        public Form1()
        {
            InitializeComponent();
        }
        #region A


        void fileDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            NowDonload = false;
            MessageBox.Show("파일 다운로드 완료!", "다운로드 완료!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            th.Abort();
            Byte[] Read = new Byte[22528];
            String Str = "";
            StreamReader SR = new StreamReader(Path + Program_Name);
            int i = 0;
            while (SR.EndOfStream)
            {
                Read[i] = (Byte)SR.Read();
                i += 1;
            }
            Str = Encoding.Default.GetString(Read);
            FileStream FF = new FileStream(@"C:\Test.txt", FileMode.Create);
            StreamWriter SW = new StreamWriter(FF, Encoding.Default);
            SW.Write(Str);
            FF.Close();
            SR.Close();
        }
        #endregion
        #region B
        private String Link = "";        private String Path = "";

        private Version version = new Version();
        private String Program_Name = "";

        #region 이부분 개발 완료 수정 무
        private void button1_Click(object sender, EventArgs e)
        {

            /*
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "Aoi Kazto의 전용 확장자(*.Aoi)|*.Aoi";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    ASDC = OFD.FileName;
                    FS = new FileStream(ASDC, FileMode.Open);
                    SR = new StreamReader(FS, Encoding.UTF8);
                    Link = Cryed.AESDecrypt256(SR.ReadLine());
                    Program_Name = Cryed.AESDecrypt256(SR.ReadLine()); // 프로그램 이름
                    textBox1.Text = Program_Name;
                    FS.Close();
                    SR.Close();
                }
                else
                {
                }
            }
            catch (Exception)
            {
                MessageBox.Show("해당 파일은 열수가 없거나, 이미 열려져 있습니다.");
            }
             */
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Cry Cra = new Cry();
            Cra.Key = textBox3.Text;
            textBox2.Text = Cra.AESDecrypt256(textBox1.Text);
            /*
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                Path = FBD.SelectedPath + @"\";
                textBox2.Text = Path;
            }*/
        }
        #endregion
        private void Down()
        {
            if (Link == "") { MessageBox.Show("다운로드 링크가 없습니다!"); return; }
            else if (Path == "") { MessageBox.Show("다운받을 경로가 없습니다."); return; }
            if (!NowDonload)
            {
                Uri uri = new Uri(Link);
                WC.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                MessageBox.Show("다운로드를 시작합니다!");
                WC.DownloadFileAsync(uri, Path);
                NowDonload = true;
            }
        }
        Thread th;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Link = textBox1.Text;
                Path = textBox2.Text;

                th = new Thread(new ThreadStart(Down));
                th.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("파일을 다운로드를 할수가없습니다.\n프로그램을 건들이지 않고 실행을 해보세요!.", "에러 발생");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            version.Key = "A-Bxa42569Av-＃#!%^5ㅇ";
            version.Link = @"https://www.googledrive.com/host/0BxsTRMuJ0OItd3o5OGs4WUE5QmM";
            version.Path = Application.StartupPath;
           // version.Version_Check();
           // WC.DownloadFileCompleted += new AsyncCompletedEventHandler(fileDownloadCompleted);
            Cryed.Key = "A-Bxa42569Av-＃#!%^5ㅇ";
        }
        #endregion

    }
    class Version
    {
        public String Link { set; get; }
        private const String NowVersion = "1.0.1";
        private String version { set; get; }
        private String DownLink { set; get; }
        public String Path { set; get; }

        private WebClient WC = new WebClient();
        public String Key { set; get; }
        private Cry Cryed = new Cry();

        private WebClient WCD = new WebClient();



        void fileDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            FileStream FS = new FileStream(@"C:\Program Files\Aoi\Download Manager\Version.ver", FileMode.Open);
            StreamReader SR = new StreamReader(FS, Encoding.UTF8);
            version = Cryed.AESDecrypt256(SR.ReadLine());
            DownLink = Cryed.AESDecrypt256(SR.ReadLine());
            FS.Close();
            SR.Close();
            try
            {
                if (version == NowVersion)
                {
                    return;
                }
                else
                {
                    WCD.DownloadFileAsync(new Uri(DownLink), Path + @"\Aoi전용 파일 다운로드 관리자 ( " + version + @" ).exe");
                    MessageBox.Show("최신버전을 찾았습니다!");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("알수없는 에러입니다.");
                return;
            }
        }

        public Version()
        {
            Cryed.Key = "A-Bxa42569Av-＃#!%^5ㅇ";
            WC.DownloadFileCompleted += new AsyncCompletedEventHandler(fileDownloadCompleted);
            WCD.DownloadFileCompleted += new AsyncCompletedEventHandler(Download);
        }

        private void Download(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("버전 업데이트를 완료 했습니다.\n최신버전으로 실행 시켜주세요!");
            Application.Exit();
        }

        public void Version_Check()
        {
            Cryed.Key = this.Key;
            DirectoryInfo Files = new DirectoryInfo(@"C:\Program Files");
            DirectoryInfo Aoi = new DirectoryInfo(@"C:\Program Files\Aoi\");
            DirectoryInfo Download = new DirectoryInfo(@"C:\Program Files\Aoi\Download Manager\");
            if (!Files.Exists)
            {
                Files.Create();
            } if (!Aoi.Exists)
            {
                Aoi.Create();
            } if (!Download.Exists)
            {
                Download.Create();
            }
            WC.DownloadFileAsync(new Uri(Link), @"C:\Program Files\Aoi\Download Manager\Version.ver");
        }
    }
}
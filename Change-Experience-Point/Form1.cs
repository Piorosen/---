/////uj using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System;

namespace 체험지수_변경기
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("이용해주셔서 감사합니다.\n개발자 : Aoi Kazto\n개발자 주소 : http://blog.naver.com/aoikazto", "이용해 주셔서 감사합니다!");
            // System.Diagnostics.Process.Start("Explorer", "http://blog.naver.com/aoikazto");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo FI = new FileInfo(@"C:\Windows\Performance\WinSAT\DataStore\2099-12-31 23.59.59.999 Formal.Assessment (Initial).WinSAT.xml");
            if (FI.Exists)
            {
                FI.Delete();
            }
            Down();
        }
        private void Down()
        {
            try
            {
                String path = @"C:\Windows\Performance\WinSAT\DataStore";
                DirectoryInfo Dir = new DirectoryInfo(path);
                FileInfo[] Directory = Dir.GetFiles();
                String[,] FileName = new String[Directory.Length, 4];
                List<String> Filter = new List<String>();
                int k = 0;
                int Length = FileName.Length - 1;
                for (int i = 0; i < Length / 4 + 1; i++)
                {
                    for (int t = 0; t < Directory[i].Name.Split(' ').Length; t++)
                    {
                        FileName[i, t] = Directory[i].Name.Split(' ')[t];
                    }
                    if (FileName[i, 2] == "Formal.Assessment")
                    {
                        Filter.Add(Directory[i].Name);
                        k += 1;
                    }
                }
                if (k == 0)
                {
                    MessageBox.Show("한번이라도 체험지수 테스트를 해주세요!");
                }
                else if (k == 1)
                {
                    foreach (String str in Filter)
                    {
                        Change(str);
                    }
                }
                else if (k > 1)
                {
                    Filter.Sort();
                    String str = "";
                    foreach (String Str1 in Filter)
                    {
                        str = Str1;
                    }
                    Change(str);
                }
                else
                {
                    MessageBox.Show("Error : 값이 -1이 될수가 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Change(String Path)
        {
            #region Round 목록
            String[] Round = new String[11];
            Round[0] = "<SystemScore>" + textBox6.Text + "</SystemScore>";
            Round[1] = "<MemoryScore>" + textBox2.Text + "</MemoryScore>";
            Round[2] = "<CpuScore>" + textBox1.Text + "</CpuScore>";
            Round[3] = "<CPUSubAggScore>" + textBox1.Text + "</CPUSubAggScore>";
            Round[4] = "<VideoEncodeScore>" + textBox3.Text + "</VideoEncodeScore>";
            Round[5] = "<GraphicsScore>" + textBox3.Text + "</GraphicsScore>";
            Round[6] = "<Dx9SubScore>" + textBox3.Text + "</Dx9SubScore>";
            Round[7] = "<Dx10SubScore>" + textBox3.Text + "</Dx10SubScore>";
            Round[8] = "<GamingScore>" + textBox4.Text + "</GamingScore>";
            Round[9] = "<StdDefPlaybackScore>TRUE</StdDefPlaybackScore><HighDefPlaybackScore>TRUE</HighDefPlaybackScore>";
            Round[10] = "<DiskScore>" + textBox5.Text + "</DiskScore>";
            #endregion
            try
            {
                
                FileStream FS = new FileStream(@"C:\Windows\Performance\WinSAT\DataStore\2099-12-31 23.59.59.999 Formal.Assessment (Initial).WinSAT.xml", FileMode.Create);
                StreamWriter SW = new StreamWriter(FS, Encoding.BigEndianUnicode);
                StreamReader SR = new StreamReader(@"C:\Windows\Performance\WinSAT\DataStore\" + Path);
                String First = "<?xml version=\"1.0\" encoding=\"UTF-16\"?><WinSAT><ProgramInfo><Name>WinSAT</Name><Version>V6.1 Build-7601.17514</Version><WinEIVersion>Windows7-RC-0.91</WinEIVersion><Title>Windows 시스템 평가 도구</Title><ModulePath>C:\\Windows\\system32\\winsat.exe</ModulePath><CmdLine><![CDATA[\"C:\\Windows\\system32\\winsat.exe\" formal -cancelevent ab6081a8-2b92-47f3-b9a3-9e3835474d55]]></CmdLine><Note><![CDATA[]]></Note></ProgramInfo><SystemEnvironment><ExecDateTOD Friendly=\"Monday December 31, 2099  3:59:57pm\">735596:57597216</ExecDateTOD><IsOfficial>1</IsOfficial><IsFormal/><RanOverTs>0</RanOverTs><RanOnBatteries>0</RanOnBatteries></SystemEnvironment><WinSPR>";
                SW.Write(First);
                for (int i = 0; i < Round.Length; i++)
                {
                    SW.Write(Round[i]);
                }

                for (int i = 0; i < 32; )
                {
                    if (SR.Read() == '>')
                    {
                        i += 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                try
                {
                    while (SR.Peek() != -1)
                    {
                        int R = SR.Read();
                        SW.Write((char)R);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                   
                    SR.Close();
                    SW.Close();
                }
                MessageBox.Show("설정이 끝났습니다.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo FI = new FileInfo(@"C:\Windows\Performance\WinSAT\DataStore\2099-12-31 23.59.59.999 Formal.Assessment (Initial).WinSAT.xml");
            if (FI.Exists)
            {
                FI.Delete();
                MessageBox.Show("되돌리기가 되었습니다.");
            }
            else
            {
                MessageBox.Show("제일 먼저 실행을 해주세요!");
            }
        }
    }
}
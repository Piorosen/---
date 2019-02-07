using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

using MyLibrary;
using MaterialSkin;
using MaterialSkin.Controls;

namespace N사_오토_프로그램
{
    public partial class Form1 : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        Naver_Library NL = new Naver_Library();
        String SavePath = System.Windows.Forms.Application.StartupPath + @"\" + "Config.ini";

        private void SettingSave()
        {

            MyLibrary.File.Config.WritePrivateProfileString("Setting", "Login", CheckBox_AutoLogin.Checked.ToString(), SavePath);
            MyLibrary.File.Config.WritePrivateProfileString("Setting", "ID", new 암호화.Cry().AESEncrypt256(Text_ID.Text), SavePath);
            MyLibrary.File.Config.WritePrivateProfileString("Setting", "PW", new 암호화.Cry().AESEncrypt256(Text_PW.Text), SavePath);
            MyLibrary.File.Config.WritePrivateProfileString("Setting", "ScreenMode", CheckBox_ScreenMode.Checked.ToString(), SavePath);
            MyLibrary.File.Config.WritePrivateProfileString("Setting", "HidePassword", CheckBox_HidePassword.Checked.ToString(), SavePath);
        }

        void Init()
        {
            tabPage4.Controls.Add(panel2);
            tabPage4.Controls.Add(panel3);
            tabPage4.Controls.Add(panel4);

            panel2.Location = new Point(163, 3);
            panel3.Location = new Point(163, 3);
            panel4.Location = new Point(163, 3);


            panel1.Size = new Size(0, 0);
            panel1.Visible = false;

            Button_Start.Location = new Point(3, 18);
            Button_Stop.Location = new Point(3, 104);
            Button_Option.Location = new Point(180, 18);

            Button_Start.Size = new Size(157, 69);
            Button_Stop.Size = new Size(157, 69);
            Button_Option.Size = new Size(78, 155);

            

            materialRaisedButton1.Location = new Point(3, 3);
            materialRaisedButton3.Location = new Point(3, 93);
            materialRaisedButton4.Location = new Point(242, 93);

            materialRaisedButton1.Size = new Size(465, 84);
            materialRaisedButton3.Size = new Size(226, 84);
            materialRaisedButton4.Size = new Size(226, 84);
            BigCheck = true;

            

            StringBuilder Login = new StringBuilder(256);
            StringBuilder ID = new StringBuilder(256);
            StringBuilder PW = new StringBuilder(256);
            StringBuilder Update = new StringBuilder(256);
            StringBuilder ScreenMode = new StringBuilder(256);
            StringBuilder Hide = new StringBuilder(256);

            MyLibrary.File.Config.GetPrivateProfileString("Setting", "Login", "False", Login, 256, SavePath);
            MyLibrary.File.Config.GetPrivateProfileString("Setting", "ID", "", ID, 256, SavePath);
            MyLibrary.File.Config.GetPrivateProfileString("Setting", "PW", "", PW, 256, SavePath);
            MyLibrary.File.Config.GetPrivateProfileString("Setting", "Update", "False", Update, 256, SavePath);
            MyLibrary.File.Config.GetPrivateProfileString("Setting", "ScreenMode", "False", ScreenMode, 256, SavePath);
            MyLibrary.File.Config.GetPrivateProfileString("Setting", "HidePassword", "False", Hide, 256, SavePath);

            if (Login.ToString() == "True")
            {
                try {
                    Text_ID.Text = new 암호화.Cry().AESDecrypt256(ID.ToString());
                    Text_PW.Text = new 암호화.Cry().AESDecrypt256(PW.ToString());
                    NL.ID = Text_ID.Text;
                    NL.PW = Text_PW.Text;
                    if (NL.Login())
                    {
                        Label_Login_Option.Text = "로그인 성공";
                    }
                    else
                    {
                        Label_Login_Option.Text = "로그인 실패";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("아이디와 비밀번호가 변조 되어있습니다.\n초기화 합니다.");
                    Text_ID.Text = "";
                    Text_PW.Text = "";
                    SettingSave();
                }
                CheckBox_AutoLogin.Checked = true;
            }
            if (Update.ToString() == "True")
            {
                CheckBox_AutoUpdate.Checked = true;
            }
            if (ScreenMode.ToString() == "True")
            {
                CheckBox_ScreenMode.Checked = true;
            }
            if (Hide.ToString() == "True")
            {
                CheckBox_HidePassword.Checked = true;
            }
            BGW.DoWork += BGW_DoWork;
            BGW.RunWorkerAsync();
            Run.DoWork += Run_DoWork;
            Run.RunWorkerAsync();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Init();
        }
        public Form1()
        {
            InitializeComponent();
            
            materialSkinManager.AddFormToManage(this);
            materialTabSelector1.BaseTabControl = materialTabControl1;
            
        }



        private void Button_Login_Click(object sender, EventArgs e)
        {
            NL.ID = Text_ID.Text;
            NL.PW = Text_PW.Text;
            if (NL.Login())
            {
                Label_Login_Option.Text = "로그인 성공";
            }
            else
            {
                Label_Login_Option.Text = "로그인 실패";
            }
        }

        #region Update
        private void Button_Update_Click(object sender, EventArgs e)
        {
            if (new Updater().Update(false))
            {
                Fast_Exit = "True";
                Application.Exit();

            }
        }

        BackgroundWorker BGW = new BackgroundWorker();
        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!new Updater().Update(true))
                {
                    Fast_Exit = "True";
                    Application.Exit();

                }
                if (!new Check().UserCheck())
                {
                    Fast_Exit = "True";
                    Application.Exit();
                }
                Thread.Sleep(60 * 1000);
            }
        }

        private void CheckBox_AutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
        }
        #endregion

        public static String Fast_Exit = "False";
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Fast_Exit == "True")
            {
                Application.ExitThread();
                return;
            } 
            if (DialogResult.Yes == MessageBox.Show("프로그램을 종료를 하시겠습니까? (Y/N)", "종료 하시겟습니까?", MessageBoxButtons.YesNo))
            {
                Application.ExitThread();
            }
            e.Cancel = true;
        }

        #region Dont worry
        private void CheckBox_ScreenMode_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_ScreenMode.Checked)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
        }

        private void Button_SettingSave_Click(object sender, EventArgs e)
        {
            SettingSave();
        }

        private void CheckBox_HidePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_HidePassword.Checked)
            {
                Pic_Hide.Visible = true;
            }
            else
            {
                Pic_Hide.Visible = false;
            }
        }

        private void Pic_Hide_Click(object sender, EventArgs e)
        {

        }

        private void Text_ID_Click(object sender, EventArgs e)
        {

        }
        bool OptionBool = true;
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (!OptionBool)
            {
                new Beauty.ControlMove().Size(panel1, new Size(0, 0), 12);
                panel1.Visible = false;

                new Beauty.ControlMove().Move(Button_Start, new Point(3, 18), 10);
                new Beauty.ControlMove().Move(Button_Stop, new Point(3, 104), 10);
                new Beauty.ControlMove().Move(Button_Option, new Point(180,18), 10);

                new Beauty.ControlMove().Size(Button_Start, new Size(157, 69), 10);
                new Beauty.ControlMove().Size(Button_Stop, new Size(157, 69), 10);
                new Beauty.ControlMove().Size(Button_Option, new Size(78, 155), 10);

                OptionBool = !OptionBool;
            }
            else
            {
                new Beauty.ControlMove().Move(Button_Start, new Point(3,18), 10);
                new Beauty.ControlMove().Move(Button_Stop, new Point(3,76), 10);
                new Beauty.ControlMove().Move(Button_Option, new Point(3,134), 10);

                new Beauty.ControlMove().Size(Button_Start, new Size(56,39), 10);
                new Beauty.ControlMove().Size(Button_Stop, new Size(56,39), 10);
                new Beauty.ControlMove().Size(Button_Option, new Size(56,39), 10);

                panel1.Visible = true;
                new Beauty.ControlMove().Size(panel1, new Size(401, 200), 12);
                OptionBool = !OptionBool;
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (List_List.SelectedIndex == -1)
            {
                return;
            }
            String Path = Application.StartupPath + "\\Library\\";

            StringBuilder title = new StringBuilder(256);
            StringBuilder content = new StringBuilder(256);
            StringBuilder MenuID = new StringBuilder(256);
            StringBuilder CafeID = new StringBuilder(256);
            StringBuilder CafeName = new StringBuilder(256);

            StringBuilder AutoDel = new StringBuilder(256);

            
            

            Path += (List_List.Items[List_List.SelectedIndex] + "\\");
            String ContentPath = Path + "ContentList\\";

            MyLibrary.File.Config.GetPrivateProfileString("Setting", "MenuID", "", MenuID, 256, Path + "Info.inf");
            MyLibrary.File.Config.GetPrivateProfileString("Setting", "CafeID", "", CafeID, 256, Path + "Info.inf");
            MyLibrary.File.Config.GetPrivateProfileString("Setting", "CafeName", "", CafeName, 256, Path + "Info.inf");
            MyLibrary.File.Config.GetPrivateProfileString("Setting", "AutoDelete", "", AutoDel, 256, Path + "Info.inf");
            
            Text_Tag.Text = List_List.Items[List_List.SelectedIndex].ToString();
            Text_Title.Text = Path + "Title.inf";
            Text_Content.Text = Path + "ContentList\\";
            Text_MenuID.Text = MenuID.ToString();
            Text_CafeID.Text = CafeID.ToString();
            Text_CafeName.Text = CafeName.ToString();
            
            if (AutoDel.ToString() == "True")
            {
                Check_Delete.Checked = true;
            }
            else
            {
                Check_Delete.Checked = false;
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            try {
                if (Text_Title.Text == "" || Text_Content.Text == "" || Text_Tag.Text == "" ||
                    Text_MenuID.Text == "" || Text_CafeID.Text == "" || Text_CafeName.Text == "")
                {
                    MessageBox.Show("올바르게 입력을 해주세요!");
                }

                String MainPath = Application.StartupPath + "\\Library\\" + Text_Tag.Text + "\\";

                if (new DirectoryInfo(MainPath).Exists)
                {
                    MessageBox.Show("이미 존재 합니다.");
                    return;
                }


                String Path = Application.StartupPath + "\\Library\\";
                if (!(new DirectoryInfo(Path).Exists))
                {
                    new DirectoryInfo(Path).Create();
                }
                Path += Text_Tag.Text + "\\";
                if (!(new DirectoryInfo(Path).Exists))
                {
                    new DirectoryInfo(Path).Create();
                }
                else
                {
                    new DirectoryInfo(Path).Delete(true);
                }
                String ContentPath = Path + "ContentList\\";
                if (!(new DirectoryInfo(ContentPath).Exists))
                {
                    new DirectoryInfo(ContentPath).Create();
                }



                MyLibrary.File.Config.WritePrivateProfileString("Setting", "MenuID", Text_MenuID.Text, Path + "Info.inf");
                MyLibrary.File.Config.WritePrivateProfileString("Setting", "CafeID", Text_CafeID.Text, Path + "Info.inf");
                MyLibrary.File.Config.WritePrivateProfileString("Setting", "CafeName", Text_CafeName.Text, Path + "Info.inf");
                MyLibrary.File.Config.WritePrivateProfileString("Setting", "AutoDelete", Check_Delete.Checked.ToString(), Path + "Info.inf");

                new FileInfo(Text_Title.Text).CopyTo(Path + "Title.inf", true);


                List<String> Title = new List<string>();
                List<String> Content = new List<string>();

                FileInfo[] di = new DirectoryInfo(Text_Content.Text).GetFiles();
                for (int i = 0; i < di.Length; i++)
                {
                    di[i].CopyTo(ContentPath + i.ToString() + ".lib");
                    Content.Add(di[i].Name);
                }
                StreamReader Sr = new StreamReader(Path + "Title.inf", Encoding.Default);

                for (int i = 0; !Sr.EndOfStream; i++)
                {
                    Title.Add(Sr.ReadLine());
                }


                if (List_List.Items.IndexOf(Text_Tag.Text) == -1)
                {
                    List_List.Items.Add(Text_Tag.Text);
                }



                Sc.AutoDel.Add(Check_Delete.Checked);
                Sc.CafeID.Add(Text_CafeID.Text);
                Sc.CafeName.Add(Text_CafeName.Text);
                Sc.MenuID.Add(Text_MenuID.Text);
                Sc.Tag.Add(Text_Tag.Text);
                Sc.SetTitle(Title);
                Sc.SetCotent(Content);
                Sc.Article.Add(" ");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        SaveClass Sc = new SaveClass();
        private void Button_Search_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Text_Content.Text = fbd.SelectedPath;
            }
        }
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "내용 검색 프로그램";
            openFileDialog1.InitialDirectory = "C:\\";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Text_Title.Text = openFileDialog1.FileName;
            }
            
        }


        private void Button_Del_Click(object sender, EventArgs e)
        {
            if (List_List.SelectedIndex == -1)
            {
                return;
            }
            String Path = Application.StartupPath + "\\Library\\" + List_List.SelectedItem.ToString();
            
            new DirectoryInfo(Path).Delete(true);
            
            Sc.Delete(List_List.SelectedIndex);
            List_List.Items.RemoveAt(List_List.SelectedIndex);
        }
        #endregion


        BackgroundWorker Run = new BackgroundWorker();
        bool Start = false;

        private void Run_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (Start)
                {
                    if (Fast_Exit == "True")
                    {
                        Start = false;
                        Run.Dispose();
                        Application.Exit();
                    }

               //     System.Windows.Forms.MessageBox.Show("Run Doit");

                    NL.Login();
                    NL.AllDelete(ref Sc);
                    for (int i = 0; i < List_List.Items.Count; i++)
                    {
                  
                        NL.Write(i, ref Sc, Application.StartupPath);
                    }


                    int Delays = 1;
                    try
                    {
                        if (Text_Delay.Text == "")
                        {
                            Delays = 1;
                        }
                        else
                        {
                            Int32.Parse(Text_Delay.Text).ToString();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("대기 시간 입력이 잘못되었습니다.");
                        Delays = 1;
                    }
                    finally
                    {
                        Thread.Sleep(Delays * 60 * 60 * 1000);
                    }
                }

                Thread.Sleep(10);
            }
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            Start = true;
            MessageBox.Show("오토 프로그램을 시작합니다.");
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
            
            Start = false;
            MessageBox.Show("오토 프로그램을 중지합니다.");
        }
        public bool IsAdministrator()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            if (null != identity)
            {


                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                try
                {
                    StreamWriter Sw = new StreamWriter("C:\\temp.ast");
                    Sw.Write("aaaa");
                    Sw.Close();
                    new FileInfo("C:\\temp.ast").Delete();
                }catch (IOException)
                {
                    Fast_Exit = "True";
                    Application.Exit();
                }





                if (!IsAdministrator())
                {
                    MessageBox.Show("관리자 권환으로 실행해 주세요!!");
                    Fast_Exit = "True";
                    Application.Exit();
                }
                String Paths = Application.StartupPath + "\\Library\\";
                if (!(new DirectoryInfo(Paths).Exists))
                {
                    new DirectoryInfo(Paths).Create();
                }


                DirectoryInfo[] Directs = new DirectoryInfo(Application.StartupPath + "\\Library\\").GetDirectories();


                for (int i = 0; i < Directs.Length; i++)
                {
                    List_List.Items.Add(Directs[i].Name);
                    String info = Directs[i].FullName + "\\info.inf";

                    StringBuilder MenuID = new StringBuilder(256);
                    StringBuilder CafeID = new StringBuilder(256);
                    StringBuilder CafeName = new StringBuilder(256);
                    StringBuilder AutoDel = new StringBuilder(256);

                    MyLibrary.File.Config.GetPrivateProfileString("Setting", "MenuID", "", MenuID, 256, info);
                    MyLibrary.File.Config.GetPrivateProfileString("Setting", "CafeID", "", CafeID, 256, info);
                    MyLibrary.File.Config.GetPrivateProfileString("Setting", "CafeName", "", CafeName, 256, info);
                    MyLibrary.File.Config.GetPrivateProfileString("Setting", "AutoDelete", "", AutoDel, 256, info);


                    List<String> Title = new List<string>();
                    List<String> Content = new List<string>();

                    StreamReader Sr = new StreamReader(Directs[i].FullName + "\\Title.inf", Encoding.Default);

                    for (int ib = 0; !Sr.EndOfStream; ib++)
                    {
                        Title.Add(Sr.ReadLine());
                    }
              //      MessageBox.Show(Directs[i].FullName);
                    FileInfo[] di = new DirectoryInfo(Directs[i].FullName + "\\ContentList\\").GetFiles();
                    for (int ib = 0; ib < di.Length; ib++)
                    {
          //              MessageBox.Show(di[ib].Name);
                        Content.Add(di[ib].Name);
                    }


                    if (AutoDel.ToString() == "True")
                    {
                        Sc.AutoDel.Add(true);
                    }
                    else
                    {
                        Sc.AutoDel.Add(false);
                    }

                    Sc.CafeID.Add(CafeID.ToString());
                    Sc.CafeName.Add(CafeName.ToString());
                    Sc.MenuID.Add(MenuID.ToString());
                    Sc.Tag.Add(Directs[i].Name);
                    Sc.SetTitle(Title);
                    Sc.SetCotent(Content);
                    Sc.Article.Add(" ");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #region

        bool BigCheck = true;
        int Now = 0;
        private void CmdBig()
        {
            if (BigCheck == false)
            {
                Beauty.ControlMove Cm = new Beauty.ControlMove();

                Cm.Move(materialRaisedButton1, new Point(3, 3), 12);
                Cm.Move(materialRaisedButton3, new Point(3, 93), 12);
                Cm.Move(materialRaisedButton4, new Point(242, 93), 12);

                Cm.Size(materialRaisedButton1, new Size(465, 84), 12);
                Cm.Size(materialRaisedButton3, new Size(226, 84), 12);
                Cm.Size(materialRaisedButton4, new Size(226, 84), 12);
                BigCheck = true;
            }
        }
        private void CmdSmall()
        {
            if (BigCheck == true)
            {
                Beauty.ControlMove Cm = new Beauty.ControlMove();

                Cm.Size(materialRaisedButton1, new Size(154, 82), 12);
                Cm.Size(materialRaisedButton3, new Size(154, 38), 12);
                Cm.Size(materialRaisedButton4, new Size(154, 38), 12);

                Cm.Move(materialRaisedButton1, new Point(3, 3), 12);
                Cm.Move(materialRaisedButton3, new Point(3, 91), 12);
                Cm.Move(materialRaisedButton4, new Point(3, 135), 12);

                
                BigCheck = false;
            }
        }
        private void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            Beauty.ControlMove Cm = new Beauty.ControlMove();
            if (Now == 0)
            {
                CmdSmall();
                Now = 1;
                panel2.Visible = true;
                Cm.Size(panel2, new Size(305,174), 12);
                
                // Panel2 나타나게
            }
            else if (Now != 1)
            {
                if (Now == 3)
                {
                    Cm.Size(panel3, new Size(0,0), 12);
                    panel3.Visible = false;
                }else if (Now == 4)
                {
                    Cm.Size(panel4, new Size(0, 0), 12);
                    panel4.Visible = false;
                }
                panel2.Visible = true;
                Cm.Size(panel2, new Size(305, 174), 12);
                
                // Panel2 나타나게
                Now = 1;
            }
            else
            {
                Now = 0;
                Cm.Size(panel2, new Size(0,0), 12);
                panel2.Visible = false;
                // Panel2 사라지게
                CmdBig();
            }
        }
        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            
            Beauty.ControlMove Cm = new Beauty.ControlMove();
            if (Now == 0)
            {
                CmdSmall();
                Now = 3;
                panel3.Visible = true;
                Cm.Size(panel3, new Size(305, 174), 12);
                
                // Panel4 나타나게
            }
            else if (Now != 3)
            {
                if (Now == 1)
                {
                    Cm.Size(panel2, new Size(0, 0), 12);
                    panel2.Visible = false;
                }
                else if (Now == 4)
                {
                    Cm.Size(panel4, new Size(0, 0), 12);
                    panel4.Visible = false;
                }
                panel3.Visible = true;
                Cm.Size(panel3, new Size(305, 174), 12);
                
                // Panel4 나타나게
                Now = 3;
            }
            else
            {
                Now = 0;
                Cm.Size(panel3, new Size(0,0), 12);
                panel3.Visible = false;
                // Panel4 사라지게
                CmdBig();
            }
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            Beauty.ControlMove Cm = new Beauty.ControlMove();
            if (Now == 0)
            {
                CmdSmall();
                Now = 4;
                panel4.Visible = true;
                Cm.Size(panel4, new Size(305, 174), 12);
                // Panel5 나타나게
            }
            else if (Now != 4)
            {
                if (Now == 1)
                {
                    Cm.Size(panel2, new Size(0, 0), 12);
                    panel2.Visible = false;
                }
                else if (Now == 3)
                {
                    Cm.Size(panel3, new Size(0, 0), 12);
                    panel3.Visible = false;
                }
                panel4.Visible = true;
                Cm.Size(panel4, new Size(305, 174), 12);
                // Panel5 나타나게
                Now = 4;
            }
            else
            {
                Now = 0;
                Cm.Size(panel4, new Size(0,0), 12);
                panel4.Visible = false;
                // Panel2 사라지게
                CmdBig();
            }
        }
#endregion
        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Start http://blog.naver.com/aoikazto");
        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void Label_ID_Click(object sender, EventArgs e)
        {

        }
    }
}
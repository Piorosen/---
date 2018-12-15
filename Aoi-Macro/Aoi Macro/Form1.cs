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
using System.IO;

namespace Aoi_Macro
{
    public partial class Form1 : Form
    {
        bool REPEAT = false;

        List<UInt16> Main_List = new List<UInt16>();/******************************************
                                                       * 
                                                       *    true = 키보드 입력
                                                       * 
                                                       *    false = 마우스 입력
                                                       *
                                                       *****************************************/
        Mouses mouse = new Mouses();
        Keyboards keyboard = new Keyboards();


        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        private const uint LBUTTONDOWN = 0x0002;   // 왼쪽 마우스 버튼 눌림
        private const uint LBUTTONUP = 0x0004;   // 왼쪽 마우스 버튼 떼어짐

        class Mouses
        {
            public List<int> Button = new List<int>();          /*******************************
                                                                 * 
                                                                 *    0 = 마우스 왼쪽   클릭
                                                                 *    1 = 마우스 가운데 클릭
                                                                 *    2 = 마우스 오른쪽 클릭
                                                                 *    
                                                                 *******************************/
            public List<Point> Mouse = new List<Point>();       /*
                                                                 *    마우스 좌표를 저장하는 곳임!
                                                                 * 
                                                                 ******************************/
        }
        class Keyboards
        {
            public List<String> Keyboard = new List<String>();
        }


        public Form1()
        {
            InitializeComponent();
            listBox1.Visible = false;
            if (Record_List.SelectedIndex == -1) Record_List.SelectedIndex = 0;
            Main_List.Add(32000);
            Key.FormClosing += new FormClosingEventHandler(Key_FormClosing);
        }

        #region 매크로 기능
        #region Mouse 매크로 구현!
        delegate void del_Mouse(Point point, int Key);
        private void ListBox(Point point, int Key)
        {
            int del = 0;
            for (int i = 0; i <= Record_List.SelectedIndex; i++)
            {
                if (Main_List[i] == 0)
                {
                    del += 1;
                }
            }
            mouse.Button.Insert(del, Key);
            mouse.Mouse.Insert(del, point);
            Main_List.Insert(Record_List.SelectedIndex + 1, 0);
            if (Record_List.SelectedIndex == -1) Record_List.SelectedIndex = 0;
            switch (Key)
            {
                case 0:
                    Record_List.Items.Insert(Record_List.SelectedIndex + 1, "마우스 : " + point.ToString() + " : 왼쪽 클릭");
                    break;
                case 1:
                    Record_List.Items.Insert(Record_List.SelectedIndex + 1, "마우스 : " + point.ToString() + " : 가운데 클릭");
                    break;
                case 2:
                    Record_List.Items.Insert(Record_List.SelectedIndex + 1, "마우스 : " + point.ToString() + " : 오른쪽 클릭");
                    break;
            }
            Record_List.SelectedIndex += 1;
           // Console.WriteLine("마우스 : " + del +"번째" + "Point : " + point.ToString());
        }
        private void Mouse_Thread_Tick(object sender, EventArgs e)
        {
            switch (Control.MouseButtons)
            {
                case MouseButtons.Left:
                    Invoke(new del_Mouse(ListBox), new Object[] {Control.MousePosition, 0 });
                    Mouse_Thread.Stop();
                    return;

                case MouseButtons.Middle:
                    Invoke(new del_Mouse(ListBox), new Object[] {Control.MousePosition, 1 });
                    Mouse_Thread.Stop();
                    return;

                case MouseButtons.Right:
                    Invoke(new del_Mouse(ListBox), new Object[] {Control.MousePosition, 2 });
                    Mouse_Thread.Stop();
                    return;
                default:
                    break;
            }
        }
        private void Mouse(object sender, EventArgs e)
        {
            Mouse_Thread.Start();
        }
        #endregion
        #region Keyboard 구현 완료!
        delegate void del_Keyboard(String Key);
        private void ListBox(String Key)
        {
            int del = 0;
            for (int i = 0; i <= Record_List.SelectedIndex; i++)
            {
                if (Main_List[i] == 1)
                {
                    del += 1;
                }
            }
            keyboard.Keyboard.Insert(del, Key);
            Main_List.Insert(Record_List.SelectedIndex + 1, 1);
            if (Record_List.SelectedIndex == -1) Record_List.SelectedIndex = 0;
            Record_List.Items.Insert(Record_List.SelectedIndex + 1, "키보드 : \"" + Key.ToString() + "\" 를 입력함.");
            Record_List.SelectedIndex += 1;
          //  Console.WriteLine("키보드 : " + del + "번째" + "키보드 : " + Key.ToString());
        }
        Keyborad Key = new Keyborad();
        private void Keyboard(object sender, EventArgs e)
        {
            Key.Location = new Point(new Form1().Location.X - 20, new Form1().Location.Y - 20);
            Key.ShowDialog();
        }

        void Key_FormClosing(object sender, FormClosingEventArgs e)
        {
            Invoke(new del_Keyboard(ListBox), new Object[] {Key.Text});
        }

        #endregion
        #endregion

        #region 실행!


        private void Run(object sender, EventArgs e)
        {
            int k = Main_List.Count;
            int i = 0, j = 0;
                for (int a = 0; a < k; a++)
                {
                    //  Console.WriteLine(Main_List[a].ToString());
                    Record_List.SelectedIndex = a;
                    if (Main_List[a] == 0)
                    {
                        System.Windows.Forms.Cursor.Position = mouse.Mouse[i];
                        mouse_event(LBUTTONDOWN, 0, 0, 0, 0);
                        System.Threading.Thread.Sleep(5);
                        mouse_event(LBUTTONUP, 0, 0, 0, 0);
                        System.Threading.Thread.Sleep(5);
                        //  Console.WriteLine("마우스 좌표 : " + mouse.Mouse[i].ToString());
                        i += 1;
                    }
                    else if (Main_List[a] == 1)
                    {
                        System.Threading.Thread.Sleep(5);
                        SendKeys.SendWait(keyboard.Keyboard[j]);
                        //    Console.WriteLine("키보도 입력 : " + keyboard.Keyboard[j].ToString());
                        j += 1;
                    }
                    else if (Main_List[a] == 2)
                    {
                        Record_List.SelectedIndex = a;
                        System.Threading.Thread.Sleep(100);
                        // Console.WriteLine("딜레이");
                    }
                    else if (Main_List[a] == 32000)
                    {
                        // Console.WriteLine("시작");
                        continue;
                    }
                }
        }
        #endregion

        #region 폼 종료시
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("개발자 블로그 : http://blog.naver.com/aoikazto\n개발자 : Aoi Kazto가 개발!");

        }
        #endregion

        #region 추가, 삭제 기능
        private void Record_List_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listBox1.Location = PointToClient(Control.MousePosition);
                listBox1.Visible = true;
            }
            else if (e.Button == MouseButtons.Left)
            {

                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listBox1.GetSelected(0))
                {
                    if (Record_List.Items.Count == 1) { listBox1.Visible = false; return; }
                    if (Record_List.SelectedIndex == 0) { listBox1.Visible = false;  return; }
                    listBox1.Visible = false;

                    UInt16 Data = Main_List[Record_List.SelectedIndex];
                    if (Data == 0)
                    {
                        int del = 0;
                        for (int i = 0; i <= Record_List.SelectedIndex; i++)
                        {
                            if (Main_List[i] == 0)
                            {
                                del += 1;
                            }
                        } if (del < 0) MessageBox.Show("삭제 할려는것이 예상외 입니다.");
               //         Console.WriteLine(mouse.Mouse[del - 1].ToString() + "삭제");
                        mouse.Mouse.RemoveAt(del - 1);
                        mouse.Button.RemoveAt(del - 1);
                    }
                    else if (Data == 1)
                    {
                        int del = 0;
                        for (int i = 1; i <= Record_List.SelectedIndex; i++)
                        {
                            if (Main_List[i] == 1)
                            {
                                del += 1;
                            }
                        } if (del < 0) MessageBox.Show("삭제 할려는것이 예상외 입니다.");
                 //       Console.WriteLine(keyboard.Keyboard[del - 1].ToString() + "삭제");
                        keyboard.Keyboard.RemoveAt(del - 1);
                    }
                    else if (Data == 2)
                    {
                      //  Console.WriteLine("삭제 : 딜레이");
                    }
                    Main_List.RemoveAt(Record_List.SelectedIndex);
                    int abcde =  Record_List.SelectedIndex;
                    Record_List.Items.RemoveAt(Record_List.SelectedIndex);
                    Record_List.SelectedIndex = abcde - 1;
                }
                else if (listBox1.GetSelected(1))
                {
                    if (Record_List.SelectedIndex == -1) Record_List.SelectedIndex = 0;
                    listBox1.Visible = false;
             //       Console.WriteLine("추가 : 딜레이");
                    Record_List.Items.Insert(Record_List.SelectedIndex + 1, "딜레이 : 0.1초 대기");
                    Record_List.SelectedIndex = Record_List.SelectedIndex + 1;
                    Main_List.Insert(Record_List.SelectedIndex + 1, 2);
                }
                else if (listBox1.GetSelected(3))
                {
                    listBox1.Visible = false;
                }
                else if (listBox1.GetSelected(5))
                {
                    REPEAT = !REPEAT;
                    listBox1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void Record_List_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            new Screen_Beauty.Screen(this, 320, 350, 10, 10, 1, 5, 320, 0).WHStart();
        }



    }

    
}

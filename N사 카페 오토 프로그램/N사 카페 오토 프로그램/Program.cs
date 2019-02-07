using System;
using System.Threading;
using System.Windows.Forms;

namespace N사_카페_오토_프로그램
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        

[STAThread]
        static void Main()
        {


            bool New;
            Mutex mutex = new Mutex(true, "MutexName", out New);
            if (New)
            {
                Check ck = new Check();
                if (!ck.UserCheck())
                {
                    Application.Exit();
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("중복 실행은 금지 되어 있습니다.");
                Application.Exit();
            }
        }
    }
}

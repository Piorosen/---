using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace AoiKazto
{
    namespace Hook
    {
        public enum KeyEventType
        {
            KEYDOWN, KEYUP, CLICK
        }

        public delegate void del(Keys k, KeyEventType keyevent);
        public delegate void del_(Point p, MouseMessages keyevent);
        public class KeyboardHook
        {
            public static event del KeyPressed;

            [DllImport("user32.dll")]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
            [DllImport("user32.dll")]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
            [DllImport("user32.dll")]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
            [DllImport("User32.dll")]
            private static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);
            [DllImport("imm32.dll")]
            public static extern bool ImmGetConversionStatus(IntPtr hImc, out int lpConversion, out int lpSentence);

            [DllImport("imm32.dll")]
            public static extern IntPtr ImmGetContext(IntPtr hWnd);

            public static bool isIMEKorean(IntPtr hWnd)
            {
                IntPtr _hImc = ImmGetContext(hWnd);
                int lpConversion;
                int lpSentence;
                ImmGetConversionStatus(_hImc, out lpConversion, out lpSentence);
                return lpConversion == 0 ? false : true;
            }
            private const int WH_KEYBOARD_LL = 13;
            private const int WM_KEYDOWN = 0x0100;
            private const int WM_KEYUP = 0x101;
            private const int WM_SYSKEYDOWN = 0x104;
            private static LowLevelKeyboardProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;
            public static bool isHide = false;
            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0)
                {
                    if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
                    {
                        int vkCode = Marshal.ReadInt32(lParam);
                        KeyPressed((Keys)vkCode, KeyEventType.KEYDOWN);
                        if ((Keys)vkCode == Keys.F11)
                        {
                            isHide = true;
                        }
                        else if((Keys)vkCode == Keys.F12)
                        {
                            isHide = false;
                        }
                    }
                    else if (wParam == (IntPtr)WM_KEYUP)
                    {
                        int vkCode = Marshal.ReadInt32(lParam);
                        KeyPressed((Keys)vkCode, KeyEventType.KEYUP);
                    }
                }

                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
            public static void HookStart()
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
            public static void HookEnd()
            {
                UnhookWindowsHookEx(_hookID);
            }
            public static void MakeKeyEvent(Keys k, KeyEventType keyEvent)
            {
                switch (keyEvent)
                {
                    case KeyEventType.KEYDOWN:
                        keybd_event((byte)k, 0x00, 0x00, 0);
                        break;
                    case KeyEventType.KEYUP:
                        keybd_event((byte)k, 0x00, 0x02, 0);
                        break;
                    case KeyEventType.CLICK:
                        keybd_event((byte)k, 0x00, 0x00, 0);
                        keybd_event((byte)k, 0x00, 0x02, 0);
                        break;
                }
            }
        }
        public enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_MOUSEHWHEEL = 0x020E,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }
        
        public class MouseHook
        {
            public static event del_ MouseEvent;
            public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

            public static HookProc MouseHookProcedure;	
            static int hHook = 0;
            public const int WH_MOUSE = 7;
            [DllImport("user32.dll")]
            static extern void keybd_event(byte vk, byte scan, int flags, ref int extrainfo);
            [DllImport("user32.dll")]
            static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern bool UnhookWindowsHookEx(int idHook);
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll")] // DllImport  <= D와 I는 대문자 입니다.
            static extern int SetCursorPos(int x, int y);

            [StructLayout(LayoutKind.Sequential)]
            public class MouseHookStruct
            {
                public Point pt;
                public int hwnd;
                public int wHitTestCode;
                public int dwExtraInfo;
            }

            public static int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
            {
                MouseHookStruct MyMouseHookStruct =
                                        (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                if (nCode < 0)
                {
                    return CallNextHookEx(hHook, nCode, wParam, lParam);
                }
                else
                {
                    MouseEvent(new Point(MyMouseHookStruct.pt.X, MyMouseHookStruct.pt.Y), (MouseMessages)wParam);
                    return CallNextHookEx(hHook, nCode, wParam, lParam);
                }
            }

            public static void HookStart()//(hHook == 0)
            {
                // Create an instance of HookProc.
                MouseHook.MouseHookProcedure = new HookProc(MouseHookProc);

                hHook = SetWindowsHookEx(WH_MOUSE,
                            MouseHookProcedure,
                            (IntPtr)0,
                            AppDomain.GetCurrentThreadId());
                //If SetWindowsHookEx fails.
                if (hHook == 0)
                {
                    MessageBox.Show("SetWindowsHookEx Failed");
                    return;
                }
            }
            public static void HookEnd()
            {
                bool ret = UnhookWindowsHookEx(hHook);
                //If UnhookWindowsHookEx fails.
                if (ret == false)
                {
                    return;
                }
                hHook = 0;
            }

            public static void MakeMouseEvent()
            {
                MakeMouseEvent(MouseMessages.WM_LBUTTONDOWN);
                MakeMouseEvent(MouseMessages.WM_LBUTTONUP);
            }
            public static void MakeMouseEvent(MouseMessages type)
            {
                MakeMouseEvent(new Point(0, 0), type);
            }
            enum MouseEventType
            {
                MOUSEEVENTF_ABSOLUTE = 0x8000,
                MOUSEEVENTF_LEFTDOWN = 0x0002,
                MOUSEEVENTF_LEFTUP = 0x0004,
                MOUSEEVENTF_MIDDLEDOWN = 0x0020,
                MOUSEEVENTF_MIDDLEUP = 0x0040,
                MOUSEEVENTF_MOVE = 0x0001,
                MOUSEEVENTF_RIGHTDOWN = 0x0008,
                MOUSEEVENTF_RIGHTUP = 0x0010,
                MOUSEEVENTF_WHEEL = 0x0800,
            }
            public static void MakeMouseEvent(Point p, MouseMessages type)
            {
                switch (type)
                {
                    case MouseMessages.WM_LBUTTONDOWN:
                        SetCursorPos(p.X, p.Y);
                        mouse_event((uint)MouseEventType.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        break;
                    case MouseMessages.WM_LBUTTONUP:
                        SetCursorPos(p.X, p.Y);
                        mouse_event((uint)MouseEventType.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        break;
                    case MouseMessages.WM_RBUTTONDOWN:
                        SetCursorPos(p.X, p.Y);
                        mouse_event((uint)MouseEventType.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                        break;
                    case MouseMessages.WM_RBUTTONUP:
                        SetCursorPos(p.X, p.Y);
                        mouse_event((uint)MouseEventType.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                        break;
                    case MouseMessages.WM_MOUSEMOVE:
                        //SetCursorPos(p.X, p.Y);
                        //mouse_event((uint)MouseEventType.MOUSEEVENTF_MOVE, (uint)p.X, (uint)p.Y, 0, 0);
                        break;
                    case MouseMessages.WM_MBUTTONDOWN:
                        SetCursorPos(p.X, p.Y);
                        mouse_event((uint)MouseEventType.MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                        break;
                    case MouseMessages.WM_MBUTTONUP:
                        SetCursorPos(p.X, p.Y);
                        mouse_event((uint)MouseEventType.MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
                        break;
                    case MouseMessages.WM_MOUSEHWHEEL:
                        SetCursorPos(p.X, p.Y);
                        mouse_event((uint)MouseEventType.MOUSEEVENTF_WHEEL, 0, 0, 0, 0);
                        break;
                }
            }
        }
    }
}

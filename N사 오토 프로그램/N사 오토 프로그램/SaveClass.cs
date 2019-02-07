using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N사_오토_프로그램
{
    class SaveClass
    {
        private List<List<String>> Title = new List<List<string>>();
        private List<int> TitleInt = new List<int>();

        private List<List<String>> Content = new List<List<string>>();
        private List<int> ContentInt = new List<int>();


        public List<String> Tag = new List<string>();

        public List<String> MenuID = new List<String>();

        public List<String> CafeID = new List<string>();
        public List<String> CafeName = new List<string>();

        public List<String> Article = new List<String>();

        public List<bool> AutoDel = new List<bool>();


      
        public void Delete(int i)
        {
            Title.RemoveAt(i);
            TitleInt.RemoveAt(i);

            Content.RemoveAt(i);
            ContentInt.RemoveAt(i);

            MenuID.RemoveAt(i);

            CafeID.RemoveAt(i);
            CafeName.RemoveAt(i);

            Article.RemoveAt(i);
            AutoDel.RemoveAt(i);


        }

        public void SetTitle(List<String> Data)
        {
            Title.Add(Data);
            TitleInt.Add(-1);
        }
        public String GetTitle(int i)
        {
            if (TitleInt[i] < Title[i].Count - 1)
            {
                TitleInt[i] += 1;
            }
            else
            {
                TitleInt[i] = 0;
            }
            return Title[i][TitleInt[i]];
        }


        public void SetCotent(List<String> Data)
        {
            Content.Add(Data);
            ContentInt.Add(-1);
        }
        public String GetContent(int i)
        {
            if (ContentInt[i] < Content[i].Count - 1)
            {
                ContentInt[i] += 1;
            }
            else
            {
                ContentInt[i] = 0;
            }
            return Content[i][ContentInt[i]];
        }

    }
}

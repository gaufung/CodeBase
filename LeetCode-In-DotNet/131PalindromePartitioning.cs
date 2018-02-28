 public class Solution
    {
        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> res=new List<IList<string>>();
            IList<string> item=new List<string>();
            Track(s,res,item);
            return res;
        }

        private void Track(string str, IList<IList<string>> res, IList<string> item)
        {
            if (string.IsNullOrEmpty(str))
            {
                res.Add(new List<string>(item));
                return;
            }
            for (int i = 0; i < str.Length; i++)
            {
                string firstPart = str.Substring(0, i + 1);
                if (IsPalindrome(firstPart))
                {
                    item.Add(firstPart);
                    string secondPart = str.Substring(i + 1);
                    Track(secondPart, res, item);
                    item.RemoveAt(item.Count-1);
                }
                //else
               //{
               //    item.Clear();
               //}
            }
        }

        private bool IsPalindrome(string str)
        {
            int header = 0;
            int tailer = str.Length - 1;
            while (header < tailer)
            {
                if (str[header] != str[tailer])
                    return false;
                tailer--;
                header++;
            }
            return true;
        }
    }
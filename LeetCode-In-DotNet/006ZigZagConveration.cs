public class Solution {
    public string Convert(string s, int numRows) {
         //如果只有一行
        if(numRows==1) return Convert(s);
        if(numRows>=s.Length)return Convert(s);
        if(string.IsNullOrEmpty(s)) Convert(s);
        //如果超过一行
        List<CharBox> boxes=new List<CharBox>();
        int i=0;
        while(true)
        {
            CharBox box=new CharBox(numRows);
            while(!box.IsFull()&&i<s.Length)
            {
                box.Insert(s[i]);
                i++;
            }
         
            boxes.Add(box);
            if(i==s.Length)
                break;
        }
        string res=string.Empty;
        for(int j=0;j<numRows;j++)
        {
            for(int k=0;k<boxes.Count;k++)
            {
                res+=boxes[k].GetString(j).Trim();
            }
        }
        return res;
    }
     string Convert(string s)
    {
        return s;
    }
    class CharBox
    {
        private char[] _chars;
        private int _count;
        private int _row;
        public CharBox(int row)
        {
            _row=row;
            _chars=new char[_row*2-2];
        }
        public bool IsFull()
        {
            return _chars.Length==_count;
        }
        public void Insert(char c)
        {
            _chars[_count++]=c;
        }
        public string GetString(int row)
        {
            if(row==0)
            {
                if(_chars[0]=='\0')
                    return string.Empty;
                else
                    return new string(_chars[0],1);
            }
            if(row==(_row-1))
            {
                if(_chars[row]=='\0')
                    return string.Empty;
                else
                    return new string(_chars[row],1);
            }
            if(_chars[row]=='\0')
                return string.Empty;
            if(_chars[2*_row-row-2]=='\0')
                return new string(_chars[row],1);
            return new string(new char[]{_chars[row],_chars[2*_row-row-2]}); 
           
        }
    }
}
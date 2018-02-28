public class Solution {
    public int MyAtoi(string str) {
        if(string.IsNullOrEmpty(str))return 0;
        string s=str.Trim();
        List<char> chars=new List<char>();
        //sign
        if(!CheckFirstChar(s[0]))
            return 0;
        else
            chars.Add(s[0]);
        //chars
        int i=1;
        while(i<s.Length&&CheckNumberChar(s[i]))
        {
            chars.Add(s[i]);
            i++;
        }
        string res=string.Empty;
        int sign=1;
        //如果包含符号位
        if(CheckSign(chars[0]))
        {
            if(chars[0]=='-')
                sign=-1;
            //如果是负数
            if(chars.Count>1)
                res=new string(chars.ToArray(),0,chars.Count);
        }
        else
        {
            res=new string(chars.ToArray(),0,chars.Count);
        }
        int value=0;
        try
        {
            value=Convert.ToInt32(res);
        }
        catch(OverflowException)
        {
            if(sign==1)
                value=Int32.MaxValue;
            if(sign==-1)
                value=Int32.MinValue;
        }
        catch(Exception)
        {
            value=0;
        }
        return value;
    }
    bool CheckFirstChar(char c)
    {
        return CheckSign(c) || CheckNumberChar(c);
    }
    bool CheckSign(char c)
    {
        return c=='+'||c=='-';
    }
    bool CheckNumberChar(char c)
    {
        return c>='0'&&c<='9';
    }
}
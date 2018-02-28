public class Solution {
    public bool IsPalindrome(string s) {
        if(string.IsNullOrEmpty(s))
            return true;
        int header=0;
        int tailer=s.Length-1;
        while(header<tailer)
        {
            if(!IsAlphaOrDigit(s[header])||!IsAlphaOrDigit(s[tailer]))
            {
                if(!IsAlphaOrDigit(s[header]))
                    header++;
                if(!IsAlphaOrDigit(s[tailer]))
                    tailer--;
            }
            else
            {
                if(IsEqual(s[header],s[tailer]))
                {
                    header++;
                    tailer--;
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }
    private bool IsEqual(char a,char b)
    {
        if(a==b)
            return true;
        if(IsAlpha(a)&&IsAlpha(b))
            return IsEqualIgnoreCase(a,b);
        return false;
    }
    private bool IsEqualIgnoreCase(char a,char b)
    {
        int gap=Math.Abs(a-b);
        return gap == 0 || gap == ('a'-'A');
    }
    private bool IsAlphaOrDigit(char a)
    {
        return IsAlpha(a) || IsDigit(a) ;
    }
    private bool IsAlpha(char a)
    {
        return (a>='a' && a<='z') || (a>='A'&&a<='Z');
    }
    private bool IsDigit(char a)
    {
        return a>='0' && a<='9';
    }
}
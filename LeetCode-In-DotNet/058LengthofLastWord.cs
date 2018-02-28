public class Solution {
    public int LengthOfLastWord(string s) {
        if(string.IsNullOrEmpty(s)) return 0;
        bool isCount=false;
        int res=0;
        for(int i=s.Length-1;i>=0;i--)
        {
            if(!IsAlphabet(s[i]))
            {
                if(isCount) break;
            }
            else{
                isCount=true;
                res++;
            }
        }
        return res;
    }
    bool IsAlphabet(char c)
    {
        return c>='a'&&c<='z' || c>='A' && c<='Z';
    }
}
public class Solution {
    public int StrStr(string haystack, string needle) {
        //kmp
        if(haystack==null || needle==null) return -1;
        if(haystack==needle) return 0;
        if(haystack.Length==0) return -1;
        if(needle.Length==0) return 0;
        int[] next=BuildNext(needle);
        int n=haystack.Length;
        int m=needle.Length;
        int i=0;
        int j=0;
        while(j<m&&i<n)
        {
            if(0>j||haystack[i]==needle[j])
            {
                i++;
                j++;
            }
            else
            {
                j=next[j];
            }
        }
        if(j!=m)return -1;
        return i-j;
        
    }
    
    private int[] BuildNext(string pattern)
    {
        int[] next=new int[pattern.Length];
        int t=next[0]=-1;
        int j=0;
        while(j<pattern.Length-1)
        {
            if(t<0||pattern[j]==pattern[t])
            {
                j ++;
                t ++;
                next[j]=t;
            }
            else
                t=next[t];
        }
        return next;
        
    }
}
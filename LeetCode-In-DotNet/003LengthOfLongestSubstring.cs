public class Solution {
    public int LengthOfLongestSubstring(string s) {
         Dictionary<char,int> ht=new Dictionary<char,int>();
          
            int res=0;//result
            int cur=0;
            for(int i=0;i<s.Length;i++)
            {
                if(!ht.ContainsKey(s[i]))
                {
                    ht.Add(s[i],i);
                    res=Math.Max(res,ht.Count);
                }
                else
                {
                    res=Math.Max(res,ht.Count);
                    int repeatIndex=ht[s[i]];
                    for(int j=cur;j<=repeatIndex;j++)
                    {
                        ht.Remove(s[j]);
                    }
                    ht.Add(s[i],i);
                    cur=repeatIndex+1;
                }                
            }
            return res;
    }
}
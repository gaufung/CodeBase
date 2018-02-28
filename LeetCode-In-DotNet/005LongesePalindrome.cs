public class Solution {
    public string LongestPalindrome(string s) {
        if(string.IsNullOrEmpty(s))return string.Empty;
            int res=1;
            int start=0,stop=0;
            for (int i = 1; i < s.Length; i++)
            {
                //odd
                int left=i-1;
                int right=i+1;
                var resOdd=Scan(s,ref left,ref right);
                if (resOdd>res)
                {
                    start=left+1;
                    stop=right-1;
                    res=resOdd;
                }
                //even to right
                left=i;
                right=i+1;
                var resEven=Scan(s,ref left,ref right);
                if(resEven>res)
                {
                    start=left+1;
                    stop=right-1;
                    res=resEven;
                }   
                //even to left
                left=i-1;
                right=i;
                var resEvenLeft=Scan(s,ref left,ref right);
                if(resEvenLeft>res)
                {
                    start=left+1;
                    stop=right-1;
                    res=resEvenLeft;
                }   
            }
            return s.Substring(start,stop-start+1);
    }
    private int Scan(string s,ref int left,ref int right)
    {
            //left->the left pointer
            //right -> the right pointer
            while (left>=0&&right<s.Length&&s[left]==s[right])
            {
                left--;
                right++;
            }
            return right-left-1;
     }
}
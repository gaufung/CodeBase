public class Solution {
    public bool IsPalindrome(int x) {
        if(x<0) return false;
        int res=0;
        int num=x;
        while(num>0)
        {
            res=res*10+num%10;
            num/=10;
        }
        return res==x;
    }
}
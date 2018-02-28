public class Solution {
    public int ClimbStairs(int n) {
        if(n<1)return 0;
        if(n==1)return 1;
        if(n==2) return 2;
        int f=1;
        int g=2;
        int counter=3;
        while(counter<=n)
        {
            g=f+g;
            f=g-f;
            counter++;
        }
        return g;
        
    }
}
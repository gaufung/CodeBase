public class Solution {
    public int MaxArea(int[] height) {
        int res=0;
        int m=0;
        int n=height.Length-1;
        while(m<n)
        {
            if(height[m]<height[n])
            {
                res=Math.Max(res,(n-m)*Math.Min(height[m],height[n]));
                m++;
            }
            else
            {
                res=Math.Max(res,(n-m)*Math.Min(height[m],height[n]));
                n--;
            }
        }
        return res;
        
    }
}
public class Solution {
    public int[,] GenerateMatrix(int n) {
        int[,] res=new int[n,n];
        int left=0;
        int right=0;
        int top=0;
        int bottom=0;
        int seed=0;
        while(true)
        {
            if(left+right>=n&&top+bottom>=n)
                break;
            if(top+bottom<n)
            {
                for(int i=left;i<n-right;i++)
                    res[top,i]=++seed;
                top++;
            }
            if(right+left<n)
            {
                for(int j=top;j<n-bottom;j++)
                    res[j,n-right-1]=++seed;
                right++;
            }
            if(top+bottom<n)
            {
                for(int k=n-right-1;k>=left;k--)
                    res[n-bottom-1,k]=++seed;
                bottom++;
            }
            if(right+left<n)
            {
                for(int l=n-bottom-1;l>=top;l--)
                    res[l,left]=++seed;
                left++;
            }
        }
        return res;
    }
}
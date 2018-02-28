public class Solution {
    public int UniquePaths(int m, int n) {
        int[,] paths=new int[m,n];
        //初始化操作
        for(int i=0;i<m;i++)
            paths[i,0]=1;
        for(int j=0;j<n;j++)
            paths[0,j]=1;
        for(int row=1;row<m;row++)
        {
            for(int column=1;column<n;column++)
            {
                 paths[row,column]=paths[row-1,column]+paths[row,column-1];
            }
        }
        return paths[m-1,n-1];
    }
}
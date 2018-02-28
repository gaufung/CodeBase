public class Solution {
    public int MinPathSum(int[,] grid) {
        int height=grid.GetLength(0);
        int width=grid.GetLength(1);
        int[,] sums=new int[height,width];
        //init 
        sums[0,0]=grid[0,0];
        for(int i=1;i<height;i++)
            sums[i,0]=sums[i-1,0]+grid[i,0];
        for(int j=1;j<width;j++)
            sums[0,j]=sums[0,j-1]+grid[0,j];
        //calculate the sum
        for(int row=1;row<height;row++)
        {
            for(int column=1;column<width;column++)
            {
                int min=Math.Min(sums[row-1,column],sums[row,column-1]);
                sums[row,column]=grid[row,column]+min;
            }
        }
        return sums[height-1,width-1];
    }
}
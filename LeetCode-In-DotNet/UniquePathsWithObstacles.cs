public class Solution {
    public int UniquePathsWithObstacles(int[,] obstacleGrid) {
        int height=obstacleGrid.GetLength(0);
        int width=obstacleGrid.GetLength(1);
        int[,] paths=new int[height,width];
        //init the left-top corner
        paths[0,0]=obstacleGrid[0,0]==0?1:0;
        //init first row and first column
        for(int i=1;i<width;i++)
        {
            if(obstacleGrid[0,i]==1)
                paths[0,i]=0;
            else
                paths[0,i]=paths[0,i-1];
        }
        for(int j=1;j<height;j++)
        {
            if(obstacleGrid[j,0]==1)
                paths[j,0]=0;
            else
                paths[j,0]=paths[j-1,0];
        }
        //init the left corner
        for(int row=1;row<height;row++)
        {
            for(int column=1;column<width;column++)
            {
                if(obstacleGrid[row,column]==1)
                    paths[row,column]=0;
                else
                    paths[row,column]=paths[row-1,column]+paths[row,column-1];
            }
        }
        return paths[height-1,width-1];
    }
}
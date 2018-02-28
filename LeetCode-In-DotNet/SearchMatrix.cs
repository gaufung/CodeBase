public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        int m=matrix.GetLength(0);
        int n=matrix.GetLength(1);
        int pos=Search(matrix,m,target);
        if(pos==-1)return false;
        if(matrix[pos,0]==target)return true;
        pos =Search(matrix,pos,n,target);
        return pos!=-1;
        
    }
    private int Search(int[,] matrix,int m,int target)
    {
        int lo=0;
        int hi=m;
        while(lo<hi)
        {
            int mi=(lo+hi)>>1;
            if(target<matrix[mi,0])
                hi=mi;
            else
                lo=mi+1;
        }
        return --lo;
    }
    private int Search(int[,] matrix,int row,int n,int target)
    {
        int lo=0;
        int hi=n;
        while(lo<hi)
        {
            int mi=(lo+hi)>>1;
            if(target<matrix[row,mi])
                hi=mi;
            else if(target>matrix[row,mi])
                lo=mi+1;
            else 
                return mi;
        }
        return -1;
    }
}
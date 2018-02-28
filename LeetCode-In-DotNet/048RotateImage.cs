public class Solution {
    public void Rotate(int[,] matrix) {
        SwapDiagon(matrix);
        SwapHorizon(matrix);
    }
    private void SwapHorizon(int[,] matrix)
    {
        int n=matrix.GetLength(0);
        for(int i=0;i<n;i++)
        {
            int j=0,k=n-1;
            while(j<k){
                Swap(matrix,i,j,i,k);
                j++;
                k--;
            }
        }
    }
    private void SwapDiagon(int[,] matrix)
    {
        for(int i=0;i<matrix.GetLength(0);i++)
        {
            for(int j=0;j<i;j++)
            {
                Swap(matrix,i,j,j,i);
            }
        }
        
    }
    private void Swap(int[,] matrix,int i,int j,int k,int l)
    {
        int temp=matrix[i,j];
        matrix[i,j]=matrix[k,l];
        matrix[k,l]=temp;
    }
}
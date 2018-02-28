public class Solution {
    public void SetZeroes(int[,] matrix) {
       bool isFirstRowZero=false;
       bool isFirtColumnZero=false;
       int m=matrix.GetLength(0);
       int n=matrix.GetLength(1);
       int i=0;
       int j=0;
       for(i=0;i<n;i++)
       {
           if(matrix[0,i]==0)
           {
               isFirstRowZero=true;
               break;
           }
       }
       for(j=0;j<m;j++)
       {
           if(matrix[j,0]==0)
           {
               isFirtColumnZero=true;
               break;
           }
       }
       for(i=1;i<m;i++)
       {
           for(j=1;j<n;j++)
           {
               if(matrix[i,j]==0)
               {
                   matrix[0,j]=0;
                   matrix[i,0]=0;
               }
           }
       }
       //set zeros
       for(i=1;i<n;i++)
       {
           if(matrix[0,i]==0)
           {
               for(j=0;j<m;j++)
                    matrix[j,i]=0;
           }
       }
       for(j=1;j<m;j++)
       {
           if(matrix[j,0]==0)
           {
               for(i=0;i<n;i++)
                matrix[j,i]=0;
           }
       }
       if(isFirstRowZero)
       {
           for(i=0;i<n;i++)
            matrix[0,i]=0;
       }
       if(isFirtColumnZero)
       {
           for(j=0;j<m;j++)
            matrix[j,0]=0;
       }
       
    }
}
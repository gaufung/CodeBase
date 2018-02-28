/*
* Dynamic programming
* 计算国际象棋中到达(n,n)处的最小步数
*/
using System;
namespace ChessDp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=3;
            int[,] mat=new int[n,n];
            for (int i = 0; i < n; i++)
            {
                mat[0,i]=i;
            }
            for (int j = 0; j < n; j++)
            {
                mat[j,0]=j;
            }
            for (int k = 1; k < n; k++)
            {
                for (int l = 1; l< n; l++)
                {
                    mat[k,l]=System.Math.Min(mat[k-1,l],mat[k,l-1])+1;
                }
            }
            System.Console.WriteLine(mat[n-1,n-1]);
        }
       
        
    }
    
}
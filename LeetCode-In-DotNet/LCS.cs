using System;
namespace Lcs
{
    class Program
    {
        static int[,] c;
        static string str1="cnblog";
        static string str2="belong";
       
        static void Main()
        {
           c=new int[str1.Length+1,str2.Length+1];
           LCS();
           System.Console.WriteLine(c[str1.Length,str2.Length]);
        }  
        static void LCS()
        {
            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    if (str1[i-1]==str2[j-1])
                    {
                        c[i,j]=c[i-1,j-1]+1;
                    }
                    else
                    {
                        c[i,j]=Math.Max(c[i-1,j],c[i,j-1]);
                    }
                }
            }
        }  
    }
}
using System;
namespace FlowLine
{
    class Factor
    {
        private static int[] C1;
        private static int[] C2;
        private static int[] X1;
        private static int[] X2;
        static Factor()
        {
            C1=new int[]{1,3,5,8,7,4,2,6};
            C2=new int[]{2,4,2,6,3,3,3,8};
            X1=new int[]{3,1,2,3,3,3,2};
            X2=new int[]{2,2,4,1,2,1,2};
        }   
        public static int GetC(int i,int j){
            if (i==1)
            {
               return C1[j];
            }
            else
            {
                return C2[j];
            }
        }
        public static int GetX(int i,int j)
        {
            if(i==1)
            {
                return X1[j-1];
            }
            else{
                return X2[j-1];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] t1=new int[8];
            int[] t2=new int[8];
            t1[1]=Factor.GetC(1,0)+Factor.GetC(1,1);
            t2[1]=Factor.GetC(2,0)+Factor.GetC(2,1);
            for (int j =2; j<8; j++)
            {
                t1[j]=Math.Min(t1[j-1]+Factor.GetC(1,j),t2[j-1]+Factor.GetC(1,j)+Factor.GetX(2,j-1));
                t2[j]=Math.Min(t2[j-1]+Factor.GetC(2,j),t1[j-1]+Factor.GetC(2,j)+Factor.GetX(1,j-1));
            }
            System.Console.WriteLine(t1[7]);
            System.Console.WriteLine(t2[7]);
            
        }
    }
}
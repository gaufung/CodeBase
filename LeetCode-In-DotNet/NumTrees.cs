public class Solution {
    public int NumTrees(int n) {
        int[] res=new int[n];
        res[0]=1;
        int counter=1;
        while(counter<n)
        {
            int sum=0;
            for(int i=0;i<=counter;i++)
            {
                int left=i-0;
                int right=counter-i;
                int leftValue=left==0?1:res[left-1];
                int rightValue=right==0?1:res[right-1];
                sum+=leftValue*rightValue;
            }
            res[counter]=sum;
            counter++;
        }
        return res[n-1];
    }
}
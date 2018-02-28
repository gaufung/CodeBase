public class Solution {
    public string GetPermutation(int n, int k) {
        char[] nums=new char[n];
        for(int i=0;i<n;i++)
            nums[i] = (char)('1'+(short)i);
        while(k>1)
        {
            NextPermutation(nums);
            k--;
        }
        return new string(nums);
    }
    private void NextPermutation(char[] nums)
    {
            int length=nums.Length;
            int index=length-1;
            for(;index>0;index--)
            {
                if(nums[index-1]<nums[index])
                    break;
            }
            int i=index==0?0:index-1;
            int minIndex=FindLastMax(index,length-1,nums[i],nums);
            Swap(i,minIndex,nums);
            for(int j=length-1;j>index;j--)
            {
                int maxIndex=FindMax(index,j,nums);
                Swap(maxIndex,j,nums);
            }
        }

        //swap the value
        private void Swap(int left, int right, char[] nums)
        {
            char temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }
        //[left,right]
        private int FindMax(int left, int right, char[] nums)
        {
            int maxIndex = left;
            int maxValue = nums[maxIndex];
            for (int j = left + 1; j <=right; j++)
            {
                if (nums[j] > maxValue)
                {
                    maxValue = nums[j];
                    maxIndex = j;
                }
            }
            return maxIndex;
        }
        //[left,right]
        private int FindLastMax(int left,int right,char value,char[] nums)
        {
            int lastIndex=left;
            for(int j=left+1;j<=right;j++)
            {
                if(nums[j]>value)
                    lastIndex=j;
            }
            return lastIndex;
        }
}
public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        //int comparer=Int32.MaxValue;
        int res=nums[0]+nums[1]+nums[2];
        for(int i=0;i<nums.Length-2;i++)
        {
            if(i>0&&nums[i]==nums[i-1])continue;
            int j=i+1;
            int k=nums.Length-1;
            while(j<k)
            {
                if(nums[i]+nums[j]+nums[k]==target)return target;
                int currentSum=nums[i]+nums[j]+nums[k];
                if(currentSum>target)
                {
                    if(Math.Abs(res-target)>Math.Abs(currentSum-target))res=currentSum;
                    k--;
                    while(nums[k]==nums[k+1]&&j<k)
                    {
                        k--;
                    }
                }
                else
                {
                    if(Math.Abs(res-target)>Math.Abs(currentSum-target))res=currentSum;
                    j++;
                    while(nums[j]==nums[j-1]&&j<k)
                    {
                        j++;
                    }
                }
            }
        }
        return res;
    }
}
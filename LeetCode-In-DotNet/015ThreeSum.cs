public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        List<IList<int>> res=new List<IList<int>>();
        if(nums==null||nums.Length<3)return res;
        Array.Sort(nums);
        if(nums[0]>0||nums[nums.Length-1]<0)return res;
        int header=0,tailer=nums.Length-1;
        for(int i=0;i<nums.Length-2;i++)
        {
            if(i>0&&nums[i]==nums[i-1])continue;
            int j=i+1;
            int k=nums.Length-1;
            while(j<k)
            {
                if(nums[i]+nums[j]+nums[k]>0)
                {
                    k--;
                }
                else
                {
                    if(nums[i]+nums[j]+nums[k]<0)
                    {
                        j++;
                    }
                    else
                    {
                        res.Add(new List<int>(){nums[i],nums[j],nums[k]});
                        j++;
                        k--;
                        while(nums[j]==nums[j-1]&&nums[k]==nums[k++]&&j<k)
                        {
                            j++;
                            k--;
                        }
                    }
                }
            }
        }
        return res;
        
    }
}
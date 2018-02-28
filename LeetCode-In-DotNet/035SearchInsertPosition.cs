public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int res =Search(nums,0,nums.Length,target);
        if(res==-1||nums[res]!=target)
            res++;
        return res;
    }
    private int Search(int[] nums,int lo,int hi,int target)
    {
        while(lo<hi)
        {
            int mi=(lo+hi)>>1;
            if(nums[mi]>target)
                hi=mi;
            else
                lo=mi+1;
        }
        return --lo;
    }
}
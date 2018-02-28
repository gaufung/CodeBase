public class Solution {
    public int RemoveDuplicates(int[] nums) {
        //valid check
        if(nums==null || nums.Length==0) return 0;
        if(1==nums.Length) return 1;
        //two pointer
        int firtstPointer=0;
        int lastPointer=1;
        while(lastPointer!=nums.Length)
        {
            if(nums[firtstPointer]==nums[lastPointer])
            {
                lastPointer++;
            }
            else
            {
                nums[++firtstPointer]=nums[lastPointer];
            }
        }
        return firtstPointer+1;
    }
}
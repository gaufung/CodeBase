public class Solution {
    public int RemoveElement(int[] nums, int val) {
        if(null==nums)return 0;
        if(nums.Length==0) return 0;
        int head=0;
        int tailer=nums.Length-1;
        while(head<tailer)
        {
            if(nums[head]==val)
            {
                nums[head]=nums[tailer--];
            }
            else
            {
                head++;
            }
        }
        if(nums[head]==val)
            return head;
        return head+1;
    }
}
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if(nums.Length<=1)return nums.Length;
        int first=0;
        int second=1;
        bool isTwice=false;
        while(second<nums.Length)
        {
            if(nums[second]!=nums[first])
            {
                nums[++first]=nums[second];
                second++;
                isTwice=false;
            }
            else{
                if(!isTwice)
                {
                    nums[++first]=nums[second];
                    second++;
                    isTwice=true;
                }
                else{
                    second++;
                }
            }
        }
        return first+1;
    }
}
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] res=new int[2];
        int rightIndex=SearchMax(nums,target);
        if(rightIndex==-1||nums[rightIndex]!=target)
        {
            res[0]=-1;
            res[1]=-1;
            return res;
        }
        //remember  to search the target-1 to find the left 
        int leftIndex=SearchMax(nums,target-1)+1;
        res[0]=leftIndex;
        res[1]=rightIndex;
        return res;
    }
    
    //查找到最大的位置
    private int SearchMax(int[] nums,int target)
    {
        int lo=0;
        int hi=nums.Length;
        while(lo<hi)
        {
            int mi=(lo+hi)>>1;
            if(target>=nums[mi])
                lo=mi+1;
            else
                hi=mi;
        }
        return --lo;
    }
}
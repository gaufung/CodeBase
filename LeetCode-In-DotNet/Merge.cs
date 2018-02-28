public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        //由于num1含有大量空间，所以采用从后面开始使用Merge排序
        if(n<=0) return;
        int firstPointer=m-1;
        int secondPointer=n-1;
        int totalPointer=m+n-1;
        while(firstPointer>=0&&secondPointer>=0)
        {
            if(nums1[firstPointer]>=nums2[secondPointer])
            {
                nums1[totalPointer--]=nums1[firstPointer--];
            }
            else{
                 nums1[totalPointer--]=nums2[secondPointer--];
            }
        }
        if(secondPointer>=0)
        {
            while(secondPointer>=0)
            {
                nums1[totalPointer--]=nums2[secondPointer--];
            }
        }
    }
}
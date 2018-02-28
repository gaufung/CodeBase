public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0)
                return DegenerateCase(nums2);
            if (nums2 == null || nums2.Length == 0)
                return DegenerateCase(nums1);
            int total = nums1.Length + nums2.Length;
            if (total % 2 == 0)
            {
                return 0.5 * FindKthSortedArrays(nums1, nums2, total / 2) + 0.5 * FindKthSortedArrays(nums1, nums2, total / 2 + 1);
            }
            else
            {
                return FindKthSortedArrays(nums1, nums2, total / 2 + 1);
            }
        }
        public double DegenerateCase(int[] nums)
        {
            if (nums.Length % 2 == 1)
            {
                return nums[nums.Length / 2];
            }
            else
            {
                return 0.5 * nums[nums.Length / 2] + 0.5 * nums[nums.Length / 2 - 1];
            }
        }
        //find the k-th element
        private int FindKthSortedArrays(int[] nums1, int[] nums2, int k)
        {
            return FindKthSortedArrays(nums1, 0, nums1.Length, nums2, 0, nums2.Length, k);
        }
        private int FindKthSortedArrays(int[] num1, int lo1, int hi1, int[] num2, int lo2, int hi2, int k)
        {
            int len1 = hi1 - lo1;
            int len2 = hi2 - lo2;
            //to ensure the len1 < len2
            if (len1 > len2)
                return FindKthSortedArrays(num2, lo2, hi2, num1, lo1, hi1, k);
            if (len1 == 0)
                return num2[lo2 + k - 1];
            if (k == 1)
                return System.Math.Min(num1[lo1], num2[lo2]);
            if (len1 <= 3 && len2 <= 3)
                return TrivalKthElement(num1, lo1, hi1, num2, lo2, hi2, k);
            int pa = System.Math.Min(k / 2, len1);
            if (num1[lo1 + pa - 1] < num2[lo2 + pa - 1])
                return FindKthSortedArrays(num1, lo1 + pa, hi1, num2, lo2, hi2, k - pa);
            else if (num1[lo1 + pa - 1] > num2[lo2 + pa - 1])
                return FindKthSortedArrays(num1, lo1, hi1, num2, lo2 + pa, hi2, k - pa);
            else
            {
                if (pa*2 == k)
                {
                    return num1[lo1 + pa - 1];
                }
                else
                {
                    return FindKthSortedArrays(num1,lo1+pa,hi1,num2,lo2+pa,hi2,k-pa-pa);
                }
                
            }
                
        }
        private int TrivalKthElement(int[] num1, int lo1, int hi1, int[] num2, int lo2, int hi2, int k)
        {
            int[] merge = new int[hi1 - lo1 + hi2 - lo2];
            int i = lo1;
            int j = lo2;
            int counter = 0;
            while (i < hi1 && j < hi2)
            {
                if (num1[i] < num2[j])
                    merge[counter++] = num1[i++];
                else
                    merge[counter++] = num2[j++];
            }
            while (i < hi1) merge[counter++] = num1[i++];
            while (j < hi2) merge[counter++] = num2[j++];
            return merge[k - 1];
        }
    }
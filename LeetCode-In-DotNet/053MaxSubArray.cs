public class Solution {
    public int MaxSubArray(int[] A) {
         int newsum=A[0];
         int max=A[0];
         for(int i=1;i<A.Length;i++){
             newsum=Math.Max(newsum+A[i],A[i]);
             max= Math.Max(max, newsum);
         }
           return max;
    }
}
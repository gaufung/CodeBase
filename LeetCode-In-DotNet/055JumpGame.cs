public class Solution {
    public bool CanJump(int[] nums) {
        bool[] res=new bool[nums.Length];
        List<int> enable=new List<int>();
        res[0]=true;
        enable.Add(0);
        for(int i=1;i<nums.Length;i++)
        {
           for(int j=enable.Count-1;j>=0;j--)
           {
               int index=enable[j];
               if(nums[index]>=i-index)
               {
                  res[i]=true;
                  enable.Add(i);
                  break;
               }
           }
        }
        return res[nums.Length-1];
    }
    
   
}
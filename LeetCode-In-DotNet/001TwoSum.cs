public class Solution {
    public int[] TwoSum(int[] nums, int target) {
       Dictionary<int,List<int>> dic=new Dictionary<int,List<int>>();
       int[] res=new int[2];
       for(int i=0;i<nums.Length;i++)
       {
           if(dic.ContainsKey(nums[i]))
           {
               dic[nums[i]].Add(i);
           }
           else{
               dic.Add(nums[i],new List<int>{i});
           }
       }
       foreach(var numKey in dic)
       {
           var left=target-numKey.Key;
           if(dic.ContainsKey(left))
           {
               if(left==numKey.Key)
               {
                   if(numKey.Value.Count>1)
                   {
                       res[0]=numKey.Value[0];
                       res[1]=numKey.Value[1];
                       break;
                   }
               }
               else{
                   res[0]=numKey.Value[0];
                   res[1]=dic[left][0];
                   break;
               }
           }
       }
       return res;
    }
}
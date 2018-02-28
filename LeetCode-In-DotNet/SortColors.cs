public class Solution {
    public void SortColors(int[] nums) {
       int head=0;
       int tailer=nums.Length-1;
       int cursor=0;
       while(cursor<=tailer)
       {
           if(nums[cursor]==0)
           {
               if(cursor!=head)
               {
                   Swap(nums,cursor,head);
                   head++;
                   continue;
               }
               else
                    head++;
           }
           else if(nums[cursor]==2)
           {
               if(cursor!=tailer)
               {
                   Swap(nums,cursor,tailer);
                   tailer--;
                   continue;
               }
               else
                    tailer--;
           }
           cursor++;
       }
       
    }
    private void Swap(int[] nums,int i,int j)
    {
        int temp=nums[i];
        nums[i]=nums[j];
        nums[j]=temp;
    }
    
}
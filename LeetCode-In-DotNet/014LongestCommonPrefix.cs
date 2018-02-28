public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if(strs.Length==0)
            return string.Empty;
        Array.Sort(strs);
        string first=strs[0];
        string last=strs[strs.Length-1];
        List<char> list=new List<char>(Math.Max(first.Length,last.Length));
        int firstPointer=0,lastPointer=0;
        while(firstPointer<first.Length&&lastPointer<last.Length)
        {
            if(first[firstPointer]==last[lastPointer])
            {
                list.Add(first[firstPointer]);
                firstPointer++;
                lastPointer++;
            }
            else
            {
                break;
            }
        }
        if(list.Count==0)return string.Empty;
        return new string(list.ToArray(),0,list.Count);
    }
}
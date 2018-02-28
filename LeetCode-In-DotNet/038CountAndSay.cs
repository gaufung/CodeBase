public class Solution {
    public string CountAndSay(int n) {
        string str="1";
        while(n>1)
        {
            str=Say(str);
            n--;
        }
        return str;
    }
    
    private string Say(string str)
    {
        StringBuilder sb=new StringBuilder();
        char curr=str[0];
        int count=0;
        for(int i=0;i<str.Length;i++)
        {
            if(str[i]==curr)
            {
                count++;
            }
            else
            {
                sb.Append(count.ToString()+new string(curr,1));
                curr=str[i];
                count=1;
            }
        }
        sb.Append(count.ToString()+new string(curr,1));
        return sb.ToString();
    }
}
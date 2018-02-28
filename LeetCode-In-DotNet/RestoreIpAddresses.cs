public class Solution {
    public IList<string> RestoreIpAddresses(string s) {
        IList<string> res=new List<string>();
        if(s.Length>12||s.Length<3)
            return res;
        IList<int> indexes=new List<int>();
        Restore(s,0,indexes,res);
        return res;
    }
    private void Restore(string s,int start,IList<int> indexes,IList<string> res)
    {
        if(indexes.Count==3)
        {
            string ip1=s.Substring(0,indexes[0]+1);
            if(!IsValidIPAddress(ip1)) return;
            string ip2=s.Substring(indexes[0]+1,indexes[1]-indexes[0]);
            if(!IsValidIPAddress(ip2)) return;
            string ip3=s.Substring(indexes[1]+1,indexes[2]-indexes[1]);
            if(!IsValidIPAddress(ip3)) return;
            string ip4=s.Substring(indexes[2]+1);
            if(!IsValidIPAddress(ip4)) return;
            res.Add(ip1+"."+ip2+"."+ip3+"."+ip4);
        }
        for(int i=start;i<s.Length;i++)
        {
            indexes.Add(i);
            Restore(s,i+1,indexes,res);
            indexes.RemoveAt(indexes.Count-1);
        }
    }
    
    
    
    private bool IsValidIPAddress(string str)
    {
        if((str.Length>1&&str[0]=='0')||str.Length==0||str.Length>3)return false;
        
        int value=Convert.ToInt32(str);
        return value>=0&&value<=255;
    }
}
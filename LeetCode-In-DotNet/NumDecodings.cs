public class Solution {
    public int NumDecodings(string s) {
        /*
        if(string.IsNullOrEmpty(s)) return 0;
        if(s.Length<=1) return CanDecode(s[0]);
        int[] res=new int[s.Length];
        res[0]=CanDecode(s[0]);
        res[1]=CanDecode(s[0],s[1]);
        for(int i=2;i<s.Length;i++)
        {
            res[i]=res[i-2]*CanDecode(s[i-1],s[i])
                +res[i-1]*CanDecode(s[i]);
        }
        return res[s.Length-1];
        */
        if(string.IsNullOrEmpty(s)) return 0;
        int[] res=new int[s.Length+2];
        for(int i=0;i<res.Length;i++)
        {
            res[i]=1;
        }
        for(int i=s.Length-1;i>=0;--i)
        {
            //self 
            if(s[i]=='0')
                res[i]=0;
            else
                res[i]=res[i+1];
            //self adn next
            if(i+1<s.Length&&(s[i]=='1'||(s[i]=='2'&&s[i+1]<='6')))
                res[i]+=res[i+2];
        }
        return res[0];
        
    }
    /*
    private int CanDecode(char character)
    {
        if(character>'0'&&character<='9')
            return 1;
        return 0;
    }
    private int CanDecode(char firstChar,char secondChar)
    {
        if(firstChar=='0')return 0;
        if((firstChar=='1'||firstChar=='2')&&secondChar=='0') return 1;
        if(firstChar=='1'&&secondChar>'0'&&secondChar<='9') return 2;
        if(firstChar=='2'&&secondChar>'0'&&secondChar<='6') return 2;
        return 1;
        
    }
    */
}
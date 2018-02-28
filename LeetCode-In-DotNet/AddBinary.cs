public class Solution {
    public string AddBinary(string a, string b) {
        if(string.IsNullOrEmpty(a)) return b;
        if(string.IsNullOrEmpty(b)) return a;
        List<char> list=new List<char>(Math.Max(a.Length,b.Length));
        bool isOver=false;
        int aPointer=a.Length-1;
        int bPointer=b.Length-1;
        while(aPointer>=0||bPointer>=0)
        {
            char aChar=aPointer>=0?a[aPointer--]:'0';
            char bChar=bPointer>=0?b[bPointer--]:'0';
            list.Add(CharAddChar(aChar,bChar,ref isOver));
        }
        if(isOver)
            list.Add('1');
        list.Reverse();
        return new string(list.ToArray(),0,list.Count);
      
        
    }
    int Char2Digit(char c)
    {
        return c=='1'?1:0;
    }
    char Digti2Char(int i)
    {
        return i==1?'1':'0'; 
    }
    char CharAddChar(char leftChar,char rightChar,ref bool isOver)
    {
        int leftValue=Char2Digit(leftChar);
        int rightValue=Char2Digit(rightChar);
        int res=(leftValue+rightValue+IsOver(isOver))%2;
        isOver=(leftValue+rightValue+IsOver(isOver))>=2?true:false;
        return Digti2Char(res);
    }
    int IsOver(bool isOver)
    {
        return isOver?1:0;
    }
}
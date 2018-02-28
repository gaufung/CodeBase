public class Solution {
    public IList<string> LetterCombinations(string digits) {
        List<string> res=new List<string>();
        List<Number> numbers=new List<Number>();
        if(digits.Length==0)return res;
        for(int i=0;i<digits.Length;i++)
        {
            numbers.Add(new Number(digits[i]));
        }
        do{
            char[] chars=new char[digits.Length];
            for(int i=0;i<numbers.Count;i++)
            {
                chars[i]=numbers[i].Current();
            }
            res.Add(new string(chars,0,chars.Length));
            int j=numbers.Count-1;
            bool flag=false;
            for(;j>=0;)
            {
                numbers[j].MoveNext();
                if (numbers[j].IsTailer())
                {
                    if (j == 0) 
                        break;
                    else
                        j--;
                    flag = true;
                }
                else
                {
                    break;
                }
            }
            
            if(j==0&&numbers[j].IsTailer())
            {
                 break;
            }
            if(flag)
            {
                for(++j;j<numbers.Count;j++)
                    numbers[j].Reset();
            }
        }while(true);        
        return res;
    }   
    public class Number
    {
        private int _current;
        private char[] _chars;
        public Number(char digit)
        {
            int number=Digit2Number(digit);
            _chars=DigitLetter(number);
            _current=0;
        }
        public char Current()
        {
            return _chars[_current];
        }
        public void MoveNext()
        {
           ++_current;
        }
        public void Reset()
        {
            _current=0;
        }
        public bool IsTailer()
        {
            return _current>=_chars.Length;
        }
        private char[] DigitLetter(int number)
        {
            int n=3;
            if(number==7||number==9) 
                n=4;
            char[] res=new char[n];
            if(number==2)
            {
                res[0]='a';res[1]='b';res[2]='c';
            }
            if(number==3)
            {
                res[0]='d';res[1]='e';res[2]='f';
            }
            if(number==4)
            {
                res[0]='g';res[1]='h';res[2]='i';
            }
            if(number==5)
            {
                res[0]='j';res[1]='k';res[2]='l';
            }
            if(number==6)
            {
                res[0]='m';res[1]='n';res[2]='o';
            }
            if(number==7)
            {
                res[0]='p';res[1]='q';res[2]='r';res[3]='s';
            }
            if(number==8)
            {
                res[0]='t';res[1]='u';res[2]='v';
            }
            if(number==9)
            {
                res[0]='w';res[1]='x';res[2]='y';res[3]='z';
            }
            return res;     
        }
        private int Digit2Number(char digit)
        {
            return digit-'0';
        }
}
    
    
}
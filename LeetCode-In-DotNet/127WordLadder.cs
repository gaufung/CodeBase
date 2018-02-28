public class Solution {
    public int LadderLength(string beginWord, string endWord, ISet<string> wordList) {
        if(string.IsNullOrEmpty(beginWord)||string.IsNullOrEmpty(endWord)||wordList.Count==0||beginWord.Length==0||endWord.Length==0)
            return 0;
        Queue<String> queue=new Queue<String>();
        queue.Enqueue(beginWord);
        queue.Enqueue(" ");
        int res=1;
        while(queue.Count!=0)
        {
            string str=queue.Peek();
            queue.Dequeue();
            if(str!=" ")
            {
                for(int i=0;i<str.Length;i++)
                {
                    char tmp=str[i];
                    for(char c='a';c<='z';c++)
                    {
                        if(c==tmp)
                            continue;
                        str=str.Remove(i).Insert(i,new String(c,1));
                        if(str==endWord)
                            return res+1;
                        if(wordList.Contains(str))
                        {
                            queue.Enqueue(str);
                            wordList.Remove(str);
                        }
                        str=str.Remove(i).Insert(i,new String(tmp,1));
                    }
                }
            }
            else if (queue.Count!=0)
            {
                res++;
                queue.Enqueue(" ");
            }
            
        }
        return 0;
    }
}
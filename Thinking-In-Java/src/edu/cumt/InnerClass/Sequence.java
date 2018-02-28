package edu.cumt.InnerClass;
/**
 * Created by gaufung on 09/06/2017.
 */
interface Selector{
    boolean end();
    Object current();
    void next();
}
public class Sequence {
    public Object[] items;
    private int next=0;
    public Sequence(int size){
        items = new Object[size];
    }
    public void add(Object obj){
        if(next<items.length){
            items[next++]=obj;
        }
    }
//    private class SequenceSelector implements Selector{
//        private int i =0;
//        public boolean end(){
//            return i==items.length;
//        }
//        public Object current(){
//            return items[i];
//        }
//        public void next() {
//            if(i<items.length)
//                i++;
//        }
//    }
    public Selector selector(){
        return new Selector() {
            private int i=0;
            @Override
            public boolean end() {
                return i==items.length;
            }

            @Override
            public Object current() {
                return items[i];
            }

            @Override
            public void next() {
                if(i< items.length)
                    i++;
            }
        };
    }
    public static void main(String[] args){
        Sequence sequence = new Sequence(10);
        for (int i = 0; i < 10; i++) {
            sequence.add(Integer.toString(i));
        }
        Selector selector = sequence.selector();
        while (!selector.end()){
            System.out.println(selector.current());
            selector.next();
        }

    }

}

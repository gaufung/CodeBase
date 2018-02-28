package edu.cumt.EIAO;

/**
 * Created by gaufung on 07/06/2017.
 */
public class Exercise {

    public static void main(String[] args){
//        Ex01();
        ex07();
    }
    static void Ex01()
    {
        int i;
        char ch;
    }
    static void ex07()
    {
        Increamentable i1 = new Increamentable();
        i1.increase();
    }
}

class Increamentable{
    static int i=47;
    public static void increase()
    {
        Increamentable.i++;
    }
}
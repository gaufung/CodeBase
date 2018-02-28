package edu.cumt.IC;

/**
 * Created by gaufung on 08/06/2017.
 */
public class InitialValues {
    boolean t;
    char c;
    byte b;
    short s;
    int i;
    long l;
    float f;
    double d;
    void printInital(){
//        System.out.println(i);
        System.out.println(t);
        System.out.println(c);
        System.out.println(b);
        System.out.println(s);
        System.out.println(i);
        System.out.println(l);
        System.out.println(f);
        System.out.println(d);
    }
    public static void main(String[] args){
        InitialValues iv = new InitialValues();
        iv.printInital();
    }
}

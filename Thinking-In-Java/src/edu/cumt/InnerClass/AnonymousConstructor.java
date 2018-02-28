package edu.cumt.InnerClass;

/**
 * Created by gaufung on 09/06/2017.
 */

abstract class Base{
    public Base(int i){
        System.out.println("Base constructor i= "+i);
    }
    public abstract void f();
}
public class AnonymousConstructor {
    public static Base getBase(int i){
        return new Base(i){
            {
                System.out.println("Inside instance initialize");
            }
            public void f()
            {
                System.out.println("in anonymous f()");
            }
        };
    }
    public static void main(String[] args){
        Base base = getBase(10);
        base.f();
    }
}

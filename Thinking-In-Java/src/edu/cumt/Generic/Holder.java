package edu.cumt.Generic;

/**
 * Created by gaufung on 11/06/2017.
 */
class Automobile{}

public class Holder<T> {
    private T a;
    public Holder(T a){this.a = a;}
    public void set(T a){this.a = a;}
    public T get(){return a;}
    public static void main(String[] args){
        Holder<Automobile> h =
                new Holder<>(new Automobile());
    }
}

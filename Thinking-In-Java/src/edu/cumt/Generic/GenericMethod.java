package edu.cumt.Generic;

/**
 * Created by gaufung on 11/06/2017.
 */
public class GenericMethod {
    public <T> void f(T x){
        System.out.println(x.getClass().getName());
    }
    public static void main(String[] args){
        GenericMethod gm = new GenericMethod();
        gm.f("");
        gm.f(1);
        gm.f(1.2);
        gm.f(gm);
    }
}

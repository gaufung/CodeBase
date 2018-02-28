package edu.cumt.Generic;

import java.util.ArrayList;

/**
 * Created by gaufung on 11/06/2017.
 */
class Base{}
class Derive extends  Base{}

class Myclass<T extends Base>{}
public class ErasedTypeEquivalence {
    public static void main(String[] args){
        Class c1 = new ArrayList<Integer>().getClass();
        Class c2 = new ArrayList<Double>().getClass();
        System.out.println(c1==c2);

        Class c3 = new Myclass<Base>().getClass();
        Class c4 = new Myclass<Derive>().getClass();
        System.out.println(c3==c4);
    }
}

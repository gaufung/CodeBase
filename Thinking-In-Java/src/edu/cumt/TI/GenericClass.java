package edu.cumt.TI;

/**
 * Created by gaufung on 11/06/2017.
 */
public class GenericClass {
    public static void main(String[] args){
        Class intClass = int.class;
        Class<Integer> genericIntClass = int.class;
        genericIntClass = intClass;
        intClass = double.class;
        // compile error
        //genericIntClass = double.class;

    }
}

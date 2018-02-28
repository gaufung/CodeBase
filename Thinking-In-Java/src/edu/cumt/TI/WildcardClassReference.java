package edu.cumt.TI;

/**
 * Created by gaufung on 11/06/2017.
 */
public class WildcardClassReference {
    public static void main(String[] args){
        Class<?> intClass = int.class;
        intClass = double.class;

        Class<? extends Number> bound = int.class;
        bound = double.class;
        bound = Number.class;
    }
}

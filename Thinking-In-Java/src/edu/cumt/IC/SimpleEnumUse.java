package edu.cumt.IC;

/**
 * Created by gaufung on 08/06/2017.
 */
enum Spiciness{
    NOT,MILD,MEDIUM,HOT,FLAMING
}

public class SimpleEnumUse {
    public static void main(String[] args){
        Spiciness howHot = Spiciness.HOT;
        System.out.println(howHot);
    }
}

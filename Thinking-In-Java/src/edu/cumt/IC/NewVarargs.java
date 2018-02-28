package edu.cumt.IC;

/**
 * Created by gaufung on 08/06/2017.
 */
public class NewVarargs {
    static void printArray(Object... args){
        for(Object obj:args){
            System.out.println(obj);
        }
    }
    public static void main(String[] args){
        printArray(1.2,0,12314L,112.58f);
        printArray();
    }
}

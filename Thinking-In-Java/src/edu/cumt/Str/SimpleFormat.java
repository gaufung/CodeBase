package edu.cumt.Str;

/**
 * Created by gaufung on 10/06/2017.
 */
public class SimpleFormat {

    public static void main(String[] args){
        int x = 5;
        double y = 5.3332;
        System.out.printf("Row1 [%d, %f]\n", x, y);
        System.out.format("Row1 [%d, %f]", x, y);
    }
}
